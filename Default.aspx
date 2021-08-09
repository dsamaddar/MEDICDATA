<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>MEDICDATA | HOME</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="keywords" content="MEDICDATA, Medical Data, Software, Medical Software, Medical Data Software" />
    <meta name="description" content="Hospital Management,MEDICDATA, Medical Data, Software, Medical Software, Medical Data Software">
    <link rel="SHORTCUT ICON" href="images/favicon.ico">
    <link type="text/css" rel="stylesheet" media="all" href="css/bootstrap.css" />
    <link type="text/css" rel="stylesheet" media="all" href="css/style.css" />
    <link type="text/css" rel="stylesheet" media="all" href="css/lending.css" />
    <link type="text/css" rel="stylesheet" href="css/fontawesome-all.css">
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Poppins:100,100i,200,200i,300,300i,400,400i,500,500i,600,600i,700,700i,800,800i,900,900i">
    <link rel="stylesheet" href="http://fonts.googleapis.com/css?family=Lato:100,100i,300,300i,400,400i,700,700i,900,900i">
</head>
<body style="background: transparent;">
    <form id="form1" runat="server">
    <div class="se-pre-con">
    </div>
    <div class="MainBackImg">
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
                    <li class="nav-item"><a class="nav-link navLinks" href="SignIn.aspx">Login </a></li>
                    <li class="nav-item"><a class="nav-link navLinks req-button" href="ContactUs.aspx">Get
                        Free Trial </a></li>
                </ul>
            </div>
        </nav>
        <div class="Infoarea">
            <div class="container" style="height: 100%;">
                <div class="InfoAbout">
                    <p>
                        Medicdata platform is a state of the art unified data management platform that transforms
                        health statistical data reporting for hospitals and health centres. Just do data
                        entry once and our platform populates and auto generates all the monthly, quarterly
                        and yearly statistical reports.
                    </p>
                    <a class="mt-2 req-button btn btn-primary" style="float: left;" href="ContactUs.aspx">
                        Get Free Trial</a>
                </div>
            </div>
        </div>
    </div>
    <div class="wrapper home-slider">
        <div class="container">
            <div class="row">
                <div class="col-lg-7">
                    <div class="about-area">
                        <div class="about-content">
                            <h2>
                                About Us</h2>
                            <p class="about-text">
                                Medicdata platform is a state of the art unified data management platform that transforms
                                health statistical data reporting for hospitals and health centres. Do data entry
                                once and our platform populates and auto generates all the monthly, quarterly and
                                yearly statistical reports. Get rid of excel sheets, store and secure your data
                                on a unified platform. Speed up data capture, data collation, data aggregation and
                                auto-reporting using our smart set of analytics tools.
                            </p>
                            <p class="about-text">
                                Data in general creates a domino effect. Clinical data is no different. When a patients
                                visit the department of emergency care for treatment and receives an outpatient
                                procedure and then had to stay in the hospital for a while and contribute to the
                                hospital bed complement data, the clinical insights generated from each stage of
                                the patient's care becomes a vital key to helping the hospital to improve care.
                                Our advanced analytics tool has the power to generate operational and clinical data
                                that hospitals can use to isolate common patterns in patient care so that they can
                                intervene sooner if need be while streamlining cost and most importantly improving
                                patient care.
                            </p>
                        </div>
                        <asp:Label runat="server" ID="lblErrormsg" Visible="false" CssClass="error" Text="Field is mandotory"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-1">
                </div>
                <div class="col-lg-4" style="margin: auto;">
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
    </form>
</body>
</html>
