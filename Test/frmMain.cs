using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.DTOs;

namespace Test
{
    public partial class frmMain : Form
    {
        private Panel pnlComputers;
        public static string infor = "Bạn chưa đăng nhập!";

        public frmMain()
        {
            InitializeComponent();
            customizeDesign();
        }

        public frmMain(string _infor)
        {
            InitializeComponent();
            customizeDesign();
            infor = _infor;
            lblInfor.Text = infor;
            InitializeComputerPanel();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            UpdateLoginState();
            await LoadComputerMap(); // Load map ngay
            SetRoundedCorners(30);
        }

        private async Task LoadComputerMap()
        {
            if (string.IsNullOrEmpty(ApiClient.Token)) return;

            try
            {
                var computers = await ApiClient.GetComputersAsync();

                if (pnlComputers == null) InitializeComputerPanel();
                pnlComputers.Controls.Clear();

                int buttonSize = 60;
                int gap = 10;

                foreach (var comp in computers)
                {
                    Button btnComp = new Button();
                    btnComp.Text = $"{comp.computer_name}\n({comp.status})";
                    btnComp.Size = new Size(buttonSize, buttonSize);

                    btnComp.Left = (comp.y - 1) * (buttonSize + gap) + gap;
                    btnComp.Top = (comp.x - 1) * (buttonSize + gap) + gap;

                    btnComp.Tag = comp;
                    btnComp.FlatStyle = FlatStyle.Flat;
                    btnComp.Font = new Font("Arial", 8, FontStyle.Bold);
                    btnComp.Click += Computer_Click;

                    // --- MÀU SẮC THEO YÊU CẦU ---
                    switch (comp.status)
                    {
                        case "trong":
                            btnComp.BackColor = Color.ForestGreen;
                            btnComp.ForeColor = Color.White;
                            break;
                        case "co nguoi":
                            btnComp.BackColor = Color.Firebrick;
                            btnComp.ForeColor = Color.White;
                            break;
                        case "dat truoc": // Đổi thành MÀU VÀNG
                            btnComp.BackColor = Color.Gold;
                            btnComp.ForeColor = Color.Black; // Chữ đen cho dễ đọc trên nền vàng
                            break;
                        default:
                            btnComp.BackColor = Color.DimGray;
                            btnComp.Enabled = false;
                            break;
                    }

                    // Highlight máy của mình (Viền đỏ đậm)
                    if (ApiClient.CurrentUser != null && comp.current_user_id == ApiClient.CurrentUser.user_id)
                    {
                        btnComp.FlatAppearance.BorderColor = Color.Red;
                        btnComp.FlatAppearance.BorderSize = 3;
                        btnComp.Text += "\n(Của Bạn)";
                    }
                    pnlComputers.Controls.Add(btnComp);
                }
            }
            catch (Exception ex) { }
        }

        private async void Computer_Click(object sender, EventArgs e)
        {
            if (ApiClient.CurrentUser == null) return;
            Button btn = sender as Button;
            Computer comp = btn.Tag as Computer;
            int currentUserId = ApiClient.CurrentUser.user_id;

            // 1. CHẶN MÁY TRỐNG
            if (comp.status == "trong")
            {
                MessageBox.Show("Bạn phải đặt trước máy trên Website mới được vào chơi!",
                    "Yêu cầu", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 2. CHẶN MÁY ĐANG CÓ NGƯỜI CHƠI
            if (comp.status == "co nguoi")
            {
                MessageBox.Show("Máy này đang có người chơi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. CHẶN MÁY NGƯỜI KHÁC ĐẶT
            if (comp.status == "dat truoc" && comp.current_user_id != currentUserId)
            {
                MessageBox.Show("Máy này đã được người khác đặt trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 4. XỬ LÝ VÀO MÁY CỦA MÌNH
            if (comp.status == "dat truoc" && comp.current_user_id == currentUserId)
            {
                string msg = $"Chào mừng! Máy {comp.computer_name} là của bạn.\nXác nhận vào chơi? (Tiền cọc sẽ được hoàn lại).";

                if (MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        // Gửi cả 2 kiểu tên biến để chắc chắn Server nhận được
                        var requestData = new
                        {
                            computer_id = comp.computer_id,
                            computerId = comp.computer_id,

                            user_id = currentUserId,
                            userId = currentUserId
                        };

                        var result = await ApiClient.PostAsync<ApiResponse>("/computers/start-session", requestData);

                        MessageBox.Show(result.message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (result.new_balance.HasValue)
                        {
                            ApiClient.CurrentUser.balance = result.new_balance.Value;
                            UpdateLoginState();
                        }
                        await LoadComputerMap();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message);
                    }
                }
            }
        }

        // --- Các hàm phụ trợ giữ nguyên từ code cũ của bạn ---
        private void InitializeComputerPanel()
        {
            if (pnlComputers != null) this.Controls.Remove(pnlComputers);
            pnlComputers = new Panel();
            pnlComputers.Location = new Point(250, 60);
            pnlComputers.Size = new Size(900, 600);
            pnlComputers.AutoScroll = true;
            pnlComputers.BackColor = Color.FromArgb(30, 30, 40);
            this.Controls.Add(pnlComputers);
            pnlComputers.BringToFront();
        }

        private void UpdateLoginState()
        {
            if (ApiClient.CurrentUser != null)
            {
                lblInfor.Text = $"Xin chào: {ApiClient.CurrentUser.user_name} | Số dư: {ApiClient.CurrentUser.balance:N0} đ";
                btnDangxuat.Enabled = true; Logout.Enabled = true;
                bool isManager = (ApiClient.CurrentUser.role_id == 1 || ApiClient.CurrentUser.role_id == 2);
            }
            else
            {
                lblInfor.Text = "Bạn chưa đăng nhập!";
                btnDangxuat.Enabled = false; Logout.Enabled = false;
            }
        }

        private async void btnDangxuat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try { await ApiClient.PostAsync<object>("/auth/logout", new { }); } catch { }
                ApiClient.Token = null; ApiClient.CurrentUser = null; infor = "Bạn chưa đăng nhập!";
                if (pnlComputers != null) pnlComputers.Visible = false;
                PanelMain.Controls.Clear();
                frmLogin loginForm = new frmLogin { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
                loginForm.LoginSuccess += LoginForm_LoginSuccess;
                PanelMain.Controls.Add(loginForm); loginForm.Show(); CenterFormInPanel(loginForm);
                UpdateLoginState();
            }
        }

        // Các hàm giao diện khác giữ nguyên...
        private void SetRoundedCorners(int radius)
        {
            radius = Math.Min(radius, Math.Min(this.Width / 2, this.Height / 2));
            var path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures(); this.Region = new Region(path);
        }
        private void timer1_Tick(object sender, EventArgs e) { txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss "); }
        private void customizeDesign() { subpanelHethong.Visible = false; subpanelDanhmuc.Visible = false; subpanelChucnang.Visible = false; }
        private void hideSubMenu() { if (subpanelHethong.Visible) subpanelHethong.Visible = false; if (subpanelDanhmuc.Visible) subpanelDanhmuc.Visible = false; if (subpanelChucnang.Visible) subpanelChucnang.Visible = false; }
        private void showSubMenu(Panel subMenu) { if (!subMenu.Visible) { hideSubMenu(); subMenu.Visible = true; } else { subMenu.Visible = false; } }
        private void btnHethong_Click(object sender, EventArgs e) { showSubMenu(subpanelHethong); }
        private void LoginForm_LoginSuccess(object sender, string username) { infor = $"Đăng nhập thành công: {username}"; UpdateLoginState(); PanelMain.Controls.Clear(); if (pnlComputers != null) pnlComputers.Visible = true; LoadComputerMap(); }
        private void btnClose_Click(object sender, EventArgs e) { if (MessageBox.Show("Thoát?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes) Application.Exit(); }
        private void CenterFormInPanel(Form form) { int x = (PanelMain.Width - form.Width) / 2; int y = (PanelMain.Height - form.Height) / 2; form.Location = new Point(x, y); }
        private void btnThoat_Click(object sender, EventArgs e) { if (MessageBox.Show("Thoát?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes) Application.Exit(); }

    }
}