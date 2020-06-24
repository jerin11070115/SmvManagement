using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for AllUsersSummaryBLL
/// </summary>
public class AllUsersSummaryBLL
{
    public AllUsersSummaryBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public string GetAllUsersNewCostingSummary(string fromDate, string toDate)
    {
        DataTable dt = null;
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (AllUsersSummaryGateway allUserSummaryGateway = new AllUsersSummaryGateway())
            {
                int count = 0;
                dt = allUserSummaryGateway.GetAllUsersNewCostingSummary(fromDate, toDate);
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Serial No</th>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Name</th>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Number Of New Costing</th>" +
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr>");

                        tableRow.Append("<td style='text-align:center;width: 40px;border: 1px solid #000000;background-color: #1012;color:black;'>" + count + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["FullName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["NewCostingCount"] + "</td>");
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
    public string GetAllUsersRevisedCostingSummary(string fromDate, string toDate)
    {
        DataTable dt = null;
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (AllUsersSummaryGateway allUserSummaryGateway = new AllUsersSummaryGateway())
            {
                int count = 0;
                dt = allUserSummaryGateway.GetAllUsersRevisedCostingSummary(fromDate, toDate);
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Serial No</th>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Name</th>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Style</th>" +
                                   "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Design</th>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Number Of Revised Costing</th>" +
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr>");

                        tableRow.Append("<td style='text-align:center;width: 40px;border: 1px solid #000000;background-color: #1012;color:black;'>" + count + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["FullName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["DesignNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["totalRevised"] + "</td>");
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


    public string GetAllUsersNewBulkSummary(string fromDate, string toDate)
    {
        DataTable dt = null;
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (AllUsersSummaryGateway allUserSummaryGateway = new AllUsersSummaryGateway())
            {
                int count = 0;
                dt = allUserSummaryGateway.GetAllUsersNewBulkSummary(fromDate, toDate);
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Serial No</th>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Name</th>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Number Of New Bulk</th>" +
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr>");

                        tableRow.Append("<td style='text-align:center;width: 40px;border: 1px solid #000000;background-color: #1012;color:black;'>" + count + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 40px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["FullName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 40px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["NewBulk"] + "</td>");
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




    public string GetAllUsersRevisedBulkSummary(string fromDate, string toDate)
    {
        DataTable dt = null;
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (AllUsersSummaryGateway allUserSummaryGateway = new AllUsersSummaryGateway())
            {
                int count = 0;
                dt = allUserSummaryGateway.GetAllUsersRevisedBulkSummary(fromDate, toDate);
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Serial No</th>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Name</th>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Style</th>" +
                                    "<th style='text-align:center;width: 40px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Number Of Revised Bulk</th>" +
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr>");

                        tableRow.Append("<td style='text-align:center;width: 40px;border: 1px solid #000000;background-color: #1012;color:black;'>" + count + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 40px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["FullName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 40px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td style='text-align:center;width: 40px;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["RevisedBulk"] + "</td>");
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




    public string GetKpiReport(string fromDate, string toDate)
    {
        DataTable dt = null;
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (AllUsersSummaryGateway allUserSummaryGateway = new AllUsersSummaryGateway())
            {
                int count = 0;
                dt = allUserSummaryGateway.GetKpiReport(fromDate, toDate);
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Serial No</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Name</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Total Issued Style</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Avg Costing</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Avg Bulk</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Variation</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Variation %</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Marks</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>SMV Increased Style</th>" +
                                    "<th style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#2b335d;color: #989690;'>Marks</th>" +
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr>");

                        tableRow.Append("<td style='text-align:center;border: 1px solid #000000;background-color: #1012;color:black;'>" + count + "</td>");
                        tableRow.Append("<td style='text-align:center;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["FullName"] + "</td>");
                        tableRow.Append("<td style='text-align:center;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["TotalIssuedStyle"] + "</td>");
                        tableRow.Append("<td style='text-align:center;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["AvgCosting"] + "</td>");
                        tableRow.Append("<td style='text-align:center;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["AvgBulk"] + "</td>");
                        tableRow.Append("<td style='text-align:center;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["Vatiation"] + "</td>");
                        tableRow.Append("<td style='text-align:center;border: 1px solid #000000;background-color: #1012;color:black;'>" + dt.Rows[i]["VariationPercentage"] + " % </td>");

                        int vpercentage = Convert.ToInt32(dt.Rows[i]["VariationPercentage"]);
                        int vpMarks = 30;
                        int vnMarks = 0;
                        int SMVIncreasedStyleN = 1;
                        int SMVIncreasedStyleP = 0;
                        if (vpercentage >= 2)
                        {
                            tableRow.Append("<td style='text-align:center;border: 1px solid #000000;background-color: #1012;color:black;'>" + vpMarks.ToString() + "  </td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;border: 1px solid #000000;background-color: #1012;color:black;'>" + vnMarks.ToString() + "  </td>");
                        }
                        if (vpercentage > 0)
                        {
                            tableRow.Append("<td style='text-align:center;border: 1px solid #000000;background-color: #1012;color:black;'>" + SMVIncreasedStyleP.ToString() + "  </td>");
                        }
                        else
                        {
                            tableRow.Append("<td style='text-align:center;border: 1px solid #000000;background-color: #1012;color:black;'>" + SMVIncreasedStyleN.ToString() + "  </td>");
                        }

                        if (vpercentage > 0)
                        {
                            tableRow.Append("<td style='text-align:center;border: 1px solid #000000;background-color: #1012;color:black;'>" + vpMarks.ToString() + "  </td>");
                        }
                        else
                        {
                            tableRow.Append("<td>" + vnMarks.ToString() + "  </td>");
                        }

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


    public string GetDailyKpiReport(string fromDate, string toDate)
    {
        DataTable dt = null;
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (AllUsersSummaryGateway allUserSummaryGateway = new AllUsersSummaryGateway())
            {
                int LastNewCostingCountTotal = 0;
                int NewCostingCountTotal = 0;
                int LastRevisedCostingCountTotal = 0;
                int RevisedCostingCountTotal = 0;
                int LastNewBulkCountTotal = 0;
                int NewBulkCountTotal = 0;
                int LastRevisedBulkCountTotal = 0;
                int RevisedBulkCountTotal = 0;


                int CepzLastNewCostingCountTotal = 0;
                int CepzNewCostingCountTotal = 0;
                int CepzLastRevisedCostingCountTotal = 0;
                int CepzRevisedCostingCountTotal = 0;
                int CepzLastNewBulkCountTotal = 0;
                int CepzNewBulkCountTotal = 0;
                int CepzLastRevisedBulkCountTotal = 0;
                int CepzRevisedBulkCountTotal = 0;
                dt = allUserSummaryGateway.GetDailyKpiReport(fromDate, toDate);
                

                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead>" +
                        "<tr class='success'>" +
                        "<th colspan = '2' style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #FFFFFF;'>"+ DateTime.Now.ToString("dd-MMM-yyyy") + "</th>" +
                        "<th colspan = '8' style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #FFFFFF;'>DAILY WORK SUMMARY OF PPIE DEPT</th>" +
                        "</tr>" +
                        "<tr class='success'>" +
                        "<th colspan = '2' style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #FFFFFF;'></th>" +
                        "<th colspan = '2' style='text-align:center;border: 1px solid #000000;background-color:#538DD6;color: #FFFFFF;'>COSTING</th>" +
                        "<th colspan = '2' style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #FFFFFF;'>COST REVISION</th>" +
                        "<th colspan = '2' style='text-align:center;border: 1px solid #000000;background-color:#538DD6;color: #FFFFFF;'>GSD</th>" +
                        "<th colspan = '2' style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #FFFFFF;'>GSD REVISION</th>" +
                        "</tr>" +
                        "<tr class='success'>" +
                        "<th colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#A6A6A6;color: #000000;'>NAME</th>" +
                        "<th colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#A6A6A6;color: #000000;'>ZONE NAME</th>" +
                        "<th colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#A6A6A6;color: #000000;'>DAY</ th>" +
                        "<th colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#A6A6A6;color: #000000;'>TOTAL</th>" +
                        "<th colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#A6A6A6;color: #000000;'>DAY</ th>" +
                        "<th colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#A6A6A6;color: #000000;'>TOTAL</th>" +
                        "<th colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#A6A6A6;color: #000000;'>DAY</ th>" +
                        "<th colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#A6A6A6;color: #000000;'>TOTAL</th>" +
                        "<th colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#A6A6A6;color: #000000;'>DAY</ th>" +
                        "<th colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color:#A6A6A6;color: #000000;'>TOTAL</th>" +
                        "</tr>"+
                        "<tr class='success'>" +
                        "<th colspan = '10' style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #FFFFFF;'>KEPZ ZONE</th>" +
                        "</tr>" +
                        "</thead >");
                    tableRow.Append("<tbody>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if(dt.Rows[i]["ZoneName"].ToString()== "KEPZ")
                        {
                            tableRow.Append("<tr>");

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #A6A6A6;color:black;font-weight: bold;'>" + dt.Rows[i]["FullName"] + "</td>");
                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #FFFFFF;color:black;font-weight: bold;'>" + dt.Rows[i]["ZoneName"] + "</td>");
                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;font-weight: bold;'>" + dt.Rows[i]["LastNewCostingCount"] + "</td>");
                            LastNewCostingCountTotal = LastNewCostingCountTotal + Convert.ToInt32(dt.Rows[i]["LastNewCostingCount"]);

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #FFFFFF;color:black;font-weight: bold;'>" + dt.Rows[i]["NewCostingCount"] + "</td>");
                            NewCostingCountTotal = NewCostingCountTotal + Convert.ToInt32(dt.Rows[i]["NewCostingCount"]);

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #A6A6A6;color:black;font-weight: bold;'>" + dt.Rows[i]["LastRevisedCostingCount"] + "</td>");
                            LastRevisedCostingCountTotal = LastRevisedCostingCountTotal + Convert.ToInt32(dt.Rows[i]["LastRevisedCostingCount"]);

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #FFFFFF;color:black;font-weight: bold;'>" + dt.Rows[i]["RevisedCostingCount"] + "</td>");
                            RevisedCostingCountTotal = RevisedCostingCountTotal + Convert.ToInt32(dt.Rows[i]["RevisedCostingCount"]);

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #A6A6A6;color:black;font-weight: bold;'>" + dt.Rows[i]["LastNewBulkCount"] + "</td>");
                            LastNewBulkCountTotal = LastNewBulkCountTotal + Convert.ToInt32(dt.Rows[i]["LastNewBulkCount"]);

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #FFFFFF;color:black;font-weight: bold;'>" + dt.Rows[i]["NewBulkCount"] + "</td>");
                            NewBulkCountTotal = NewBulkCountTotal + Convert.ToInt32(dt.Rows[i]["NewBulkCount"]);

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #A6A6A6;color:black;font-weight: bold;'>" + dt.Rows[i]["LastRevisedBulkCount"] + "</td>");
                            LastRevisedBulkCountTotal = LastRevisedBulkCountTotal + Convert.ToInt32(dt.Rows[i]["LastRevisedBulkCount"]);

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #FFFFFF;color:black;font-weight: bold;'>" + dt.Rows[i]["RevisedBulkCount"] + "</td>");
                            RevisedBulkCountTotal = RevisedBulkCountTotal + Convert.ToInt32(dt.Rows[i]["RevisedBulkCount"]);
                            tableRow.Append("</tr>");
                        }
                        
                    }
                    tableRow.Append("<tr>");
                    tableRow.Append("<td colspan = '2' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>TOTAL</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + LastNewCostingCountTotal + "</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + NewCostingCountTotal + "</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + LastRevisedCostingCountTotal + "</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + RevisedCostingCountTotal + "</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + LastNewBulkCountTotal + "</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + NewBulkCountTotal + "</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + LastRevisedBulkCountTotal + "</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + RevisedBulkCountTotal + "</td>");
                    tableRow.Append("</tr>");

                    tableRow.Append("<tr class='success'>" +
                       "<td colspan = '10' style='text-align:center;border: 1px solid #000000;background-color:#2b335d;color: #FFFFFF;'>CEPZ ZONE</td>" +
                       "</tr>");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["ZoneName"].ToString() == "CEPZ" || dt.Rows[i]["ZoneName"].ToString() == "" || dt.Rows[i]["ZoneName"].ToString() == null)
                        {
                            tableRow.Append("<tr>");

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #A6A6A6;color:black;font-weight: bold;'>" + dt.Rows[i]["FullName"] + "</td>");
                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #FFFFFF;color:black;font-weight: bold;'>" + dt.Rows[i]["ZoneName"] + "</td>");
                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #1012;color:black;font-weight: bold;'>" + dt.Rows[i]["LastNewCostingCount"] + "</td>");
                            CepzLastNewCostingCountTotal = CepzLastNewCostingCountTotal + Convert.ToInt32(dt.Rows[i]["LastNewCostingCount"]);

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #FFFFFF;color:black;font-weight: bold;'>" + dt.Rows[i]["NewCostingCount"] + "</td>");
                            CepzNewCostingCountTotal = CepzNewCostingCountTotal + Convert.ToInt32(dt.Rows[i]["NewCostingCount"]);

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #A6A6A6;color:black;font-weight: bold;'>" + dt.Rows[i]["LastRevisedCostingCount"] + "</td>");
                            CepzLastRevisedCostingCountTotal = CepzLastRevisedCostingCountTotal + Convert.ToInt32(dt.Rows[i]["LastRevisedCostingCount"]);

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #FFFFFF;color:black;font-weight: bold;'>" + dt.Rows[i]["RevisedCostingCount"] + "</td>");
                            CepzRevisedCostingCountTotal = CepzRevisedCostingCountTotal + Convert.ToInt32(dt.Rows[i]["RevisedCostingCount"]);

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #A6A6A6;color:black;font-weight: bold;'>" + dt.Rows[i]["LastNewBulkCount"] + "</td>");
                            CepzLastNewBulkCountTotal = CepzLastNewBulkCountTotal + Convert.ToInt32(dt.Rows[i]["LastNewBulkCount"]);

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #FFFFFF;color:black;font-weight: bold;'>" + dt.Rows[i]["NewBulkCount"] + "</td>");
                            CepzNewBulkCountTotal = CepzNewBulkCountTotal + Convert.ToInt32(dt.Rows[i]["NewBulkCount"]);

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #A6A6A6;color:black;font-weight: bold;'>" + dt.Rows[i]["LastRevisedBulkCount"] + "</td>");
                            CepzLastRevisedBulkCountTotal = CepzLastRevisedBulkCountTotal + Convert.ToInt32(dt.Rows[i]["LastRevisedBulkCount"]);

                            tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #FFFFFF;color:black;font-weight: bold;'>" + dt.Rows[i]["RevisedBulkCount"] + "</td>");
                            CepzRevisedBulkCountTotal = CepzRevisedBulkCountTotal + Convert.ToInt32(dt.Rows[i]["RevisedBulkCount"]);
                            tableRow.Append("</tr>");
                        }

                    }
                    tableRow.Append("<tr>");
                    tableRow.Append("<td colspan = '2' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>TOTAL</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + CepzLastNewCostingCountTotal + "</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + CepzNewCostingCountTotal + "</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + CepzLastRevisedCostingCountTotal + "</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + CepzRevisedCostingCountTotal + "</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + CepzLastNewBulkCountTotal + "</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + CepzNewBulkCountTotal + "</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + CepzLastRevisedBulkCountTotal + "</td>");
                    tableRow.Append("<td colspan = '1' style='text-align:center;width: 75px;border: 1px solid #000000;background-color: #16365C;color:#FFFFFF;'>" + CepzRevisedBulkCountTotal + "</td>");
                    tableRow.Append("</tr>");

                    tableRow.Append("</tbody>");
                    tableRow.Append("</table>");
                }
                else
                {
                    tableRow.Append("No Data Found");
                }
                return tableRow.ToString();
            }
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }
}