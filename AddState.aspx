<%@ Page Title="MEDICDATA | ADD STATE" Language="C#" MasterPageFile="~/site.master"
    AutoEventWireup="true" CodeFile="AddState.aspx.cs" Inherits="AddUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="hdProfilePic" runat="server" />
    <div class="form-padding">
        <h3 class="tittle-agileits mb-4">
            Add State</h3>
        <div class="form-row">
            <div class="form-group input-area col-md-4 offset-lg-4">
                <label>
                    *&nbsp;State Name</label>
                <asp:TextBox runat="server" ID="txtStateName" class="form-control txtStateName"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group input-area col-md-4 offset-lg-4">
                <label>
                    Description</label>
                <asp:TextBox runat="server" ID="txtDescription" TextMode="MultiLine" class="form-control"></asp:TextBox>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group input-area col-md-4 offset-lg-4">
                <asp:LinkButton runat="server" ID="btnAdd" class="btn btn-primary btnSave" OnClick="btnAdd_Click">Save</asp:LinkButton>
            </div>
        </div>
        <div class="form-row">
            <div class="form-group input-area col-md-4 offset-lg-4">
                <asp:Label runat="server" ID="lblErrormsg" Visible="false" CssClass="error" Text="Field is mandotory"></asp:Label>
                <asp:Label runat="server" ID="lblSuccessmsg" Visible="false" CssClass="success" Text="Field is mandotory"></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript">

        $(".btnSave").click(function () {
            if ($(".txtStateName").val() == '') {
                $(".txtStateName").parent("div").children(".tooltip").remove();
                $(".txtStateName").parent("div").append("<b class='tooltip tooltip-bottom-right'>Required filed</b>", removetooltip('txtStateName'));
                $(".txtStateName").focus();
                return false;
            }
        });
    </script>
</asp:Content>
