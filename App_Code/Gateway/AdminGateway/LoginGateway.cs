using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LoginGateway
/// </summary>
public class LoginGateway:KpGateway
{
    public LoginGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable Login(LoginClass log)
    {
        DataTable dt = null;
        
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@UserName", log.UserName));
            arlSqlParameter.Add(new SqlParameter("@UserPassword", log.UserPassword));
            dt=this.ExecuteQuery("[dbo].[USP_UserLogin]", arlSqlParameter);
        
        
            CloseConnection();
        
        return dt;
    }


    public DataTable Show_AllUsers(int UserId)
    {

        try
        {
            OpenConnection();
            ArrayList objArray = new ArrayList();
            objArray.Add(new SqlParameter("@UserId", UserId));
            DataTable objData = this.ExecuteQuery("[KP].[USP_User_ShowData]", objArray);
            return objData;
        }
        catch (Exception ex)
        {
            throw new Exception("Gateway Error:", ex);
        }
        finally
        {
            CloseConnection();
        }
    }
}