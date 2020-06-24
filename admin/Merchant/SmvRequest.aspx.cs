using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Services;
using System.Web.UI.WebControls;

public partial class Merchant_SmvRequest : System.Web.UI.Page
{
    public string merchantId = "";
    public string merchantLogin = "";
    public int buyerId = 0;
    public int requestId = 0;
    public string pdfFileName = String.Empty;
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
            LoadBuyerName();
            LoadFabricType();
            LoadProductCategory();
            LoadUser();
            table = LoadPendingMerchantRequest(Convert.ToInt32(merchantId));
        }

    }



    protected void sendButton_Click(object sender, EventArgs e)
    {
        MerchantSmvRequestModel merchantSmvRequestModel = new MerchantSmvRequestModel();
        MerchantSmvRequestBLL merchantSmvRequestBLL = new MerchantSmvRequestBLL();
        DataTable dt = new DataTable();
        try
        {
            
            int value= 0;
            merchantSmvRequestModel.BuyerId = Convert.ToInt32(buyerDropDownList.SelectedValue);
            value = Convert.ToInt32(sampleStageHiddenField.Value);
            merchantSmvRequestModel.SampleStageId = value;
            merchantSmvRequestModel.StyleNumber = styleNumberTextBox.Text;
            merchantSmvRequestModel.FabricId = Convert.ToInt32(fabricDropDownList.SelectedValue);
            merchantSmvRequestModel.ProductCategoryId = Convert.ToInt32(productDropDownList.SelectedValue);
            merchantSmvRequestModel.ApproxOrderQtn = Convert.ToInt32(quantityTextBox.Text);
            merchantSmvRequestModel.CostingDeadLine = costingDeadLineTextBox.Text;
            merchantSmvRequestModel.Comments = commentsTextBox.Text;
            merchantSmvRequestModel.SendToUserId = Convert.ToInt32(sendToDropDownList.SelectedValue);
            merchantSmvRequestModel.MerchantId = Convert.ToInt32(merchantId);
            merchantSmvRequestModel.IsActive = 1;
            merchantSmvRequestModel.PreviousSampleStage = 0;
            merchantSmvRequestModel.DesignNumber = DesignNumberTextBox.Text;
            merchantSmvRequestModel.IsOption = Convert.ToInt32(optionDropDownList.SelectedValue);

            pdfFileName =merchantSmvRequestModel.MerchantId.ToString()
                        + merchantSmvRequestModel.BuyerId.ToString() 
                        + merchantSmvRequestModel.SampleStageId.ToString()                         
                        + merchantSmvRequestModel.FabricId.ToString() 
                        + merchantSmvRequestModel.ProductCategoryId.ToString()
                        + merchantSmvRequestModel.StyleNumber.ToString()
                        +"_"+ merchantSmvRequestModel.DesignNumber.ToString()
                        + merchantSmvRequestModel.SendToUserId.ToString();

            
            if (requestId==0)
            {
                merchantSmvRequestModel.PostedBy= Convert.ToInt32(merchantId);
                merchantSmvRequestModel.UpdatedBy = 0;
                dt=merchantSmvRequestBLL.InsertMerchantSmvRequest(merchantSmvRequestModel);

                if(dt.Rows.Count>0)
                {
                    bool success = Convert.ToBoolean(dt.Rows[0]["Success"]);
                    if(success)
                    {
                        messageLabel.Text = "<p Style ='font-size:20px;color:Red; margin-top:20px;'>Already Exists</p>";
                    }
                    else
                    {
                        messageLabel.Text = "<p Style ='font-size:20px;color:Red; margin-top:20px;'>SMV Information Successfully Sended</p>";
                        PdfFileUpload(pdfFileName);
                        ClearData();
                        table = LoadPendingMerchantRequest(Convert.ToInt32(merchantId));
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
            if(pdfFileUpload.HasFile)
            {
                pdfFileUpload.PostedFile.SaveAs(Server.MapPath("~/Files/Request/") + fileName + ".pdf");
                //pdfFileUpload.PostedFile.SaveAs(Server.MapPath("~/Files/Request/") + fileName + ".msg");
            }

            if(mailFileUpload.HasFile)
            {
                mailFileUpload.PostedFile.SaveAs(Server.MapPath("~/Files/Request/Mail/") + fileName + ".msg");
            }
        }
        catch(Exception ex)
        {

        }
    }



    public DataTable LoadBuyerName()
    {
        DataTable dt = null;
        try
        {
            SampleStageBLL sampleBLL = new SampleStageBLL();
            dt = sampleBLL.LoadBuyerName();
            if (dt.Rows.Count > 0)
            {
                buyerDropDownList.DataSource = dt;
                buyerDropDownList.DataValueField = "BuyerId";
                buyerDropDownList.DataTextField = "BuyerName";
                buyerDropDownList.DataBind();
                buyerDropDownList.Items.Insert(0, new ListItem("Please Select Buyer", "0"));
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    [WebMethod]
    public static SampleStage[] LoadSampleStage(int buyerId)
    {
        DataTable dt = new DataTable();
        List<SampleStage> sampleStage = new List<SampleStage>();
        try
        {


            using (SmvEntryGateway smvGateway = new SmvEntryGateway())
            {

                dt = smvGateway.LoadBuyerWiseSampleStage(buyerId);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dtr in dt.Rows)
                    {
                        SampleStage sample = new SampleStage();
                        sample.SampleStageId = Convert.ToInt32(dtr["SampleStageId"].ToString());
                        sample.SampleStageName = dtr["SampleStageName"].ToString();
                        sampleStage.Add(sample);
                    }
                }

            }
        }
        catch (Exception Ex)
        {

        }
        return sampleStage.ToArray();
    }

    public DataTable LoadFabricType()
    {
        DataTable dt = null;
        try
        {
            SmvBLL smvBLL = new SmvBLL();
            dt = smvBLL.LoadFabricType();

            if (dt.Rows.Count > 0)
            {
                fabricDropDownList.DataSource = dt;
                fabricDropDownList.DataValueField = "FabricId";
                fabricDropDownList.DataTextField = "FabricType";
                fabricDropDownList.DataBind();
                fabricDropDownList.Items.Insert(0, new ListItem("Please Select Fabric Type", "0"));

            }

        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable LoadProductCategory()
    {
        DataTable dt = null;
        try
        {
            SmvBLL smvBLL = new SmvBLL();
            dt = smvBLL.LoadProductCategory();
            if (dt.Rows.Count > 0)
            {
                productDropDownList.DataSource = dt;
                productDropDownList.DataValueField = "ProductId";
                productDropDownList.DataTextField = "ProductName";
                productDropDownList.DataBind();
                productDropDownList.Items.Insert(0, new ListItem("Please Select Product Category", "0"));
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable LoadUser()
    {
        DataTable dt = null;
        try
        {
            SmvEntryGateway smvGateway = new SmvEntryGateway();
            dt = smvGateway.LoadUserName();

            if (dt.Rows.Count > 0)
            {
                sendToDropDownList.DataSource = dt;
                sendToDropDownList.DataValueField = "UserId";
                sendToDropDownList.DataTextField = "FullName";
                sendToDropDownList.DataBind();
                sendToDropDownList.Items.Insert(0, new ListItem("Send To", "0"));            
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public void ClearData()
    {
        buyerDropDownList.SelectedValue = "0";
        sampleStageHiddenField.Value = "0";
        styleNumberTextBox.Text = "";
        DesignNumberTextBox.Text = "";
        productDropDownList.SelectedValue = "0";
        fabricDropDownList.SelectedValue = "0";
        commentsTextBox.Text = "";
        quantityTextBox.Text = "";
        costingDeadLineTextBox.Text = "";
        sendToDropDownList.SelectedValue = "0";
    }

    public string LoadPendingMerchantRequest(int MerchantId)
    {
        string InfoTable = "";
        MerchantSmvRequestBLL merchantBll = new MerchantSmvRequestBLL();
        try
        {
            InfoTable = merchantBll.LoadPendingMerchantRequest(MerchantId);
            return InfoTable;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }
}