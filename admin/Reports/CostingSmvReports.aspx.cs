using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Reports_CostingSmvReports : System.Web.UI.Page
{
    public string styleNumber = "";
    public string designNumber = "";
    public int buyerId=0;
    public string smvtable = null;
    public string table = "";

    public string userId = "0";
    public string userName = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        GenarateSessionThroughtCoockie checkSession = new GenarateSessionThroughtCoockie();

        bool hasSession = checkSession.SessionCheck(1);

        if (hasSession)
        {
            userId = Session["KP_User_Id"].ToString();
            userName = Session["KP_UserName"].ToString();
        }
        else

        {
            Response.Redirect("~/admin/Default.aspx");
            Response.End();
        }




        if (!IsPostBack)
        {
            table = loadCostingSmvinformation(buyerId, styleNumber);
            //LoadStyleInfo();
            LoadBuyerName();
        }
        table = loadCostingSmvinformation(buyerId, styleNumber);
        //LoadStyleInfo();

    }



    //public DataTable LoadStyleInfo()
    //{
    //    DataTable dt = null;
    //    try
    //    {
    //        BulkSmvBLL bulkSmvBLL = new BulkSmvBLL();
    //        dt = bulkSmvBLL.LoadStyleName();

    //        if (dt.Rows.Count > 0)
    //        {
    //            searchDropDownList.DataSource = dt;
    //            searchDropDownList.DataValueField = "StyleId";
    //            searchDropDownList.DataTextField = "StyleNumber";
    //            searchDropDownList.DataBind();
    //            searchDropDownList.Items.Insert(0, new ListItem("Search With Style Number", "0"));

    //        }

    //    }
    //    catch (Exception ex)
    //    {

    //    }
    //    return dt;
    //}
    public DataTable LoadBuyerName()
    {
        DataTable dt = null;
        try
        {
            SampleStageBLL sampleBLL = new SampleStageBLL();
            dt = sampleBLL.LoadBuyerName();
            if (dt.Rows.Count > 0)
            {
                buyerDropDownList.DataSource = dt;
                buyerDropDownList.DataValueField = "BuyerId";
                buyerDropDownList.DataTextField = "BuyerName";
                buyerDropDownList.DataBind();
                buyerDropDownList.Items.Insert(0, new ListItem("Please Select Buyer", "0"));
            }
        }
        catch (Exception ex)
        {

        }
        return dt;
    }


    //[WebMethod]
    //public static Style[] LoadStyle(int buyerId)
    //{
    //    DataTable dt = new DataTable();
    //    List<Style> style = new List<Style>();
    //    try
    //    {


    //        using (SmvEntryGateway smvGateway = new SmvEntryGateway())
    //        {

    //            dt = smvGateway.LoadBuyerWiseStyleNumber(buyerId);

    //            if (dt.Rows.Count > 0)
    //            {
    //                foreach (DataRow dtr in dt.Rows)
    //                {
    //                    Style stylePart = new Style();
    //                    stylePart.StyleId = Convert.ToInt32(dtr["StyleId"].ToString());
    //                    stylePart.StyleNumber = dtr["StyleNumber"].ToString();
    //                    style.Add(stylePart);
    //                }
    //            }

    //        }
    //    }
    //    catch (Exception Ex)
    //    {

    //    }
    //    return style.ToArray();
    //}


    public string loadCostingSmvinformation(int BuyerId,string StyleNumber)
    {
        SmvBLL smvBll = new SmvBLL();


        //buyerId = Convert.ToInt32(seatchDropDownList.SelectedValue);

        try
        {
            smvtable = smvBll.ReportCostingSmvInfo(BuyerId, StyleNumber);
        }
        catch (Exception ex)
        {

        }
        return smvtable;
    }

    protected void searchButton_Click(object sender, EventArgs e)
    {

        buyerId = Convert.ToInt32(buyerDropDownList.SelectedValue);

        //if (styleNumberTextBox.Text!="")
        //{
            styleNumber = styleNumberTextBox.Text;
        //styleNumber.Replace("'","%");
        styleNumber = styleNumber.Replace("'", "_");
        //}
        //else if(designNumberTextBox.Text!="")
        //{
        //    designNumber = designNumberTextBox.Text;            
        //}

        table = loadCostingSmvinformation(buyerId, styleNumber);
    }

    protected void exlbutton_Click(object sender, EventArgs e)
    {
        DataTable dt = null;

        StringBuilder tableRow = new StringBuilder();
        styleNumber = Convert.ToString(styleNumberTextBox.Text);
        buyerId= Convert.ToInt32(buyerDropDownList.SelectedValue);
        loadCostingSmvinformation(buyerId, styleNumber);
        tableRow.Append("<table class='table table-bordered' id='tableLoad'>" + loadCostingSmvinformation(buyerId, styleNumber) + "</table>");
        

        // string output = LoadNewMarchentLive(formDate,toDate);
        Response.Clear();
        Response.Buffer = true;
       Response.AddHeader("content-disposition", "attachment;filename=Costing_Smv_Report.xls");       
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        Response.Output.Write(tableRow.ToString());
        Response.Flush();
        Response.End();
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
}