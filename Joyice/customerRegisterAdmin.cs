using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Joyice
{
    public partial class customerRegisterAdmin : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Connecting\\SQLEXPRESS;Initial Catalog=joyice;Integrated Security=True");

        string datagridQuery = "SELECT customers_table.cus_ID, customers_table.cus_name, customers_table.cus_address, customers_table.cus_contactNum, customers_table.cus_email, users_table.user_firstName + ' ' + users_table.user_lastName AS created_by FROM customers_table INNER JOIN users_table ON customers_table.userID = users_table.userID";
        public string userIDValue { get; set; }
        public customerRegisterAdmin()
        {
            InitializeComponent();
            txtName.TabIndex = 0;
            txtAddress.TabIndex = 1;
            txtEmail.TabIndex = 2;
            txtContactNumber.TabIndex = 3;
        }

        private void txtContactNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void customerRegisterAdmin_Load(object sender, System.EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(datagridQuery, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridView1.DataSource = dt;

            lblUserID.Text = userIDValue;


            conn.Close();
        }

        private void btnRegister_Click(object sender, System.EventArgs e)
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

                    txtName.Enabled = true;
                    txtContactNumber.Enabled = true;
                    txtAddress.Enabled = true;
                    txtEmail.Enabled = true;
                    dataGridView1.Enabled = false;

                    txtName.Clear();
                    txtContactNumber.Clear();
                    txtAddress.Clear();
                    txtEmail.Clear();

                }
                else
                {
                    MessageBox.Show("Incorrect Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }




        private void btnCancelRegister_Click(object sender, System.EventArgs e)
        {

            btnRegister.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;
            btnCancelRegister.Visible = false;
            btnSaveRegister.Visible = false;
            dataGridView1.Enabled = true;

            txtName.Enabled = false;
            txtContactNumber.Enabled = false;
            txtAddress.Enabled = false;
            txtEmail.Enabled = false;

        }

        private void btnSaveRegister_Click(object sender, System.EventArgs e)
        {
            if (txtName.Text == string.Empty || txtAddress.Text == string.Empty || txtContactNumber.Text == string.Empty || txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Populate all fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM customers_table WHERE cus_name = '" + txtName.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Name already in exists in database", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Clear();
                    txtContactNumber.Clear();
                    txtAddress.Clear();
                    txtEmail.Clear();
                    conn.Close();
                }
                else
                {

                    SqlCommand cmd2 = new SqlCommand("INSERT INTO customers_table (cus_name, cus_address, cus_email, cus_contactNum, userID) VALUES (@cus_name, @cus_address, @cus_email, @cus_contactNum, @userID)", conn);


                    cmd2.Parameters.AddWithValue("@cus_name", txtName.Text);
                    cmd2.Parameters.AddWithValue("@cus_address", txtAddress.Text);
                    cmd2.Parameters.AddWithValue("@cus_email", txtEmail.Text);
                    cmd2.Parameters.AddWithValue("@cus_contactNum", txtContactNumber.Text);
                    cmd2.Parameters.AddWithValue("@userID", lblUserID.Text);

                    cmd2.ExecuteNonQuery();
                    conn.Close();

                    txtName.Clear();
                    txtContactNumber.Clear();
                    txtAddress.Clear();
                    txtEmail.Clear();

                    MessageBox.Show("Customer Created!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    SqlCommand cmd3 = new SqlCommand(datagridQuery, conn);

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

                    txtName.Enabled = false;
                    txtContactNumber.Enabled = false;
                    txtAddress.Enabled = false;
                    txtEmail.Enabled = false;
                }
            }
        }

        private void btnUpdate_Click(object sender, System.EventArgs e)
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

                    txtName.Enabled = true;
                    txtContactNumber.Enabled = true;
                    txtAddress.Enabled = true;
                    txtEmail.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Incorrect Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnSaveChanges_Click(object sender, System.EventArgs e)
        {

            if (txtName.Text == string.Empty || txtAddress.Text == string.Empty || txtContactNumber.Text == string.Empty || txtEmail.Text == string.Empty)
            {
                MessageBox.Show("Populate all fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE customers_table SET cus_name=@cus_name, cus_address=@cus_address, cus_email=@cus_email, cus_contactNum=@cus_contactNum WHERE cus_ID=@cus_ID", conn);

                cmd.Parameters.AddWithValue("@cus_ID", lblId.Text);
                cmd.Parameters.AddWithValue("@cus_name", txtName.Text);
                cmd.Parameters.AddWithValue("@cus_address", txtAddress.Text);
                cmd.Parameters.AddWithValue("@cus_email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@cus_contactNum", txtContactNumber.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                txtName.Clear();
                txtContactNumber.Clear();
                txtAddress.Clear();
                txtEmail.Clear();


                MessageBox.Show("Customer Credentials Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand cmd2 = new SqlCommand(datagridQuery, conn);

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

                txtName.Enabled = false;
                txtContactNumber.Enabled = false;
                txtAddress.Enabled = false;
                txtEmail.Enabled = false;
            }
        }

        private void txtSearch_TextChanged(object sender, System.EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM customers_table WHERE cus_name LIKE '%" + txtSearch.Text + "%'", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                lblId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtAddress.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtContactNumber.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtEmail.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
        }

        private void btnDelete_Click(object sender, System.EventArgs e)
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
                    if (MessageBox.Show("Do you want to delete customer?", "Delete data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        conn.Open();
                        SqlCommand cmd3 = new SqlCommand("DELETE customers_table WHERE cus_ID=@cus_ID", conn);


                        cmd3.Parameters.AddWithValue("@cus_ID", lblId.Text);

                        cmd3.ExecuteNonQuery();
                        conn.Close();

                        txtName.Clear();
                        txtContactNumber.Clear();
                        txtAddress.Clear();
                        txtEmail.Clear();

                        SqlCommand cmd2 = new SqlCommand(datagridQuery, conn);

                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

                        DataTable dt2 = new DataTable();

                        da2.Fill(dt2);
                        dataGridView1.DataSource = dt2;

                        MessageBox.Show("Customer Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Incorrect Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
