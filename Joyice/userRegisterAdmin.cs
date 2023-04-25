using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Joyice
{
    public partial class userRegisterAdmin : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Connecting\\SQLEXPRESS;Initial Catalog=joyice;Integrated Security=True");
        String sex;


        public string userIDValue { get; set; }

        public userRegisterAdmin()
        {
            InitializeComponent();

            txtFirstName.TabIndex = 0;
            txtLastName.TabIndex = 1;
            rdMale.TabIndex = 2;
            rdFemale.TabIndex = 3;
            dtpBday.TabIndex = 4;
            txtAddress.TabIndex = 5;
            txtContactNumber.TabIndex = 6;
            txtEmail.TabIndex = 7;
            cmUserType.TabIndex = 8;
            txtUsername.TabIndex = 9;
            txtPassword.TabIndex = 10;
            txtRePassword.TabIndex = 11;

        }



        private void btnRESET_Click(object sender, EventArgs e)
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtContactNumber.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtRePassword.Clear();
            cmUserType.Text = "Select User Type";
            rdMale.Checked = false;
            rdFemale.Checked = false;

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
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
                    btnRegister.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancelRegister.Visible = true;
                    btnSaveRegister.Visible = true;

                    txtFirstName.Enabled = true;
                    txtLastName.Enabled = true;
                    txtContactNumber.Enabled = true;
                    txtAddress.Enabled = true;
                    txtEmail.Enabled = true;
                    txtUsername.Enabled = true;
                    dtpBday.Enabled = true;
                    cmUserType.Enabled = true;
                    txtPassword.Enabled = true;
                    txtRePassword.Enabled = true;
                    rdMale.Enabled = true;
                    rdFemale.Enabled = true;
                    dataGridView1.Enabled = false;

                    txtFirstName.Clear();
                    txtLastName.Clear();
                    txtContactNumber.Clear();
                    txtAddress.Clear();
                    txtEmail.Clear();
                    txtUsername.Clear();
                    txtPassword.Clear();

                }
                else
                {
                    MessageBox.Show("Incorrect Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
                    btnRegister.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnSaveRegister.Visible = false;

                    btnCancelRegister.Visible = true;
                    btnSaveChanges.Visible = true;

                    txtFirstName.Enabled = true;
                    txtLastName.Enabled = true;
                    txtContactNumber.Enabled = true;
                    txtAddress.Enabled = true;
                    txtEmail.Enabled = true;
                    txtUsername.Enabled = true;
                    dtpBday.Enabled = true;
                    cmUserType.Enabled = true;
                    txtPassword.Enabled = true;
                    txtRePassword.Enabled = true;
                    rdMale.Enabled = true;
                    rdFemale.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Incorrect Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        }

        private void btnDelete_Click(object sender, EventArgs e)
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
                    if (MessageBox.Show("Do you want to delete user?", "Delete data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        conn.Open();
                        SqlCommand cmd3 = new SqlCommand("DELETE users_table WHERE userID=@userID", conn);


                        cmd3.Parameters.AddWithValue("@userID", lblId.Text);

                        cmd3.ExecuteNonQuery();
                        conn.Close();

                        txtFirstName.Clear();
                        txtLastName.Clear();
                        txtContactNumber.Clear();
                        txtAddress.Clear();
                        txtEmail.Clear();
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtRePassword.Clear();
                        cmUserType.Text = "Select User Type";
                        rdMale.Checked = false;
                        rdFemale.Checked = false;

                        SqlCommand cmd2 = new SqlCommand("SELECT userID, user_firstName, user_lastName, user_sex, user_bday, user_address, user_contactNum, user_email, user_type, username FROM users_table", conn);

                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

                        DataTable dt2 = new DataTable();

                        da2.Fill(dt2);
                        dataGridView1.DataSource = dt2;

                        MessageBox.Show("User Credentials Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Incorrect Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtFirstName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtLastName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                string sex = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (sex == "male")
                {
                    rdMale.Checked = true;
                }
                else
                {
                    rdFemale.Checked = true;
                }
                dtpBday.Value = DateTime.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                txtContactNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                cmUserType.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                txtUsername.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
                lblId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void userRegisterAdmin_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT userID, user_firstName, user_lastName, user_sex, user_bday, user_address, user_contactNum, user_email, user_type, username FROM users_table", conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridView1.DataSource = dt;

            lblUserID.Text = userIDValue;


            conn.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnRegister.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnCancelRegister.Visible = false;
            btnSaveRegister.Visible = false;
            dataGridView1.Enabled = true;

            txtFirstName.Enabled = false;
            txtLastName.Enabled = false;
            txtContactNumber.Enabled = false;
            txtAddress.Enabled = false;
            txtEmail.Enabled = false;
            txtUsername.Enabled = false;
            dtpBday.Enabled = false;
            cmUserType.Enabled = false;
            txtPassword.Enabled = false;
            txtRePassword.Enabled = false;
            rdMale.Enabled = false;
            rdFemale.Enabled = false;

        }



        private void btnSaveRegister_Click(object sender, EventArgs e)
        {
            string sexChecked;
            if (rdMale.Checked)
            {
                sexChecked = "male";
            }
            else
            {
                sexChecked = "female";
            }
            if (txtFirstName.Text == string.Empty || txtLastName.Text == string.Empty || sexChecked == string.Empty || dtpBday.Text == string.Empty || txtAddress.Text == string.Empty || txtContactNumber.Text == string.Empty || txtEmail.Text == string.Empty || txtUsername.Text == string.Empty || txtPassword.Text == string.Empty || txtRePassword.Text == string.Empty || cmUserType.Text == "Select user type")
            {
                MessageBox.Show("Populate all fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtPassword.Text != txtRePassword.Text)
                {
                    MessageBox.Show("Passwords don't match", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtPassword.Clear();
                    txtRePassword.Clear();
                }
                else
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM users_table WHERE username = '" + txtUsername.Text + "'", conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        MessageBox.Show("Username already in use", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtFirstName.Clear();
                        txtLastName.Clear();
                        txtContactNumber.Clear();
                        txtAddress.Clear();
                        txtEmail.Clear();
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtRePassword.Clear();
                        cmUserType.Text = "Select User Type";
                        rdMale.Checked = false;
                        rdFemale.Checked = false;
                        conn.Close();
                    }
                    else
                    {

                        SqlCommand cmd2 = new SqlCommand("INSERT INTO users_table (user_firstName, user_lastName, user_sex, user_bday, user_address, user_contactNum, user_email, user_type, username, password) VALUES (@user_firstName, @user_lastName, @user_sex, @user_bday, @user_address, @user_contactNum, @user_email, @user_type, @username, @password)", conn);


                        cmd2.Parameters.AddWithValue("@user_firstName", txtFirstName.Text);
                        cmd2.Parameters.AddWithValue("@user_lastName", txtLastName.Text);
                        cmd2.Parameters.AddWithValue("@user_sex", sexChecked);
                        cmd2.Parameters.AddWithValue("@user_bday", dtpBday.Text);
                        cmd2.Parameters.AddWithValue("@user_address", txtAddress.Text);
                        cmd2.Parameters.AddWithValue("@user_contactNum", txtContactNumber.Text);
                        cmd2.Parameters.AddWithValue("@user_email", txtEmail.Text);
                        cmd2.Parameters.AddWithValue("@user_type", cmUserType.Text);
                        cmd2.Parameters.AddWithValue("@username", txtUsername.Text);
                        cmd2.Parameters.AddWithValue("@password", txtPassword.Text);
                        cmd2.ExecuteNonQuery();
                        conn.Close();

                        txtFirstName.Clear();
                        txtLastName.Clear();
                        txtContactNumber.Clear();
                        txtAddress.Clear();
                        txtEmail.Clear();
                        txtUsername.Clear();
                        txtPassword.Clear();
                        txtRePassword.Clear();
                        cmUserType.Text = "Select User Type";
                        rdMale.Checked = false;
                        rdFemale.Checked = false;

                        MessageBox.Show("User Created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        SqlCommand cmd3 = new SqlCommand("SELECT userID, user_firstName, user_lastName, user_sex, user_bday, user_address, user_contactNum, user_email, user_type, username FROM users_table", conn);

                        SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

                        DataTable dt3 = new DataTable();

                        da3.Fill(dt3);
                        dataGridView1.DataSource = dt3;


                        btnRegister.Visible = true;
                        btnUpdate.Visible = true;
                        btnDelete.Visible = true;
                        btnCancelRegister.Visible = false;
                        btnSaveRegister.Visible = false;
                        dataGridView1.Enabled = true;

                        txtFirstName.Enabled = false;
                        txtLastName.Enabled = false;
                        txtContactNumber.Enabled = false;
                        txtAddress.Enabled = false;
                        txtEmail.Enabled = false;
                        txtUsername.Enabled = false;
                        dtpBday.Enabled = false;
                        cmUserType.Enabled = false;
                        txtPassword.Enabled = false;
                        txtRePassword.Enabled = false;
                        rdMale.Enabled = false;
                        rdFemale.Enabled = false;

                    }
                }
            }
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            string sexChecked;
            if (rdMale.Checked)
            {
                sexChecked = "male";
            }
            else
            {
                sexChecked = "female";
            }

            if (txtFirstName.Text == string.Empty || txtLastName.Text == string.Empty || sex == string.Empty || dtpBday.Text == string.Empty || txtAddress.Text == string.Empty || txtContactNumber.Text == string.Empty || txtEmail.Text == string.Empty || txtUsername.Text == string.Empty || txtPassword.Text == string.Empty || txtRePassword.Text == string.Empty || cmUserType.Text == "Select user type")
            {
                MessageBox.Show("Populate all fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE users_table SET user_firstName=@user_firstName, user_lastName=@user_lastName, user_sex=@user_sex, user_bday=@user_bday, user_address=@user_address, user_contactNum=@user_contactNum, user_email=@user_email, user_type=@user_type, username=@username, password=@password WHERE userID=@userID", conn);


                cmd.Parameters.AddWithValue("@userID", lblId.Text);
                cmd.Parameters.AddWithValue("@user_firstName", txtFirstName.Text);
                cmd.Parameters.AddWithValue("@user_lastName", txtLastName.Text);
                cmd.Parameters.AddWithValue("@user_sex", sexChecked);
                cmd.Parameters.AddWithValue("@user_bday", dtpBday.Text);
                cmd.Parameters.AddWithValue("@user_address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@user_contactNum", txtContactNumber.Text);
                cmd.Parameters.AddWithValue("@user_email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@user_type", cmUserType.Text);
                cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                cmd.Parameters.AddWithValue("@password", txtPassword.Text);
                cmUserType.Text = "Select User Type";
                rdMale.Checked = false;
                rdFemale.Checked = false;
                cmd.ExecuteNonQuery();
                conn.Close();

                txtFirstName.Clear();
                txtLastName.Clear();
                txtContactNumber.Clear();
                txtAddress.Clear();
                txtEmail.Clear();
                txtUsername.Clear();
                txtPassword.Clear();
                txtRePassword.Clear();

                MessageBox.Show("User Credentials Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand cmd2 = new SqlCommand("SELECT userID, user_firstName, user_lastName, user_sex, user_bday, user_address, user_contactNum, user_email, user_type, username FROM users_table", conn);

                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

                DataTable dt2 = new DataTable();

                da2.Fill(dt2);
                dataGridView1.DataSource = dt2;

                btnRegister.Visible = true;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;
                btnSaveChanges.Visible = false;
                btnCancelRegister.Visible = false;
                btnSaveRegister.Visible = false;
                dataGridView1.Enabled = true;

                txtFirstName.Enabled = false;
                txtLastName.Enabled = false;
                txtContactNumber.Enabled = false;
                txtAddress.Enabled = false;
                txtEmail.Enabled = false;
                txtUsername.Enabled = false;
                dtpBday.Enabled = false;
                cmUserType.Enabled = false;
                txtPassword.Enabled = false;
                txtRePassword.Enabled = false;
                rdMale.Enabled = false;
                rdFemale.Enabled = false;


            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM users_table WHERE user_firstName LIKE '%" + txtSearch.Text + "%' OR user_lastName LIKE '%" + txtSearch.Text + "%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();

        }

        private void lklblMyAccount_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AdminEditAccount adminEditAccount = new AdminEditAccount();
            adminEditAccount.userIDValue = lblUserID.Text;
            adminEditAccount.Show();
            this.Hide();

        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            homePageAdmin homePageAdmin = new homePageAdmin();
            homePageAdmin.userIDValue = lblUserID.Text;
            homePageAdmin.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            lblUserID.Text = string.Empty;
            login login = new login();
            login.Show();
            this.Hide();
        }

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void cmUserType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
