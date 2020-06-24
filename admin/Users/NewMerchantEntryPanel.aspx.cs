using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Users_NewMerchantEntryPanel : System.Web.UI.Page
{
    public string userId = "0";
    public string userName = "";
    public int merchantId=0;
    public string table = "";
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

            Response.Redirect("../Default.aspx");
            Response.End();
        }
        merchantId=Convert.ToInt32(Request.QueryString["id"]);

        if (!IsPostBack)
        {
            table = GetMerchantInfo(merchantId);

            if(merchantId!=0)
            {
                LoadMerchantInfoForUpdate(merchantId);
            }
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        MerchantBLL merchantBLL = new MerchantBLL();
        MerchantModel merchant = new MerchantModel();
        DataTable dt = null;
        try
        {
            merchant.MerchantName = merchantNameTextBox.Text;
            merchant.LoginId = loginIdTextBox.Text;
            merchant.Password = paswordTextBox.Text;
            merchant.ConfirmPassword = confirmPasswordTextBox.Text;
            merchant.IsActive = Convert.ToInt32(isAcctiveDropDownList.SelectedValue);
            

            if(merchant.Password==merchant.ConfirmPassword)
            {
                if(merchantId==0)
                {
                    merchant.PostedBy = Convert.ToInt32(userId);
                    dt = merchantBLL.InsertNewMerchant(merchant);
                    if(dt.Rows.Count>0)
                    {
                        bool DbMerchant= Convert.ToBoolean(dt.Rows[0]["Merchant"]);
                        if(DbMerchant)
                        {
                            messageLabel.Text = "<p Style ='font-size:20px;color:Red; margin-top:20px;'>Already Exists</p>";

                        }
                        else
                        {
                            messageLabel.Text = "<p Style ='font-size:20px;color:Green; margin-top:20px;'>New Information Successfully Inserted</p>";
                        }
                    }
                    table = GetMerchantInfo(merchantId);
                }
                else
                {
                    merchant.UpdatedBy = Convert.ToInt32(userId);
                    merchant.MerchantId = merchantId;                    
                    int actionResult = 0;

                    actionResult = merchantBLL.UpdateMerchantInfo(merchant);

                    if(actionResult>0)
                    {
                        messageLabel.Text = "<p Style ='font-size:20px;color:Green; margin-top:20px;'> Information Successfully Updated</p>";
                        table = GetMerchantInfo(merchantId);
                    }
                    else
                    {
                        messageLabel.Text = "<p Style ='font-size:20px;color:Red; margin-top:20px;'>Already Exists</p>";
                    }
                }

            }
            else
            {
                messageLabel.Text = "<p Style ='font-size:20px;color:Red; margin-top:20px;'>Password Dose Not Match!</p>";
            }
            
        }
        catch(Exception ex)
        {

        }
    }

    protected string GetMerchantInfo(int loadMerchantId)
    {
        string merchantTable = "";
        MerchantBLL merchantBLL = new MerchantBLL();
        try
        {
            merchantTable = merchantBLL.GetMerchantInfo(loadMerchantId);
        }
        catch(Exception ex)
        {

        }
        return merchantTable;
    }

    public void LoadMerchantInfoForUpdate(int loadMerchantId)
    {
        DataTable dt = new DataTable();
        MerchantGateway merchantGateway = new MerchantGateway();
        try
        {
            if(loadMerchantId>0)
            {
                dt = merchantGateway.GetMerchantInfo(loadMerchantId);
                if(dt.Rows.Count>0)
                {
                    merchantNameTextBox.Text= Convert.ToString(dt.Rows[0]["MerchantName"]);
                    loginIdTextBox.Text = Convert.ToString(dt.Rows[0]["LogInId"]);
                    paswordTextBox.Text = Convert.ToString(dt.Rows[0]["Password"]);
                    confirmPasswordTextBox.Text= Convert.ToString(dt.Rows[0]["Password"]);
                    isAcctiveDropDownList.SelectedValue= Convert.ToString(dt.Rows[0]["IsActive"]);
                }
            }
            
        }
        catch(Exception ex)
        {

        }
    }
}