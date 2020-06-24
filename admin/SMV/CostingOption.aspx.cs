using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_SMV_CostingOption : System.Web.UI.Page
{
    public string userId = "0";
    public string userName = "";
    public int optionId = 0;
    public string table = "";

    public int smvId = 0;

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
        optionId= Convert.ToInt32(Request.QueryString["Id"]);
        smvId= Convert.ToInt32(Request.QueryString["Option"]);

        if (!IsPostBack)
        {
            table = LoadCostingInfo(smvId);

            if(optionId!=0)
            {
                LoadData(optionId);
            }
        }
    }



    protected string LoadCostingInfo(int SmvId)
    {
        string infoTable = null;
        try
        {
            SmvBLL smv = new SmvBLL();
            infoTable = smv.LoadCostingOptionForUpdate(SmvId);
           
        }
        catch(Exception ex)
        {

        }
        return infoTable;
    }

    public void LoadData(int Id)
    {
        DataTable dt = null;
        SmvBLL smv = new SmvBLL();
        try
        {
            dt = smv.GetOptionInformationForUpdate(Id);
            if(dt.Rows.Count>0)
            {
                buyerTextBox.Text= Convert.ToString(dt.Rows[0]["BuyerName"]);
                sampleStageTextBox.Text = Convert.ToString(dt.Rows[0]["SampleStageName"]);
                styleTextBox.Text= Convert.ToString(dt.Rows[0]["StyleNumber"]);
                designTextBox.Text= Convert.ToString(dt.Rows[0]["DesignNumber"]);

                optionNumberTextBox.Text= Convert.ToString(dt.Rows[0]["OptionNumber"]);
                reductionTextBox.Text= Convert.ToString(dt.Rows[0]["OptionReduction"]);
                additionTextBox.Text= Convert.ToString(dt.Rows[0]["OptionAddition"]);
                descriptionTextBox.Text= Convert.ToString(dt.Rows[0]["OptionDescription"]);
                remarksTextBox.Text = Convert.ToString(dt.Rows[0]["OptionRemarks"]);
            }
        }
        catch(Exception ex)
        {

        }
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        UpdateOptionModel costingOption = new UpdateOptionModel ();
        SmvBLL smv = new SmvBLL();
        int action = 0;
        try
        {
            if (optionId > 0)
            {
                costingOption.OptionId = optionId;
                costingOption.OptionNumber = optionNumberTextBox.Text;
                costingOption.OptionReduction = reductionTextBox.Text;
                costingOption.OptionAddition = additionTextBox.Text;
                costingOption.OptionDescription = descriptionTextBox.Text;
                costingOption.OptionRemarks = remarksTextBox.Text;

                action = smv.UpdateCostingOption(costingOption);
                if(action>0)
                {
                    massageSpan.InnerText = "Costing Option has Been Updated";
                    table = LoadCostingInfo(smvId);
                    Clear();
                    //Response.Redirect("CostingOption.aspx");
                }
                else
                {
                    massageSpan.InnerText = "Faield";
                }

            }
            else
            {
                massageSpan.InnerText = "This Data Not Found In Our Store";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }

        
    }

    protected void Clear()
    {
        optionNumberTextBox.Text="";
        reductionTextBox.Text="";
        additionTextBox.Text="";
        descriptionTextBox.Text="";
        remarksTextBox.Text="";
        buyerTextBox.Text = "";
        styleTextBox.Text = "";
        designTextBox.Text = "";
        sampleStageTextBox.Text = "";
    }
}