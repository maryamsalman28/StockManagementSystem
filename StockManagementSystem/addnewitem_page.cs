using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class addnewitem_page : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\user\Desktop\SDAM STOCK SYSTEM\StockManagementSystem\StockManagementSystem\Database1.mdf"";Integrated Security=True");

        public addnewitem_page()
        {
            InitializeComponent();
        }

        private void gobackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menuPage = new menu();
            _ = menuPage.ShowDialog();
        }

        private void clearbutton_Click(object sender, EventArgs e)
        {
            stockcodeTxtbox.Clear();
            itemnameTxtbox.Clear();
            quantityTextbox.Clear();
            stockcodeTxtbox.Focus();
        }

        private void addnewitem_page_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();
        }

        private void additemBtn_Click(object sender, EventArgs e)
        {
            int i = 0;
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from stockmanagement where stock_code='" + stockcodeTxtbox.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                // Create a StockItem object
                StockItem newItem = new StockItem(
                    int.Parse(stockcodeTxtbox.Text),
                    itemnameTxtbox.Text,
                    int.Parse(quantityTextbox.Text),
                    DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
                );

                // Insert the StockItem into the database
                SqlCommand cmd1 = con.CreateCommand();
                cmd1.CommandType = CommandType.Text;
                cmd1.CommandText = "INSERT INTO stockmanagement (stock_code, item_name, quantity, date_and_time) VALUES (@stock_code, @item_name, @quantity, @date_and_time)";
                cmd1.Parameters.AddWithValue("@stock_code", newItem.GetStockCode());
                cmd1.Parameters.AddWithValue("@item_name", newItem.GetStockName());
                cmd1.Parameters.AddWithValue("@quantity", newItem.GetStockQuantity());
                cmd1.Parameters.AddWithValue("@date_and_time", newItem.GetDate());
                cmd1.ExecuteNonQuery();

                stockcodeTxtbox.Text = " ";
                itemnameTxtbox.Text = " ";
                quantityTextbox.Text = " ";

                MessageBox.Show("Item added successfully.");
            }
            else
            {
                MessageBox.Show("This item already exists.");
            }

            this.Hide();
            transactionlogs_page ViewDataForm = new transactionlogs_page();
            ViewDataForm.LoadDataFromDatabase();
            ViewDataForm.Show();
        }
    }
}
