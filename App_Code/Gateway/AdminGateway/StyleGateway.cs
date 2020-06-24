using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StyleGateway
/// </summary>
public class StyleGateway:KpGateway
{
    public int actionResult = 0;
    public StyleGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int InsertStyleInfo(Style style)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();

            arlSqlParameter.Add(new SqlParameter("@StyleNumber", style.StyleNumber));
            arlSqlParameter.Add(new SqlParameter("@StyleDescription", style.StyleDescription));
            actionResult = this.ExecuteActionQuery("[Kp].[USP_InsertStyleInfo]", arlSqlParameter);

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
    public DataTable LoadstyleInfo()
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            dt = this.ExecuteQuery("[KP].[USP_LoadStyleInfo]", arlSqlParameter);

        }
        catch(Exception ex)
        {

        }
        finally
        {

        }
        return dt;
    }
}