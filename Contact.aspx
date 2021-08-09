<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeFile="Contact.aspx.cs" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="https://www.google.com/recaptcha/api.js?onload=onloadCallback&render=explicit"
        async defer></script>
    <script src="js/reCaptchaValidation1.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-padding">
        <h3 class="tittle-agileits mb-4">
            Contact Us</h3>
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
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ErrorMessage="*" ForeColor="Red"
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
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ErrorMessage="*" ForeColor="Red"
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
                <asp:RequiredFieldValidator ID="rfvphone" runat="server" ErrorMessage="*" ForeColor="Red"
                    Display="Dynamic" ControlToValidate="txtphone" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:TextBox runat="server" ID="txtphone" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2 col-md-2">
            </div>
            <div class="col-lg-8 col-md-8 py-3">
                <label for="inputEmail4">
                    *&nbsp;Message</label>
                <asp:RequiredFieldValidator ID="rfvMsg" runat="server" ErrorMessage="*" ForeColor="Red"
                    Display="Dynamic" ControlToValidate="txtMsg" ValidationGroup="A"></asp:RequiredFieldValidator>
                <asp:TextBox TextMode="MultiLine" runat="server" ID="txtMsg" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2 col-md-2">
            </div>
            <div class="col-lg-8 col-md-8 py-3">
                <div id="dvCaptcha" style="margin-bottom: 5px;">
                </div>
                <asp:TextBox ID="txtCaptcha" runat="server" Style="display: none" />
                <asp:RequiredFieldValidator ID="rfvCaptcha" ErrorMessage="Captcha validation is required."
                    ControlToValidate="txtCaptcha" runat="server" ForeColor="Red" Display="Dynamic"
                    ValidationGroup="A" />
                <br />
                <asp:Button ID="btnContact" CssClass="btn btn-primary" runat="server" Text="Submit"
                    ValidationGroup="A" OnClick="btnContact_Click" />
            </div>
        </div>
        <div class="row">
            <div class="col-lg-2 col-md-2">
            </div>
            <div class="col-lg-8 col-md-8 py-3">
                <asp:Label runat="server" ID="lblErrormsg" Visible="false" CssClass="error" Text="Field is mandotory"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
