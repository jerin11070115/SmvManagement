using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_SignOut : System.Web.UI.Page
{
    public string userId = "0";
    public string userName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GenarateSessionThroughtCoockie checkSession = new GenarateSessionThroughtCoockie();

        bool hasSession = checkSession.SessionCheck(1);

        if (hasSession)
        {
            userId = Session["KP_User_Id"].ToString();
            userName = Session["KP_UserName"].ToString();
            SignOut();
        }
        else

        {

            Response.Redirect("Default.aspx");
            Response.End();
        }

        
    }


    public void SignOut()
    {
        if (userId != "" || userId != null)
        {
            this.Session.Remove(Session["KP_User_Id"].ToString());
           this.Session.Remove(Session["KP_UserName"].ToString());
            this.Session.Clear();
            Response.Redirect("Default.aspx",false);
        }


    }
}