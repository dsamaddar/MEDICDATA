<%@ Page Title="MEDICDATA | HOSPITAL INFO" Language="C#" MasterPageFile="~/site.master"
    AutoEventWireup="true" CodeFile="DeathsEntry.aspx.cs" Inherits="HospitalInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-padding">
        <h3 class="tittle-agileits mb-4" id="PageTitle" runat="server">
        </h3>
        <div class="form-row">
            <asp:HiddenField ID="HType" Value="" runat="server" />
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-4">
                <label for="inputEmail4">
                    *&nbsp;Name of the Deceased</label>
                <asp:TextBox runat="server" ID="txtDeceased" class="form-control txtDeceased"></asp:TextBox>
            </div>
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-4">
                <label for="inputEmail4">
                    *&nbsp;Sex</label>
                <asp:RadioButtonList runat="server" ID="rdGender" RepeatDirection="Horizontal" CssClass="radio-table rdGender"
                    Style="border: 1px solid transparent">
                    <asp:ListItem Text="Male" Value="1" />
                    <asp:ListItem Text="Female" Value="2" />
                </asp:RadioButtonList>
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-4">
                <label for="inputAddress">
                    *&nbsp;Age</label>
                <asp:TextBox runat="server" ID="txtAge" class="form-control txtAge numeric"></asp:TextBox>
            </div>
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-4">
                <label for="inputAddress">
                    *&nbsp;Reg. No.</label>
                <asp:TextBox runat="server" ID="txtRefNo" class="form-control txtRefNo"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-4">
                <label for="inputAddress">
                    *&nbsp;Address</label>
                <asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" class="form-control txtAddress"></asp:TextBox>
            </div>
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-4">
                <label for="inputAddress">
                    *&nbsp;Date Of Admission</label>
                <asp:TextBox runat="server" ID="txtAdmiddion" class="form-control datepicker txtAdmiddion"
                    placeholder="DD/MM/YY" autocomplete="off"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-1">
            </div>
            <div class="form-group input-area input-area col-md-4">
                <label for="inputAddress">
                    *&nbsp;Date of Death</label>
                <asp:TextBox runat="server" ID="txtDateofDeath" class="form-control datepicker txtDateofDeath"
                    placeholder="DD/MM/YY" autocomplete="off"></asp:TextBox>
            </div>
            <div class="col-md-1">
            </div>
            <div class="form-group input-area col-md-4">
                <label for="inputAddress">
                    Causes(s) of Death</label>
                <%--<asp:DropDownList runat="server" ID="ddlCausesDeath" CssClass="form-control ddlCausesDeath">
                </asp:DropDownList>--%>
                <asp:TextBox ID="txtcases" runat="server" class="form-control" MaxLength="500"></asp:TextBox>
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
                <asp:LinkButton runat="server" ID="btnUpdateDeaths" OnClick="btnUpdatebtnUpdateDeaths_Click"
                    class="btn btn-primary btnSave">Save</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript">
        $(".btnSave").click(function () {
            if ($(".txtDeceased").val() == '') {
                $(".txtDeceased").parent("div").children(".tooltip").remove();
                $(".txtDeceased").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('txtDeceased'));
                $(".txtDeceased").focus();
                return false;
            }
            var checkedUserType = $(".rdGender input[type=radio]:checked");
            if (checkedUserType.length == 0) {
                $(".rdGender").parent("div").children(".tooltip").remove();
                $(".rdGender").parent("div").append("<b class='tooltip tooltip-bottom-right' style='opacity:1;right:50%'>Required filed</b>", removetooltip('rdGender'));
                $(".rdGender").addClass("red-border");
                setTimeout(function () { $(".rdGender").removeClass("red-border"); }, 5000)
                return false;
            }
            if ($(".txtAge").val() == '') {
                $(".txtAge").parent("div").children(".tooltip").remove();
                $(".txtAge").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('txtAge'));
                $(".txtAge").focus();
                return false;
            }
            if ($(".txtRefNo").val() == '') {
                $(".txtRefNo").parent("div").children(".tooltip").remove();
                $(".txtRefNo").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('txtRefNo'));
                $(".txtRefNo").focus();
                return false;
            }
            if ($(".txtAddress").val() == '') {
                $(".txtAddress").parent("div").children(".tooltip").remove();
                $(".txtAddress").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('txtAddress'));
                $(".txtAddress").focus();
                return false;
            }
            if ($(".txtAdmiddion").val() == '') {
                $(".txtAdmiddion").parent("div").children(".tooltip").remove();
                $(".txtAdmiddion").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('txtAdmiddion'));
                $(".txtAdmiddion").focus();
                return false;
            }
            if (!isDate($(".txtAdmiddion").val())) {
                $(".txtAdmiddion").parent("div").children(".tooltip").remove();
                $(".txtAdmiddion").parent("div").append("<b class='tooltip tooltip-bottom-right'>Please Enter Valid Date Format : DD/MM/YY</b>", removetooltip('txtAdmiddion'));
                $(".txtAdmiddion").focus();
                return false;
            }
            if ($(".txtDateofDeath").val() == '') {
                $(".txtDateofDeath").parent("div").children(".tooltip").remove();
                $(".txtDateofDeath").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('txtDateofDeath'));
                $(".txtDateofDeath").focus();
                return false;
            }
            if (!isDate($(".txtDateofDeath").val())) {
                $(".txtDateofDeath").parent("div").children(".tooltip").remove();
                $(".txtDateofDeath").parent("div").append("<b class='tooltip tooltip-bottom-right'>Please Enter Valid Date Format : DD/MM/YY</b>", removetooltip('txtDateofDeath'));
                $(".txtDateofDeath").focus();
                return false;
            }
            if ($(".ddlCausesDeath").val() == '') {
                $(".ddlCausesDeath").parent("div").children(".tooltip").remove();
                $(".ddlCausesDeath").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('ddlCausesDeath'));
                $(".ddlCausesDeath").focus();
                return false;
            }
        });
    </script>
</asp:Content>
