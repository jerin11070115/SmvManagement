using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Reports_BulkStyleReports : System.Web.UI.Page
{
    public string userId = "0";
    public string userName = "";

    public string fromDate = "";
    public string toDate = "";


    public string BulkTable = "";
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
            BulkTable = LoadBuyersStyleInfoFromBulk(fromDate, toDate);
        }

    }

    protected void searchButton_Click(object sender, EventArgs e)
    {

        fromDate = fromDateTextBox.Text;
        toDate = toDateTextBox.Text;
        BulkTable= LoadBuyersStyleInfoFromBulk(fromDate, toDate);

    }



    protected string LoadBuyersStyleInfoFromBulk(string fromDate, string toDate)
    {
        string table = "";
        try
        {
            table = new BulkSmvBLL().LoadBuyersStyleInfoFromBulk(fromDate, toDate);
        }
        catch (Exception ex)
        {

        }
        return table;
    }

    protected void exlButton_Click(object sender, EventArgs e)
    {
        DataTable dt = null;

        StringBuilder tableRow = new StringBuilder();

        fromDate = fromDateTextBox.Text;
        toDate = toDateTextBox.Text;
        LoadBuyersStyleInfoFromBulk(fromDate, toDate);

        tableRow.Append("<table class='table table-bordered' id='tableLoad'>" + LoadBuyersStyleInfoFromBulk(fromDate, toDate) + "</table>");

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Buyers_Style_Info.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        Response.Output.Write(tableRow.ToString());
        Response.Flush();
        Response.End();
    }
}