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
    public partial class deposit : Form
    {
        public deposit()
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
                    last.Text = rd[2].ToString();



                }


            }



            catch (Exception )
            {
         



            }

            finally
            {
                con.Close();

            }





        }

        private void button2_Click(object sender, EventArgs e)
        {
            string acno, date;
            double bal, deposit;

            acno = txtacc.Text;
            date = bdate.Text;
            bal = double.Parse(label7.Text);
            deposit = double.Parse(txtdbal.Text);


            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction transaction;
            transaction = con.BeginTransaction();

            cmd.Connection = con;
            cmd.Transaction = transaction;

            try
            {
                cmd.CommandText = "update customer set bal = bal + '"+deposit+"' where custid = '"+acno+"'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into transaction(accid, date,bal, deposit) values('" + acno + "', '" + date + "','" + bal + "','" + deposit + "')";
                cmd.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Balance Deposit Succesfully....!");
                this.Hide();




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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void deposit_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtacc;

        }
    }
}
