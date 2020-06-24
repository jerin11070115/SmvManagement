using System;
using System.Data;

public partial class Merchant_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            userNameTextBox.Text = "";
            passWordTextBox.Text = "";
        }
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        MerchantLoginModel merchant = new MerchantLoginModel();
        MerchantLoginGateway merchantGateway = new MerchantLoginGateway();
        DataTable dt = new DataTable();

        try
        {
            merchant.LoginId = userNameTextBox.Text;
            merchant.Password = passWordTextBox.Text;
            if (merchant.LoginId != "" && merchant.Password != "" && merchant.LoginId != null && merchant.Password != null)
            {
                dt = merchantGateway.MerchantLogin(merchant);
                if (dt.Rows.Count > 0)
                {
                    merchant.MerchantId = Convert.ToInt32(dt.Rows[0]["MerchantId"].ToString());
                    merchant.LoginId = dt.Rows[0]["LogInId"].ToString();
                    merchant.MerchantName = dt.Rows[0]["MerchantName"].ToString();
                    //merchant.isActive = dt.Rows[0]["IsActive"].ToString();

                    if (merchant.MerchantId != 0)
                    {
                        this.Session.Timeout = 300;
                        this.Session["KP_Merchant_Id"] = merchant.MerchantId.ToString();
                        this.Session["KP_Merchant_LoginId"] = merchant.LoginId.ToString();
                        this.Session["KP_MerchantName"] = merchant.MerchantName.ToString();

                        Response.Cookies["CK_KP_Merchant_Id"].Value = merchant.MerchantId.ToString();
                        Response.Cookies["CK_KP_Merchant_Id"].Expires = DateTime.Now.AddDays(2);
                        Response.Redirect("Default.aspx", false);
                    }

                }
                else
                {
                    Response.Write("Access denied! Invalid Login Email or Password.");
                }
            }
            else
            {

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}