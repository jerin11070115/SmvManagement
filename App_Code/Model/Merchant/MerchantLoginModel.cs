using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MerchantLoginModel
/// </summary>
public class MerchantLoginModel
{
    public int MerchantId { get; set; }
    public string MerchantName { get; set; }
    public string LoginId { get; set; }
    public string Password { get; set; }
    public int isActive { get; set; }

}