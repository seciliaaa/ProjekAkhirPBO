using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace Projek2
{
    public partial class Registration : Form
    {
        public Registration()
        {
            display();
        }
        public void display()
        {
            InitializeComponent();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=tapbo;User Id=postgres;Password=tunasharapan06");
            conn.Open();
            NpgsqlDataAdapter adapt = new NpgsqlDataAdapter();
            DataTable dt = new DataTable();
            adapt = new NpgsqlDataAdapter("select * from customer", conn);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        public void clear()
        {
            textBox1.Text = String.Empty;
            textBox2.Text = String.Empty;
            textBox3.Text = String.Empty;
            textBox4.Text = String.Empty;
            textBox5.Text = String.Empty;
            textBox6.Text = String.Empty;
            textBox7.Text = String.Empty;
            textBox8.Text = String.Empty;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            string nama = (string)textBox8.Text;
            string ttl = (string)textBox7.Text;
            string jenis_kelamin;
            if (radioButton1.Checked)
            {
                jenis_kelamin = "Laki-laki";
            }
            else
            {
                jenis_kelamin = "Perempuan";
            }
            string telepon = (string)textBox2.Text;
            string email = (string)textBox3.Text;
            string alamat = (string)textBox4.Text;
            string nomor_ktp = (string)textBox5.Text;
            string nama_ibu_kandung = (string)textBox6.Text;
            string jenis_tabungan;
            if (checkBox1.Checked)
            {
                jenis_tabungan = "Tabungan Simdas";
            }
            else if (checkBox2.Checked)
            {
                jenis_tabungan = "Deposito";
            }
            else
            {
                jenis_tabungan = "Tabungan Prestasi";
            }
            
            InitializeComponent();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=tapbo;User Id=postgres;Password=tunasharapan06");
            conn.Open();
            NpgsqlCommand comm = conn.CreateCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "INSERT INTO customer(customerid, nama, ttl, jenis_kelamin, telepon, email, alamat, nomor_ktp, nama_ibu_kandung, jenis_tabungan)" +
                "VALUES(@customerid, @nama, @ttl, @jenis_kelamin, @telepon, @email, @alamat, @nomor_KTP, @nama_ibu_kandung, @jenis_tabungan); ";
            comm.Parameters.AddWithValue("@customerid", id);
            comm.Parameters.AddWithValue("@nama", nama);
            comm.Parameters.AddWithValue("@ttl", ttl);
            comm.Parameters.AddWithValue("@jenis_kelamin", jenis_kelamin);
            comm.Parameters.AddWithValue("@telepon", telepon);
            comm.Parameters.AddWithValue("@email", email);
            comm.Parameters.AddWithValue("@alamat", alamat);
            comm.Parameters.AddWithValue("@nomor_KTP", nomor_ktp);
            comm.Parameters.AddWithValue("@nama_ibu_kandung", nama_ibu_kandung);
            comm.Parameters.AddWithValue("@jenis_tabungan", jenis_tabungan);
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Sukses diinputkan");
            display();
            clear();

        }
        

        private void button3_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            InitializeComponent();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=tapbo;User Id=postgres;Password=tunasharapan06");
            conn.Open();
            NpgsqlCommand comm = conn.CreateCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "delete from customer where customerid =@customerid;";
            comm.Parameters.AddWithValue("@customerid", id);
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Berhasil dihapus");

        }
 

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            string nama = (string)textBox8.Text;
            string ttl = (string)textBox7.Text;
            string jenis_kelamin;
            if (radioButton1.Checked)
            {
                jenis_kelamin = "Laki-laki";
            }
            else
            {
                jenis_kelamin = "Perempuan";
            }
            string telepon = (string)textBox2.Text;
            string email = (string)textBox3.Text;
            string alamat = (string)textBox4.Text;
            string nomor_ktp = (string)textBox5.Text;
            string nama_ibu_kandung = (string)textBox6.Text;
            string jenis_tabungan;
            if (checkBox1.Checked)
            {
                jenis_tabungan = "Tabungan Simdas";
            }
            else if (checkBox2.Checked)
            {
                jenis_tabungan = "Deposito";
            }
            else
            {
                jenis_tabungan = "Tabungan Prestasi";
            }
            InitializeComponent();
            NpgsqlConnection conn = new NpgsqlConnection("Server=localhost;Port=5432;Database=tapbo;User Id=postgres;Password=tunasharapan06");
            conn.Open();
            NpgsqlCommand comm = conn.CreateCommand();
            comm.Connection = conn;
            comm.CommandType = CommandType.Text;
            comm.CommandText = "Update customer set nama= '"+nama+ "', ttl='" + ttl + "', jenis_kelamin='" + jenis_kelamin + "', " +
                "telepon='" + telepon + "', email='" + email + "', alamat='" + alamat + "', nomor_ktp='" + nomor_ktp + "', nama_ibu_kandung='" + nama_ibu_kandung + 
                "', jenis_tabungan='" + jenis_tabungan + "' WHERE customerid=@customerid";
            comm.Parameters.AddWithValue("@customerid", id);
            comm.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data Berhasil diUpdate");
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
