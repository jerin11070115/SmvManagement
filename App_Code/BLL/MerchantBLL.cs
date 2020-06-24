using DevExpress.Utils.OAuth.Provider;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;


/// <summary>
/// Summary description for MerchantBLL
/// </summary>
public class MerchantBLL
{
    public DataTable InsertNewMerchant(MerchantModel merchant)
    {
        DataTable dt = new DataTable();
        MerchantGateway merchantGateway = new MerchantGateway();
        try
        {
            dt = merchantGateway.InsertNewMerchant(merchant);

            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public int UpdateMerchantInfo(MerchantModel merchant)
    {
        int actionResult = 0;
        MerchantGateway merchantGateway = new MerchantGateway();
        try
        {
            actionResult = merchantGateway.UpdateMerchantInfo(merchant);
            return actionResult;
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public string GetMerchantInfo(int merchantId)
    {
        StringBuilder table = new StringBuilder();
        DataTable dt = new DataTable();
        MerchantGateway merchantGateway = new MerchantGateway();
        try
        {
            dt = merchantGateway.GetMerchantInfo(merchantId);
            int count = 0;
            if (dt.Rows.Count > 0)
            {
                table.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                                "<th>Serial No</th>" +
                                "<th>Merchant Name</th>" +
                                "<th>Login Id</th>" +
                                "<th>Is Active</th>" +
                                "<th>Posted By</th>" +
                                "<th>Posted On</th>" +
                                "<th>Updated By</th>" +
                                "<th>Updated On</th>" +
                                "<th>Action</th>" +
                                "</tr></thead >");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    count++;

                    table.Append("<tbody><tr>");
                    table.Append("<td>" + count + "</td>");
                    table.Append("<td>" + dt.Rows[i]["MerchantName"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["LogInId"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["IsActive"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["PostedByName"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["PostedOn"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["UpdatedByName"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["UpdatedOn"] + "</td>");
                    table.Append("<td><a href ='NewMerchantEntryPanel.aspx?id=" + dt.Rows[i]["MerchantId"] + "'> EDIT </a> </td>");
                    table.Append("</tr></tbody>");
                }
                table.Append("</table>");
            }
            else
            {
                table.Append("No Data Found");
            }
        }
        catch (Exception ex)
        {

        }
        return table.ToString();
    }

    public string LoadMerchantRequest(int userId)
    {
        StringBuilder table = new StringBuilder();
        DataTable dt = new DataTable();
        MerchantGateway merchantGateway = new MerchantGateway();

        try
        {
            dt = merchantGateway.LoadMerchantRequest(userId);

            int count = 0;
            if (dt.Rows.Count > 0)
            {
                table.Append("<table class='table table-bordered' id='example'><thead><tr class='success'>" +
                                "<th>Serial No</th>" +
                                "<th>Merchant Name</th>" +
                                "<th>Buyer Name</th>" +
                                "<th>Style Number</th>" +
                                "<th>Sampel Stage</th>" +
                                "<th>Proguct Category</th>" +
                                "<th>Fabric</th>" +
                                "<th>Approx Order Qtn</th>" +
                                "<th>Costing Dead Line</th>" +
                                "<th>Special Comment</th>" +
                                "<th>Send To User</th>" +
                                "<th>Sender</th>" +
                                "<th>Sending Date</th>" +
                                "<th>File</th>" +
                                "<th>Mail</th>" +
                                "<th>Action</th>" +
                               "<th>Send Mail</th>" +
                                "</tr></thead >");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    count++;

                    table.Append("<tbody><tr>");
                    table.Append("<td>" + count + "</td>");
                    table.Append("<td>" + dt.Rows[i]["MerchantName"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["BuyerName"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["StyleNumber"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["SampelStage"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["ProguctCategory"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["FabricName"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["ApproxOrderQtn"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["CostingDeadLine"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["SpecialComment"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["SendToUser"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["PostedByName"] + "</td>");
                    table.Append("<td>" + dt.Rows[i]["PostedOn"] + "</td>");

                    string merchantId = dt.Rows[i]["MerchantId"].ToString();
                    string buyerId = dt.Rows[i]["BuyerId"].ToString();
                    string sampleStageId = dt.Rows[i]["SampleStageId"].ToString();
                    string fabricId = dt.Rows[i]["FabricId"].ToString();
                    string productCategoryId = dt.Rows[i]["ProductId"].ToString();
                    string styleNumber = dt.Rows[i]["StyleNumber"].ToString();
                    string sendToUserId = dt.Rows[i]["SendToUserId"].ToString();
                    string DesignNumber = dt.Rows[i]["DesignNumber"].ToString();
                    //string currentURL = HttpContext.Current.Request.Url.AbsoluteUri;

                    Uri uri = HttpContext.Current.Request.Url;
                    string currentURL = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;
                   //string filePath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Files/Request/" + merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".pdf");
                    string filePath = currentURL+ "/SMV/Files/Request/" + merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".pdf";
                    string file = merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".pdf";


                   string mailFilePath = currentURL + "/SMV/Files/Request/Mail/" + merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".msg";
                   //string mailFilePath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Files/Request/Mail/" + merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".msg");

                    string mailFile = merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".msg";
                    

                    if (File.Exists(filePath))
                    {

                        table.Append("<td>" + file + "<a href='" + filePath + "'>(Download)</a></td>");

                    }
                    else
                    {
                        //table.Append("<td>" + "File Not Found" + "</td>");
                        table.Append("<td>" + file + "<a href='" + filePath + "'>(Download)</a></td>");
                    }


                    if (File.Exists(mailFilePath))
                    {

                        table.Append("<td>" + mailFile + "<a href='" + mailFilePath + "'>(Download)</a></td>");

                    }
                    else
                    {
                       // table.Append("<td>" + "File Not Found" + "</td>");
                        table.Append("<td>" + mailFile + "<a href='" + mailFilePath + "'>(Download)</a></td>");
                    }

                    int PreviousSampleStage =Convert.ToInt32(dt.Rows[i]["PreviousSampleStage"]);
                    if(PreviousSampleStage>0)
                    {
                        table.Append("<td><a href ='../SMV/CostingRevisedPanel.aspx?RequestId=" + dt.Rows[i]["RequestId"] + "'>Load For SMV</a></td>");
                    }
                    else
                    {
                        table.Append("<td><a href ='../SMV/CostingSmvPanel.aspx?RequestId=" + dt.Rows[i]["RequestId"] + "'>Load For SMV</a></td>");
                    }

                    table.Append("<td><a href ='SmvSentToMerchant.aspx?RequestId=" + dt.Rows[i]["RequestId"] + "'>Send</a></td>");

                    table.Append("</tr></tbody>");
                }
                table.Append("</table>");
            }
            else
            {
                table.Append("No Data Found");
            }
        }
        catch (Exception ex)
        {

        }
        return table.ToString();
    }

	public string LoadAllPendingSmvRequestOfCurrentDate(string FromDate, string Todate)
	{
		StringBuilder table = new StringBuilder();
		DataTable dt = new DataTable();
		MerchantGateway merchantGateway = new MerchantGateway();
		try
		{
			dt = merchantGateway.LoadAllPendingSmvRequestOfCurrentDate(FromDate, Todate);

			int count = 0;

			if (dt.Rows.Count > 0)
			{
				table.Append("<table class='table table-bordered' id='example'><thead><tr class='success'>" +
								"<th>Serial No</th>" +
								"<th>Request To</th>" +
								"<th>Merchant Name</th>" +
								"<th>Buyer Name</th>" +
								"<th>Style Number</th>" +
								"<th>Design Number</th>" +
								"<th>Requested Sampel Stage</th>" +
								"<th>Previous Sampel Stage</th>" +
								"<th>Proguct Category</th>" +
								"<th>Fabric</th>" +
								"<th>Approx Order Qtn</th>" +
								"<th>Costing Dead Line</th>" +
								"<th>Special Comment</th>" +
								"<th>Sending Date</th>" +

								"</tr></thead >");
				for (int i = 0; i < dt.Rows.Count; i++)
				{
					count++;

					table.Append("<tbody><tr>");
					table.Append("<td>" + count + "</td>");
					table.Append("<td>" + dt.Rows[i]["SendToUser"] + "</td>");
					table.Append("<td>" + dt.Rows[i]["MerchantName"] + "</td>");
					table.Append("<td>" + dt.Rows[i]["BuyerName"] + "</td>");
					table.Append("<td>" + dt.Rows[i]["StyleNumber"] + "</td>");
					table.Append("<td>" + dt.Rows[i]["DesignNumber"] + "</td>");
					table.Append("<td>" + dt.Rows[i]["SampelStage"] + "</td>");
					table.Append("<td>" + dt.Rows[i]["PreviousSampleStageName"] + "</td>");
					table.Append("<td>" + dt.Rows[i]["ProguctCategory"] + "</td>");
					table.Append("<td>" + dt.Rows[i]["FabricName"] + "</td>");
					table.Append("<td>" + dt.Rows[i]["ApproxOrderQtn"] + "</td>");
					table.Append("<td>" + dt.Rows[i]["CostingDeadLine"] + "</td>");
					table.Append("<td>" + dt.Rows[i]["SpecialComment"] + "</td>");
					table.Append("<td>" + dt.Rows[i]["PostedOn"] + "</td>");

					table.Append("</tr></tbody>");
				}
				table.Append("</table>");
			}
			else
			{
				table.Append("No Request Has Been Received ToDay");
			}


			return table.ToString();
		}
		catch (Exception ex)
		{
			throw ex;
		}

	}






	public int UpdateMerchantRequest(int RequestId)
    {
        int actionResult = 0;
        try
        {
            MerchantGateway merchantGateway = new MerchantGateway();
            actionResult = merchantGateway.UpdateMerchantRequest(RequestId);

            return actionResult;

        }
        catch(Exception ex)
        {
            throw ex;
        }
    }
}