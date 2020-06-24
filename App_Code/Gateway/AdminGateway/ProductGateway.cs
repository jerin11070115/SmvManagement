using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ProductGateway
/// </summary>
public class ProductGateway:KpGateway
{
    public int actionResult = 0;
    public ProductGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int InsertProductInfo(Products product)
    {
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();

           // arlSqlParameter.Add(new SqlParameter("@ProductType", product.ProductType));
            arlSqlParameter.Add(new SqlParameter("@ProductName", product.ProductName));
            actionResult = this.ExecuteActionQuery("[Kp].[USP_InsertProductInfo]", arlSqlParameter);
        }
        catch(Exception ex)
        {

        }
        finally
        {

        }
        return actionResult;
    }



    public DataTable LoadProductsInfo()
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            dt = this.ExecuteQuery("[kp].[USP_LoadProductInfo]", arlSqlParameter);
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