namespace Test
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.btnChucnang = new System.Windows.Forms.Button();
            this.btnDanhmuc = new System.Windows.Forms.Button();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.txtDate = new System.Windows.Forms.ToolStripLabel();
            this.lblInfor = new System.Windows.Forms.ToolStripLabel();
            this.btnReset = new System.Windows.Forms.Button();
            this.panelhethong = new System.Windows.Forms.Panel();
            this.btnClose = new Guna.UI2.WinForms.Guna2Button();
            this.guna2Elipse1 = new Guna.UI2.WinForms.Guna2Elipse(this.components);
            this.PanelMain = new System.Windows.Forms.Panel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnHethong = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.subpanelHethong = new System.Windows.Forms.Panel();
            this.btnThoat = new System.Windows.Forms.Button();
            this.btnDangxuat = new System.Windows.Forms.Button();
            this.subpanelChucnang = new System.Windows.Forms.Panel();
            this.subpanelDanhmuc = new System.Windows.Forms.Panel();
            this.btnMenu = new System.Windows.Forms.Button();
            this.btnHoadon = new System.Windows.Forms.Button();
            this.btnTaikhoan = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Logout = new System.Windows.Forms.ToolStripButton();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.SelectComputer = new System.Windows.Forms.Button();
            this.toolStrip2.SuspendLayout();
            this.panelhethong.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.subpanelHethong.SuspendLayout();
            this.subpanelChucnang.SuspendLayout();
            this.subpanelDanhmuc.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChucnang
            // 
            this.btnChucnang.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnChucnang.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnChucnang.FlatAppearance.BorderSize = 0;
            this.btnChucnang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChucnang.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnChucnang.Location = new System.Drawing.Point(0, 401);
            this.btnChucnang.Name = "btnChucnang";
            this.btnChucnang.Size = new System.Drawing.Size(225, 48);
            this.btnChucnang.TabIndex = 6;
            this.btnChucnang.Text = "Chức năng";
            this.btnChucnang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnChucnang.UseVisualStyleBackColor = false;
            this.btnChucnang.Click += new System.EventHandler(this.btnChucnang_Click);
            // 
            // btnDanhmuc
            // 
            this.btnDanhmuc.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnDanhmuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDanhmuc.FlatAppearance.BorderSize = 0;
            this.btnDanhmuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDanhmuc.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDanhmuc.Location = new System.Drawing.Point(0, 226);
            this.btnDanhmuc.Name = "btnDanhmuc";
            this.btnDanhmuc.Size = new System.Drawing.Size(225, 48);
            this.btnDanhmuc.TabIndex = 3;
            this.btnDanhmuc.Text = "Danh mục";
            this.btnDanhmuc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDanhmuc.UseVisualStyleBackColor = false;
            this.btnDanhmuc.Click += new System.EventHandler(this.btnDanhmuc_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.Color.Black;
            this.toolStrip2.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.txtDate,
            this.lblInfor,
            this.Logout});
            this.toolStrip2.Location = new System.Drawing.Point(6, 9);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(292, 27);
            this.toolStrip2.TabIndex = 11;
            this.toolStrip2.Text = "Bạn chưa đăng nhập";
            // 
            // txtDate
            // 
            this.txtDate.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(111, 24);
            this.txtDate.Text = "toolStripLabel1";
            // 
            // lblInfor
            // 
            this.lblInfor.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInfor.Name = "lblInfor";
            this.lblInfor.Size = new System.Drawing.Size(149, 24);
            this.lblInfor.Text = "Bạn chưa đăng nhập!";
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnReset.Location = new System.Drawing.Point(0, 0);
            this.btnReset.Name = "btnReset";
            this.btnReset.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnReset.Size = new System.Drawing.Size(225, 43);
            this.btnReset.TabIndex = 15;
            this.btnReset.Text = "Reset mật khẩu";
            this.btnReset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // panelhethong
            // 
            this.panelhethong.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panelhethong.Controls.Add(this.toolStrip2);
            this.panelhethong.Controls.Add(this.pictureBox4);
            this.panelhethong.Controls.Add(this.btnClose);
            this.panelhethong.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelhethong.Location = new System.Drawing.Point(246, 0);
            this.panelhethong.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.panelhethong.Name = "panelhethong";
            this.panelhethong.Size = new System.Drawing.Size(804, 36);
            this.panelhethong.TabIndex = 16;
            // 
            // btnClose
            // 
            this.btnClose.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnClose.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnClose.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FillColor = System.Drawing.Color.Black;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnClose.ForeColor = System.Drawing.Color.White;
            this.btnClose.Image = global::Test.Properties.Resources.close123;
            this.btnClose.Location = new System.Drawing.Point(756, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 36);
            this.btnClose.TabIndex = 1;
            this.btnClose.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // PanelMain
            // 
            this.PanelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelMain.Location = new System.Drawing.Point(246, 0);
            this.PanelMain.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PanelMain.Name = "PanelMain";
            this.PanelMain.Size = new System.Drawing.Size(804, 700);
            this.PanelMain.TabIndex = 17;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnHethong
            // 
            this.btnHethong.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnHethong.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHethong.FlatAppearance.BorderSize = 0;
            this.btnHethong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHethong.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHethong.Location = new System.Drawing.Point(0, 100);
            this.btnHethong.Name = "btnHethong";
            this.btnHethong.Size = new System.Drawing.Size(225, 43);
            this.btnHethong.TabIndex = 1;
            this.btnHethong.Text = "Hệ thống";
            this.btnHethong.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHethong.UseVisualStyleBackColor = false;
            this.btnHethong.Click += new System.EventHandler(this.btnHethong_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.label2);
            this.panelLogo.Controls.Add(this.pictureBox1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(225, 100);
            this.panelLogo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(4, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Hệ thống net";
            // 
            // subpanelHethong
            // 
            this.subpanelHethong.Controls.Add(this.btnThoat);
            this.subpanelHethong.Controls.Add(this.btnDangxuat);
            this.subpanelHethong.Dock = System.Windows.Forms.DockStyle.Top;
            this.subpanelHethong.Location = new System.Drawing.Point(0, 143);
            this.subpanelHethong.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.subpanelHethong.Name = "subpanelHethong";
            this.subpanelHethong.Size = new System.Drawing.Size(225, 83);
            this.subpanelHethong.TabIndex = 2;
            // 
            // btnThoat
            // 
            this.btnThoat.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnThoat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnThoat.FlatAppearance.BorderSize = 0;
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnThoat.Location = new System.Drawing.Point(0, 37);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnThoat.Size = new System.Drawing.Size(225, 43);
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThoat.UseVisualStyleBackColor = false;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangxuat
            // 
            this.btnDangxuat.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDangxuat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDangxuat.FlatAppearance.BorderSize = 0;
            this.btnDangxuat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDangxuat.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnDangxuat.Location = new System.Drawing.Point(0, 0);
            this.btnDangxuat.Name = "btnDangxuat";
            this.btnDangxuat.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnDangxuat.Size = new System.Drawing.Size(225, 37);
            this.btnDangxuat.TabIndex = 8;
            this.btnDangxuat.Text = "Đăng xuất";
            this.btnDangxuat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDangxuat.UseVisualStyleBackColor = false;
            this.btnDangxuat.Click += new System.EventHandler(this.btnDangxuat_Click);
            // 
            // subpanelChucnang
            // 
            this.subpanelChucnang.Controls.Add(this.SelectComputer);
            this.subpanelChucnang.Controls.Add(this.btnReset);
            this.subpanelChucnang.Dock = System.Windows.Forms.DockStyle.Top;
            this.subpanelChucnang.Location = new System.Drawing.Point(0, 449);
            this.subpanelChucnang.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.subpanelChucnang.Name = "subpanelChucnang";
            this.subpanelChucnang.Size = new System.Drawing.Size(225, 401);
            this.subpanelChucnang.TabIndex = 8;
            // 
            // subpanelDanhmuc
            // 
            this.subpanelDanhmuc.Controls.Add(this.btnMenu);
            this.subpanelDanhmuc.Controls.Add(this.btnHoadon);
            this.subpanelDanhmuc.Controls.Add(this.btnTaikhoan);
            this.subpanelDanhmuc.Dock = System.Windows.Forms.DockStyle.Top;
            this.subpanelDanhmuc.Location = new System.Drawing.Point(0, 274);
            this.subpanelDanhmuc.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.subpanelDanhmuc.Name = "subpanelDanhmuc";
            this.subpanelDanhmuc.Size = new System.Drawing.Size(225, 127);
            this.subpanelDanhmuc.TabIndex = 4;
            // 
            // btnMenu
            // 
            this.btnMenu.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenu.FlatAppearance.BorderSize = 0;
            this.btnMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenu.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnMenu.Location = new System.Drawing.Point(0, 80);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnMenu.Size = new System.Drawing.Size(225, 40);
            this.btnMenu.TabIndex = 5;
            this.btnMenu.Text = "Menu";
            this.btnMenu.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenu.UseVisualStyleBackColor = false;
            // 
            // btnHoadon
            // 
            this.btnHoadon.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnHoadon.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHoadon.FlatAppearance.BorderSize = 0;
            this.btnHoadon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHoadon.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnHoadon.Location = new System.Drawing.Point(0, 40);
            this.btnHoadon.Name = "btnHoadon";
            this.btnHoadon.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnHoadon.Size = new System.Drawing.Size(225, 40);
            this.btnHoadon.TabIndex = 3;
            this.btnHoadon.Text = "Hóa đơn";
            this.btnHoadon.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHoadon.UseVisualStyleBackColor = false;
            // 
            // btnTaikhoan
            // 
            this.btnTaikhoan.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnTaikhoan.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTaikhoan.FlatAppearance.BorderSize = 0;
            this.btnTaikhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaikhoan.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnTaikhoan.Location = new System.Drawing.Point(0, 0);
            this.btnTaikhoan.Name = "btnTaikhoan";
            this.btnTaikhoan.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.btnTaikhoan.Size = new System.Drawing.Size(225, 40);
            this.btnTaikhoan.TabIndex = 0;
            this.btnTaikhoan.Text = "Tài khoản";
            this.btnTaikhoan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTaikhoan.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel1.Controls.Add(this.subpanelChucnang);
            this.panel1.Controls.Add(this.btnChucnang);
            this.panel1.Controls.Add(this.subpanelDanhmuc);
            this.panel1.Controls.Add(this.btnDanhmuc);
            this.panel1.Controls.Add(this.subpanelHethong);
            this.panel1.Controls.Add(this.btnHethong);
            this.panel1.Controls.Add(this.panelLogo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(246, 700);
            this.panel1.TabIndex = 15;
            // 
            // Logout
            // 
            this.Logout.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Logout.Image = ((System.Drawing.Image)(resources.GetObject("Logout.Image")));
            this.Logout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Logout.Name = "Logout";
            this.Logout.Size = new System.Drawing.Size(29, 24);
            this.Logout.Text = "Đăng xuất";
            this.Logout.Click += new System.EventHandler(this.btnDangxuat_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(-21, -23);
            this.pictureBox4.Margin = new System.Windows.Forms.Padding(4, 7, 4, 7);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(309, 350);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 9;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(225, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // SelectComputer
            // 
            this.SelectComputer.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.SelectComputer.Dock = System.Windows.Forms.DockStyle.Top;
            this.SelectComputer.FlatAppearance.BorderSize = 0;
            this.SelectComputer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SelectComputer.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.SelectComputer.Location = new System.Drawing.Point(0, 43);
            this.SelectComputer.Name = "SelectComputer";
            this.SelectComputer.Padding = new System.Windows.Forms.Padding(35, 0, 0, 0);
            this.SelectComputer.Size = new System.Drawing.Size(225, 43);
            this.SelectComputer.TabIndex = 16;
            this.SelectComputer.Text = "Chọn máy";
            this.SelectComputer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SelectComputer.UseVisualStyleBackColor = false;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1050, 700);
            this.Controls.Add(this.panelhethong);
            this.Controls.Add(this.PanelMain);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(1600, 900);
            this.MinimumSize = new System.Drawing.Size(1050, 700);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panelhethong.ResumeLayout(false);
            this.panelhethong.PerformLayout();
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.subpanelHethong.ResumeLayout(false);
            this.subpanelChucnang.ResumeLayout(false);
            this.subpanelDanhmuc.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnChucnang;
        private System.Windows.Forms.Button btnDanhmuc;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel txtDate;
        private System.Windows.Forms.ToolStripLabel lblInfor;
        private System.Windows.Forms.ToolStripButton Logout;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Panel panelhethong;
        private System.Windows.Forms.PictureBox pictureBox4;
        private Guna.UI2.WinForms.Guna2Button btnClose;
        private Guna.UI2.WinForms.Guna2Elipse guna2Elipse1;
        private System.Windows.Forms.Panel PanelMain;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnHethong;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel subpanelHethong;
        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.Button btnDangxuat;
        private System.Windows.Forms.Panel subpanelChucnang;
        private System.Windows.Forms.Panel subpanelDanhmuc;
        private System.Windows.Forms.Button btnMenu;
        private System.Windows.Forms.Button btnHoadon;
        private System.Windows.Forms.Button btnTaikhoan;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button SelectComputer;
    }
}