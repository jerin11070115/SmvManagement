using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for SmvBLL
/// </summary>
public class SmvBLL
{

    public SmvBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //public DataTable LoadStyleNumber()
    //{
    //    DataTable dt = null;
    //    try
    //    {
    //        using (SmvEntryGateway smvEntryGateway = new SmvEntryGateway())
    //        {
    //            dt = smvEntryGateway.LoadStyelNumber();
    //        }
    //    }
    //    catch(Exception ex)
    //    {

    //    }
    //    return dt;
    //}

    public DataTable LoadProductCategory()
    {
        DataTable dt = null;
        try
        {
            using (ProductGateway productGateway = new ProductGateway())
            {
                dt = productGateway.LoadProductsInfo();
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable LoadFabricType()
    {
        DataTable dt = null;
        try
        {
            using (SmvEntryGateway smvEntryGateway = new SmvEntryGateway())
            {
                dt = smvEntryGateway.LoadFabric();
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public DataTable InsertCostingSmvInfo(CostingSmv smv, DataTable data)
    {
        DataTable dt = null;
        try
        {
            using (SmvEntryGateway smvGateway = new SmvEntryGateway())
            {
                dt = smvGateway.InsertCostingSMV(smv, data);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    public DataTable InsertNewCostingSmvInfo(CostingSmv smv, DataTable data)
    {
        DataTable dt = null;
        try
        {
            using (SmvEntryGateway smvGateway = new SmvEntryGateway())
            {
                dt = smvGateway.InsertNewCostingSMV(smv, data);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    public string LoadCostingSmvInfo(int buyerId, string StyleNumber)
    {
        StringBuilder tableRow = new StringBuilder();

        DataTable dt = null;
        try
        {
            using (SmvEntryGateway smvGateway = new SmvEntryGateway())
            {

                dt = smvGateway.LoadNewCostingSmvInfo(buyerId, StyleNumber);
                if (dt.Rows.Count > 0)
                {
                    int count = 0;
                    tableRow.Append("<thead ID='eventHead'><tr class='success' ID='eventTr'>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Sr No</th>" +
                                    "<th style='text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Buyer Name</th>" +
                                    "<th style='text-align:center;width: 100px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Sample Stage</th>" +
                                    "<th style='text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Style Number</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Style Description</th>" +
                                    "<th style='text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Design Number</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Fabric Type</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Product Category</th>" +
                                    "<th style='text-align:center;width: 100px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Season</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Sample Date</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Sewing SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Pleating SMV</th>" +

                                    "<th style='text-align:center;width: 85px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Permanent Crease</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Supper Crease</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Heat Seal</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Overlay Film</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Heat SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>PLK Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Auto Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Manual Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Manual DownFill</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Machine DownFill</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Down Fill SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Lycra Breakage SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Bonding</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Cutting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Finishing SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Others Value</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Others Description</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Option Value</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Option Additional Value</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Option Description</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Option Number</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Option Remarks</th>" +

                                    //"<th style='text-align:center;width: 75px;'>Total SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Valid SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Non-Valid SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Review By</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Approved By</th>" +
                                    "<th style='text-align:center;width: 350px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Machine & Technical Concern</th>" +
                                    "<th style='text-align:center;width: 350px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Remarks</th>" +
                                    "<th style='text-align:center;width: 90px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Posted On</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Posted By</th>" +
                                    "<th style='text-align:center;width: 90px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Updated On</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Updated By</th>" +
                                    "<th style='text-align:center;width: 75px; border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Action</th>" +
                                    "</tr></thead><tbody ID='eventTb' style='text-align:center;'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tr ID='eventTd'> ");
                        tableRow.Append("<td style='text-align:center;width: 40px;border: 1px solid #000000;'>" + count + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["BuyerName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 100px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["SampleStageName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["StyleDescription"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["DesignNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["FabricType"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ProductName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 100px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["Season"] + "</td>");

                        DateTime date = Convert.ToDateTime(dt.Rows[i]["SampleDate"]);
                        string datepart = date.ToString("yyyy-MM-dd");
                        if (datepart == "1900-01-01")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + datepart + "</td>");
                        }


                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["SwingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["PleatingSmv"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 85px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["PermanentCrease"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["SupperCrease"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["HeatSeal"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OverlayFilm"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["HeatSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["PLKQuiltingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["AutoQuiltingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ManualQuiltingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["QuiltingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ManualDownFill"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["MachineDownFill"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["DownFillSMV"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["SeamSeal"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["Bonding"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["CuttingSMV"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["FinisingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OthersValue"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OthersDescription"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OptionValue"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OptionAdditionalValue"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OptionDescription"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OptionNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OptionRemarks"] + "</td>");

                        //tableRow.Append("<td class='success' style='text-align:center;width: 75px;'>" + dt.Rows[i]["TotalSMV"] + "</td>");
                        tableRow.Append("<td class='active' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ValuableSmv"] + "</td>");
                        tableRow.Append("<td class='info' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["NonValuableSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ReviewByName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ApprovedByName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 350px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["MachineWork"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 350px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["Remarks"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 90px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["PostedOn"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["PostedByName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 90px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["UpdatedOn"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["UpdatedByName"] + "</td>");



                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #fff;'><a href='CostingRevisedPanel.aspx?Id=" + dt.Rows[i]["SmvId"] + "'>Revised</a><br/>" +
                                                                                                                "<a href='CostingSmvPanel.aspx?Id=" + dt.Rows[i]["SmvId"] + "'>Correction</a><br/>" +
                                                                                                                "<a href='CostingOption.aspx?Option=" + dt.Rows[i]["SmvId"] + "'>Option Update</a><br/>" +
                                                                                                                "<a href='BulkSmvPanel.aspx?SmvValue=" + dt.Rows[i]["SmvId"] + "'>Set Bulk</a></td>"); 



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

    public DataTable LoadCostingInfoInfoForUpdate(int SmvId)
    {
        DataTable dt = null;
        try
        {
            using (SmvEntryGateway smvGateway = new SmvEntryGateway())
            {
                dt = smvGateway.LoadCostingInfoInfoForUpdate(SmvId);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public int UpdateCostingSmv(CostingSmv smv, DataTable data)
    {
        int actionResult = 0;
        try
        {
            using (SmvEntryGateway smvGateway = new SmvEntryGateway())
            {
                actionResult = smvGateway.UpdateCostingSmv(smv,data);
            }
        }
        catch (Exception ex)
        {

        }
        return actionResult;
    }



    public string ReportCostingSmvInfo(int BuyerId, string StyleNumber)
    {
        StringBuilder tableRow = new StringBuilder();

        DataTable dt = null;
        DataTable optionData = null;
        try
        {
            using (SmvEntryGateway smvGateway = new SmvEntryGateway())
            {

                dt = smvGateway.LoadCostingSmvReport(BuyerId, StyleNumber);
                if (StyleNumber == "" && BuyerId == 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        int count = 0;
                        tableRow.Append("<thead ID='eventHead'><tr class='success' ID='eventTr'>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690; padding: 8px;text-align:center;width: 55px;'>Sr No</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 120px;white-space: normal !important;word - wrap: break-word;'>Buyer Name</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 100px;'>Sample Stage</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;'>Style Number</th>" +

                                        "<th style='text-align:center;width: 115px; border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px; '>Style Description</th>" +

                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;'>Design Number</th>" +

                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px; text-align:center;width: 90px;'>Fabric Type</th>" +

                                        "<th style='text-align:center; border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;width: 90px;'>Product Category</th>" +
                                        "<th style='text-align:center; border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;width: 90px;'>Season</th>" +
                                        //"<th style='text-align:center;'>Department</th>" +

                                        "<th style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px; width: 75px;'>Sample Date</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Sewing SMV</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Pleating SMV</th>" +

                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 90px;'>Permanent Crease</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Supper Crease</th>" +

                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Heat Seal</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Overlay Film</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Heat SMV</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>PLK Quilting SMV</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Auto Quilting SMV</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Manual Quilting SMV</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Quilting SMV</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Manual DownFill</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Machine DownFill</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Down Fill SMV</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Lycra Breakage SMV</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Bonding</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Cutting SMV</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Finishing SMV</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Others Value</th>" +

                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Others Additional Value</th>" +

                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 200px;'>Others Description</th>" +

                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Option Value</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 200px;'>Option Description</th>" +

                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Option number</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 200px;'>Option Remarks</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Total SMV</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Total Net SMV</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Valid SMV</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 75px;'>Non-Valid SMV</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 150px;'>Review By</th>" +
                                        "<th style ='border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 8px;text-align:center;width: 150px;'>Approved By</th>" +

                                    "<th style='text-align:center;width: 300px; border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Machine & Technical Concern</th>" +
                                    "<th style='text-align:center;width: 300px; border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Remarks</th>" +

                                        "</tr></thead><tbody ID='eventTb' style='text-align:center;'>");
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            count++;

                            tableRow.Append("<tr ID='eventTd'> ");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 55px;'>" + count + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 120px; width: 120px;white-space: normal !important;word - wrap: break-word;'>" + dt.Rows[i]["BuyerName"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 100px;'>" + dt.Rows[i]["SampleStageName"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;'>" + dt.Rows[i]["StyleNumber"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 115px;'>" + dt.Rows[i]["StyleDescription"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;'>" + dt.Rows[i]["DesignNumber"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 90px;'>" + dt.Rows[i]["FabricType"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 90px;'>" + dt.Rows[i]["ProductName"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 90px;'>" + dt.Rows[i]["Season"] + "</td>");

                            DateTime date = Convert.ToDateTime(dt.Rows[i]["SampleDate"]);
                            string datepart = date.ToString("yyyy-MM-dd");
                            if (datepart == "1900-01-01")
                            {
                                tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + "" + "</td>");
                            }
                            else
                            {
                                tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + datepart + "</td>");
                            }


                            //tableRow.Append("<td>" + dt.Rows[i]["SampleDate"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["SwingSmv"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["PleatingSmv"] + "</td>");

                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 90px;'>" + dt.Rows[i]["PermanentCrease"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["SupperCrease"] + "</td>");

                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["HeatSeal"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["OverlayFilm"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["HeatSmv"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["PLKQuiltingSmv"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["AutoQuiltingSmv"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["ManualQuiltingSmv"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["QuiltingSmv"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["ManualDownFill"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["MachineDownFill"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["DownFillSMV"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["SeamSeal"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["Bonding"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["CuttingSMV"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["FinisingSmv"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["OthersValue"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["OptionAdditionalValue"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 200px;'>" + dt.Rows[i]["OthersDescription"] + "</td>");



                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["OptionValue"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 200px;'>" + dt.Rows[i]["OptionDescription"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["OptionNumber"] + "</td>");

                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 200px;'>" + dt.Rows[i]["OptionRemarks"] + "</td>");

                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["TotalSMV"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["TotalNetSmv"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["ValuableSmv"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 75px;'>" + dt.Rows[i]["NonValuableSmv"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 150px;'>" + dt.Rows[i]["ReviewByName"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 8px;text-align:center;width: 150px;'>" + dt.Rows[i]["ApprovedByName"] + "</td>");
                            // tableRow.Append("<td  style='text-align:center; width: 200px;'>" + dt.Rows[i]["WorksUpdate"] + "</td>");
                            tableRow.Append("<td style='text-align:center;width: 300px; border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["MachineWork"] + "</td>");
                            tableRow.Append("<td style='text-align:center;width: 300px; border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;'>" + dt.Rows[i]["Remarks"] + "</td>");

                            tableRow.Append("</tr>");
                        }
                        tableRow.Append("</tbody>");
                    }
                    else
                    {
                        tableRow.Append("<h3>No Data Found</h3>");
                    }
                }

                else if (StyleNumber != "" && BuyerId != 0)
                {
                    if (dt.Rows.Count > 0)
                    {
                        tableRow.Append("<thead>"
                                       + "<tr>"
                                       + "<td colspan = '16' style = 'text-align: center;border: 1px solid #ddd;padding: 1px;border-collapse: collapse; color: #ffffff; background-color:#1F618D;font-family: Arial Black;'><b> HIRDARAMANI BANGLADESH </b></td>"
                                       + "</tr>"
                                       + "</thead>"

                                       + "<tbody>"

                                        + "<tr>"
                                        + "<td colspan = '16' style = 'text-align: center;border: 1px solid #ddd;padding: 1px;border-collapse: collapse; color: #ffffff; background-color:#1F618D;font-family: Arial Black;' > Pre - Production IE team - Costing SMV Format</td>"
                                        + "</tr>"

                                        + "<tr>"
                                        + "<td colspan = '3' style ='border: 1px solid #ddd;padding: 1px;border-collapse: collapse;color:#5DADE2;font-size:12px;'><b>Buyer </b></td>"
                                        + "<td colspan = '5' style ='border: 1px solid #ddd;padding: 1px;border-collapse: collapse;font-size:12px'> " + dt.Rows[0]["BuyerName"] + " </td>"
                                        + "<td colspan = '4' style ='border: 1px solid #ddd;padding: 1px;border-collapse: collapse;color:#5DADE2;font-size:12px;'><b>Product Category  </b></td>"
                                        + "<td colspan = '4' style ='border: 1px solid #ddd;padding: 1px;border-collapse: collapse;font-size:12px'>" + dt.Rows[0]["ProductName"] + " </td>"

                                        + "</tr>"

                                         + "<tr>"
                                              + "<td colspan = '3' style ='border: 1px solid #ddd;padding: 1px;border-collapse: collapse; color:#5DADE2;font-size:12px;'><b> Style # </b></td>"
                                              + "<td colspan = '3' style ='border: 1px solid #ddd;padding: 1px;border-collapse: collapse;font-size:12px'> " + dt.Rows[0]["StyleNumber"] + " </td>"
                                              + "<td colspan = '3' style ='border: 1px solid #ddd;padding: 1px;border-collapse: collapse;color:#5DADE2;font-size:12px;'><b> Design Number </b></td>"
                                              + "<td colspan = '3' style ='border: 1px solid #ddd;padding: 1px;border-collapse: collapse;font-size:12px'> " + dt.Rows[0]["DesignNumber"] + " </td>"
                                              + "<td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;border-collapse: collapse;color:#5DADE2;font-size:12px;'><b> Season </b></td>"
                                              + "<td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;border-collapse: collapse;font-size:12px'> " + dt.Rows[0]["Season"] + " </td>"
                                         + "</tr>"

                                         + "<tr>"
                                           + "<td colspan = '3' style ='border: 1px solid #ddd;padding: 1px;border-collapse: collapse;color:#5DADE2;font-size:12px;'><b> Style Description </b></td>"
                                           + "<td colspan = '5' style ='border: 1px solid #ddd;padding: 1px;border-collapse: collapse;font-size:12px'> " + dt.Rows[0]["StyleDescription"] + " </td>"
                                           + "<td colspan = '3' style ='border: 1px solid #ddd;padding: 1px; color:#5DADE2;font-size:12px;'><b> Fabrics Details </b></td>"
                                           + "<td colspan = '5' style ='border: 1px solid #ddd;padding: 1px;border-collapse: collapse;font-size:12px'> " + dt.Rows[0]["FabricType"] + " </td>"
                                           
                                         + "</tr>");
                        tableRow.Append("<tr>"
                                             + "<td colspan = '4' style = 'border: 1px solid #ddd;padding: 1px;color:#5DADE2;font-size:12px;'><b> Machinery & Technical Constrain </b></td>"
                                             + "<td colspan = '12' style ='border: 1px solid #ddd;padding: 1px;font-size:12px'>" + dt.Rows[0]["MachineWork"] + "</td>"
                                         +"</tr>");

                        


                        tableRow.Append("<tr>"
                                        + "<td colspan = '12' style = 'text-align: center;vertical-align:middle;border: 1px solid #ddd;padding: 1px;color: #ffffff; background-color:#1F618D;font-family: Arial Black;font-size:12px;'><b> Value Added (VA) Smv </b></td>"
                                        + "<td colspan = '3' style = 'text-align: center;vertical-align:middle;border: 1px solid #ddd;padding: 1px;color: #ffffff; background-color:#1F618D;font-family: Arial Black;font-size:12px;'> <b> Non Value Added (NVA) Smv </b></td>"
                                        + "<td colspan = '1' style = 'text-align: center;border:1px solid #ddd;padding:1px;background-color:#1F618D;'></td>"
                                    + "</tr>"
                                    );
                        //new add
                        tableRow.Append("<tr>"
                                       + " <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;vertical-align:middle;font-size:12px;'> <b>Sample stage</b> </td>"
                                       + " <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;vertical-align:middle;color:#000000;background-color:#82E0AA;vertical-align:middle;font-size:12px;'> <b>Sewing   </b> </td>"
                                       + " <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;vertical-align:middle;font-size:12px;'> <b>Pleating </b> </td>");

                        tableRow.Append(" <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;vertical-align:middle;font-size:12px;'><b>Permanent Crease    </b></td>");
                        tableRow.Append(" <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;vertical-align:middle;font-size:12px;'><b>Supper Crease    </b></td>");

                        tableRow.Append(" <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;vertical-align:middle;font-size:12px;'><b>Heat </b></td>");
                        tableRow.Append(" <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;vertical-align:middle;font-size:12px;'><b>Quilting </b></td>");
                        tableRow.Append(" <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;vertical-align:middle;font-size:12px;'><b>DownFill </b></td>");
                        tableRow.Append(" <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;vertical-align:middle;font-size:12px;'><b>Lycra Breakage SMV</b></td>");
                        tableRow.Append(" <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;vertical-align:middle;font-size:12px;'><b> Bonding </b> </td>"
                               + " <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;vertical-align:middle;font-size:12px;'> <b>Others Works  </b></td>"
                               + " <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#000000;background-color:#82E0AA;vertical-align:middle;font-size:11px;'> <b>Total VA SMV</b></td>"
                               + " <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;vertical-align:middle;font-size:12px;'> <b>Cutting    </b></td>"
                               + " <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;vertical-align:middle;font-size:12px;'> <b>Finishing  </b></td>"
                               + " <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#000000;background-color:#F1948A;vertical-align:middle;font-size:12px;'> <b>Total NVA Smv</b></td>"
                               + " <td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#000000;background-color:#F9E79F;vertical-align:middle;font-size:12px;'> <b>Grand Total</b></td>"
                               + " <td style ='padding: 1px;text-align: center;border-right:1px solid #ddd;border-left:1px solid #ddd;border-bottom:1px solid #ddd'>  </td>"
                               + "</tr>");
                        //end add
                        if (dt.Rows.Count > 1)
                        {
                            for (int i = 0; i < dt.Rows.Count; i++)
                            {
                                tableRow.Append("<tr>"
                                                 + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["SampleStageName"] + "</td>"
                                                 + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#000000;background-color:#82E0AA;font-size:11px'>" + dt.Rows[i]["SwingSmv"] + "</td>"
                                                 + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["PleatingSmv"] + "</td>");

                                tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["PermanentCrease"] + "</td>");
                                tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["SupperCrease"] + "</td>");

                                if (dt.Rows[i]["HeatSeal"].ToString() != "0.00")
                                {
                                    tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["HeatSeal"] + "  (Heat Seal)</td>");
                                }
                                else
                                {
                                    tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["OverlayFilm"] + " (Overlay)</td>");
                                }



                                if (dt.Rows[i]["PLKQuiltingSmv"].ToString() != "0.00")
                                {
                                    tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["PLKQuiltingSmv"] + " (PLK)</td>");
                                }
                                else if (dt.Rows[i]["AutoQuiltingSmv"].ToString() != "0.00")
                                {
                                    tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["AutoQuiltingSmv"] + " (Auto)</td>");
                                }
                                else
                                {
                                    tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["ManualQuiltingSmv"] + " (Manual)</td>");
                                }



                                if (dt.Rows[i]["ManualDownFill"].ToString() != "0.00")
                                {
                                    tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["ManualDownFill"] + " (Manual)</td>");
                                }
                                else
                                {
                                    tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["MachineDownFill"] + " (Machine)</td>");
                                }

                                tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["SeamSeal"] + "</td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["Bonding"] + "</td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["OthersValue"] + " (" + dt.Rows[i]["OthersDescription"] + ") </td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#000000;background-color:#82E0AA;font-size:11px'><b>" + dt.Rows[i]["ValuableSmv"] + "<b/></td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["CuttingSMV"] + "</td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["FinisingSmv"] + "</td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;center;color:#000000;background-color:#F1948A;font-size:11px'>" + dt.Rows[i]["TotalNetSmv"] + "</td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#000000;background-color:#F9E79F;font-size:11px'><b>" + dt.Rows[i]["NonValuableSmv"] + "</b></td>"
                                    + "</tr>");
                            }

                        }
                        else
                        {
                            tableRow.Append("<tr>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align:center;font-size:11px'>" + dt.Rows[0]["SampleStageName"] + "</td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#000000;background-color:#82E0AA;font-size:11px'>" + dt.Rows[0]["SwingSmv"] + "</td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["PleatingSmv"] + "</td>");

                            tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["PermanentCrease"] + "</td>");
                            tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["SupperCrease"] + "</td>");

                            if (dt.Rows[0]["HeatSeal"].ToString() != "0.00")
                            {
                                tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["HeatSeal"] + "  (Heat Seal)</td>");
                            }
                            else
                            {
                                tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["OverlayFilm"] + " (Overlay)</td>");
                            }



                            if (dt.Rows[0]["PLKQuiltingSmv"].ToString() != "0.00")
                            {
                                tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["PLKQuiltingSmv"] + " (PLK)</td>");
                            }
                            else if (dt.Rows[0]["AutoQuiltingSmv"].ToString() != "0.00")
                            {
                                tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["AutoQuiltingSmv"] + " (Auto)</td>");
                            }
                            else
                            {
                                tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["ManualQuiltingSmv"] + " (Manual)</td>");
                            }



                            if (dt.Rows[0]["ManualDownFill"].ToString() != "0.00")
                            {
                                tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["ManualDownFill"] + " (Manual)</td>");
                            }
                            else
                            {
                                tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["MachineDownFill"] + " (Machine)</td>");
                            }

                            tableRow.Append("<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["SeamSeal"] + "</td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["Bonding"] + "</td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["OthersValue"] + " (" + dt.Rows[0]["OthersDescription"] + ")</td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#000000;background-color:#82E0AA;font-size:11px'><b>" + dt.Rows[0]["ValuableSmv"] + "</b></td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["CuttingSMV"] + "</td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["FinisingSmv"] + "</td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#000000;background-color:#F1948A;font-size:11px'>" + dt.Rows[0]["TotalNetSmv"] + "</td>"
                                         + "<td style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#000000;background-color:#F9E79F;font-size:11px'><b>" + dt.Rows[0]["NonValuableSmv"] + "</b></td>"
                                    + "</tr>");
                        }






                        tableRow.Append("<tr>"
                                        + "<td colspan = '16' style ='text-align: center;border: 1px solid #ddd;padding: 1px;color: #ffffff; background-color:#1F618D;'><b> Construction Remarks </b></td>"
                                        + "</tr>"
                                        + "<tr>"
                                            + "<td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color: #ffffff; background-color:#1F618D;'><b> Sample date </b></td>"
                                            + "<td colspan = '3' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color: #ffffff; background-color:#1F618D;'><b> Sample Stage</b></td>"
                                            // + "<td colspan = '4' > Description :</td>"
                                            + "<td colspan = '11' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color: #ffffff; background-color:#1F618D;'><b> Remarks </b></td>"
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
                                                 + " <td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + datepart + " </td>"
                                                 + " <td colspan = '3' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["SampleStageName"] + " </td>"
                                                 // + " <td colspan = '4'>" + dt.Rows[i]["WorksUpdate"] + "  </td>"
                                                 + " <td colspan = '11' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[i]["Remarks"] + "  </td>"
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
                                         + " <td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + datepart + " </td>"
                                         + " <td colspan = '3' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["SampleStageName"] + " </td>"
                                         //+ " <td colspan = '4'>" + dt.Rows[0]["WorksUpdate"] + "  </td>"
                                         + " <td colspan = '11' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["Remarks"] + "  </td>"
                                         + " </tr>");
                        }

                        //new added 

                        //tableRow.Append("<tr>"
                        //                + "<td colspan = '16' style ='text-align: center;border: 1px solid #ddd;padding: 1px;color: #ffffff; background-color:#1F618D;'><b> Option </b></td>"
                        //                + "</tr>"
                        //                + "<tr>"
                        //                    + "<td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;font-size:11px;'><b> Sample Stage </b></td>"
                        //                    + "<td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;font-size:11px;'><b>Option Number</b></td>"

                        //                    + "<td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;font-size:11px;'><b>Reduction Value </b></td>"
                        //                    + "<td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;font-size:11px;'><b>Additional Value </b></td>"
                        //                    + "<td colspan = '4' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;font-size:11px;'><b> Description </b></td>"
                        //                    + "<td colspan = '4' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;font-size:11px;'><b> Remarks </b></td>"
                        //                + " </tr>");

                        optionData = smvGateway.LoadBuyerWiseOptionInfo(BuyerId, StyleNumber);
                        //end new add
                        if (optionData.Rows.Count > 0)
                        {
                            tableRow.Append("<tr>"
                                       + "<td colspan = '16' style ='text-align: center;border: 1px solid #ddd;padding: 1px;color: #ffffff; background-color:#1F618D;'><b> Option </b></td>"
                                       + "</tr>"
                                       + "<tr>"
                                           + "<td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;font-size:11px;'><b> Sample Stage </b></td>"
                                           + "<td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;font-size:11px;'><b>Option Number</b></td>"

                                           + "<td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;font-size:11px;'><b>Reduction Value </b></td>"
                                           + "<td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;font-size:11px;'><b>Additional Value </b></td>"
                                           + "<td colspan = '4' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;font-size:11px;'><b> Description </b></td>"
                                           + "<td colspan = '4' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color:#5DADE2;font-size:11px;'><b> Remarks </b></td>"
                                       + " </tr>");

                            for (int i = 0; i < optionData.Rows.Count; i++)
                            {
                                tableRow.Append("<tr>"
                                                 + " <td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + optionData.Rows[i]["OptionSampleStageName"] + " </td>"
                                                 + " <td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + optionData.Rows[i]["OptionNumber"] + " </td>"
                                                 // + " <td colspan = '4'>" + dt.Rows[i]["WorksUpdate"] + "  </td>"
                                                 + " <td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + optionData.Rows[i]["OptionReduction"] + "  </td>"
                                                 + " <td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + optionData.Rows[i]["OptionAddition"] + "  </td>"
                                                 + " <td colspan = '4' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + optionData.Rows[i]["OptionDescription"] + "  </td>"
                                                 + " <td colspan = '4' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + optionData.Rows[i]["OptionRemarks"] + "  </td>"
                                                 + " </tr>");
                            }
                        }
                        //else
                        //{
                            
                        //    tableRow.Append("<tr>"
                        //                 + " <td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;'>" + optionData.Rows[0]["OptionSampleStageName"] + " </td>"
                        //                 + " <td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;'>" + optionData.Rows[0]["OptionNumber"] + " </td>"
                                      
                        //                 + " <td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;'>" + optionData.Rows[0]["OptionReduction"] + "  </td>"
                        //                 + " <td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;'>" + optionData.Rows[0]["OptionAddition"] + "  </td>"
                        //                 + " <td colspan = '4' style ='border: 1px solid #ddd;padding: 1px;text-align: center;'>" + optionData.Rows[0]["OptionDescription"] + "  </td>"
                        //                 + " <td colspan = '4' style ='border: 1px solid #ddd;padding: 1px;text-align: center;'>" + optionData.Rows[0]["OptionRemarks"] + "  </td>"
                        //                 + " </tr>");
                        //}





                        tableRow.Append(" <tr> "
                        + "<td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color: #ffffff; background-color:#1F618D;font-size:13px;'> <b>Made By</b></td>"
                        + "<td colspan = '3' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["PostedByName"] + "</ td >"
                        + "<td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color: #ffffff; background-color:#1F618D;font-size:13px;'> <b>Review By </b></td>"
                        + "<td colspan = '3' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["ReviewByName"] + "</td>"
                        + "<td colspan = '2' style ='border: 1px solid #ddd;padding: 1px;text-align: center;color: #ffffff; background-color:#1F618D; font-size:13px;'> <b>Approved By </b></td>"
                        + "<td colspan = '4' style ='border: 1px solid #ddd;padding: 1px;text-align: center;font-size:11px'>" + dt.Rows[0]["ApprovedByName"] + "</td>"
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
        catch (Exception ex)
        {

        }
        return tableRow.ToString();
    }

    public string DetailsCostingSmvInfo(int BuyerId, string StyleNumber)
    {
        StringBuilder tableRow = new StringBuilder();

        DataTable dt = null;
        try
        {
            using (SmvEntryGateway smvGateway = new SmvEntryGateway())
            {

                dt = smvGateway.LoadCostingSmvDetailsReport(BuyerId, StyleNumber);
                if (dt.Rows.Count > 0)
                {
                    int count = 0;
                    tableRow.Append("<thead ID='eventHead'><tr class='success' ID='eventTr'>" +
                                    "<th style='text-align:center;width: 60px; border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Sr No</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Buyer Name</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>SampleStage</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Style Number</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Style Description</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Design Number</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Fabric Type</th>" +

                                    "<th style='text-align:center;width: 130px;border: 1px solid#000000;background-color:#2b335d;color: #989690;padding: 1px;'>Product Category</th>" +
                                    //"<th style='text-align:center;'>Department</th>" +

                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Sample Date</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Sewing SMV</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Pleating SMV</th>" +

                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Permanent Crease</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Supper Crease</th>" +

                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Heat Seal </th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Overlay Film</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Heat SMV</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>PLK Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Auto Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Manual Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Quilting Smv</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Manual DownFill</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Machine DownFill</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Down Fill SMV</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Lycra Breakage SMV</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Bonding</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Cutting SMV</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Finishing SMV</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Others Value</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Others Description</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Option Value</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Option Description</th>" +
                                    "<th class='success' style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Total SMV</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Valid SMV</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Non-Valid Smv</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Review By</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Approved By</th>" +
                                // "<th style='text-align:center; width: 200px;'>Description</th>" +
                                "<th style='text-align:center;width: 350px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Machine & Technical Concern</th>" +
                                "<th style='text-align:center;width: 600px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Remarks</th>" +
                                "<th style='text-align:center;width: 90px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Posted On</th>" +
                                "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;padding: 1px;'>Posted By</th>" +

                                

                                    "</tr></thead><tbody ID='eventTb' style='text-align:center;'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tr ID='eventTd'>");
                        tableRow.Append("<td style='text-align:center;width: 60px; border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + count + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["BuyerName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["SampleStageName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["StyleDescription"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["DesignNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["FabricType"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["ProductName"] + "</td>");
                        //tableRow.Append("<td>" + dt.Rows[i]["DepartmentName"] + "</td>");

                        DateTime date = Convert.ToDateTime(dt.Rows[i]["SampleDate"]);
                        string datepart = date.ToString("yyyy-MM-dd");
                        if (datepart == "1900-01-01")
                        {
                            tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;padding: 1px;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + datepart + "</td>");
                        }


                        //tableRow.Append("<td>" + dt.Rows[i]["SampleDate"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["SewingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["PleatingSmv"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["PermanentCrease"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;padding: 1px;'>" + dt.Rows[i]["SupperCrease"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["HeatSeal"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["OverlayFilm"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["HeatSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["PLKQueltingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["AutoQueltingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["ManualQueltingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["QuiltingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["ManualDownFill"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["MachineDownFill"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["DownFillSMV"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["SeamSeal"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["Bonding"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["CuttingSMV"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["FinisingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["OthersValue"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["OthersDescription"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["OptionValue"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["OptionDescription"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;' class='success'>" + dt.Rows[i]["TotalSMV"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["valueableSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["NonValuableSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["ReviewByName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["ApprovedByName"] + "</td>");
                        // tableRow.Append("<td  style='text-align:center; width: 200px;'>" + dt.Rows[i]["WorksUpdate"] + "</td>");
                        tableRow.Append("<td  style='text-align:center;width: 350px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["MachineWork"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 600px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["Remarks"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 90px;border: 1px solid #ddd;border-color:black;background-color: #1012;color:black;padding: 1px;'>" + dt.Rows[i]["PostedOn"] + "</td>");
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



    public string LoadCostingSmvInfoRevised(int buyerId, string StyleNumber)
    {
        StringBuilder tableRow = new StringBuilder();

        DataTable dt = null;
        try
        {
            using (SmvEntryGateway smvGateway = new SmvEntryGateway())
            {

                dt = smvGateway.LoadCostingSmvInfo(buyerId, StyleNumber);
                if (dt.Rows.Count > 0)
                {
                    int count = 0;
                    tableRow.Append("<thead ID='eventHead'><tr class='success' ID='eventTr'>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Sr No</th>" +
                                    "<th style='text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Buyer Name</th>" +
                                    "<th style='text-align:center;width: 100px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Sample Stage</th>" +
                                    "<th style='text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Style Number</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Style Description</th>" +
                                    "<th style='text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Design Number</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Fabric Type</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Product Category</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Season</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Sample Date</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Sewing SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Pleating SMV</th>" +

                                    "<th style='text-align:center;width: 85px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Permanent Crease</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Supper Crease</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Heat Seal</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Overlay Film</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Heat SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>PLK Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Auto Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Manual Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Manual DownFill</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Machine DownFill</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Down Fill SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Lycra Breakage SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Bonding</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Cutting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Finishing SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Others Value</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Others Description</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Option Value</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Option Additional Value</th>" +

                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Option Description</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Option Number</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Option Remarks</th>" +
                                    //"<th style='text-align:center;width: 75px;'>Total SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Valid SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Non-Valid SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Review By</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Approved By</th>" +
                                    "<th style='text-align:center;width: 350px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Machine & Technical Concern</th>" +
                                    "<th style='text-align:center;width: 350px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Remarks</th>" +
                                    "<th style='text-align:center;width: 90px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Posted On</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Posted By</th>" +
                                    "<th style='text-align:center;width: 90px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Updated On</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Updated By</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690; '>Action</th>" +
                                    "</tr></thead><tbody ID='eventTb' style='text-align:center;'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tr ID='eventTd'> ");
                        tableRow.Append("<td style='text-align:center;width: 40px;border: 1px solid #000000;'>" + count + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["BuyerName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 100px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["SampleStageName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["StyleDescription"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 120px; white-space: normal !important;word - wrap: break-word;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["DesignNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["FabricType"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ProductName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["Season"] + "</td>");
                        DateTime date = Convert.ToDateTime(dt.Rows[i]["SampleDate"]);
                        string datepart = date.ToString("yyyy-MM-dd");
                        if (datepart == "1900-01-01")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + datepart + "</td>");
                        }


                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["SwingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["PleatingSmv"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 85px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["PermanentCrease"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["SupperCrease"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["HeatSeal"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OverlayFilm"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["HeatSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["PLKQuiltingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["AutoQuiltingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ManualQuiltingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["QuiltingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ManualDownFill"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["MachineDownFill"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["DownFillSMV"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["SeamSeal"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["Bonding"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["CuttingSMV"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["FinisingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OthersValue"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OthersDescription"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OptionValue"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OptionAdditionalValue"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OptionDescription"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OptionNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["OptionRemarks"] + "</td>");
                        //tableRow.Append("<td class='success' style='text-align:center;width: 75px;'>" + dt.Rows[i]["TotalSMV"] + "</td>");
                        tableRow.Append("<td class='active' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ValuableSmv"] + "</td>");
                        tableRow.Append("<td class='info' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["NonValuableSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ReviewByName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["ApprovedByName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 350px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["MachineWork"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 350px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["Remarks"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 90px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["PostedOn"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["PostedByName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 90px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["UpdatedOn"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["UpdatedByName"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #fff;'><a href='CostingRevisedPanel.aspx?Id=" + dt.Rows[i]["SmvId"] + "'>Revised</a><br/>" +
                            "<a href='CostingRevisedPanel.aspx?Up=" + dt.Rows[i]["SmvId"] + "'>Correction</a><br/>" +
                            "<a href='CostingOption.aspx?Option=" + dt.Rows[i]["SmvId"] + "'>Option Update</a><br/>" +
                            "<a href='BulkSmvPanel.aspx?SmvValue=" + dt.Rows[i]["SmvId"] + "'>Set Bulk</a></td>");

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



    public string LoadCombineStyleReports(int buyerId, string StyleNumber)
    {
        StringBuilder tableRow = new StringBuilder();

        DataTable dt = null;
        try
        {
            using (SmvEntryGateway smvGateway = new SmvEntryGateway())
            {

                dt = smvGateway.LoadCombineStyleReports(buyerId, StyleNumber);
                if (dt.Rows.Count > 0)
                {
                    int count = 0;
                    tableRow.Append("<thead ID='eventHead'><tr class='success' ID='eventTr'>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;'>Sr No</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Buyer Name</th>" +
                                    "<th style='text-align:center;width: 100px;border: 1px solid #000000;'>Costing Sample Stage</th>" +
                                    "<th style='text-align:center;width: 84px;border: 1px solid #000000;'>Design Number</th>" +
                                    "<th style='text-align:center;width: 84px;border: 1px solid #000000;'>Style Number</th>" +
                                   "<th style='text-align:center;width: 150px;border: 1px solid #000000;'>Costing Style Description</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Fabric Type</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Product Category</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Sample Date</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Sewing SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Pleating SMV</th>" +

                                    "<th style='text-align:center;width: 85px;border: 1px solid #000000;'>Costing Permanent Crease</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Supper Crease</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Heat Seal</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Overlay Film</th>" + 
                                                                       
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing PLK Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Auto Quilting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Manual Quilting SMV</th>" +                                   

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Manual DownFill</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Machine DownFill</th>" +
                                    
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Seam Seal</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Bonding</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Cutting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Finishing SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Others Value</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;'>Others Description</th>" +
                                    //"<th style='text-align:center;width: 75px;'>Total SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Valid SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Non-Valid SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Review By</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Costing Approved By</th>" +
                                    "<th style='text-align:center;width: 350px;border: 1px solid #000000;'>Costing Machine & Technical Concern</th>" +
                                    "<th style='text-align:center;width: 350px;border: 1px solid #000000;'>Costing Remarks</th>" +
                                    "<th style='text-align:center;width: 90px;border: 1px solid #000000;'>Costing Posted On</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;'>Costing Posted By</th>" +
                                    "<th style='text-align:center;width: 90px;border: 1px solid #000000;'>Costing Updated On</th>" +
                                    "<th style='text-align:center;width: 130px;border: 1px solid #000000;'>Costing Updated By</th>" +

                                    "<th style='text-align:center;width: 100px;border: 1px solid #000000;'>Bulk Sample Stage</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Sewing SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Overlay SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Fit SMV</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Plk Quelting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Auto Quelting SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Manual Quelting SMV</th>" +


                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Manual Downfill SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Machine Downfill SMV</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Review By</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Approved By</th>" +


                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Posted By</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Posted On</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Updated By</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Updated On</th>" +
                                    "<th style='text-align:center;width: 350px;border: 1px solid #000000;'>Bulk Machine & Technical Concern</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Sample Date</th>" +
                                    "<th style='text-align:center;width: 150px;border: 1px solid #000000;'>Bulk Description</th>" +

                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Bulk Finishing SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Total Costing SMV</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Saving In Minute</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;'>Saving Percentage</th>" +
                                    "</tr></thead><tbody ID='eventTb' style='text-align:center;'>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tr ID='eventTd'> ");
                        tableRow.Append("<td style='text-align:center;width: 40px;border: 1px solid #000000;'>" + count + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["BuyerName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 100px;border: 1px solid #000000;'>" + dt.Rows[i]["CostingSampleStageName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 84px;border: 1px solid #000000;'>" + dt.Rows[i]["DesignNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 84px;border: 1px solid #000000;'>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;'>" + dt.Rows[i]["StyleDescription"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["FabricName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["ProductName"] + "</td>");

                        DateTime date = Convert.ToDateTime(dt.Rows[i]["SampleDate"]);
                        string datepart = date.ToString("yyyy-MM-dd");
                        if (datepart == "1900-01-01")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + datepart + "</td>");
                        }


                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["SwingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["PleatingSmv"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 85px;border: 1px solid #000000;'>" + dt.Rows[i]["PermanentCrease"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["SupperCrease"] + "</td>");

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["HeatSealHeatSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["OverlayFilmHeatSmv"] + "</td>");
                                           
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["PLKQuiltingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["AutoQuiltingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["ManualQuiltingSmv"] + "</td>");
                        
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["ManualDownFill"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["MachineDownFill"] + "</td>");
                        
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["SeamSeal"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["Bonding"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["CuttingSMV"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["FinisingSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["OthersValue"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;'>" + dt.Rows[i]["OthersDescription"] + "</td>");
                  
                        //tableRow.Append("<td class='success' style='text-align:center;width: 75px;'>" + dt.Rows[i]["TotalSMV"] + "</td>");
                        tableRow.Append("<td class='active' style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["ValuableSmv"] + "</td>");
                        tableRow.Append("<td class='info' style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["NonValuableSmv"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["CostingRewiew"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["CostingApproved"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 350px;border: 1px solid #000000;'>" + dt.Rows[i]["MachineWork"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 350px;border: 1px solid #000000;'>" + dt.Rows[i]["Remarks"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 90px;border: 1px solid #000000;'>" + dt.Rows[i]["PostedOn"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #000000;'>" + dt.Rows[i]["CostingPosted"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 90px;border: 1px solid #000000;'>" + dt.Rows[i]["UpdatedOn"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 130px;border: 1px solid #000000;'>" + dt.Rows[i]["CostingUpdate"] + "</td>");
                        
                        //bulkvalue start
                        tableRow.Append("<td style='text-align:center;width: 100px;border: 1px solid #000000;'>" + dt.Rows[i]["BulkSampleStageName"] + "</td>");

                        string bulkSewing = dt.Rows[i]["SewingSmvBulk"].ToString();
                        if (bulkSewing == "0.00")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + bulkSewing + "</td>");
                        }

                        string bulkOverlay= dt.Rows[i]["OverlaySmvBulk"].ToString();
                        if (bulkOverlay == "0.00")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + bulkOverlay + "</td>");
                        }

                        string bulkFits = dt.Rows[i]["FitsSmvBulk"].ToString();
                        if (bulkFits == "0.00")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + bulkFits + "</td>");
                        }


                        string bulkPlkQuelting = dt.Rows[i]["PlkQueltingBulk"].ToString();
                        if (bulkPlkQuelting == "0.00")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + bulkPlkQuelting + "</td>");
                        }



                        string bulkAutoQuelting = dt.Rows[i]["AutoQueltingBulk"].ToString();
                        if (bulkAutoQuelting == "0.00")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + bulkAutoQuelting + "</td>");
                        }


                        string bulkManualQuelting = dt.Rows[i]["ManualQueltingBulk"].ToString();
                        if (bulkManualQuelting == "0.00")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + bulkManualQuelting + "</td>");
                        }

                        string ManualDownfillBulk = dt.Rows[i]["ManualDownfillBulk"].ToString();
                        if (ManualDownfillBulk == "0.00")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + ManualDownfillBulk + "</td>");
                        }


                        string MachineDownfillBulk = dt.Rows[i]["MachineDownfillBulk"].ToString();
                        if (MachineDownfillBulk == "0.00")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + MachineDownfillBulk + "</td>");
                        }

                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["BulkRewiew"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["BulkApproved"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["BulkPosted"] + "</td>");
                       // tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["PostedOnBulk"] + "</td>");


                        DateTime date2 = Convert.ToDateTime(dt.Rows[i]["PostedOnBulk"]);
                        string datepart2 = date.ToString("yyyy-MM-dd");
                        if (datepart2 == "1900-01-01")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + datepart2 + "</td>");
                        }


                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["BulkUpdate"] + "</td>");
                       //tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + dt.Rows[i]["UpdatedOnBulk"] + "</td>");

                        DateTime date3 = Convert.ToDateTime(dt.Rows[i]["UpdatedOnBulk"]);
                        string datepart3 = date.ToString("yyyy-MM-dd");
                        if (datepart3 == "1900-01-01")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + datepart3 + "</td>");
                        }



                        tableRow.Append("<td style='text-align:center;width: 350px;border: 1px solid #000000;'>" + dt.Rows[i]["MachineWorkBulk"] + "</td>");



                        DateTime date1 = Convert.ToDateTime(dt.Rows[i]["SampleDateBulk"]);
                        string datepart1 = date.ToString("yyyy-MM-dd");
                        if (datepart1 == "1900-01-01")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + datepart1 + "</td>");
                        }

                        tableRow.Append("<td style='text-align:center;width: 150px;border: 1px solid #000000;'>" + dt.Rows[i]["DescriptionBulk"] + "</td>");

                        string FinishingSmvBulk = dt.Rows[i]["FinishingSmvBulk"].ToString();
                        if (FinishingSmvBulk == "0.00")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + FinishingSmvBulk + "</td>");
                        }

                        string TotalCostingSmv = dt.Rows[i]["TotalCostingSmv"].ToString();
                        if (MachineDownfillBulk == "0.00")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + TotalCostingSmv + "</td>");
                        }

                        string SavingInMinute = dt.Rows[i]["SavingInMinute"].ToString();
                        if (MachineDownfillBulk == "0.00")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + SavingInMinute + "</td>");
                        }

                        string SavingPercentage = dt.Rows[i]["SavingPercentage"].ToString();
                        if (MachineDownfillBulk == "0.00")
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + "" + "</td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;'>" + SavingPercentage + "</td>");
                        }
                        //bulkvalue end



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


    public string LoadCostingOptionForUpdate(int SmvId)
    {
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (SmvEntryGateway smv=new SmvEntryGateway())
            {
                int count = 0;
                DataTable dt = smv.LoadCostingOptionForUpdate(SmvId);
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                                    "<th>Sl</th>" +
                                    "<th>BuyerName</th>" +
                                    "<th>SampleStageName</th>" +
                                    "<th>StyleNumber</th>" +
                                    "<th>DesignNumber</th>" +
                                    "<th>FabricName</th>" +
                                    "<th>ProductName</th>" +
                                    "<th>OptionNumber</th>" +
                                    "<th>OptionReduction</th>" +
                                    "<th>OptionAddition</th>" +
                                    "<th>OptionDescription</th>" +
                                    "<th>OptionRemarks</th>" +                                    
                                    "<th>Action</th>" +
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr>");

                        tableRow.Append("<td>" + count + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["BuyerName"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["SampleStageName"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["DesignNumber"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["FabricName"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["ProductName"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["OptionNumber"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["OptionReduction"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["OptionAddition"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["OptionDescription"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["OptionRemarks"] + "</td>");

                        tableRow.Append("<td><a href='CostingOption.aspx?Id=" + dt.Rows[i]["OptionId"] + "'>Edit</a></td>");
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
        catch (Exception ex)
        {

        }
        return tableRow.ToString();
    }

    public DataTable GetOptionInformationForUpdate(int optionId)
    {
        DataTable dt = null;
        try
        {
            using (SmvEntryGateway smv = new SmvEntryGateway())
            {
                dt = smv.GetOptionInformationForUpdate(optionId);
                return dt;
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
        
    }
    public int UpdateCostingOption(UpdateOptionModel optionModel)
    {
        int action = 0;
        try
        {
            using (SmvEntryGateway smv = new SmvEntryGateway())
            {
                action = smv.UpdateCostingOption(optionModel);
                return action;
            }
        }
        catch(Exception ex)
        {
            throw ex;
        }
    }

    public DataTable LoadSeason()
    {
        DataTable dt = null;
        try
        {
            using (SmvEntryGateway smvEntryGateway = new SmvEntryGateway()) {
                dt = smvEntryGateway.LoadSeason();
                return dt;
            }
        }
        catch (Exception ex) {
            throw ex;
        }

    }

}