using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MerchantModel
/// </summary>
public class MerchantModel
{
    public int MerchantId { get; set; }
    public string MerchantName { get; set; }
    public string LoginId { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public int IsActive { get; set; }
    public int PostedBy { get; set; }
    public int UpdatedBy { get; set; }
}