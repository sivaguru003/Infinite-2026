using System;
using System.Configuration;
using System.Data.SqlClient;

namespace FoodOrderManagement
{
    public partial class EditMenu : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Request.QueryString["MenuId"] != null)
                LoadData();
        }

        void LoadData()
        {
            SqlConnection con = new SqlConnection(connStr);
            SqlCommand cmd = new SqlCommand("select * from menufood where menuid=@id", con);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["MenuId"]);
            con.Open();

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtName.Text = dr["itemname"].ToString();
                txtCategory.Text = dr["category"].ToString();
                txtPrice.Text = dr["price"].ToString();
                txtQty.Text = dr["availablequantity"].ToString();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connStr);

            string query = "update menufood set itemname=@n,category=@c,foodtype=@t,price=@p,availablequantity=@q where menuid=@id";

            SqlCommand cmd = new SqlCommand(query, con);

            cmd.Parameters.AddWithValue("@n", txtName.Text);
            cmd.Parameters.AddWithValue("@c", txtCategory.Text);
            cmd.Parameters.AddWithValue("@t", ddlType.Text);
            cmd.Parameters.AddWithValue("@p", txtPrice.Text);
            cmd.Parameters.AddWithValue("@q", txtQty.Text);
            cmd.Parameters.AddWithValue("@id", Request.QueryString["MenuId"]);

            con.Open();
            cmd.ExecuteNonQuery();

            Response.Redirect("MenuList.aspx");
        }
    }
}

