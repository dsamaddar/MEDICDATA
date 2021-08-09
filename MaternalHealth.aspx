<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeFile="MaternalHealth.aspx.cs" Inherits="MaternalHealth" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .table-control
        {
            width: 100% !important;
        }
    </style>
    <asp:HiddenField ID="CompanyId" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="StateId" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="CreatedBy" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="HType" ClientIDMode="Static" runat="server" />

    <h5 class="tittle-agileits mb-4" id="PageTitle" runat="server">
        MATERNAL HEALTH SERVICES INFORMATION
    </h5>
    <div class="form-row">
        <div class="form-group input-area col-md-2">
            <asp:DropDownList ID="ddlYear" runat="server" CssClass="form-control search-control CYear">
            </asp:DropDownList>
        </div>
        <div class="form-group input-area col-md-2">
            <asp:DropDownList ID="ddlMonth" runat="server" CssClass="form-control search-control CMonth">
            </asp:DropDownList>
        </div>
        <div class="form-group col-md-2">
            <asp:LinkButton runat="server" ID="btnSearch" class="btn btn-primary" OnClick="btnSearch_Click"><i class="fa fa-search mr-1"></i>Search</asp:LinkButton>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel with-nav-tabs panel-primary">
                <div class="panel-heading">
                    <div class="row">
                        <div class="col-md-12">
                            <ul class="nav nav-tabs report-tab">
                                <li class="active"></li>
                            </ul>
                            <asp:HiddenField ID="hdActiveMenu" ClientIDMode="Static" Value="" runat="server" />
                            <div id="ABCDMenu" runat="server" visible="false">
                                <asp:LinkButton ID="PageA" Text="A" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageB" Text="B" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageC" Text="C" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageD" Text="D" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageE" Text="E" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageF" Text="F" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageG" Text="G" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageH" Text="H" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageI" Text="I" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageJ" Text="J" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageK" Text="K" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageL" Text="L" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageM" Text="M" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageN" Text="N" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageO" Text="O" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageP" Text="P" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageQ" Text="Q" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageR" Text="R" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageS" Text="S" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageT" Text="T" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageU" Text="U" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageV" Text="V" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageW" Text="W" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageX" Text="X" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageY" Text="Y" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                                <asp:LinkButton ID="PageZ" Text="Z" runat="server" CssClass="TopHeadingMenu" OnClick="PageA_Click" />
                            </div>
                        </div>
                        <%--<div class="col-md-6 text-right">
                            <a class="btn btn-primary btnrecordsave"><i class="far fa-save mr-1"></i>Save</a>
                        </div>--%>
                    </div>
                </div>
                <div class="panel-body table-body">
                    <div class="tab-content">
                        <div class="table-responsive">
                            <table class="table table-bordered table-striped entryform-table">
                                <tbody>
                                    <%--  <tr>
                                        <th>
                                            S/N
                                        </th>
                                        <th>
                                            PROCEDURES
                                        </th>
                                        <th colspan="2">
                                            0-12
                                        </th>
                                        <th colspan="2">
                                            13-59
                                        </th>
                                        <th colspan="2">
                                            60 & ABOVE
                                        </th>
                                        <th colspan="2">
                                            TOTAL
                                        </th>
                                    </tr>
                                    <tr>
                                        <th>
                                        </th>
                                        <th>
                                        </th>
                                        <th>
                                            M
                                        </th>
                                        <th>
                                            F
                                        </th>
                                        <th>
                                            M
                                        </th>
                                        <th>
                                            F
                                        </th>
                                        <th>
                                            M
                                        </th>
                                        <th>
                                            F
                                        </th>
                                        <th>
                                            M
                                        </th>
                                        <th>
                                            F
                                        </th>
                                    </tr>--%>
                                    <asp:Repeater runat="server" ID="RPTDentalProc">
                                        <ItemTemplate>
                                            <tr data-recid="<%# Eval("RecId") %>" class='<%# Eval("ServiceName").ToString() != "Total" ? "" : "d-none" %>'>
                                                <th class="heading" title="<%# Eval("RecId")%>">
                                                    <%# Eval("SortOrder")%>
                                                </th>
                                                <th class="heading" title="<%# Eval("ServiceName")%>">
                                                    <%# Eval("ServiceName")%>
                                                </th>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox1" runat="server" data-day="Result" value='<%# Eval("Result")%>'
                                                        class='<%# Convert.ToInt32(Eval("RecId")) < 52 ? "table-control numeric TOTCELL" : "table-control numeric" %>' />
                                                </td>
                                                <%--<th class="heading" title="<%# Eval("Result")%>">
                                                    <%# Eval("Result")%>
                                                </th>--%>
                                            </tr>
                                            <tr data-recid="<%# Eval("RecId") %>" class='<%# Eval("ServiceName").ToString() == "Total" ? "" : "d-none" %>'>
                                                <th class="heading" title="<%# Eval("RecId")%>">
                                                    <%# Eval("SortOrder")%>
                                                </th>
                                                <th class="heading" title="<%# Eval("ServiceName")%>">
                                                    <%# Eval("ServiceName")%>
                                                </th>
                                                <td class="table-total">
                                                    <%# Eval("Result")%>
                                                </td>
                                                <%--<th class="heading" title="<%# Eval("Result")%>">
                                                    <%# Eval("Result")%>
                                                </th>--%>
                                            </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $(".d-none").remove();
            //$(".entryform-table input").trigger('keyup');
        });

        $(".entryform-table input").keyup(function () {
            var sum = 0;

            //Rows Sum
            $(this).parents("table").find(".TOTCELL").each(function () {
                sum += Number($(this).val());
            });
            $(this).parents("table").find(".table-total").text(sum);
        });

        $(".entryform-table input").keydown(function () {
            var sum = 0;

            //Rows Sum
            $(this).parents("table").find(".TOTCELL").each(function () {
                sum += Number($(this).val());
            });
            $(this).parents("table").find(".table-total").text(sum);
        });

        $(".entryform-table input").keypress(function () {
            var sum = 0;

            //Rows Sum
            $(this).parents("table").find(".TOTCELL").each(function () {
                sum += Number($(this).val());
            });
            $(this).parents("table").find(".table-total").text(sum);
        });

        /*Save Data jquery*/
        $(".entryform-table input").focusout(function () {
            var RecId = $(this).parents("tr").attr("data-RecId");
            var ServiceId = 0;
            var CompanyId = $("#CompanyId").val();
            var StateId = $("#StateId").val();
            var CMonth = $(".CMonth").val();
            var CYear = $(".CYear").val();
            var CDay = $(this).attr("data-day");
            var CVal = Number($(this).val());
            var CreatedBy = $("#CreatedBy").val();
            var Htype = $("#HType").val();
            //console.log('{"RecId":' + RecId + ',"ServiceId":' + ServiceId + ',"CompanyId":' + CompanyId + ', "StateId": ' + StateId + ',"CMonth":' + CMonth + ',"CYear":' + CYear + ',"CDay":' + CDay + ',"CVal":' + CVal + ',"CreatedBy":' + CreatedBy + '}');
            $.ajax({
                type: "POST",
                url: "Handler.ashx/SaveMaternalHealthHandler",
                contentType: "application/json; charset=uft-8",
                data: '{"RecId":' + RecId + ',"ServiceId":' + ServiceId + ',"CompanyId":' + CompanyId + ', "StateId": ' + StateId + ',"CMonth":' + CMonth + ',"CYear":' + CYear + ',"CDay":"' + CDay + '","CVal":' + CVal + ',"CreatedBy":' + CreatedBy + ',"Htype":' + Htype + '}',
                beforeSend: function () {
                },
                success: function (response) {
                    //console.log(response);
                }
            });
        });
        
    </script>
</asp:Content>
