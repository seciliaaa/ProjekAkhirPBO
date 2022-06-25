using System;
using System.Windows.Forms;

namespace Projek2
{
    public partial class Form1 : Form
    {
        Registration rg = new Registration();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            rg.Show();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
