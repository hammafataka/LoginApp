using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class ForgotPass : Form
    {
        public ForgotPass()
        {
            InitializeComponent();
        }

        private void ForgotPass_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-039S4KAI\FATAKA;Initial Catalog=final;Integrated Security=True;");
            con.Open();
            SqlCommand commandQ1 = new SqlCommand($"select * from Login ", con);
            SqlDataAdapter adapterQ1 = new SqlDataAdapter(commandQ1);
            DataTable dtQ = new DataTable();
            adapterQ1.Fill(dtQ);

            if (textBox1.Text.Length < 1 || textBox2.Text.Length < 1)
            {
                MessageBox.Show("please fill both name and email blank", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else 
            {
                bool found = false;
               

               for (int i = 0; i < dtQ.Rows.Count; i++)
               {

                        if (textBox1.Text == dtQ.Rows[i][0].ToString() && textBox2.Text == dtQ.Rows[i][3].ToString())
                        {
                            MessageBox.Show($"your password is: {dtQ.Rows[i][1].ToString()}", "Recovered", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            found = true;
                        }
                        else
                        {
                            found = false;
                        }

               }

                if (found != true)
                {

                    MessageBox.Show("entered data not found please double check..","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
              
               
                
                
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UTB tB = new UTB();
            tB.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
