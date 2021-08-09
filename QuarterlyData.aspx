<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeFile="QuarterlyData.aspx.cs" Inherits="MonthlyData" %>
    <%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="form-row">
        <div class="form-group input-area col-md-2">
            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control search-control">
            </asp:DropDownList>
        </div>
        <div class="form-group input-area col-md-2">
            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control search-control">
            </asp:DropDownList>
        </div>
        <div class="form-group input-area col-md-2">
            <asp:DropDownList ID="ddlCompany" runat="server" CssClass="form-control search-control">
            </asp:DropDownList>
        </div>
        <div class="form-group input-area col-md-2">
            <asp:TextBox runat="server" ID="txtRefNo" placeholder="Ref.No" CssClass="form-control search-control" />
        </div>
        <div class="form-group col-md-2">
            <asp:LinkButton runat="server" ID="btnSearch" class="btn btn-primary" OnClick="btnSearch_Click1"><i class="fa fa-search mr-1"></i>Search</asp:LinkButton>
        </div>
    </div>
    <div class="row mt-4">
        <div class="col-lg-12">
            <rsweb:reportviewer id="ReportViewer1" runat="server" font-names="Verdana" font-size="8pt"
                interactivedeviceinfos="(Collection)" waitmessagefont-names="Verdana" waitmessagefont-size="14pt"
                height="700px" width="1000px" cssclass="Report">
                         <LocalReport ReportPath="Reports\QuarterlyData.rdlc">
                </LocalReport>       
            </rsweb:reportviewer>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
