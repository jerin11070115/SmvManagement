using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BulkSmvGateway
/// </summary>
public class BulkSmvGateway:KpGateway
{
    public BulkSmvGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable LodaStyleInfo()
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            dt = this.ExecuteQuery("[KP].[USP_StyleInfo]", arlSqlParameter);
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


    public DataTable InsertBulkSMV(BulkSmv bulk)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();

            arlSqlParameter.Add(new SqlParameter("@BuyerId", bulk.BuyerId));
            arlSqlParameter.Add(new SqlParameter("@SampleStageId", bulk.SampleStageId));

            //arlSqlParameter.Add(new SqlParameter("@StyleId", bulk.StyleId));
            arlSqlParameter.Add(new SqlParameter("@StyleNumber", bulk.StyleNumber));
            arlSqlParameter.Add(new SqlParameter("@StyleDescription", bulk.StyleDescription));

            arlSqlParameter.Add(new SqlParameter("@FabricId", bulk.FabricId));
            arlSqlParameter.Add(new SqlParameter("@SewingSmv", bulk.SewingSmv));
            arlSqlParameter.Add(new SqlParameter("@OverlayFilm", bulk.OverlaySmv));
            arlSqlParameter.Add(new SqlParameter("@Fits", bulk.FitsSmv));
            arlSqlParameter.Add(new SqlParameter("@PLKQuiltingSmv", bulk.PlkQuilting));
            arlSqlParameter.Add(new SqlParameter("@AutoQuiltingSmv", bulk.AutoQuilting));
            arlSqlParameter.Add(new SqlParameter("@ManualQuiltingSmv", bulk.ManualQuilting));
            arlSqlParameter.Add(new SqlParameter("@ManualDownFill", bulk.ManualDownFill));
            arlSqlParameter.Add(new SqlParameter("@MachineDownFill", bulk.MachineDownFill));

            arlSqlParameter.Add(new SqlParameter("@FinishingSmv", bulk.FinishingSmv));

            arlSqlParameter.Add(new SqlParameter("@CostingSmvId", bulk.CostingSmvId));

            //arlSqlParameter.Add(new SqlParameter("@OptionData", data));

            arlSqlParameter.Add(new SqlParameter("@ReviewBy", bulk.ReviewBy));
            arlSqlParameter.Add(new SqlParameter("@ApprovedBy", bulk.ApprovedBy));
            arlSqlParameter.Add(new SqlParameter("@PostedBy", bulk.PostedBy));
            arlSqlParameter.Add(new SqlParameter("@UpdatedBy", bulk.UpdatedBy));

            arlSqlParameter.Add(new SqlParameter("@ProductCategory", bulk.ProductCategory));
            arlSqlParameter.Add(new SqlParameter("@SampleDate", bulk.SampleDate));
            //arlSqlParameter.Add(new SqlParameter("@WorkUpdate", bulk.WorkUpdate));
            arlSqlParameter.Add(new SqlParameter("@MachineWork", bulk.MachineWork));
            arlSqlParameter.Add(new SqlParameter("@Description", bulk.Description));

			arlSqlParameter.Add(new SqlParameter("@SeasonId", bulk.SeasonId));

			dt = this.ExecuteQuery("[kp].[USP_InsertBulkSmvInfo]", arlSqlParameter);
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


	public DataTable InsertBulkRevisedSmv(BulkSmv bulk)
	{
		DataTable dt = null;
		try
		{
			OpenConnection();
			ArrayList arlSqlParameter = new ArrayList();

			arlSqlParameter.Add(new SqlParameter("@BuyerId", bulk.BuyerId));
			arlSqlParameter.Add(new SqlParameter("@SampleStageId", bulk.SampleStageId));

			//arlSqlParameter.Add(new SqlParameter("@StyleId", bulk.StyleId));
			arlSqlParameter.Add(new SqlParameter("@StyleNumber", bulk.StyleNumber));
			arlSqlParameter.Add(new SqlParameter("@StyleDescription", bulk.StyleDescription));

			arlSqlParameter.Add(new SqlParameter("@FabricId", bulk.FabricId));
			arlSqlParameter.Add(new SqlParameter("@SewingSmv", bulk.SewingSmv));
			arlSqlParameter.Add(new SqlParameter("@OverlayFilm", bulk.OverlaySmv));
			arlSqlParameter.Add(new SqlParameter("@Fits", bulk.FitsSmv));
			arlSqlParameter.Add(new SqlParameter("@PLKQuiltingSmv", bulk.PlkQuilting));
			arlSqlParameter.Add(new SqlParameter("@AutoQuiltingSmv", bulk.AutoQuilting));
			arlSqlParameter.Add(new SqlParameter("@ManualQuiltingSmv", bulk.ManualQuilting));
			arlSqlParameter.Add(new SqlParameter("@ManualDownFill", bulk.ManualDownFill));
			arlSqlParameter.Add(new SqlParameter("@MachineDownFill", bulk.MachineDownFill));

			arlSqlParameter.Add(new SqlParameter("@FinishingSmv", bulk.FinishingSmv));

			arlSqlParameter.Add(new SqlParameter("@CostingSmvId", bulk.CostingSmvId));

			//arlSqlParameter.Add(new SqlParameter("@OptionData", data));

			arlSqlParameter.Add(new SqlParameter("@ReviewBy", bulk.ReviewBy));
			arlSqlParameter.Add(new SqlParameter("@ApprovedBy", bulk.ApprovedBy));
			arlSqlParameter.Add(new SqlParameter("@PostedBy", bulk.PostedBy));
			arlSqlParameter.Add(new SqlParameter("@UpdatedBy", bulk.UpdatedBy));

			arlSqlParameter.Add(new SqlParameter("@ProductCategory", bulk.ProductCategory));
			arlSqlParameter.Add(new SqlParameter("@SampleDate", bulk.SampleDate));
			//arlSqlParameter.Add(new SqlParameter("@WorkUpdate", bulk.WorkUpdate));
			arlSqlParameter.Add(new SqlParameter("@MachineWork", bulk.MachineWork));
			arlSqlParameter.Add(new SqlParameter("@Description", bulk.Description));

			arlSqlParameter.Add(new SqlParameter("@SeasonId", bulk.SeasonId));

			dt = this.ExecuteQuery("[KP].[USP_InsertBulkRevisedSmvInfo]", arlSqlParameter);
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

    public DataTable LoadNewBulkSmvInfo(int buyerId,string styleNumber)
    {
        DataTable dt = null;
        try
        {

            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@StyleNumber", styleNumber));
            arlSqlParameter.Add(new SqlParameter("@BuyerId", buyerId));
            dt = this.ExecuteQuery("[kp].[USP_LoadBulkSmvInfo]", arlSqlParameter);

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

    public DataTable LoadRevisedBulkSmvInfo(int buyerId, string styleNumber)
    {
        DataTable dt = null;
        try
        {

            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@StyleNumber", styleNumber));
            arlSqlParameter.Add(new SqlParameter("@BuyerId", buyerId));
            dt = this.ExecuteQuery("[KP].[USP_LoadRevisedBulkSmvInfo]", arlSqlParameter);

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


    public DataTable LoadBulkInfoForUpdate(int bulkSmvId)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@BulkSmvId", bulkSmvId));
            dt = this.ExecuteQuery("[Kp].[LoadBulkInfoForUpdate]", arlSqlParameter);
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


    public int UpdateBulkInfo (BulkSmv bulk)
    {
        int actionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();

            arlSqlParameter.Add(new SqlParameter("@BuklSmvId", bulk.BulkSmvId));
            arlSqlParameter.Add(new SqlParameter("@BuyerId", bulk.BuyerId));
            arlSqlParameter.Add(new SqlParameter("@SampleStageId", bulk.SampleStageId));
            //arlSqlParameter.Add(new SqlParameter("@StyleId", bulk.StyleId));

            arlSqlParameter.Add(new SqlParameter("@StyleNumber", bulk.StyleNumber));
            arlSqlParameter.Add(new SqlParameter("@StyleDescription", bulk.StyleDescription));

            arlSqlParameter.Add(new SqlParameter("@FabricId", bulk.FabricId));
            arlSqlParameter.Add(new SqlParameter("@SewingSmv", bulk.SewingSmv));
            arlSqlParameter.Add(new SqlParameter("@OverlayFilm", bulk.OverlaySmv));
            arlSqlParameter.Add(new SqlParameter("@Fits", bulk.FitsSmv));
            arlSqlParameter.Add(new SqlParameter("@PLKQuiltingSmv", bulk.PlkQuilting));
            arlSqlParameter.Add(new SqlParameter("@AutoQuiltingSmv", bulk.AutoQuilting));
            arlSqlParameter.Add(new SqlParameter("@ManualQuiltingSmv", bulk.ManualQuilting));
            arlSqlParameter.Add(new SqlParameter("@ManualDownFill", bulk.ManualDownFill));
            arlSqlParameter.Add(new SqlParameter("@MachineDownFill", bulk.MachineDownFill));

            arlSqlParameter.Add(new SqlParameter("@FinishingSmv", bulk.FinishingSmv));

            arlSqlParameter.Add(new SqlParameter("@ReviewBy", bulk.ReviewBy));
            arlSqlParameter.Add(new SqlParameter("@ApprovedBy", bulk.ApprovedBy));            
            arlSqlParameter.Add(new SqlParameter("@UpdatedBy", bulk.UpdatedBy));

            arlSqlParameter.Add(new SqlParameter("@ProductCategory", bulk.ProductCategory));
            arlSqlParameter.Add(new SqlParameter("@SampleDate", bulk.SampleDate));
            //arlSqlParameter.Add(new SqlParameter("@WorkUpdate", bulk.WorkUpdate));
            arlSqlParameter.Add(new SqlParameter("@MachineWork", bulk.MachineWork));
            arlSqlParameter.Add(new SqlParameter("@Description", bulk.Description));
			arlSqlParameter.Add(new SqlParameter("@SeasonId", bulk.SeasonId));

			actionResult = this.ExecuteActionQuery("[kp].[USP_UpdateBulkSmvInfo]", arlSqlParameter);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            CloseConnection();
        }
        return actionResult;
    }


    //for Bulk SMV Report
    public DataTable LoadBulkSmvreportInfo(int buyerId, string styleNumber)
    {
        DataTable dt=null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();

            arlSqlParameter.Add(new SqlParameter("@BuyerId", buyerId));
            arlSqlParameter.Add(new SqlParameter("@StyleNumber", styleNumber));

            dt=this.ExecuteQuery("[kp].[USP_LoadBalkSmvReport]", arlSqlParameter);

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

    public DataTable LoadBulkSmvDetailsReportInfo(int buyerId, string styleNumber)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();

            arlSqlParameter.Add(new SqlParameter("@BuyerId", buyerId));
            arlSqlParameter.Add(new SqlParameter("@StyleNumber", styleNumber));

            dt = this.ExecuteQuery("[KP].[USP_LoadBalkSmvLogReport]", arlSqlParameter);

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



    //public DataTable LoadBuyerWiseStyleNumber(int buyerId)
    //{
    //    DataTable dt = null;
    //    try
    //    {
    //        OpenConnection();
    //        ArrayList arlSqlParam = new ArrayList();

    //        arlSqlParam.Add(new SqlParameter("@BuyerId", buyerId));
    //        dt = this.ExecuteQuery("[kp].[LoadStyleNumberByBuyer]", arlSqlParam);
    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    finally
    //    {
    //        CloseConnection();
    //    }
    //    return dt;
    //}



    //suggestion
    public List<Tuple<string>> Get_SuggestionForStyleNumberforBulk(string keyWord)
    {
        DataTable objDatatable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@keyword", keyWord));

            objDatatable = this.ExecuteQuery("[kp].[USP_StyleNumberForSearchForBulk]", arlSQLParameters);
            List<Tuple<string>> list = new List<Tuple<string>>();
            list = (from data in objDatatable.AsEnumerable() select (new Tuple<string>(data["StyleNumber"].ToString())))
                    .ToList();
            return list;
        }
        catch (Exception exception)
        {
            throw new Exception(exception.Message);
        }
        finally
        {
            this.CloseConnection();
        }
    }



 

    public DataTable LoadBuyersStyleInfoFromBulk(string fromDate, string toDate)
    {
        DataTable dt = null;
        try
        {

            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@fromDate", fromDate));
            arlSqlParameter.Add(new SqlParameter("@toDate", toDate));
            dt = this.ExecuteQuery("[Reports].[USP_GetBuyersStyleInfoFromBulk]", arlSqlParameter);

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
    public DataTable LoadComponentSmv(int BuyerId, string StyleNumber)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@BuyerId", BuyerId));
            arlSqlParameter.Add(new SqlParameter("@Stylenumber", StyleNumber));
            dt = this.ExecuteQuery("[KP].[USP_ComponentSmv]", arlSqlParameter);
            return dt;
        }
        catch (Exception ex) {
            throw ex;
        }
        finally
        {
            CloseConnection();
        }
    }
}