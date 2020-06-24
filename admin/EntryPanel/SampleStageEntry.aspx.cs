using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_EntryPanel_SampleStageEntry : System.Web.UI.Page
{

    public string userId = "0";
    public string userName = "";
    public string table = "";
    public int actionResult = 0;
    public int loadSampleId = 0;
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

        loadSampleId = Convert.ToInt32(Request.QueryString["Id"]);

        if (!IsPostBack)
        {
            table = loadSampleStage();
            LoadBuyerName();
            if (loadSampleId != 0)
            {
                LoadFoeUpdate(loadSampleId);
            }
        }
        else
        {
            table = loadSampleStage();
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        SampleStage sample = new SampleStage();
        SampleStageBLL sampleBll = new SampleStageBLL();
        DataTable dt = new DataTable();
        try
        {
            sample.SampleStageName = sampleStageTextBox.Text;
            sample.BuyerId = Convert.ToInt32(buyerNameDropDownList.SelectedValue);
            sample.IsActive = Convert.ToInt32(isAcctiveDropDownList.SelectedValue);

            if(loadSampleId==0)
            {
                sample.PostedBy= Convert.ToInt32(userId);
                sample.UpdatedBy = 0;
                dt= sampleBll.InsertSampleStage(sample);

                if (dt.Rows.Count > 0)
                {
                    bool buyerName = Convert.ToBoolean(dt.Rows[0]["dBuyerName"]);
                    bool sampleStage= Convert.ToBoolean(dt.Rows[0]["dSampleStage"]);

                    if (buyerName && sampleStage)
                    {
                        messageLabel.Text = "<p Style ='font-size:20px;color:Red; margin-top:20px;'>(" + sample.SampleStageName + ") Already Exists For This Buyer</p>";
                    }
                    else
                    {
                        messageLabel.Text = "<p Style ='font-size:20px;color:Green; margin-top:20px;'>New Sample Stage : " + sample.SampleStageName + " Created </p>";
                        sampleStageTextBox.Text = "";
                        buyerNameDropDownList.SelectedValue = "0";
                        isAcctiveDropDownList.SelectedValue = "0";
                    }
                }


            }

            else
            {
                sample.UpdatedBy= Convert.ToInt32(userId);
                sample.SampleStageId = loadSampleId;
                actionResult = sampleBll.UpdateSampleStageInfo(sample);

                if (actionResult == 1)
                {
                    messageLabel.Text = "<p Style ='font-size:20px;color:Green; margin-top:20px;'>Updated has been successfully complete...</p>";
                }
                else
                {
                    messageLabel.Text = "<p Style ='font-size:20px;color:Red; margin-top:20px;'>Already Exists</p>";
                }
            }
            table = loadSampleStage();

            
        }
        catch (Exception ex)
        {

        }
    }

    public string loadSampleStage()
    {
        string tableRow = "";
        try
        {
            tableRow = new SampleStageBLL().LoadsampleStage();
        }
        catch (Exception ex)
        {

        }
        return tableRow.ToString();
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
                buyerNameDropDownList.DataSource = dt;
                buyerNameDropDownList.DataValueField = "BuyerId";
                buyerNameDropDownList.DataTextField = "BuyerName";
                buyerNameDropDownList.DataBind();
                buyerNameDropDownList.Items.Insert(0, new ListItem("Please Select", "0"));
            }
        }
        catch (Exception ex)
        {

        }

        return dt;
    }

    public void LoadFoeUpdate(int buyerId)
    {
        DataTable dt = null;
        try
        {
            using (SampleStageGateway sampleGateway = new SampleStageGateway())
            {
                dt = sampleGateway.LoadDataForUpdate(loadSampleId);
                if (dt.Rows.Count > 0)
                {
                    buyerNameDropDownList.SelectedValue= Convert.ToString(dt.Rows[0]["BuyerId"]);
                    sampleStageTextBox.Text = Convert.ToString(dt.Rows[0]["SampleStageName"]);
                    isActiveHiddenField.Value = Convert.ToString(dt.Rows[0]["IsActive"]);                    
                    isAcctiveDropDownList.SelectedValue = Convert.ToString(isActiveHiddenField.Value);
                    
                }
            }
        }
        catch (Exception ex)
        {

        }
    }
}