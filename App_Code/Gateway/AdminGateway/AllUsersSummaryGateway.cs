using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AllUsersSummaryGateway
/// </summary>
public class AllUsersSummaryGateway:KpGateway
{
    public AllUsersSummaryGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetAllUsersNewCostingSummary(string fromDate, string toDate)
    {
        DataTable dt = null;

        try
        {
            OpenConnection();

            ArrayList arlSqlParameter = new ArrayList();

            arlSqlParameter.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameter.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[kp].[USP_AllUsersNewCostingSummary]", arlSqlParameter);
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

    public DataTable GetAllUsersRevisedCostingSummary(string fromDate, string toDate)
    {
        DataTable dt = null;

        try
        {
            OpenConnection();

            ArrayList arlSqlParameter = new ArrayList();

            arlSqlParameter.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameter.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[KP].[USP_AllUsersRevisedCostingSummary]", arlSqlParameter);
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




    public DataTable GetAllUsersNewBulkSummary(string fromDate, string toDate)
    {
        DataTable dt = null;

        try
        {
            OpenConnection();

            ArrayList arlSqlParameter = new ArrayList();

            arlSqlParameter.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameter.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[KP].[USP_AllUsersNewBulkSummary]", arlSqlParameter);
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

    public DataTable GetAllUsersRevisedBulkSummary(string fromDate, string toDate)
    {
        DataTable dt = null;

        try
        {
            OpenConnection();

            ArrayList arlSqlParameter = new ArrayList();

            arlSqlParameter.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameter.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[KP].[USP_AllUsersRevisedBulkSummary]", arlSqlParameter);
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



    public DataTable GetKpiReport(string fromDate, string toDate)
    {
        DataTable dt = null;

        try
        {
            OpenConnection();

            ArrayList arlSqlParameter = new ArrayList();

            arlSqlParameter.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameter.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[kp].[USP_KpiReport]", arlSqlParameter);
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

    public DataTable GetDailyKpiReport(string fromDate, string toDate)
    {
        DataTable dt = null;

        try
        {
            OpenConnection();

            ArrayList arlSqlParameter = new ArrayList();

            arlSqlParameter.Add(new SqlParameter("@FromDate", fromDate));
            arlSqlParameter.Add(new SqlParameter("@ToDate", toDate));

            dt = this.ExecuteQuery("[Reports].[USP_DailyKpiReports]", arlSqlParameter);
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