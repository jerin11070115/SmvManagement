using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_EntryPanel_BuyerEntry : System.Web.UI.Page
{
    public string table = "";
    public string userId = "0";
    public string userName = "";
    public int LoadBuyerId = 0;
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

        LoadBuyerId = Convert.ToInt32(Request.QueryString["Id"]);
        if (!IsPostBack)
        {
            table = LoadBuyerInfo();
            if(LoadBuyerId!=0)
            {
                LoadFoeUpdate(LoadBuyerId);
            }
        }
    }



    protected void submitButton_Click(object sender, EventArgs e)
    {
        Buyers buyer = new Buyers();
        BuyerEntryBLL buyerEnteyBll = new BuyerEntryBLL();
        DataTable dt = new DataTable();
        try
        {
            buyer.BuyerName = buyerTextBox.Text;
            buyer.IsActive = Convert.ToInt32(IsActiveDropDownList.SelectedValue);
            if(LoadBuyerId==0)
            {
                buyer.PostedBy = Convert.ToInt32(userId);
                buyer.UpdatedBy = 0;
                dt = buyerEnteyBll.InsertBuyer(buyer);
                if (dt.Rows.Count > 0)
                {
                    bool buyerName = Convert.ToBoolean(dt.Rows[0]["dBuyerName"]);

                    if (buyerName)
                    {
                        messageLabel.Text = "<p Style ='font-size:20px;color:Red; margin-top:20px;'>(" + buyer.BuyerName + ") Already Exists</p>";
                        buyerTextBox.Text = "";
                    }
                    else
                    {
                        messageLabel.Text = "<p Style ='font-size:20px;color:Green; margin-top:20px;'>New Buyer Name : " + buyer.BuyerName + " Created</p>";
                    }
                }
            }
            else
            {
                int actionResult = 0;
                buyer.UpdatedBy= Convert.ToInt32(userId);
                buyer.BuyerId = LoadBuyerId;

                actionResult = buyerEnteyBll.UpdateBuyerInfo(buyer);

                if(actionResult==1)
                {
                    messageLabel.Text = "<p Style ='font-size:20px;color:Green; margin-top:20px;'>Updated has been successfully complete...</p>";
                }
                else
                {
                    messageLabel.Text = "<p Style ='font-size:20px;color:Red; margin-top:20px;'>Already Exists</p>";
                }
            }
            table = LoadBuyerInfo();

        }
        catch (Exception ex)
        {

        }
    }


    public string LoadBuyerInfo()
    {
        string tableRow = "";
        try
        {
            BuyerEntryBLL buyerEntry = new BuyerEntryBLL();
            tableRow = buyerEntry.LoadBuyerInfo();
        }
        catch (Exception ex)
        {

        }
        return tableRow.ToString();
    }

    public void LoadFoeUpdate(int buyerId)
    {
        DataTable dt = null;
        try
        {
            using (BuyerGateway buyerGateway = new BuyerGateway())
            {
                dt = buyerGateway.LoadForUpdate(buyerId);
                if(dt.Rows.Count>0)
                {
                    buyerTextBox.Text= Convert.ToString(dt.Rows[0]["BuyerName"]);
                    isActiveHiddenField.Value= Convert.ToString(dt.Rows[0]["IsActive"]);
                    //string value = isActiveHiddenField.Value;
                    IsActiveDropDownList.SelectedValue = Convert.ToString(isActiveHiddenField.Value);
                    //IsActiveDropDownList.SelectedValue= Convert.ToString(dt.Rows[0]["IsActive"]);
                }
            }
        }
        catch(Exception ex)
        {

        }
    }
}