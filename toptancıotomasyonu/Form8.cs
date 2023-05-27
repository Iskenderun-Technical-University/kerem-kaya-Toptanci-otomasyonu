using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace den
{
    public partial class Form8 : Form
    {
        public Form8()
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
        private void Form8_Load(object sender, EventArgs e)
        {
            GriDoldur();
            


        }

       

       /* private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)

        {
             
             
                  listBox1.Items.Add(dataGridView1.CurrentRow.Cells[1].Value.ToString());

                  listBox2.Items.Add(dataGridView1.CurrentRow.Cells[3].Value.ToString());
                double toplam = 0;
                for (int i = 0; i < listBox2.Items.Count; i++)
                {
                    toplam += Convert.ToDouble(listBox2.Items[i]);
                }
                label3.Text = toplam+ "TL";
            

        }
       */
        private void button1_Click(object sender, EventArgs e)
        {
            Form9 form9 = new Form9();
            form9.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Siparişiniz alınmıştır.");
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            listBox1.Items.Add(dataGridView1.CurrentRow.Cells[1].Value.ToString());

            listBox2.Items.Add(dataGridView1.CurrentRow.Cells[3].Value.ToString());
            double toplam = 0;
            for (int i = 0; i < listBox2.Items.Count; i++)
            {
                toplam += Convert.ToDouble(listBox2.Items[i]);
            }
            label3.Text = toplam + "TL";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.Show();
            this.Hide();
        }
    }
}
