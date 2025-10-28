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
using Microsoft.Data.SqlClient;
namespace ProiectAtestat
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txt_password.PasswordChar = '*';
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=(localdb)\\echipa;Initial Catalog=ProiectAtestat;Integrated Security=True;TrustServerCertificate=True");
            con.Open();
            string query = "SELECT COUNT(*) FROM loginapp WHERE username=@username AND password=@password";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@username", txt_username.Text);
            cmd.Parameters.AddWithValue("@password", txt_password.Text);
            int count = (int)cmd.ExecuteScalar();
            con.Close();
            if (count > 0)
            {
                Form1 game = new Form1(txt_username.Text);
                game.Show();
            }
            else
            {
                MessageBox.Show("error to login");
            }
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged (Object sender, EventArgs e)
        {
            txt_password.PasswordChar =checkBox1.Checked ? '\0' : '*';
        }
    }
}
