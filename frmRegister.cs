using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class frmRegister : Form
    {
        SqlConnection connection = new SqlConnection("Data Source=RACUNAR202\\SQLEXPRESS;Initial Catalog=store;Integrated Security=True");

        public frmRegister()
        {
            InitializeComponent();
        }

        private void CheckbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckbxShowPas.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '○';
                txtComPassword.PasswordChar = '○';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "" && txtPassword.Text == "" && txtComPassword.Text == "")
            {
                MessageBox.Show("Popunite korisnicko ime i sifru", "Neuspesna registracija", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text == txtComPassword.Text)
            {
                connection.Open();
                string register = "INSERT INTO users VALUES('" + txtUsername.Text + "','tempemail@email.com','" + txtPassword.Text + "',0)";
                SqlCommand cmd = new SqlCommand(register, connection);
                cmd.ExecuteNonQuery();
                connection.Close();

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtComPassword.Text = "";

                MessageBox.Show("Upesno ste napravili nalog", "Uspesna registracija", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Sifre se ne poklapaju, unesite ponovo", "Neuspesna registracija", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = " ";
                txtComPassword.Text = " ";
                txtPassword.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtComPassword.Text = "";
            txtUsername.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Hide();
            new frmLogin().ShowDialog();
            Close();
        }
    }
}