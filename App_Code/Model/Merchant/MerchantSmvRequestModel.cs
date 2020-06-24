/// <summary>
/// Summary description for MerchantSmvRequestModel
/// </summary>
public class MerchantSmvRequestModel
{
    public int MerchantId { get; set; }
    public int SmvRequestId { get; set; }
    public int BuyerId { get; set; }
    public int SampleStageId { get; set; }
    public string StyleNumber { get; set; }
    public int FabricId { get; set; }
    public int ProductCategoryId { get; set; }
    public int ApproxOrderQtn { get; set; }
    public string CostingDeadLine { get; set; }
    public string Comments { get; set; }
    public int SendToUserId { get; set; }
    public int PostedBy { get; set; }
    public string PostedOn { get; set; }
    public int UpdatedBy { get; set; }
    public string UpdatedOn { get; set; }
    public float CostingSmvValue { get; set; }
    public int IsActive { get; set; }
    public int PreviousSampleStage { get; set; }
    public string DesignNumber{ get; set; }
    public string ReasonToRevised { get; set; }
    public string ReceivedDate { get; set; }
    public int IsOption { get; set; }

}