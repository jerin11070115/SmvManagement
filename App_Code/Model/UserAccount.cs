using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserAccount
/// </summary>
public class UserAccount
{
    public UserAccount()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string UserFullName{ get; set; }
    public int IsActive { get; set; }

    public int AdminType { get; set; }
    public string ZoneName { get; set; }

    public int PostedBy { get; set; }
    public int UpdatedBy { get; set; }
}