using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Merchant_SmvReceive : System.Web.UI.Page
{
    public string merchantId = "";
    public string merchantLogin = "";

    public string table = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GenarateSessionThroughtCoockie checkSession = new GenarateSessionThroughtCoockie();

        bool hasSession = checkSession.SessionCheck(2);

        if (hasSession)
        {
            merchantId = Session["KP_Merchant_Id"].ToString();
            merchantLogin = Session["KP_Merchant_LoginId"].ToString();
        }
        else
        {
            Response.Redirect("login.aspx");
            Response.End();
        }
        if (!IsPostBack)
        {
            table = LoadPendingMerchantRequest(Convert.ToInt32(merchantId));
        }
    }

    public string LoadPendingMerchantRequest(int MerchantId)
    {
        string InfoTable = "";
        MerchantSmvRequestBLL merchantBll = new MerchantSmvRequestBLL();
        try
        {
            InfoTable = merchantBll.LoadReceivedMerchantSmvData(MerchantId);
            return InfoTable;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}