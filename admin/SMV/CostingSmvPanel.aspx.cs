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
using Newtonsoft.Json;

public partial class admin_SMV_CostingSmvPanel : System.Web.UI.Page
{
    public string url = "http://web.kenpark-bangladesh.com/SMV/admin/SMV/CostingSmvPanel.aspx";
    public string table = "";
    public int actionResult = 0;
    public int SmvId = 0;
    public string userId = "0";
    public string userName = "";
    public string smvtable = null;
    public int buyerId = 0;
    public string styleNumber = "";
    //public string designNumber = "";
    public int RequestId = 0;
    //public string zone = ""; 
    protected void Page_Load(object sender, EventArgs e)
    {
        GenarateSessionThroughtCoockie checkSession = new GenarateSessionThroughtCoockie();

        bool hasSession = checkSession.SessionCheck(1);

        if (hasSession)
        {
            userId = Session["KP_User_Id"].ToString();
            userName = Session["KP_UserName"].ToString();
            //zone= Session["KP_Zone"].ToString();
        }
        else

        {

            Response.Redirect("../Default.aspx");
            Response.End();
        }


        SmvId = Convert.ToInt32(Request.QueryString["Id"]);
        RequestId= Convert.ToInt32(Request.QueryString["RequestId"]);
        if (!IsPostBack)
        {
            LoadBuyerName();
            LoadFabricType();
            LoadUser();
            LoadProductCategory();
            //table = loadCostingSmvinformation(buyerId,styleNumber);
            //LoadSeason();
            if (SmvId != 0)
            {
                LoadSmvInfoForUpdate(SmvId);

                buyerNameDropDownList.Enabled = false;
                sampleStageDropDownList.Enabled = false;
                // fabricDropDownList.Enabled = false;
                //styleDescriptionTextBox.Enabled = false;
                //styleNumberTextBox.Enabled = false;
                ProductDropDownList.Enabled = false;
            }
            if(RequestId!=0)
            {
                LoadSmvInfoRequestIdWise(RequestId);
            }
            else
            {
                submitButton.Text = "Save";
                
            }
            

        }



    }


    //Load Buyer
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
                searchDropDownList.Items.Insert(0, new ListItem("Please Select", "0"));
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

    public DataTable LoadProductCategory()
    {
        DataTable dt = null;
        try
        {
            SmvBLL smvBLL = new SmvBLL();
            dt = smvBLL.LoadProductCategory();
            if(dt.Rows.Count>0)
            {
                ProductDropDownList.DataSource = dt;
                ProductDropDownList.DataValueField = "ProductId";
                ProductDropDownList.DataTextField = "ProductName";
                ProductDropDownList.DataBind();
                ProductDropDownList.Items.Insert(0, new ListItem("Please Select", "0"));
            }
        }
        catch(Exception ex)
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

    public DataTable ToDataTable<T>(List<T> items)

    {

        DataTable dataTable = new DataTable(typeof(T).Name);

        //Get all the properties

        PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (PropertyInfo prop in Props)

        {

            //Setting column names as Property names

            dataTable.Columns.Add(prop.Name);

        }

        foreach (T item in items)

        {

            var values = new object[Props.Length];

            for (int i = 0; i < Props.Length; i++)

            {

                //inserting property values to datatable rows

                values[i] = Props[i].GetValue(item, null);

            }

            dataTable.Rows.Add(values);

        }

        //put a breakpoint here and check datatable

        return dataTable;

    }



    protected void submitButton_Click(object sender, EventArgs e)
    {
        //string session= Session["ListOfOption"].ToString();

        string listOfOption = string.Empty;

        //if (Session["ListOfOption"].ToString()!="[]" || Session["ListOfOption"] != null)
        //{

        //    listOfOption = Session["ListOfOption"].ToString();

        //}
        try
        {
            if (Session["ListOfOption"].ToString() != "[]" || Session["ListOfOption"] != null)
            {

                listOfOption = Session["ListOfOption"].ToString();

            }
        }
        catch
        {
            listOfOption = "[]";
        }


        List<CostingOptionModel> dataList = new List<CostingOptionModel>();
        List<CostingOptionModel> listOfCostingOption = JsonConvert.DeserializeObject<List<CostingOptionModel>>(listOfOption);
        foreach (var optionModel in listOfCostingOption)
        {
            CostingOptionModel costingOption = new CostingOptionModel();
            costingOption.OptionNumber = optionModel.OptionNumber;
            if (optionModel.OptionReduction == null || optionModel.OptionReduction == "")
            {
                costingOption.OptionReduction = "0.00";
            }
            else
            {
                costingOption.OptionReduction = optionModel.OptionReduction;
            }
            if (optionModel.OptionAddition == null || optionModel.OptionAddition == "")
            {
                costingOption.OptionAddition = "0.00";
            }
            else
            {
                costingOption.OptionAddition = optionModel.OptionAddition;
            }
            costingOption.OptionDescription = optionModel.OptionDescription;
            costingOption.OptionRemarks = optionModel.OptionRemarks;
            dataList.Add(costingOption);
        }
        DataTable data = ToDataTable(dataList);




        DataTable dt = new DataTable();
        try
        {
            int value = 0;
            CostingSmv smv = new CostingSmv();
            SmvBLL smvBLL = new SmvBLL();
            MailClass mailClass = new MailClass();
            smv.BuyerId = Convert.ToInt32(buyerNameDropDownList.SelectedValue);

            value = Convert.ToInt32(sampleStageHiddenField.Value);
            smv.SampleStageId = value;
            smv.StyleNumber = styleNumberTextBox.Text.Trim();
            smv.DesignNumber = designTextBox.Text.Trim();
            smv.StyleDescription = styleDescriptionTextBox.Text;
            smv.FabricId = Convert.ToInt32(fabricDropDownList.SelectedValue);
            smv.ProductCategory = Convert.ToInt32(ProductDropDownList.SelectedValue);
            smv.Season= seasonTextBox.Text.Trim();
            smv.Department = "";
            //smv.SampleDate = sampleDateTextBox.Text;
            if (sampleDateTextBox.Text == "1900-01-01")
            {
                smv.SampleDate = Convert.ToString("");
            }
            else
            {
                smv.SampleDate = Convert.ToString(sampleDateTextBox.Text);
            }


            if (sewingTextBox.Text == "" || sewingTextBox.Text == null)
            {
                smv.SewingSmv = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.SewingSmv = Convert.ToDecimal(sewingTextBox.Text);
            }

            if (pleatingTextBox.Text == "" || pleatingTextBox.Text == null)
            {
                smv.PleatingSmv = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.PleatingSmv = Convert.ToDecimal(pleatingTextBox.Text);
            }



            if (permanentCreaseTextBox.Text == "" || permanentCreaseTextBox.Text == null)
            {
                smv.PermanentCrease = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.PermanentCrease = Convert.ToDecimal(permanentCreaseTextBox.Text);
            }

            if (supperCreaseTextBox.Text == "" || supperCreaseTextBox.Text == null)
            {
                smv.SupperCrease = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.SupperCrease = Convert.ToDecimal(supperCreaseTextBox.Text);
            }

            if (heatSealTextBox.Text == "" || heatSealTextBox.Text == null)
            {
                smv.HeatSeal = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.HeatSeal = Convert.ToDecimal(heatSealTextBox.Text);
            }

            if (overlayTextBox.Text == "" || overlayTextBox.Text == null)
            {
                smv.OverlayFilm = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.OverlayFilm = Convert.ToDecimal(overlayTextBox.Text);
            }

            if (plkTextBox.Text == "" || plkTextBox.Text == null)
            {
                smv.PLKQuilting = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.PLKQuilting = Convert.ToDecimal(plkTextBox.Text);
            }

            if (autoTextBox.Text == "" || autoTextBox.Text == null)
            {
                smv.AutoQuilting = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.AutoQuilting = Convert.ToDecimal(autoTextBox.Text);
            }
            if (quiltingManualTextBox.Text == "" || quiltingManualTextBox.Text == null)
            {
                smv.ManualQuilting = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.ManualQuilting = Convert.ToDecimal(quiltingManualTextBox.Text);
            }

            if (downManualTextBox.Text == "" || downManualTextBox.Text == null)
            {
                smv.ManualDownFill = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.ManualDownFill = Convert.ToDecimal(downManualTextBox.Text);
            }

            if (downMachineTextBox.Text == "" || downMachineTextBox.Text == null)
            {
                smv.MachineDownFill = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.MachineDownFill = Convert.ToDecimal(downMachineTextBox.Text);
            }

            if (seamTextBox.Text == "" || seamTextBox.Text == null)
            {
                smv.SeamSeal = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.SeamSeal = Convert.ToDecimal(seamTextBox.Text);
            }

            if (bondingTextBox.Text == "" || bondingTextBox.Text == null)
            {
                smv.Bonding = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.Bonding = Convert.ToDecimal(bondingTextBox.Text);
            }
            if (cuttingTextBox.Text == "" || cuttingTextBox.Text == null)
            {
                smv.CuttingSMV = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.CuttingSMV = Convert.ToDecimal(cuttingTextBox.Text);
            }
            if (finisingTextBox.Text == "" || finisingTextBox.Text == null)
            {
                smv.FinishingSmv = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.FinishingSmv = Convert.ToDecimal(finisingTextBox.Text);
            }

            if (otherValueTextBox.Text == "" || otherValueTextBox.Text == null)
            {
                smv.OthersValue = Convert.ToDecimal("0.00");
            }
            else
            {
                smv.OthersValue = Convert.ToDecimal(otherValueTextBox.Text);
            }


            smv.OthersDescription = otherDescriptionTextBox.Text;
           
            smv.OptionValue = Convert.ToDecimal("0.00");
            smv.OptionAdditionalValue = Convert.ToDecimal("0.00");
            smv.OptionNumber = "";
            smv.OptionDescription = "";
            smv.OptionRemarks = "";
            smv.ReviewBy = Convert.ToInt32(reviewDropDownList.SelectedValue);
            smv.ApprovedBy = Convert.ToInt32(approvedDropDownList.SelectedValue);

            smv.Remarks = descriptionTextarea.InnerText;
            smv.MachineDescription = machineDetailsTextarea.InnerText;

            if (SmvId == 0)
            {
                smv.PostedBy = Convert.ToInt32(userId);
                smv.UpdatedBy = 0;
                dt = smvBLL.InsertNewCostingSmvInfo(smv, data);

                if (dt.Rows.Count > 0)
                {
                    bool buyerName = Convert.ToBoolean(dt.Rows[0]["dBuyer"]);

                    if (buyerName)


                    {
                        messageLabel.Text = "<p Style ='font-size:20px;color:Red; margin-top:20px;'>Already Exists</p>";
                    }
                    else
                    {
                        //mailClass.SendMailForCostingSmv(smv);

                        if(smv.ApprovedBy==0)
                        {
                            mailClass.SendMailForApprovedByNotSet(smv);
                        }

                        messageLabel.Text = "<p Style ='font-size:20px;color:Green; margin-top:20px;'>New Information Successfully Inserted</p>";
                        ClearAllData();
                        Page.Response.Redirect(url.ToString(), true);
                    }
                }
            }
            else
            {


                smv.SmvId = SmvId;
                smv.UpdatedBy = Convert.ToInt32(userId);
                actionResult = smvBLL.UpdateCostingSmv(smv,data);

                if (actionResult >= 1)
                {
                    
                    messageLabel.Text = "<p Style ='font-size:20px;color:Green; margin-top:20px;'> Information Successfully Updated</p>";

                    if (smv.ApprovedBy == 0)
                    {
                        mailClass.SendMailForApprovedByNotSet(smv);
                    }

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
        table = loadCostingSmvinformation(buyerId,styleNumber);
    }

    public string loadCostingSmvinformation(int buyerId, string StyleNumber)
    {
        SmvBLL smvBll = new SmvBLL();


        //buyerId = Convert.ToInt32(seatchDropDownList.SelectedValue);

        try
        {
            smvtable = smvBll.LoadCostingSmvInfo(buyerId, StyleNumber);
        }
        catch (Exception ex)
        {

        }
        return smvtable;
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {

        styleNumber = searchTextBox.Text;
        styleNumber = styleNumber.Replace("'", "_");
        buyerId = Convert.ToInt32(searchDropDownList.SelectedValue);
        table = loadCostingSmvinformation(buyerId,styleNumber);
    }


    public void LoadSmvInfoForUpdate(int smvId)
    {
        int buyerIdForLoad = 0;
        try
        {
            SmvBLL smvBll = new SmvBLL();
            DataTable dt = smvBll.LoadCostingInfoInfoForUpdate(SmvId);

            if (dt.Rows.Count > 0)
            {
                buyerNameDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["BuyerId"]);
                buyerIdForLoad = Convert.ToInt32(dt.Rows[0]["BuyerId"]);
                string value = Convert.ToString(dt.Rows[0]["SampleStageId"]);
                sampleStageHiddenField.Value = value;

                loadSampleStageForUpdate(buyerIdForLoad); 

                sampleStageDropDownList.SelectedValue = sampleStageHiddenField.Value;
                fabricDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["FabricId"]);

                styleDescriptionTextBox.Text = Convert.ToString(dt.Rows[0]["StyleDescription"]); 
                styleNumberTextBox.Text = Convert.ToString(dt.Rows[0]["StyleNumber"]);
                designTextBox.Text = Convert.ToString(dt.Rows[0]["DesignNumber"]);

                ProductDropDownList.SelectedValue= Convert.ToString(dt.Rows[0]["ProductCategoryId"]);
                //SeasonDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["SeasonId"]);
                seasonTextBox.Text= Convert.ToString(dt.Rows[0]["SeasonId"]);
                DateTime date= Convert.ToDateTime(dt.Rows[0]["SampleDate"]);

                if(date.ToString("yyyy-MM-dd") == "1900-01-01")
                {
                    sampleDateTextBox.Text = "";
                }
                else
                {
                    sampleDateTextBox.Text = date.ToString("yyyy-MM-dd");
                }
                




                sewingTextBox.Text = Convert.ToString(dt.Rows[0]["SwingSmv"]);
                pleatingTextBox.Text = Convert.ToString(dt.Rows[0]["PleatingSmv"]);

                permanentCreaseTextBox.Text= Convert.ToString(dt.Rows[0]["PermanentCrease"]);
                supperCreaseTextBox.Text= Convert.ToString(dt.Rows[0]["SupperCrease"]);

                heatSealTextBox.Text = Convert.ToString(dt.Rows[0]["HeatSealHeatSmv"]);
                overlayTextBox.Text = Convert.ToString(dt.Rows[0]["OverlayFilmHeatSmv"]);
                plkTextBox.Text = Convert.ToString(dt.Rows[0]["PLKQuiltingSmv"]);
                autoTextBox.Text = Convert.ToString(dt.Rows[0]["AutoQuiltingSmv"]);
                quiltingManualTextBox.Text = Convert.ToString(dt.Rows[0]["ManualQuiltingSmv"]);
                downManualTextBox.Text = Convert.ToString(dt.Rows[0]["ManualDownFill"]);
                downMachineTextBox.Text = Convert.ToString(dt.Rows[0]["MachineDownFill"]);
                seamTextBox.Text = Convert.ToString(dt.Rows[0]["SeamSeal"]);
                bondingTextBox.Text = Convert.ToString(dt.Rows[0]["Bonding"]);
                cuttingTextBox.Text = Convert.ToString(dt.Rows[0]["CuttingSMV"]);
                finisingTextBox.Text = Convert.ToString(dt.Rows[0]["FinisingSmv"]);
                otherDescriptionTextBox.Text = Convert.ToString(dt.Rows[0]["OthersDescription"]);
                otherValueTextBox.Text = Convert.ToString(dt.Rows[0]["OthersValue"]);
                //optionDescriptionTextBox.Text = Convert.ToString(dt.Rows[0]["OptionDescription"]);
                //optionNumberTextBox.Text= Convert.ToString(dt.Rows[0]["OptionNumber"]);
                //optionRemarksTextBox.Text= Convert.ToString(dt.Rows[0]["OptionRemarks"]);
                //optionValueTextBox.Text = Convert.ToString(dt.Rows[0]["OptionValue"]);
                //optionAdditionalTextBox.Text= Convert.ToString(dt.Rows[0]["OptionAdditionalValuee"]);
                machineDetailsTextarea.InnerText = Convert.ToString(dt.Rows[0]["MachineWork"]);
                descriptionTextarea.InnerText = Convert.ToString(dt.Rows[0]["Remarks"]);
                approvedDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["ApprovedBy"]);
                reviewDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["ReviewBy"]);

                submitButton.Text = "Correction";

            }
        }

        catch (Exception ex)
        {

        }
    }

    public void LoadSmvInfoRequestIdWise(int requestId)
    {
        int buyerIdForLoad = 0;

        try
        {
            MerchantGateway merchantGateway = new MerchantGateway();
            DataTable dt = merchantGateway.LoadMerchantRequestInfoRequestIdWise(requestId);

            if (dt.Rows.Count > 0)
            {
                buyerNameDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["BuyerId"]);
                buyerIdForLoad = Convert.ToInt32(dt.Rows[0]["BuyerId"]);
                string value = Convert.ToString(dt.Rows[0]["SampleStageId"]);
                sampleStageHiddenField.Value = value;

                loadSampleStageForUpdate(buyerIdForLoad);

                sampleStageDropDownList.SelectedValue = sampleStageHiddenField.Value;
                fabricDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["FabricId"]);            
                styleNumberTextBox.Text = Convert.ToString(dt.Rows[0]["StyleNumber"]);
                designTextBox.Text = Convert.ToString(dt.Rows[0]["DesignNumber"]);
                ProductDropDownList.SelectedValue = Convert.ToString(dt.Rows[0]["ProductId"]);
            }

                
        }
        catch(Exception ex)
        {

        }
    }


    public void ClearAllData()
    {
        buyerNameDropDownList.SelectedValue = "0";


        sampleStageDropDownList.SelectedValue = "0";
        fabricDropDownList.SelectedValue = "0";
       // SeasonDropDownList.SelectedValue = "0";
        seasonTextBox.Text = "";
        styleNumberTextBox.Text = "";
        styleDescriptionTextBox.Text = "";
        designTextBox.Text = "";

        ProductDropDownList.SelectedValue = "0";
        sampleDateTextBox.Text = "";


        sewingTextBox.Text = "";
        pleatingTextBox.Text = "";
        heatSealTextBox.Text = "";
        overlayTextBox.Text = "";
        plkTextBox.Text = "";
        autoTextBox.Text = "";
        quiltingManualTextBox.Text = "";
        downManualTextBox.Text = "";
        downMachineTextBox.Text = "";
        seamTextBox.Text = "";
        bondingTextBox.Text = "";
        cuttingTextBox.Text = "";
        finisingTextBox.Text = "";
        otherDescriptionTextBox.Text = "";
        otherValueTextBox.Text = "";
        //optionDescriptionTextBox.Text = "";
        //optionValueTextBox.Text = "";
        //optionNumberTextBox.Text = "";
        //optionDescriptionTextBox.Text = "";
        //optionAdditionalTextBox.Text = "";
       // workTextArea.InnerText = "";
        machineDetailsTextarea.InnerText = "";
        descriptionTextarea.InnerText = "";
        approvedDropDownList.SelectedValue = "0";
        reviewDropDownList.SelectedValue = "0";
        permanentCreaseTextBox.Text = "";
        supperCreaseTextBox.Text = "";

        submitButton.Text = "Save";
        buyerNameDropDownList.Enabled = true;
        sampleStageDropDownList.Enabled = true;
        //fabricDropDownList.Enabled = true;
        //styleDescriptionTextBox.Enabled = true;
        styleNumberTextBox.Enabled = true;
        ProductDropDownList.Enabled = true;
    }

    protected void reloadButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("CostingSmvPanel.aspx");
    }



    [WebMethod]
    public static List<Tuple<string>> Load_SuggestionForStyleNumber(string keyword)
    {
        List<Tuple<string>> DataList = new List<Tuple<string>>();
        SmvEntryGateway smvEntryGateway = new SmvEntryGateway();
        DataList = smvEntryGateway.Get_SuggestionForStyleNumber(keyword);

        return DataList;
    }




    [WebMethod]
    public static List<Tuple<string>> Load_SuggestionForDesignNumber(string keyword)
    {
        List<Tuple<string>> DataList = new List<Tuple<string>>();
        SmvEntryGateway smvEntryGateway = new SmvEntryGateway();
        DataList = smvEntryGateway.Get_SuggestionForDesignNumber(keyword);

        return DataList;
    }



    protected void exlButton_Click(object sender, EventArgs e)
    {
        DataTable dt = null;

        StringBuilder tableRow = new StringBuilder();
        styleNumber = Convert.ToString(searchTextBox.Text);
        buyerId = Convert.ToInt32(searchDropDownList.SelectedValue);
        loadCostingSmvinformation(buyerId, styleNumber);
        tableRow.Append("<table class='table table-bordered' id='tableLoad'>" + loadCostingSmvinformation(buyerId, styleNumber) + "</table>");
        
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=New_Costing_Smv.xls");
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
    //    DataTable dt = null;
    //    try
    //    {
    //        SmvBLL smvBLL = new SmvBLL();
    //        dt = smvBLL.LoadSeason();

    //        if (dt.Rows.Count > 0)
    //        {
    //            SeasonDropDownList.DataSource = dt;
    //            SeasonDropDownList.DataValueField = "SeasonId";
    //            SeasonDropDownList.DataTextField = "Season";
    //            SeasonDropDownList.DataBind();
    //            SeasonDropDownList.Items.Insert(0, new ListItem("Please Select", "0"));

    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //    }
        
    //}

}