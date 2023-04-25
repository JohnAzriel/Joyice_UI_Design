namespace Joyice
{
    partial class homePageAdmin
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
            this.lbluserID = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlScreen = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.icnbtnHome = new FontAwesome.Sharp.IconButton();
            this.icnbtnUsers = new FontAwesome.Sharp.IconButton();
            this.icnbtnProdCat = new FontAwesome.Sharp.IconButton();
            this.icnbtnProducts = new FontAwesome.Sharp.IconButton();
            this.icnbtnBackup = new FontAwesome.Sharp.IconButton();
            this.icnbtnLogout = new FontAwesome.Sharp.IconButton();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.icnBtnCustomers = new FontAwesome.Sharp.IconButton();
            this.icnbtnReports = new FontAwesome.Sharp.IconButton();
            this.pnlScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbluserID
            // 
            this.lbluserID.AutoSize = true;
            this.lbluserID.Location = new System.Drawing.Point(1277, 652);
            this.lbluserID.Name = "lbluserID";
            this.lbluserID.Size = new System.Drawing.Size(38, 13);
            this.lbluserID.TabIndex = 21;
            this.lbluserID.Text = "userID";
            this.lbluserID.Visible = false;
            this.lbluserID.Click += new System.EventHandler(this.lbluserID_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(592, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 24;
            this.label1.Text = "Home";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1477, 40);
            this.panel2.TabIndex = 28;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(144, 405);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1224, 76);
            this.label2.TabIndex = 0;
            this.label2.Text = "WELCOME JOYICE ADMIN MESSAGE";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // pnlScreen
            // 
            this.pnlScreen.BackColor = System.Drawing.Color.Transparent;
            this.pnlScreen.Controls.Add(this.label2);
            this.pnlScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScreen.ForeColor = System.Drawing.Color.White;
            this.pnlScreen.Location = new System.Drawing.Point(200, 40);
            this.pnlScreen.Name = "pnlScreen";
            this.pnlScreen.Size = new System.Drawing.Size(1477, 978);
            this.pnlScreen.TabIndex = 30;
            this.pnlScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlScreen_Paint);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(47, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // icnbtnHome
            // 
            this.icnbtnHome.FlatAppearance.BorderSize = 0;
            this.icnbtnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnbtnHome.ForeColor = System.Drawing.Color.White;
            this.icnbtnHome.IconChar = FontAwesome.Sharp.IconChar.House;
            this.icnbtnHome.IconColor = System.Drawing.Color.White;
            this.icnbtnHome.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnbtnHome.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.icnbtnHome.Location = new System.Drawing.Point(0, 227);
            this.icnbtnHome.Name = "icnbtnHome";
            this.icnbtnHome.Size = new System.Drawing.Size(200, 72);
            this.icnbtnHome.TabIndex = 27;
            this.icnbtnHome.Text = "HOME";
            this.icnbtnHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnbtnHome.UseVisualStyleBackColor = true;
            this.icnbtnHome.Click += new System.EventHandler(this.icnbtnHome_Click);
            // 
            // icnbtnUsers
            // 
            this.icnbtnUsers.FlatAppearance.BorderSize = 0;
            this.icnbtnUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnbtnUsers.ForeColor = System.Drawing.Color.White;
            this.icnbtnUsers.IconChar = FontAwesome.Sharp.IconChar.UserEdit;
            this.icnbtnUsers.IconColor = System.Drawing.Color.White;
            this.icnbtnUsers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnbtnUsers.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.icnbtnUsers.Location = new System.Drawing.Point(2, 322);
            this.icnbtnUsers.Name = "icnbtnUsers";
            this.icnbtnUsers.Size = new System.Drawing.Size(197, 72);
            this.icnbtnUsers.TabIndex = 28;
            this.icnbtnUsers.Text = "MANAGE USERS";
            this.icnbtnUsers.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnbtnUsers.UseVisualStyleBackColor = true;
            this.icnbtnUsers.Click += new System.EventHandler(this.icnbtnUsers_Click);
            // 
            // icnbtnProdCat
            // 
            this.icnbtnProdCat.FlatAppearance.BorderSize = 0;
            this.icnbtnProdCat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnbtnProdCat.ForeColor = System.Drawing.Color.White;
            this.icnbtnProdCat.IconChar = FontAwesome.Sharp.IconChar.FileEdit;
            this.icnbtnProdCat.IconColor = System.Drawing.Color.White;
            this.icnbtnProdCat.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnbtnProdCat.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.icnbtnProdCat.Location = new System.Drawing.Point(0, 512);
            this.icnbtnProdCat.Name = "icnbtnProdCat";
            this.icnbtnProdCat.Size = new System.Drawing.Size(200, 72);
            this.icnbtnProdCat.TabIndex = 29;
            this.icnbtnProdCat.Text = "PRODUCT CATEGORIES";
            this.icnbtnProdCat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnbtnProdCat.UseVisualStyleBackColor = true;
            this.icnbtnProdCat.Click += new System.EventHandler(this.icnbtnProdCat_Click);
            // 
            // icnbtnProducts
            // 
            this.icnbtnProducts.FlatAppearance.BorderSize = 0;
            this.icnbtnProducts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnbtnProducts.ForeColor = System.Drawing.Color.White;
            this.icnbtnProducts.IconChar = FontAwesome.Sharp.IconChar.IceCream;
            this.icnbtnProducts.IconColor = System.Drawing.Color.White;
            this.icnbtnProducts.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnbtnProducts.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.icnbtnProducts.Location = new System.Drawing.Point(2, 607);
            this.icnbtnProducts.Name = "icnbtnProducts";
            this.icnbtnProducts.Size = new System.Drawing.Size(197, 72);
            this.icnbtnProducts.TabIndex = 30;
            this.icnbtnProducts.Text = "PRODUCTS";
            this.icnbtnProducts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnbtnProducts.UseVisualStyleBackColor = true;
            this.icnbtnProducts.Click += new System.EventHandler(this.icnbtnProducts_Click);
            // 
            // icnbtnBackup
            // 
            this.icnbtnBackup.FlatAppearance.BorderSize = 0;
            this.icnbtnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnbtnBackup.ForeColor = System.Drawing.Color.White;
            this.icnbtnBackup.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.icnbtnBackup.IconColor = System.Drawing.Color.White;
            this.icnbtnBackup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnbtnBackup.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.icnbtnBackup.Location = new System.Drawing.Point(2, 797);
            this.icnbtnBackup.Name = "icnbtnBackup";
            this.icnbtnBackup.Size = new System.Drawing.Size(197, 72);
            this.icnbtnBackup.TabIndex = 32;
            this.icnbtnBackup.Text = "DATABASE BACKUP";
            this.icnbtnBackup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnbtnBackup.UseVisualStyleBackColor = true;
            this.icnbtnBackup.Click += new System.EventHandler(this.icnbtnBackup_Click);
            // 
            // icnbtnLogout
            // 
            this.icnbtnLogout.FlatAppearance.BorderSize = 0;
            this.icnbtnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnbtnLogout.ForeColor = System.Drawing.Color.White;
            this.icnbtnLogout.IconChar = FontAwesome.Sharp.IconChar.LeftLong;
            this.icnbtnLogout.IconColor = System.Drawing.Color.White;
            this.icnbtnLogout.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnbtnLogout.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.icnbtnLogout.Location = new System.Drawing.Point(2, 892);
            this.icnbtnLogout.Name = "icnbtnLogout";
            this.icnbtnLogout.Size = new System.Drawing.Size(197, 72);
            this.icnbtnLogout.TabIndex = 33;
            this.icnbtnLogout.Text = "LOGOUT";
            this.icnbtnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnbtnLogout.UseVisualStyleBackColor = true;
            this.icnbtnLogout.Click += new System.EventHandler(this.icnbtnLogout_Click);
            // 
            // iconButton1
            // 
            this.iconButton1.FlatAppearance.BorderSize = 0;
            this.iconButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.iconButton1.ForeColor = System.Drawing.Color.White;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.UserGear;
            this.iconButton1.IconColor = System.Drawing.Color.White;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.iconButton1.Location = new System.Drawing.Point(0, 132);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(191, 45);
            this.iconButton1.TabIndex = 34;
            this.iconButton1.Text = "Edit my account";
            this.iconButton1.UseVisualStyleBackColor = true;
            this.iconButton1.Click += new System.EventHandler(this.iconButton1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.icnBtnCustomers);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.icnbtnLogout);
            this.panel1.Controls.Add(this.icnbtnBackup);
            this.panel1.Controls.Add(this.icnbtnReports);
            this.panel1.Controls.Add(this.icnbtnProducts);
            this.panel1.Controls.Add(this.icnbtnProdCat);
            this.panel1.Controls.Add(this.icnbtnUsers);
            this.panel1.Controls.Add(this.icnbtnHome);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 1018);
            this.panel1.TabIndex = 27;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // icnBtnCustomers
            // 
            this.icnBtnCustomers.FlatAppearance.BorderSize = 0;
            this.icnBtnCustomers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnBtnCustomers.ForeColor = System.Drawing.Color.White;
            this.icnBtnCustomers.IconChar = FontAwesome.Sharp.IconChar.Children;
            this.icnBtnCustomers.IconColor = System.Drawing.Color.White;
            this.icnBtnCustomers.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnBtnCustomers.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.icnBtnCustomers.Location = new System.Drawing.Point(2, 417);
            this.icnBtnCustomers.Name = "icnBtnCustomers";
            this.icnBtnCustomers.Size = new System.Drawing.Size(197, 72);
            this.icnBtnCustomers.TabIndex = 35;
            this.icnBtnCustomers.Text = "MANAGE CUSTOMERS";
            this.icnBtnCustomers.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnBtnCustomers.UseVisualStyleBackColor = true;
            this.icnBtnCustomers.Click += new System.EventHandler(this.icnBtnCustomers_Click);
            // 
            // icnbtnReports
            // 
            this.icnbtnReports.FlatAppearance.BorderSize = 0;
            this.icnbtnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icnbtnReports.ForeColor = System.Drawing.Color.White;
            this.icnbtnReports.IconChar = FontAwesome.Sharp.IconChar.FileContract;
            this.icnbtnReports.IconColor = System.Drawing.Color.White;
            this.icnbtnReports.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.icnbtnReports.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.icnbtnReports.Location = new System.Drawing.Point(2, 702);
            this.icnbtnReports.Name = "icnbtnReports";
            this.icnbtnReports.Size = new System.Drawing.Size(197, 72);
            this.icnbtnReports.TabIndex = 31;
            this.icnbtnReports.Text = "REPORTS";
            this.icnbtnReports.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnbtnReports.UseVisualStyleBackColor = true;
            this.icnbtnReports.Click += new System.EventHandler(this.icnbtnReports_Click);
            // 
            // homePageAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1677, 1018);
            this.ControlBox = false;
            this.Controls.Add(this.pnlScreen);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbluserID);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "homePageAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "homePageAdmin";
            this.Load += new System.EventHandler(this.homePageAdmin_Load);
            this.pnlScreen.ResumeLayout(false);
            this.pnlScreen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbluserID;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlScreen;
        private System.Windows.Forms.PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton icnbtnHome;
        private FontAwesome.Sharp.IconButton icnbtnUsers;
        private FontAwesome.Sharp.IconButton icnbtnProdCat;
        private FontAwesome.Sharp.IconButton icnbtnProducts;
        private FontAwesome.Sharp.IconButton icnbtnBackup;
        private FontAwesome.Sharp.IconButton icnbtnLogout;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton icnBtnCustomers;
        private FontAwesome.Sharp.IconButton icnbtnReports;
    }
}