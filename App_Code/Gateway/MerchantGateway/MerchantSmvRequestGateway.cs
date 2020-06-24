using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
/// <summary>
/// Summary description for MerchantSmvRequestGateway
/// </summary>
public class MerchantSmvRequestGateway:KpGateway
{
  public DataTable InsertMerchantSmvRequest(MerchantSmvRequestModel merchantSmvRequestModel)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@BuyerId", merchantSmvRequestModel.BuyerId));
            arlSqlParameter.Add(new SqlParameter("@SampleStageId", merchantSmvRequestModel.SampleStageId));
            arlSqlParameter.Add(new SqlParameter("@StyleNumber", merchantSmvRequestModel.StyleNumber));
            arlSqlParameter.Add(new SqlParameter("@FabricId", merchantSmvRequestModel.FabricId));
            arlSqlParameter.Add(new SqlParameter("@ProductCategoryId", merchantSmvRequestModel.ProductCategoryId));
            arlSqlParameter.Add(new SqlParameter("@ApproxOrderQtn", merchantSmvRequestModel.ApproxOrderQtn));
            arlSqlParameter.Add(new SqlParameter("@CostingDeadLine", merchantSmvRequestModel.CostingDeadLine));
            arlSqlParameter.Add(new SqlParameter("@Comments", merchantSmvRequestModel.Comments));
            arlSqlParameter.Add(new SqlParameter("@SendToUserId", merchantSmvRequestModel.SendToUserId));
            arlSqlParameter.Add(new SqlParameter("@PostedBy", merchantSmvRequestModel.PostedBy));
            arlSqlParameter.Add(new SqlParameter("@MerchantId", merchantSmvRequestModel.MerchantId));
            arlSqlParameter.Add(new SqlParameter("@IsActive", merchantSmvRequestModel.IsActive));
            arlSqlParameter.Add(new SqlParameter("@PreviousSampleStage", merchantSmvRequestModel.PreviousSampleStage));
            arlSqlParameter.Add(new SqlParameter("@DesignNumber", merchantSmvRequestModel.DesignNumber));
            arlSqlParameter.Add(new SqlParameter("@IsOption", merchantSmvRequestModel.IsOption));
            dt = this.ExecuteQuery("[KP].[USP_InsertMerchantSmvRequestInfo]", arlSqlParameter);

            return dt;
        }
        catch(Exception exc)
        {
            throw exc;
        }
        finally
        {
            CloseConnection();
        }
    }


    public DataTable InsertMerchantSmvRequestToRevise(MerchantSmvRequestModel merchantSmvRequestModel)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@BuyerId", merchantSmvRequestModel.BuyerId));
            arlSqlParameter.Add(new SqlParameter("@MerchantId", merchantSmvRequestModel.MerchantId));
            arlSqlParameter.Add(new SqlParameter("@SampleStageId", merchantSmvRequestModel.SampleStageId));
            arlSqlParameter.Add(new SqlParameter("@PreviousSampleStage", merchantSmvRequestModel.PreviousSampleStage));
            arlSqlParameter.Add(new SqlParameter("@IsActive", merchantSmvRequestModel.IsActive));
            arlSqlParameter.Add(new SqlParameter("@StyleNumber", merchantSmvRequestModel.StyleNumber));
            arlSqlParameter.Add(new SqlParameter("@DesignNumber", merchantSmvRequestModel.DesignNumber));
            arlSqlParameter.Add(new SqlParameter("@FabricId", merchantSmvRequestModel.FabricId));
            arlSqlParameter.Add(new SqlParameter("@ProductCategoryId", merchantSmvRequestModel.ProductCategoryId));
            arlSqlParameter.Add(new SqlParameter("@ReasonToRevised", merchantSmvRequestModel.ReasonToRevised));
            arlSqlParameter.Add(new SqlParameter("@ApproxOrderQtn", merchantSmvRequestModel.ApproxOrderQtn));
            arlSqlParameter.Add(new SqlParameter("@CostingDeadLine", merchantSmvRequestModel.CostingDeadLine));
            arlSqlParameter.Add(new SqlParameter("@Comments", merchantSmvRequestModel.Comments));
            arlSqlParameter.Add(new SqlParameter("@SendToUserId", merchantSmvRequestModel.SendToUserId));
            arlSqlParameter.Add(new SqlParameter("@PostedBy", merchantSmvRequestModel.PostedBy));
            arlSqlParameter.Add(new SqlParameter("@UpdatedBy", merchantSmvRequestModel.UpdatedBy));
            arlSqlParameter.Add(new SqlParameter("@IsOption", merchantSmvRequestModel.IsOption));

            dt = this.ExecuteQuery("[KP].[USP_InsertMerchantSmvRequestToRevise]", arlSqlParameter);
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


    public DataTable LoadPendingMerchantRequest(int MerchantId)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@MerchantId", MerchantId));
            dt = this.ExecuteQuery("[kp].[USP_GetAllMerchantRequestMerchantWise]", arlSqlParameter);
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


    public DataTable LoadReceivedMerchantSmvData(int MerchantId)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@MerchantId", MerchantId));
            dt = this.ExecuteQuery("[kp].[USP_GetMerchantReceivedReport]", arlSqlParameter);
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