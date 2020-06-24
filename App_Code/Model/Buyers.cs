using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Buyers
/// </summary>
public class Buyers
{
    public Buyers()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int BuyerId {get;set;}
    public string BuyerName { get; set; }
    public string Country { get; set; }
    public int IsActive { get; set; }
    public int PostedBy { get; set; }
    public int UpdatedBy { get; set; } 
}