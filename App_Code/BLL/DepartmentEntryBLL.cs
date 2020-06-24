using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for DepartmentEntryBLL
/// </summary>
public class DepartmentEntryBLL
{
    public int actionResult = 0;
    public DepartmentEntryBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int InsertDepartmentInfo(Departments department)
    {
        try
        {
            using (DepartmentGateway departmentGateway = new DepartmentGateway())
            {
                actionResult = departmentGateway.InsertDepartment(department);
            }
        }
        catch(Exception ex)
        {

        }
        return actionResult;
    }
    public string LoadDepartmentInfo()
    {
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (DepartmentGateway departmentGateway = new DepartmentGateway())
            {
                int count = 0;
                DataTable dt = departmentGateway.LoadDepartmentInfo();
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead><tr>" +
                                    "<th>Sl</th>" +
                                    "<th>department Id</th>" +
                                    "<th>department Name</th>" +
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr>");

                        tableRow.Append("<td>" + count + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["departmentId"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["departmentName"] + "</td>");
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