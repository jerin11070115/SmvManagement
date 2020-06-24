using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MerchantLoginGateway
/// </summary>
public class MerchantLoginGateway:KpGateway
{
    public DataTable MerchantLogin(MerchantLoginModel merchant)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@LoginId", merchant.LoginId));
            arlSqlParameter.Add(new SqlParameter("@PassWord", merchant.Password));

            dt = this.ExecuteQuery("[KP].[MerchantLogin]", arlSqlParameter);
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


    public DataTable ShowAllMerchant(int MerchantId)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@merchantId", MerchantId));
            dt = this.ExecuteQuery("[KP].[USP_ShowAllMerchantInfo]", arlSqlParameter);
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
}