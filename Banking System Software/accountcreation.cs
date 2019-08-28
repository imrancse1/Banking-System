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
    public partial class accountcreation : Form
    {
        public accountcreation()
        {
            InitializeComponent();
        }


       
        MySqlConnection con = new MySqlConnection("server = localhost; database = bank; username = root; password=;");


        public void custid()
        { 
        
            con.Open();
            string query  = "select max(custid) from customer";
            MySqlCommand cmd = new MySqlCommand(query, con);
            this.ActiveControl = txtlname;
            
            MySqlDataReader dr;


            dr = cmd.ExecuteReader();

            
            if (dr.Read())
            {
                String val = dr[0].ToString();
                if (val == "")
                {
	                txtid.Text = "100";
                    
                   
                  
                }
                else 
                {

	            int a ;
                a = int.Parse(dr[0].ToString());
                a = a+1;
                txtid.Text = a.ToString();


                }
                con.Close();
        }


        
        
        
        }








        

        private void accountcreation_Load(object sender, EventArgs e)
        {

            custid();
        }

        private void txtid_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String cid, lname, fname, street, city, bal, phone, email, date;

            cid = txtid.Text;
            lname = txtlname.Text;
            fname = txtfname.Text;
            street = txtstreet.Text;
            city = txtcity.Text;
            bal = txtbal.Text;
            phone = txtphone.Text;
            date = txtdate.Text;
            email = txtemail.Text;


         

            con.Open();
            MySqlCommand cmd = new MySqlCommand();
            MySqlTransaction transaction ;
            transaction = con.BeginTransaction();

            cmd.Connection = con;
            cmd.Transaction = transaction;

            try
            {
                cmd.CommandText = "insert into customer(custid, lastname, firstname, street,city, bal, phone,date,email) values('" + cid + "', '" + lname + "','" + fname + "','" + street + "','" + city + "','" + bal + "','" + phone + "','" + date + "','" + email + "');";
                cmd.ExecuteNonQuery();

               

                transaction.Commit();
                MessageBox.Show("Record Added....!");
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

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txtacno_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

       

        }
    }

