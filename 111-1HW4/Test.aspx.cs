using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;

namespace _111_1HW4
{
    public partial class Test : System.Web.UI.Page
    {
        SqlConnection sconn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["SQLname"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                sconn.Open();
                SqlDataAdapter o_A = new SqlDataAdapter("SELECT * FROM Users", sconn);
                DataSet o_Set = new DataSet();
                o_A.Fill(o_Set, "hello");
                gd_View.DataSource = o_Set;
                gd_View.DataBind();
                sconn.Close();                
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        protected void btn_Insert_Click(object sender, EventArgs e)
        {
            try
            {
                sconn.Open();
                // 新增資料
                SqlCommand scom = new SqlCommand("INSERT INTO Users (Name, Birthday)" + " VALUES(N'阿貓阿狗', '2000/10/10');", sconn);
                scom.ExecuteNonQuery();
                sconn.Close();
                // 立即顯示
                Page_Load(sender, e);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }
    }
}