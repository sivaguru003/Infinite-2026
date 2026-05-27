using System;

namespace FoodOrderManagement
{
    public partial class OrderStats : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblVisitors.Text =
                Application["TotalUsers"].ToString();

            lblUsers.Text =
                Application["ActiveUsers"].ToString();
        }
    }
}