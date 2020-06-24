using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SmvEntryGateway
/// </summary>
public class SmvEntryGateway : KpGateway
{
    public SmvEntryGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable LoadBuyerWiseSampleStage(int buyerId)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParam = new ArrayList();

            arlSqlParam.Add(new SqlParameter("@BuyerId", buyerId));
            dt = this.ExecuteQuery("[kp].[USP_LoadSamplestageById]", arlSqlParam);
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


    public DataTable LoadFabric()
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParam = new ArrayList();
            dt = this.ExecuteQuery("[kp].[LoadFabricInfo]", arlSqlParam);

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


    public DataTable LoadUserName()
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParam = new ArrayList();
            dt = this.ExecuteQuery("[kp].[USP_LoadUsers]", arlSqlParam);
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

    public DataTable InsertCostingSMV(CostingSmv smv, DataTable data)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@BuyerId", smv.BuyerId));
            arlSqlParameter.Add(new SqlParameter("@SampleStageId", smv.SampleStageId));
            arlSqlParameter.Add(new SqlParameter("@StyleNumber", smv.StyleNumber));
            arlSqlParameter.Add(new SqlParameter("@DesignNumber", smv.DesignNumber));
            arlSqlParameter.Add(new SqlParameter("@StyleDescription", smv.StyleDescription));
            arlSqlParameter.Add(new SqlParameter("@FabricId", smv.FabricId));
            arlSqlParameter.Add(new SqlParameter("@DepartmentName", smv.Department));
            arlSqlParameter.Add(new SqlParameter("@SwingSmv", smv.SewingSmv));
            arlSqlParameter.Add(new SqlParameter("@PleatingSmv", smv.PleatingSmv));

            arlSqlParameter.Add(new SqlParameter("@PermanentCrease", smv.PermanentCrease));
            arlSqlParameter.Add(new SqlParameter("@SupperCrease", smv.SupperCrease));

            arlSqlParameter.Add(new SqlParameter("@HeatSealHeatSmv", smv.HeatSeal));
            arlSqlParameter.Add(new SqlParameter("@OverlayFilmHeatSmv", smv.OverlayFilm));
            arlSqlParameter.Add(new SqlParameter("@PLKQuiltingSmv", smv.PLKQuilting));
            arlSqlParameter.Add(new SqlParameter("@AutoQuiltingSmv", smv.AutoQuilting));
            arlSqlParameter.Add(new SqlParameter("@ManualQuiltingSmv", smv.ManualQuilting));
            arlSqlParameter.Add(new SqlParameter("@ManualDownFill", smv.ManualDownFill));
            arlSqlParameter.Add(new SqlParameter("@MachineDownFill", smv.MachineDownFill));
            arlSqlParameter.Add(new SqlParameter("@SeamSeal", smv.SeamSeal));
            arlSqlParameter.Add(new SqlParameter("@Bonding", smv.Bonding));
            arlSqlParameter.Add(new SqlParameter("@CuttingSMV", smv.CuttingSMV));
            arlSqlParameter.Add(new SqlParameter("@FinisingSmv", smv.FinishingSmv));
            arlSqlParameter.Add(new SqlParameter("@OtherValue", smv.OthersValue));
            arlSqlParameter.Add(new SqlParameter("@OthersDescription", smv.OthersDescription));

            arlSqlParameter.Add(new SqlParameter("@OptionValue", smv.OptionValue));
            arlSqlParameter.Add(new SqlParameter("@OptionDescription", smv.OptionDescription));
            arlSqlParameter.Add(new SqlParameter("@OptionNumber", smv.OptionNumber));
            arlSqlParameter.Add(new SqlParameter("@OptionRemarks", smv.OptionRemarks));
            arlSqlParameter.Add(new SqlParameter("@OptionAdditionalValue", smv.OptionAdditionalValue));

            //new for option 
            arlSqlParameter.Add(new SqlParameter("@OptionData", data));
            //end

            arlSqlParameter.Add(new SqlParameter("@ReviewBy", smv.ReviewBy));
            arlSqlParameter.Add(new SqlParameter("@ApprovedBy", smv.ApprovedBy));
            arlSqlParameter.Add(new SqlParameter("@Remarks", smv.Remarks));
            arlSqlParameter.Add(new SqlParameter("@PostedBy", smv.PostedBy));
            arlSqlParameter.Add(new SqlParameter("@UpdatedBy", smv.UpdatedBy));

            arlSqlParameter.Add(new SqlParameter("@productCategoryId", smv.ProductCategory));
            arlSqlParameter.Add(new SqlParameter("@machineWork", smv.MachineDescription));
            arlSqlParameter.Add(new SqlParameter("@sampleDate", smv.SampleDate));
            arlSqlParameter.Add(new SqlParameter("@seasonId", smv.Season));


            dt = this.ExecuteQuery("[Kp].[Usp_InsertCostingSmvInfo]", arlSqlParameter);


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
    public DataTable LoadCostingSmvInfo(int buyerId, string StyleNumber)
    {
        DataTable dt = null;
        try
        {
            
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@StyleNumber", StyleNumber)); 
            //arlSqlParameter.Add(new SqlParameter("@DesignNumber", DesignNumber));
            arlSqlParameter.Add(new SqlParameter("@BuyerId", buyerId));
            dt = this.ExecuteQuery("[kp].[USP_LoadCostingSmvInfo]", arlSqlParameter);

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
    public DataTable LoadNewCostingSmvInfo(int buyerId, string StyleNumber)
    {
        DataTable dt = null;
        try
        {

            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@StyleNumber", StyleNumber));
            //arlSqlParameter.Add(new SqlParameter("@DesignNumber", DesignNumber));
            arlSqlParameter.Add(new SqlParameter("@BuyerId", buyerId));
            dt = this.ExecuteQuery("[kp].[USP_LoadNewCostingSmvInfo]", arlSqlParameter);

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


    public DataTable LoadCostingInfoInfoForUpdate(int smvId)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@SmvId", smvId));
            dt = this.ExecuteQuery("[kp].[USP_lodatCostingSmvForUpdate]", arlSqlParameter);
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

    public int UpdateCostingSmv(CostingSmv smv, DataTable data)
    {
        int actionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@SmvId", smv.SmvId));
            arlSqlParameter.Add(new SqlParameter("@BuyerId", smv.BuyerId));
            arlSqlParameter.Add(new SqlParameter("@SampleStageId", smv.SampleStageId));

            arlSqlParameter.Add(new SqlParameter("@StyleNumber", smv.StyleNumber));
            arlSqlParameter.Add(new SqlParameter("@DesignNumber", smv.DesignNumber));
            arlSqlParameter.Add(new SqlParameter("@StyleDescription", smv.StyleDescription));

            arlSqlParameter.Add(new SqlParameter("@FabricId", smv.FabricId));
            arlSqlParameter.Add(new SqlParameter("@DepartmentName", smv.Department));
            arlSqlParameter.Add(new SqlParameter("@SwingSmv", smv.SewingSmv));
            arlSqlParameter.Add(new SqlParameter("@PleatingSmv", smv.PleatingSmv));

            arlSqlParameter.Add(new SqlParameter("@PermanentCrease", smv.PermanentCrease));
            arlSqlParameter.Add(new SqlParameter("@SupperCrease", smv.SupperCrease));

            arlSqlParameter.Add(new SqlParameter("@HeatSealHeatSmv", smv.HeatSeal));
            arlSqlParameter.Add(new SqlParameter("@OverlayFilmHeatSmv", smv.OverlayFilm));
            arlSqlParameter.Add(new SqlParameter("@PLKQuiltingSmv", smv.PLKQuilting));
            arlSqlParameter.Add(new SqlParameter("@AutoQuiltingSmv", smv.AutoQuilting));
            arlSqlParameter.Add(new SqlParameter("@ManualQuiltingSmv", smv.ManualQuilting));
            arlSqlParameter.Add(new SqlParameter("@ManualDownFill", smv.ManualDownFill));
            arlSqlParameter.Add(new SqlParameter("@MachineDownFill", smv.MachineDownFill));
            arlSqlParameter.Add(new SqlParameter("@SeamSeal", smv.SeamSeal));
            arlSqlParameter.Add(new SqlParameter("@Bonding", smv.Bonding));
            arlSqlParameter.Add(new SqlParameter("@CuttingSMV", smv.CuttingSMV));
            arlSqlParameter.Add(new SqlParameter("@FinisingSmv", smv.FinishingSmv));
            arlSqlParameter.Add(new SqlParameter("@OtherValue", smv.OthersValue));
            arlSqlParameter.Add(new SqlParameter("@OthersDescription", smv.OthersDescription));

            arlSqlParameter.Add(new SqlParameter("@OptionValue", smv.OptionValue));
            arlSqlParameter.Add(new SqlParameter("@OptionDescription", smv.OptionDescription));
            arlSqlParameter.Add(new SqlParameter("@OptionNumber", smv.OptionNumber));
            arlSqlParameter.Add(new SqlParameter("@OptionRemarks", smv.OptionRemarks));
            arlSqlParameter.Add(new SqlParameter("@OptionAdditionalValue", smv.OptionAdditionalValue));

            arlSqlParameter.Add(new SqlParameter("@ReviewBy", smv.ReviewBy));
            arlSqlParameter.Add(new SqlParameter("@ApprovedBy", smv.ApprovedBy));
            arlSqlParameter.Add(new SqlParameter("@Remarks", smv.Remarks));
            arlSqlParameter.Add(new SqlParameter("@UpdatedBy", smv.UpdatedBy));

            arlSqlParameter.Add(new SqlParameter("@productCategoryId", smv.ProductCategory));
            arlSqlParameter.Add(new SqlParameter("@machineWork", smv.MachineDescription));
            arlSqlParameter.Add(new SqlParameter("@sampleDate", smv.SampleDate));
            arlSqlParameter.Add(new SqlParameter("@seasonId", smv.Season));
            arlSqlParameter.Add(new SqlParameter("@OptionData", data));
            actionResult =this.ExecuteActionQuery("[Kp].[USP_UpdateCostingSmvInfo]", arlSqlParameter);
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



    //for Costing SMV report
    public DataTable LoadCostingSmvReport(int buyerId,string StyleNumber)
    {
        DataTable dt = null;
        try
        {

            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@StyleNumber", StyleNumber));
            //arlSqlParameter.Add(new SqlParameter("@DesignNumber", DesignNumber));
            arlSqlParameter.Add(new SqlParameter("@buyerId", buyerId));
            dt = this.ExecuteQuery("[kp].[USP_LoadCostingSmvReport]", arlSqlParameter);

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

    public DataTable LoadBuyerWiseOptionInfo(int buyerId, string StyleNumber)
    {
        DataTable dt = null;
        try
        {

            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@StyleNumber", StyleNumber));
            //arlSqlParameter.Add(new SqlParameter("@DesignNumber", DesignNumber));
            arlSqlParameter.Add(new SqlParameter("@buyerId", buyerId));
            dt = this.ExecuteQuery("[kp].[buyerWiseOptionInfo]", arlSqlParameter);

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




    public DataTable LoadCostingSmvDetailsReport(int buyerId, string StyleNumber)
    {
        DataTable dt = null;
        try
        {

            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@StyleNumber", StyleNumber));
            arlSqlParameter.Add(new SqlParameter("@buyerId", buyerId));
            dt = this.ExecuteQuery("[Reports].[USP_LoadCostingSmvDetailsreports]", arlSqlParameter);

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

    public List<Tuple<string>> Get_SuggestionForStyleNumber(string keyWord)
    {
        DataTable objDatatable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@keyword", keyWord));

            objDatatable = this.ExecuteQuery("[kp].[USP_StyleNumberForSearch]", arlSQLParameters);
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





    public List<Tuple<string>> Get_SuggestionForDesignNumber(string keyWord)
    {
        DataTable objDatatable = new DataTable();

        try
        {
            OpenConnection();
            ArrayList arlSQLParameters = new ArrayList();

            arlSQLParameters.Add(new SqlParameter("@keyword", keyWord));

            objDatatable = this.ExecuteQuery("[KP].[USP_DesignNumberForSearch]", arlSQLParameters);
            List<Tuple<string>> list = new List<Tuple<string>>();
            list = (from data in objDatatable.AsEnumerable() select (new Tuple<string>(data["DesignNumber"].ToString())))
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


    public DataTable LoadCombineStyleReports(int buyerId, string StyleNumber)
    {
        DataTable dt = null;
        try
        {

            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@designNo", StyleNumber));
            arlSqlParameter.Add(new SqlParameter("@buyerId", buyerId));
            dt = this.ExecuteQuery("[KP].[GetStyleCombineReports]", arlSqlParameter);

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

    public DataTable InsertNewCostingSMV(CostingSmv smv, DataTable data)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@BuyerId", smv.BuyerId));
            arlSqlParameter.Add(new SqlParameter("@SampleStageId", smv.SampleStageId));
            arlSqlParameter.Add(new SqlParameter("@StyleNumber", smv.StyleNumber));
            arlSqlParameter.Add(new SqlParameter("@DesignNumber", smv.DesignNumber));
            arlSqlParameter.Add(new SqlParameter("@StyleDescription", smv.StyleDescription));
            arlSqlParameter.Add(new SqlParameter("@FabricId", smv.FabricId));
            arlSqlParameter.Add(new SqlParameter("@DepartmentName", smv.Department));
            arlSqlParameter.Add(new SqlParameter("@SwingSmv", smv.SewingSmv));
            arlSqlParameter.Add(new SqlParameter("@PleatingSmv", smv.PleatingSmv));

            arlSqlParameter.Add(new SqlParameter("@PermanentCrease", smv.PermanentCrease));
            arlSqlParameter.Add(new SqlParameter("@SupperCrease", smv.SupperCrease));

            arlSqlParameter.Add(new SqlParameter("@HeatSealHeatSmv", smv.HeatSeal));
            arlSqlParameter.Add(new SqlParameter("@OverlayFilmHeatSmv", smv.OverlayFilm));
            arlSqlParameter.Add(new SqlParameter("@PLKQuiltingSmv", smv.PLKQuilting));
            arlSqlParameter.Add(new SqlParameter("@AutoQuiltingSmv", smv.AutoQuilting));
            arlSqlParameter.Add(new SqlParameter("@ManualQuiltingSmv", smv.ManualQuilting));
            arlSqlParameter.Add(new SqlParameter("@ManualDownFill", smv.ManualDownFill));
            arlSqlParameter.Add(new SqlParameter("@MachineDownFill", smv.MachineDownFill));
            arlSqlParameter.Add(new SqlParameter("@SeamSeal", smv.SeamSeal));
            arlSqlParameter.Add(new SqlParameter("@Bonding", smv.Bonding));
            arlSqlParameter.Add(new SqlParameter("@CuttingSMV", smv.CuttingSMV));
            arlSqlParameter.Add(new SqlParameter("@FinisingSmv", smv.FinishingSmv));
            arlSqlParameter.Add(new SqlParameter("@OtherValue", smv.OthersValue));
            arlSqlParameter.Add(new SqlParameter("@OthersDescription", smv.OthersDescription));

            arlSqlParameter.Add(new SqlParameter("@OptionValue", smv.OptionValue));
            arlSqlParameter.Add(new SqlParameter("@OptionDescription", smv.OptionDescription));
            arlSqlParameter.Add(new SqlParameter("@OptionNumber", smv.OptionNumber));
            arlSqlParameter.Add(new SqlParameter("@OptionRemarks", smv.OptionRemarks));
            arlSqlParameter.Add(new SqlParameter("@OptionAdditionalValue", smv.OptionAdditionalValue));

            //new for option 
            arlSqlParameter.Add(new SqlParameter("@OptionData", data));
            //end

            arlSqlParameter.Add(new SqlParameter("@ReviewBy", smv.ReviewBy));
            arlSqlParameter.Add(new SqlParameter("@ApprovedBy", smv.ApprovedBy));
            arlSqlParameter.Add(new SqlParameter("@Remarks", smv.Remarks));
            arlSqlParameter.Add(new SqlParameter("@PostedBy", smv.PostedBy));
            arlSqlParameter.Add(new SqlParameter("@UpdatedBy", smv.UpdatedBy));

            arlSqlParameter.Add(new SqlParameter("@productCategoryId", smv.ProductCategory));
            arlSqlParameter.Add(new SqlParameter("@machineWork", smv.MachineDescription));
            arlSqlParameter.Add(new SqlParameter("@sampleDate", smv.SampleDate));

            arlSqlParameter.Add(new SqlParameter("@seasonId", smv.Season));




            dt = this.ExecuteQuery("[KP].[Usp_InsertNewCostingSmvInfo]", arlSqlParameter);


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


    public DataTable LoadCostingOptionForUpdate(int SmvId)
    {
        DataTable dt = null;
        try
        {

            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@smvId", SmvId));
            
            dt = this.ExecuteQuery("[kp].[USP_GetDateWiseCostingOptionForUpdate]", arlSqlParameter);

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


    public DataTable GetOptionInformationForUpdate(int optionId)
    {
        DataTable dt = null;
        try
        {

            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@OptionId",optionId));

            dt = this.ExecuteQuery("[kp].[USP_LoadCostingOptionInfoForUpdate]", arlSqlParameter);

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


    public int UpdateCostingOption(UpdateOptionModel optionModel)
    {
        int actionResult = 0;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@Id",optionModel.OptionId));
            arlSqlParameter.Add(new SqlParameter("@Number", optionModel.OptionNumber));
            arlSqlParameter.Add(new SqlParameter("@Addition", optionModel.OptionAddition));
            arlSqlParameter.Add(new SqlParameter("@Reduction", optionModel.OptionReduction));
            arlSqlParameter.Add(new SqlParameter("@description", optionModel.OptionDescription));
            arlSqlParameter.Add(new SqlParameter("@Remarks", optionModel.OptionRemarks));

            actionResult = this.ExecuteActionQuery("[kp].[USP_UpdateCostionOption]", arlSqlParameter);
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


    public DataTable LoadSeason()
    {
        DataTable dt = null;
        try {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            dt = this.ExecuteQuery("[KP].[USP_LoadSeasonInfo]", arlSqlParameter);

            return dt;
        }
        catch(Exception ex) {
            throw ex;
        }
        finally {
            CloseConnection();
        }
    }

    //public DataTable LoadBuyerWiseStyleNumber(int buyerId)
    //{
    //    DataTable dt = null;
    //    try
    //    {
    //        OpenConnection();
    //        ArrayList arlSqlParam = new ArrayList();

    //        arlSqlParam.Add(new SqlParameter("@BuyerId", buyerId));
    //        dt = this.ExecuteQuery("[kp].[LoadStyleNumberBybuyerIdForCostingSmv]", arlSqlParam);
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
}

