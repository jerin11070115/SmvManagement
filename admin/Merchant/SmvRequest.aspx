<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SmvRequest.aspx.cs" EnableEventValidation="false" Inherits="Merchant_SmvRequest" %>

<!doctype html>
<html>
<head>
    <meta charset="utf-8">
    <title>Merchant Request</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">


    <link href="../Content/bootstrap.min.css" rel="stylesheet" type="text/css" />

    <link href="css/main.css" rel="stylesheet">
    <link href="css/font-style.css" rel="stylesheet">
    <link href="css/flexslider.css" rel="stylesheet">



    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/base/jquery-ui.css" rel="stylesheet" type="text/css" />


    <style type="text/css">
        body {
            padding-top: 60px;
        }

        #buyerDropDownList, #styleNumberTextBox, #sampleStageDropDownList, #fabricDropDownList, #productDropDownList, #quantityTextBox, #costingDeadLineTextBox, #commentsTextBox, #sendToDropDownList,#DesignNumberTextBox,#pdfFileUpload,#optionDropDownList,#mailFileUpload {
            margin-left: 15px;
            background: #cdcbcc;
            width: 30%;
        }

        #styleNumberTextBox, #fabricDropDownList, #productDropDownList, #quantityTextBox, #sendToDropDownList {
            margin-top: 20px;
            width: 30%;
        }

        #pdfFileUpload {
                margin: 10px 0px 0px 0px;
                width: 342px;
        }

        #sendButton{
            margin: 20px 0px 0px 120px;
        }
        #example{
            background-color:#F5F5F5;
        }
        a{
            color:brown;
        }
        a:hover{
            color:rebeccapurple;
        }

    </style>




    <!-- Google Fonts call. Font Used Open Sans & Raleway -->
    <link href="http://fonts.googleapis.com/css?family=Raleway:400,300" rel="stylesheet" type="text/css">
    <link href="http://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet" type="text/css">
</head>
<body>
    <form id="form1" runat="server" class="cmxform">
        <!-- NAVIGATION MENU -->

        <div class="navbar-nav navbar-inverse navbar-fixed-top">
            <div class="container">
                <div class="navbar-header">
                    <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                        <span class="icon-bar"></span>
                    </button>
                    <a class="navbar-brand" href="index.html">
                        <img src="images/logo30.png" alt="">
                        Hirdaramani</a>
                </div>
                <div class="navbar-collapse collapse">
                    <ul class="nav navbar-nav">
                        <li><a href="Default.aspx"><i class="icon-home icon-white"></i>Home</a></li>
                        <li class="active"><a href="SmvRequest.aspx"><i class="icon-th icon-white"></i>SMV Request</a></li>
                        <li><a href="SmvReceive.aspx"><i class="icon-lock icon-white"></i>SMV Reports</a></li>
                        <%--<li><a href="user.html"><i class="icon-user icon-white"></i>User</a></li>--%>
                        <li><a href="SignOut.aspx"><i class="icon-lock icon-white"></i>Log Out</a></li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </div>

        <div class="container">

            <!-- FIRST ROW OF BLOCKS -->

            <div class="col-lg-12 col-md-12 col-xs-12">
                <h1>Smv Request :</h1>
            </div>

            <div class="col-lg-12 col-md-12 col-xs-12">
                <hr />
            </div>

            <div class="col-lg-12 col-md-12 col-xs-12">
                           
                    <div class="row">
                        <asp:Label ID="messageLabel" runat="server"></asp:Label>
                    </div>
                    <div class="row">
                        <asp:DropDownList ID="buyerDropDownList" runat="server" CssClass="form-control" onchange="sampleStageSelect(this.value)"></asp:DropDownList>
                        <asp:HiddenField ID="buyerIdHiddenField" runat="server" />
                    </div>
                    <div class="row">
                        <asp:TextBox ID="styleNumberTextBox" runat="server" CssClass="form-control" placeholder="Enter  Style Number"></asp:TextBox>
                    </div>

                    <div class="row">
                        <asp:TextBox ID="DesignNumberTextBox" runat="server" CssClass="form-control" placeholder="Enter Design Number"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:DropDownList ID="sampleStageDropDownList" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Please Select Sample Stage" Value="0"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:HiddenField ID="sampleStageHiddenField" Value="0" runat="server" />

                    </div>
                    <div class="row">
                        <asp:DropDownList ID="fabricDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="row">
                        <asp:DropDownList ID="productDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="quantityTextBox" runat="server" CssClass="form-control" placeholder="Enter Approx Order Qtn"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="costingDeadLineTextBox" runat="server" CssClass="form-control" placeholder="Select Costing Deadline"></asp:TextBox>
                    </div>
                    <div class="row">
                        <asp:TextBox ID="commentsTextBox" runat="server" CssClass="form-control" placeholder="Special Comments"></asp:TextBox>
                    </div>

                    <div class="row">
                        <asp:DropDownList ID="optionDropDownList" runat="server" CssClass="form-control">
                            <asp:ListItem Text="Select Option Request" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
                            <asp:ListItem Text="No" Value="0"></asp:ListItem>
                        </asp:DropDownList>                        
                    </div>
                    <div class="row">
                        <asp:DropDownList ID="sendToDropDownList" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>

                    <div id="fileUploadDiv row form-group" style="margin-top:20px; color:#ffffff">
                        <asp:Label ID="pdfFileUploadLable" runat="server" Text="Upload PDF File : "></asp:Label>
                        <asp:FileUpload ID="pdfFileUpload" runat="server" CssClass="btn btn-default" />
                    </div>
                    <div id="mailUploadDiv row form-group" style="margin-top:20px; color:#ffffff">
                        <asp:Label ID="mailFileUploadLabel" runat="server" Text="Upload Mail File : "></asp:Label>
                        <asp:FileUpload ID="mailFileUpload" runat="server" CssClass="btn btn-default" />
                    </div>

                    <div class="row">
                        <asp:Button ID="sendButton" runat="server" Text="Send" OnClick="sendButton_Click"/>
                    </div>
                
            </div>
            <div class="col-lg-12 col-md-12 col-xs-12">
                <hr />
            </div>
            <div class="col-lg-12 col-md-12 col-xs-12">
               <h3>Pending Request</h3>
            </div>
            <div class="col-lg-12 col-md-12 col-xs-12">
                <hr />
            </div>
            <div class="col-lg-12 col-md-12 col-xs-12">
                <%=table%>
            </div>
        </div>
        <!-- /container -->
        <div id="footerwrap">
            <footer class="clearfix"></footer>
            <div class="container">
                <div class="row">
                    <div class="col-sm-12 col-lg-12">
                        <p>
                            <img src="images/logo.png" alt="">
                        </p>
                        <p>Hirdaramani Bangladesh- Copyright 2018</p>
                    </div>

                </div>
                <!-- /row -->
            </div>
            <!-- /container -->
        </div>
        <!-- /footerwrap -->
    </form>


    <script type="text/javascript" src="../Scripts/jquery-3.2.1.min.js"></script>

    <script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
    <script type="text/javascript" src="../Scripts/bootstrap.min.js"></script>

    <script type="text/javascript" src="js/lineandbars.js"></script>

    <script type="text/javascript" src="js/dash-charts.js"></script>
    <script type="text/javascript" src="js/gauge.js"></script>

    <!-- NOTY JAVASCRIPT -->
    <script type="text/javascript" src="js/noty/jquery.noty.js"></script>
    <script type="text/javascript" src="js/noty/layouts/top.js"></script>
    <script type="text/javascript" src="js/noty/layouts/topLeft.js"></script>
    <script type="text/javascript" src="js/noty/layouts/topRight.js"></script>
    <script type="text/javascript" src="js/noty/layouts/topCenter.js"></script>

    <!-- You can add more layouts if you want -->
    <script type="text/javascript" src="js/noty/themes/default.js"></script>
    <!-- <script type="text/javascript" src="assets/js/dash-noty.js"></script> This is a Noty bubble when you init the theme-->
    <script type="text/javascript" src="http://code.highcharts.com/highcharts.js"></script>
    <script src="js/jquery.flexslider.js" type="text/javascript"></script>
    <script type="text/javascript" src="js/admin.js"></script>
    <script src="https://cdn.datatables.net/1.10.16/js/jquery.dataTables.min.js"></script>
    <script src="//cdn.datatables.net/tabletools/2.2.4/js/dataTables.tableTools.min.js"></script>


</body>
</html>

<script type="text/javascript">
    $(document).ready(function () {

        $("#btn-blog-next").click(function () {
            $('#blogCarousel').carousel('next')
        });
        $("#btn-blog-prev").click(function () {
            $('#blogCarousel').carousel('prev')
        });

        $("#btn-client-next").click(function () {
            $('#clientCarousel').carousel('next')
        });
        $("#btn-client-prev").click(function () {
            $('#clientCarousel').carousel('prev')
        });

    });

    $(window).load(function () {

        $('.flexslider').flexslider({
            animation: "slide",
            slideshow: true,
            start: function (slider) {
                $('body').removeClass('loading');
            }
        });
    });

</script>

<%--Load sampleStage--%>
<script type="text/javascript">

    function sampleStageSelect(intvalue) {
        var buyerId = intvalue;
        //alert(categoryId);
        $('#sampleStageDropDownList').empty().append($("<option></option>").val("0").html("Please Select Sample Stage"))
        $.ajax({
            beforeSend: function () {

                // $('#loadBusy').show();
            },
            complete: function () {

                //$('#loadBusy').hide();
            },
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "SmvRequest.aspx/LoadSampleStage",

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
    $(function () {
        $("#costingDeadLineTextBox").datepicker({
            dateFormat: 'yy-mm-dd',
            minDate: 0
        });

    });
</script>
