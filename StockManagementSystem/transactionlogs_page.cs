using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace StockManagementSystem
{
    public partial class transactionlogs_page : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\user\Desktop\SDAM STOCK SYSTEM\StockManagementSystem\StockManagementSystem\Database1.mdf"";Integrated Security=True");

        public transactionlogs_page()
        {
            InitializeComponent();
        }

        private void transactionlogs_page_Load(object sender, EventArgs e)
        {
            LoadDataFromDatabase();
        }

        public void LoadDataFromDatabase()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
            con.Open();

            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT stock_code, item_name, quantity, date_and_time FROM stockmanagement";

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        //public void AddCurrentDateTime(DateTime currentDateTime)
        //{
            // dataGridView1.Rows.Add(currentDateTime.ToString("yyyy-MM-dd HH:mm:ss"));
        //}

        private void gobackBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            menu menuPage = new menu();
            _ = menuPage.ShowDialog();
        }
    }
    }

