using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Users_KpiReport : System.Web.UI.Page
{
    public string userId = "0";
    public string userName = "";

    public string fromDate = "";
    public string toDate = "";
    public string KpiTable = "";
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

        if (!IsPostBack)
        {
            KpiTable=LoadKpiReport(fromDate, toDate);
        }
    }

    protected string LoadKpiReport(string FromDate,string Todate)
    {
        string table = "";
        try
        {
            table = new AllUsersSummaryBLL().GetKpiReport(fromDate, toDate);
        }
        catch(Exception ex)
        {

        }
        return table;
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        fromDate = fromDateTextBox.Text;
        toDate = toDateTextBox.Text;

        KpiTable = LoadKpiReport(fromDate, toDate);

    }

    protected void excelButton_Click(object sender, EventArgs e)
    {
        DataTable dt = null;

        StringBuilder tableRow = new StringBuilder();
        fromDate = fromDateTextBox.Text;
        toDate = toDateTextBox.Text;
        LoadKpiReport(fromDate, toDate);
        tableRow.Append("<table class='table table-bordered' id='tableLoad'>" + LoadKpiReport(fromDate, toDate) + "</table>");

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=KPI_Report.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        Response.Output.Write(tableRow.ToString());
        Response.Flush();
        Response.End();
    }
}