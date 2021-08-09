<%@ Page Title="" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeFile="DentalProcedures.aspx.cs" Inherits="DentalProcedures" %>

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
        DENTAL PROCEDURE
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
                <div class="panel-body table-body">
                    <div class="tab-content">
                        <div class="table-responsive">
                            <table class="table table-bordered table-striped entryform-table">
                                <tbody>
                                    <tr>
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
                                    </tr>
                                    <asp:Repeater runat="server" ID="RPTDentalProc">
                                        <ItemTemplate>
                                            <tr data-recid="<%# Eval("RecId") %>" class='<%# Eval("ServiceName").ToString() != "TOTAL" ? "" : "d-none" %>'>
                                                <th class="heading" title="<%# Eval("RecId")%>">
                                                    <%# Eval("RecId")%>
                                                </th>
                                                <th class="heading" title="<%# Eval("ServiceName")%>">
                                                    <%# Eval("ServiceName")%>
                                                </th>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox1" runat="server" data-day="M012" value='<%# Eval("M012")%>'
                                                        class='<%# "table-control numeric Cols1 MRows"+  Eval("RecId") %>' data-rowclass='<%# "MRows" + Eval("RecId")%>'
                                                        data-colclass='1' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox2" runat="server" data-day="F012" value='<%# Eval("F012")%>'
                                                        class='<%# "table-control numeric Cols2 FRows"+  Eval("RecId") %>' data-rowclass='<%# "FRows" + Eval("RecId")%>'
                                                        data-colclass='2' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox3" runat="server" data-day="M1359" value='<%# Eval("M1359")%>'
                                                        class='<%# "table-control numeric Cols3 MRows"+  Eval("RecId") %>' data-rowclass='<%# "MRows" + Eval("RecId")%>'
                                                        data-colclass='3' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox4" runat="server" data-day="F1359" value='<%# Eval("F1359")%>'
                                                        class='<%# "table-control numeric Cols4 FRows"+  Eval("RecId") %>' data-rowclass='<%# "FRows" + Eval("RecId")%>'
                                                        data-colclass='4' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox5" runat="server" data-day="M60" value='<%# Eval("M60")%>'
                                                        class='<%# "table-control numeric Cols5 MRows"+  Eval("RecId") %>' data-rowclass='<%# "MRows" + Eval("RecId")%>'
                                                        data-colclass='5' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox6" runat="server" data-day="F60" value='<%# Eval("F60")%>'
                                                        class='<%# "table-control numeric Cols6 FRows"+  Eval("RecId") %>' data-rowclass='<%# "FRows" + Eval("RecId")%>'
                                                        data-colclass='6' />
                                                </td>
                                                <td class="<%# "table-total TOTMRows" + Eval("RecId")%>" style="width: 70px;">
                                                    <%# Eval("Mtot")%>
                                                </td>
                                                <td class="<%# "table-total TOTFRows" + Eval("RecId")%>" style="width: 70px;">
                                                    <%# Eval("Ftot")%>
                                                </td>
                                            </tr>
                                            <tr class='<%# Eval("ServiceName").ToString() == "TOTAL" ? "" : "d-none" %>'>
                                                <th class="heading" title="<%# Eval("ServiceName")%>">
                                                    <%# Eval("RecId")%>
                                                </th>
                                                <th class="heading" title="<%# Eval("ServiceName")%>">
                                                    <%# Eval("ServiceName")%>
                                                </th>
                                                <td class="table-total MTOTCELL ColsTotal1">
                                                    <%# Eval("M012")%>
                                                </td>
                                                <td class="table-total FTOTCELL ColsTotal2">
                                                    <%# Eval("F012")%>
                                                </td>
                                                <td class="table-total MTOTCELL ColsTotal3">
                                                    <%# Eval("M1359")%>
                                                </td>
                                                <td class="table-total FTOTCELL ColsTotal4">
                                                    <%# Eval("F1359")%>
                                                </td>
                                                <td class="table-total MTOTCELL ColsTotal5">
                                                    <%# Eval("M60")%>
                                                </td>
                                                <td class="table-total FTOTCELL ColsTotal6">
                                                    <%# Eval("F60")%>
                                                </td>
                                                <td class="table-total MFinalTotal ColsTotal7">
                                                    <%# Eval("Mtot")%>
                                                </td>
                                                <td class="table-total FFinalTotal ColsTotal8">
                                                    <%# Eval("Ftot")%>
                                                </td>
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
            var RowClass = $(this).attr("data-rowclass");
            var ColClass = $(this).attr("data-colclass");

            //Rows Sum
            $(this).parents("tr").find("." + RowClass).each(function () {
                sum += Number($(this).val());
            });
            $(this).parents("tr").find(".TOT" + RowClass).text(sum);

            //Column Sum
            var sum1 = 0;
            $(this).parents("table").find(".Cols" + ColClass).each(function () {
                sum1 += Number($(this).val());
                //console.log(Number($(this).val()));
            });
            $(this).parents("table").find(".ColsTotal" + ColClass).text(sum1);

            //FinalTotal
            var MFinalTotal = 0;
            $(".MFinalTotal").parents("tr").find(".MTOTCELL").each(function () {
                MFinalTotal += Number($(this).text());
            });
            $(".MFinalTotal").text(MFinalTotal);

            var FFinalTotal = 0;
            $(".FFinalTotal").parents("tr").find(".FTOTCELL").each(function () {
                FFinalTotal += Number($(this).text());
            });
            $(".FFinalTotal").text(FFinalTotal);
        });

        $(".entryform-table input").keydown(function () {
            var sum = 0;
            var RowClass = $(this).attr("data-rowclass");
            var ColClass = $(this).attr("data-colclass");

            //Rows Sum
            $(this).parents("tr").find("." + RowClass).each(function () {
                sum += Number($(this).val());
            });
            $(this).parents("tr").find(".TOT" + RowClass).text(sum);

            //Column Sum
            var sum1 = 0;
            $(this).parents("table").find(".Cols" + ColClass).each(function () {
                sum1 += Number($(this).val());
                //console.log(Number($(this).val()));
            });
            $(this).parents("table").find(".ColsTotal" + ColClass).text(sum1);

            //FinalTotal
            var MFinalTotal = 0;
            $(".MFinalTotal").parents("tr").find(".MTOTCELL").each(function () {
                MFinalTotal += Number($(this).text());
            });
            $(".MFinalTotal").text(MFinalTotal);

            var FFinalTotal = 0;
            $(".FFinalTotal").parents("tr").find(".FTOTCELL").each(function () {
                FFinalTotal += Number($(this).text());
            });
            $(".FFinalTotal").text(FFinalTotal);
        });

        $(".entryform-table input").keypress(function () {
            var sum = 0;
            var RowClass = $(this).attr("data-rowclass");
            var ColClass = $(this).attr("data-colclass");

            //Rows Sum
            $(this).parents("tr").find("." + RowClass).each(function () {
                sum += Number($(this).val());
            });
            $(this).parents("tr").find(".TOT" + RowClass).text(sum);

            //Column Sum
            var sum1 = 0;
            $(this).parents("table").find(".Cols" + ColClass).each(function () {
                sum1 += Number($(this).val());
                //console.log(Number($(this).val()));
            });
            $(this).parents("table").find(".ColsTotal" + ColClass).text(sum1);

            //FinalTotal
            var MFinalTotal = 0;
            $(".MFinalTotal").parents("tr").find(".MTOTCELL").each(function () {
                MFinalTotal += Number($(this).text());
            });
            $(".MFinalTotal").text(MFinalTotal);

            var FFinalTotal = 0;
            $(".FFinalTotal").parents("tr").find(".FTOTCELL").each(function () {
                FFinalTotal += Number($(this).text());
            });
            $(".FFinalTotal").text(FFinalTotal);
        });

        /*Save Data jquery*/
        $(".entryform-table input").focusout(function () {

            var RecId = $(this).parents("tr").attr("data-RecId"); ;
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
            //return false;
            $.ajax({
                type: "POST",
                url: "Handler.ashx/SaveDentalProcedureHandler",
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
