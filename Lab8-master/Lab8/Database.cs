using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8
{
    class Database
    {
        public SqlConnection sqlConn;
        SqlDataAdapter da;
        DataSet ds;

        public string srvName = "latitube-7410\\NVTINES";
        public string dbName = "QLTHUVIEN"; 

        public Database()
        {
            string strConn = "Data source=" + srvName + ";database=" + dbName + ";Integrated Security = True";
            sqlConn = new SqlConnection(strConn);
        }

        public  DataTable Execute(string sqlStr)
        {
            da = new SqlDataAdapter(sqlStr, sqlConn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }
        public void ExecuteNonQuery_CU(string sqlStr, DateTime ngay)
        {
            SqlCommand sqlcmd = new SqlCommand(sqlStr, sqlConn);
            sqlcmd.Parameters.Add("@Ngay", SqlDbType.DateTime).Value = ngay;
            sqlConn.Open();
            sqlcmd.ExecuteNonQuery();
            sqlConn.Close();
        }
        public void ExecuteNonQuery(string sqlStr)
        {
            SqlCommand sqlcmd = new SqlCommand(sqlStr, sqlConn);
            sqlConn.Open(); 
            sqlcmd.ExecuteNonQuery();
            sqlConn.Close(); 
        }
    }
}
