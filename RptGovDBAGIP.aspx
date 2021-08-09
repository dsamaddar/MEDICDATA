<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeFile="RptGovDBAGIP.aspx.cs" Inherits="RptGovDBAGIP" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="form-row">
        <div class="form-group input-area col-md-2">
            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control search-control ddlYear">
            </asp:DropDownList>
        </div>
        <div class="form-group input-area col-md-2">
            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control search-control ddlMonth">
            </asp:DropDownList>
        </div>
        <div class="form-group col-md-1" style="padding-top: 8px; text-align: center;">
            <asp:CheckBox ID="chkDateMode" runat="server" CssClass="datemode" Text="" />
        </div>
        <div class="form-group input-area col-md-2">
            <asp:TextBox ID="txtFromDate" runat="server" class="form-control search-control datepicker FromDate"
                autocomplete="off" placeholder="From Date"></asp:TextBox>
        </div>
        <div class="form-group input-area col-md-2">
            <asp:TextBox ID="txtToDate" runat="server" class="form-control search-control datepicker ToDate"
                autocomplete="off" placeholder="To Date"></asp:TextBox>
        </div>
    </div>
    <div class="form-row">
        <div class="form-group input-area col-md-2">
            <asp:DropDownList ID="ddlCompany" runat="server" CssClass="form-control search-control">
            </asp:DropDownList>
        </div>
        <div class="form-group input-area col-md-2">
            <asp:TextBox runat="server" ID="txtRefNo" placeholder="Ref.No" CssClass="form-control search-control" />
        </div>
        <div class="form-group input-area col-md-3">
        </div>
        <div class="form-group col-md-2">
            <asp:CheckBox ID="chkchart" runat="server" Text="&nbsp;&nbsp;Chart" Style="padding-top: 8px;" />
            <asp:LinkButton runat="server" ID="btnSearch" class="btn btn-primary pull-right"
                OnClick="btnSearch_Click"><i class="fa fa-search mr-1"></i>Search</asp:LinkButton>
        </div>
    </div>
    <div class="row mt-4">
        <div class="col-lg-12">
            <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" Font-Size="8pt"
                InteractiveDeviceInfos="(Collection)" WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt"
                Height="700px" Width="100%" CssClass="Report">
                <LocalReport ReportPath="Reports\RptGovDBAGIP.rdlc">
                </LocalReport>
            </rsweb:ReportViewer>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            if ($(".datemode input[type=checkbox]").prop("checked")) {
                $(".FromDate").removeAttr("disabled");
                $(".ToDate").removeAttr("disabled");
                $(".ddlYear").attr("disabled", "disabled");
                $(".ddlMonth").attr("disabled", "disabled");
            }
            else {
                $(".FromDate").attr("disabled", "disabled");
                $(".ToDate").attr("disabled", "disabled");
                $(".ddlYear").removeAttr("disabled");
                $(".ddlMonth").removeAttr("disabled");
            }
            $(".datemode input[type=checkbox]").click(function () {
                if ($(this).prop("checked")) {
                    $(".FromDate").removeAttr("disabled");
                    $(".ToDate").removeAttr("disabled");
                    $(".ddlYear").attr("disabled", "disabled");
                    $(".ddlMonth").attr("disabled", "disabled");
                }
                else {
                    $(".FromDate").attr("disabled", "disabled");
                    $(".ToDate").attr("disabled", "disabled");
                    $(".ddlYear").removeAttr("disabled");
                    $(".ddlMonth").removeAttr("disabled");
                }
            });
        });
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#ContentPlaceHolder1_btnSearch").click(function () {
                if ($(".datemode input[type=checkbox]").prop("checked")) {
                    if ($(".FromDate").val() == "") {
                        $(".FromDate").parent("div").children(".tooltip").remove();
                        $(".FromDate").parent("div").append("<b class='tooltip tooltip-bottom-right' style='opacity: 1;'>Required filed</b>", removetooltip('FromDate'));
                        return false;
                    }
                    if (!isDate($(".FromDate").val())) {
                        $(".FromDate").parent("div").children(".tooltip").remove();
                        $(".FromDate").parent("div").append("<b class='tooltip tooltip-bottom-right' style='opacity: 1;'>Please Enter Valid Date Format : DD/MM/YY</b>", removetooltip('FromDate'));
                        return false;
                    }
                    if ($(".ToDate").val() == "") {
                        $(".ToDate").parent("div").children(".tooltip").remove();
                        $(".ToDate").parent("div").append("<b class='tooltip tooltip-bottom-right' style='opacity: 1;'>Required filed</b>", removetooltip('ToDate'));
                        return false;
                    }
                    if (!isDate($(".ToDate").val())) {
                        $(".ToDate").parent("div").children(".tooltip").remove();
                        $(".ToDate").parent("div").append("<b class='tooltip tooltip-bottom-right' style='opacity: 1;'>Please Enter Valid Date Format : DD/MM/YY</b>", removetooltip('ToDate'));
                        return false;
                    }
                }
            });
        });
    </script>
</asp:Content>
