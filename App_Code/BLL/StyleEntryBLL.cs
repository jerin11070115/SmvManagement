using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for StyleEntryBLL
/// </summary>
public class StyleEntryBLL
{
    public int actionResult = 0; 
    public StyleEntryBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int InsertStyleInfo(Style style)
    {
        try
        {
            using(StyleGateway styleGateway=new StyleGateway())
            {
                actionResult = styleGateway.InsertStyleInfo(style);
            }
        }
        catch(Exception ex)
        {

        }
        return actionResult;
    }

    public string LoadStyleInfo()
    {
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using(StyleGateway styleGateway=new StyleGateway())
            {
                int count = 0;
                DataTable dt = styleGateway.LoadstyleInfo();
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                                    "<th>Serial No</th>" +
                                    "<th>Style Number</th>" +
                                    "<th>Style Description</th>" +                                    
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr>");

                        tableRow.Append("<td>" + count + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["StyleNumber"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["StyleDescription"] + "</td>");
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