using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for FabricGateway
/// </summary>
public class FabricGateway:KpGateway
{
    public int actionResult = 0;
    public FabricGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int InsertStyleInfo(Fabrics fabric)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();

            arlSqlParameter.Add(new SqlParameter("@FabricType", fabric.FabricType));
            arlSqlParameter.Add(new SqlParameter("@FabricName", fabric.FabricName));
            actionResult = this.ExecuteActionQuery("[Kp].[USP_InsertFabricTypeInfo]", arlSqlParameter);
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
    public DataTable LoadFabricsInfo()
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            dt = this.ExecuteQuery("[Kp].[USP_LoadFabricsInfo]", arlSqlParameter);
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