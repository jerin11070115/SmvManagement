using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for ProductEntryBLL
/// </summary>
public class ProductEntryBLL
{
    public int actionResult = 0;
    public ProductEntryBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int InsertProductInfo(Products product)
    {
        try
        {
            using (ProductGateway productGateway = new ProductGateway())
            {
                actionResult = productGateway.InsertProductInfo(product);
            }
        }
        catch(Exception ex)
        {

        }
        return actionResult;
    }
    public string LoadProductInfo()
    {
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (ProductGateway productGateway= new ProductGateway())
            {
                int count = 0;
                DataTable dt = productGateway.LoadProductsInfo();
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                                    "<th style='text-align:center;padding: 12px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff'>Serial No</th>" +
                                    // "<th>Product Type</th>" +
                                    "<th style='text-align:center;padding: 12px; color: #FFFFFF; background-color:#0099FF;border: 2px solid #ffffff'>Product Category Name</th>" +
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr style='border:1px solid #ffffff;background-color:lavender;'>");

                        tableRow.Append("<td  style='text-align:center; border: 2px solid #ffffff;padding: 5px;color: black;'>" + count + "</td>");
                       // tableRow.Append("<td>" + dt.Rows[i]["ProductType"] + "</td>");
                        tableRow.Append("<td style='text-align:center; border: 2px solid #ffffff;padding: 5px;color: black;'>" + dt.Rows[i]["ProductName"] + "</td>");
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