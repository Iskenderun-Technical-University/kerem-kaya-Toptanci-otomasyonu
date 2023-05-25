using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace den
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        static SqlConnection con;
        static SqlDataAdapter da;
        static SqlCommand cmd;
        static DataSet ds;
        public static String SqlCon = "Data Source=DESKTOP-TK2GC17\\SQLEXPRESS;Initial Catalog=odev;Integrated Security=True";
        void GriDoldur()
        {

            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("Select * from urunler where urun_sayisi > 0", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "urunler");

            dataGridView1.DataSource = ds.Tables["urunler"];
            con.Close();
        }
        void Gribiten()
        {

            con = new SqlConnection(SqlCon);
            da = new SqlDataAdapter("Select * from urunler where urun_sayisi=0", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "urunler");

            dataGridView2.DataSource = ds.Tables["urunler"];
            con.Close();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            GriDoldur();
            Gribiten();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
    }
}
