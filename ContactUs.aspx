<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ContactUs.aspx.cs" Inherits="ContactUs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>MEDICDATA | CONTACT US</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="keywords" content="MEDICDATA, Medical Data, Software, Medical Software, Medical Data Software" />
    <meta name="description" content="Hospital Management,MEDICDATA, Medical Data, Software, Medical Software, Medical Data Software">
    <link rel="SHORTCUT ICON" href="images/favicon.ico">
    <link type="text/css" rel="stylesheet" media="all" href="css/bootstrap.css" />
    <link type="text/css" rel="stylesheet" media="all" href="css/style.css" />
    <link type="text/css" rel="stylesheet" media="all" href="css/lending.css" />
    <link type="text/css" rel="stylesheet" href="css/style4.css">
    <link type="text/css" rel="stylesheet" href="css/fontawesome-all.css">
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i">
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Lato:100,100i,300,300i,400,400i,700,700i,900,900i">
    <%--<script src="https://www.google.com/recaptcha/api.js" async defer></script>--%>
     <script type="text/javascript" src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit"
        async defer></script>
    <script src="js/reCaptchaValidation.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="se-pre-con">
    </div>
    <nav class="navbar navbar-default">
        <div class="container-fluid">
            <div class="navbar-header">
                <button type="button" id="sidebarCollapse" class="btn btn-info navbar-btn">
                    <i class="fas fa-bars"></i>
                </button>
            </div>
            <div class="sidebar-header Headerheading">
                <h1>
                    <a href="Default.aspx" class="newLogo">
                        <img src="images/logo2.png" />
                    </a>
                </h1>
            </div>
            <div class="form-inline mx-auto search-form jamx_logo">
                <!-- site logo -->
            </div>
            <ul class="top-icons-agileits-w3layouts float-right">
                <li class="nav-item"><a class="nav-link navLinks" href="Default.aspx">Home </a></li>
                <li class="nav-item"><a class="nav-link navLinks req-button" href="#">Get Free Trial
                </a></li>
            </ul>
        </div>
    </nav>
    <div class="wrapper mt-1 py-4 home-slider">
        <div class="container">
            <div class="row">
                <div class="col-lg-7">
                    <div class="form-padding">
                        <h3 class="tittle-agileits mb-4">
                            REQUEST FOR FREE TRIAL</h3>
                        <div class="row">
                            <div class="col-lg-2 col-md-2">
                            </div>
                            <div class="col-lg-8 col-md-8 py-3">
                                <asp:Label ID="lblMsg" runat="server" Visible="false" CssClass="success" Text="Thanks For Request...! Our team will contact in 24 hrs."></asp:Label>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-2 col-md-2">
                            </div>
                            <div class="col-lg-8 col-md-8 py-2">
                                <label for="inputEmail4">
                                    *&nbsp;Name</label>
                                <asp:RequiredFieldValidator ID="ReqName" runat="server" ErrorMessage="*" ForeColor="Red"
                                    Display="Dynamic" ControlToValidate="txtName" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" ID="txtName" class="form-control txtName"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-2 col-md-2">
                            </div>
                            <div class="col-lg-8 col-md-8 py-3">
                                <label for="inputEmail4">
                                    *&nbsp;Email</label>
                                <asp:RequiredFieldValidator ID="ReqEmail" runat="server" ErrorMessage="*" ForeColor="Red"
                                    Display="Dynamic" ControlToValidate="txtEmail" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegEmail" runat="server" CssClass="float-right"
                                    ErrorMessage="Your Email Not Valid.!" ControlToValidate="txtEmail" Display="Dynamic"
                                    ForeColor="#FF3300" SetFocusOnError="True" ValidationGroup="A" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                <asp:TextBox runat="server" ID="txtEmail" class="form-control txtEmail"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-2 col-md-2">
                            </div>
                            <div class="col-lg-8 col-md-8 py-3">
                                <label for="inputEmail4">
                                    Phone</label>
                                <asp:RequiredFieldValidator ID="ReqPhone" runat="server" ErrorMessage="*" ForeColor="Red"
                                    Display="Dynamic" ControlToValidate="txtphone" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:TextBox runat="server" ID="txtphone" class="form-control numeric"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-2 col-md-2">
                            </div>
                            <div class="col-lg-8 col-md-8 py-3">
                                <label for="inputEmail4">
                                    *&nbsp;Message</label>
                                <asp:RequiredFieldValidator ID="ReqMsg" runat="server" ForeColor="Red" Display="Dynamic"
                                    ErrorMessage="*" ControlToValidate="txtMsg" ValidationGroup="A"></asp:RequiredFieldValidator>
                                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtMsg" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            
                            <div class="col-lg-2 col-md-2">
                            </div>
                            <div class="col-lg-8 col-md-8 py-3">
                            <div id="dvCaptcha" style="margin-bottom: 5px;" >
                            </div>
                            <asp:TextBox ID="txtCaptcha" runat="server" Style="display: none" />
                            <asp:RequiredFieldValidator ID="rfvCaptcha" ErrorMessage="Captcha validation is required."
                                ControlToValidate="txtCaptcha" runat="server" ForeColor="Red" Display="Dynamic" ValidationGroup="A" />
                            <br />
                           
                                <asp:Button ID="btnContact" CssClass="btn btn-primary" runat="server" Text="REQUEST"
                                    OnClick="btnContact_Click" ValidationGroup="A" />
                            </div>
                        </div>
                    </div>
                </div>
                <%--  <div class="col-lg-1">
                </div>--%>
                <div class="col-lg-5">
                    <div class="bootstrap-sliders">
                        <div id="carouselExampleControls" class="carousel slide" data-ride="carousel">
                            <div class="carousel-inner">
                                <div class="carousel-item active">
                                    <img class="d-block w-100" src="images/login.png" alt="First slide" />
                                </div>
                                <div class="carousel-item">
                                    <img class="d-block w-100" src="images/casedetails.png" alt="Second slide" />
                                </div>
                                <div class="carousel-item">
                                    <img class="d-block w-100" src="images/summary.png" alt="Third slide" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="wrapper home-contact">
        <div class="container">
            <section class="py-4">
                <div class="grid-base grid-base--borders grid-base--three-column">
                    <div class="grid-base__item">
                        <div class="callout-item">
                            <a class="callout-item__icon" href="#">
                                <img src="images/call.png" alt="">
                            </a>
                            <h3 class="callout-item__headline">
                                Talk to a specialist
                            </h3>
                            <p class="callout-item__text">
                                Speak directly to one of our sales<br>
                                representatives by calling.
                            </p>
                            <a class="button button--dark" href="javascript:void(0)">+234 812 301 3735</a>
                        </div>
                    </div>
                    <div class="grid-base__item">
                        <div class="callout-item">
                            <a href="#" class="callout-item__icon">
                                <img src="images/msg.png" alt="">
                            </a>
                            <h3 class="callout-item__headline">
                                Contact Us
                            </h3>
                            <p class="callout-item__text">
                                Got questions? Want to see a live demo?<br>
                                We'll be in touch within 24 hours.
                            </p>
                            <a class="button button--dark" href="javascript:void(0)">+234 812 301 3735</a>
                        </div>
                    </div>
                    <div class="grid-base__item">
                        <div class="callout-item">
                            <a href="#" class="callout-item__icon" target="_blank">
                                <img src="images/info.png" alt="">
                            </a>
                            <h3 class="callout-item__headline">
                                Support
                            </h3>
                            <p class="callout-item__text">
                                Check out our help centre for answers to common questions.
                            </p>
                            <a class="button button--dark" rel="noopener noreferrer" href="javascript:void(0)">+234
                                812 301 3735</a>
                        </div>
                    </div>
                </div>
            </section>
        </div>
    </div>
    <div class="copyright-w3layouts py-xl-3 py-2 text-center">
        <!--p>© 2019 MEDICDATA | Develop by
            <a href="http://omtechsoft.com/" target="_blank"> OmTechsoft </a>
        </p-->
    </div>
    <!-- Required common Js -->
    <script type="text/javascript" src='js/jquery-2.2.3.min.js'></script>
    <script type="text/javascript" src='js/jquery.min.js'></script>
    <script type="text/javascript" src="js/bootstrap.min.js"></script>
    <script type="text/javascript">
        $(window).load(function () {
            $(".se-pre-con").fadeOut("slow"); ;
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#sidebarCollapse').on('click', function () {
                $('#sidebar').toggleClass('active');
            });
        });
    </script>
    <!-- dropdown nav -->
    <script type="text/javascript">
        $(document).ready(function () {
            $(".dropdown").hover(
                function () {
                    $('.dropdown-menu', this).stop(true, true).slideDown("fast");
                    $(this).toggleClass('open');
                },
                function () {
                    $('.dropdown-menu', this).stop(true, true).slideUp("fast");
                    $(this).toggleClass('open');
                }
                );
        });
    </script>
    <script type="text/javascript">
        //Number Only
        $(".numeric").keydown(function (e) {
            if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110]) !== -1 ||
		(e.keyCode === 65 && (e.ctrlKey === true || e.metaKey === true)) ||
		(e.keyCode >= 35 && e.keyCode <= 40)) {
                return;
            }
            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                e.preventDefault();
            }
        });
    </script>
    </form>
</body>
</html>
