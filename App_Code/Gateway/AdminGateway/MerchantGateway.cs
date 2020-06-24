using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MerchantGateway
/// </summary>
public class MerchantGateway:KpGateway
{

    public DataTable InsertNewMerchant(MerchantModel merchant)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@MerchantName", merchant.MerchantName));
            arlSqlParameter.Add(new SqlParameter("@LoginId", merchant.LoginId));
            arlSqlParameter.Add(new SqlParameter("@Password", merchant.Password));
            arlSqlParameter.Add(new SqlParameter("@PostedBy", merchant.PostedBy));
            arlSqlParameter.Add(new SqlParameter("@IsActive", merchant.IsActive));
            dt = this.ExecuteQuery("[kp].[USP_InsertNewMerchant]", arlSqlParameter);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable GetMerchantInfo( int merchantId)
    {
        DataTable dt = new DataTable();
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@MerchantId", merchantId));
            dt = this.ExecuteQuery("[kp].[GetAllMerchantInfo]", arlSqlParameter);
            return dt;
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
        
    }
    public int UpdateMerchantInfo(MerchantModel merchant)
    {
        int actionResult = 0;
        try
        {
            OpenConnection();

            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@MerchantId", merchant.MerchantId));
            arlSqlParameter.Add(new SqlParameter("@MerchantName", merchant.MerchantName));
            arlSqlParameter.Add(new SqlParameter("@LogInId", merchant.LoginId));
            arlSqlParameter.Add(new SqlParameter("@Password", merchant.Password));
            arlSqlParameter.Add(new SqlParameter("@IsActive", merchant.IsActive));
            arlSqlParameter.Add(new SqlParameter("@UpdatedBy", merchant.UpdatedBy));

            actionResult = this.ExecuteActionQuery("[kp].[USP_UpdateMerchantinfo]", arlSqlParameter);
            return actionResult;
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
    }
    public DataTable LoadMerchantRequest(int userId)
    {
        DataTable dt = null;
        try
        {
            

            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@SendTo", userId));

            dt = this.ExecuteQuery("[kp].[USP_GetAllMerchantRequestUserWise]", arlSqlParameter);
            return dt;
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
    }


	public DataTable LoadAllPendingSmvRequestOfCurrentDate(string FromDate, string Todate)
	{
		DataTable dt = null;
		try
		{
			OpenConnection();
			ArrayList arlSqlParameter = new ArrayList();
			arlSqlParameter.Add(new SqlParameter("@FromDate", FromDate));
			arlSqlParameter.Add(new SqlParameter("@ToDate", Todate));
			dt = this.ExecuteQuery("[Reports].[USP_GetAllPendingSmvRequestOfCurrentDate]", arlSqlParameter);
			return dt;
		}
		catch (Exception ex)
		{
			throw ex;
		}
		finally {
			CloseConnection();
		}
	}


	public DataTable LoadMerchantRequestInfoRequestIdWise(int requestId)
    {
        DataTable dt = null;
        try
        {


            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@RequestId", requestId));
            dt = this.ExecuteQuery("[kp].[USP_GetAllMerchantRequestIdWise]", arlSqlParameter);
            return dt;
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
    }
    public int UpdateMerchantRequest(int RequestId)
    {
        int actionResult = 0;
        try
        {
            OpenConnection();

            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@RequestId", RequestId));
            actionResult = this.ExecuteActionQuery("[kp].[USP_UpdateMerchantRequestforSendData]", arlSqlParameter);

            return actionResult;
        }
        catch(Exception ex)
        {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
    }
}