using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SampleStageGateway
/// </summary>
public class SampleStageGateway:KpGateway
{
    public int actionResult = 0;
    public SampleStageGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable InsertsampleStage(SampleStage sample)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();

            arlSqlParameter.Add(new SqlParameter("@SampleStageName", sample.SampleStageName));
            arlSqlParameter.Add(new SqlParameter("@BuyerId", sample.BuyerId));
            arlSqlParameter.Add(new SqlParameter("@IsActive", sample.IsActive));
            arlSqlParameter.Add(new SqlParameter("@InsertedBy", sample.PostedBy));
            arlSqlParameter.Add(new SqlParameter("@UpdatedBy", sample.UpdatedBy));


            dt = this.ExecuteQuery("[kp].[USP_InsertSampleStage]", arlSqlParameter);
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

    public DataTable LoadSampleStage()
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            dt = this.ExecuteQuery("[kp].[USP_LoadSampleStage]", arlSqlParameter);
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

    public DataTable LoadDataForUpdate(int sampleStageId)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@SampleStageId", sampleStageId));
            dt = this.ExecuteQuery("[kp].[USP_LoadSampleStageBySampleStageId]", arlSqlParameter);
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

    public int UpdateSampleStage(SampleStage sample)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();

            arlSqlParameter.Add(new SqlParameter("@SampleStageId", sample.SampleStageId));
            arlSqlParameter.Add(new SqlParameter("@SampleStageName", sample.SampleStageName));
            arlSqlParameter.Add(new SqlParameter("@BuyerId", sample.BuyerId));
            arlSqlParameter.Add(new SqlParameter("@IsActive", sample.IsActive));
            arlSqlParameter.Add(new SqlParameter("@UpdatedBy", sample.UpdatedBy));

            actionResult =this.ExecuteActionQuery("[kp].[USP_UpdateSampleStage]",arlSqlParameter);
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


}