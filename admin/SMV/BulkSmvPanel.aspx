<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BulkSmvPanel.aspx.cs" EnableEventValidation="false" Inherits="admin_SMV_BulkSmvPanel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bulk Smv</title>

    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge,chrome=1">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <!-- VENDOR CSS -->
    <link rel="stylesheet" href="../../assets/vendor/bootstrap/css/bootstrap.min.css">
    <link rel="stylesheet" href="../../assets/vendor/font-awesome/css/font-awesome.min.css">
    <link rel="stylesheet" href="../../assets/vendor/linearicons/style.css">
    <!-- MAIN CSS -->
    <link rel="stylesheet" href="../../assets/css/main.css">
    <!-- FOR DEMO PURPOSES ONLY. You should remove this in your project -->
    <link rel="stylesheet" href="../../assets/css/demo.css">
    <!-- GOOGLE FONTS -->
    <link href="https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,600,700" rel="stylesheet">
    <!-- ICONS -->
    <link rel="apple-touch-icon" sizes="76x76" href="../../assets/img/apple-icon.png">
    <link rel="icon" type="image/png" sizes="96x96" href="../../assets/img/favicon.png">
    <!--pdf-->
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js">
    <link rel="stylesheet" type="text/css" href="//cdn.datatables.net/tabletools/2.2.4/css/dataTables.tableTools.css">


    <!-- DatePicker-->
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />


    <style>
        table {
            display: block;
            max-width: 600px;
            overflow-x: scroll;
            max-height: 500px;
            overflow-y: scroll;
            width: 2055px;
        }

        #eventHead, #eventTb #eventTr {
            display: table;
            width: 2055px;
            table-layout: fixed;
        }

        #eventTd {
            display: table;
            width: 2055px;
            table-layout: fixed;
        }

        thead {
            width: 100%;
        }
        ::-webkit-scrollbar {
  width: 20px;
}

/* Track */
::-webkit-scrollbar-track {
  box-shadow: inset 0 0 5px grey; 
  border-radius: 3px;
}
 
/* Handle */
::-webkit-scrollbar-thumb {
  background:#003366; 
  border-radius: 10px;
}

/* Handle on hover */
::-webkit-scrollbar-thumb:hover {
  background: grey; 
}
/*::-webkit-scrollbar { 
    display: none; 
    /*overflow: hidden;*/
}*/
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <!-- NAVBAR -->
            <nav class="navbar navbar-default navbar-fixed-top"  style="background-color:#001f3f">
                <div class="brand" style="background-color:#001f3f;height: 0px">
                   <img src="../../assets/img/hirdaramani_logo_white.png" />
                </div>
                <div class="container-fluid">
                    <form class="navbar-form navbar-left">
                        <!--Search option-->

                    </form>
                    <div class="navbar-btn navbar-btn-right">

                        <!--LogOut Button -->
                    </div>
                    <div id="navbar-menu">
                        <ul class="nav navbar-nav navbar-right">
                           <%-- <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="lnr lnr-question-circle"></i><span>Help</span> <i class="icon-submenu lnr lnr-chevron-down"></i></a>
                                <ul class="dropdown-menu">
                                    <li><a href="#">Basic Use</a></li>
                                </ul>
                            </li>--%>
                            
                             <button class="btn btn-primary" id="reloadButton" runat="server" style="background-color: #001f3f; border-color: #001f3f; margin-top: 24px;" href="../SMV/BulkSmvPanel.aspx" ><span class="glyphicon glyphicon-refresh"></span></button> 
                            <li class="dropdown">
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                                    <img src="../../assets/img/KP-logo.png" class="img-circle" alt="Avatar">
                                    <span><%=userName%></span> <i class="icon-submenu lnr lnr-chevron-down"></i></a>
                                <ul class="dropdown-menu">
                                    <li><a href="#"><i class="lnr lnr-user"></i><span>My Profile</span></a></li>
                                    <li><a href="../SignOut.aspx"><i class="lnr lnr-exit"></i><span>Logout</span></a></li>

                                </ul>
                            </li>

                        </ul>
                    </div>
                </div>
            </nav>
            <!-- END NAVBAR -->
            <!-- LEFT SIDEBAR -->
                        <div id="sidebar-nav" class="sidebar">
                <div class="sidebar-scroll">
                    <nav>
                        <ul class="nav">
                            <%--<li><a href="#" class=""><i class="lnr lnr-home"></i><span>Dashboard</span></a></li>--%>
                            <li><a href="../Users/UserProfile.aspx" class=""><i class="lnr lnr-user"></i><span>Profile</span></a></li>
                            
                            
                            <%--<li><a href="#" class=""><i class="lnr lnr-code"></i><span>Reports</span></a></li>--%>
                            <li>
                                <a href="#subPages" data-toggle="collapse" class="collapsed"><i class="lnr lnr-file-empty"></i><span>Entry Panel</span><i class="icon-submenu lnr lnr-pointer-left"></i></a>
                                <div id="subPages" class="collapse ">
                                    <ul class="nav">
                                        <li><a href="../EntryPanel/BuyerEntry.aspx" class="">Buyer Entry</a></li>
                                        <li><a href="../EntryPanel/FabricEntry.aspx" class="">Fabrics Entry</a></li>
                                        <li><a href="../EntryPanel/SampleStageEntry.aspx" class="">Sample Stage</a></li>
                                        <%--<li><a href="../EntryPanel/StyleEntry.aspx" class="">Style Entry</a></li>--%>
                                        <li><a href="../EntryPanel/ProductEntryPanel.aspx" class="">Product Category</a></li>
                                        <li><a href="../SMV/CostingSmvPanel.aspx" class="">Costing Smv Entry</a></li>
                                        <li><a href="../SMV/CostingRevisedPanel.aspx" class="">Costing Revised</a></li>
                                        <li><a href="../SMV/BulkSmvPanel.aspx" class="">Bulk Smv Entry</a></li>
                                        <li><a href="../SMV/BulkRevisedPanel.aspx" class="">Bulk Revised</a></li>

                                    </ul>
                                </div>
                            </li>
                            <li>
                                <a href="#subReport" data-toggle="collapse" class="collapsed"><i class="lnr lnr-code"></i><span>Reports</span> <i class="icon-submenu lnr lnr-pointer-left"></i></a>
                                <div id="subReport" class="collapse">
                                    <ul class="nav">
                                        <li><a href="../Reports/CostingSmvReports.aspx">Costing Smv Report</a></li>
                                        <li><a href="../Reports/BulkSmvReport.aspx">Bulk Smv Report</a></li>
                                        <li><a href="../Reports/CostingSmvDetailsReport.aspx">Costing Smv Details</a></li>
                                        <li><a href="../Reports/BulkSmvDetailsReport.aspx">Bulk Smv Details</a></li>
                                        <li><a href="../Reports/BulkStyleReports.aspx">GSD Sewing Report</a></li>
                                        <li><a href="../Reports/StyleCombineReport.aspx">Style Combine Report</a></li>
                                        <li><a href="../Reports/ComponentSmvReport.aspx">Component SMV Report</a></li>
                                        <li><a href="../Reports/SMvDailyReport.aspx">Daily SMV Report</a></li>
                                    </ul>
                                </div>
                            </li>
                            <li><a href="../Users/AllUsersSummary.aspx" class=""><i class="lnr lnr-users"></i><span>ALL User Report</span></a></li>
                            <li><a href="../Users/KpiReport.aspx" class=""><i class="lnr lnr-map"></i><span>KPI Report</span></a></li>
                             <li><a href="../Users/DailyKpiReport.aspx" class=""><i class="lnr lnr-map"></i><span>Daily KPI Report</span></a></li>
                            <li><a href="../Request/SmvRequestPanel.aspx" class=""><i class="lnr lnr-bubble"></i><span>Merchant Request</span></a></li>
                            <%--<li><a href="../Users/NewAccount.aspx" class=""><i class="lnr lnr-user"></i><span>New Account</span></a></li>--%>
                            

                        </ul>
                    </nav>
                </div>
            </div>

            <!-- END LEFT SIDEBAR -->
            <!-- MAIN -->
            <div class="main">
                <!-- MAIN CONTENT -->
                <div class="main-content" style="background-color: #F1F1F1">
                    <div class="container-fluid" >

                       
                            <div class="col-lg-11" style="text-align:center">
                                <h1 style="color:#13144F;display:inline-block; border-bottom:1px solid #13144F;font-family:Franchise;">Bulk Information</h1>
                            </div>
                        

                           <%-- <div class="col-lg-1">
                                <asp:Button ID="reloadButton" runat="server" Text="Refresh" BackColor="#20B2AA" BorderColor="#000000" ForeColor="#FBFCFC" Font-Size="Small" CssClass="btn btn-link" OnClick="reloadButton_Click" />
                            </div>--%>
                        
                        <div class="col-lg-12">
                            <hr />
                        </div>
                        <div class="col-lg-12">
                            <asp:Label ID="messageLabel" runat="server"></asp:Label>
                        </div>
                        <div class="col-lg-12">
                            <hr />
                        </div>
                        <div class="col-lg-4">
                            <asp:DropDownList ID="searchDropDownList" runat="server" Style="border-radius:15px; width: 200px; margin-left: 236px; background-color:#244369;color:#F1F1F1" CssClass="form-control">
                            </asp:DropDownList>
                        </div>

                        <div class="col-lg-4">
                            <div class="form-group">
                                <asp:TextBox ID="searchTextBox" runat="server" Style="border-radius:15px;width: 200px; margin-left: 143px; background-color:#244369;color:#F1F1F1"  CssClass="form-control" placeholder="Search With Style Number"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4" style="text-align: center">
                         <%--<button class="btn btn-primary" id="searchButton" runat="server" style="background-color:#001f3f; border-color:#001f3f;" href="../SMV/BulkSmvPanel.aspx"><span class="glyphicon glyphicon-search"></span></button>--%>
                             
                                <div class="glyphicon">
                                     <i class="glyphicon glyphicon-search form-control-feedback" style="color: #f5f0f0;"></i>
                                     <asp:Button ID="Button2" runat="server" style="background-color: #12233C; border-color: #12233C;" class="btn btn-primary btn-search" OnClick="searchButton_Click"></asp:Button>
                            </div>
                            
                            <%--<asp:Button ID="searchButton" runat="server" Text="Search" BackColor="#2471A3" BorderColor="#000000" ForeColor="#FBFCFC" Font-Size="Small" CssClass="btn btn-success" OnClick="searchButton_Click" />--%>
                        </div>
                        <div class="col-lg-12 table" id="table">

                            <table class='table table-bordered' id='example'>
                                <%=table%>
                            </table>
                        </div>

                       <%-- <div class="col-lg-12">--%>
                           <%-- <div class="col-lg-4">
                                <asp:Button ID="Button1" runat="server" Text="Convert to Excel File" BackColor="#145A32" BorderColor="#000000" ForeColor="#FBFCFC" Font-Size="Small" CssClass="btn btn-success" OnClick="exlButton_Click"  />
                            </div>--%>
                           <%-- <div class="col-lg-4">
                                <asp:Button ID="exlButton" runat="server" Text="Convert to Excel File" CssClass="btn btn-success" OnClick="exlButton_Click" />
                            </div>--%>
                            <%--<div class="col-lg-4"></div>
                        </div>--%>
                        <div class="col-lg-12">
                            <hr />
                        </div>
                          <%--<div class="col-lg-12" style="text-align: center; vertical-align:central; margin-bottom: 45px; background-color:#AAB7B8;">
                            <h1 style="color:#2471A3;">Bulk Smv ENtry</h1>
                        </div>--%>
                        

                        <div class="col-lg-12" id="mainBody" runat="server">
                            <div class="col-lg-12">
                                <asp:Label ID="errorMessageLabel" runat="server"></asp:Label>
                            </div>
                            <div class="col-lg-12">
                                <hr />
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="usr" style="color:#2471A3;"><b>Buyer Name :</b> </label>
                                    <asp:DropDownList ID="buyerNameDropDownList" runat="server" Style="border-radius:15px;width: 190px;background-color:#244369;color:#F1F1F1" CssClass="form-control"
                                        onchange="sampleStageSelect(this.value)">
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="buyerIdHiddenField" runat="server" />
                                </div>
                            </div>

                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="usr" style="color:#2471A3;"><b>Sample Stage :</b> </label>
                                    <asp:DropDownList ID="sampleStageDropDownList" runat="server" Style="border-radius:15px;width: 190px;background-color:#244369;color:#F1F1F1" CssClass="form-control">
                                        <asp:ListItem Text="Please Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="sampleStageHiddenField" Value="0" runat="server" />
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="usr" style="color:#2471A3;"><b>Fabrics :</b> </label>
                                    <asp:DropDownList ID="fabricDropDownList" runat="server" Style="border-radius:15px;width: 190px;background-color:#244369;color:#F1F1F1" CssClass="form-control">
                                        <asp:ListItem Text="Please Select" Value="0"></asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:HiddenField ID="fabricsHiddenField" Value="0" runat="server" />
                                </div>
                            </div>
                             <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="ProductDropDownList" style="color:#2471A3;"><b>Product Category :</b> </label>
                                    <asp:DropDownList ID="ProductDropDownList" runat="server" Style="border-radius:15px;width: 190px;background-color:#244369;color:#F1F1F1" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="styleNumberTextBox" style="color:#2471A3;"><b>Style Number:</b> </label>
                                    <asp:TextBox ID="styleNumberTextBox" runat="server"  Style="border-radius:15px;width: 190px;background-color:#244369;color:#F1F1F1" CssClass="form-control" placeholder="Style Number"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="styleDescriptionTextBox" style="color:#2471A3;"><b>Style Description:</b> </label>
                                    <asp:TextBox ID="styleDescriptionTextBox" runat="server"  Style="border-radius:15px;width: 190px;background-color:#244369;color:#F1F1F1" CssClass="form-control" placeholder="Style Description"></asp:TextBox>
                                </div>
                            </div>


                           
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="sampleDateTextBox" style="color:#2471A3;"><b>Sample Date:</b> </label>
                                    <asp:TextBox ID="sampleDateTextBox" runat="server" CssClass="form-control" Style="border-radius:15px;width: 190px;background-color:#244369;color:#F1F1F1" placeholder="Sample Date"></asp:TextBox>
                                </div>
                            </div>
                            <asp:HiddenField ID="valueAddedSmvHiddenField" runat="server" value="0"/>

<%--							<div class="col-lg-3">
                                <div class="form-group">
                                    <label for="SeasonDropDownList" style="color:#2471A3;"><b>Season :</b> </label>
                                    <asp:DropDownList ID="SeasonDropDownList" runat="server" Style="border-radius:15px;width: 190px;background-color:#244369;color:#F1F1F1" CssClass="form-control">
                                    </asp:DropDownList>
                                </div>
                            </div>--%>
                            <div class="col-lg-3">
                                <div class="form-group">
                                    <label for="seasonTextBox" style="color:#2471A3;"><b>Season</b> </label>
                                    <asp:TextBox ID="seasonTextBox" runat="server" Style="width: 190px;background-color:#244369;border-radius: 22px;color:#F1F1F1" CssClass="form-control" placeholder="Season"></asp:TextBox>
                                </div>
                            </div>


                            <div class="col-lg-12" id="smvBody">
                               <%-- <div class="col-lg-12">
                                    <h4><b>Bulk SMV :</b></h4>
                                </div>--%>
                                <div class="col-lg-12">
                                    <hr />
                                </div>
                                <div class="col-lg-12">
                                    <div class="col-lg-2">
                                         <div class="form-group">
                                        <label for="sewingTextBox" style="color:#2471A3;"><b>Sewing SMV:</b> </label>
                                        <asp:TextBox ID="sewingTextBox" runat="server"  style="border-radius:15px;background-color:#244369;color:#F1F1F1" CssClass="form-control" placeholder="00.00"></asp:TextBox>
                                    </div>
                                    </div>
                                   <div class="col-lg-2">
                                       <div class="form-group">
                                        <label for="finishingTextBox" style="color:#2471A3;"><b>Finising Smv :</b> </label>
                                        <asp:TextBox ID="finishingTextBox" runat="server" CssClass="form-control" placeholder="00.00" style="border-radius:15px;width: 120px;background-color:#244369;color:#F1F1F1"></asp:TextBox>
                                    </div>
                                   </div>
                               </div>
                                <div class="col-lg-12">
                                     <div class="form-group">
                                        <h4 style="color:#2471A3;"><b>Heat Seal : </b></h4>

                                        <input value="0" type="checkbox" id="activeFits" name="active[]" />
                                        <label for="activeFits" style="color:#2471A3;"><b>Fits</b></label>

                                        <input value="0" type="checkbox" id="activeOverlay" name="active[]" />
                                        <label for="activeOverlay" style="color:#2471A3;"><b>Overlay Film</b></label>
                                    </div>
                                </div>
                               <div class="col-lg-2">
                                  
                                    <div class="form-group">
                                        <label for="fitsTextBox" style="color:#2471A3;"><b>Fits :</b> </label>
                                        <asp:TextBox ID="fitsTextBox" runat="server" style="border-radius:15px;background-color:#244369;" CssClass="form-control" placeholder="00.00"></asp:TextBox>
                                    </div>
                                
                               </div>
                                    <div class="col-lg-2">
                                          <div class="form-group">
                                        <label for="overlayTextBox" style="color:#2471A3;"><b>Overlay Film</b> </label>
                                        <asp:TextBox ID="overlayTextBox" runat="server" style="border-radius:15px;background-color:#244369;" CssClass="form-control" placeholder="00.00"></asp:TextBox>
                                    </div>
                                    </div>

                                     <div class="col-lg-12">
                                    <div class="form-group">
                                        <h4 style="color:#2471A3;"><b>Quilting SMV :</b> </h4>
                                        <input value="0" type="checkbox" id="activePLK" name="active[]" />
                                        <label for="activePLK" style="color:#2471A3;"><b>PLK </b></label>
                                        <input value="0" type="checkbox" id="activeAuto" name="active[]" />
                                        <label for="activeAuto" style="color:#2471A3;"><b>AUTO </b></label>
                                        <input value="0" type="checkbox" id="activeManual" name="active[]" />
                                        <label for="activeManual" style="color:#2471A3;"><b>Manual </b></label>

                                    </div>

                                </div>
                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label for="plkTextBox" style="color:#2471A3;"><b>PLK :</b> </label>
                                        <asp:TextBox ID="plkTextBox" runat="server" style="border-radius:15px;background-color:#244369;" CssClass="form-control" placeholder="00.00"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label for="autoTextBox" style="color:#2471A3;"><b>AUTO :</b> </label>
                                        <asp:TextBox ID="autoTextBox" runat="server" style="border-radius:15px;background-color:#244369;" CssClass="form-control" placeholder="00.00"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label for="quiltingManualTextBox" style="color:#2471A3;"><b>Manual :</b> </label>
                                        <asp:TextBox ID="quiltingManualTextBox" runat="server" style="border-radius:15px;background-color:#244369;" CssClass="form-control" placeholder="00.00"></asp:TextBox>
                                    </div>
                                </div>
                                      <div class="col-lg-12">
                                    <h4 style="color:#2471A3;"><b>Down Fill :</b></h4>
                                    <input value="0" type="checkbox" id="activeDownfillManual" name="active[]" />
                                    <label for="activeDoenfillManual" style="color:#2471A3;"><b>Manual </b></label>

                                    <input value="0" type="checkbox" id="activeDownfillMachine" name="active[]" />
                                    <label for="activeDownfillMachine" style="color:#2471A3;"><b>Machine </b></label>
                                </div>
                               
                                
                                
                                   
                                   
                                     <div class="col-lg-2">
                                    <div class="form-group">
                                        <label for="downManualTextBox" style="color:#2471A3;"><b>Manual:</b> </label>
                                        <asp:TextBox ID="downManualTextBox" runat="server" style="border-radius:15px;background-color:#244369;color:#F1F1F1" CssClass="form-control" placeholder="00.00"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-2">
                                    <div class="form-group">
                                        <label for="downMachineTextBox" style="color:#2471A3;"><b>Machine :</b> </label>
                                        <asp:TextBox ID="downMachineTextBox" runat="server" style="border-radius:15px;background-color:#244369;width: 120px;color:#F1F1F1" CssClass="form-control" placeholder="00.00"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-4 ">
                                    <div class="form-group">
                                        <label for="machineDetailsTextarea" style="color:#2471A3;"><b>Machine details concern :</b> </label>
                                        <textarea id="machineDetailsTextarea" cols="20" rows="3" runat="server" style="border-radius:15px;background-color:#244369;color:#F1F1F1" class="form-control" placeholder="Machine details concern"></textarea>
                                    </div>
                                </div>
                                   <div class="col-lg-4"">
                                    <div class="form-group">
                                        <label for="descriptionTextarea" style="color:#2471A3;"><b>Remarks :</b> </label>
                                        <textarea id="descriptionTextarea" cols="20" rows="3" runat="server" style="border-radius:15px;background-color:#244369;color:#F1F1F1" class="form-control" placeholder="Description "></textarea>
                                    </div>
                                </div>
                                <!-----Option Start------------>
                                  <%--<div class="col-lg-2">
                                        <div class="form-group">
                                            <label for="optionNumberTextBox" style="color:#2471A3;"><b>Option Number:</b> </label>
                                            <asp:TextBox ID="optionNumberTextBox" runat="server" CssClass="form-control" placeholder="Option Number"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label for="optionValueTextBox"><b>Option Reduction:</b> </label>
                                            <asp:TextBox ID="optionValueTextBox" runat="server" CssClass="form-control" placeholder="Reduction Value"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label for="optionAdditionalTextBox" style="color:#2471A3;"><b>Option Additional:</b> </label>
                                            <asp:TextBox ID="optionAdditionalTextBox" runat="server" CssClass="form-control" placeholder="Additional Value"></asp:TextBox>
                                        </div>
                                    </div>
                                   
                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label for="optionDescriptionTextBox" style="color:#2471A3;"><b>Option Description:</b> </label>
                                            <asp:TextBox ID="optionDescriptionTextBox" runat="server" CssClass="form-control" placeholder="Option Description"></asp:TextBox>
                                        </div>
                                    </div>

                                    <div class="col-lg-3">
                                        <div class="form-group">
                                            <label for="optionRemarksTextBox" style="color:#2471A3;"><b>Option Remarks:</b> </label>
                                            <asp:TextBox ID="optionRemarksTextBox" runat="server" CssClass="form-control" placeholder="Option Remarks"></asp:TextBox>
                                        </div>
                                    </div>--%>
                                
                                

                               
                                

                               
                               
                                

                            
                                  <%--  <div class="col-lg-2">
                                        <div class="form-group">
                                            <label for="optionNumberTextBox" style="color:#2471A3;"><b>Option Number:</b> </label>
                                            
                                        <input id="optionNumberTextBox" type="text" class="form-control" placeholder="Option Number"/>
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label for="optionValueTextBox" style="color:#2471A3;"><b>Option Reduction:</b> </label>
                                            
                                        <input id="optionValueTextBox" type="text" class="form-control" placeholder="Reduction Value"/>
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label for="optionAdditionalTextBox" style="color:#2471A3;"><b>Option Additional:</b> </label>
                                            
                                       <input id="optionAdditionalTextBox" type="text" class="form-control" placeholder="Additional Value"/>
                                             </div>
                                    </div>
                                    
                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label for="optionDescriptionTextBox" style="color:#2471A3;"><b>Option Description:</b> </label>
                                            
                                        <input id="optionDescriptionTextBox" type="text" class="form-control" placeholder="Option Description"/>
                                        </div>
                                    </div>

                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label for="optionRemarksTextBox" style="color:#2471A3;"><b>Option Remarks:</b> </label>
                                            
                                        <input id="optionRemarksTextBox" type="text" class="form-control" placeholder="Option Remarks"/>
                                        </div>
                                    </div>


                                    <div class="col-lg-2">
                                        <div class="form-group">
                                            <label for="addOption" style="color:#2471A3;"><b>ADD Option</b> </label>
                                            <input id="addOption" type="button" value="ADD" onclick="AddOptions();" class="btn btn-success"/>
                                        
                                        </div>
                                    </div>
                                
                               
                                <div class="elementAllNetwork"></div>--%>

                        
                    



                               

                                <%--<div class="col-lg-4" style="margin-top: 20px;">
                                    <%--<div class="form-group">
                                        <label for="remarksTextArea"><b>Remarks :</b> </label>
                                        <textarea id="remarksTextArea" cols="20" rows="3" runat="server" class="form-control" placeholder="Working Update"></textarea>
                                    </div>--%>
                               <%-- </div>--%>

                                <!-----Option End--------->
                             
                       

                            



                            <div class="col-lg-12" style="margin-top: 20px;">

                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label for="reviewDropDownList" style="color:#2471A3;"><b>Review By :</b> </label>
                                        <asp:DropDownList ID="reviewDropDownList" runat="server" Style="border-radius:15px;width: 190px;background-color:#244369;color:#F1F1F1" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>




                                <div class="col-lg-4"></div>
                                <div class="col-lg-4">
                                    <div class="form-group">
                                        <label for="approvedDropDownList" style="color:#2471A3;"><b>Approved By :</b> </label>
                                        <asp:DropDownList ID="approvedDropDownList" runat="server" Style="border-radius:15px;width: 190px;background-color:#244369;color:#F1F1F1" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                </div>

                            </div>

                            <div class="col-lg-12" style="margin-top: 20px;">
                                <div class="col-lg-4"></div>
                                <div class="col-lg-4">
                                    <asp:Button ID="submitButton" runat="server" Text="Save" class="btn btn-success" Style="width: 80px; margin-left: 80px;background-color:#096887;border-color: #096887;" OnClick="submitButton_Click" OnClientClick="return Validation();" />
                                </div>
                                <div class="col-lg-4"></div>
                            </div>

                            <div class="col-lg-12">
                                <hr />

                            </div>




                            <asp:HiddenField ID="smvIdHiddenField" runat="server" />
                        </div>


                    </div>
                </div>
                <!-- END MAIN CONTENT -->
            </div>
            <!-- END MAIN -->
            <div class="clearfix"></div>
            <footer>
                <div class="container-fluid">
                    <p style="color:#000000; font-family: "Helvetica Neue",Helvetica,Arial,sans-serif; font-weight: bold;" class="copyright">Kenpark & Regency (Hirdaramani Bangladesh) &copy; 2017</p>
                </div>
            </footer>
        </div>
    </form>



    <script src="../../assets/vendor/jquery/jquery.min.js"></script>
    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script src="../../assets/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="../../assets/vendor/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../../assets/scripts/klorofil-common.js"></script>

    <script src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>
    <script src="//cdn.datatables.net/tabletools/2.2.4/js/dataTables.tableTools.min.js"></script>
</body>
</html>


<script type="text/javascript">
    $(function () {
        $("#searchTextBox").autocomplete({
            source: function (request, response) {
                var param = { keyword: $('#searchTextBox').val() };
                $.ajax({
                    url: window.location.origin + window.location.pathname + "/Load_SuggestionForStyleNumber",
                    data: JSON.stringify(param),
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        
                        response($.map(data.d, function (item) {
                            
                            return {

                                value: item["Item1"]
                            }
                        }));
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });
            },
            select: function (event, ui) {
                var StyleData = ui.item.value;
                
                var styleName = StyleData;
                
                $('#searchTextBox').val(styleName);
                

                return false;
            },

            minLength: 2//minLength as 2, it means when ever user enter 1 character in TextBox the AutoComplete method will fire and get its source data. 
        });
    });
</script>

<%--Load sampleStage--%>
<script type="text/javascript">

    function sampleStageSelect(intvalue) {
        var buyerId = intvalue;
        //alert(categoryId);
        $('#sampleStageDropDownList').empty().append($("<option></option>").val("0").html("--Please Select--"))
        $.ajax({
            beforeSend: function () {

                // $('#loadBusy').show();
            },
            complete: function () {

                //$('#loadBusy').hide();
            },
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "BulkSmvPanel.aspx/LoadSampleStage",

            data: "{ 'buyerId': '" + buyerId + "' }",

            dataType: "json",
            async: true,
            success: function (data) {
                $.each(data.d, function (key, value) {
                    resultData = data['d'];
                    $("#sampleStageDropDownList").append($("<option></option>").val(value.SampleStageId).html(value.SampleStageName));  //value.resultData[0]
                    $('#sampleStageDropDownList').val($('#sampleStageHiddenField').val());
                });
            },
            error: function (result) {
                alert("Error");
            }
        });
    }

    $('#sampleStageDropDownList').on('change', function () {

        $('#sampleStageHiddenField').val($('#sampleStageDropDownList').val());

    });
</script>

<script type="text/javascript">
    $('#activeFits').click(function () {
        activeheatSeal();
    });
    $('#activeOverlay').click(function () {
        activeOverlay();
    });

    $(document).ready(function () {
        document.getElementById("activeFits").checked = true;
        document.getElementById("overlayTextBox").disabled = true;
        document.getElementById("fitsTextBox").disabled = false;
        document.getElementById("activeOverlay").checked = false;

        document.getElementById("quiltingManualTextBox").disabled = true;
        document.getElementById("autoTextBox").disabled = true;
        document.getElementById("plkTextBox").disabled = false;

        document.getElementById("activeAuto").checked = false;
        document.getElementById("activeManual").checked = false;
        document.getElementById("activePLK").checked = true;

        document.getElementById("downMachineTextBox").disabled = true;
        document.getElementById("downManualTextBox").disabled = false;
        document.getElementById("activeDownfillMachine").checked = false;
        document.getElementById("activeDownfillManual").checked = true;
    })


    $('#activeDownfillManual').click(function () {
        document.getElementById("downMachineTextBox").disabled = true;
        document.getElementById("downManualTextBox").disabled = false;
        document.getElementById("activeDownfillMachine").checked = false;
    });

    $('#activeDownfillMachine').click(function () {
        document.getElementById("downMachineTextBox").disabled = false;
        document.getElementById("downManualTextBox").disabled = true;
        document.getElementById("activeDownfillManual").checked = false;
    });


    $('#activePLK').click(function () {
        document.getElementById("quiltingManualTextBox").disabled = true;
        document.getElementById("autoTextBox").disabled = true;
        document.getElementById("plkTextBox").disabled = false;

        document.getElementById("activeAuto").checked = false;
        document.getElementById("activeManual").checked = false;

    });

    $('#activeAuto').click(function () {
        document.getElementById("quiltingManualTextBox").disabled = true;
        document.getElementById("autoTextBox").disabled = false;
        document.getElementById("plkTextBox").disabled = true;
        document.getElementById("activePLK").checked = false;
        document.getElementById("activeManual").checked = false;
    });


    $('#activeManual').click(function () {
        document.getElementById("quiltingManualTextBox").disabled = false;
        document.getElementById("autoTextBox").disabled = true;
        document.getElementById("plkTextBox").disabled = true;
        document.getElementById("activePLK").checked = false;
        document.getElementById("activeAuto").checked = false;
    });


    function activeheatSeal() {
        document.getElementById("overlayTextBox").disabled = true;
        document.getElementById("fitsTextBox").disabled = false;
        document.getElementById("activeOverlay").checked = false;

    }


    function activeOverlay() {
        document.getElementById("fitsTextBox").disabled = true;
        document.getElementById("overlayTextBox").disabled = false;
        document.getElementById("activeFits").checked = false;
    }
</script>

<script type="text/javascript">
    $(function () {
        $("#sampleDateTextBox").datepicker({
            dateFormat: 'yy-mm-dd',
            maxDate: 0
        });
    });

</script>

<script type="text/javascript">
    function Validation() {
        if (document.getElementById("buyerNameDropDownList").value == 0) {
            document.getElementById("buyerNameDropDownList").focus();
            document.getElementById('buyerNameDropDownList').style.color = "red";
            document.getElementById("errorMessageLabel").innerHTML = "Please Select A Buyer";
            document.getElementById('errorMessageLabel').style.color = "red";
            document.getElementById('errorMessageLabel').style.fontSize = "20px";
            return false;
        }
        if (document.getElementById("sampleStageDropDownList").value == 0) {
            document.getElementById("sampleStageDropDownList").focus();
            document.getElementById('sampleStageDropDownList').style.color = "red";
            document.getElementById("errorMessageLabel").innerHTML = "Please Select A Buyer's Sample Stage";
            document.getElementById('errorMessageLabel').style.color = "red";
            document.getElementById('errorMessageLabel').style.fontSize = "20px";
            return false;
        }
        if (document.getElementById("fabricDropDownList").value == 0) {
            document.getElementById("fabricDropDownList").focus();
            document.getElementById('fabricDropDownList').style.color = "red";
            document.getElementById("errorMessageLabel").innerHTML = "Please Select A Fabric Item";
            document.getElementById('errorMessageLabel').style.color = "red";
            document.getElementById('errorMessageLabel').style.fontSize = "20px";
            return false;
        }



        if (document.getElementById("ProductDropDownList").value == 0) {
            document.getElementById("ProductDropDownList").focus();
            document.getElementById('ProductDropDownList').style.color = "red";
            document.getElementById("errorMessageLabel").innerHTML = "Please Select A Product Category";
            document.getElementById('errorMessageLabel').style.color = "red";
            document.getElementById('errorMessageLabel').style.fontSize = "20px";
            return false;
        }
    }
</script>

<%--//search stylenumber--%>
<script type="text/javascript">
    $(function () {
        $("#styleNumberTextBox").autocomplete({
            source: function (request, response) {
                var param = { keyword: $('#styleNumberTextBox').val() };
                $.ajax({
                    url: window.location.origin + window.location.pathname + "/Load_SuggestionForStyleNumber",
                    data: JSON.stringify(param),
                    dataType: "json",
                    type: "POST",
                    contentType: "application/json; charset=utf-8",
                    dataFilter: function (data) { return data; },
                    success: function (data) {
                        //console.log(data.d[0][1]);
                        response($.map(data.d, function (item) {
                            
                            return {

                                value: item["Item1"]
                            }
                        }));
                    },
                    error: function (XMLHttpRequest, textStatus, errorThrown) {
                        alert(textStatus);
                    }
                });
            },
            select: function (event, ui) {
                var StyleData = ui.item.value;
                
                var styleName = StyleData;
                
                $('#styleNumberTextBox').val(styleName);
                
                // update what is displayed in the textbox
                //this.value = v; 
                return false;
            },

            minLength: 2//minLength as 2, it means when ever user enter 1 character in TextBox the AutoComplete method will fire and get its source data. 
        });
    });
</script>




<script type="text/javascript">
    function Validation() {
        if (document.getElementById("buyerNameDropDownList").value == 0) {
            document.getElementById("buyerNameDropDownList").focus();
            document.getElementById('buyerNameDropDownList').style.color = "red";
            document.getElementById("errorMessageLabel").innerHTML = "Please Select A Buyer";
            document.getElementById('errorMessageLabel').style.color = "red";
            document.getElementById('errorMessageLabel').style.fontSize = "20px";
            return false;
        }
        if (document.getElementById("sampleStageDropDownList").value == 0) {
            document.getElementById("sampleStageDropDownList").focus();
            document.getElementById('sampleStageDropDownList').style.color = "red";
            document.getElementById("errorMessageLabel").innerHTML = "Please Select A Buyer's Sample Stage";
            document.getElementById('errorMessageLabel').style.color = "red";
            document.getElementById('errorMessageLabel').style.fontSize = "20px";
            return false;
        }
        if (document.getElementById("fabricDropDownList").value == 0) {
            document.getElementById("fabricDropDownList").focus();
            document.getElementById('fabricDropDownList').style.color = "red";
            document.getElementById("errorMessageLabel").innerHTML = "Please Select A Fabric Item";
            document.getElementById('errorMessageLabel').style.color = "red";
            document.getElementById('errorMessageLabel').style.fontSize = "20px";
            return false;
        }



        if (document.getElementById("ProductDropDownList").value == 0) {
            document.getElementById("ProductDropDownList").focus();
            document.getElementById('ProductDropDownList').style.color = "red";
            document.getElementById("errorMessageLabel").innerHTML = "Please Select A Product Category";
            document.getElementById('errorMessageLabel').style.color = "red";
            document.getElementById('errorMessageLabel').style.fontSize = "20px";
            return false;
        }


        //PassData();
    }
</script>

<script type="text/javascript">
    var valueOfAllOption = [];

    function AddOptions() {
        checkDuplicate = 0;
        optionNumber = $('#optionNumberTextBox').val();
        optionValue = $('#optionValueTextBox').val();
        optionAdditional = $('#optionAdditionalTextBox').val();
        optionDescription = $('#optionDescriptionTextBox').val();
        optionRemarks = $('#optionRemarksTextBox').val();

        var objectValue = {};

        objectValue['OptionNumber'] = optionNumber.trim();
        objectValue['OptionReduction'] = optionValue.trim();
        objectValue['OptionAddition'] = optionAdditional.trim();
        objectValue['OptionDescription'] = optionDescription.trim();
        objectValue['OptionRemarks'] = optionRemarks.trim();

        valueOfAllOption.push(objectValue);

        showAllData();

    }


    function showAllData() {
        var showAllValue = '<table class=socialNetworkValue>';
        showAllValue += '<tr><td>' + '<b>Option Number</b>' + '&nbsp;&nbsp;</td><td>' + '<b>Reduction Value</b>' + '&nbsp;&nbsp;</td><td>' + '<b>Additional Value</b>' + '&nbsp;&nbsp;</td><td>' + '<b> Description</b>' + '&nbsp;&nbsp;</td><td>' + '<b>Remarks</b>' + '&nbsp;&nbsp;</td><td><b>Action</b></td></tr>';
        for (var i = 0; i < valueOfAllOption.length; i++) {

            showAllValue += '<tr><td>' + valueOfAllOption[i].OptionNumber + '&nbsp;&nbsp;</td><td>' + valueOfAllOption[i].OptionReduction + '&nbsp;&nbsp;</td><td>' + valueOfAllOption[i].OptionAddition + '&nbsp;&nbsp;</td><td>' + valueOfAllOption[i].OptionDescription + '&nbsp;&nbsp;</td><td>' + valueOfAllOption[i].OptionRemarks + '&nbsp;&nbsp;</td><td><input type=button class=btn-danger onclick=RemoveData(' + i + ') value=Remove /></td></tr>';
            showAllValue += '<br />';
        }
        showAllValue += '</table>';
        $('.elementAllNetwork').html(showAllValue);
    }


    function RemoveData(index) {
        valueOfAllOption.splice(index, 1);
        showAllData();
    }


    function PassData() {

        valueOfAllOption = JSON.stringify(valueOfAllOption);
        $.ajax({
            type: 'post',
            url: 'BulkSmvPanel.aspx/LoadJsonData',
            contentType: 'application/json;chatset=utf-8',
            dataType: 'JSON',
            data: JSON.stringify({ dataValue: valueOfAllOption }),
            success: function (data) {
                //alert('Ok');
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                //alert(textStatus);
            }
        });
    }
</script>
