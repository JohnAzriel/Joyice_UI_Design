using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace Joyice
{
    public partial class productsAdmin : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Connecting\\SQLEXPRESS;Initial Catalog=joyice;Integrated Security=True");
        DateTime currentDate = DateTime.Now;

        public string userIDValue { get; set; }

        public productsAdmin()
        {
            InitializeComponent();
            txtProduct.TabIndex = 0;
            cmProdCat.TabIndex = 1;
            txtQty.TabIndex = 2;

        }

        private void productsAdmin_Load(object sender, EventArgs e)
        {
            lblUserID.Text = userIDValue;
            conn.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM categories_table", conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            cmProdCat.DataSource = dt;
            cmProdCat.DisplayMember = "cat_name";
            cmProdCat.ValueMember = "cat_ID";

            SqlCommand cmd3 = new SqlCommand("SELECT products_table.prod_ID, categories_table.cat_name AS category, products_table.prod_name, products_table.prod_qty, users_table.user_firstName + ' ' + users_table.user_lastName AS Created_by, products_table.prod_createdAt, products_table.prod_modifiedBy AS modified_byID,products_table.prod_modifiedAt FROM products_table INNER JOIN categories_table ON products_table.cat_ID = categories_table.cat_ID INNER JOIN users_table ON products_table.prod_createdBy = users_table.userID", conn);

            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

            DataTable dt3 = new DataTable();

            da3.Fill(dt3);
            dataGridView1.DataSource = dt3;

            conn.Close();
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
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

                    txtProduct.Clear();
                    txtQty.Clear();

                    dataGridView1.Enabled = false;
                    txtProduct.Enabled = true;
                    txtQty.Enabled = true;
                    cmProdCat.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Incorrect Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void cmProdCat_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtProduct.Text == string.Empty || txtQty.Text == string.Empty || cmProdCat.Text == string.Empty)
            {

                MessageBox.Show("Populate all fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM products_table WHERE prod_name = '" + txtProduct.Text + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Product already exists.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtProduct.Clear();
                    conn.Close();
                }
                else
                {
                    conn.Open();
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO products_table (prod_name, cat_ID, prod_qty, prod_createdBy, prod_createdAt) VALUES (@prod_name, @cat_ID, @prod_qty, @prod_createdBy, @prod_createdAt)", conn);
                    cmd2.Parameters.AddWithValue("@prod_name", txtProduct.Text);
                    cmd2.Parameters.AddWithValue("@cat_ID", cmProdCat.SelectedValue);
                    cmd2.Parameters.AddWithValue("@prod_qty", txtQty.Text);
                    cmd2.Parameters.AddWithValue("@prod_createdBy", lblUserID.Text);
                    cmd2.Parameters.AddWithValue("@prod_createdAt", currentDate);

                    cmd2.ExecuteNonQuery();
                    conn.Close();
                    txtProduct.Clear();
                    txtQty.Clear();

                    SqlCommand cmd3 = new SqlCommand("SELECT products_table.prod_ID, categories_table.cat_name AS category, products_table.prod_name, products_table.prod_qty, users_table.user_firstName + ' ' + users_table.user_lastName AS Created_by, products_table.prod_createdAt, products_table.prod_modifiedBy AS modified_byID,products_table.prod_modifiedAt FROM products_table INNER JOIN categories_table ON products_table.cat_ID = categories_table.cat_ID INNER JOIN users_table ON products_table.prod_createdBy = users_table.userID", conn);
                    SqlDataAdapter da3 = new SqlDataAdapter(cmd3);

                    DataTable dt3 = new DataTable();

                    da3.Fill(dt3);
                    dataGridView1.DataSource = dt3;

                    btnCreate.Visible = true;
                    btnUpdate.Visible = true;
                    btnDelete.Visible = true;
                    btnCancel.Visible = false;

                    btnInsert.Visible = false;

                    txtProduct.Clear();
                    txtQty.Clear();

                    dataGridView1.Enabled = true;
                    txtProduct.Enabled = false;
                    txtQty.Enabled = false;
                    cmProdCat.Enabled = false;

                    MessageBox.Show("Product added!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnCreate.Visible = true;
            btnUpdate.Visible = true;
            btnDelete.Visible = true;

            btnInsert.Visible = false;
            btnNewUpdate.Visible = false;

            txtProduct.Clear();
            txtQty.Clear();

            dataGridView1.Enabled = true;
            txtProduct.Enabled = false;
            txtQty.Enabled = false;
            cmProdCat.Enabled = false;
            btnCancel.Visible = false;
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

                    dataGridView1.Enabled = true;
                    txtProduct.Enabled = true;
                    txtQty.Enabled = true;
                    cmProdCat.Enabled = true;

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
                lblProdID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                cmProdCat.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtProduct.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtQty.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            }
        }

        private void btnNewUpdate_Click(object sender, EventArgs e)
        {
            if (txtProduct.Text == string.Empty || txtQty.Text == string.Empty || cmProdCat.Text == string.Empty)
            {
                MessageBox.Show("Populate all fields", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE products_table SET prod_name=@prod_name, prod_qty=@prod_qty, cat_ID=@cat_ID, prod_modifiedBy=@prod_modifiedBy, prod_modifiedAt=@prod_modifiedAt WHERE prod_ID=@prod_ID", conn);


                cmd.Parameters.AddWithValue("@prod_name", txtProduct.Text);
                cmd.Parameters.AddWithValue("@prod_qty", txtQty.Text);
                cmd.Parameters.AddWithValue("@cat_ID", cmProdCat.SelectedValue);
                cmd.Parameters.AddWithValue("@prod_modifiedBy", lblUserID.Text);
                cmd.Parameters.AddWithValue("@prod_modifiedAt", currentDate);
                cmd.Parameters.AddWithValue("@prod_ID", lblProdID.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                txtProduct.Clear();
                txtQty.Clear();

                MessageBox.Show("User Credentials Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                SqlCommand cmd2 = new SqlCommand("SELECT products_table.prod_ID, categories_table.cat_name AS category, products_table.prod_name, products_table.prod_qty, users_table.user_firstName + ' ' + users_table.user_lastName AS Created_by, products_table.prod_createdAt, products_table.prod_modifiedBy AS modified_byID,products_table.prod_modifiedAt FROM products_table INNER JOIN categories_table ON products_table.cat_ID = categories_table.cat_ID INNER JOIN users_table ON products_table.prod_createdBy = users_table.userID", conn);

                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

                DataTable dt2 = new DataTable();

                da2.Fill(dt2);
                dataGridView1.DataSource = dt2;

                btnCreate.Visible = true;
                btnUpdate.Visible = true;
                btnDelete.Visible = true;

                btnInsert.Visible = false;
                btnNewUpdate.Visible = false;

                txtProduct.Clear();
                txtQty.Clear();

                dataGridView1.Enabled = true;
                txtProduct.Enabled = false;
                txtQty.Enabled = false;
                cmProdCat.Enabled = false;
                btnCancel.Visible = false;

            }
        }

        private void lblProdID_Click(object sender, EventArgs e)
        {

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
                    if (MessageBox.Show("Do you want to delete product?", "Delete data", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        conn.Open();
                        SqlCommand cmd3 = new SqlCommand("DELETE products_table WHERE prod_ID=@prod_ID", conn);


                        cmd3.Parameters.AddWithValue("@prod_ID", lblProdID.Text);

                        cmd3.ExecuteNonQuery();
                        conn.Close();

                        txtProduct.Clear();
                        txtQty.Clear();


                        SqlCommand cmd2 = new SqlCommand("SELECT products_table.prod_ID, categories_table.cat_name AS category, products_table.prod_name, products_table.prod_qty, users_table.user_firstName + ' ' + users_table.user_lastName AS Created_by, products_table.prod_createdAt, products_table.prod_modifiedBy AS modified_byID,products_table.prod_modifiedAt FROM products_table INNER JOIN categories_table ON products_table.cat_ID = categories_table.cat_ID INNER JOIN users_table ON products_table.prod_createdBy = users_table.userID", conn);

                        SqlDataAdapter da2 = new SqlDataAdapter(cmd2);

                        DataTable dt2 = new DataTable();

                        da2.Fill(dt2);
                        dataGridView1.DataSource = dt2;

                        MessageBox.Show("Product Deleted!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Incorrect Password", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }

        private void cmProdCat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
