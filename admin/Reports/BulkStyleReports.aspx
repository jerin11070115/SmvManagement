﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BulkStyleReports.aspx.cs" EnableEventValidation="false" Inherits="admin_Reports_BulkStyleReports" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>GSD Sewing Reports</title>

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


   <%-- <style>
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
    </style>--%>

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
                                <a href="#" class="dropdown-toggle" data-toggle="dropdown"><i class="lnr lnr-question-circle"></i><span>Help</span> <i class="icon-submenu lnr lnr-chevron-down"></i></a>
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
                            <%--<li><a href="#" class=""><i class="lnr lnr-home"></i><span>Dashboard</span></a></li>--%>
                            <li><a href="../Users/UserProfile.aspx" class=""><i class="lnr lnr-user"></i><span>Profile</span></a></li>
                            
                            
                            <%--<li><a href="#" class=""><i class="lnr lnr-code"></i><span>Reports</span></a></li>--%>
                            <li>
                                <a href="#subPages" data-toggle="collapse" class="collapsed"><i class="lnr lnr-file-empty"></i><span>Entry Panel</span> <i class="icon-submenu lnr lnr-chevron-left"></i></a>
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
                                <a href="#subReport" data-toggle="collapse" class="collapsed"><i class="lnr lnr-code"></i><span>Reports</span> <i class="icon-submenu lnr lnr-chevron-left"></i></a>
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
                <div class="main-content"  style="background-color:#F1F1F1">
                    <div class="container-fluid">
                         <div class="col-lg-12" style="text-align:center" >
                            <h1 style="color:#13144F;display:inline-block; border-bottom:1px solid #13144F;font-family:Franchise;">GSD SEWING REPORT</h1>
                        </div>
                        <div class="col-lg-12">
                            <hr />
                        </div>
                         <div class="col-lg-12">
                            <div class="col-lg-4 form-group">
                                <asp:TextBox ID="fromDateTextBox" runat="server" style="background-color:#244369;margin-left: 72px;" PlaceHolder="From Date" CssClass="form-control" ></asp:TextBox>
                            </div>
                            <div class="col-lg-4 form-group">
                                <asp:TextBox ID="toDateTextBox" runat="server" style="background-color:#244369;margin-left: 124px;" PlaceHolder="To Date" CssClass="form-control" ></asp:TextBox>
                            </div>
                            <div class="col-lg-4 form-group">
                                <div class="glyphicon">
                                    <i class="glyphicon-search form-control-feedback" style="color:#f5f0f0;"></i>
                                      
                                <asp:Button ID="searchButton" runat="server" Style="background-color: #12233C; border-color: #12233C; margin-left: 114px;" class="btn btn-primary btn-search" OnClick ="searchButton_Click"></asp:Button>
                            </div>
                             </div>
                                <%--<div class="glyphicon">
                                     <i class="glyphicon glyphicon-search form-control-feedback" style="color: #f5f0f0;"></i>
                                     <asp:Button ID="Button1" runat="server" style="background-color: #12233C; border-color: #12233C;" class="btn btn-primary btn-search" OnClick="searchButton_Click"></asp:Button>
                            </div>--%>
                          
                           
                        <div class="col-lg-12">
                            <hr />
                        </div>
                           
                       
                         
                      <%-- <div class="col-lg-12">
                             <%=BulkTable%>
                        </div>  --%> 

                        <div class="col-lg-12 table row" id="report" style="margin-top: 40px;">
                            <table id="example" class="table table-bordered">
                                <%=BulkTable%>
                            </table>
                        </div>
                        <div class="col-lg-12">
                                <asp:Button ID="exlButton" runat="server" Text="Convert to Excel File" BackColor="#145A32" BorderColor="#000000" ForeColor="#FBFCFC" Font-Size="Small" Style="margin-left: 737px;" CssClass="btn btn-success" OnClick="exlButton_Click"  />
                         </div>   
                        <div class="col-lg-12">
                            <asp:button id="BtnPrint" runat="server" BackColor="#133337" BorderColor="#133337" ForeColor="#E3E9E5" style="margin-left: 85px;" cssclass="btn btn-success" onclientclick="javascript:CallPrint('report');" text="Print" xmlns:asp="#unknown" />
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
                <%-- <div class="col-lg-3">
                            <asp:button id="BtnPrint" runat="server" BackColor="#133337" BorderColor="#133337" style="margin-left: 648px;margin-bottom: 32px;" ForeColor="#E3E9E5" cssclass="btn btn-success" onclientclick="javascript:CallPrint('report');" text="Print" xmlns:asp="#unknown" />
                        </div>--%>
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
        $("#fromDateTextBox").datepicker({
            dateFormat: 'yy-mm-dd',
            maxDate: 0
        });
    });

    $(function () {
        $("#toDateTextBox").datepicker({
            dateFormat: 'yy-mm-dd',
            maxDate: 0
        });
    });

</script>
<script language="javascript" type="text/javascript">
    function CallPrint(strid) {
        var prtContent = document.getElementById(strid);
        var WinPrint = window.open('', '', 'letf=0,top=0,width=1200,height=800,toolbar=0,scrollbars=0,status=0,dir=ltr');
        WinPrint.document.write(prtContent.innerHTML);
        WinPrint.document.close();
        WinPrint.focus();
        WinPrint.print();
        WinPrint.close();
        prtContent.innerHTML = strOldOne;
    }
</script>



