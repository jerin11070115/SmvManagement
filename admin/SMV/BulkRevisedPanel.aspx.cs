using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_SMV_BulkRevisedPanel : System.Web.UI.Page
{
    public string url = "http://web.kenpark-bangladesh.com/SMV/admin/SMV/BulkRevisedPanel.aspx";
    public string userId = "0";
    public string userName = "";

    public string table = "";
    public int actionResult = 0;
    public int bulkSmvId = 0;
    public int RevisedBulkSmvId = 0;
    public string bulkSmvTable = null;
    public int buyerId = 0;
    public string styleNumber = "";
    //public string zone = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GenarateSessionThroughtCoockie checkSession = new GenarateSessionThroughtCoockie();

        bool hasSession = checkSession.SessionCheck(1);

        if (hasSession)
        {
            userId = Session["KP_User_Id"].ToString();
            userName = Session["KP_UserName"].ToString();
            //zone = Session["KP_Zone"].ToString();
        }
        else

        {
            Response.Redirect("~/admin/Default.aspx");
            Response.End();
        }

        bulkSmvId = Convert.ToInt32(Request.QueryString["Id"]);

        RevisedBulkSmvId = Convert.ToInt32(Request.QueryString["Up"]);

        if (!IsPostBack)
        {
            LoadBuyerName();
            LoadFabricType();
            LoadUser();
			//LoadSeason();

			LoadProductCategory();
            mainBody.Visible = false;
            //table = LoadRevisedBulkSmvinformation(buyerId,styleNumber);
            if (bulkSmvId != 0)
            {
                LoadBuklSmvForUpdate(bulkSmvId);
                mainBody.Visible = true;
                buyerNameDropDownList.Enabled = false;
                sampleStageDropDownList.Enabled = false;
                //fabricDropDownList.Enabled = false;
                //styleDescriptionTextBox.Enabled = false;
                styleNumberTextBox.Enabled = false;
                ProductDropDownList.Enabled = false;
                submitButton.Visible = false;


            }
            if (RevisedBulkSmvId != 0)
            {
                LoadBuklSmvForRevised(RevisedBulkSmvId);
                mainBody.Visible = true;
                buyerNameDropDownList.Enabled = false;
                //sampleStageDropDownList.Enabled = false;
                //fabricDropDownList.Enabled = false;
                //styleDescriptionTextBox.Enabled = false;
                styleNumberTextBox.Enabled = false;
                //ProductDropDownList.Enabled = false;
                updateButton.Visible = false;


            }

            else
            {
               // submitButton.Text = "Revised";

            }
        }

    }


    public DataTable LoadUser()
    {
        DataTable dt = null;
        try
        {
            SmvEntryGateway smvGateway = new SmvEntryGateway();
            dt = smvGateway.LoadUserName();

            if (dt.Rows.Count > 0)
            {
                approvedDropDownList.DataSource = dt;
                approvedDropDownList.DataValueField = "UserId";
                approvedDropDownList.DataTextField = "FullName";
                approvedDropDownList.DataBind();
                approvedDropDownList.Items.Insert(0, new ListItem("Please Select", "0"));

                reviewDropDownList.DataSource = dt;
                reviewDropDownList.DataValueField = "UserId";
                reviewDropDownList.DataTextField = "FullName";
                reviewDropDownList.DataBind();
                reviewDropDownList.Items.Insert(0, new ListItem("Please Select", "0"));
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable LoadProductCategory()
    {
        DataTable dt = null;
        try
        {
            SmvBLL smvBLL = new SmvBLL();
            dt = smvBLL.LoadProductCategory();
            if (dt.Rows.Count > 0)
            {
                ProductDropDownList.DataSource = dt;
                ProductDropDownList.DataValueField = "ProductId";
                ProductDropDownList.DataTextField = "ProductName";
                ProductDropDownList.DataBind();
                ProductDropDownList.Items.Insert(0, new ListItem("Please Select", "0"));
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }



    public DataTable LoadBuyerName()
    {
        DataTable dt = null;
        try
        {
            SampleStageBLL sampleBLL = new SampleStageBLL();
            dt = sampleBLL.LoadBuyerName();
            if (dt.Rows.Count > 0)
            {
                buyerNameDropDownList.DataSource = dt;
                buyerNameDropDownList.DataValueField = "BuyerId";
                buyerNameDropDownList.DataTextField = "BuyerName";
                buyerNameDropDownList.DataBind();
                buyerNameDropDownList.Items.Insert(0, new ListItem("Please Select", "0"));


                searchDropDownList.DataSource = dt;
                searchDropDownList.DataValueField = "BuyerId";
                searchDropDownList.DataTextField = "BuyerName";
                searchDropDownList.DataBind();
                searchDropDownList.Items.Insert(0, new ListItem("Search With Buyer", "0"));




            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }

    //Load Buyer wise Samplestage

    [WebMethod]
    public static SampleStage[] LoadSampleStage(int buyerId)
    {
        DataTable dt = new DataTable();
        List<SampleStage> sampleStage = new List<SampleStage>();
        try
        {


            using (SmvEntryGateway smvGateway = new SmvEntryGateway())
            {

                dt = smvGateway.LoadBuyerWiseSampleStage(buyerId);

                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow dtr in dt.Rows)
                    {
                        SampleStage sample = new SampleStage();
                        sample.SampleStageId = Convert.ToInt32(dtr["SampleStageId"].ToString());
                        sample.SampleStageName = dtr["SampleStageName"].ToString();
                        sampleStage.Add(sample);
                    }
                }

            }
        }
        catch (Exception Ex)
        {

        }
        return sampleStage.ToArray();
    }

    //Load Fabric

    public DataTable LoadFabricType()
    {
        DataTable dt = null;
        try
        {
            SmvBLL smvBLL = new SmvBLL();
            dt = smvBLL.LoadFabricType();

            if (dt.Rows.Count > 0)
            {
                fabricDropDownList.DataSource = dt;
                fabricDropDownList.DataValueField = "FabricId";
                fabricDropDownList.DataTextField = "FabricType";
                fabricDropDownList.DataBind();
                fabricDropDownList.Items.Insert(0, new ListItem("Please Select", "0"));

            }

        }
        catch (Exception ex)
        {

        }
        return dt;
    }
    public DataTable loadSampleStageForUpdate(int loadBuyerId)
    {
        DataTable dt = new DataTable();
        try
        {
            using (SmvEntryGateway smvGateway = new SmvEntryGateway())
            {
                dt = smvGateway.LoadBuyerWiseSampleStage(loadBuyerId);

                if (dt.Rows.Count > 0)
                {
                    sampleStageDropDownList.DataSource = dt;
                    sampleStageDropDownList.DataValueField = "SampleStageId";
                    sampleStageDropDownList.DataTextField = "SampleStageName";
                    sampleStageDropDownList.DataBind();
                    sampleStageDropDownList.Items.Insert(0, new ListItem("Please Select", "0"));
                }


            }
        }
        catch (Exception ex)
        {

        }

        return dt;
    }
    public string LoadRevisedBulkSmvinformation(int buyerId, string styleNumber)
    {
        BulkSmvBLL smvBll = new BulkSmvBLL();

        try
        {
            bulkSmvTable = smvBll.LoadRevisedBulkSmvInfo(buyerId, styleNumber);
        }
        catch (Exception ex)
        {

        }
        return bulkSmvTable;
    }
    [WebMethod]
    public static List<Tuple<string>> Load_SuggestionForStyleNumber(string keyword)
    {
        List<Tuple<string>> DataList = new List<Tuple<string>>();
        BulkSmvGateway bulkEntryGateway = new BulkSmvGateway();
        DataList = bulkEntryGateway.Get_SuggestionForStyleNumberforBulk(keyword);

        return DataList;
    }
    public void LoadBuklSmvForUpdate(int BulkId)
    {
        int buyerIdForLoad = 0;
        try
        {
            BulkSmvBLL bulkSmvBLL = new BulkSmvBLL();

            DataTable dt = bulkSmvBLL.LoadCostingInfoInfoForUpdate(BulkId);

            if (dt.Rows.Count > 0)
            {
                buyerNameDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["BuyerId"]);
                buyerIdForLoad = Convert.ToInt32(dt.Rows[0]["BuyerId"]);
                string value = Convert.ToString(dt.Rows[0]["SampleStageId"]);
                sampleStageHiddenField.Value = value;

                loadSampleStageForUpdate(buyerIdForLoad);

                sampleStageDropDownList.SelectedValue = sampleStageHiddenField.Value;
                fabricDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["FabricId"]);
                //styleDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["StyleId"]);
				//SeasonDropDownList.SelectedValue= Convert.ToString(dt.Rows[0]["SeasonId"]);
                seasonTextBox.Text = Convert.ToString(dt.Rows[0]["SeasonId"]);
                styleNumberTextBox.Text = Convert.ToString(dt.Rows[0]["StyleNumber"]);
                styleDescriptionTextBox.Text = Convert.ToString(dt.Rows[0]["StyleDescription"]);


                sewingTextBox.Text = Convert.ToString(dt.Rows[0]["SewingSmv"]);
                overlayTextBox.Text = Convert.ToString(dt.Rows[0]["OverlaySmv"]);
                fitsTextBox.Text = Convert.ToString(dt.Rows[0]["FitsSmv"]);

                plkTextBox.Text = Convert.ToString(dt.Rows[0]["PlkQuelting"]);
                autoTextBox.Text = Convert.ToString(dt.Rows[0]["AutoQuelting"]);
                quiltingManualTextBox.Text = Convert.ToString(dt.Rows[0]["ManualQuelting"]);

                downManualTextBox.Text = Convert.ToString(dt.Rows[0]["ManualDownfill"]);
                downMachineTextBox.Text = Convert.ToString(dt.Rows[0]["MachineDownfill"]);
                finishingTextBox.Text = Convert.ToString(dt.Rows[0]["FinishingSmv"]);


                approvedDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["ApprovedBy"]);
                reviewDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["ReviewBy"]);

                ProductDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["ProductCategory"]);

                DateTime date = Convert.ToDateTime(dt.Rows[0]["SampleDate"]);


                if (date.ToString("yyyy-MM-dd") == "1900-01-01")
                {
                    sampleDateTextBox.Text = "";
                }
                else
                {
                    sampleDateTextBox.Text = date.ToString("yyyy-MM-dd");
                }

                //sampleDateTextBox.Text= Convert.ToString(dt.Rows[0]["SampleDate"]);
                //remarksTextArea.InnerText= Convert.ToString(dt.Rows[0]["WorkUpdate"]);
                machineDetailsTextarea.InnerText = Convert.ToString(dt.Rows[0]["MachineWork"]);
                descriptionTextarea.InnerText = Convert.ToString(dt.Rows[0]["Description"]);

                //submitButton.Text = "Update";

                //buyerNameDropDownList.Enabled = false;
                //sampleStageDropDownList.Enabled = false;
                //styleDropDownList.Enabled = false;
                //fabricDropDownList.Enabled = false;
            }
        }
        catch (Exception ex)
        {

        }
    }



    public void LoadBuklSmvForRevised(int BulkId)
    {
        int buyerIdForLoad = 0;
        try
        {
            BulkSmvBLL bulkSmvBLL = new BulkSmvBLL();

            DataTable dt = bulkSmvBLL.LoadCostingInfoInfoForUpdate(BulkId);

            if (dt.Rows.Count > 0)
            {
                buyerNameDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["BuyerId"]);
                buyerIdForLoad = Convert.ToInt32(dt.Rows[0]["BuyerId"]);
                string value = Convert.ToString(dt.Rows[0]["SampleStageId"]);
                sampleStageHiddenField.Value = value;

                loadSampleStageForUpdate(buyerIdForLoad);

                sampleStageDropDownList.SelectedValue = sampleStageHiddenField.Value;
                fabricDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["FabricId"]);
                //styleDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["StyleId"]);


                styleNumberTextBox.Text = Convert.ToString(dt.Rows[0]["StyleNumber"]);
                styleDescriptionTextBox.Text = Convert.ToString(dt.Rows[0]["StyleDescription"]);

                ProductDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["ProductCategory"]);
                //SeasonDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["SeasonId"]);
                seasonTextBox.Text = Convert.ToString(dt.Rows[0]["SeasonId"]);
                //sewingTextBox.Text = Convert.ToString(dt.Rows[0]["SewingSmv"]);
                //overlayTextBox.Text = Convert.ToString(dt.Rows[0]["OverlaySmv"]);
                //fitsTextBox.Text = Convert.ToString(dt.Rows[0]["FitsSmv"]);

                //plkTextBox.Text = Convert.ToString(dt.Rows[0]["PlkQuelting"]);
                //autoTextBox.Text = Convert.ToString(dt.Rows[0]["AutoQuelting"]);
                //quiltingManualTextBox.Text = Convert.ToString(dt.Rows[0]["ManualQuelting"]);

                //downManualTextBox.Text = Convert.ToString(dt.Rows[0]["ManualDownfill"]);
                //downMachineTextBox.Text = Convert.ToString(dt.Rows[0]["MachineDownfill"]);
                //finishingTextBox.Text = Convert.ToString(dt.Rows[0]["FinishingSmv"]);


                //approvedDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["ApprovedBy"]);
                //reviewDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["ReviewBy"]);

                //ProductDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["ProductCategory"]);

                //DateTime date = Convert.ToDateTime(dt.Rows[0]["SampleDate"]);


                //if (date.ToString("yyyy-MM-dd") == "1900-01-01")
                //{
                //    sampleDateTextBox.Text = "";
                //}
                //else
                //{
                //    sampleDateTextBox.Text = date.ToString("yyyy-MM-dd");
                //}

                ////sampleDateTextBox.Text= Convert.ToString(dt.Rows[0]["SampleDate"]);
                ////remarksTextArea.InnerText= Convert.ToString(dt.Rows[0]["WorkUpdate"]);
                //machineDetailsTextarea.InnerText = Convert.ToString(dt.Rows[0]["MachineWork"]);
                //descriptionTextarea.InnerText = Convert.ToString(dt.Rows[0]["Description"]);

                // submitButton.Text = "Correction";

                //buyerNameDropDownList.Enabled = false;
                //sampleStageDropDownList.Enabled = false;
                //styleDropDownList.Enabled = false;
                //fabricDropDownList.Enabled = false;
            }
		}
        catch (Exception ex)
        {

        }
    }






    public void ClearAllData()
    {
        buyerNameDropDownList.SelectedValue = "0";

        sampleStageDropDownList.SelectedValue = "0";
        fabricDropDownList.SelectedValue = "0";
        //SeasonDropDownList.SelectedValue = "0";
        seasonTextBox.Text = "";
		styleDescriptionTextBox.Text = "";
        styleNumberTextBox.Text = "";

        sewingTextBox.Text = "";
        overlayTextBox.Text = "";
        fitsTextBox.Text = "";

        plkTextBox.Text = "";
        autoTextBox.Text = "";
        quiltingManualTextBox.Text = "";

        downManualTextBox.Text = "";
        downMachineTextBox.Text = "";

        finishingTextBox.Text = "";

        approvedDropDownList.SelectedValue = "0";
        reviewDropDownList.SelectedValue = "0";

        ProductDropDownList.SelectedValue = "0";
        sampleDateTextBox.Text = "";
        //remarksTextArea.InnerText = "";
        machineDetailsTextarea.InnerText = "";
        descriptionTextarea.InnerText = "";
        //submitButton.Text = "Revised";

        buyerNameDropDownList.Enabled = true;
        sampleStageDropDownList.Enabled = true;
        //fabricDropDownList.Enabled = true;
        //styleDescriptionTextBox.Enabled = true;
        styleNumberTextBox.Enabled = true;
        ProductDropDownList.Enabled = true;
    }

    protected void reloadButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("BulkRevisedPanel.aspx");
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {
        styleNumber = searchTextBox.Text;
        buyerId = Convert.ToInt32(searchDropDownList.SelectedValue);
        table = LoadRevisedBulkSmvinformation(buyerId, styleNumber);
    }


    

    protected void submitButton_Click(object sender, EventArgs e)
    {
        

        DataTable dt = new DataTable();

        try
        {
            int value = 0;
            BulkSmv bulk = new BulkSmv();
            BulkSmvBLL bulkSmvBLL = new BulkSmvBLL();
            MailClass mailClass = new MailClass();

            bulk.BuyerId = Convert.ToInt32(buyerNameDropDownList.SelectedValue);

            value = Convert.ToInt32(sampleStageHiddenField.Value);
            bulk.SampleStageId = value;

            bulk.FabricId = Convert.ToInt32(fabricDropDownList.SelectedValue);
            //bulk.StyleId= Convert.ToInt32(styleDropDownList.SelectedValue);
            bulk.StyleNumber = styleNumberTextBox.Text.Trim();
            bulk.StyleDescription = styleDescriptionTextBox.Text;
            bulk.ProductCategory = Convert.ToInt32(ProductDropDownList.SelectedValue);
            //bulk.WorkUpdate = remarksTextArea.InnerText;
            //bulk.SampleDate = sampleDateTextBox.Text;
            //bulk.SeasonId= SeasonDropDownList.SelectedValue;
            bulk.SeasonId = seasonTextBox.Text.Trim();


            if (sampleDateTextBox.Text == "1900-01-01")
            {
                bulk.SampleDate = Convert.ToString("");
            }
            else
            {
                bulk.SampleDate = Convert.ToString(sampleDateTextBox.Text);
            }

            bulk.MachineWork = machineDetailsTextarea.InnerText;
            bulk.Description = descriptionTextarea.InnerText;

            if (sewingTextBox.Text == "" || sewingTextBox.Text == null)
            {
                bulk.SewingSmv = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.SewingSmv = Convert.ToDecimal(sewingTextBox.Text);
            }

            if (fitsTextBox.Text == "" || fitsTextBox.Text == null)
            {
                bulk.FitsSmv = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.FitsSmv = Convert.ToDecimal(fitsTextBox.Text);
            }

            if (overlayTextBox.Text == "" || overlayTextBox == null)
            {
                bulk.OverlaySmv = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.OverlaySmv = Convert.ToDecimal(overlayTextBox.Text);
            }


            if (plkTextBox.Text == "" || plkTextBox.Text == null)
            {
                bulk.PlkQuilting = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.PlkQuilting = Convert.ToDecimal(plkTextBox.Text);
            }

            if (autoTextBox.Text == "" || autoTextBox.Text == null)
            {
                bulk.AutoQuilting = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.AutoQuilting = Convert.ToDecimal(autoTextBox.Text);
            }
            if (quiltingManualTextBox.Text == "" || quiltingManualTextBox.Text == null)
            {
                bulk.ManualQuilting = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.ManualQuilting = Convert.ToDecimal(quiltingManualTextBox.Text);
            }

            if (downManualTextBox.Text == "" || downManualTextBox.Text == null)
            {
                bulk.ManualDownFill = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.ManualDownFill = Convert.ToDecimal(downManualTextBox.Text);
            }

            if (downMachineTextBox.Text == "" || downMachineTextBox.Text == null)
            {
                bulk.MachineDownFill = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.MachineDownFill = Convert.ToDecimal(downMachineTextBox.Text);
            }

            if (finishingTextBox.Text == "" || finishingTextBox.Text == null)
            {
                bulk.FinishingSmv = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.FinishingSmv = Convert.ToDecimal(finishingTextBox.Text);
            }


            bulk.ReviewBy = Convert.ToInt32(reviewDropDownList.SelectedValue);
            bulk.ApprovedBy = Convert.ToInt32(approvedDropDownList.SelectedValue);

            if (bulkSmvId == 0)
            {
                bulk.PostedBy = Convert.ToInt32(userId);
                bulk.UpdatedBy = 0;
				bulk.CostingSmvId = RevisedBulkSmvId;
                dt = bulkSmvBLL.InsertBulkRevisedSmvInfo(bulk);

                if (dt.Rows.Count > 0)
                {
                    if (bulk.ApprovedBy == 0)
                    {
                        mailClass.SendMailForApprovedByNotSetOfBulk(bulk);
                    }
                    int buyerName = Convert.ToInt32(dt.Rows[0]["dBuyer"]);
					decimal SavingPercentage = Convert.ToDecimal(dt.Rows[0]["SavingPercentage"]);
					if (buyerName == 1)
					{
						messageLabel.Text = "<p Style ='font-size:20px;color:Red; margin-top:20px;'>Already Exists</p>";
					}
					else if (buyerName == 0)
					{
						messageLabel.Text = "<p Style ='font-size:20px;color:Green; margin-top:20px;'>New Information Successfully Inserted</p> </br>";
						if (SavingPercentage > 3)
						{
							messageLabel.Text += "<p Style ='font-size:20px;color:Green; margin-top:20px;'>Saving percentage " + SavingPercentage + "% > 3%  </p>";
						}
						else if (SavingPercentage < 3)
						{
							messageLabel.Text += "<p Style ='font-size:20px;color:red; margin-top:20px;'>Saving percentage " + SavingPercentage + "% < 3%  </p>";
						}
						ClearAllData();
                        Page.Response.Redirect(url.ToString(), true);
                    }
					else
					{
						if (SavingPercentage < 0)
						{
							messageLabel.Text += "</br><p Style ='font-size:20px;color:red; margin-top:20px;'>Saving percentage is = " + SavingPercentage + "% </p>";
						}
						else if (SavingPercentage == 3)
						{
							messageLabel.Text += "</br><p Style ='font-size:20px;color:red; margin-top:20px;'>Saving percentage is = " + SavingPercentage + "% </p>";
                            //Page.Response.Redirect(url.ToString(), true);
                        }
                        
                    }
				}
                

            }            


        }
        catch (Exception ex)
        {

        }
        table = LoadRevisedBulkSmvinformation(buyerId, styleNumber);
        mainBody.Visible = false;
    }

    protected void updateButton_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();

        try
        {
            int value = 0;
            BulkSmv bulk = new BulkSmv();
            BulkSmvBLL bulkSmvBLL = new BulkSmvBLL();
            MailClass mailClass = new MailClass();

            bulk.BuyerId = Convert.ToInt32(buyerNameDropDownList.SelectedValue);

            value = Convert.ToInt32(sampleStageHiddenField.Value);
            bulk.SampleStageId = value;

            bulk.FabricId = Convert.ToInt32(fabricDropDownList.SelectedValue);
            //bulk.StyleId= Convert.ToInt32(styleDropDownList.SelectedValue);
            bulk.StyleNumber = styleNumberTextBox.Text.Trim();
            bulk.StyleDescription = styleDescriptionTextBox.Text;
            bulk.ProductCategory = Convert.ToInt32(ProductDropDownList.SelectedValue);
            //bulk.WorkUpdate = remarksTextArea.InnerText;
            //bulk.SampleDate = sampleDateTextBox.Text;
            //bulk.SeasonId= SeasonDropDownList.SelectedValue;
            bulk.SeasonId = seasonTextBox.Text.Trim();


            if (sampleDateTextBox.Text == "1900-01-01")
            {
                bulk.SampleDate = Convert.ToString("");
            }
            else
            {
                bulk.SampleDate = Convert.ToString(sampleDateTextBox.Text);
            }

            bulk.MachineWork = machineDetailsTextarea.InnerText;
            bulk.Description = descriptionTextarea.InnerText;

            if (sewingTextBox.Text == "" || sewingTextBox.Text == null)
            {
                bulk.SewingSmv = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.SewingSmv = Convert.ToDecimal(sewingTextBox.Text);
            }

            if (fitsTextBox.Text == "" || fitsTextBox.Text == null)
            {
                bulk.FitsSmv = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.FitsSmv = Convert.ToDecimal(fitsTextBox.Text);
            }

            if (overlayTextBox.Text == "" || overlayTextBox == null)
            {
                bulk.OverlaySmv = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.OverlaySmv = Convert.ToDecimal(overlayTextBox.Text);
            }


            if (plkTextBox.Text == "" || plkTextBox.Text == null)
            {
                bulk.PlkQuilting = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.PlkQuilting = Convert.ToDecimal(plkTextBox.Text);
            }

            if (autoTextBox.Text == "" || autoTextBox.Text == null)
            {
                bulk.AutoQuilting = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.AutoQuilting = Convert.ToDecimal(autoTextBox.Text);
            }
            if (quiltingManualTextBox.Text == "" || quiltingManualTextBox.Text == null)
            {
                bulk.ManualQuilting = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.ManualQuilting = Convert.ToDecimal(quiltingManualTextBox.Text);
            }

            if (downManualTextBox.Text == "" || downManualTextBox.Text == null)
            {
                bulk.ManualDownFill = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.ManualDownFill = Convert.ToDecimal(downManualTextBox.Text);
            }

            if (downMachineTextBox.Text == "" || downMachineTextBox.Text == null)
            {
                bulk.MachineDownFill = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.MachineDownFill = Convert.ToDecimal(downMachineTextBox.Text);
            }

            if (finishingTextBox.Text == "" || finishingTextBox.Text == null)
            {
                bulk.FinishingSmv = Convert.ToDecimal("0.00");
            }
            else
            {
                bulk.FinishingSmv = Convert.ToDecimal(finishingTextBox.Text);
            }


            bulk.ReviewBy = Convert.ToInt32(reviewDropDownList.SelectedValue);
            bulk.ApprovedBy = Convert.ToInt32(approvedDropDownList.SelectedValue);

            
            if(bulkSmvId !=0)
            {
                bulk.BulkSmvId = bulkSmvId;
                bulk.UpdatedBy = Convert.ToInt32(userId);
                actionResult = bulkSmvBLL.UpdateBulkSmv(bulk);


                if (actionResult >= 1)
                {
                    if (bulk.ApprovedBy == 0)
                    {
                        mailClass.SendMailForApprovedByNotSetOfBulk(bulk);
                    }
                    messageLabel.Text = "<p Style ='font-size:20px;color:Green; margin-top:20px;'> Information Successfully Updated</p>";
                    ClearAllData();
                    Page.Response.Redirect(url.ToString(), true);
                }
                else
                {
                    messageLabel.Text = "<p Style ='font-size:20px;color:Red; margin-top:20px;'>Already Exists...</p>";
                }
            }


        }
        catch (Exception ex)
        {

        }
        table = LoadRevisedBulkSmvinformation(buyerId, styleNumber);
        mainBody.Visible = false;

    }

    protected void exlButton_Click(object sender, EventArgs e)
    {
        DataTable dt = null;

        StringBuilder tableRow = new StringBuilder();
        styleNumber = Convert.ToString(searchTextBox.Text);
        buyerId = Convert.ToInt32(searchDropDownList.SelectedValue);
        LoadRevisedBulkSmvinformation(buyerId, styleNumber);
        tableRow.Append("<table class='table table-bordered' id='tableLoad'>" + LoadRevisedBulkSmvinformation(buyerId, styleNumber) + "</table>");

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=Revised_Bulk_Smv.xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        Response.Output.Write(tableRow.ToString());
        Response.Flush();
        Response.End();
    }

    [WebMethod]
    public static void LoadJsonData(string dataValue)
    {
        HttpContext.Current.Session["ListOfOption"] = "";
        HttpContext.Current.Session["ListOfOption"] = dataValue;
    }

	//public void LoadSeason()
	//{
	//	DataTable dt = null;
	//	try
	//	{
	//		SmvBLL smvBLL = new SmvBLL();
	//		dt = smvBLL.LoadSeason();

	//		if (dt.Rows.Count > 0)
	//		{
	//			SeasonDropDownList.DataSource = dt;
	//			SeasonDropDownList.DataValueField = "SeasonId";
	//			SeasonDropDownList.DataTextField = "Season";
	//			SeasonDropDownList.DataBind();
	//			SeasonDropDownList.Items.Insert(0, new ListItem("Please Select", "0"));

	//		}

	//	}
	//	catch (Exception ex)
	//	{

	//	}

	//}
}