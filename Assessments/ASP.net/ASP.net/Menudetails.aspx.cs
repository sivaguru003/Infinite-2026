using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FoodOrderManagement
{
    public partial class MenuDetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(
            ConfigurationManager.ConnectionStrings["FoodDB"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter(
                "SELECT * FROM MenuFood WHERE MenuId=" +
                Request.QueryString["MenuId"], con);

            DataTable dt = new DataTable();

            da.Fill(dt);

            DetailsView1.DataSource = dt;
            DetailsView1.DataBind();

            con.Close();
        }
    }
}