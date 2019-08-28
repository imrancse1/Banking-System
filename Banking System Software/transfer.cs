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
    public partial class transfer : Form
    {
        public transfer()
        {
           
            InitializeComponent();
        }
        MySqlConnection con = new MySqlConnection("server = localhost; database = bank; username = root; password=;");
        private void button1_Click(object sender, EventArgs e)
        {


            this.ActiveControl = txtf;
            
                string fno, tono, date;
                double bal;

                fno = txtf.Text;
                tono = txto.Text;
                date = txtdate.Text;
                bal = double.Parse(txtamount.Text);





                con.Open();
                MySqlCommand cmd = new MySqlCommand();
                MySqlTransaction transaction;
                transaction = con.BeginTransaction();

                cmd.Connection = con;
                cmd.Transaction = transaction;

                try
                {
                    cmd.CommandText = "update customer set bal = bal + '" + bal + "' where custid = '" + tono + "'";
                    cmd.ExecuteNonQuery();

                    cmd.CommandText = "update customer set bal = bal - '" + bal + "' where custid = '" + fno + "'";
                    cmd.ExecuteNonQuery();

                    transaction.Commit();

                    

                    MessageBox.Show("Transfer Succesfully....!");
                    this.Hide();


                    cmd.CommandText = "insert into transfer(tf_id, f_acc,to_acc, date, bal) values('" + fno + "', '" + tono + "','" + date + "','" + bal + "')";
                    cmd.ExecuteNonQuery();

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
            this.Hide();
        }

        private void txtf_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {
            

        }

        private void transfer_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtf;
        }
    }
}
