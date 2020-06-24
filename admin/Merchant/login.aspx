<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" EnableEventValidation="false" Inherits="Merchant_login" %>

<!doctype html>
<html>
    <head>
    <meta charset="utf-8">
    <title>Sign In</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <meta name="description" content="">

    <!-- Le styles -->
    <link rel="stylesheet" type="text/css" href="bootstrap/css/bootstrap.min.css" />

    <link href="css/login.css" rel="stylesheet">
    
	<script type="text/javascript" src="js/jquery.js"></script>    
    <script type="text/javascript" src="bootstrap/js/bootstrap.min.js"></script>

    <style type="text/css">
      body {
        padding-top: 30px;
      }

      pbfooter {
        position:relative;
      }
    </style>


       
  	<!-- Google Fonts call. Font Used Open Sans & Raleway -->
	<link href="http://fonts.googleapis.com/css?family=Raleway:400,300" rel="stylesheet" type="text/css">
  	<link href="http://fonts.googleapis.com/css?family=Open+Sans" rel="stylesheet" type="text/css">

  	<!-- Jquery Validate Script -->
    <script type="text/javascript" src="js/jquery.validate.js"></script>

</head>

  <body style="background:url('images/photo_chlo_06.jpg') no-repeat center center; height:700px;">
  <form id="form1" runat="server">         
  	<!-- NAVIGATION MENU -->

    

    <div class="container">
        <div class="row">
   		<div class="col-lg-offset-4 col-lg-4" style="margin-top:100px">
   			<div class="block-unit" style="text-align:center; padding:8px 8px 8px 8px;">
   				<img src="images/h-logo.png" alt="" class="img-circle" style="height:100px;">
   				<br>
   				<br>
					<div class="cmxform" id="signupForm" >
						<fieldset>
							<p>


                                <asp:TextBox ID="userNameTextBox" runat="server" type="text" placeholder="Username"></asp:TextBox>
                                <asp:TextBox ID="passWordTextBox" runat="server" type="password" placeholder="Password"></asp:TextBox>
							</p>
								
                                <asp:Button ID="submitButton" runat="server" Text="Login" class="submit btn-success btn btn-large" OnClick="Login_Click"/>
                            
						</fieldset>
					</div>
   			</div>

   		</div>


        </div>
    </div>



    <!-- Le javascript
    ================================================== -->
    <!-- Placed at the end of the document so the pages load faster -->
    <script type="text/javascript" src="js/bootstrap.js"></script>
</form>    
  
</body></html>