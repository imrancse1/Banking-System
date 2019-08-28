using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Banking_System_Software
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            accountcreation account = new accountcreation();
            account.Show();
         



        }

        private void button3_Click(object sender, EventArgs e)
        {
            deposit d = new deposit();
            d.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            withdraw w = new withdraw();
            w.Show();
        }

      

        private void button5_Click_1(object sender, EventArgs e)
        {
            transfer t = new transfer();
            t.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            display d = new display();
            d.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            delete de = new delete();
            de.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            developer de = new developer();
            de.Show();
        }
    }
}
