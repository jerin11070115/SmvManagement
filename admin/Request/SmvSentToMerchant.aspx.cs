using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Request_SmvSentToMerchant : System.Web.UI.Page
{
    public string table = "";
    public int buyerId = 0;
    public string styleNumber = "0";

    public int RequestId = 0;


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
        RequestId = Convert.ToInt32(Request.QueryString["RequestId"]);

    }



    protected void sendButton_Click(object sender, EventArgs e)
    {
        MerchantSmvRequestModel merchantSmvRequestModel = new MerchantSmvRequestModel();
        MerchantGateway merchantGateway = new MerchantGateway();
        DataTable dt = new DataTable();
        int actionResult = 0;
        string pdfFileName = String.Empty;
        try
        {
            if(RequestId>0)
            {
                dt = merchantGateway.LoadMerchantRequestInfoRequestIdWise(RequestId);
                if(dt.Rows.Count>0)
                {
                    merchantSmvRequestModel.SmvRequestId = RequestId;
                    merchantSmvRequestModel.MerchantId = Convert.ToInt32(dt.Rows[0]["MerchantId"]);
                    merchantSmvRequestModel.BuyerId= Convert.ToInt32(dt.Rows[0]["BuyerId"]);
                    merchantSmvRequestModel.SampleStageId = Convert.ToInt32(dt.Rows[0]["SampleStageId"]);
                    merchantSmvRequestModel.StyleNumber = dt.Rows[0]["StyleNumber"].ToString();
                    merchantSmvRequestModel.DesignNumber= dt.Rows[0]["DesignNumber"].ToString();
                    merchantSmvRequestModel.ProductCategoryId= Convert.ToInt32(dt.Rows[0]["ProductId"]);
                    merchantSmvRequestModel.FabricId = Convert.ToInt32(dt.Rows[0]["FabricId"]);
                    merchantSmvRequestModel.SendToUserId= Convert.ToInt32(dt.Rows[0]["SendToUserId"]);

                    pdfFileName = merchantSmvRequestModel.MerchantId.ToString()
                        + merchantSmvRequestModel.BuyerId.ToString()
                        + merchantSmvRequestModel.SampleStageId.ToString()
                        + merchantSmvRequestModel.FabricId.ToString()
                        + merchantSmvRequestModel.ProductCategoryId.ToString()
                        + merchantSmvRequestModel.StyleNumber.ToString()
                        + "_" + merchantSmvRequestModel.DesignNumber.ToString()
                        + merchantSmvRequestModel.SendToUserId.ToString();

                    actionResult = merchantGateway.UpdateMerchantRequest(merchantSmvRequestModel.SmvRequestId);
                    if(actionResult>0)
                    {
                        PdfFileUpload(pdfFileName);
                    }
                    
                }
                
            }
        }
        catch(Exception ex)
        {

        }
    }

    public void PdfFileUpload(string fileName)
    {

        try
        {
            if (pdfFileUpload.HasFile)
            {
                pdfFileUpload.PostedFile.SaveAs(Server.MapPath("~/Files/Received/") + fileName + ".pdf");
            }

            if (mailFileUpload.HasFile)
            {
                mailFileUpload.PostedFile.SaveAs(Server.MapPath("~/Files/Received/Mail/") + fileName + ".msg");
            }
        }
        catch (Exception ex)
        {

        }
    }
}