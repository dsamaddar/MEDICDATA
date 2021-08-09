<%@ Page Title="MEDICDATA | Hospital Beds" Language="C#" MasterPageFile="~/site.master"
    AutoEventWireup="true" CodeFile="AllocationHosptBEDS.aspx.cs" Inherits="AllocationHosptBEDS" %>

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
        ALLOCATION OF HOSPITAL BEDS
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
                            <table class="table table-bordered table-striped entryform-table EntryFormTable1">
                                <tbody>
                                    <tr>
                                        <th>
                                            ###
                                        </th>
                                        <th>
                                            BEDS
                                        </th>
                                        <th>
                                            CRADLES
                                        </th>
                                        <th>
                                            COTS
                                        </th>
                                        <th>
                                            INCUBATOR
                                        </th>
                                        <th>
                                            TOTAL
                                        </th>
                                        <th>
                                            ADMISSION
                                        </th>
                                        <th>
                                            DISCHARGES
                                        </th>
                                        <th>
                                            DEATHS
                                        </th>
                                    </tr>
                                    <asp:Repeater runat="server" ID="RPTAllocBEDS">
                                        <ItemTemplate>
                                            <tr data-recid="<%# Eval("RecId") %>" class='<%# Eval("ServiceName").ToString() != "TOTAL" ? "" : "d-none" %>'>
                                                <th class="heading" title="<%# Eval("ServiceName")%>">
                                                    <%# Eval("ServiceName")%>
                                                </th>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox1" runat="server" data-day="Beds" value='<%# Eval("Beds")%>'
                                                        Width="50px" class='<%# "table-control numeric Cols1 Rows"+  Eval("RecId") %>'
                                                        data-colclass='1' data-rowclass='<%# "Rows" + Eval("RecId")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox2" runat="server" data-day="Cradles" value='<%# Eval("Cradles")%>'
                                                        Width="50px" class='<%# "table-control numeric Cols2 Rows"+  Eval("RecId") %>'
                                                        data-colclass='2' data-rowclass='<%# "Rows" + Eval("RecId")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox3" runat="server" data-day="Cots" value='<%# Eval("Cots")%>'
                                                        Width="50px" class='<%# "table-control numeric Cols3 Rows"+  Eval("RecId") %>'
                                                        data-colclass='3' data-rowclass='<%# "Rows" + Eval("RecId")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox4" runat="server" data-day="Incubator" value='<%# Eval("Incubator")%>'
                                                        Width="50px" class='<%# "table-control numeric Cols4 Rows"+  Eval("RecId") %>'
                                                        data-colclass='4' data-rowclass='<%# "Rows" + Eval("RecId")%>' />
                                                </td>
                                                <td class="table-total">
                                                    <%# Eval("Total")%>
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox6" runat="server" data-day="Admission" value='<%# Eval("Admission")%>'
                                                        Width="50px" class='<%# "table-control numeric Cols6" %>' data-colclass='6' data-rowclass='<%# "Rows" + Eval("RecId")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox7" runat="server" data-day="Dicharge" value='<%# Eval("Dicharge")%>'
                                                        Width="50px" class='<%# "table-control numeric Cols7" %>' data-colclass='7' data-rowclass='<%# "Rows" + Eval("RecId")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox8" runat="server" data-day="Deaths" value='<%# Eval("Deaths")%>'
                                                        Width="50px" class='<%# "table-control numeric Cols8" %>' data-colclass='8' data-rowclass='<%# "Rows" + Eval("RecId")%>' />
                                                </td>
                                            </tr>
                                            <tr class='<%# Eval("ServiceName").ToString() == "TOTAL" ? "" : "d-none" %>'>
                                                <th class="heading" title="<%# Eval("ServiceName")%>">
                                                    <%# Eval("ServiceName")%>
                                                </th>
                                                <%--<td class="table-total TOTCELL ColsTotal1">--%>
                                                <td class="table-total ColsTotal1">
                                                    <%# Eval("Beds")%>
                                                </td>
                                                <td class="table-total TOTCELL ColsTotal2">
                                                    <%# Eval("Cradles")%>
                                                </td>
                                                <td class="table-total TOTCELL ColsTotal3">
                                                    <%# Eval("Cots")%>
                                                </td>
                                                <td class="table-total TOTCELL ColsTotal4">
                                                    <%# Eval("Incubator")%>
                                                </td>
                                                <td class="table-total ColsTotal5 FinalTotal">
                                                    <%# Eval("Total")%>
                                                </td>
                                                <td class="table-total ColsTotal6">
                                                    <%# Eval("Admission")%>
                                                </td>
                                                <td class="table-total ColsTotal7">
                                                    <%# Eval("Dicharge")%>
                                                </td>
                                                <td class="table-total ColsTotal8">
                                                    <%# Eval("Deaths")%>
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
    <h5 class="tittle-agileits mb-4 mt-5" id="H1" runat="server">
        IN-PATIENT ADMISSION AND THEIR OUTCOME
    </h5>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel with-nav-tabs panel-primary">
                <div class="panel-body table-body">
                    <div class="tab-content">
                        <div class="table-responsive">
                            <table class="table table-bordered table-striped entryform-table EntryFormTable2">
                                <tbody>
                                    <tr>
                                        <th>
                                            BED- COMPLEMENT
                                        </th>
                                        <th>
                                            MALE
                                        </th>
                                        <th>
                                            FEMALE
                                        </th>
                                        <th>
                                            TOTAL
                                        </th>
                                    </tr>
                                    <asp:Repeater runat="server" ID="RPTPatientAdmitOutcom">
                                        <ItemTemplate>
                                            <tr data-recid="<%# Eval("RecId") %>" class='<%# Eval("ServiceName").ToString() != "AVAILABLE BED" ? "" : "d-none" %>'>
                                                <th class="heading" title="<%# Eval("ServiceName")%>">
                                                    <%# Eval("ServiceName")%>
                                                </th>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox1" runat="server" data-day="MALE" value='<%# Eval("MALE")%>'
                                                        class='<%# "table-control numeric Rows"+  Eval("RecId") %>' data-rowclass='<%# "Rows" + Eval("RecId")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox2" runat="server" data-day="FEMALE" value='<%# Eval("FEMALE")%>'
                                                        class='<%# "table-control numeric Rows"+  Eval("RecId") %>' data-rowclass='<%# "Rows" + Eval("RecId")%>' />
                                                </td>
                                                <td class='table-total <%# Eval("ServiceName").ToString() == "BED COMPLEMENT" ? "BEDCOMTOT" : "" %> <%# Eval("ServiceName").ToString() == "CUMMULATIVE PATIENT DAYS" ? "DEATHSTOT" : "" %>'>
                                                    <%# Eval("Total")%>
                                                </td>
                                            </tr>

                                            <tr data-recid="<%# Eval("RecId") %>" class='<%# Eval("ServiceName").ToString() != "AVAILABLE BED" ? "d-none" : "" %>'>
                                                <th class="heading" title="<%# Eval("ServiceName")%>">
                                                    <%# Eval("ServiceName")%>
                                                </th>
                                                <td class="tcontrol AVBED" colspan="3">
                                                    <asp:TextBox ID="TextBox5" runat="server" data-day="MALE" value='<%# Eval("MALE")%>'
                                                        class='<%# "table-control numeric Rows"+  Eval("RecId") %>' data-rowclass='<%# "Rows" + Eval("RecId")%>' />
                                                </td>                                            
                                            </tr>
                                            <asp:HiddenField ID="HDays" ClientIDMode="Static" runat="server" value='<%# Eval("Days")%>' />
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <span class="headingABCD headingABD mt-3 width100 text-center" style="">A.B.D = <span>
                        0</span></span> <span class="headingABCD headingVBD mt-3 width100 text-center">V. B.
                            D. = <span>0</span></span>
                    <p class="text-center mt-3" style="color: Black; font-size: smaller; margin-left: 330px;">
                        NB: Cradles, Cots and Incubators in all Maternity ward should be deducted from Bed
                    </p>
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

            //A.B.D Total
            $(".headingABD>span").text(Number($('.AVBED').find('.table-control').val()) * Number($('#HDays').val()));
            $(".headingVBD>span").text((Number($('.AVBED').find('.table-control').val()) * Number($('#HDays').val())) - Number(($('.DEATHSTOT').text())));
        });

        $(".EntryFormTable1 input").keyup(function () {
            var sum = 0;
            var RowClass = $(this).attr("data-rowclass");
            var ColClass = $(this).attr("data-colclass");

            //Rows Sum
            $(this).parents("tr").find("." + RowClass).each(function () {
                sum += Number($(this).val());
            });
            $(this).parents("tr").find(".table-total").text(sum);

            //Column Sum
            var sum1 = 0;
            $(this).parents("table").find(".Cols" + ColClass).each(function () {
                sum1 += Number($(this).val());
                //console.log(Number($(this).val()));
            });
            $(this).parents("table").find(".ColsTotal" + ColClass).text(sum1);

            //FinalTotal
            var FinalTotal = 0;
            $(".FinalTotal").parents("tr").find(".TOTCELL").each(function () {
                FinalTotal += Number($(this).text());
            });
            $(".FinalTotal").text(FinalTotal);
        });

        $(".EntryFormTable1 input").keydown(function () {
            var sum = 0;
            var RowClass = $(this).attr("data-rowclass");
            var ColClass = $(this).attr("data-colclass");

            //Rows Sum
            $(this).parents("tr").find("." + RowClass).each(function () {
                sum += Number($(this).val());
            });
            $(this).parents("tr").find(".table-total").text(sum);

            //Column Sum
            var sum1 = 0;
            $(this).parents("table").find(".Cols" + ColClass).each(function () {
                sum1 += Number($(this).val());
                //console.log(Number($(this).val()));
            });
            $(this).parents("table").find(".ColsTotal" + ColClass).text(sum1);

            //FinalTotal
            var FinalTotal = 0;
            $(".FinalTotal").parents("tr").find(".TOTCELL").each(function () {
                FinalTotal += Number($(this).text());
            });
            $(".FinalTotal").text(FinalTotal);
        });

        $(".EntryFormTable1 input").keypress(function () {
            var sum = 0;
            var RowClass = $(this).attr("data-rowclass");
            var ColClass = $(this).attr("data-colclass");

            //Rows Sum
            $(this).parents("tr").find("." + RowClass).each(function () {
                sum += Number($(this).val());
            });
            $(this).parents("tr").find(".table-total").text(sum);

            //Column Sum
            var sum1 = 0;
            $(this).parents("table").find(".Cols" + ColClass).each(function () {
                sum1 += Number($(this).val());
                //console.log(Number($(this).val()));
            });
            $(this).parents("table").find(".ColsTotal" + ColClass).text(sum1);

            //FinalTotal
            var FinalTotal = 0;
            $(".FinalTotal").parents("tr").find(".TOTCELL").each(function () {
                FinalTotal += Number($(this).text());
            });
            $(".FinalTotal").text(FinalTotal);
        });

        /*Save Data jquery*/
        $(".EntryFormTable1 input").focusout(function () {

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
            //console.log('{"RecId":' + RecId + ',"ServiceId":' + ServiceId + ',"CompanyId":' + CompanyId + ', "StateId": ' + StateId + ',"CMonth":' + CMonth + ',"CYear":' + CYear + ',"CDay":' + CDay + ',"CVal":' + CVal + ',"CreatedBy":' + CreatedBy + ',"Htype":' + Htype + '}');
            $.ajax({
                type: "POST",
                url: "Handler.ashx/SaveHospitalBedsDetailsHandler",
                contentType: "application/json; charset=uft-8",
                data: '{"RecId":' + RecId + ',"ServiceId":' + ServiceId + ',"CompanyId":' + CompanyId + ', "StateId": ' + StateId + ',"CMonth":' + CMonth + ',"CYear":' + CYear + ',"CDay":"' + CDay + '","CVal":' + CVal + ',"CreatedBy":' + CreatedBy + ',"Htype":' + Htype + '}',
                beforeSend: function () {
                },
                success: function (response) {
                    //console.log(response);
                }
            });

        });

        //EntryFormTable2
        $(".EntryFormTable2 input").keyup(function () {
            var sum = 0;
            var RowClass = $(this).attr("data-rowclass");

            //Rows Sum
            $(this).parents("tr").find("." + RowClass).each(function () {
                sum += Number($(this).val());
            });
            $(this).parents("tr").find(".table-total").text(sum);

            //A.B.D Total
            $(".headingABD>span").text(Number($('.AVBED').find('.table-control').val()) * Number($('#HDays').val()));
            $(".headingVBD>span").text((Number($('.AVBED').find('.table-control').val()) * Number($('#HDays').val())) - Number(($('.DEATHSTOT').text())));
        });

        $(".EntryFormTable2 input").keydown(function () {
            var sum = 0;
            var RowClass = $(this).attr("data-rowclass");

            //Rows Sum
            $(this).parents("tr").find("." + RowClass).each(function () {
                sum += Number($(this).val());
            });
            $(this).parents("tr").find(".table-total").text(sum);

            //A.B.D Total
            $(".headingABD>span").text(Number($('.AVBED').find('.table-control').val()) * Number($('#HDays').val()));
            $(".headingVBD>span").text((Number($('.AVBED').find('.table-control').val()) * Number($('#HDays').val())) - Number(($('.DEATHSTOT').text())));
        });

        $(".EntryFormTable2 input").keypress(function () {
            var sum = 0;
            var RowClass = $(this).attr("data-rowclass");

            //Rows Sum
            $(this).parents("tr").find("." + RowClass).each(function () {
                sum += Number($(this).val());
            });
            $(this).parents("tr").find(".table-total").text(sum);

            //A.B.D Total
            $(".headingABD>span").text(Number($('.AVBED').find('.table-control').val()) * Number($('#HDays').val()));
            $(".headingVBD>span").text((Number($('.AVBED').find('.table-control').val()) * Number($('#HDays').val())) - Number(($('.DEATHSTOT').text())));

        });

        /*Save Data jquery*/
        $(".EntryFormTable2 input").focusout(function () {
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
            console.log('{"RecId":' + RecId + ',"ServiceId":' + ServiceId + ',"CompanyId":' + CompanyId + ', "StateId": ' + StateId + ',"CMonth":' + CMonth + ',"CYear":' + CYear + ',"CDay":' + CDay + ',"CVal":' + CVal + ',"CreatedBy":' + CreatedBy + ',"Htype":' + Htype + '}');
            $.ajax({
                type: "POST",
                url: "Handler.ashx/SavePatientAdmitOutcomesHandler",
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
