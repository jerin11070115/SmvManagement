using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for ProfileBLL
/// </summary>
public class ProfileBLL
{
    public ProfileBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetUserProfileName(int userId)
    {
        DataTable dt = null;
        try
        {
            using (ProfileGateway profileGateway = new ProfileGateway())
            {
                dt = profileGateway.GetUserProfileName(userId);
            }
        }
        catch(Exception ex)
        {

        }
        return dt;
        
    }


    public DataTable GetUsersPerformance(int userId)
    {
        DataTable dt = null;
        try
        {
            using (ProfileGateway profileGateway = new ProfileGateway())
            {
                dt = profileGateway.GetUsersPerformance(userId);
            }
        }
        catch (Exception ex)
        {

        }
        return dt;

    }


    public int GetCostingStyleInfoByUser(int userId)
    {
        DataTable dt = null;
        StringBuilder tableRow = new StringBuilder();

        int GetCostingStyleInfoByUserCount = 0;
        try
        {
            using (ProfileGateway profileGateway = new ProfileGateway())
            {
                int count = 0;
                dt = profileGateway.GetCostingStyleInfoByUser(userId);
                GetCostingStyleInfoByUserCount = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                                    "<th>Serial No</th>" +
                                    "<th>Style Number</th>" +
                                    "<th>Revision</th>" +                                    
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr>");

                        int Revision = Convert.ToInt32(dt.Rows[i]["TotalCountOfSampleStage"])-1;

                        tableRow.Append("<td>" + count + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td>" + Revision + "</td>");
                    
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
        //return tableRow.ToString();
        return GetCostingStyleInfoByUserCount;
    }




    public int GetCostingSampleInfoByUser(int userId)
    {
        int GetCostingSampleInfoByUserCount = 0;
        DataTable dt = null;
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (ProfileGateway profileGateway = new ProfileGateway())
            {
                //int count = 0;
                dt = profileGateway.GetCostingSampleInfoByUser(userId);
                GetCostingSampleInfoByUserCount =Convert.ToInt32(dt.Rows[0]["RevisedSMV"]);
                //if (dt.Rows.Count > 0)
                //{
                //    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                //                    "<th>Serial No</th>" +
                //                    "<th>Style Number</th>" +
                //                    "<th>Revision name</th>" +
                //                    "<th>Posted Date</th>" +
                //                    "</tr></thead >");
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        count++;

                //        tableRow.Append("<tbody><tr>");

                //        tableRow.Append("<td>" + count + "</td>");
                //        tableRow.Append("<td>" + dt.Rows[i]["StyleNumber"] + "</td>");
                //        tableRow.Append("<td>" + dt.Rows[i]["SampleStageName"] + "</td>");
                //        tableRow.Append("<td>" + dt.Rows[i]["PostedOn"] + "</td>");
                //        tableRow.Append("</tr></tbody>");
                //    }
                //    tableRow.Append("</table>");
                //}
                //else
                //{
                //    tableRow.Append("No Data Found");
                //}
            }
        }
        catch (Exception ex)
        {

        }
        return GetCostingSampleInfoByUserCount;
    }




    public int GetBulkStyleInfoByUser(int userId)
    {
        int GetBulkStyleInfoByUserCount = 0;
        DataTable dt = null;
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (ProfileGateway profileGateway = new ProfileGateway())
            {
                int count = 0;
                dt = profileGateway.GetBulkStyleInfoByUser(userId);
                GetBulkStyleInfoByUserCount = dt.Rows.Count;
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                                    "<th>Serial No</th>" +
                                    "<th>Style Number</th>" +
                                    "<th>Revision</th>" +
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr>");

                        tableRow.Append("<td>" + count + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["TotalCountOfSampleStage"] + "</td>");

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
        return GetBulkStyleInfoByUserCount;
    }

    public int GetBulkSampleInfoByUser(int userId)
    {
        int GetBulkSampleInfoByUserCount = 0;
        DataTable dt = null;
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (ProfileGateway profileGateway = new ProfileGateway())
            {
                int count = 0;
                dt = profileGateway.GetBulkSampleInfoByUser(userId);
                GetBulkSampleInfoByUserCount = Convert.ToInt32(dt.Rows[0]["RevisedBulk"]);
                //if (dt.Rows.Count > 0)
                //{
                //    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                //                    "<th>Serial No</th>" +
                //                    "<th>Style Number</th>" +
                //                    "<th>Revision name</th>" +
                //                    "<th>Posted Date</th>" +
                //                    "</tr></thead >");
                //    for (int i = 0; i < dt.Rows.Count; i++)
                //    {
                //        count++;

                //        tableRow.Append("<tbody><tr>");

                //        tableRow.Append("<td>" + count + "</td>");
                //        tableRow.Append("<td>" + dt.Rows[i]["StyleNumber"] + "</td>");
                //        tableRow.Append("<td>" + dt.Rows[i]["SampleStageName"] + "</td>");
                //        tableRow.Append("<td>" + dt.Rows[i]["PostedOn"] + "</td>");
                //        tableRow.Append("</tr></tbody>");
                //    }
                //    tableRow.Append("</table>");
                //}
                //else
                //{
                //    tableRow.Append("No Data Found");
                //}
            }
        }
        catch (Exception ex)
        {

        }
        return GetBulkSampleInfoByUserCount;
    }
}