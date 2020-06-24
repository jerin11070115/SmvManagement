using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Reports_CostingSmvDetailsReport : System.Web.UI.Page
{

    public string styleNumber = "";
    public int buyerId = 0;
    public string smvtable = null;
    public string table = "";

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

        if (!IsPostBack)
        {
            //table = loadCostingSmvinformation(buyerId, styleNumber);
            LoadBuyerName();
        }
        //table = loadCostingSmvinformation(buyerId, styleNumber);
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



    public string loadCostingSmvinformation(int BuyerId, string StyleNumber)
    {
        SmvBLL smvBll = new SmvBLL();


        //buyerId = Convert.ToInt32(seatchDropDownList.SelectedValue);

        try
        {
            smvtable = smvBll.DetailsCostingSmvInfo(BuyerId, StyleNumber);
            return smvtable;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        styleNumber = styleNumberTextBox.Text;
        buyerId = Convert.ToInt32(buyerDropDownList.SelectedValue);
        table = loadCostingSmvinformation(buyerId, styleNumber);
    }

    protected void exlbutton_Click(object sender, EventArgs e)
    {
        DataTable dt = null;

        StringBuilder tableRow = new StringBuilder();
        styleNumber = Convert.ToString(styleNumberTextBox.Text);
        buyerId = Convert.ToInt32(buyerDropDownList.SelectedValue);
        loadCostingSmvinformation(buyerId, styleNumber);
        tableRow.Append("<table class='table table-bordered' id='tableLoad'>" + loadCostingSmvinformation(buyerId, styleNumber) + "</table>");


        // string output = LoadNewMarchentLive(formDate,toDate);
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Costing_Smv_Details_Report.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        Response.Output.Write(tableRow.ToString());
        Response.Flush();
        Response.End();
    }

    [WebMethod]
    public static List<Tuple<string>> Load_SuggestionForStyleNumber(string keyword)
    {
        List<Tuple<string>> DataList = new List<Tuple<string>>();
        SmvEntryGateway smvEntryGateway = new SmvEntryGateway();
        DataList = smvEntryGateway.Get_SuggestionForStyleNumber(keyword);

        return DataList;
    }

}