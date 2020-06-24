<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LandingPage.aspx.cs" Inherits="LandingPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Welcome</title>

    <link href="Content/bootstrap.css" rel="stylesheet" />
    <script src="Scripts/bootstrap.js"></script>
    <script src="Scripts/jquery-3.2.1.js"></script>
    <style>
        body {
            background-image: url("Merchant/images/katlynohara-nh-fashion-photographer-models-1_uxga.JPG");
            position: fixed center;
            
        }
        #adminButton,#merchantButton{
            background-color: Transparent;
            background-repeat:no-repeat;
            cursor:pointer;
            overflow: hidden;
            outline:none;
            color:white;
            font-size:20px; 
            border: white solid 1px; 
        }
        .acolumn{
            display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: center;
  text-align: center;
  min-height: 100vh;
        }
        #adminButton{
            margin-right: 170px;
            margin-bottom: -42px;

        }
        #merchantButton{
            margin-left: 380px;
        }

        #adminButton:hover,#merchantButton:hover{
            background-color: #808080;
            background-repeat:no-repeat;
            cursor:pointer;
            overflow: hidden;
            outline:none;
            color:white;
            font-size:20px;  
            border: #4a4683 solid 1px;
        }
        
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="acolumn">
        <asp:Button ID="adminButton" runat="server" Text="Login As PPIE" CssClass="btn btn-group-lg" OnClick="adminButton_Click"/>   
        <asp:Button ID="merchantButton" runat="server" Text="Login As Merchant" CssClass="btn btn-group-lg" OnClick="merchantButton_Click"/>    
    </div>
        
            
        
        
    </form>
</body>
</html>
