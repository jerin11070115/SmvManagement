using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Request_SmvRequestPanel : System.Web.UI.Page
{
    public string table = "";
    public int buyerId = 0;
    public string styleNumber = "0";
    
    public int requestId = 0;
    

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
        }
        else

        {
            Response.Redirect("~/admin/Default.aspx");
            Response.End();
        }

        
        if(!IsPostBack)
        {
            table = LoadMerchantRequest(Convert.ToInt32(userId));
        }
    }
    public string LoadMerchantRequest(int userId)
    {
        string InfoTable = "";
        MerchantBLL merchantBll = new MerchantBLL();
        try
        {
            InfoTable = merchantBll.LoadMerchantRequest(userId);
            return InfoTable;
        }
        catch(Exception ex)
        {
            throw ex;
        }
        
    }
}