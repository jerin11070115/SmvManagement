using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_EntryPanel_ProductEntryPanel : System.Web.UI.Page
{

    public string table = "";
    public string userId = "0";
    public string userName = "";
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
            table = LoadProductInfo();
        }
        else
        {
            table = LoadProductInfo();
        }

    }




    protected void submitButton_Click(object sender, EventArgs e)
    {
        Products product = new Products();
        ProductEntryBLL productBll = new ProductEntryBLL();
        try
        {
            product.ProductName = productNameTextBox.Text;
           // product.ProductType = productTypeTextBox.Text;
            if (productNameTextBox.Text == "" || productNameTextBox.Text == null)
            {
                messageLabel.Text = "Please Enter Product Name..";
                table = LoadProductInfo();
            }
            //else if (productTypeTextBox.Text == "" || productTypeTextBox.Text == null)
            //{
            //    messageLabel.Text = "Please Enter Product Type..";
            //    table = LoadProductInfo();
            //}
            else
            {
                actionResult = productBll.InsertProductInfo(product);
                if (actionResult == 1)
                {
                    messageLabel.Text = "Product Information Has Been Sucessfully Inserted...";
                    //productTypeTextBox.Text = "";
                    productNameTextBox.Text = "";
                    table = LoadProductInfo();
                }
                else
                {
                    messageLabel.Text = "Operation failed...";
                    table = LoadProductInfo();
                }

            }
        }
        catch (Exception ex)
        {

        }
    }

    public string LoadProductInfo()
    {
        string tableRow = "";
        try
        {
            tableRow = new ProductEntryBLL().LoadProductInfo();
        }
        catch (Exception ex)
        {

        }
        return tableRow.ToString();
    }
}