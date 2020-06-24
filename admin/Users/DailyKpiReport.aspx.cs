using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Users_DailyKpiReport : System.Web.UI.Page
{
    public string userId = "0";
    public string userName = "";

    public string fromDate = "";
    public string toDate = "";
    public string DailyKpiTable = "";
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
            
        }
    }
    protected string GetDailyKpiReport(string FromDate, string Todate)
    {
        string table = "";
        try
        {
            table = new AllUsersSummaryBLL().GetDailyKpiReport(FromDate, Todate);
            return table;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        fromDate = fromDateTextBox.Text;
        toDate = toDateTextBox.Text;

        DailyKpiTable = GetDailyKpiReport(fromDate, toDate);
    }

    protected void excelButton_Click(object sender, EventArgs e)
    {
        DataTable dt = null;

        StringBuilder tableRow = new StringBuilder();
        fromDate = fromDateTextBox.Text;
        toDate = toDateTextBox.Text;
        GetDailyKpiReport(fromDate, toDate);
        tableRow.Append("<table class='table table-bordered' id='tableLoad'>" + GetDailyKpiReport(fromDate, toDate) + "</table>");

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Daily_KPI_Report Of ("+fromDate+ " To "+ toDate + ").xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        Response.Output.Write(tableRow.ToString());
        Response.Flush();
        Response.End();
    }
}