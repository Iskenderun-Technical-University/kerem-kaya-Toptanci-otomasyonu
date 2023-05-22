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
    public partial class Form6 : Form
    {
        public Form6()
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
            da = new SqlDataAdapter("Select * from siparisler", con);
            ds = new DataSet();
            con.Open();
            da.Fill(ds, "siparisler");

            dataGridView1.DataSource = ds.Tables["siparisler"];
            con.Close();
        }
        private void Form6_Load(object sender, EventArgs e)
        {
            GriDoldur();
            dataGridView1.Columns[0].HeaderText = "Siparis Sırası";
            dataGridView1.Columns[1].HeaderText = "Siparis Türü";
            dataGridView1.Columns[2].HeaderText = "Adet/Kg";
            dataGridView1.Columns[3].HeaderText = "Sipariş tarihi";
            dataGridView1.Columns[4].HeaderText = "Tahmini Teslimat";
            dataGridView1.Columns[3].Width = 100;

            dateTimePicker1.Value = DateTime.Now;

        }
        void KayıtSil(int adet )
        {
            con = new SqlConnection(SqlCon);
            string sql = "delete from siparisler where adet_kg=@adet";
            cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@adet", adet);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            GriDoldur();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql = "delete from siparisler where verilen_siparis=@siparis and sirket_ismi=@sirket_ismi";
            cmd = new SqlCommand();
            cmd.Parameters.AddWithValue("@siparis", textBox2.Text);
            cmd.Parameters.AddWithValue("@sirket_ismi",textBox4.Text);
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;
            cmd.ExecuteNonQuery();
            con.Close();
            GriDoldur();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
             string sql = "insert into siparisler(verilen_siparis, adet_kg, siparis_tarihi,tahmini_teslim,sirket_ismi) values ('"+textBox2.Text+"','"+textBox3.Text+"','"+dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss")+"','"+ dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss") + "','"+textBox4.Text+"')";
             cmd = new SqlCommand();
             con.Open();
             cmd.Connection = con;
             cmd.CommandText = sql;
             cmd.ExecuteNonQuery(); 
             con.Close();
             GriDoldur();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            con = new SqlConnection(SqlCon);
            string sql = "update siparisler set tahmini_teslim='"+ dateTimePicker2.Value.ToString("yyyy-MM-dd HH:mm:ss") + "' where verilen_siparis='"+ textBox2.Text +"'";
            cmd = new SqlCommand();
            con.Open();
            cmd.Connection = con;
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();
            con.Close();

            GriDoldur();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
    }
}

