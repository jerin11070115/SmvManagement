<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" EnableEventValidation="false" Inherits="admin_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<link href="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" rel="stylesheet" id="bootstrap-css">
<head runat="server">
    <title>Welcome To Kenpark</title>
   
    <style>

        body {
            font-family: "Lato", sans-serif;
            /*background-color:burlywood;*/
            /*position: absolute;
            top: -20px;
            left: -20px;
            right: -40px;
            bottom: -40px;
            width: auto;
            /*height: auto;*/
        /*background: url("../assets/img/denim.jpg");
            background-repeat: no-repeat;*/
            /*background-size: 100% 50%;*/
            /*background-position: 0 0; 
            background-size: cover;*/
            /*-webkit-filter: blur(5px);*/
            /*z-index: 0;*/
            /*overflow: hidden;*/*/
        }



.main-head{
    height: 150px;
    background: #FFF;
    /*background-image: url("../assets/img/_ZAK8850.JPG");*/
   
}

.sidenav {
    height: 100%;
    background-color: #001f3f;
    overflow-x: hidden;
    padding-top: 20px;
}


        .main {
            padding: 0px 100px;
            /*background-image: url("../assets/img/fabric_sew_pants.jpg");*/
            width: 61%;
            background-image:url("../assets/img/fabric_SEW_pants.jpg")  ;     
            position: absolute;
            background-size: cover;
            right: 0px;
            height: 100%;
        }

@media screen and (max-height: 450px) {
    .sidenav {padding-top: 15px;}
}

@media screen and (max-width: 450px) {
    .login-form{
        margin-top: 10%;
    }

    .register-form{
        margin-top: 10%;
    }
}

@media screen and (min-width: 768px){
    .main{
        margin-left: 40%; 
    }

    .sidenav{
        width: 40%;
        position: fixed;
        z-index: 1;
        top: 0;
        left: 0;
    }

    .login-form{
        margin-top: 88%;
    }

    /*.register-form{
        margin-top: 20%;
    }*/
}


.login-main-text{
    margin-top: 26%;
    padding: 60px;
    color: #fff;
}

.login-main-text h2{
    font-weight: 300;
}

.btn-black{
    background-color: #0026ff !important;
    color:#ffffff ;
}
    </style>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js"></script>
<script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
   <div class="sidenav">
      
       <%--<div class="logoclass">
            <img src="../assets/img/hirdaramani_logo_white.png" style="" />
       </div>--%>

         <div class="login-main-text">
             <img src="../assets/img/hirdaramani_logo_white.png" style="margin-left: -5px;" />
            <h1>SMV<br>INTERFACE</h1>
            <p>Login or register from here to access.</p>
         </div>
      </div>
      <div class="main" >
         <div class="col-md-6 col-sm-12">
            <div class="login-form">
               <form>
                  <div class="form-group">
                     <label style="color: #ffffff"><b>User Name</b></label>
                     <%--<input type="text" class="form-control" placeholder="User Name" >--%>
                      <asp:TextBox class="form-control" ID="userNameTextBox" placeholder="User Name" runat="server"></asp:TextBox><asp:Label ID="idAlartLabel" runat="server"></asp:Label>
                  </div>
                  <div class="form-group">
                     <label style="color: #ffffff"><b>Password</b></label>
                     <%--<input type="password" class="form-control" placeholder="Password">--%>
                      <asp:TextBox class="form-control" ID="passwordTextBox" placeholder="Password" runat="server" TextMode="Password"></asp:TextBox><asp:Label ID="passwordAlartLabel" runat="server"></asp:Label>
                  </div>
                 <%-- <button type="submit" class="btn btn-black">Login</button>--%>
                   <asp:Button class="btn btn-black" ID="loginButton" runat="server" Text="Login" OnClick="loginButton_Click" />
                 <%-- <button type="submit" class="btn btn-secondary">Register</button>--%>
               </form>
            </div>
         </div>
      </div>
    </form>
</body>
</html>