using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace CrawlingDecInfoCMD
{
    class DBHelper
    {
        SqlConnection con = new SqlConnection("Server=HXABC\\SQLEXPRESS;Database=FHASGAMESHOP;Trusted_Connection=True;uid=sa;password=nyz12345");
        SqlCommand cmd;
        
        public void InsertData(List<Hashtable> hashtable)
        {
            foreach (var item in hashtable)
            {
                con.Open();
                var sqlKey = "";
                var sqlValue = "";
                var test = item["DecName_CN"].ToString();
                foreach (var key in item.Keys)
                {
                    sqlKey += key.ToString() + ",";
                    sqlValue += "'" + item[key] + "'" + ",";
                }
                var sqlStr = "insert into FHASGAMESHOP.dbo.BaseDec_CSGOs ("
                    + sqlKey.Substring(0, sqlKey.Length - 1)
                    +") values ("
                    + sqlValue.Substring(0, sqlValue.Length - 1)
                    +")";
                cmd = new SqlCommand(sqlStr, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
