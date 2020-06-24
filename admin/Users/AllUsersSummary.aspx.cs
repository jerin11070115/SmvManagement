using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Users_AllUsersSummary : System.Web.UI.Page
{
    public string userId = "0";
    public string userName = "";
    public string newCostingTable = "";
    public string RevisedCostingTable = "";
    public string newBulkTable = "";
    public string RevisedBulkTable = "";

    public string fromDate = "";
    public string toDate = "";
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
            //newCostingTable = GetAllUsersNewCostingSummary(fromDate, toDate);
            //RevisedCostingTable = GetAllUsersRevisedCostingSummary(fromDate, toDate);
            //newBulkTable = GetAllUsersNewBulkSummary(fromDate, toDate);
            //RevisedBulkTable = GetAllUsersRevisedBulkSummary(fromDate, toDate);
        }
    }




    protected string GetAllUsersNewCostingSummary( string fromDate,string toDate)
    {
        string table = "";       
        try
        {
            table = new AllUsersSummaryBLL().GetAllUsersNewCostingSummary(fromDate, toDate);
        }
        catch (Exception ex)
        {

        }
        return table;
    }

    protected string GetAllUsersRevisedCostingSummary(string fromDate, string toDate)
    {
        string table = "";
        try
        {
            table = new AllUsersSummaryBLL().GetAllUsersRevisedCostingSummary(fromDate, toDate);
        }
        catch (Exception ex)
        {

        }
        return table;
    }

    protected string GetAllUsersNewBulkSummary(string fromDate, string toDate)
    {
        string table = "";
        try
        {
            table = new AllUsersSummaryBLL().GetAllUsersNewBulkSummary(fromDate, toDate);
        }
        catch (Exception ex)
        {

        }
        return table;
    }

    protected string GetAllUsersRevisedBulkSummary(string fromDate, string toDate)
    {
        string table = "";
        try
        {
            table = new AllUsersSummaryBLL().GetAllUsersRevisedBulkSummary(fromDate, toDate);
        }
        catch (Exception ex)
        {

        }
        return table;
    }


    protected void searchButton_Click(object sender, EventArgs e)
    {
        fromDate = fromDateTextBox.Text;
        toDate = toDateTextBox.Text;

        newCostingTable = GetAllUsersNewCostingSummary(fromDate, toDate);
        RevisedCostingTable = GetAllUsersRevisedCostingSummary(fromDate, toDate);
        newBulkTable = GetAllUsersNewBulkSummary(fromDate, toDate);
        RevisedBulkTable = GetAllUsersRevisedBulkSummary(fromDate, toDate);
    }
}