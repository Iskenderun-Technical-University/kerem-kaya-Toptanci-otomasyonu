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
    public partial class Form9 : Form
    {
        public Form9()
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
            da = new SqlDataAdapter("SELECT * from siparisler where sirket_ismi='daşcı' ", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "siparisler");

            dataGridView1.DataSource = ds.Tables["siparisler"];
            con.Close();
        }
        private void Form9_Load(object sender, EventArgs e)
        {
            GriDoldur();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
        }
    }
}
