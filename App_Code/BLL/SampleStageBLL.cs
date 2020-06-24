using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for SampleStageBLL
/// </summary>
public class SampleStageBLL
{
    public int actionResult = 0;
    public SampleStageBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable InsertSampleStage(SampleStage sample)
    {
        DataTable dt = null;
        try
        {
            using (SampleStageGateway sampleStageGateway = new SampleStageGateway())
            {
                dt = sampleStageGateway.InsertsampleStage(sample);
            }
        }
        catch(Exception ex)
        {

        }
        return dt;
    }

    public int UpdateSampleStageInfo(SampleStage sample)
    {
        try
        {
            using (SampleStageGateway sampleStageGateway = new SampleStageGateway())
            {
                actionResult = sampleStageGateway.UpdateSampleStage(sample);
            }
        }
        catch(Exception ex)
        {

        }
        return actionResult;
    }


    public string LoadsampleStage()
    {
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (SampleStageGateway sampleStageGateway=new SampleStageGateway())
            {
                int count = 0;
                DataTable dt = sampleStageGateway.LoadSampleStage();
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                                    "<th style=' width: 25 %; text-align:center;padding: 10px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff;'>Serial No</th>" +
                                    "<th style=' width: 25 %; text-align:center;padding: 10px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff;'>Buyer Name</th>" +
                                    "<th style=' width: 25 %; text-align:center;padding: 10px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff;'>Sample Stage</th>" +
                                    "<th style=' width: 25 %; text-align:center;padding: 10px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff;'>IsActive</th>" +
                                    "<th style=' width: 25 %; text-align:center;padding: 10px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff;'>Action</th>" +
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr style='background-color:lavender;'>");

                        tableRow.Append("<td style='width: 25 %;text-align:center;border: 2px solid #ffffff;padding:5px;color: black;'>" + count + "</td>");
                        tableRow.Append("<td style='width: 25 %;text-align:center;border: 2px solid #ffffff;padding:5px;color: black;'>" + dt.Rows[i]["BuyerName"] + "</td>");
                        tableRow.Append("<td style='width: 25 %;text-align:center;border: 2px solid #ffffff;padding:5px;color: black;'>" + dt.Rows[i]["SampleStageName"] + "</td>");
                        tableRow.Append("<td style='width: 25 %;text-align:center;border: 2px solid #ffffff;padding:5px;color: black;'>" + dt.Rows[i]["IsActive"] + "</td>");
                        tableRow.Append("<td style='width: 25 %;text-align:center;border: 2px solid #ffffff;padding:5px;color: black;'><a href='SampleStageEntry.aspx?Id=" + dt.Rows[i]["SampleStageId"] + "'>Edit</a></td>");
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


    public DataTable LoadBuyerName()
    {
        DataTable dt = null;
        try
        {
            using (BuyerGateway buyerGateway = new BuyerGateway())
            {
                dt = buyerGateway.LodaBuyerInfo();
            }
        }
        catch(Exception ex)
        {

        }
        return dt;
    }

}