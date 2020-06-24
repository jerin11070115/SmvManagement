using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Merchant_Default : System.Web.UI.Page
{
    public string merchantId = "";
    public string merchantLogin = "";
    public string merchantName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GenarateSessionThroughtCoockie checkSession = new GenarateSessionThroughtCoockie();

        bool hasSession = checkSession.SessionCheck(2);

        if (hasSession)
        {
            merchantId = Session["KP_Merchant_Id"].ToString();
            merchantLogin = Session["KP_Merchant_LoginId"].ToString();
            merchantName= Session["KP_MerchantName"].ToString();
        }
        else
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
    }
}