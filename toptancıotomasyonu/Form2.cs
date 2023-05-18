using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace den
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            frm1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String admingirisi = "sa123";
            String adminsifre = "123456";
            if(textBox1.Text== admingirisi && textBox2.Text==adminsifre)
            {
                Form5 form5 = new Form5();
                form5.Show();
                this.Hide();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Admin adı veya şifre yanlış");
            }
        }
    }
}
