using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Users_deletefile : System.Web.UI.Page
{
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

            Response.Redirect("../Default.aspx");
            Response.End();
        }

    }

    protected void deleteButton_Click(object sender, EventArgs e)
    {

        List<string> DeletePath = new List<string>();
        DirectoryInfo info = new DirectoryInfo(Server.MapPath("~\\Files"));
        FileInfo[] files = info.GetFiles().OrderBy(p => p.CreationTime).ToArray();
        foreach (FileInfo file in files)
        {
            DateTime CreationTime = file.CreationTime;
            double days = (DateTime.Now - CreationTime).TotalDays;
            if (days > 2)
            {
                string delFullPath = file.DirectoryName + "\\" + file.Name;
                DeletePath.Add(delFullPath);
            }
        }
        foreach (var f in DeletePath)
        {
            if (File.Exists(f))
            {
                File.Delete(f);
            }
        }

    }
}