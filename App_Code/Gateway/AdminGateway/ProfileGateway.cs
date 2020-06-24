using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProfileGateway
/// </summary>
public class ProfileGateway:KpGateway
{

    public ProfileGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GetUserProfileName(int UserId)
    {
        DataTable dt = null;

        try
        {
            OpenConnection();

            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@UserId", UserId));
            dt = this.ExecuteQuery("[kp].[USP_GetUserProfileInfo]", arlSqlParameter);
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

    public DataTable GetUsersPerformance(int UserId)
    {
        DataTable dt = null;

        try
        {
            OpenConnection();

            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@userId", UserId));
            dt = this.ExecuteQuery("[kp].[GetUserPerformancInfo]", arlSqlParameter);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            CloseConnection();
        }
        return dt;
    }



    public DataTable GetCostingStyleInfoByUser(int UserId)
    {
        DataTable dt = null;

        try
        {
            OpenConnection();

            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@userId", UserId));
            dt = this.ExecuteQuery("[kp].[USP_GetCostingStyleInfoByUser]", arlSqlParameter);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            CloseConnection();
        }
        return dt;
    }
    public DataTable GetCostingSampleInfoByUser(int UserId)
    {
        DataTable dt = null;

        try
        {
            OpenConnection();

            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@userId", UserId));
            dt = this.ExecuteQuery("[kp].[USP_GetCostingSampleInfoByUser]", arlSqlParameter);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            CloseConnection();
        }
        return dt;
    }



    public DataTable GetBulkStyleInfoByUser(int UserId)
    {
        DataTable dt = null;

        try
        {
            OpenConnection();

            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@userId", UserId));
            dt = this.ExecuteQuery("[kp].[USP_GetBulkStyleInfoByUser]", arlSqlParameter);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            CloseConnection();
        }
        return dt;
    }


    public DataTable GetBulkSampleInfoByUser(int UserId)
    {
        DataTable dt = null;

        try
        {
            OpenConnection();

            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@userId", UserId));
            dt = this.ExecuteQuery("[kp].[USP_GetBulkSampleInfoByUser]", arlSqlParameter);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            CloseConnection();
        }
        return dt;
    }

}