<%@ Page Title="MEDICDATA | USER PERMISSION" Language="C#" MasterPageFile="~/site.master"
    AutoEventWireup="true" CodeFile="UserPermission.aspx.cs" Inherits="UserPermission" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .menubox
        {
            border: 1px solid white;
            padding: 1px;
            margin-bottom: 5px;
            margin-right: 5px;
        }
        .menulabel
        {
            color: #fff;
            padding: 5px 0;
            font-size: 10px;
            margin-left: 5px;
        }
        .menulabel > input
        {
            margin-right: 5px;
        }
        span > label
        {
            overflow: overlay;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="form-padding">
        <h3 class="tittle-agileits mb-4">
            User Permission</h3>
        <div class="form-row">
            <div class="form-group input-area col-md-4">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <asp:DropDownList ID="ddlUserType" runat="server" CssClass="form-control ddlUserType"
                            AutoPostBack="true" ToolTip="User Type" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                        </asp:DropDownList>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
        <div class="form-row">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" style="width: 100%;">
                <ContentTemplate>
                    <asp:DataList ID="dlMenuList" runat="server" Width="100%" RepeatColumns="2" RepeatLayout="Table">
                        <ItemTemplate>
                            <div class="menubox">
                                <asp:CheckBox ID="chkMenu" runat="server" CssClass="menulabel" AutoPostBack="true"
                                    Text='<%# Eval("MenuName") %>' Checked='<%# Convert.ToBoolean(Eval("PMIsActive")) %>'
                                    ToolTip='<%# Eval("PMRecId") + "," + Eval("MenuId") %>' OnCheckedChanged="chkMenu_CheckedChanged" />
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript">
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_endRequest(function () {
            $(".menulabel").change(function () {
                $('.se-pre-con').show();
            });
        });
    </script>
</asp:Content>
