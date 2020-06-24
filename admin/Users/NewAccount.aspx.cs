using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Users_NewAccount : System.Web.UI.Page
{
    public string userId = "0";
    public string userName = "";
    public string table = "";
    public int loadUserId = 0;
    public int actionResult = 0;
    public string adminType = "0";

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



        loadUserId = Convert.ToInt32(Request.QueryString["Id"]);

        if (!IsPostBack)
        {
            table = LoadUserInformation();

            if (loadUserId != 0)
            {
                LoadUserInfoById(loadUserId);
                submitButton.Text = "Update";
            }
        }

    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        UserAccount account = new UserAccount();
        AcountBLL accountBll = new AcountBLL();
        try
        {


            account.UserName = userNameTextBox.Text;
            account.Password = passwordTextBox.Text;
            account.UserFullName = fullNameTextBox.Text;
            account.IsActive = Convert.ToInt32(isAcctiveDropDownList.SelectedValue);
            account.AdminType = Convert.ToInt32(typeDropDownList.SelectedValue);
            account.ZoneName = zoneNameDropDownList.SelectedValue.ToString();

            if (loadUserId == 0)
            {
                account.PostedBy =Convert.ToInt32(userId);
                account.UpdatedBy = 0;
                dt = accountBll.InsertNewAccount(account);
                if (dt.Rows.Count > 0)
                {
                    bool Useraccount = Convert.ToBoolean(dt.Rows[0]["dName"]);

                    if (Useraccount)
                    {
                        messageLabel.Text = "<p Style ='font-size:20px;color:Red; margin-top:20px;'>User Account (" + account.UserName + ") Or Password Already Exists</p>";
                    }
                    else
                    {
                        messageLabel.Text = "<p Style ='font-size:20px;color:Green; margin-top:20px;'>New User Account : " + account.UserName + " Created</p>";
                    }
                }
            }
            else
            {

                account.UpdatedBy = Convert.ToInt32(userId);
                account.UserId = loadUserId;

                actionResult = accountBll.UpdateUserAccount(account);
                if (actionResult == 1)
                {
                    messageLabel.Text = "<p Style ='font-size:20px;color:green; margin-top:20px;'>User account has been successfully updated</p>";
                }
                else
                {
                    messageLabel.Text = "<p Style ='font-size:20px;color:Red; margin-top:20px;'>Same Information Declare For Update !</p>";
                }


            }
        }
        catch (Exception ex)
        {

        }
        table = LoadUserInformation();

    }

    public string LoadUserInformation()
    {
        string info = null;
        try
        {
            AcountBLL accountBll = new AcountBLL();
            info = accountBll.LoadUserInformation();
        }
        catch (Exception ex)
        {

        }
        return info;
    }

    public void LoadUserInfoById(int newUserId)
    {
        //UserAccount account = new UserAccount();

        try
        {
            AcountBLL accountBLL = new AcountBLL();
            DataTable dt = accountBLL.LoadUserInfoById(newUserId);

            if (dt.Rows.Count > 0)
            {
                userNameTextBox.Text = Convert.ToString(dt.Rows[0]["UserName"]);
                passwordTextBox.Text = Convert.ToString(dt.Rows[0]["UserPassword"]);
                fullNameTextBox.Text = Convert.ToString(dt.Rows[0]["FullName"]);
                isAcctiveDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["IsActive"]);
                typeDropDownList.SelectedValue= Convert.ToString(dt.Rows[0]["AdminType"]);
                zoneNameDropDownList.SelectedValue= Convert.ToString(dt.Rows[0]["ZoneName"]);
            }

        }
        catch (Exception ex)
        {

        }
    }
}