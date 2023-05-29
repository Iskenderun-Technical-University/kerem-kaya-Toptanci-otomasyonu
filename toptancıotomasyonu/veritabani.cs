using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace den
{
    class veritabani
    {
       static  SqlConnection con;
       static SqlDataAdapter da;
       static  SqlCommand cmd;
       static DataSet ds;
        public static String SqlCon = "Data Source=DESKTOP-TK2GC17\\SQLEXPRESS;Initial Catalog=toptanci;Integrated Security=True";

        public static bool baglantiDurum()
        {
            using (con = new SqlConnection(SqlCon))
                try
                {
                    con.Open();
                    return true;
                }
                catch(SqlException ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                    return false;
                }
            
        }


    }
}
