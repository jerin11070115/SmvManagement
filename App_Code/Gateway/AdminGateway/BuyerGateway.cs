using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BuyerGateway
/// </summary>
public class BuyerGateway:KpGateway
{
    public int actionResult = 0;
    public BuyerGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable InsertBuyer(Buyers buyer)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@BuyerName", buyer.BuyerName));
            arlSqlParameter.Add(new SqlParameter("@IsActive", buyer.IsActive));
            arlSqlParameter.Add(new SqlParameter("@InsertedBy", buyer.PostedBy));
            arlSqlParameter.Add(new SqlParameter("@UpdatedBy", buyer.UpdatedBy));

            dt = this.ExecuteQuery("[kp].[USP_InsertBuyerInfo]", arlSqlParameter);
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

    public DataTable LodaBuyerInfo()
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            dt = this.ExecuteQuery("[KP].[USP_LoadBuyerInfo]", arlSqlParameter);
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


    public int UpdateBuyerInfo(Buyers buyer)
    {
        int dt = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@BuyerName", buyer.BuyerName));
            arlSqlParameter.Add(new SqlParameter("@IsActive", buyer.IsActive));
            arlSqlParameter.Add(new SqlParameter("@UpdatedBy", buyer.UpdatedBy));
            arlSqlParameter.Add(new SqlParameter("@BuyerId", buyer.BuyerId));
            dt = this.ExecuteActionQuery("[kp].[UpdateBuyerInfo]", arlSqlParameter);


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

    public DataTable LoadForUpdate(int buyerId)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@BuyerId", buyerId));
            dt = this.ExecuteQuery("[KP].[USP_LoadBuyerInfoById]", arlSqlParameter);
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
    public DataTable GetSendingMailInfo(int buyerId, int sampleStageId, int postedBy)
    {
        DataTable dt = null;
        try
        {

            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@BuyerId", buyerId));
            arlSqlParameter.Add(new SqlParameter("@SampleStageId", sampleStageId));
            arlSqlParameter.Add(new SqlParameter("@PostedBy", postedBy));
            dt = this.ExecuteQuery("[KP].[USP_GetSendingMailInfo]", arlSqlParameter);
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


}