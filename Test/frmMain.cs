using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Test.DTOs;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

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

            // --- SỬA 1: Phải gọi hàm này máy mới hiện ra ---
            await LoadComputerMap();

            SetRoundedCorners(30);
        }

        private async Task LoadComputerMap()
        {
            // Kiểm tra Token để tránh lỗi 401 khi chưa đăng nhập
            if (string.IsNullOrEmpty(ApiClient.Token)) return;

            try
            {
                var computers = await ApiClient.GetComputersAsync();
                pnlComputers.Controls.Clear();

                int buttonSize = 60;
                int gap = 10;

                foreach (var comp in computers)
                {
                    Button btnComp = new Button();
                    btnComp.Text = $"{comp.computer_name}\n({comp.status})";
                    btnComp.Size = new Size(buttonSize, buttonSize);

                    // Web: x=row, y=col -> Winform: Top=x, Left=y
                    btnComp.Left = (comp.y - 1) * (buttonSize + gap) + gap;
                    btnComp.Top = (comp.x - 1) * (buttonSize + gap) + gap;

                    btnComp.Tag = comp;
                    btnComp.FlatStyle = FlatStyle.Flat;
                    btnComp.Font = new Font("Arial", 8, FontStyle.Bold);
                    btnComp.Click += Computer_Click;

                    switch (comp.status)
                    {
                        case "trong": btnComp.BackColor = Color.ForestGreen; btnComp.ForeColor = Color.White; break;
                        case "co nguoi": btnComp.BackColor = Color.Firebrick; btnComp.ForeColor = Color.White; break;
                        case "dat truoc": btnComp.BackColor = Color.DarkOrange; btnComp.ForeColor = Color.White; break;
                        default: btnComp.BackColor = Color.DimGray; btnComp.Enabled = false; break;
                    }

                    // Highlight máy của mình
                    if (ApiClient.CurrentUser != null && comp.current_user_id == ApiClient.CurrentUser.user_id)
                    {
                        btnComp.FlatAppearance.BorderColor = Color.Yellow;
                        btnComp.FlatAppearance.BorderSize = 3;
                        btnComp.Text += "\n(Bạn)";
                    }

                    pnlComputers.Controls.Add(btnComp);
                }
            }
            catch (Exception ex)
            {
                // Bỏ qua lỗi kết nối ngầm
            }
        }

        private async void Computer_Click(object sender, EventArgs e)
        {
            if (ApiClient.CurrentUser == null) return;

            Button btn = sender as Button;
            Computer comp = btn.Tag as Computer;
            int currentUserId = ApiClient.CurrentUser.user_id;

            if (comp.status == "co nguoi")
            {
                MessageBox.Show("Máy này đang có người chơi!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (comp.status == "dat truoc" && comp.current_user_id != currentUserId)
            {
                MessageBox.Show("Máy này đã được người khác đặt trước!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string msg = comp.status == "dat truoc"
                ? $"Máy {comp.computer_name} đã được bạn đặt cọc.\nBạn muốn vào chơi và nhận hoàn tiền cọc không?"
                : $"Bạn có muốn bắt đầu chơi tại máy {comp.computer_name}?";

            if (MessageBox.Show(msg, "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    // --- SỬA 2: Đổi tên thành computer_id và user_id (có dấu gạch dưới) ---
                    var requestData = new { computer_id = comp.computer_id, user_id = currentUserId };

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

        // --- Giữ nguyên các hàm thiết kế giao diện ---
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
                btnChucnang.Enabled = isManager; btnDanhmuc.Enabled = isManager;
            }
            else
            {
                lblInfor.Text = "Bạn chưa đăng nhập!";
                btnDangxuat.Enabled = false; Logout.Enabled = false;
                btnChucnang.Enabled = false; btnDanhmuc.Enabled = false;
            }
        }

        private async void btnDangxuat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try { await ApiClient.PostAsync<object>("/auth/logout", new { }); } catch { }
                ApiClient.Token = null; ApiClient.CurrentUser = null; infor = "Bạn chưa đăng nhập!";
                if (pnlComputers != null) pnlComputers.Visible = false;

                PanelMain.Controls.Clear();
                frmLogin loginForm = new frmLogin { TopLevel = false, FormBorderStyle = FormBorderStyle.None };
                loginForm.LoginSuccess += LoginForm_LoginSuccess;
                PanelMain.Controls.Add(loginForm);
                loginForm.Show(); CenterFormInPanel(loginForm);
                UpdateLoginState();
            }
        }

        // --- Các hàm phụ trợ khác giữ nguyên ---
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
        private void btnDanhmuc_Click(object sender, EventArgs e) { showSubMenu(subpanelDanhmuc); }
        private void btnChucnang_Click(object sender, EventArgs e) { showSubMenu(subpanelChucnang); }
        private void LoginForm_LoginSuccess(object sender, string username) { infor = $"Đăng nhập thành công: {username}"; UpdateLoginState(); PanelMain.Controls.Clear(); if (pnlComputers != null) pnlComputers.Visible = true; LoadComputerMap(); }
        private void btnClose_Click(object sender, EventArgs e) { if (MessageBox.Show("Thoát?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes) Application.Exit(); }
        private void CenterFormInPanel(Form form) { int x = (PanelMain.Width - form.Width) / 2; int y = (PanelMain.Height - form.Height) / 2; form.Location = new Point(x, y); }
        private void btnThoat_Click(object sender, EventArgs e) { if (MessageBox.Show("Thoát?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes) Application.Exit(); }
        private void btnDangNhap_Click(object sender, EventArgs e) { PanelMain.Controls.Clear(); frmLogin loginForm = new frmLogin { TopLevel = false, FormBorderStyle = FormBorderStyle.None }; PanelMain.Controls.Add(loginForm); loginForm.Show(); CenterFormInPanel(loginForm); }
        private void btnDatmay_Click(object sender, EventArgs e) { }
        private void btnNhaphang_Click(object sender, EventArgs e) { PanelMain.Controls.Clear(); }
    }
}