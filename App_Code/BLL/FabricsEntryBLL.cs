using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for FabricsEntryBLL
/// </summary>
public class FabricsEntryBLL
{
    public int actionResult = 0;
    public FabricsEntryBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int InsertFabricInfo(Fabrics fabric)
    {
        try
        {
            using (FabricGateway fabricsGateway = new FabricGateway())
            {
                actionResult = fabricsGateway.InsertStyleInfo(fabric);
            }
        }
        catch(Exception ex)
        {

        }
        return actionResult;
    }

    public string LoadFabricsInfo()
    {
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (FabricGateway fabricGateway=new FabricGateway())
            {
                int count = 0;
                DataTable dt = fabricGateway.LoadFabricsInfo();
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered' style='width: 80%;margin-left: 10%;'><thead><tr class='success'>" +
                                    "<th style=' width: 25 %; text-align:center;padding: 12px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff;'>Serial No</th>" +
                                    "<th style=' width: 25 %; text-align:center;padding: 12px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff;'>Fabric Type</th>" +
                                    "<th style=' width: 25 %; text-align:center;padding: 12px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff;'>Fabric Name</th>" +
                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr style='border:1px solid #ffffff;background-color:lavender;'>");

                        tableRow.Append("<td style='width: 25 %;text-align:center;border: 2px solid #ffffff;padding:5px;color: black;'>" + count + "</td>");
                        tableRow.Append("<td style='width: 25 %;text-align:center;border: 2px solid #ffffff;padding:5px;color: black;'>" + dt.Rows[i]["FabricType"] + "</td>");
                        tableRow.Append("<td style='width: 25 %;text-align:center;border: 2px solid #ffffff;padding:5px;color: black;'>" + dt.Rows[i]["FabricName"] + "</td>");
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

}