using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LandingPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }


    protected void adminButton_Click(object sender, EventArgs e)
    {
        
        Response.Redirect("admin/Default.aspx", false);
    }

    protected void merchantButton_Click(object sender, EventArgs e)
    {

        Response.Redirect("Merchant/login.aspx", false);
    }
}