using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BulkSmv
/// </summary>
public class BulkSmv
{
    public BulkSmv()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int BulkSmvId { get; set; }
    public int BuyerId { get; set; }
    public int SampleStageId { get; set; }
    public string StyleNumber { get; set; }
    public string StyleDescription { get; set; }
    public int FabricId { get; set; }
    public decimal SewingSmv { get; set; }
    public decimal OverlaySmv { get; set; }
    public decimal FitsSmv { get; set; }
    public decimal PlkQuilting { get; set; }
    public decimal AutoQuilting { get; set; }
    public decimal ManualQuilting { get; set; }
    public decimal MachineDownFill { get; set; }
    public decimal ManualDownFill { get; set; }
    public int ReviewBy { get; set; }
    public int ApprovedBy { get; set; }
    public int PostedBy { get; set; }
    public int UpdatedBy { get; set; }
    public int ProductCategory { get; set; }
    public string SampleDate { get; set; }
    public string WorkUpdate { get; set; }
    public string MachineWork { get; set; }
    public string Description { get; set; }

    public decimal FinishingSmv { get; set; }

    public int CostingSmvId { get; set; }

	public string SeasonId { get; set; }
    
}