using System;

namespace Assignment1
{
    public partial class Product : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                imgProduct.ImageUrl = "images/watch.jpg";
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (ddlProducts.SelectedValue)
            {
                case "Watch":
                    imgProduct.ImageUrl = "images/watch.jpg";
                    break;

                case "Camera":
                    imgProduct.ImageUrl = "images/camera.jpg";
                    break;

                case "Speaker":
                    imgProduct.ImageUrl = "images/speaker.jpg";
                    break;
            }
        }

        protected void btnPrice_Click(object sender, EventArgs e)
        {
            switch (ddlProducts.SelectedValue)
            {
                case "Watch":
                    lblPrice.Text = "Price : ₹5,000";
                    break;

                case "Camera":
                    lblPrice.Text = "Price : ₹45,000";
                    break;

                case "Speaker":
                    lblPrice.Text = "Price : ₹8,000";
                    break;
            }
        }
    }
}