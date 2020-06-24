using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Users_PendingSmvRequestReport : System.Web.UI.Page
{
	public string userId = "0";
	public string userName = "";
	public string requestTable = "";

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
			requestTable = LoadAllPendingSmvRequestOfCurrentDate(fromDate, toDate);
		}
	}

	protected string LoadAllPendingSmvRequestOfCurrentDate(string FromDate, string Todate)
	{
		string table = "";
		try
		{
			table = new MerchantBLL().LoadAllPendingSmvRequestOfCurrentDate(FromDate, Todate);
		}
		catch (Exception ex)
		{

		}
		return table;
	}




    protected void sendButton_Click(object sender, EventArgs e)
    {
        fromDate = fromDateTextBox.Text;
        toDate = toDateTextBox.Text;

        requestTable = LoadAllPendingSmvRequestOfCurrentDate(fromDate, toDate);
        // DateTime dateTime = DateTime.UtcNow.Date;


        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

        if (manager1CheckBox.Checked)
        {
            mail.To.Add("Omil.Viraj@kenpark-bangladesh.com");
        }
        if (manager2CheckBox.Checked)
        {
            mail.To.Add("Nazrul.Sanzo@kenpark-bangladesh.com");
        }
        if (manager3CheckBox.Checked)
        {
            mail.To.Add("Bathiya.Desilva@regencybd.net");
        }
        if (manager4CheckBox.Checked)
        {
            mail.To.Add("Amzad.Hossain@regencybd.net");
        }
        mail.To.Add("smvsystem2018@gmail.com");
        //mail.To.Add("md.shifuddin@regencybd.net");

        mail.From = new MailAddress("smvsystem2018@gmail.com", "Smv System", System.Text.Encoding.UTF8);
        mail.Subject = "Pending Smv Request From Merchant - " + fromDate + " TO " + toDate;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = requestTable;
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;
        SmtpClient client = new SmtpClient();
        client.Port = 25;
        client.Host = "mail.kenpark-bangladesh.com";
        //client.EnableSsl = true;
        try
        {
            client.Send(mail);
            Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='PendingSmvRequestReport.aspx';}</script>");
        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;

            }
            //Response.Write(errorMessage);
            Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='PendingSmvRequestReport.aspx';}</script>");
            //Page.RegisterStartupScript("UserMsg", "<script>alert('"+ errorMessage +"');if(alert){ window.location='PendingSmvRequestReport.aspx';}</script>");                    

            //requestTable = LoadAllPendingSmvRequestOfCurrentDate(fromDate, toDate);
            //DateTime dateTime = DateTime.UtcNow.Date;

            //System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            ////if (manager1CheckBox.Checked)
            ////{
            ////    mail.To.Add("Nazrul.Sanzo@kenpark-bangladesh.com");
            ////}
            ////if(manager2CheckBox.Checked)
            ////{
            ////    mail.To.Add("Omil.Viraj@kenpark-bangladesh,.com"); 
            ////}
            ////if(manager3CheckBox.Checked)
            ////{
            ////    mail.To.Add("Bathiya.DeSilva@regencybd.net");
            ////}
            ////if(manager4CheckBox.Checked)
            ////{
            ////    mail.To.Add("Amzad.Hossain@regencybd.net");
            ////}
            //mail.To.Add("smvsystem2018@gmail.com");
            //mail.To.Add("ismatkhanzarin@gmail.com");
            //mail.To.Add("himu1110@gmail.com");
            //mail.From = new MailAddress("smvsystem2018@gmail.com", "Smv System", System.Text.Encoding.UTF8);
            //mail.Subject = "Pending Smv Request From Merchant - " + fromDate + "To" + toDate;
            //mail.SubjectEncoding = System.Text.Encoding.UTF8;
            //mail.Body = requestTable;
            //mail.BodyEncoding = System.Text.Encoding.UTF8;
            //mail.IsBodyHtml = true;
            //mail.Priority = MailPriority.High;
            //SmtpClient client = new SmtpClient();
            ////client.Credentials = new System.Net.NetworkCredential("smvsystem@gmail.com", "smvmanage2018");
            ////client.Port = 587;
            //client.Port = 25;
            //client.Host = "mail.kenpark-bangladesh.com";
            ////client.Host = "smtp.gmail.com";
            ////client.EnableSsl = true;
            //try
            //{
            //    client.Send(mail);
            //    Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){window.location='PendingSmvRequestRepoert.aspx';}</script>");
            //}
            //catch (Exception ex)
            //{
            //    Exception ex2 = ex;
            //    string errorMessage = string.Empty;
            //    while(ex2!=null)
            //    {
            //        errorMessage += ex2.ToString();
            //        ex2 = ex2.InnerException;
            //    }
            //    Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){window.location='PendingSmvRequestReport.aspx';}</script>");
            //}
            //fromDate = fromDateTextBox.Text;
            //toDate = toDateTextBox.Text;

            //requestTable = LoadAllPendingSmvRequestOfCurrentDate(fromDate, toDate);
            //DateTime dateTime = DateTime.UtcNow.Date;


            //System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

            //if (manager1CheckBox.Checked)
            //{
            //	mail.To.Add("Omil.Viraj@kenpark-bangladesh.com");
            //}
            //if (manager2CheckBox.Checked)
            //{
            //	mail.To.Add("Nazrul.Sanzo@kenpark-bangladesh.com");
            //}
            //if (manager3CheckBox.Checked)
            //{
            //	mail.To.Add("Bathiya.Desilva@regencybd.net");
            //}
            //if (manager4CheckBox.Checked)
            //{
            //	mail.To.Add("Amzad.Hossain@regencybd.net");
            //}
            //mail.To.Add("smvsystem2018@gmail.com");
            //mail.To.Add("ismatkhanzarin@gmail.com");

            //mail.From = new MailAddress("smvsystem2018@gmail.com", "Smv System", System.Text.Encoding.UTF8);
            //mail.Subject = "Pending Smv Request From Merchant - "+ fromDate +" TO "+toDate;
            //mail.SubjectEncoding = System.Text.Encoding.UTF8;
            //mail.Body = requestTable;
            //mail.BodyEncoding = System.Text.Encoding.UTF8;
            //mail.IsBodyHtml = true;
            //mail.Priority = MailPriority.High;
            //SmtpClient client = new SmtpClient();
            //client.Credentials = new System.Net.NetworkCredential("smvsystem2018@gmail.com", "smvmanage2018");
            //client.Port = 587;
            //client.Host = "smtp.gmail.com";
            //client.EnableSsl = true;

            //try
            //{
            //	client.Send(mail);
            //	Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='PendingSmvRequestReport.aspx';}</script>");
            //}
            //catch (Exception ex)
            //{
            //	Exception ex2 = ex;
            //	string errorMessage = string.Empty;
            //	while (ex2 != null)
            //	{
            //		errorMessage += ex2.ToString();
            //		ex2 = ex2.InnerException;
            //	}
            //	Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='PendingSmvRequestReport.aspx';}</script>");
            //}

        }
    }


    protected void searchButton_Click(object sender, EventArgs e)
	{
		fromDate = fromDateTextBox.Text;
		toDate = toDateTextBox.Text;

		requestTable = LoadAllPendingSmvRequestOfCurrentDate(fromDate, toDate);

	}
}