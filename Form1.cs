using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;

namespace YESNO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public int value = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Interval = Int32.Parse(textBox1.Text);
            timer1.Start();
                       
        }

        //private void button2_Click(object sender, EventArgs e)
        //{

        //    string connstring = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", "localhost", "5432", "postgres", "video3545", "pilot");

        //    NpgsqlConnection conn = new NpgsqlConnection(connstring);
        //    conn.Open();

        //    var cmd = new NpgsqlCommand();
        //    cmd.Connection = conn;
        //    cmd.CommandText = "CREATE TABLE public.referendum(id serial PRIMARY KEY, yes NUMERIC, no NUMERIC); INSERT INTO public.referendum(id, yes, no) VALUES(0, 0, 0)";
        //    cmd.ExecuteNonQuery();

        //    conn.Close();
            
        //}

        private void timer1_Tick(object sender, EventArgs e)
        {
            listBox1.Items.Add(DateTime.Now.ToString() + "   interval: " + timer1.Interval.ToString() + " value: " + value);
            string connstring = String.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};", "localhost", "5432", "postgres", "45h@dr8X", "pilot"); //45h@dr8X


            NpgsqlConnection conn = new NpgsqlConnection(connstring);
            conn.Open();

            var cmd = new NpgsqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "UPDATE public.election SET seats = " + value + " WHERE id = 428 ";
            cmd.ExecuteNonQuery();

            conn.Close();
            value = value + 1;
            
            timer1.Interval = timer1.Interval + 1000;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
