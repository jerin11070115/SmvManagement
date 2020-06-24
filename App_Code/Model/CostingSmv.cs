using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CostingSmv
/// </summary>
public class CostingSmv
{
    public CostingSmv()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int SmvId { get; set; }
    public int BuyerId { get; set; }
    public int SampleStageId { get; set; }
    public string StyleNumber { get; set; }

    public string DesignNumber { get; set; }
    public string StyleDescription { get; set; }
    public int FabricId { get; set; }
    public string Department { get; set; }
    public int ProductCategory { get; set; }    
    public string SampleDate { get; set; }
    public decimal SewingSmv { get; set; }
    public decimal PleatingSmv { get; set; }
    public decimal HeatSeal { get; set; }
    public decimal OverlayFilm { get; set; }
    public decimal PLKQuilting { get; set; }
    public decimal AutoQuilting { get; set; }
    public decimal ManualQuilting { get; set; }
    public decimal ManualDownFill { get; set; }
    public decimal MachineDownFill { get; set; }
    public decimal SeamSeal { get; set; }
    public decimal Bonding { get; set; }
    public decimal CuttingSMV { get; set; }
    public decimal FinishingSmv { get; set; }
    public decimal OthersValue { get; set; }
    public string OthersDescription { get; set; }
    public string OptionNumber { get; set; }
    public decimal OptionValue { get; set; }
    public decimal OptionAdditionalValue { get; set; }
    public string OptionDescription { get; set; }
    public string OptionRemarks { get; set; }
    public int ReviewBy { get; set; }
    public int ApprovedBy { get; set; }
    public string Remarks { get; set; }
    public string WorksUpdate { get; set; }
    public string MachineDescription { get; set; }
    public int PostedBy { get; set; }
    public int UpdatedBy { get; set; }
    public decimal PermanentCrease { get; set; }
    public decimal SupperCrease { get; set; }
    public string Season { get; set; }

}