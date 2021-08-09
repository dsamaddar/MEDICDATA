<%@ Page Title="MEDICDATA | HOSPITAL INFO" Language="C#" MasterPageFile="~/site.master"
    AutoEventWireup="true" CodeFile="AddHospital.aspx.cs" Inherits="HospitalInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-padding">
        <h3 class="tittle-agileits mb-4">
            Hospital Info</h3>
        <div class="form-row">
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-4">
                <label for="inputEmail4">
                    *&nbsp;Hospital</label>
                <asp:TextBox runat="server" ID="txtHospital" class="form-control txtHospital"></asp:TextBox>
            </div>
            <div class="col-md-1">
            </div>
            <div class="form-group col-md-4">
                <label for="inputEmail4">
                    Email</label>
                <asp:TextBox runat="server" ID="txtEmail" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-4">
                <label for="inputAddress">
                    *&nbsp;State</label>
                <asp:DropDownList runat="server" ID="ddlState" class="form-control ddlState">
                </asp:DropDownList>
            </div>
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-4">
                <label for="inputAddress">
                    *&nbsp;City</label>
                <asp:TextBox runat="server" ID="txtCity" class="form-control txtCity"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-1">
            </div>
            <div class="form-group col-md-4">
                <label for="inputAddress">
                    Contact</label>
                <asp:TextBox runat="server" ID="txtContact" class="form-control"></asp:TextBox>
            </div>
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-3">
                <label for="inputAddress">
                    Logo</label>
                <asp:FileUpload ID="fuLogo" runat="server" CssClass="form-control fuLogo" />
            </div>
            <div class="form-group col-md-1" id="LogoArea" runat="server">
                <label for="inputAddress">
                    Logo</label>
                <asp:Image ImageUrl="" ID="DisplayLogo" runat="server" CssClass="" Style="width: 100%;" />
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-4">
                <label for="inputAddress">
                    Report Title 1</label>
                <asp:TextBox runat="server" ID="txtReportTitle1" class="form-control txtReportTitle1"></asp:TextBox>
            </div>
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-4">
                <label for="inputAddress">
                    Report Title 2</label>
                <asp:TextBox runat="server" ID="txtReportTitle2" class="form-control txtReportTitle2"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-4">
                <label for="inputAddress">
                    Report Title 3</label>
                <asp:TextBox runat="server" ID="txtReportTitle3" class="form-control txtReportTitle3"></asp:TextBox>
            </div>
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-4">
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-1">
            </div>
            <div class="col-md-7">
                <asp:Label runat="server" ID="lblErrormsg" Visible="false" CssClass="error" Text="Field is mandotory"></asp:Label>
                <asp:Label runat="server" ID="lblSuccessmsg" Visible="false" CssClass="success" Text="Field is mandotory"></asp:Label>
            </div>
            <div class="col-md-2 text-right">
                <asp:LinkButton runat="server" ID="btnUpdateHospitalInfo" class="btn btn-primary btnSave"
                    OnClick="btnUpdateHospitalInfo_Click">Save</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript">
        $(".btnSave").click(function () {
            if ($(".txtHospital").val() == '') {
                $(".txtHospital").parent("div").children(".tooltip").remove();
                $(".txtHospital").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('txtHospital'));
                $(".txtHospital").focus();
                return false;
            }
            if ($(".ddlState option:selected").index() == 0) {
                $(".ddlState").parent("div").children(".tooltip").remove();
                $(".ddlState").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('ddlState'));
                $(".ddlState").focus();
                return false;
            }
            if ($(".txtCity").val() == '') {
                $(".txtCity").parent("div").children(".tooltip").remove();
                $(".txtCity").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('txtCity'));
                $(".txtCity").focus();
                return false;
            }
            /*var ext = $('.fuLogo').val().split('.').pop().toLowerCase();
            if ($.inArray(ext, ['gif', 'png', 'jpg', 'jpeg']) == -1) {
            $(".fuLogo").parent("div").children(".tooltip").remove();
            $(".fuLogo").parent("div").append("<b class='tooltip tooltip-bottom-right' style='opacity:1;'>Required filed</b>", removetooltip('fuLogo'));
            $(".fuLogo").focus();
            return false;
            }*/
        });
    </script>
</asp:Content>
