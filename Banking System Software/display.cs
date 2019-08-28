using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;




namespace Banking_System_Software
{
    public partial class display : Form
    {
        public display()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server = localhost; database = bank; username = root; password=;");

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                string srt = "select * from customer where custid = '" + txtac.Text + "'";
                MySqlCommand cmd = new MySqlCommand(srt, con);

                MySqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    fn.Text = rd[1].ToString();
                    ln.Text = rd[2].ToString();
                    st.Text = rd[3].ToString();
                    ci.Text = rd[4].ToString();
                    ph.Text = rd[5].ToString();
                    da.Text = rd[6].ToString();
                    em.Text = rd[7].ToString();
                    ba.Text = rd[8].ToString();



                }




            }






            catch (Exception)
            {




            }

            finally
            {
                con.Close();

            }

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            this.Hide();

        }


    }
}