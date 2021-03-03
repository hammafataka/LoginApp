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
    public partial class Grades : Form
    {
        


        public Grades()
        {
            InitializeComponent();
            


        }
        

        private void label1_Click(object sender, EventArgs e)
        {
            

        }
        public static decimal qnum;
        public static decimal rnum = 0;

 
        private void Grades_Load(object sender, EventArgs e)
        {

           

            
            string t = student.Qname;
            string c = student.Qcode;
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-039S4KAI\FATAKA;Initial Catalog=final;Integrated Security=True;");
            con.Open();
            SqlCommand commandQ1 = new SqlCommand($" select * from {t} where Code='{c}'", con);
            SqlDataAdapter adapterQ1 = new SqlDataAdapter(commandQ1);
            DataTable dtQ = new DataTable();
            adapterQ1.Fill(dtQ);
            decimal Qnum = dtQ.Rows.Count;
            Qnum = qnum;
            int Rnum;
            Rnum = Questions.rightA;
            rnum = Rnum;
            int g = Convert.ToInt32(GetG());

            label1.Text = "welcome dear " + UTB.userL;
            label2.Text = $"your grade in this {t} is: {g}";




            SqlCommand command2 = new SqlCommand($"insert into Grades values('{t}','{UTB.userL}','{g}') ",con);
            SqlDataAdapter adapter2 = new SqlDataAdapter(command2);
            adapter2.InsertCommand = command2;
            adapter2.InsertCommand.ExecuteNonQuery();



            commandQ1.Dispose();
            adapterQ1.Dispose();
            command2.Dispose();
            adapter2.Dispose();
            con.Close();

        }
        public decimal GetG()
        {
            string t = student.Qname;
            string c = student.Qcode;
            decimal r;
            SqlConnection con = new SqlConnection(@"Data Source=LAPTOP-039S4KAI\FATAKA;Initial Catalog=final;Integrated Security=True;");
            con.Open();
            SqlCommand commandQ1 = new SqlCommand($" select * from {t} where Code='{c}'", con);
            SqlDataAdapter adapterQ1 = new SqlDataAdapter(commandQ1);
            DataTable dtQ = new DataTable();
            adapterQ1.Fill(dtQ);


            r = (rnum / dtQ.Rows.Count) * 100;

            return r;
            
            
            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UTB uTB = new UTB();
            uTB.Show();
        }
    }
}
