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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int count;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, password;

            username = txtuser.Text;
            password = txtpass.Text;



            count = count + 1;

            if (count > 3)
            {
                MessageBox.Show ("System has been Blocked......! ");
                Application.Exit();

            }
           



            if (username == "admin" && password == "admin")
            {

                //label4.Text = "Log in Successfully!";



                progbar pr = new progbar();
                this.Hide();
                pr.Show();




            }
            else
            {
                label4.Text = "Invalid Username and Password";
                txtuser.Clear();
                txtpass.Clear();
                txtuser.Focus();

            
            }
            if (username == "" && password == "")
            {
                label4.Text = "Blank not Allowed";
            }



        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
