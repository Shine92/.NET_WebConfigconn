using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Data;

namespace test0913_test02 {
    public partial class Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            string connString = WebConfigurationManager.ConnectionStrings["testConnectionString"].ConnectionString;
            SqlConnection cn = new SqlConnection(connString);
            cn.Open();
            string cmdText = "select * from Products";
            SqlCommand cmd = new SqlCommand(cmdText, cn);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read()) {
                Response.Write(dr["ProductName"]);
            }
            cmd.Cancel();
            dr.Close();

            if(cn.State == ConnectionState.Open) {
                cn.Close();
                cn.Dispose();
            }
            
        }
    }
}