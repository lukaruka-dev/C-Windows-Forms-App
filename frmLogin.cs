using System;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp2
{
    public partial class frmLogin : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=RACUNAR202\\SQLEXPRESS;Initial Catalog=store;Integrated Security=True");

        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand($"SELECT COUNT(*) FROM users WHERE username='{txtUsername.Text}' and password='{txtPassword.Text}'", connection);
         
            connection.Open();
            var a = (int)cmd.ExecuteScalar();
            connection.Close();
            
            if (a > 0)
            {
                Hide();
                new EditForm().ShowDialog();
                Close();
            }
            else
            {
                MessageBox.Show("Netacna sifra ili username", "Neuspesno logovanje",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtUsername.Focus(); 
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtUsername.Focus();
        }

        private void CheckbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '○';              
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Hide();
            new frmRegister().ShowDialog();
            Close();
        }
    }
}
