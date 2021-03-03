using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp1
{
    public partial class UTB : Form
    {
        public static string userL = "";
        public static string userP = "";




        public UTB()
        {
         
            InitializeComponent();
            

        }

        private void Canclebutton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginbutton_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-039S4KAI\FATAKA;Initial Catalog=final;Integrated Security=True;");
            SqlCommand cmd = new SqlCommand("select * from Login where UserName='" + textBox1.Text + "'and Password='" + textBox2.Text + "'", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string cmb = "";
            try
            {
                string cmbitemvalue = comboBox1.SelectedItem.ToString();
                cmb = cmbitemvalue;


            }
            catch (System.NullReferenceException)
            {

                MessageBox.Show("Please Enter the user Type.","Errror",MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            

            if (dt.Rows.Count > 0)
            {
                for (int i=0;i<dt.Rows.Count;i++)
                {
                    if (cmb==dt.Rows[i]["UserType"].ToString())
                    {
                        MessageBox.Show("You login as "+dt.Rows[i][2],"Login succes",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        if (comboBox1.SelectedIndex==0)
                        {
                            userP = textBox1.Text;
                            Profesor P= new Profesor();
                            P.Show();
                            this.Hide();
                        }
                        else if(comboBox1.SelectedIndex==1)
                        {
                            userL = textBox1.Text;
                            student s = new student();
                            s.Show();
                            this.Hide();
                        }

                    }
                }

            }
            else 
            {
                MessageBox.Show("please check your username and password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                
                

            }
            cmd.Dispose();
            sda.Dispose();

           


        }
        


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
           

        }

   

        private void label3_Click(object sender, EventArgs e)
        {
            ForgotPass fg = new ForgotPass();
            fg.Show();
            this.Hide();

        }
    }
}
