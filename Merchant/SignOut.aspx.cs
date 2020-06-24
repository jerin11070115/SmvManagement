using System;

public partial class Merchant_SignOut : System.Web.UI.Page
{
    public string merchantId = "0";
    public string merchantLogin = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GenarateSessionThroughtCoockie checkSession = new GenarateSessionThroughtCoockie();

        bool hasSession = checkSession.SessionCheck(2);

        if (hasSession)
        {
            merchantId = Session["KP_Merchant_Id"].ToString();
            merchantLogin = Session["KP_Merchant_LoginId"].ToString();
            SignOut();
        }
        else
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
    }


    public void SignOut()
    {
        if (merchantId != "" || merchantId != null)
        {
            this.Session.Remove(Session["KP_Merchant_Id"].ToString());
            this.Session.Remove(Session["KP_Merchant_LoginId"].ToString());
            this.Session.Clear();           
            Response.Redirect("login.aspx", false);
        }


    }
}