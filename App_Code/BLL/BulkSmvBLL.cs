using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for BulkSmvBLL
/// </summary>
public class BulkSmvBLL
{
    public BulkSmvBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable LoadStyleName()
    {
        DataTable dt = null;
        try
        {
            using (BulkSmvGateway bulkGateway = new BulkSmvGateway())
            {
                dt = bulkGateway.LodaStyleInfo();
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable InsertBulkSmvInfo(BulkSmv bulk)
    {
        DataTable dt = null;
        try
        {
            using (BulkSmvGateway bulksmvGateway = new BulkSmvGateway())
            {
                dt = bulksmvGateway.InsertBulkSMV(bulk);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

	public DataTable InsertBulkRevisedSmvInfo(BulkSmv bulk)
	{
		DataTable dt = null;
		try
		{
			using (BulkSmvGateway bulksmvGateway = new BulkSmvGateway())
			{
				dt = bulksmvGateway.InsertBulkRevisedSmv(bulk);
			}
		}
		catch (Exception ex)
		{

		}
		return dt;
	}



	// Work place no 1 
	public string LoadNewBulkSmvInfo(int buyerId, string styleNumber)
    {
        StringBuilder tableRow = new StringBuilder();

        DataTable dt = null;
        try
        {
            using (BulkSmvGateway smvGateway = new BulkSmvGateway())
            {

                dt = smvGateway.LoadNewBulkSmvInfo(buyerId,styleNumber);
                if (dt.Rows.Count > 0)
                {
                    int count = 0;
                    tableRow.Append("<thead ID='eventHead'><tr class='success' ID='eventTr'>" +
                                    "<th style='text-align:center;width: 55px;border:1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Sr No</th>" +
                                    "<th style='text-align:center;width: 100px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Buyer Name</th>" +
                                    "<th style='text-align:center;width: 190px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Sample Stage</th>" +
                                    "<th style='text-align:center;width: 120px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Style Number</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Style Descreption</th>" +
                                    "<th style='text-align:center;width: 120px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Fabric Type</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Product Category</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Season</th>" +
                                    "<th style='text-align:center;width: 90px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Sample Date</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Sewing SMV</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Overlay Film</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Fits SMV</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>PLK Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Auto Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Manual Quilting SMV</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Manual DownFill</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Machine DownFill</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Finishing Smv</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Total SMV</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Total Costing SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Saving In Minute</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Saving Percentage</th>" +


                                    // "<th style='text-align:center;'>Remarks</th>" +
                                    "<th style='text-align:center;width: 580px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Machine & Technical Concern</th>" +
                                    "<th style='text-align:center;width: 500px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Remarks</th>" +

                                    "<th style='text-align:center;width: 150px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Review By</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Approved By</th>" +

                                    "<th style='text-align:center;width: 160px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Posted On</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Posted By</th>" +
                                    "<th style='text-align:center;width: 160px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Updated On</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Updated By</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color:#2b335d;color: #989690;'>Edit</th>" +
                                    "</tr></thead><tbody ID='eventTb' style='text-align:center;'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tr ID='eventTd'>");
                        tableRow.Append("<td style='text-align:center;width: 55px;border: 1px solid #ddd;border-color:black;'>" + count + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 100px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["BuyerName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 190px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["SampleStageName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 120px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["StyleDescription"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 120px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["FabricType"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["ProductName"] + "</td>");
						tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["Season"] + "</td>");

						DateTime date = Convert.ToDateTime(dt.Rows[i]["SampleDate"]);
                        string datepart = date.ToString("yyyy-MM-dd");
                        if (datepart == "1900-01-01")
                        {
                            tableRow.Append("<td style='text-align:center;width: 90px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 90px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + datepart + "</td>");
                        }

                        //tableRow.Append("<td>" + dt.Rows[i]["SampleDate"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["SewingSmv"] + "</td>");
                        
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["OverlaySmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["FitsSmv"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["PlkQuelting"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["AutoQuelting"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["ManualQuelting"] + "</td>");
                        
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["ManualDownfill"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["MachineDownfill"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["FinishingSmv"] + "</td>");


                        tableRow.Append("<td class='success' style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["TotalBulkSmv"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["TotalCostingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["SavingInMinute"] + "</td>");
                        decimal percentd = Convert.ToDecimal(dt.Rows[i]["SavingPercentage"]);
                        string percent = percentd.ToString("#,##0.00");
                        //percent =dt.Rows[i]["SavingPercentage"].ToString();
                        if(percent=="0.00" || percent==null)
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + percent + "%</td>");
                        }
                        

                        //tableRow.Append("<td>" + dt.Rows[i]["WorkUpdate"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 580px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["MachineWork"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 500px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["Description"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["Review"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["Approved"] + "</td>");
                        
                        tableRow.Append("<td style='text-align:center;width: 160px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["PostedOn"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["PostedByName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 160px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["UpdatedOn"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["UpdatedByName"] + "</td>");

                        //tableRow.Append("<td><a href='#' onclick='LoadMap(" + dt.Rows[i]["SmvId"] +")'>Edit</a></td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'><a href='BulkSmvPanel.aspx?Id=" + dt.Rows[i]["BulkSmvId"] + "'>Correction</a><br/>" +

                           "<a href='BulkRevisedPanel.aspx?Up=" + dt.Rows[i]["BulkSmvId"] + "'>Revised</a></td>");

                        tableRow.Append("</tr>");
                    }
                    tableRow.Append("</tbody>");
                }
                else
                {
                    tableRow.Append("<h3>No Data Found</h3>");
                }

            }
        }
        catch (Exception ex)
        {

        }
        return tableRow.ToString();
    }


//work place no 2
    public string LoadRevisedBulkSmvInfo(int buyerId, string styleNumber)
    {
        StringBuilder tableRow = new StringBuilder();

        DataTable dt = null;
        try
        {
            using (BulkSmvGateway smvGateway = new BulkSmvGateway())
            {

                dt = smvGateway.LoadRevisedBulkSmvInfo(buyerId, styleNumber);
                if (dt.Rows.Count > 0)
                {
                    int count = 0;
                    tableRow.Append("<thead ID='eventHead'><tr class='success' ID='eventTr'>" +
                                    "<th style='text-align:center;width: 55px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Sr No</th>" +
                                    "<th style='text-align:center;width: 100px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Buyer Name</th>" +
                                    "<th style='text-align:center;width: 190px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Sample Stage</th>" +
                                    "<th style='text-align:center;width: 120px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Style Number</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Style Descreption</th>" +
                                    "<th style='text-align:center;width: 120px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Fabric Type</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Product Category</th>" +
                                    "<th style='text-align:center;width: 90px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Sample Date</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Sewing SMV</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Overlay Film</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Fits SMV</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>PLK Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Auto Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Manual Quilting SMV</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Manual DownFill</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Machine DownFill</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Finishing Smv</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Total SMV</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Total Costing SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Saving In Minute</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Saving Percentage</th>" +


                                    // "<th style='text-align:center;'>Remarks</th>" +
                                    "<th style='text-align:center;width: 580px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Machine & Technical Concern</th>" +
                                    "<th style='text-align:center;width: 500px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Remarks</th>" +

                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Review By</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Approved By</th>" +

                                    "<th style='text-align:center;width: 160px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Posted On</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Posted By</th>" +
                                    "<th style='text-align:center;width: 160px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Updated On</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Updated By</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Edit</th>" +
                                    "</tr></thead><tbody ID='eventTb' style='text-align:center;'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tr ID='eventTd'>");
                        tableRow.Append("<td style='text-align:center;width: 55px;border: 1px solid #000000;border-color:black;'>" + count + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 100px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["BuyerName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 190px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["SampleStageName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 120px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["StyleDescription"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 120px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["FabricType"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ProductName"] + "</td>");
                        DateTime date = Convert.ToDateTime(dt.Rows[i]["SampleDate"]);
                        string datepart = date.ToString("yyyy-MM-dd");
                        if (datepart == "1900-01-01")
                        {
                            tableRow.Append("<td style='text-align:center;width: 90px;border: 1px solid #000000;background-color: #1012;color:black;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 90px;border: 1px solid #000000;background-color: #1012;color:black;'>" + datepart + "</td>");
                        }

                        //tableRow.Append("<td>" + dt.Rows[i]["SampleDate"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["SewingSmv"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OverlaySmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["FitsSmv"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["PlkQuelting"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["AutoQuelting"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ManualQuelting"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ManualDownfill"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["MachineDownfill"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["FinishingSmv"] + "</td>");


                        tableRow.Append("<td class='success' style='text-align:center;width: 75px;#000000;background-color: #1012;color:black;'>" + dt.Rows[i]["TotalBulkSmv"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["TotalCostingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["SavingInMinute"] + "</td>");

                        decimal percentd = Convert.ToDecimal(dt.Rows[i]["SavingPercentage"]);
                        string percent = percentd.ToString("#,##0.00");
                        //percent = dt.Rows[i]["SavingPercentage"].ToString();
                        if (percent == "0.00" || percent == null)
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + percent + "%</td>");
                        }


                        //tableRow.Append("<td>" + dt.Rows[i]["WorkUpdate"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 580px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["MachineWork"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 500px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["Description"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["Review"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["Approved"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 160px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["PostedOn"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["PostedByName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 160px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["UpdatedOn"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["UpdatedByName"] + "</td>");

                        //tableRow.Append("<td><a href='#' onclick='LoadMap(" + dt.Rows[i]["SmvId"] +")'>Edit</a></td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'><a href='BulkRevisedPanel.aspx?Id=" + dt.Rows[i]["BulkSmvId"] + "'>Correction</a><br/>" +

                           "<a href='BulkRevisedPanel.aspx?Up=" + dt.Rows[i]["BulkSmvId"] + "'>Revised</a></td>");

                        tableRow.Append("</tr>");
                    }
                    tableRow.Append("</tbody>");
                }
                else
                {
                    tableRow.Append("<h3>No Data Found</h3>");
                }

            }
        }
        catch (Exception ex)
        {

        }
        return tableRow.ToString();
    }



    public DataTable LoadCostingInfoInfoForUpdate(int bulkSmvId)
    {
        DataTable dt = null;
        try
        {
            using (BulkSmvGateway smvGateway = new BulkSmvGateway())
            {
                dt = smvGateway.LoadBulkInfoForUpdate(bulkSmvId);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public int UpdateBulkSmv(BulkSmv bulk)
    {
        int actionResult = 0;
        try
        {
            using (BulkSmvGateway smvGateway = new BulkSmvGateway())
            {
                actionResult = smvGateway.UpdateBulkInfo(bulk);
            }
        }
        catch (Exception ex)
        {

        }
        return actionResult;
    }

    public string LoadBulkSmvReports(int buyerId, string styleNumber)
    {


        StringBuilder tableRow = new StringBuilder();

        DataTable dt = null;
        try
        {
            using (BulkSmvGateway bulkGateway = new BulkSmvGateway())
            {
                dt = bulkGateway.LoadBulkSmvreportInfo(buyerId, styleNumber);

                if(buyerId==0 && styleNumber == "")
                {
                    if (dt.Rows.Count > 0)
                    {
                        int count = 0;
                        tableRow.Append("<thead><tr class='success'>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Sr No</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Buyer Name</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Sample Stage</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Style Number</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Style Descreption</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Fabric Type</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Product Category</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Season</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Sewing SMV</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>OverlayFilm</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Fits SMV</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>PLK Quilting SMV</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Auto Quilting SMV</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Manual Quilting SMV</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Manual DownFill</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Machine DownFill</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Finishing Smv</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Total Bulk SMV</th>" +

                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Total Costing Smv</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Saving In Minute</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Saving Percentage</th>" +

                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;padding: 0 150px 0 150px;'>Remarks</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;padding: 0 150px 0 150px;'>Machine & Technical Concern</th>" +
                                        //"<th style='text-align:center;'>Remarks</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Sample Date</th>" +

                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Review By</th>" +
                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;'>Approved By</th>" +
                                        "</tr></thead><tbody style='text-align:center;border: 1px solid #ddd; padding: 8px;'>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            count++;

                            tableRow.Append("<tr> ");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + count + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["BuyerName"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["SampleStageName"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["StyleNumber"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["StyleDescription"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["FabricType"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["ProductName"] + "</td>");
							tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["Season"] + "</td>");
							tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["SewingSmv"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["OverlaySmv"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["FitsSmv"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["PlkQuelting"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["AutoQuelting"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["ManualQuelting"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["ManualDownfill"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["MachineDownfill"] + "</td>");

                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["FinishingSmv"] + "</td>");

                            tableRow.Append("<td class='success'style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["TotalBulkSmv"] + "</td>");

                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["TotalCostingSmv"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["SavingInMinute"] + "</td>");
                            //tableRow.Append("<td style='text-align:center;border: 1px solid #ddd; padding: 8px;'>" + dt.Rows[i]["SavingPercentage"] + "</td>");

                            decimal percentd = Convert.ToDecimal(dt.Rows[i]["SavingPercentage"]);
                            string percent = percentd.ToString("#,##0.00");
                            //percent =dt.Rows[i]["SavingPercentage"].ToString();
                            if (percent == "0.00" || percent == null)
                                
                            {
                                tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + "" + "</td>");
                            }
                            else
                            {
                                tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + percent + "%</td>");
                            }


                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["Description"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["MachineWork"] + "</td>");
                            //tableRow.Append("<td>" + dt.Rows[i]["WorkUpdate"] + "</td>");

                            DateTime date = Convert.ToDateTime(dt.Rows[i]["SampleDate"]);
                            string datepart = date.ToString("yyyy-MM-dd");
                            if (datepart == "1900-01-01")
                            {
                                tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + "" + "</td>");
                            }
                            else
                            {
                                tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + datepart + "</td>");
                            }
                            //tableRow.Append("<td>" + dt.Rows[i]["SampleDate"] + "</td>");

                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["ReviweByName"] + "</td>");
                            tableRow.Append("<td style='text-align:center;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black; padding: 8px;'>" + dt.Rows[i]["ApprovedByName"] + "</td>");




                            tableRow.Append("</tr>");
                        }
                        tableRow.Append("</tbody>");
                    }
                    else
                    {
                        tableRow.Append("<h3>No Data Found</h3>");
                    }
                }




                else
                {
                    if (dt.Rows.Count > 0)
                    {
                        tableRow.Append("<thead>"
                                       + "<tr>"
                                       + "<td colspan = '10' style = 'text-align: center;border: 1px solid #ddd;padding: 1px;color: #ffffff; background-color:#1F618D;font-family: Arial Black;'><b> HIRDARAMANI BANGLADESH </b></td>"
                                       + "</tr>"
                                       + "</thead>"

                                       + "<tbody>"

                                        + "<tr>"
                                        + "<td colspan = '10' style ='text-align: center;border: 1px solid #ddd;padding: 1px;color: #ffffff; background-color:#1F618D;font-family: Arial Black;' > Pre - Production IE team -Bulk SMV Format</td>"
                                        + "</tr>"

                                        + "<tr>"
                                        + "<td colspan = '2' style ='border: 1px solid #ddd; padding: 1px;color:#5DADE2;font-size:12px;'> <b>Buyer </b></td>"
                                        + "<td colspan = '4' style ='border: 1px solid #ddd; padding: 1px;font-size:12px;'> " + dt.Rows[0]["BuyerName"] + " </td>"
                                        + "<td colspan = '2' style ='border: 1px solid #ddd; padding: 1px;color:#5DADE2;font-size:12px;'><b> Product Category </b></td>"
                                        + "<td colspan = '4' style ='border: 1px solid #ddd; padding: 1px;font-size:12px;'> " + dt.Rows[0]["ProductName"] + " </td>"
                                        + "</tr>"

                                         + "<tr>"
                                              + "<td colspan = '2' style ='border: 1px solid #ddd; padding: 1px;color:#5DADE2;font-size:12px;'> <b>Style # </b></td>"
                                              + "<td colspan = '4' style ='border: 1px solid #ddd; padding: 1px;font-size:12px;'> " + dt.Rows[0]["StyleNumber"] + " </td>"
                                              + "<td colspan = '2' style ='border: 1px solid #ddd; padding: 1px;color:#5DADE2;font-size:12px;'><b> Style Description</b></td>"
                                              + "<td colspan = '4' style ='border: 1px solid #ddd; padding: 1px;font-size:12px;'> " + dt.Rows[0]["StyleDescription"] + "</td>"
                                         + "</tr>"

                                         + "<tr>"
                                              + "<td colspan = '2' style ='border: 1px solid #ddd; padding: 1px;color:#5DADE2;font-size:12px;'><b> Fabrics Details </b></td>"
                                              + "<td colspan = '4' style ='border: 1px solid #ddd; padding: 1px;font-size:12px;'> " + dt.Rows[0]["FabricType"] + " </td>"
											  + "<td colspan = '2' style ='border: 1px solid #ddd; padding: 1px;color:#5DADE2;font-size:12px;'><b> Season </b></td>"
											  + "<td colspan = '4' style ='border: 1px solid #ddd; padding: 1px;font-size:12px;'> " + dt.Rows[0]["Season"] + " </td>"
										 + "</tr>"
                                    );

                        tableRow.Append("<tr>");
                        tableRow.Append("<td colspan = '2' style ='border: 1px solid #ddd; padding: 1px;color:#5DADE2;font-size:12px;'><b> Machinery & Technical Constrain </b></td>");
                        tableRow.Append("<td colspan = '8' style = 'text-align: center;border: 1px solid #ddd;padding: 1px;font-size:12px;'>" + dt.Rows[0]["MachineWork"] + "</td>");
                        tableRow.Append("</tr>");

                        //tableRow.Append("<tr>"
                        //                     + "<td colspan = '2' style ='border: 1px solid #ddd; padding: 8px;'><b>Sample Stage </b></td>"
                        //                     + "<td colspan = '4' style ='border: 1px solid #ddd; padding: 8px;'><b>Machinery Concern </b></td>"
                        //                 + "</tr>");

                        //if (dt.Rows.Count > 1)
                        //{
                        //    for (int i = 0; i < dt.Rows.Count; i++)
                        //    {
                        //        tableRow.Append("<tr>"
                        //                     + "<td colspan = '2' style ='border: 1px solid #ddd; padding: 8px;'>" + dt.Rows[i]["SampleStageName"] + "</td>"
                        //                     + "<td colspan = '4' style ='border: 1px solid #ddd; padding: 8px;'>" + dt.Rows[i]["MachineWork"] + "</td>"
                        //                 + "</tr>");
                        //    }
                        //}
                        //else
                        //{
                            
                        //}
                        tableRow.Append("<tr>");
                        tableRow.Append("<td colspan = '10' style = 'text-align: center;border: 1px solid #ddd;padding: 1px;color: #ffffff; background-color:#1F618D;font-family: Arial Black;'><b> Bulk SMV Details </b></td>");
                        tableRow.Append("</tr>");

                        tableRow.Append("<tr>"
                                       + " <td style = 'text-align: center;border: 1px solid #ddd;padding: 1px;color:#5DADE2;vertical-align:middle;font-size:12px;'> <b>Sample stage</b></td>"
                                       + " <td style = 'text-align: center;border: 1px solid #ddd;padding: 1px;color:#5DADE2;vertical-align:middle;font-size:12px;'><b> Sewing </b></td>");
                        tableRow.Append(" <td style = 'text-align: center;border: 1px solid #ddd;padding: 1px;color:#5DADE2;vertical-align:middle;font-size:12px;'><b>Quilting </b></td>");
                        tableRow.Append(" <td style = 'text-align: center;border: 1px solid #ddd;padding: 1px;color:#5DADE2;vertical-align:middle;font-size:12px;'><b>DownFill </b></td>");
                        tableRow.Append(" <td style = 'text-align: center;border: 1px solid #ddd;padding: 1px;color:#5DADE2;vertical-align:middle;font-size:12px;'><b>Heat Seal </b></td>");
                        tableRow.Append(" <td style = 'text-align: center;border: 1px solid #ddd;padding: 1px;color:#5DADE2;vertical-align:middle;font-size:12px;'><b>Finishing </b></td>");
                        tableRow.Append(" <td style = 'text-align: center;border: 1px solid #ddd;padding: 1px;color:#000000;vertical-align:middle;font-size:12px;' class='success'><b> Total Bulk SMV</b></td>");
                        tableRow.Append(" <td style = 'text-align: center;border: 1px solid #ddd;padding: 1px;color:#000000;vertical-align:middle;font-size:12px; background-color:#F1948A;'><b> Costing Smv</b></td>");
                        tableRow.Append(" <td style = 'text-align: center;border: 1px solid #ddd;padding: 1px;color:#000000;vertical-align:middle;font-size:12px; background-color:#F9E79F;'><b> Saving In Minute</b></td>");
                        tableRow.Append(" <td style = 'text-align: center;border: 1px solid #ddd;padding: 1px;color:#000000;vertical-align:middle;font-size:12px; background-color:#82E0AA;'><b> Saving Percentage</b></td>");
                        tableRow.Append("</tr>");
                        if (dt.Rows.Count > 1)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                //tableRow.Append("<tr>"
                                //       + " <td> Sample stage</td>"
                                //       + " <td> Sewing smv</td>");
                                //tableRow.Append(" <td>Heat SMV</td>");
                                //tableRow.Append(" <td>Quilting SMV</td>");
                                //tableRow.Append(" <td>DownFill SMV</td>");




                                //if (dt.Rows[i]["OverlaySmv"].ToString() != "0.00")
                                //{
                                //    tableRow.Append(" <td>Overlay Flim</td>");
                                //}
                                //else
                                //{
                                //    tableRow.Append(" <td>Fits Smv</td>");
                                //}

                                //if (dt.Rows[i]["PlkQuelting"].ToString() != "0.00")
                                //{
                                //    tableRow.Append(" <td>PLK Quilting</td>");
                                //}
                                //else if (dt.Rows[i]["AutoQuelting"].ToString() != "0.00")
                                //{
                                //    tableRow.Append(" <td>Auto Quilting</td>");
                                //}
                                //else
                                //{
                                //    tableRow.Append(" <td>Manual Quilting</td>");
                                //}

                                //if (dt.Rows[i]["ManualDownfill"].ToString() != "0.00")
                                //{
                                //    tableRow.Append(" <td>Manual DownFill</td>");
                                //}
                                //else
                                //{
                                //    tableRow.Append(" <td>Machine DownFill</td>");
                                //}



                                //tableRow.Append(" <td> Total Bulk Smv </td>");
                                //tableRow.Append("</tr>");



                                tableRow.Append("<tr>"
                                                 + "<td style = 'text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[i]["SampleStageName"] + "</td>"
                                                 + "<td style = 'text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[i]["SewingSmv"] + "</td>");

                                if (dt.Rows[i]["OverlaySmv"].ToString() != "0.00")
                                {
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[i]["OverlaySmv"] + " <b>(Overlay)</b></td>");
                                }
                                else
                                {
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[i]["FitsSmv"] + " <b>(Fits)</b></td>");
                                }



                                if (dt.Rows[i]["PlkQuelting"].ToString() != "0.00")
                                {
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[i]["PlkQuelting"] + " <b>(PLK)</b></td>");
                                }
                                else if (dt.Rows[i]["AutoQuelting"].ToString() != "0.00")
                                {
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[i]["AutoQuelting"] + " <b>(Auto)</b></td>");
                                }
                                else
                                {
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[i]["ManualQuelting"] + " <b>(Manual)</b></td>");
                                }



                                if (dt.Rows[i]["ManualDownfill"].ToString() != "0.00")
                                {
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[i]["ManualDownfill"] + " <b>(Manual)</b></td>");
                                }
                                else
                                {
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[i]["MachineDownfill"] + " <b>(Machine)</b></td>");
                                }

                                tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'><b>" + dt.Rows[i]["FinishingSmv"] + "</b></td>");

                                tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;color:#000000;font-size:11px;' class='success'><b>" + dt.Rows[i]["TotalBulkSmv"] + "</b></td>");

                                tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px; background-color:#F1948A;color:#000000;font-size:11px;'><b>" + dt.Rows[i]["TotalCostingSmv"] + "</b></td>");
                                tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px; background-color:#F9E79F;color:#000000;font-size:11px;'><b>" + dt.Rows[i]["SavingInMinute"] + "</b></td>");
                                //tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;'><b>" + dt.Rows[i]["SavingPercentage"] + "</b></td>");

                                decimal percentd = Convert.ToDecimal(dt.Rows[i]["SavingPercentage"]);
                                string percent = percentd.ToString("#,##0.00");
                                //percent =dt.Rows[i]["SavingPercentage"].ToString();
                                if (percent == "0.00" || percent == null)
                                {
                                    //tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #ddd;padding: 1px;'>" + "" + "</td>");
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px; background-color:#82E0AA;color:#000000;'><b>" + "" + "</b></td>");
                                }
                                else
                                {
                                    //tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #ddd;padding: 1px;'>" + percent + "%</td>");
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;background-color:#82E0AA;color:#000000;font-size:11px;'><b>" + percent + "%</b></td>");
                                }


                                tableRow.Append("</tr>");
                            }

                        }
                        else
                        {
                            {
                                //tableRow.Append("<tr>"
                                //       + " <td> Sample stage</td>"
                                //       + " <td> Sewing smv</td>");
                                //tableRow.Append(" <td>Heat SMV</td>");
                                //tableRow.Append(" <td>Quilting SMV</td>");
                                //tableRow.Append(" <td>DownFill SMV</td>");

                                //if (dt.Rows[0]["OverlaySmv"].ToString() != "0.00")
                                //{
                                //    tableRow.Append(" <td>Overlay Flim</td>");
                                //}
                                //else
                                //{
                                //    tableRow.Append(" <td>Fits Smv</td>");
                                //}




                                //if (dt.Rows[0]["PlkQuelting"].ToString() != "0.00")
                                //{
                                //    tableRow.Append(" <td>PLK Quilting</td>");
                                //}
                                //else if (dt.Rows[0]["AutoQuelting"].ToString() != "0.00")
                                //{
                                //    tableRow.Append(" <td>Auto Quilting</td>");
                                //}
                                //else
                                //{
                                //    tableRow.Append(" <td>Manual Quilting</td>");
                                //}






                                //if (dt.Rows[0]["ManualDownfill"].ToString() != "0.00")
                                //{
                                //    tableRow.Append(" <td>Manual DownFill</td>");
                                //}
                                //else
                                //{
                                //    tableRow.Append(" <td>Machine DownFill</td>");
                                //}


                                //tableRow.Append(" <td> Total Bulk Smv </td>");
                                //tableRow.Append("</tr>");



                                tableRow.Append("<tr>"
                                                 + "<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[0]["SampleStageName"] + "</td>"
                                                 + "<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[0]["SewingSmv"] + "</td>");

                                if (dt.Rows[0]["OverlaySmv"].ToString() != "0.00")
                                {
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[0]["OverlaySmv"] + " <b>(Overlay)</b></td>");
                                }
                                else
                                {
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[0]["FitsSmv"] + " <b>(Fits)</b></td>");
                                }



                                if (dt.Rows[0]["PlkQuelting"].ToString() != "0.00")
                                {
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[0]["PlkQuelting"] + " <b>(Plk)</b></td>");
                                }
                                else if (dt.Rows[0]["AutoQuelting"].ToString() != "0.00")
                                {
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[0]["AutoQuelting"] + " <b>(Auto)</b></td>");
                                }
                                else
                                {
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[0]["ManualQuelting"] + " <b>(Manual)</b></td>");
                                }



                                if (dt.Rows[0]["ManualDownfill"].ToString() != "0.00")
                                {
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[0]["ManualDownfill"] + " <b>(Manual)</b></td>");
                                }
                                else
                                {
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[0]["MachineDownfill"] + " <b>(Machine)</b></td>");
                                }

                                tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'><b>" + dt.Rows[0]["FinishingSmv"] + "</b></td>");

                                tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;color:#000000;font-size:11px;' class='success'><b>" + dt.Rows[0]["TotalBulkSmv"] + "</b></td>");

                                tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px; background-color:#F1948A;color:#000000;font-size:11px;'><b>" + dt.Rows[0]["TotalCostingSmv"] + "</b></td>");
                                tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;background-color:#F9E79F;color:#000000;font-size:11px;'><b>" + dt.Rows[0]["SavingInMinute"] + "</b></td>");
                                //tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;'><b>" + dt.Rows[0]["SavingPercentage"] + "</b></td>");
                                decimal percentd = Convert.ToDecimal(dt.Rows[0]["SavingPercentage"]);
                                string percent = percentd.ToString("#,##0.00");
                                //percent =dt.Rows[i]["SavingPercentage"].ToString();
                                if (percent == "0.00" || percent == null)
                                {
                                    //tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #ddd;padding: 1px;'>" + "" + "</td>");
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;background-color:#82E0AA;color:#000000;font-size:11px;'><b>" + "" + "</b></td>");
                                }
                                else
                                {
                                    //tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #ddd;padding: 1px;'>" + percent + "%</td>");
                                    tableRow.Append("<td style ='text-align: center;border: 1px solid #ddd;padding: 1px;background-color:#82E0AA;color:#000000;font-size:11px;'><b>" + percent + "%</b></td>");
                                }


                                tableRow.Append("</tr>");
                            }
                        }


                        tableRow.Append("<tr>"
                                        + "<td colspan = '10' style = 'text-align: center;border: 1px solid #ddd;padding: 1px;color: #ffffff; background-color:#1F618D;font-family: Arial Black;'><b> Construction Remarks </b></td>"
                                        + "</tr>"
                                        + "<tr>"
                                            + "<td colspan = '2' style ='text-align: center;border: 1px solid #ddd;padding: 1px;color:#5DADE2;font-size:12px;'><b> Sample date</b></td>"
                                            + "<td colspan = '2' style ='text-align: center;border: 1px solid #ddd;padding: 1px;color:#5DADE2;font-size:12px;'><b> Sample Stage</b></td>"
                                            + "<td colspan = '6' style ='text-align: center;border: 1px solid #ddd;padding: 1px;color:#5DADE2;font-size:12px;'><b> Remarks </b></td>"
                                        // + "<td colspan = '2' > Remarks :</td>"
                                        + " </tr>");
                        if (dt.Rows.Count > 1)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                DateTime date = Convert.ToDateTime(dt.Rows[i]["SampleDate"]);
                                string datepart = date.ToString("yyyy-MM-dd");
                                if (datepart == "1900-01-01")
                                {
                                    datepart = "";
                                }

                                tableRow.Append("<tr>"
                                                 + " <td colspan = '2'style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + datepart + " </td>"
                                                 + " <td colspan = '2'style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[i]["SampleStageName"] + " </td>"
                                                 + " <td colspan = '6'style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[i]["Description"] + "  </td>"
                                                 //+ " <td colspan = '2'>" + dt.Rows[i]["WorkUpdate"] + "  </td>"                                                 
                                                 + " </tr>");
                            }
                        }
                        else
                        {
                            DateTime date = Convert.ToDateTime(dt.Rows[0]["SampleDate"]);
                            string datepart = date.ToString("yyyy-MM-dd");
                            if (datepart == "1900-01-01")
                            {
                                datepart = "";
                            }
                          
                            tableRow.Append("<tr>"
                                                + " <td colspan = '2'style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + datepart + " </td>"
                                                + " <td colspan = '2'style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[0]["SampleStageName"] + " </td>"
                                                + " <td colspan = '6'style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[0]["Description"] + "  </td>"
                                                //+ " <td colspan = '2'>" + dt.Rows[0]["WorkUpdate"] + "  </td>"                                               
                                         + " </tr>");
                        }


                        tableRow.Append(" <tr> "
                        + "<td colspan = '2'style ='text-align: center;border: 1px solid #ddd;padding: 1px;color: #ffffff; background-color:#1F618D;font-family: Arial Black;font-size:12px;'><b> Made By</b></td>"
                        + "<td colspan = '2'style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[0]["PostedByName"] + "</ td >"
                        + "<td colspan = '1'style ='text-align: center;border: 1px solid #ddd;padding: 1px;color: #ffffff; background-color:#1F618D;font-family: Arial Black;font-size:12px;'> <b>Review By </b></td>"
                        + "<td colspan = '2'style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[0]["ReviweByName"] + "</td>"
                        + "<td colspan = '1'style ='text-align: center;border: 1px solid #ddd;padding: 1px;color: #ffffff; background-color:#1F618D;font-family: Arial Black;font-size:12px;'> <b>Approved By </b></td>"
                        + "<td colspan = '2'style ='text-align: center;border: 1px solid #ddd;padding: 1px;font-size:11px;'>" + dt.Rows[0]["ApprovedByName"] + "</td>"
                    + "</tr>"
                + "</tbody>");
                    }
                    else
                    {
                        tableRow.Append("<h3>No Data Found</h3>");
                    }
                }
            }
        }
        catch(Exception ex)
        {

        }
        return tableRow.ToString();
    }

    public string LoadBulkSmvLogReports(int buyerId, string styleNumber)
    {
        StringBuilder tableRow = new StringBuilder();

        DataTable dt = null;
        try
        {
            using (BulkSmvGateway smvGateway = new BulkSmvGateway())
            {

                dt = smvGateway.LoadBulkSmvDetailsReportInfo(buyerId,styleNumber);
                if (dt.Rows.Count > 0)
                {
                    int count = 0;
                    tableRow.Append("<thead ID='eventHead'><tr class='success' ID='eventTr'>" +
                                    "<th style='text-align:center;width: 55px; border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Sr No</th>" +
                                    "<th style='text-align:center;width: 100px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Buyer Name</th>" +
                                    "<th style='text-align:center;width: 100px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Sample Stage</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Style Number</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Style Descreption</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Fabric Type</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Product Category</th>" +
                                    "<th style='text-align:center;width: 80px; border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Sample Date</th>" +

                                    "<th style='text-align:center;width: 70px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Sewing SMV</th>" +

                                    "<th style='text-align:center;width: 80px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Overlay Film</th>" +
                                    "<th style='text-align:center;width: 55px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Fits SMV</th>" +

                                    "<th style='text-align:center;width: 90px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>PLK Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 95px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Auto Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 110px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding:8px;'>Manual Quilting SMV</th>" +

                                    "<th style='text-align:center;width: 90px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Manual DownFill</th>" +
                                    "<th style='text-align:center;width: 95px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Machine DownFill</th>" +
                                    "<th style='text-align:center;width: 95px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Finishing SMV</th>" +

                                    "<th style='text-align:center;width: 55px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Total SMV</th>" +

                                    "<th style='text-align:center;width: 95px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Total Costing Smv</th>" +
                                    "<th style='text-align:center;width: 95px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Saving In Minute</th>" +
                                    "<th style='text-align:center;width: 95px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Saving Percentage</th>" +

                                    // "<th style='text-align:center;'>Remarks</th>" +
                                    "<th style='text-align:center;width: 450px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Machine & Technical Concern</th>" +
                                    "<th style='text-align:center;width: 500px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Remarks</th>" +

                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Review By</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Approved By</th>" +
                                    "<th style='text-align:center;width: 65px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Posted On</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;'>Posted By</th>" +
                                    "</tr></thead><tbody ID='eventTb' style='text-align:center;'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tr ID='eventTd'>");
                        tableRow.Append("<td style='text-align:center;width: 55px; border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;;padding: 1px;'>" + count + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 100px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["BuyerName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 100px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["SampleStageName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["StyleDescription"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["FabricType"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["ProductName"] + "</td>");
                        DateTime date = Convert.ToDateTime(dt.Rows[i]["SampleDate"]);
                        string datepart = date.ToString("yyyy-MM-dd");
                        if (datepart == "1900-01-01")
                        {
                            tableRow.Append("<td style='text-align:center;width: 80px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 80px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + datepart + "</td>");
                        }

                        //tableRow.Append("<td>" + dt.Rows[i]["SampleDate"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 70px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["SewingSmv"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 80px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["OverlaySmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 55px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["FitsSmv"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 90px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["PlkQuelting"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["AutoQuelting"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 110px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["ManualQuelting"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 90px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["ManualDownfill"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["MachineDownfill"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["FinishingSmv"] + "</td>");

                        tableRow.Append("<td class='success' style='text-align:center;width: 55px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["TotalBulkSmv"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["TotalCostingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["SavingInMinute"] + "</td>");
                        //tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #ddd;padding: 1px;'>" + dt.Rows[i]["SavingPercentage"] +"% </td>");

                        decimal percentd = Convert.ToDecimal(dt.Rows[i]["SavingPercentage"]);
                        string percent = percentd.ToString("#,##0.00");
                        //percent =dt.Rows[i]["SavingPercentage"].ToString();
                        if (percent == "0.00" || percent == null)
                        {
                            tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + percent + "%</td>");
                        }

                        //tableRow.Append("<td>" + dt.Rows[i]["WorkUpdate"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 450px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["MachineWork"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 500px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["Description"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["ReviweByName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["ApprovedByName"] + "</td>");
                       // tableRow.Append("<td style='text-align:center;width: 100px;border: 1px solid #ddd;padding: 1px;'>" + dt.Rows[i]["PostedOn"] + "</td>");

                        DateTime date2 = Convert.ToDateTime(dt.Rows[i]["PostedOn"]);
                        string datepart2 = date2.ToString("yyyy-MM-dd");

                        if (datepart == "1900-01-01")
                        {
                            tableRow.Append("<td style='text-align:center;width: 65px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 65px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + datepart2 + "</td>");
                        }

                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["PostedByName"] + "</td>");

                        tableRow.Append("</tr>");
                    }
                    tableRow.Append("</tbody>");
                }
                else
                {
                    tableRow.Append("<h3>No Data Found</h3>");
                }

            }
        }
        catch (Exception ex)
        {

        }
        return tableRow.ToString();
    }






    public string LoadBuyersStyleInfoFromBulk(string fromDate, string toDate)
    {
        DataTable dt = null;
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (BulkSmvGateway bulkGateway=new BulkSmvGateway())
            {
                int count = 0;
                dt = bulkGateway.LoadBuyersStyleInfoFromBulk(fromDate, toDate);
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered' style='width: 80%;margin-left: 10%;'><thead><tr class='success'>" +
                                    "<th style='text-align:center;width: 95px;border: 1px solid #080808;padding: 8px; color: #FFFFFF; background-color:#0099FF;'>Serial No</th>" +
                                    "<th style='text-align:center;width: 95px;border: 1px solid #080808;padding: 8px; color: #FFFFFF; background-color:#0099FF; '>Buyer Name</th>" +
                                    "<th style='text-align:center;width: 95px;border: 1px solid #080808;padding: 8px; color: #FFFFFF; background-color:#0099FF;'>Style Number</th>" +
                                    "<th style='text-align:center;width: 95px;border: 1px solid #080808;padding: 8px; color:#FFFFFF; background-color:#0099FF; '>Sewing Smv</th>" +
                                    "<th style='text-align:center;width: 95px;border: 1px solid #080808;padding: 8px; color: #FFFFFF; background-color:#0099FF; '>Posted On</th>" +
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr>");

                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808;'>" + count + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808;'>" + dt.Rows[i]["BuyerName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808;'>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808;'>" + dt.Rows[i]["SewingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808;'>" + dt.Rows[i]["PostedOn"] + "</td>");
                        tableRow.Append("</tr></tbody>");
                    }
                    tableRow.Append("</table>");
                }
                else
                {
                    tableRow.Append("No Data Found");
                }
            }
        }
        catch (Exception)
        {

        }
        return tableRow.ToString();
    }
    public string LoadComponentSmv(int BuyerId, string StyleNumber)
    {
        DataTable dt = null;
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (BulkSmvGateway bulkGateway = new BulkSmvGateway())
            {
                int count = 0;
                dt = bulkGateway.LoadComponentSmv(BuyerId, StyleNumber);
                if(dt.Rows.Count>0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                        "<th style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808; background-color:#ABB2B9;'>Sr No.</th>" +
                                   "<th style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808; background-color:#ABB2B9;'>Buyer Name</th>" +
                                   "<th style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808; background-color:#ABB2B9; '>Style Number</th>" +
                                   "<th style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808; background-color:#ABB2B9;'>Costing Smv</th>" +
                                   "<th style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808; background-color:#ABB2B9; '>Sewing Smv</th>" +
                                   "<th style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808; background-color:#ABB2B9; '>Saving Minute</th>" +
                                    "<th style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808; background-color:#ABB2B9; '>Posted By</th>" +
                                     "<th style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808; background-color:#ABB2B9; '>Posted On</th>" +
                                   "</tr></thead >");
                    for(int i=0; i< dt.Rows.Count; i++)
                    {
                        count++;
                        tableRow.Append("<tbody><tr>");

                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808;'>" + count + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808;'>" + dt.Rows[i]["BuyerName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808;'>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808;'>" + dt.Rows[i]["TotalCostingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808;'>" + dt.Rows[i]["SewingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808;'>" + dt.Rows[i]["SavingInMinute"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808;'>" + dt.Rows[i]["PostedByName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 95px;border: 1px solid #080808;padding: 1px; color: #080808;'>" + dt.Rows[i]["PostedOn"] + "</td>");
                        tableRow.Append("</tr></tbody>");
                    }
                    tableRow.Append("</table>");
                }
                else
                {
                    tableRow.Append("No Data Found");
                }
            }
        }
        catch(Exception ex)
        {

        }
        return tableRow.ToString();
    }

}