using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Joyice
{
    public partial class ProductCategoryAdmin : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Connecting\\SQLEXPRESS;Initial Catalog=joyice;Integrated Security=True");
        DateTime currentDate = DateTime.Now;
        String datagridQuery = "SELECT \r\n    categories_table.cat_ID, \r\n    categories_table.cat_name, \r\n\tSUM(products_table.prod_qty) AS products_under,\r\n    categories_table.cat_createdAt, \r\n    users_table.user_firstName + ' ' + users_table.user_lastName AS Created_by, \r\n    categories_table.cat_modifiedByID, \r\n    categories_table.cat_modifiedAt \r\nFROM \r\n    categories_table \r\n    INNER JOIN users_table ON categories_table.userID = users_table.userID\r\n    LEFT JOIN products_table ON categories_table.cat_ID = products_table.cat_ID\r\nGROUP BY \r\n    categories_table.cat_ID, \r\n    categories_table.cat_name, \r\n    categories_table.cat_createdAt, \r\n    users_table.user_firstName, \r\n    users_table.user_lastName, \r\n    categories_table.cat_modifiedByID, \r\n    categories_table.cat_modifiedAt\r\n\r\n";

        public string userIDValue { get; set; }

        public ProductCategoryAdmin()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCreate.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;

            btnInsert.Visible = false;
            btnNewUpdate.Visible = false;

            txtCategory.Clear();

            dataGridView1.Enabled = true;
            txtCategory.Enabled = false;
            btnCancel.Visible = false;
        }

        private void ProductCategoryAdmin_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(datagridQuery, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridView1.DataSource = dt;

            lblUserID.Text = userIDValue;
        }

        private void btnCreate_Click(object sender, EventArgs e)
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
                    btnCreate.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;

                    btnInsert.Visible = true;

                    txtCategory.Clear();

                    dataGridView1.Enabled = false;
                    txtCategory.Enabled = true;

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
                    btnCreate.Visible = false;
                    btnUpdate.Visible = false;
                    btnDelete.Visible = false;
                    btnCancel.Visible = true;

                    btnNewUpdate.Visible = true;

                    txtCategory.Enabled = true;

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
                txtCategory.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                lblCatID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text == string.Empty)
            {
                MessageBox.Show("Category must not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM categories_table WHERE cat_name = '" + txtCategory.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Category already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCategory.Clear();
                    conn.Close();
                }
                else
                {
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO categories_table (cat_name, cat_createdAt, userID) VALUES (@cat_name, @cat_createdAt, @userID)", conn);
                    cmd2.Parameters.AddWithValue("@cat_name", txtCategory.Text);
                    cmd2.Parameters.AddWithValue("@cat_createdAt", currentDate);
                    cmd2.Parameters.AddWithValue("@userID", lblUserID.Text);
                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    txtCategory.Clear();

                    SqlCommand cmd3 = new SqlCommand(datagridQuery, conn);

                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

                    DataTable dt3 = new DataTable();

                    da3.Fill(dt3);
                    dataGridView1.DataSource = dt3;


                    btnCreate.Visible = true;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnCancel.Visible = false;

                    btnInsert.Visible = false;

                    txtCategory.Clear();

                    dataGridView1.Enabled = true;
                    txtCategory.Enabled = false;

                    MessageBox.Show("User Credentials Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNewUpdate_Click(object sender, EventArgs e)
        {
            if (txtCategory.Text == string.Empty)
            {
                MessageBox.Show("Category must not be empty", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE categories_table SET cat_name=@cat_name, cat_modifiedAt=@cat_modifiedAt, cat_modifiedByID=@cat_modifiedByID WHERE cat_ID=@cat_ID", conn);


                cmd.Parameters.AddWithValue("@cat_name", txtCategory.Text);
                cmd.Parameters.AddWithValue("@cat_modifiedAt", currentDate);
                cmd.Parameters.AddWithValue("@cat_modifiedByID", lblUserID.Text);
                cmd.Parameters.AddWithValue("@cat_ID", lblCatID.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                txtCategory.Clear();


                MessageBox.Show("Category Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand cmd2 = new SqlCommand(datagridQuery, conn);

                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

                DataTable dt2 = new DataTable();

                da2.Fill(dt2);
                dataGridView1.DataSource = dt2;

                btnCreate.Visible = true;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;

                btnInsert.Visible = false;
                btnNewUpdate.Visible = false;

                txtCategory.Clear();

                dataGridView1.Enabled = true;
                txtCategory.Enabled = false;
                btnCancel.Visible = false;

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
                    if (lblCatID.Text == string.Empty)
                    {
                        MessageBox.Show("Please select a category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        lblCatID.Text = "";
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want to delete category?'" + lblCatID.Text + "'", "Delete data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            int catID = int.Parse(lblCatID.Text);
                            conn.Open();
                            SqlCommand cmd4 = new SqlCommand("SELECT COUNT(*) FROM products_table WHERE cat_ID =@cat_ID", conn);
                            cmd4.Parameters.AddWithValue("@cat_ID", catID);
                            int count = (int)cmd4.ExecuteScalar();
                            conn.Close();

                            if (count == 0)
                            {
                                conn.Open();
                                SqlCommand cmd3 = new SqlCommand("DELETE categories_table WHERE cat_ID=@cat_ID", conn);


                                cmd3.Parameters.AddWithValue("@cat_ID", lblCatID.Text);

                                cmd3.ExecuteNonQuery();
                                conn.Close();

                                txtCategory.Clear();


                                SqlCommand cmd2 = new SqlCommand(datagridQuery, conn);

                                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

                                DataTable dt2 = new DataTable();

                                da2.Fill(dt2);
                                dataGridView1.DataSource = dt2;

                                MessageBox.Show("Category Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            }
                            else
                            {
                                MessageBox.Show("There are products under that category", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                lblCatID.Text = "";
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    lblCatID.Text = "";
                }
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
