using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagementSystem
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            addnewitem_page newItemForm = new addnewitem_page();
            _ = newItemForm.ShowDialog();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            transactionlogs_page transactionForm = new transactionlogs_page();
            transactionForm.ShowDialog();
            
        }

        private void menu_Load(object sender, EventArgs e)
        {

        }
    }
}
