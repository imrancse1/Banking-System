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
    public partial class withdraw : Form
    {
        public withdraw()
        {
            InitializeComponent();
        }

        MySqlConnection con = new MySqlConnection("server = localhost; database = bank; username = root; password=;");

        private void withdraw_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtacc;

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                string srt = "select * from customer where custid ='" + txtacc.Text + "'";
                MySqlCommand cmd = new MySqlCommand(srt, con);

                MySqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    label6.Text = rd[1].ToString();
                    label7.Text = rd[8].ToString();
                    last.Text = rd[2].ToString();

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

        private void button2_Click(object sender, EventArgs e)
        {
            string acno, date;
            double bal, withdraw;

            acno = txtacc.Text;
            date = txtdate.Text;
            bal = double.Parse(label7.Text);
            withdraw = double.Parse(txtwbal.Text);


            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction transaction;
            transaction = con.BeginTransaction();

            cmd.Connection = con;
            cmd.Transaction = transaction;

            try
            {
                cmd.CommandText = "update customer set bal = bal - '" + withdraw + "' where custid = '" + acno + "'";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "insert into transaction(accid, date,bal, withdraw) values('" + acno + "', '" + date + "','" + bal + "','" + withdraw + "')";
                cmd.ExecuteNonQuery();

                transaction.Commit();
                MessageBox.Show("Withdraw Succesfully....!");
                this.Hide();




            }



            catch (Exception ex)
            {
                transaction.Rollback();
                MessageBox.Show(ex.ToString());




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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
