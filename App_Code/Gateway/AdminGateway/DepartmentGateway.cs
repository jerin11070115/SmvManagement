using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DepartmentGateway
/// </summary>
public class DepartmentGateway:KpGateway
{
    public int actionResult = 0;
    public DepartmentGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int InsertDepartment(Departments department)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@DepartmentName", department.DepartmentName));
            actionResult = this.ExecuteActionQuery("[Kp].[USP_InsertDepartmentInfo]", arlSqlParameter);
        }
        catch(Exception ex)
        {

        }
        finally
        {
            CloseConnection();
        }
        return actionResult;
    }
    public DataTable LoadDepartmentInfo()
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            dt = this.ExecuteQuery("[kp].[USP_LoadDepartmentInfo]", arlSqlParameter);

        }
        catch(Exception ex)
        {

        }
        finally
        {
            CloseConnection();
        }
        return dt;
    }
}