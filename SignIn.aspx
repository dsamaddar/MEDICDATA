<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignIn.aspx.cs" Inherits="SignIn" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MEDICDATA | LOGIN</title>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, minimal-ui, maximum-scale=1.0">
    <meta name="keywords" content="MEDICDATA, Medical Data, Software, Medical Software, Medical Data Software" />
    <meta name="description" content="Hospital Management,MEDICDATA, Medical Data, Software, Medical Software, Medical Data Software">
    <link rel="SHORTCUT ICON" href="images/favicon.ico">
    <link type="text/css" rel="stylesheet" href="css/weblogin.css">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Muli:200,200i,300,300i,400,400i,600,600i,700,700i,800,800i,900,900i">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Montserrat:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i">
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Quicksand:300,400,500,700">
</head>
<body>
    <form id="form1" runat="server">
    <table class="outertable">
        <tbody>
            <tr>
                <td align="center">
                    <div class="loginform">
                        <div class="logo-top">
                            <a href="Default.aspx">
                                <img src="images/logo.png" alt="Hospital Management">
                            </a>
                        </div>
                        <div class="title2">
                            Sign In to access Accounts
                        </div>
                        <div class="bdre2">
                        </div>
                        <div id="form-main">
                            <div class="label">
                                <asp:TextBox runat="server" ID="txtUserId" class="unauthinputText" TabIndex="1" placeholder="UserId"></asp:TextBox>
                            </div>
                            <div class="label">
                                <asp:TextBox runat="server" ID="txtPassword" TextMode="Password" TabIndex="2" class="unauthinputText"
                                    placeholder="Password"></asp:TextBox>
                            </div>
                            <div class="label">
                                <asp:Button runat="server" ID="btnLogin" class="redBtn" Text="Sign In" TabIndex="3"
                                    OnClick="btnLogin_Click" />
                            </div>
                            <div class="label">
                                <a href="ForgotPassword.aspx" style="text-decoration: none;" tabindex="4">Forgot Password?</a>
                            </div>
                            <asp:Label runat="server" ID="lblErrormsg" Visible="false" CssClass="error" Text="Field is mandotory"></asp:Label>
                            <div style="clear: both;">
                            </div>
                        </div>
                    </div>
                </td>
            </tr>
        </tbody>
    </table>
    </form>
</body>
</html>
