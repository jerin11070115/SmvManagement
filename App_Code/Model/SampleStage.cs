using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SampleStage
/// </summary>
public class SampleStage
{
    public SampleStage()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int SampleStageId { get; set; }
    public string SampleStageName { get; set; }
    public int BuyerId { get; set; }
    public int IsActive { get; set; }

    public int PostedBy { get; set; }
    public int UpdatedBy { get; set; }
    
}