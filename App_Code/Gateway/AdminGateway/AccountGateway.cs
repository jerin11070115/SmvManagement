using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for AccountGateway
/// </summary>
public class AccountGateway:KpGateway
{
    public AccountGateway()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable InsertNewAccount(UserAccount userAccount)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@UserName", userAccount.UserName));
            arlSqlParameter.Add(new SqlParameter("@UserPassword", userAccount.Password));
            arlSqlParameter.Add(new SqlParameter("@FullName", userAccount.UserFullName));
            arlSqlParameter.Add(new SqlParameter("@IsActive", userAccount.IsActive));
            arlSqlParameter.Add(new SqlParameter("@AdminType", userAccount.AdminType));
            arlSqlParameter.Add(new SqlParameter("@ZoneName", userAccount.ZoneName));
            arlSqlParameter.Add(new SqlParameter("@InsertedBy", userAccount.PostedBy));
            dt = this.ExecuteQuery("[kp].[USP_InsertNewAccount]", arlSqlParameter);

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

    public DataTable LoadUserInformation()
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            dt = this.ExecuteQuery("[kp].[USP_LoadUserAccountInformation]", arlSqlParameter);

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

    public DataTable LoadUserInfoById(int UserId)
    {
        DataTable dt = null;
        try
        {
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@UserId", UserId));
            dt = this.ExecuteQuery("[kp].[USP_LoadUserInfoById]", arlSqlParameter);
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


    public int UpdateUserAccount(UserAccount account)
    {
        int actionResult = 0;
        try
        {
           
            OpenConnection();
            ArrayList arlSqlParameter = new ArrayList();
            arlSqlParameter.Add(new SqlParameter("@UserId", account.UserId));
            arlSqlParameter.Add(new SqlParameter("@UserName", account.UserName));
            arlSqlParameter.Add(new SqlParameter("@Password", account.Password));
            arlSqlParameter.Add(new SqlParameter("@UserFullName", account.UserFullName));
            arlSqlParameter.Add(new SqlParameter("@IsActive", account.IsActive));
            arlSqlParameter.Add(new SqlParameter("@AdminType", account.AdminType));
            arlSqlParameter.Add(new SqlParameter("@ZoneName", account.ZoneName));
            arlSqlParameter.Add(new SqlParameter("@UpdatedBy", account.UpdatedBy));           
            actionResult=this.ExecuteActionQuery("[Kp].[USP_UpdateUserAccount]", arlSqlParameter);

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

}