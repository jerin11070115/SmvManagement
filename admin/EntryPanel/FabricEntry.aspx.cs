using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_EntryPanel_FabricEntry : System.Web.UI.Page
{
    public string userId = "0";
    public string userName = "";
    public string table = "";
    public int actionResult = 0;
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
            table = LoadFabricInfo();
        }
        else
        {
            table = LoadFabricInfo();
        }
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        Fabrics fabric = new Fabrics();
        FabricsEntryBLL fabricBLL = new FabricsEntryBLL();
        try
        {
            fabric.FabricType = fabricTypeTextBox.Text;
            fabric.FabricName = fabricNameTextBox.Text;

            if (fabricTypeTextBox.Text == "" || fabricTypeTextBox.Text == null)
            {
                messageLabel.Text = "Please Enter Fabric Type..";
                table = LoadFabricInfo();
            }
            else if (fabricNameTextBox.Text == "" || fabricNameTextBox.Text == null)
            {
                messageLabel.Text = "Please Enter Fabric Name..";
                table = LoadFabricInfo();
            }
            else
            {
                actionResult = fabricBLL.InsertFabricInfo(fabric);
                if (actionResult == 1)
                {
                    messageLabel.Text = "Fabric Information Has Been Sucessfully Inserted...";
                    fabricTypeTextBox.Text = "";
                    fabricNameTextBox.Text = "";
                    table = LoadFabricInfo();
                }
                else
                {
                    messageLabel.Text = "Operation failed...";
                    table = LoadFabricInfo();
                }


            }
        }
        catch (Exception ex)
        {

        }
    }

    public string LoadFabricInfo()
    {
        string tableRow = "";
        try
        {
            tableRow = new FabricsEntryBLL().LoadFabricsInfo();
        }
        catch (Exception ex)
        {

        }
        return tableRow.ToString();
    }
}