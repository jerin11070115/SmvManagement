using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;

/// <summary>
/// Summary description for AcountBLL
/// </summary>
public class AcountBLL
{
    public AcountBLL()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable InsertNewAccount(UserAccount userAccount)
    {
        DataTable dt = null;
        try
        {
            using (AccountGateway accountGateway = new AccountGateway())
            {
                dt = accountGateway.InsertNewAccount(userAccount);
            }
        }
        catch(Exception ex)
        {

        }
        return dt;
    }
    public string LoadUserInformation()
    {
        DataTable dt = null;
        StringBuilder tableRow = new StringBuilder();
        try
        {
            using (AccountGateway accountGateway = new AccountGateway())
            {
                int count = 0;
                dt = accountGateway.LoadUserInformation();
                if (dt.Rows.Count > 0)
                {
                    tableRow.Append("<table class='table table-bordered'><thead><tr class='success'>" +
                                    "<th>Serial No</th>" +
                                    "<th>User Name</th>" +
                                    "<th>User Password</th>" +
                                    "<th>Full Name</th>" +
                                    "<th>IsActive</th>" +
                                    "<th>Admin Type</th>" +
                                    "<th>Zone Name</th>" +
                                    "<th>Inserted On</th>" +
                                    "<th>Inserted By</th>" +
                                    "<th>Updated On</th>" +
                                    "<th>Updated By</th>" +
                                     "<th>Action</th>" +
                                    "</tr></thead >");
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        count++;

                        tableRow.Append("<tbody><tr>");

                        tableRow.Append("<td>" + count + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["UserName"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["UserPassword"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["FullName"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["IsActive"] + "</td>");

                        //tableRow.Append("<td>" + dt.Rows[i]["AdminType"] + "</td>");
                        string admin = dt.Rows[i]["AdminType"].ToString();

                        if(admin=="1")
                        {
                            tableRow.Append("<td>" + "Admin" + "</td>");
                        }
                        if (admin == "2")
                        {
                            tableRow.Append("<td>" + "Manager" + "</td>");
                        }
                        if (admin == "3")
                        {
                            tableRow.Append("<td>" + "User" + "</td>");
                        }

                        tableRow.Append("<td>" + dt.Rows[i]["ZoneName"] + "</td>");

                        tableRow.Append("<td>" + dt.Rows[i]["InsertedOn"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["InsertedBy"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["UpdatedOn"] + "</td>");
                        tableRow.Append("<td>" + dt.Rows[i]["UpdatedBy"] + "</td>");
                        tableRow.Append("<td><a href='NewAccount.aspx?Id=" + dt.Rows[i]["UserId"] + "'>Edit</a></td>");
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

    public DataTable LoadUserInfoById(int UserId)
    {
        DataTable dt = null;
        try
        {
            using (AccountGateway account = new AccountGateway())
            {
                dt = account.LoadUserInfoById(UserId);
            }
        }
        catch(Exception ex)
        {

        }
        return dt;
    }

    public int UpdateUserAccount(UserAccount account)
    {
        int actionResult = 0;
        try
        {
            using (AccountGateway accountGateway = new AccountGateway())
            {
                actionResult = accountGateway.UpdateUserAccount(account);
            }
        }
        catch(Exception ex)
        {

        }
        return actionResult;
    }
}