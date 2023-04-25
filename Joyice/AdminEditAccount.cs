using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Joyice
{


    public partial class AdminEditAccount : Form
    {
        //comment
        SqlConnection conn = new SqlConnection("Data Source=Connecting\\SQLEXPRESS;Initial Catalog=joyice;Integrated Security=True");

        string imgPath = ConfigurationManager.AppSettings["imgFilePath"];


        public string userIDValue { get; set; }

        public AdminEditAccount()
        {
            InitializeComponent();
            txtEmail.TabIndex = 0;
            txtContactNumber.TabIndex = 1;
            txtUsername.TabIndex = 2;
            txtPassword.TabIndex = 3;
            txtRePassword.TabIndex = 4;
        }

        private void AdminEditAccount_Load(object sender, EventArgs e)
        {


            lblUserID.Text = userIDValue;


            SqlCommand cmd = new SqlCommand("SELECT * FROM users_table WHERE userID= '" + lblUserID.Text + "'", conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    lblEmail.Text = reader["user_email"].ToString();
                    lblContactNumber.Text = reader["user_contactNum"].ToString();
                    lblUsername.Text = reader["username"].ToString();
                    txtPassword.Text = reader["password"].ToString();
                    if (reader["user_profilePic"].ToString() == string.Empty)
                    {
                        pictureBox1.ImageLocation = imgPath + "\\default.jpg"; ;
                    }
                    else
                    {
                        pictureBox1.ImageLocation = reader["user_profilePic"].ToString();
                    }
                }
            }
            conn.Close();

        }

        private void lbluserID_Click(object sender, EventArgs e)
        {

        }

        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            Form passwordDialog = new Form();
            TextBox txtPasswordDialogue = new TextBox();
            Button btnOK = new Button();
            Button btnCancelDialogue = new Button();
            Label lblPassword = new Label();

            lblPassword.Text = "Enter Password";
            passwordDialog.Text = "Confirm User";
            txtPasswordDialogue.PasswordChar = '*';
            txtPasswordDialogue.UseSystemPasswordChar = true;
            btnOK.Text = "OK";
            btnCancelDialogue.Text = "Cancel";
            btnOK.DialogResult = DialogResult.OK;
            btnCancelDialogue.DialogResult = DialogResult.Cancel;

            lblPassword.Location = new Point(10, 5);
            lblPassword.Size = new Size(100, 20);
            txtPasswordDialogue.Location = new Point(10, 25);
            txtPasswordDialogue.Size = new Size(250, 50);
            btnOK.Location = new Point(10, 50);
            btnCancelDialogue.Location = new Point(90, 50);

            passwordDialog.ClientSize = new Size(275, 80);
            passwordDialog.Controls.Add(lblPassword);
            passwordDialog.Controls.Add(txtPasswordDialogue);
            passwordDialog.Controls.Add(btnOK);
            passwordDialog.Controls.Add(btnCancelDialogue);

            passwordDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
            passwordDialog.StartPosition = FormStartPosition.CenterScreen;
            passwordDialog.AcceptButton = btnOK;
            passwordDialog.CancelButton = btnCancelDialogue;

            if (passwordDialog.ShowDialog() == DialogResult.OK)
            {
                string password = txtPasswordDialogue.Text;



                SqlCommand cmd = new SqlCommand("SELECT * FROM users_table WHERE userID= '" + lblUserID.Text + "' AND password= '" + password + "'", conn);


                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    lblEmail.Visible = false;
                    lblContactNumber.Visible = false;
                    lblUsername.Visible = false;
                    btnEditAccount.Visible = false;

                    txtContactNumber.Visible = true;
                    txtEmail.Visible = true;
                    txtUsername.Visible = true;
                    btnSave.Visible = true;
                    btnChangePicture.Visible = true;
                    btnCancel.Visible = true;
                    txtRePassword.Visible = true;
                    txtPassword.Enabled = true;
                    lblRetypePassword.Visible = true;
                    lblPicName.Visible = true;

                    SqlCommand cmd2 = new SqlCommand("SELECT * FROM users_table WHERE userID= '" + lblUserID.Text + "'", conn);

                    conn.Open();
                    using (SqlDataReader reader = cmd2.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            txtEmail.Text = reader["user_email"].ToString();
                            txtContactNumber.Text = reader["user_contactNum"].ToString();
                            txtUsername.Text = reader["username"].ToString();

                            string filePath = reader["user_profilePic"].ToString();
                            lblPicName.Text = Path.GetFileName(filePath);

                        }
                    }
                    conn.Close();
                }
                else
                {
                    MessageBox.Show("Incorrect Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }






        }

        string imglocation = "";

        private void btnChangePicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "png files(*.png)|*.png|jpg files(*.jpg)|*.jpg|All files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imglocation = openFileDialog.FileName.ToString();
                pictureBox1.ImageLocation = imglocation;
                lblPicName.Text = Path.GetFileName(imglocation);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {


            if (txtContactNumber.Text == string.Empty && txtEmail.Text == string.Empty && txtUsername.Text == string.Empty && txtRePassword.Text == string.Empty && txtRePassword.Text == string.Empty)
            {
                MessageBox.Show("Populate all fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtPassword.Text != txtRePassword.Text)
                {
                    MessageBox.Show("Passwords don't match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtRePassword.Clear();
                }
                else
                {
                    string imagePath = pictureBox1.ImageLocation;
                    string fileName = Path.GetFileName(imagePath);
                    string savePath = Path.Combine(Application.StartupPath, imgPath, fileName);

                    if (!Directory.Exists(Path.Combine(Application.StartupPath, imgPath)))
                    {
                        Directory.CreateDirectory(Path.Combine(Application.StartupPath, imgPath));
                    }


                    try
                    {
                        File.Copy(imagePath, savePath, true);
                    }
                    catch (IOException ex)
                    {
                        Console.WriteLine($"An error occurred while copying the file: {ex.Message}");

                    }




                    conn.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE users_table SET user_email=@user_email, user_contactNum=@user_contactNum, username=@username,  password=@password, user_profilePic=@user_profilePic WHERE userID='" + lblUserID.Text + "'", conn);
                    cmd.Parameters.AddWithValue("@user_email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@user_contactNum", txtContactNumber.Text);
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@user_profilePic", savePath);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    MessageBox.Show("User Credentials Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblEmail.Visible = true;
                    lblContactNumber.Visible = true;
                    lblUsername.Visible = true;
                    btnEditAccount.Visible = true;

                    txtContactNumber.Visible = false;
                    txtEmail.Visible = false;
                    txtUsername.Visible = false;
                    btnSave.Visible = false;
                    btnChangePicture.Visible = false;
                    btnCancel.Visible = false;

                    txtPassword.Enabled = false;
                    txtRePassword.Visible = false;
                    lblRetypePassword.Visible = false;
                    lblPicName.Visible = false;
                }

            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblEmail.Visible = true;
            lblContactNumber.Visible = true;
            lblUsername.Visible = true;
            btnEditAccount.Visible = true;

            txtContactNumber.Visible = false;
            txtEmail.Visible = false;
            txtUsername.Visible = false;
            btnSave.Visible = false;
            btnChangePicture.Visible = false;
            btnCancel.Visible = false;
            txtRePassword.Visible = false;
            lblRetypePassword.Visible = false;
            txtPassword.Enabled = false;
            lblPicName.Visible = false;


            SqlCommand cmd = new SqlCommand("SELECT * FROM users_table WHERE userID= '" + lblUserID.Text + "'", conn);
            conn.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {

                    txtEmail.Text = reader["user_email"].ToString();
                    txtContactNumber.Text = reader["user_contactNum"].ToString();
                    txtUsername.Text = reader["username"].ToString();
                    pictureBox1.ImageLocation = reader["user_profilePic"].ToString();

                    string filePath = reader["user_profilePic"].ToString();
                    lblPicName.Text = Path.GetFileName(filePath);




                }
            }
            conn.Close();


        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }

}
