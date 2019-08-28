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
    public partial class progbar : Form
    {
        public progbar()
        {
            InitializeComponent();
        }

    

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = progressBar1.Value + 2;

            if (progressBar1.Value >= 100)
            {

                main m = new main();
                this.Hide();
                m.Show();



                timer1.Enabled = false;
                progressBar1.Value = progressBar1.Value - 1;
        }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void progbar_Load(object sender, EventArgs e)
        {

        }
    }
}
