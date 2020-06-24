using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            userNameTextBox.Text = "";
            passwordTextBox.Text = "";
        }
    }

    protected void loginButton_Click(object sender, EventArgs e)
    {
		
		
        LoginClass login = new LoginClass();
        LoginGateway loginGateway = new LoginGateway();
        DataTable dt = new DataTable();
       // try
        //{


            login.UserName = userNameTextBox.Text;
            login.UserPassword = passwordTextBox.Text;

            dt = loginGateway.Login(login);
            if (dt.Rows.Count > 0)
            {
                login.UserId = Convert.ToInt32(dt.Rows[0]["UserId"].ToString());
                login.UserName = dt.Rows[0]["UserName"].ToString();
                login.FullName = dt.Rows[0]["FullName"].ToString();
                //login.ZoneName = dt.Rows[0]["ZoneName"].ToString();

                if (login.UserId != 0)
                {
                    //this.Session.Timeout = 300;
                    this.Session["KP_User_Id"] = login.UserId.ToString();
                    this.Session["KP_UserName"] = login.UserName.ToString();
                    this.Session["KP_Name"] = login.FullName.ToString();
                   // this.Session["KP_Zone"] = login.ZoneName.ToString();


                Response.Cookies["CK_KP_User_Id"].Value = login.UserId.ToString();
                    Response.Cookies["CK_KP_User_Id"].Expires = DateTime.Now.AddDays(7);
                    Response.Redirect("Users/UserProfile.aspx", false);
                }



            }
            else
            {
                Response.Write("Access denied! Invalid Login Email or Password.");
            }
          //Response.Write(dt.Rows.Count);


       // }
//catch (Exception ex){
	//Response.Write("error");
//}
    }
}