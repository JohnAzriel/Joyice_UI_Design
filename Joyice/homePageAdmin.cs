using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Joyice
{
    public partial class homePageAdmin : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Connecting\\SQLEXPRESS;Initial Catalog=joyice;Integrated Security=True");
        string backupDBFilePath = ConfigurationManager.AppSettings["backupDBFilePath"];
        string imgPath = ConfigurationManager.AppSettings["imgFilePath"];

        DateTime currentTime = DateTime.Now;


        public string userIDValue { get; set; }

        public homePageAdmin()
        {
            InitializeComponent();
        }

        private void homePageAdmin_Load(object sender, EventArgs e)
        {
            lbluserID.Text = userIDValue;

            SqlCommand cmd = new SqlCommand("SELECT * FROM users_table WHERE userID= '" + lbluserID.Text + "'", conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (reader["user_profilePic"].ToString() == string.Empty)
                    {
                        pictureBox1.ImageLocation = $"{imgPath}\\default.jpg";
                    }
                    else
                    {
                        pictureBox1.ImageLocation = reader["user_profilePic"].ToString();
                    }
                }
            }
            conn.Close();


        }




        private void lklblMyAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {


        }

        private void lbluserID_Click(object sender, EventArgs e)
        {

        }


        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {

        }




        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void icnbtnHome_Click(object sender, EventArgs e)
        {
            adminHome adminHome = new adminHome();
            adminHome.TopLevel = false;
            pnlScreen.Controls.Add(adminHome);
            adminHome.BringToFront();
            adminHome.Show();

        }

        private void icnbtnUsers_Click(object sender, EventArgs e)
        {
            userRegisterAdmin userRegisterAdmin = new userRegisterAdmin();
            userRegisterAdmin.TopLevel = false;
            pnlScreen.Controls.Add(userRegisterAdmin);
            userRegisterAdmin.BringToFront();
            userRegisterAdmin.userIDValue = lbluserID.Text;
            userRegisterAdmin.Show();
        }



        private void icnbtnProdCat_Click(object sender, EventArgs e)
        {
            ProductCategoryAdmin productCategoryAdmin = new ProductCategoryAdmin();
            productCategoryAdmin.TopLevel = false;
            pnlScreen.Controls.Add(productCategoryAdmin);
            productCategoryAdmin.BringToFront();
            productCategoryAdmin.userIDValue = lbluserID.Text;
            productCategoryAdmin.Show();
        }

        private void btnBackup_Click_1(object sender, EventArgs e)
        {

        }

        private void icnbtnBackup_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to create database backup?", "Database Backup", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                conn.Open();
                string fileName = "MyDatabase_" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + ".bak";
                fileName = fileName.Replace("/", "-").Replace(":", ".");
                string backupQuery = $"BACKUP DATABASE joyice TO DISK = '{backupDBFilePath}\\{fileName}'";


                SqlCommand command = new SqlCommand(backupQuery, conn);
                command.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show($"{fileName} created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void icnbtnLogout_Click(object sender, EventArgs e)
        {
            lbluserID.Text = string.Empty;
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            AdminEditAccount adminEditAccount = new AdminEditAccount();
            adminEditAccount.TopLevel = false;
            pnlScreen.Controls.Add(adminEditAccount);
            adminEditAccount.userIDValue = lbluserID.Text;
            adminEditAccount.Show();
        }

        private void pnlScreen_Paint(object sender, PaintEventArgs e)
        {

        }

        private void icnbtnProducts_Click(object sender, EventArgs e)
        {
            productsAdmin productsAdmin = new productsAdmin();
            productsAdmin.TopLevel = false;
            pnlScreen.Controls.Add(productsAdmin);
            productsAdmin.BringToFront();
            productsAdmin.userIDValue = lbluserID.Text;
            productsAdmin.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void icnbtnReports_Click(object sender, EventArgs e)
        {
            reportsAdmin reportsAdmin = new reportsAdmin();
            reportsAdmin.TopLevel = false;
            pnlScreen.Controls.Add(reportsAdmin);
            reportsAdmin.BringToFront();
            reportsAdmin.Show();
        }

        private void icnBtnCustomers_Click(object sender, EventArgs e)
        {
            customerRegisterAdmin customerRegisterAdmin = new customerRegisterAdmin();
            customerRegisterAdmin.TopLevel = false;
            pnlScreen.Controls.Add(customerRegisterAdmin);
            customerRegisterAdmin.BringToFront();
            customerRegisterAdmin.userIDValue = lbluserID.Text;
            customerRegisterAdmin.Show();

        }
    }
}
