using System;

namespace FoodOrderManagement
{
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "admin" && txtPass.Text == "food@123")
            {
                Session["Username"] = txtUser.Text;
                Response.Redirect("MenuList.aspx");
            }
            else
            {
                lblMsg.Text = "Invalid login";
            }
        }
    }
}