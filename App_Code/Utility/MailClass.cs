using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;

/// <summary>
/// Summary description for MailClass
/// </summary>
public class MailClass
{
    public MailClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public void SendMailForCostingSmv(CostingSmv smv)
    {
        string buyerName = String.Empty;
        string sampleStage = String.Empty;
        string postedByName = String.Empty;
        string zoneName = String.Empty;
        BuyerGateway buyerGateway = new BuyerGateway();
        DataTable dt = new DataTable();

        dt = buyerGateway.GetSendingMailInfo(smv.BuyerId, smv.SampleStageId, smv.PostedBy);
        if(dt.Rows.Count>0)
        {
            buyerName = dt.Rows[0]["BuyerName"].ToString();
            sampleStage = dt.Rows[0]["SampleStage"].ToString();
            postedByName = dt.Rows[0]["PostedByName"].ToString();
            zoneName = dt.Rows[0]["ZoneName"].ToString();
        }

        StringBuilder mailBody = new StringBuilder();
        mailBody.Append("Dear Concern,"
            +" The new costing smv on Buyer Name : "+ buyerName + ", Style number: "+smv.StyleNumber
            + " Sample Stage : "+ sampleStage + ", Season : "+smv.Season +"Sewing Smv:"+smv.SewingSmv
            +" was stored by : "+ postedByName

            + "Thank You"
            +"**NB:- Please do not reply this Email"
            );


        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();


        //mail.To.Add("Omil.Viraj@kenpark-bangladesh.com");
        mail.To.Add("Nazrul.Sanzo@kenpark-bangladesh.com");
        mail.To.Add("shahedul.Hoque@regencybd.net");
        mail.To.Add("Amzad.Hossain@regencybd.net");
        mail.To.Add("smvmanager2019@gmail.com");
        mail.To.Add("Moniruzzaman.Dickens@kenpark-bangladesh.com");
        mail.To.Add("Ismat.Zarin@kenpark-bangladesh.com");
        
        //mail.To.Add("ismatkhanzarin @gmail.com");

        mail.From = new MailAddress("smvmanager2019@gmail.com", "Smv System", System.Text.Encoding.UTF8);
        mail.Subject = "New Smv For - Style:" + smv.StyleNumber;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = mailBody.ToString();
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;
        SmtpClient client = new SmtpClient();
        client.Credentials = new System.Net.NetworkCredential("smvmanager2019@gmail.com", "@2018Smv");
        client.Port = 587;
        client.Host = "smtp.gmail.com";
        client.EnableSsl = true;
        try
        {
            client.Send(mail);

        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
                throw ex2;

            }

        }
    }


    public void SendMailForApprovedByNotSet(CostingSmv smv)
    {
        string buyerName = String.Empty;
        string sampleStage = String.Empty;
        string postedByName = String.Empty;
        string zoneName = String.Empty;
        BuyerGateway buyerGateway = new BuyerGateway();
        DataTable dt = new DataTable();
        
        if(smv.UpdatedBy==0)
        {
            dt = buyerGateway.GetSendingMailInfo(smv.BuyerId, smv.SampleStageId, smv.PostedBy);
        }
        else
        {
            dt = buyerGateway.GetSendingMailInfo(smv.BuyerId, smv.SampleStageId, smv.UpdatedBy);
        }

        
        if (dt.Rows.Count > 0)
        {
            buyerName = dt.Rows[0]["BuyerName"].ToString();
            sampleStage = dt.Rows[0]["SampleStage"].ToString();
            postedByName = dt.Rows[0]["PostedByName"].ToString();
            zoneName= dt.Rows[0]["ZoneName"].ToString();
        }

        StringBuilder mailBody = new StringBuilder();
        mailBody.Append("<h3>Dear Concern,</h3>"
            + "<br/>"
            + " <p>"
            + " The costing smv of Buyer Name : " + buyerName + ", <br/> Style number: " + smv.StyleNumber
            + " <br/> Design number: " + smv.DesignNumber
            + " <br/> Sample Stage : " + sampleStage + ", <br/> Season : " + smv.Season + ", <br/> Sewing Smv:" + smv.SewingSmv
            + " <br/> was stored by : " + postedByName
            + " <br/> Without Approved From: " + zoneName
            + " </p>"
            + "<br/>"
            + " Thank You"
            + "<br/>"
            + "**NB:- Please do not reply this Email"
            );


        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

        //mail.To.Add("Omil.Viraj@kenpark-bangladesh.com");
        //mail.To.Add("shahedul.Hoque@regencybd.net");

        //if (zoneName == "CEPZ")
        //{
        //    mail.To.Add("Shahab.Uddin@kenpark-bangladesh.com");

        //}
        //else if (zoneName == "KEPZ")
        //{
        //    mail.To.Add("Amzad.Hossain@regencybd.net");

        //}
        //mail.To.Add("smvmanager2019@gmail.com");
        //mail.To.Add("himu1110@gmail.com");
        mail.To.Add("Ismat.Zarin@kenpark-bangladesh.com");

        mail.From = new MailAddress("noreply@regencybd.net", "No-Reply", System.Text.Encoding.UTF8);
        mail.Subject = "Approval Missing For - Style:" + smv.StyleNumber;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = mailBody.ToString();
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;
        SmtpClient client = new SmtpClient();
        //client.Credentials = new System.Net.NetworkCredential("smvmanager2019@gmail.com", "@2018Smv");
        client.Port = 25;
        client.Host = "mail.hirdaramani.com";
        //client.EnableSsl = true;
        try
        {
            //if (zoneName == "KEPZ" || zoneName == "CEPZ")
            //{
                client.Send(mail);
            //}

        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
                throw ex2;

            }

        }
    }
    public void SendMailForApprovedByNotSetOfBulk(BulkSmv bulk)
    {
        string buyerName = String.Empty;
        string sampleStage = String.Empty;
        string postedByName = String.Empty;
        string zoneName = String.Empty;
        BuyerGateway buyerGateway = new BuyerGateway();
        DataTable dt = new DataTable();


        dt = buyerGateway.GetSendingMailInfo(bulk.BuyerId, bulk.SampleStageId, bulk.PostedBy);
        if (dt.Rows.Count > 0)
        {
            buyerName = dt.Rows[0]["BuyerName"].ToString();
            sampleStage = dt.Rows[0]["SampleStage"].ToString();
            postedByName = dt.Rows[0]["PostedByName"].ToString();
            zoneName = dt.Rows[0]["ZoneName"].ToString();
        }

        StringBuilder mailBody = new StringBuilder();
        mailBody.Append("Dear Concern,"
            + " The bulk smv of Buyer Name : " + buyerName + ", Style number: " + bulk.StyleNumber
            + " Sample Stage : " + sampleStage + ", Season : " + bulk.SeasonId + "Sewing Smv:" + bulk.SewingSmv
            + " was stored by : " + postedByName
            + " Without Approved From: " + zoneName

            + "Thank You"

            + "**NB:- Please do not reply this Email"
            );


        System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();

        //mail.To.Add("Omil.Viraj@kenpark-bangladesh.com");
        //mail.To.Add("shahedul.Hoque@regencybd.net");

        //if (zoneName == "CEPZ")
        //{
        //    mail.To.Add("Shahab.Uddin@kenpark-bangladesh.com");


        //}
        //else if (zoneName == "KEPZ")
        //{
        //    mail.To.Add("Amzad.Hossain@regencybd.net");

        //}
        //mail.To.Add("himu1110@gmail.com");
        //mail.To.Add("smvmanager2019@gmail.com");
        mail.To.Add("Ismat.Zarin@kenpark-bangladesh.com");

        // mail.From = new MailAddress("smvmanager2019@gmail.com", "Smv System", System.Text.Encoding.UTF8);
        mail.From = new MailAddress("noreply@regencybd.net", "No-Reply", System.Text.Encoding.UTF8);
        mail.Subject = "Approval Missing For - Style:" + bulk.StyleNumber;
        mail.SubjectEncoding = System.Text.Encoding.UTF8;
        mail.Body = mailBody.ToString();
        mail.BodyEncoding = System.Text.Encoding.UTF8;
        mail.IsBodyHtml = true;
        mail.Priority = MailPriority.High;
        SmtpClient client = new SmtpClient();
        //client.Credentials = new System.Net.NetworkCredential("smvmanager2019@gmail.com", "@2018Smv");
        //client.Port = 587;
        //client.Host = "smtp.gmail.com";
        //client.EnableSsl = true;
        client.Port = 25;
        client.Host = "mail.hirdaramani.com";
        try
        {
            //if(zoneName == "KEPZ" || zoneName == "CEPZ")
            //{
                client.Send(mail);
            //}
            

        }
        catch (Exception ex)
        {
            Exception ex2 = ex;
            string errorMessage = string.Empty;
            while (ex2 != null)
            {
                errorMessage += ex2.ToString();
                ex2 = ex2.InnerException;
                throw ex2;

            }

        }
    }


}