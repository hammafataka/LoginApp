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
    public partial class Edit : Form
    {
        public Edit()
        {
            InitializeComponent();
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {




                SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-039S4KAI\FATAKA;Initial Catalog=final;Integrated Security=True;");
                con.Open();

                string sql = $"select*from {textBox1.Text}";
                SqlCommand Qcommand = new SqlCommand(sql, con);
                SqlDataReader reader = Qcommand.ExecuteReader();



                if (reader.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    dataGridView1.DataSource = dt;



                }

                Qcommand.Dispose();
                reader.Close();

            }
            catch 
            {
                MessageBox.Show("Incorrect exam name, or the exam is not in database","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
              
            }


        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profesor profesor = new Profesor();
            profesor.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            UTB uTB = new UTB();
            uTB.Show();

        }
    }
}
