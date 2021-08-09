<%@ Page Title="MEDICDATA | ADD USERS" Language="C#" MasterPageFile="~/site.master"
    AutoEventWireup="true" CodeFile="AddUser.aspx.cs" Inherits="AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hdProfilePic" runat="server" />
    <div class="form-padding">
        <h3 class="tittle-agileits mb-4">
            Add User</h3>
        <div class="form-row">
            <div class="form-group input-area col-md-4 offset-lg-1">
                <label>
                    *&nbsp;User ID</label>
                <asp:TextBox runat="server" ID="txtUserId" class="form-control txtUserId"></asp:TextBox>
            </div>
            <div class="form-group input-area col-md-4 offset-lg-1">
                <label>
                    *&nbsp;Password</label>
                <asp:TextBox runat="server" TextMode="Password" ID="txtPassword" class="form-control txtPassword"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group input-area col-md-4 offset-lg-1">
                <label>
                    *&nbsp;User Type</label>
                <asp:DropDownList runat="server" ID="ddlUserType" CssClass="form-control ddlUserType">
                </asp:DropDownList>
            </div>
            <div class="form-group input-area col-md-4 offset-lg-1">
                <label>
                    *&nbsp;Hospital</label>
                <asp:DropDownList runat="server" ID="ddlCompany" CssClass="form-control ddlCompany">
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group input-area col-md-4 offset-lg-1">
                <label>
                    *&nbsp;User Name</label>
                <asp:TextBox runat="server" ID="txtUserName" class="form-control txtUserName"></asp:TextBox>
            </div>
            <div class="form-group input-area col-md-4 offset-lg-1">
                <label>
                    *&nbsp;Date of Birth</label>
                <asp:TextBox runat="server" ID="txtDOB" class="form-control txtDOB"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group input-area col-md-4 offset-lg-1">
                <label>
                    *&nbsp;Gender</label>
                <asp:RadioButtonList runat="server" ID="rdGender" RepeatDirection="Horizontal" CssClass="radio-table rdGender">
                    <asp:ListItem Text="Male" Value="1" />
                    <asp:ListItem Text="Female" Value="2" />
                </asp:RadioButtonList>
            </div>
            <div class="form-group input-area col-md-4 offset-lg-1">
                <label>
                    Email Id</label>
                <asp:TextBox runat="server" ID="txtEmailId" class="form-control txtEmailId"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group input-area col-md-4 offset-lg-1">
                <label>
                    Contact</label>
                <asp:TextBox runat="server" ID="txtContact" class="form-control txtContact numeric"></asp:TextBox>
            </div>
            <div class="form-group input-area col-md-4 offset-lg-1">
                <label>
                    Address</label>
                <asp:TextBox runat="server" ID="txtAddress" TextMode="MultiLine" class="form-control txtAddress"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <%--<div class="form-group input-area col-md-4 offset-lg-1">
                <label>
                    State</label>
                <asp:DropDownList runat="server" ID="ddlState" class="form-control ddlState">
                </asp:DropDownList>
            </div>--%>
            <div class="form-group input-area col-md-4 offset-lg-1">
                <label>
                    City</label>
                <asp:TextBox runat="server" ID="txtCity" class="form-control txtCity"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group input-area col-md-4 offset-lg-1">
                <label>
                    Zip Code</label>
                <asp:TextBox runat="server" ID="txtZipCode" class="form-control txtZipCode"></asp:TextBox>
            </div>
            <div class="form-group input-area col-md-4 offset-lg-1">
                <label>
                    Profile Pic</label>
                <asp:FileUpload ID="fuProfile" runat="server" class="form-control fuProfile file-photos" />
                <%--<img src="images/addimage.png" id="flProfile" runat="server" title="User Profile Pic"
                    class="file-img-photos">--%>
                <asp:Image ID="flProfile" runat="server" CssClass="file-img-photos" ImageUrl="~/images/addimage.png"
                    ToolTip="Profile Picture" />
            </div>
        </div>
        <div class="form-row">
            <div class="col-md-1">
            </div>
            <div class="col-md-7">
                <asp:Label runat="server" ID="lblErrormsg" Visible="false" CssClass="error" Text="Field is mandotory"></asp:Label>
                <asp:Label runat="server" ID="lblSuccessmsg" Visible="false" CssClass="success" Text="Field is mandotory"></asp:Label>
            </div>
            <div class="form-group input-area col-md-2 text-right">
                <label style="width: 100%">
                    &nbsp;</label>
                <asp:LinkButton runat="server" ID="btnAdd" class="btn btn-primary btnSave" OnClick="btnAdd_Click">Save</asp:LinkButton>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript">
        $(".file-img-photos").click(function () {
            $(".file-photos").trigger('click');
        });
        $(".file-photos").change(function () {
            readURL(this, 'file-img-photos');
        });

        function readURL(input, fclass) {
            if (input.files && input.files[0]) {
                var reader = new FileReader();

                reader.onload = function (e) {
                    $('.' + fclass).attr('src', e.target.result);
                }

                reader.readAsDataURL(input.files[0]);
            }
        }

        $(".btnSave").click(function () {
            if ($(".txtUserId").val() == '') {
                $(".txtUserId").parent("div").children(".tooltip").remove();
                $(".txtUserId").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('txtUserId'));
                $(".txtUserId").focus();
                return false;
            }
            if ($(".txtPassword").val() == '') {
                $(".txtPassword").parent("div").children(".tooltip").remove();
                $(".txtPassword").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('txtPassword'));
                $(".txtPassword").focus();
                return false;
            }
            if ($(".ddlUserType").val() == '') {
                $(".ddlUserType").parent("div").children(".tooltip").remove();
                $(".ddlUserType").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('ddlUserType'));
                $(".ddlUserType").focus();
                return false;
            }
            if ($(".ddlCompany").val() == '' || $(".ddlCompany").val() == 0) {
                if ($(".ddlUserType").val() == '1') {
                    $(".ddlCompany").parent("div").children(".tooltip").remove();
                    $(".ddlCompany").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('ddlCompany'));
                    $(".ddlCompany").focus();
                    return false;
                }
            }
            if ($(".txtUserName").val() == '') {
                $(".txtUserName").parent("div").children(".tooltip").remove();
                $(".txtUserName").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('txtUserName'));
                $(".txtUserName").focus();
                return false;
            }
            if ($(".txtDOB").val() == '') {
                $(".txtDOB").parent("div").children(".tooltip").remove();
                $(".txtDOB").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('txtDOB'));
                $(".txtDOB").focus();
                return false;
            }
            else {
                if (!isDate($(".txtDOB").val())) {
                    $(".txtDOB").parent("div").children(".tooltip").remove();
                    $(".txtDOB").parent("div").append("<b class='tooltip tooltip-bottom-right'>Please Enter Valid Date Format : DD/MM/YYYY</b>", removetooltip('txtDOB'));
                    $(".txtDOB").focus();
                    return false;
                }
            }
            if ($(".txtEmailId").val() != '' && !validateEmail($(".txtEmailId").val())) {
                $(".txtEmailId").parent("div").children(".tooltip").remove();
                $(".txtEmailId").parent("div").append("<b class='tooltip tooltip-bottom-right'>Please Enter Valid Email</b>", removetooltip('txtEmailId'));
                $(".txtEmailId").focus();
                return false;
            }
            var checkedUserType = $(".rdGender input[type=radio]:checked");
            if (checkedUserType.length == 0) {
                $(".rdGender").parent("div").children(".tooltip").remove();
                $(".rdGender").parent("div").append("<b class='tooltip tooltip-bottom-right' style='opacity:1'>Required filed</b>", removetooltip('rdGender'));
                $(".rdGender").focus();
                return false;
            }
            if ($(".fuProfile").val() != "") {
                var ext = $('.fuProfile').val().split('.').pop().toLowerCase();
                if ($.inArray(ext, ['gif', 'png', 'jpg', 'jpeg']) == -1) {
                    $(".fuProfile").parent("div").children(".tooltip").remove();
                    $(".fuProfile").parent("div").append("<b class='tooltip tooltip-bottom-right' style='opacity:1'>Please select Valid file (gif, png, jpg, jpeg.)</b>", removetooltip('fuProfile'));
                    $(".fuProfile").focus();
                    return false;
                }
            }
        });

        /*$(".ddlUserType").change(function () {
        if ($(this).val() == "1") {
        $(".ddlCompany").val("0");
        $(".ddlCompany").attr("disabled", true);
        }
        else {
        $(".ddlCompany").attr("disabled", false);
        }
        });*/
    </script>
</asp:Content>
