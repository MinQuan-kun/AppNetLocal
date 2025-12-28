using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Test.DTOs;

namespace Test
{
    public partial class frmLogin : Form
    {
        public event EventHandler<string> LoginSuccess;
        public string UserRole { get; private set; }

        public static string UserInfo { get; private set; } = "Bạn chưa đăng nhập!";

        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
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

        private Point mouseOffset;
        private bool isMouseDown = false;

        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOffset = new Point(-e.X, -e.Y);
                isMouseDown = true;
            }
        }

        private void frmLogin_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                Point mousePosition = Control.MousePosition;
                mousePosition.Offset(mouseOffset.X, mouseOffset.Y);
                this.Location = mousePosition;
            }
        }

        private void frmLogin_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left) isMouseDown = false;
        }


        private async void btnDangNhap_Click(object sender, EventArgs e)
        {
            string _username = txtUsername.Text;
            string _password = txtPassword.Text;

            if (string.IsNullOrEmpty(_username) || string.IsNullOrEmpty(_password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnDangNhap.Enabled = false;
                btnDangNhap.Text = "Đang xử lý...";

                var loginData = new { user_name = _username, password = _password };

                // Gọi API Login
                // Biến result khai báo ở đây sẽ không bị trùng nữa
                var result = await ApiClient.PostAsync<LoginResponse>("/auth/login", loginData);

                // Lưu Token và User
                ApiClient.Token = result.token;

                // Bây giờ gán được vì cả 2 đều là UserDTO
                ApiClient.CurrentUser = result.user;

                UserInfo = $"Xin chào: {result.user.user_name}";

                // Mở Form Main
                frmMain mainForm = new frmMain(UserInfo);
                this.Hide();
                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đăng nhập thất bại: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDangNhap.Enabled = true;
                btnDangNhap.Text = "Đăng nhập";
            }
        }

        private void btnIntro_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmGioithieu gioithieu = new frmGioithieu();
            gioithieu.ShowDialog();
            this.Show();
        }
    }
}