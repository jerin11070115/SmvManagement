<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BuyerEntry.aspx.cs" EnableEventValidation="false" Inherits="admin_EntryPanel_BuyerEntry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Buyer Entry</title>

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
</head>
<body>
    <form id="form1" runat="server">
        <div id="wrapper">
            <!-- NAVBAR -->
            <nav class="navbar navbar-default navbar-fixed-top" style="background-color:#001f3f">
                <div class="brand" style="background-color:#001f3f;height: 0px">
                   <img src="../../assets/img/hirdaramani_logo_white.png" />
                </div>
                <div class="container-fluid">
                    <form class="navbar-form navbar-left">
                        <!--Search option-->

                    </form>
                    <div class="navbar-btn navbar-btn-right">

                        <!--LogOut Buttone -->
                    </div>
                    <div id="navbar-menu">
                        <ul class="nav navbar-nav navbar-right">
                            <li class="dropdown">
                                <%--<a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="lnr lnr-question-circle"></i><span>Help</span> <i class="icon-submenu lnr lnr-chevron-down"></i></a>--%>
                                <ul class="dropdown-menu">
                                    <li><a href="#">Basic Use</a></li>
                                </ul>
                            </li>
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
                            <li><a href="#" class=""><i class="lnr lnr-home"></i><span>Dashboard</span></a></li>
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
                                <a href="#subReport" data-toggle="collapse" class="collapsed"><i class="lnr lnr-code"></i><span>Reports</span><i class="icon-submenu lnr lnr-pointer-left"></i></a>
                                <div id="subReport" class="collapse">
                                    <ul class="nav">
                                        <li><a href="../Reports/CostingSmvReports.aspx">Costing Smv Report</a></li>
                                        <li><a href="../Reports/BulkSmvReport.aspx">Bulk Smv Report</a></li>
                                        <li><a href="../Reports/CostingSmvDetailsReport.aspx">Costing Smv Details</a></li>
                                        <li><a href="../Reports/BulkSmvDetailsReport.aspx">Bulk Smv Details</a></li>
                                        <li><a href="../Reports/BulkStyleReports.aspx">GSD Sewing Report</a></li>
                                        <li><a href="../Reports/StyleCombineReport.aspx">Style Combine Report</a></li>
                                        <li><a href="../Reports/ComponentSmvReport.aspx">Component SMV Report</a></li>
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
                <div class="main-content" style="background-color:#E6E6E8">
                    <div class="container-fluid">

                        <div class="col-lg-12">

                            <div class="row" style="text-align:center;text-decoration: underline; text-transform: uppercase;letter-spacing: 3px;line-height: 1.8;font-family:Franchise;color:#13144F;">
                                <h1>Buyer Entry Panel</h1>
                                <hr />
                            </div>
                            <div class="col-lg-12">
                                <asp:Label ID="messageLabel" runat="server" ></asp:Label>
                            </div>
                            <div class="col-lg-12" style="position:center;margin-left:7%;">
                            <div class="col-lg-4">
                                <div class="row form-group">
                                    <asp:Label ID="buyerLabel" runat="server" Text="Buyer Name" style="margin-left: 28%; text-transform: uppercase;letter-spacing: 3px;line-height: 1.8;font-size:20px;font-weight: bold;color:#13144F;"></asp:Label>
                                    <asp:TextBox ID="buyerTextBox" runat="server" Style="width: 218px;margin-left: 28%;border: 2px solid #0099FF;color:black;" placeholder="Enter Buyer Name" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                               <div class="col-lg-4">
                                <div class="form-group row">
                                    <asp:Label ID="isActaveLable" runat="server" Text="IsActive : " style="margin-left: 10%;margin-left: 25%; text-transform: uppercase;letter-spacing: 3px;line-height: 1.8;font-size:20px;font-weight: bold;color:#13144F;"></asp:Label>
                                    <asp:DropDownList ID="IsActiveDropDownList" runat="server" Style="width: 196px;margin-left: 25%;border: 2px solid #0099FF;color:black;" CssClass="form-control">
                                        
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Value="0">No</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div> 
                                 <asp:HiddenField ID="isActiveHiddenField" runat="server" />
                                <div class="col-lg-4">
                                    <asp:Button ID="submitButton" runat="server" Text="Submit" CssClass="btn btn-success" OnClick="submitButton_Click" style="margin-top:12%;margin-left: -8%;background-color: #008CBA;border-color:#008CBA;"/>
                                </div>
                            
                            </div>
                            
                           

                            <div class="col-lg-12" style="margin-top: 15px;">
                                <hr />
                            </div>
                           
                            <div class="col-lg-8" style="margin-top: -19px; table-border:-9px; margin-left: 16%;">

                                <%=table%>
                            </div>

                           

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
    <script src="../../assets/vendor/bootstrap/js/bootstrap.min.js"></script>
    <script src="../../assets/vendor/jquery-slimscroll/jquery.slimscroll.min.js"></script>
    <script src="../../assets/scripts/klorofil-common.js"></script>
</body>
</html>
