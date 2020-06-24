using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Reports_BulkSmvReport : System.Web.UI.Page
{
    public string userId = "0";
    public string userName = "";

    public int buyer = 0;
    public string style = "";
    public string bulkTable = "";
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
            Response.Redirect("~/admin/Default.aspx");
            Response.End();
        }

        if(!IsPostBack)
        {
            LoadBuyerName();
            table = LoadBulkSmvReport(buyer, style);
        }
        table = LoadBulkSmvReport(buyer, style);
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


    public string LoadBulkSmvReport(int buyerId, string styleNumber)
    {
        BulkSmvBLL bulkBll = new BulkSmvBLL();
        try
        {
            bulkTable = bulkBll.LoadBulkSmvReports(buyerId, styleNumber);
        }
        catch(Exception ex)
        {

        }
        return bulkTable;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        buyer = Convert.ToInt32(buyerDropDownList.SelectedValue);
        //style = Convert.ToInt32(styleHiddenField.Value);
        style = styleNumberTextBox.Text;
        table = LoadBulkSmvReport(buyer, style);
    }

    protected void exlbutton_Click(object sender, EventArgs e)
    {
        DataTable dt = null;

        StringBuilder tableRow = new StringBuilder();
        style = styleNumberTextBox.Text;
        buyer = Convert.ToInt32(buyerDropDownList.SelectedValue);
        LoadBulkSmvReport(buyer, style);
        tableRow.Append("<table class='table table-bordered' id='tableLoad'>" + LoadBulkSmvReport(buyer, style) + "</table>");


        // string output = LoadNewMarchentLive(formDate,toDate);
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Bulk_Smv_Report.xls");
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
        BulkSmvGateway bulkEntryGateway = new BulkSmvGateway();
        DataList = bulkEntryGateway.Get_SuggestionForStyleNumberforBulk(keyword);

        return DataList;
    }
}