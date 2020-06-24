using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UpdateOptionModel
/// </summary>
public class UpdateOptionModel
{
    public int OptionId { get; set; }
    public string OptionNumber { set; get; }
    public string OptionReduction { set; get; }
    public string OptionAddition { set; get; }
    public string OptionDescription { set; get; }
    public string OptionRemarks { set; get; }
}