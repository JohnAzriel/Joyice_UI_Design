using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;



namespace Joyice
{
    public partial class printOrdersStaff : Form
    {
        SqlConnection conn = new SqlConnection("Data Source=Connecting\\SQLEXPRESS;Initial Catalog=joyice;Integrated Security=True");
        String datagridQuery = "SELECT orders_table.order_ID, customers_table.cus_name, products_table.prod_name, orders_table.order_qty, orders_table.order_date, users_table.user_firstName +' '+ users_table.user_lastName AS order_createdBy FROM orders_table INNER JOIN products_table ON orders_table.prod_ID = products_table.prod_ID INNER JOIN customers_table ON orders_table.cus_ID = customers_table.cus_ID INNER JOIN users_table ON orders_table.userID = users_table.userID";
        string ordersPDFpath = ConfigurationManager.AppSettings["ordersPDFpath"];
        string logoPDFPath = ConfigurationManager.AppSettings["logoPDFPath"];
        DateTime currentTime = DateTime.Now;

        public printOrdersStaff()
        {
            InitializeComponent();
        }

        private void printOrdersStaff_Load(object sender, EventArgs e)
        {
            SqlCommand cmd3 = new SqlCommand(datagridQuery, conn);
            SqlDataAdapter da3 = new SqlDataAdapter(cmd3);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            dataGridView1.DataSource = dt3;
        }
        
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtCusName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtProd.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtQty.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txtDate.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                txtMadeBy.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();

            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to print order?", "Print Order", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (txtID.Text == string.Empty && txtCusName.Text == string.Empty && txtDate.Text == string.Empty && txtMadeBy.Text == string.Empty && txtProd.Text == string.Empty && txtQty.Text == string.Empty)
                {
                    MessageBox.Show("Please select an order to print", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Document document = new Document();

                    try
                    {
                        string fileName = $"Order_{txtID.Text}_{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}.pdf";
                        fileName = fileName.Replace("/", "-").Replace(":", ".");
                        string fullPath = $"{ordersPDFpath}/{fileName}";

                        PdfWriter.GetInstance(document, new FileStream(fullPath, FileMode.Create));

                        document.Open();

                        System.Drawing.Image image = System.Drawing.Image.FromFile(logoPDFPath);

                        float maxWidth = document.PageSize.Width * 0.25f;
                        float maxHeight = document.PageSize.Height * 0.25f;

                        float aspectRatio = image.Width / (float)image.Height;

                        float width = Math.Min(maxWidth, image.Width);
                        float height = Math.Min(maxHeight, width / aspectRatio);

                        iTextSharp.text.Image pdfImage = iTextSharp.text.Image.GetInstance(image, System.Drawing.Imaging.ImageFormat.Jpeg);
                        pdfImage.ScaleAbsolute(width, height);


                        float x = (document.PageSize.Width - pdfImage.ScaledWidth) / 2;
                        float y = document.PageSize.Height - pdfImage.ScaledHeight - 80f;
                        pdfImage.SetAbsolutePosition(x, y);

                        document.Add(pdfImage);


                        Chunk chunk = new Chunk("Thank you for ordering from JoyIce");


                        Font font = FontFactory.GetFont("Times New Roman", 25);


                        chunk.Font = font;

                        Paragraph paraTitle = new Paragraph();
                        paraTitle.Alignment = Element.ALIGN_CENTER;
                        paraTitle.Add(chunk);

                        document.Add(paraTitle);



                        document.Add(new Paragraph("\n\n\n\n\n\n\n\n\n\n\n\n"));
                        document.Add(new Paragraph("______________________________________________________________________________"));
                        document.Add(new Paragraph("\n\n"));
                        Paragraph para = new Paragraph();

                        para.Add($"Order ID: {txtID.Text}\nCustomer Name: {txtCusName.Text}\nOrder Details: \n    -> Product Name: {txtProd.Text}\n    -> Product Quantity: {txtQty.Text}\n    -> Order Date: {txtDate.Text}\n    -> Order Create By: {txtMadeBy.Text}\n");

                        document.Add(para);

                        document.Close();

                        if (MessageBox.Show($"{fileName} created! Do you want to open PDF?", "Open PDF", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            Process.Start(fullPath);
                        }

                    }
                    catch (Exception ex)
                    {
                        // Handle any errors that occur during PDF generation
                        MessageBox.Show(ex.Message);
                    }

                }

            }

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
    }
}
