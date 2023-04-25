namespace Joyice
{
    partial class homePageStaff
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.icnbtnProdCat = new FontAwesome.Sharp.IconButton();
            this.icnbtnLogout = new FontAwesome.Sharp.IconButton();
            this.icnbtnProducts = new FontAwesome.Sharp.IconButton();
            this.icnbtnHome = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlScreen = new System.Windows.Forms.Panel();
            this.icnbtnReports = new FontAwesome.Sharp.IconButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.pnlScreen.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbluserID
            // 
            this.lbluserID.AutoSize = true;
            this.lbluserID.Location = new System.Drawing.Point(1277, 652);
            this.lbluserID.Name = "lbluserID";
            this.lbluserID.Size = new System.Drawing.Size(38, 13);
            this.lbluserID.TabIndex = 31;
            this.lbluserID.Text = "userID";
            this.lbluserID.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(200, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1461, 40);
            this.panel2.TabIndex = 34;
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
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(47, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 100);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panel1.Controls.Add(this.icnbtnProdCat);
            this.panel1.Controls.Add(this.iconButton1);
            this.panel1.Controls.Add(this.icnbtnLogout);
            this.panel1.Controls.Add(this.icnbtnReports);
            this.panel1.Controls.Add(this.icnbtnProducts);
            this.panel1.Controls.Add(this.icnbtnHome);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 979);
            this.panel1.TabIndex = 33;
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
            this.icnbtnProdCat.Location = new System.Drawing.Point(0, 468);
            this.icnbtnProdCat.Name = "icnbtnProdCat";
            this.icnbtnProdCat.Size = new System.Drawing.Size(200, 72);
            this.icnbtnProdCat.TabIndex = 35;
            this.icnbtnProdCat.Text = "ORDERS";
            this.icnbtnProdCat.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnbtnProdCat.UseVisualStyleBackColor = true;
            this.icnbtnProdCat.Click += new System.EventHandler(this.icnbtnProdCat_Click);
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
            this.icnbtnLogout.Location = new System.Drawing.Point(2, 672);
            this.icnbtnLogout.Name = "icnbtnLogout";
            this.icnbtnLogout.Size = new System.Drawing.Size(197, 72);
            this.icnbtnLogout.TabIndex = 33;
            this.icnbtnLogout.Text = "LOGOUT";
            this.icnbtnLogout.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnbtnLogout.UseVisualStyleBackColor = true;
            this.icnbtnLogout.Click += new System.EventHandler(this.icnbtnLogout_Click);
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
            this.icnbtnProducts.Location = new System.Drawing.Point(2, 366);
            this.icnbtnProducts.Name = "icnbtnProducts";
            this.icnbtnProducts.Size = new System.Drawing.Size(197, 72);
            this.icnbtnProducts.TabIndex = 30;
            this.icnbtnProducts.Text = "PRODUCTS";
            this.icnbtnProducts.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnbtnProducts.UseVisualStyleBackColor = true;
            this.icnbtnProducts.Click += new System.EventHandler(this.icnbtnProducts_Click);
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
            this.icnbtnHome.Location = new System.Drawing.Point(0, 264);
            this.icnbtnHome.Name = "icnbtnHome";
            this.icnbtnHome.Size = new System.Drawing.Size(200, 72);
            this.icnbtnHome.TabIndex = 27;
            this.icnbtnHome.Text = "HOME";
            this.icnbtnHome.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnbtnHome.UseVisualStyleBackColor = true;
            this.icnbtnHome.Click += new System.EventHandler(this.icnbtnHome_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(592, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Home";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 50F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(144, 405);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(1221, 76);
            this.label2.TabIndex = 0;
            this.label2.Text = "WELCOME JOYICE STAFF MESSAGE";
            // 
            // pnlScreen
            // 
            this.pnlScreen.BackColor = System.Drawing.Color.Transparent;
            this.pnlScreen.Controls.Add(this.label2);
            this.pnlScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlScreen.ForeColor = System.Drawing.Color.White;
            this.pnlScreen.Location = new System.Drawing.Point(200, 40);
            this.pnlScreen.Name = "pnlScreen";
            this.pnlScreen.Size = new System.Drawing.Size(1461, 939);
            this.pnlScreen.TabIndex = 35;
            this.pnlScreen.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlScreen_Paint);
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
            this.icnbtnReports.Location = new System.Drawing.Point(2, 570);
            this.icnbtnReports.Name = "icnbtnReports";
            this.icnbtnReports.Size = new System.Drawing.Size(197, 72);
            this.icnbtnReports.TabIndex = 31;
            this.icnbtnReports.Text = "PRINT ORDERS";
            this.icnbtnReports.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.icnbtnReports.UseVisualStyleBackColor = true;
            this.icnbtnReports.Click += new System.EventHandler(this.icnbtnReports_Click);
            // 
            // homePageStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1661, 979);
            this.ControlBox = false;
            this.Controls.Add(this.pnlScreen);
            this.Controls.Add(this.lbluserID);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "homePageStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "homePageStaff";
            this.Load += new System.EventHandler(this.homePageStaff_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.pnlScreen.ResumeLayout(false);
            this.pnlScreen.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbluserID;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panel2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private FontAwesome.Sharp.IconButton icnbtnProdCat;
        private FontAwesome.Sharp.IconButton icnbtnLogout;
        private FontAwesome.Sharp.IconButton icnbtnProducts;
        private FontAwesome.Sharp.IconButton icnbtnHome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlScreen;
        private FontAwesome.Sharp.IconButton icnbtnReports;
    }
}