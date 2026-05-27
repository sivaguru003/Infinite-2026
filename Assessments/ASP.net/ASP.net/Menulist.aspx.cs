using System;
using System.Configuration;
using System.Data.SqlClient;

namespace FoodOrderManagement
{
    public partial class MenuList : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] == null)
                Response.Redirect("Login.aspx");

            if (!IsPostBack)
            {
                if (Request.QueryString["DeleteId"] != null)
                {
                    DeleteItem(Request.QueryString["DeleteId"]);
                }

                LoadData();
            }
        }

        void LoadData()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("select * from menufood", con);
                con.Open();

                GridView1.DataSource = cmd.ExecuteReader();
                GridView1.DataBind();
            }
        }

        void DeleteItem(string id)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand("delete from menufood where menuid=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
