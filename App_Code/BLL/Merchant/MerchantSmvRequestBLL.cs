using System;
using System.Data;
using System.IO;
using System.Text;
using System.Web;
/// <summary>
/// Summary description for MerchantSmvRequestBLL
/// </summary>
public class MerchantSmvRequestBLL
{
    public DataTable InsertMerchantSmvRequest(MerchantSmvRequestModel merchantSmvRequestModel)
    {
        DataTable dt = null;
        try
        {
            return dt = new MerchantSmvRequestGateway().InsertMerchantSmvRequest(merchantSmvRequestModel);   
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }


    public DataTable InsertMerchantSmvRequestToRevise(MerchantSmvRequestModel merchantSmvRequestModel)
    {
        DataTable dt = null;
        try
        {
            return dt = new MerchantSmvRequestGateway().InsertMerchantSmvRequestToRevise(merchantSmvRequestModel);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public string LoadPendingMerchantRequest(int MerchantId)
    {
        StringBuilder table = new StringBuilder();
        DataTable dt = new DataTable();
        MerchantSmvRequestGateway merchantSmvRequestGateway = new MerchantSmvRequestGateway();
        try
        {
            dt = merchantSmvRequestGateway.LoadPendingMerchantRequest(MerchantId);

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
                                "<th>Sending Date</th>" +
                                "<th>Pdf File</th>" +
                                "<th>Mail File</th>" +
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
                    table.Append("<td>" + dt.Rows[i]["PostedOn"] + "</td>");

                    string merchantId = dt.Rows[i]["MerchantId"].ToString();
                    string buyerId = dt.Rows[i]["BuyerId"].ToString();
                    string sampleStageId = dt.Rows[i]["SampleStageId"].ToString();
                    string fabricId = dt.Rows[i]["FabricId"].ToString();
                    string productCategoryId = dt.Rows[i]["ProductId"].ToString();
                    string styleNumber = dt.Rows[i]["StyleNumber"].ToString();
                    string DesignNumber= dt.Rows[i]["DesignNumber"].ToString();
                    string sendToUserId = dt.Rows[i]["SendToUserId"].ToString();
                    //string currentURL = HttpContext.Current.Request.Url.AbsoluteUri;
                    Uri uri = HttpContext.Current.Request.Url;
                    string currentURL = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;

                    string filePath = currentURL + "/SMV/Files/Request/" + merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".pdf";
                    string file = merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".pdf";


                    string mailfilePath = currentURL + "/SMV/Files/Request/Mail/" + merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".msg";
                    string mailfile = merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".msg";


                    if (File.Exists(filePath))
                    {

                        table.Append("<td>" + file + "</td>");

                    }
                    else
                    {
                        //table.Append("<td>" + "File Not Found" + "</td>");
                        table.Append("<td>" + file + "</td>");
                    }
                    if (File.Exists(mailfilePath))
                    {

                        table.Append("<td>" + mailfile + "</td>");

                    }
                    else
                    {
                        //table.Append("<td>" + "File Not Found" + "</td>");
                        table.Append("<td>" + mailfile + "</td>");
                    }


                    table.Append("</tr></tbody>");
                }
                table.Append("</table>");
            }
            else
            {
                table.Append("No Data Found");
            }
        }
        catch(Exception ex)
        {

        }
        return table.ToString();
    }

    public string LoadReceivedMerchantSmvData(int MerchantId)
    {
        StringBuilder table = new StringBuilder();
        DataTable dt = new DataTable();
        MerchantSmvRequestGateway merchantSmvRequestGateway = new MerchantSmvRequestGateway();
        try
        {
            dt = merchantSmvRequestGateway.LoadReceivedMerchantSmvData(MerchantId);

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
                                "<th>Sending Date</th>" +
                                "<th>Pdf File</th>" +
                                "<th>Mail File</th>" +
                                "<th>Action</th>" +
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
                    table.Append("<td>" + dt.Rows[i]["PostedOn"] + "</td>");

                    string merchantId = dt.Rows[i]["MerchantId"].ToString();
                    string buyerId = dt.Rows[i]["BuyerId"].ToString();
                    string sampleStageId = dt.Rows[i]["SampleStageId"].ToString();
                    string fabricId = dt.Rows[i]["FabricId"].ToString();
                    string productCategoryId = dt.Rows[i]["ProductId"].ToString();
                    string styleNumber = dt.Rows[i]["StyleNumber"].ToString();
                    string DesignNumber = dt.Rows[i]["DesignNumber"].ToString();
                    string sendToUserId = dt.Rows[i]["SendToUserId"].ToString();
                    //string currentURL = HttpContext.Current.Request.Url.Host;
                    Uri uri = HttpContext.Current.Request.Url;
                    string currentURL = uri.Scheme + Uri.SchemeDelimiter + uri.Host + ":" + uri.Port;


                   // string filePath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Files/Received/" + merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".pdf");
                    string filePath = currentURL+ "/SMV/Files/Received/" + merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".pdf";
                    string file = merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".pdf";

                    //string mailFilePath = System.Web.Hosting.HostingEnvironment.MapPath(@"~/Files/Received/Mail/" + merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".msg");
                    string mailFilePath = currentURL + "/SMV/Files/Received/Mail/" + merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".msg";
                    string mailFile = merchantId + buyerId + sampleStageId + fabricId + productCategoryId + styleNumber + "_" + DesignNumber + sendToUserId + ".msg";

                    if (File.Exists(filePath))
                    {

                        table.Append("<td>" + file + "<a href='"+ filePath +"'> (Download)</a></td>");

                    }
                    else
                    {
                       //table.Append("<td>" + "File Not Found" + "</td>");
                       table.Append("<td>" + file + "<a href='" + filePath + "'> (Download)</a></td>");
                    }

                    if (File.Exists(mailFilePath))
                    {

                        table.Append("<td>" + mailFile + "<a href='" + mailFilePath + "'> (Download)</a></td>");

                    }
                    else
                    {
                        // table.Append("<td>" + "File Not Found" + "</td>");
                        table.Append("<td>" + mailFile + "<a href='" + mailFilePath + "'> (Download)</a></td>");
                    }

                    table.Append("<td><a href ='RevisedSmvRequest.aspx?RequestId=" + dt.Rows[i]["RequestId"] + "'>Request For Revise</a></td>");

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

}