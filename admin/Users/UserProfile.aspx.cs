using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Users_UserProfile : System.Web.UI.Page
{
    public string userId = "0";
    public string userName = "";
    public string styleTable = "";

    public string sampleTable = "";
    public string bulkStyleTable = "";
    public string bulkSampleTable = "";
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

        GetUserProfileName();
        //GetUsersPerformance();
       

        if(!IsPostBack)
        {
            styleTable = GetCostingStyleInfoByUser();
            sampleTable = GetCostingSampleInfoByUser();
            bulkStyleTable = GetBulkStyleInfoByUser();
            bulkSampleTable = GetBulkSampleInfoByUser();
        }
    }

    protected  void GetUserProfileName()
    {
        int UsersId = Convert.ToInt32(userId);
        try
        {
            DataTable dt = null;
            ProfileBLL profileBLL = new ProfileBLL();

            dt = profileBLL.GetUserProfileName(UsersId);

            if(dt.Rows.Count==1)
            {
                fullNameLabel.Text = dt.Rows[0]["FullName"].ToString();
            }
        }
        catch(Exception)
        {

        }
    }



    //protected void GetUsersPerformance()
    //{
    //    int UsersId = Convert.ToInt32(userId);
    //    try
    //    {
    //        DataTable dt = null;
    //        ProfileBLL profileBLL = new ProfileBLL();

    //        dt = profileBLL.GetUsersPerformance(UsersId);

    //        if (dt.Rows.Count == 1)

    //        {
    //            int costingNew =Convert.ToInt32( dt.Rows[0]["CostingStyleNumber"]);
    //            int costingRevised = Convert.ToInt32(dt.Rows[0]["CostingSampleStage"]);
    //            int Revised = costingRevised - costingNew;

    //            costingStyleNumberLabel.Text = "Inputed Total Costing New : " + dt.Rows[0]["CostingStyleNumber"].ToString();
    //            costingSampleStageLabel.Text = "Inputed Total Costing Revised : " + Revised.ToString();
    //            bulkStyleNumberLabel.Text = "Inputed Total Issued OB : " + dt.Rows[0]["BulkStyleNumber"].ToString();
    //            bulkSampleStageLabel.Text = "Inputed Total Bulk Revised : " + dt.Rows[0]["BulkSampleStage"].ToString();
    //        }
    //    }
    //    catch (Exception)
    //    {

    //    }
    //}


    protected string GetCostingStyleInfoByUser()
    {
        string table = "";
        int UsersId = Convert.ToInt32(userId);
        try
        {
            ProfileBLL profileBLL = new ProfileBLL();

            table = profileBLL.GetCostingStyleInfoByUser(UsersId).ToString();
        }
        catch(Exception ex)
        {
            
        }
        return table;
    }



    protected string GetCostingSampleInfoByUser()
    {
        string table = "";
        int UsersId = Convert.ToInt32(userId);
        try
        {
            ProfileBLL profileBLL = new ProfileBLL();

            table = profileBLL.GetCostingSampleInfoByUser(UsersId).ToString();
        }
        catch (Exception ex)
        {

        }
        return table;
    }

    protected string GetBulkStyleInfoByUser()
    {
        string table = "";
        int UsersId = Convert.ToInt32(userId);
        try
        {
            ProfileBLL profileBLL = new ProfileBLL();

            table = profileBLL.GetBulkStyleInfoByUser(UsersId).ToString();
        }
        catch (Exception ex)
        {

        }
        return table;
    }


    protected string GetBulkSampleInfoByUser()
    {
        string table = "";
        int UsersId = Convert.ToInt32(userId);
        try
        {
            ProfileBLL profileBLL = new ProfileBLL();

            table = profileBLL.GetBulkSampleInfoByUser(UsersId).ToString();
        }
        catch (Exception ex)
        {

        }
        return table;
    }
}