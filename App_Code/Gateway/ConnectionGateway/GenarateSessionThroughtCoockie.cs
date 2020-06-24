using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for GenarateSessionThroughtCoockie
/// </summary>
public class GenarateSessionThroughtCoockie:KpGateway
{
    public GenarateSessionThroughtCoockie()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool SessionCheck(int sessionType)
    {

        bool isSessionExist = false;

        if (sessionType == 1)
        {
            isSessionExist = GenerateSessionForAdmin();
            return isSessionExist;
        }
        else if(sessionType==2)
        {
            isSessionExist = GenerateSessionForMerchant();
            return isSessionExist;
        }

        else
        {
            return isSessionExist;
        }

    }
    private bool GenerateSessionForAdmin()
    {
        string userCookies = "";
        string userSession = "";

        if (HttpContext.Current.Request.Cookies["CK_KP_User_Id"] != null)
        {
            userCookies = (string)HttpContext.Current.Request.Cookies["CK_KP_User_Id"].Value;
        }

        if (HttpContext.Current.Session["KP_User_Id"] != null)
        {
            userSession = HttpContext.Current.Session["KP_User_Id"].ToString();
        }

        if (userSession == null || userSession == "")
        {
            if (userCookies != null && userCookies != "")
            {
                using (LoginGateway objAdmin = new LoginGateway())
                {
                    DataTable dtAdmin = objAdmin.Show_AllUsers(Convert.ToInt32(userCookies));
                    if (dtAdmin.Rows.Count > 0)
                    {
                        HttpContext.Current.Session["KP_User_Id"] = dtAdmin.Rows[0]["UserId"].ToString();
                        HttpContext.Current.Session["KP_Name"] = dtAdmin.Rows[0]["FullName"].ToString();
                        HttpContext.Current.Session["KP_UserName"] = dtAdmin.Rows[0]["UserName"].ToString();
                        

                        HttpContext.Current.Response.Cookies["CK_KP_User_Id"].Expires = DateTime.Now.AddDays(7);

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }

    private bool GenerateSessionForMerchant()
    {
        string merchantCookies = "";
        string merchantSession = "";
        if (HttpContext.Current.Request.Cookies["CK_KP_Merchant_Id"] != null)
        {
            merchantCookies = (string)HttpContext.Current.Request.Cookies["CK_KP_Merchant_Id"].Value;
        }

        if (HttpContext.Current.Session["KP_Merchant_Id"] != null)
        {
            merchantSession = HttpContext.Current.Session["KP_Merchant_Id"].ToString();
        }

        if (merchantSession == null || merchantSession == "")
        {
            if (merchantCookies != null && merchantCookies != "")
            {
                using (MerchantLoginGateway merchantloginGateway = new MerchantLoginGateway())
                {
                    DataTable dt = merchantloginGateway.ShowAllMerchant(Convert.ToInt32(merchantCookies));

                    if (dt.Rows.Count > 0)
                    {
                        HttpContext.Current.Session["KP_Merchant_Id"] = dt.Rows[0]["MerchantId"].ToString();
                        HttpContext.Current.Session["KP_MerchantName"] = dt.Rows[0]["MerchantName"].ToString();
                        HttpContext.Current.Session["KP_Merchant_LoginId"] = dt.Rows[0]["LogInId"].ToString();


                        HttpContext.Current.Response.Cookies["CK_KP_Merchant_Id"].Expires = DateTime.Now.AddDays(3);

                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return true;
        }
    }
}