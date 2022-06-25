using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace Projek2
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=tapbo;User Id=postgres;Password=tunasharapan06");
            NpgsqlDataAdapter adp = new NpgsqlDataAdapter("select loginid from public.login where username='"+textBox1.Text+"' and password='"+textBox2.Text+"'", conn);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            if (dt.Rows[0][0].ToString() == "1")
            {
                this.Hide();
                Form1 fm = new Form1();
                fm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Cek Kembali username atau password anda");
            }
        }
    }
}
