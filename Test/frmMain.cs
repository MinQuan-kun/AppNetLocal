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

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            UpdateLoginState();
            btnMenu.PerformClick();
            SetRoundedCorners(30);
        }
        private void SetRoundedCorners(int radius)
        {
            radius = Math.Min(radius, Math.Min(this.Width / 2, this.Height / 2));
            var path = new GraphicsPath();
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            txtDate.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss ");
        }


        private void customizeDesign()
        {
            subpanelHethong.Visible = false;
            subpanelDanhmuc.Visible = false;
            subpanelChucnang.Visible = false;
            //ThucDon.Visible = false;
            //Taikhoan.Visible = false;
            //The.Visible = false;
        }

        private void hideSubMenu()
        {
            if (subpanelHethong.Visible)
                subpanelHethong.Visible = false;
            if (subpanelDanhmuc.Visible)
                subpanelDanhmuc.Visible = false;
            if (subpanelChucnang.Visible)
                subpanelChucnang.Visible = false;
        }
        private void showSubMenu(Panel subMenu)
        {
            if (!subMenu.Visible)
            {
                hideSubMenu();
                subMenu.Visible = true;
            }
            else
            {
                subMenu.Visible = false;
            }
        }

        private void InitializeComputerPanel()
        {
            pnlComputers = new Panel();
            pnlComputers.Location = new Point(250, 60); 
            pnlComputers.Size = new Size(900, 600);
            pnlComputers.AutoScroll = true;
            pnlComputers.BackColor = Color.FromArgb(20, 20, 30); 
            this.Controls.Add(pnlComputers);
        }

        private async Task LoadComputerMap()
        {
            try
            {
                pnlComputers.Controls.Clear();
                var computers = await ApiClient.GetComputersAsync();

                int buttonSize = 60;
                int gap = 10;

                foreach (var comp in computers)
                {
                    Button btnComp = new Button();
                    btnComp.Text = comp.computer_name;
                    btnComp.Size = new Size(buttonSize, buttonSize);

                    // Tính vị trí dựa trên grid x, y (giống web)
                    // Lưu ý: Web x=row, y=col hoặc ngược lại tùy db, cần test để khớp
                    btnComp.Location = new Point(comp.y * (buttonSize + gap), comp.x * (buttonSize + gap));
                    btnComp.Tag = comp; // Lưu đối tượng Computer vào button
                    btnComp.FlatStyle = FlatStyle.Flat;
                    btnComp.Click += Computer_Click;

                    // Màu sắc theo trạng thái
                    switch (comp.status)
                    {
                        case "trong":
                            btnComp.BackColor = Color.Green;
                            btnComp.ForeColor = Color.White;
                            break;
                        case "co nguoi":
                            btnComp.BackColor = Color.Red;
                            btnComp.ForeColor = Color.White;
                            break;
                        case "dat truoc":
                            btnComp.BackColor = Color.Orange; // Màu vàng cam cho đặt trước
                            btnComp.ForeColor = Color.White;
                            break;
                        default: // bao tri
                            btnComp.BackColor = Color.Gray;
                            btnComp.Enabled = false;
                            break;
                    }

                    pnlComputers.Controls.Add(btnComp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải sơ đồ máy: " + ex.Message);
            }
        }

        private async void Computer_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            Computer comp = btn.Tag as Computer;
            int currentUserId = ApiClient.CurrentUser.user_id;

            // Logic kiểm tra điều kiện vào máy
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
                    var requestData = new { computerId = comp.computer_id, userId = currentUserId };

                    // Gọi API start-session (API này trên server đã có logic hoàn tiền nếu status="dat truoc")
                    var result = await ApiClient.PostAsync<ApiResponse>("/computers/start-session", requestData);

                    MessageBox.Show(result.message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Cập nhật lại số dư hiển thị nếu cần
                    if (result.new_balance.HasValue)
                    {
                        ApiClient.CurrentUser.balance = result.new_balance.Value;
                        // Cập nhật label hiển thị tiền (nếu có)
                    }

                    // Load lại map để cập nhật màu đỏ (online)
                    await LoadComputerMap();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi vào máy: " + ex.Message);
                }
            }
        }

        private void UpdateLoginState()
        {
            if (ApiClient.CurrentUser != null)
            {
                lblInfor.Text = $"Xin chào: {ApiClient.CurrentUser.user_name} | Số dư: {ApiClient.CurrentUser.balance:N0} đ";

                // 2. Bật nút đăng xuất
                btnDangxuat.Enabled = true;
                Logout.Enabled = true;

                int roleId = ApiClient.CurrentUser.role_id;

                if (roleId == 1 || roleId == 2)
                {
                    // Là Admin hoặc Nhân viên -> Bật chức năng quản lý
                    btnChucnang.Enabled = true;
                    btnDanhmuc.Enabled = true;

                    // Ví dụ: Ẩn nút Tài khoản nếu là Staff (giống logic cũ của bạn)
                    if (roleId == 2)
                    {
                        // btnTaikhoan.Visible = false; 
                    }
                }
                else
                {
                    // Là User thường (Khách) -> Tắt chức năng quản lý hệ thống
                    btnChucnang.Enabled = false;
                    btnDanhmuc.Enabled = false;
                }
            }
            else
            {
                // --- TRƯỜNG HỢP CHƯA ĐĂNG NHẬP ---
                lblInfor.Text = "Bạn chưa đăng nhập!";

                btnDangxuat.Enabled = false;
                Logout.Enabled = false;

                btnChucnang.Enabled = false;
                btnDanhmuc.Enabled = false;
            }
        }

        //Hiện thị subMenu
        private void btnHethong_Click(object sender, EventArgs e)
        {
            showSubMenu(subpanelHethong);
        }
        private void btnDanhmuc_Click(object sender, EventArgs e)
        {
            showSubMenu(subpanelDanhmuc);
        }
        private void btnChucnang_Click(object sender, EventArgs e)
        {
            showSubMenu(subpanelChucnang);
        }

        private async void btnDangxuat_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    // Gọi API Logout để server set trạng thái về offline và máy về trống (nếu đang chơi)
                    await ApiClient.PostAsync<object>("/auth/logout", new { });
                }
                catch
                {
                    // Kệ lỗi mạng khi logout, vẫn cho logout ở client
                }

                // Xóa thông tin local
                ApiClient.Token = null;
                ApiClient.CurrentUser = null;
                infor = "Bạn chưa đăng nhập!";

                // Chuyển về màn hình login (giữ nguyên code cũ của bạn đoạn này)
                PanelMain.Controls.Clear();
                if (pnlComputers != null) pnlComputers.Visible = false; // Ẩn map đi

                frmLogin loginForm = new frmLogin
                {
                    TopLevel = false,
                    FormBorderStyle = FormBorderStyle.None,
                };

                loginForm.LoginSuccess += LoginForm_LoginSuccess;
                PanelMain.Controls.Add(loginForm);
                loginForm.Show();
                CenterFormInPanel(loginForm);
                UpdateLoginState();
            }
        }


        // Xử lý sự kiện khi đăng nhập lại thành công
        private void LoginForm_LoginSuccess(object sender, string username)
        {
            infor = $"Đăng nhập thành công: {username}";
            UpdateLoginState();
            PanelMain.Controls.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        // Hàm căn giữa form trong PanelMain
        private void CenterFormInPanel(Form form)
        {
            int x = (PanelMain.Width - form.Width) / 2;
            int y = (PanelMain.Height - form.Height) / 2;
            form.Location = new Point(x, y);
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            PanelMain.Controls.Clear();

            frmLogin loginForm = new frmLogin
            {
                TopLevel = false,              
                FormBorderStyle = FormBorderStyle.None,
            };

            PanelMain.Controls.Add(loginForm);
            loginForm.Show();
            CenterFormInPanel(loginForm);
        }


        
        private void btnDatmay_Click(object sender, EventArgs e)
        {

        }


        private void btnNhaphang_Click(object sender, EventArgs e)
        {
            PanelMain.Controls.Clear();

        }
    }
}
