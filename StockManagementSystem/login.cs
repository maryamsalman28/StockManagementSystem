namespace StockManagementSystem
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        

        private void loginBtn_Click(object sender, EventArgs e)
        {
            if (usernameTxtbox.Text == "maryam" && passwordTxtbox.Text == "maryam123")
            {
                new menu().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("The Username or Password is incorrect, try again");
                usernameTxtbox.Clear();
                passwordTxtbox.Clear();
                usernameTxtbox.Focus();
            }

        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            usernameTxtbox.Clear();
            passwordTxtbox.Clear();
            usernameTxtbox.Focus();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}