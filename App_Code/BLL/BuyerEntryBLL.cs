using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for BuyerEntryBLL
/// </summary>
public class BuyerEntryBLL
{
    public int actionResult = 0;
    public BuyerEntryBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable InsertBuyer(Buyers buyer)
    {
        DataTable dt = null;

        using (BuyerGateway buyerGateway = new BuyerGateway())
        {
            dt = buyerGateway.InsertBuyer(buyer);
        }
        return dt;

    }
    public string LoadBuyerInfo()
    {
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (BuyerGateway buyerGateway = new BuyerGateway())
            {
                int count = 0;
                DataTable dt = buyerGateway.LodaBuyerInfo();
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered;'><thead><tr class='success'>" +
                                    "<th style='width: 25 %;text-align:center;padding: 12px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff'>Sl</th>" +
                                    "<th style='width: 25 %;text-align:center;padding: 12px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff'>Buyer Id</th>" +
                                    "<th style='width: 25 %;text-align:center;padding: 12px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff'>Buyer Name</th>" +
                                    "<th style='width: 25 %;text-align:center;padding: 12px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff'>Is Active</th>" +
                                    "<th style='width: 25 %;text-align:center;padding: 12px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff'>Action</th>" +
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr style='border:1px solid #ffffff;background-color:lavender;'>");

                        tableRow.Append("<td style='text-align:center; border: 2px solid #ffffff'>" + count + "</td>");
                        tableRow.Append("<td style='width: 25 %;text-align:center; border: 2px solid #ffffff;padding: 5px;color: black;'>" + dt.Rows[i]["BuyerId"] + "</td>");
                        tableRow.Append("<td style='width: 25 %;text-align:center; border: 2px solid #ffffff;padding: 5px;color: black;'>" + dt.Rows[i]["BuyerName"] + "</td>");
                        tableRow.Append("<td style='width: 25 %;text-align:center; border: 2px solid #ffffff;padding: 5px;color: black;'>" + dt.Rows[i]["IsActive"] + "</td>");
                        tableRow.Append("<td style='width: 25 %;text-align:center; border: 2px solid #ffffff;padding: 5px;color: black;'><a href='BuyerEntry.aspx?Id=" + dt.Rows[i]["BuyerId"] + "'>Edit</a></td>");
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

    public int UpdateBuyerInfo(Buyers buyer)
    {
        int dt =0;
        try
        {
            using (BuyerGateway buyerGateway = new BuyerGateway())
            {
                dt = buyerGateway.UpdateBuyerInfo(buyer);
            }
        }
        catch(Exception ex)
        {

        }
        return dt;
    }
}