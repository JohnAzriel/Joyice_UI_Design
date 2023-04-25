using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Joyice
{
    public partial class reportsAdmin : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Connecting\\SQLEXPRESS;Initial Catalog=joyice;Integrated Security=True");
        String datagridQuery = "SELECT \r\n  orders_table.order_ID, \r\n  orders_table.cus_ID,\r\n  customers_table.cus_name, \r\n  products_table.prod_name, \r\n  orders_table.order_qty, \r\n  orders_table.order_date, \r\n  users_table.user_firstName + ' ' + users_table.user_lastName AS order_createdBy\r\nFROM orders_table \r\nINNER JOIN products_table ON orders_table.prod_ID = products_table.prod_ID \r\nINNER JOIN customers_table ON orders_table.cus_ID = customers_table.cus_ID \r\nINNER JOIN users_table ON orders_table.userID = users_table.userID\r\n";
        String showDetails = "SELECT COUNT(*) AS order_count, MAX(order_date) AS last_order_date FROM orders_table WHERE cus_ID = @cus_ID";


        public reportsAdmin()
        {
            InitializeComponent();
        }

        private void reportsAdmin_Load(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand(datagridQuery, conn);

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand($"{datagridQuery} WHERE cus_name LIKE '%" + txtSearch.Text + "%'", conn);
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
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtName.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void btnNewUpdate_Click(object sender, EventArgs e)
        {
            conn.Open();
            if (txtID.Text == string.Empty && txtName.Text == string.Empty)
            {
                MessageBox.Show("Please select a customer", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlCommand cmd = new SqlCommand($"{showDetails}", conn);
                cmd.Parameters.AddWithValue("@cus_ID", txtID.Text);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int orderCount = Convert.ToInt32(reader["order_count"]);
                    DateTime lastOrderDate = Convert.ToDateTime(reader["last_order_date"]);

                    // Update the text box with the result
                    String counts = orderCount.ToString();
                    String date = lastOrderDate.ToShortDateString();
                    MessageBox.Show("Order Count: " + counts + "\nLast Order Date: " + date, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    reader.Close();
                }
            }
            conn.Close();


        }
    }
}
