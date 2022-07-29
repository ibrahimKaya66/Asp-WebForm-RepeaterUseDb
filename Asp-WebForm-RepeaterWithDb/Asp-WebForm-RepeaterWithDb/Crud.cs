using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace Asp_WebForm_RepeaterWithDb
{
    public class Crud
    {
        public static SqlConnection conn;
        private static SqlCommand cmd;
        private static SqlDataReader dr;
        public static DataTable ListSearch(string sql)
        {
            DataTable dt = new DataTable();
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["db"].ConnectionString);
            conn.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(sql,conn);
            adapter.Fill(dt);
            conn.Close();
            conn.Dispose();
            return dt;
        }
        public static void GetDb(TextBox firstname, TextBox lastname, TextBox city, TextBox salary,string sql)
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["db"].ConnectionString);
            conn.Open();
            cmd = new SqlCommand(sql, conn);
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                firstname.Text = dr[1].ToString();
                lastname.Text = dr[2].ToString();
                city.Text = dr[3].ToString();
                salary.Text = dr[4].ToString();
            }

            dr.Close();
            conn.Close();
            cmd.Dispose();
            conn.Dispose();
        }
        public static void AddDeleteUpdate(SqlCommand cmd, string sql)
        {
            conn = new SqlConnection(WebConfigurationManager.ConnectionStrings["db"].ConnectionString);
            conn.Open();
            cmd.CommandText = sql;
            cmd.Connection = conn;
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            conn.Close();
            conn.Dispose();
        }
    }
}