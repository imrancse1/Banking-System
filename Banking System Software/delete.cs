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
    public partial class delete : Form
    {
        public delete()
        {
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server = localhost; database = bank; username = root; password=;");

        private void button1_Click(object sender, EventArgs e)
        {
             
          

            try
            {
                

                con.Open();
                string srt = "select * from customer where custid ='" + txtacc.Text + "';";
                MySqlCommand cmd = new MySqlCommand(srt, con);

                MySqlDataReader rd = cmd.ExecuteReader();


                


                    while (rd.Read())
                    {

                        label7.Text = rd[8].ToString();
                     

                        label6.Text = rd[1].ToString();
                        phone.Text = rd[5].ToString();
                        email.Text = rd[7].ToString();
                        reg.Text = rd[6].ToString();

                      
                       

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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string acno;
            double bal;
           

            acno = txtacc.Text;
            bal = double.Parse(label7.Text);


            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction transaction;
            transaction = con.BeginTransaction();

            cmd.Connection = con;
            cmd.Transaction = transaction;

            try
            {



                if (bal > 0)
                {

                    if (MessageBox.Show("Do You Want To Remove This Data", "Waring !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cmd.CommandText = "delete from customer where custid = '" + acno + "'";
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Account Delete Succesfully....!");
                        this.Hide();

                    }

                    else
                    {
                        MessageBox.Show("Data Not Deleted", "Waring !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();

                    }


                }
                else
                {
                    MessageBox.Show("Please Search the Account");
                }









                transaction.Commit();
               
             



            }



            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.ToString());
                con.Close();



            }

            finally
            {
                con.Close();

            }

        }
    }
}
