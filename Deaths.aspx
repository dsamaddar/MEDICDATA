<%@ Page Title="MEDICDATA | CASE DETAILS" Language="C#" MasterPageFile="~/site.master"
    AutoEventWireup="true" CodeFile="Deaths.aspx.cs" Inherits="Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:HiddenField ID="GroupId" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="HType" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="CaseType" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="GenderType" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="CreatedBy" ClientIDMode="Static" runat="server" />
    <asp:HiddenField ID="StateId" ClientIDMode="Static" runat="server" />
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
                        <div class="col-md-6">
                            <ul class="nav nav-tabs report-tab">
                                <li class="active"><a href="javascript:void(0)" id="PageTitle" runat="server"></a>
                                </li>
                            </ul>
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
                                    <tr>
                                        <th>
                                            SERVICES
                                        </th>
                                        <th>
                                            1
                                        </th>
                                        <th>
                                            2
                                        </th>
                                        <th>
                                            3
                                        </th>
                                        <th>
                                            4
                                        </th>
                                        <th>
                                            5
                                        </th>
                                        <th>
                                            6
                                        </th>
                                        <th>
                                            7
                                        </th>
                                        <th>
                                            8
                                        </th>
                                        <th>
                                            9
                                        </th>
                                        <th>
                                            10
                                        </th>
                                        <th>
                                            11
                                        </th>
                                        <th>
                                            12
                                        </th>
                                        <th>
                                            13
                                        </th>
                                        <th>
                                            14
                                        </th>
                                        <th>
                                            15
                                        </th>
                                        <th>
                                            16
                                        </th>
                                        <th>
                                            17
                                        </th>
                                        <th>
                                            18
                                        </th>
                                        <th>
                                            19
                                        </th>
                                        <th>
                                            20
                                        </th>
                                        <th>
                                            21
                                        </th>
                                        <th>
                                            22
                                        </th>
                                        <th>
                                            23
                                        </th>
                                        <th>
                                            24
                                        </th>
                                        <th>
                                            25
                                        </th>
                                        <th>
                                            26
                                        </th>
                                        <th>
                                            27
                                        </th>
                                        <th>
                                            28
                                        </th>
                                        <th id="hday29" runat="server">
                                            29
                                        </th>
                                        <th id="hday30" runat="server">
                                            30
                                        </th>
                                        <th id="hday31" runat="server">
                                            31
                                        </th>
                                        <th class="table-total">
                                            Total
                                        </th>
                                    </tr>
                                    <asp:Repeater runat="server" ID="RPTCaseDetails">
                                        <ItemTemplate>
                                            <tr class='<%# Eval("SMParentId").ToString() != "0" && Eval("SMParentId").ToString() != "9999" ? "" : "d-none" %>'
                                                data-finaltot="<%# "FinalTotal"+  Eval("OrderId")%>" data-recid="<%# Eval("SMRecId") %>">
                                                <th class="heading">
                                                    <%# Eval("ServiceName")%>
                                                </th>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox1" runat="server" data-day="1" data-colclass='<%# "1" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols1"+  Eval("OrderId") +" Rows" + Eval("SMRecId") %>'
                                                        value='<%# Eval("Date1")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox2" runat="server" data-day="2" data-colclass='<%# "2" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols2"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date2")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox3" runat="server" data-day="3" data-colclass='<%# "3" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols3"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date3")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox4" runat="server" data-day="4" data-colclass='<%# "4" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols4"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date4")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox5" runat="server" data-day="5" data-colclass='<%# "5" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols5"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date5")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox6" runat="server" data-day="6" data-colclass='<%# "6" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols6"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date6")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox7" runat="server" data-day="7" data-colclass='<%# "7" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols7"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date7")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox8" runat="server" data-day="8" data-colclass='<%# "8" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols8"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date8")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox9" runat="server" data-day="9" data-colclass='<%# "9" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols9"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date9")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox10" runat="server" data-day="10" data-colclass='<%# "10" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols10"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date10")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox11" runat="server" data-day="11" data-colclass='<%# "11" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols11"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date11")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox12" runat="server" data-day="12" data-colclass='<%# "12" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols12"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date12")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox13" runat="server" data-day="13" data-colclass='<%# "13" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols13"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date13")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox14" runat="server" data-day="14" data-colclass='<%# "14" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols14"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date14")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox15" runat="server" data-day="15" data-colclass='<%# "15" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols15"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date15")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox16" runat="server" data-day="16" data-colclass='<%# "16" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols16"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date16")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox17" runat="server" data-day="17" data-colclass='<%# "17" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols17"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date17")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox18" runat="server" data-day="18" data-colclass='<%# "18" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols18"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date18")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox19" runat="server" data-day="19" data-colclass='<%# "19" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols19"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date19")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox20" runat="server" data-day="20" data-colclass='<%# "20" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols20"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date20")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox21" runat="server" data-day="21" data-colclass='<%# "21" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols21"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date21")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox22" runat="server" data-day="22" data-colclass='<%# "22" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols22"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date22")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox23" runat="server" data-day="23" data-colclass='<%# "23" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols23"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date23")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox24" runat="server" data-day="24" data-colclass='<%# "24" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols24"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date24")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox25" runat="server" data-day="25" data-colclass='<%# "25" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols25"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date25")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox26" runat="server" data-day="26" data-colclass='<%# "26" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols26"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date26")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox27" runat="server" data-day="27" data-colclass='<%# "27" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols27"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date27")%>' />
                                                </td>
                                                <td class="tcontrol">
                                                    <asp:TextBox ID="TextBox28" runat="server" data-day="28" data-colclass='<%# "28" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols28"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date28")%>' />
                                                </td>
                                                <td class='<%# "tcontrol "+ Eval("VDate29")%>'>
                                                    <asp:TextBox ID="TextBox29" runat="server" data-day="29" data-colclass='<%# "29" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols29"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date29")%>' />
                                                </td>
                                                <td class='<%# "tcontrol "+ Eval("VDate30")%>'>
                                                    <asp:TextBox ID="TextBox30" runat="server" data-day="30" data-colclass='<%# "30" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols30"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date30")%>' />
                                                </td>
                                                <td class='<%# "tcontrol "+ Eval("VDate31")%>'>
                                                    <asp:TextBox ID="TextBox31" runat="server" data-day="31" data-colclass='<%# "31" + Eval("OrderId")%>'
                                                        data-rowclass='<%# "Rows" + Eval("SMRecId")%>' class='<%# "table-control numeric Cols31"+  Eval("OrderId") +" Rows" + Eval("SMRecId")%>'
                                                        value='<%# Eval("Date31")%>' />
                                                </td>
                                                <td class='<%# "table-total ColsTotal" +Eval("OrderId") + " RowsTotal" + Eval("SMRecId")%>'>
                                                    <%# Eval("RowTotal")%>
                                                </td>
                                            </tr>
                                            <tr class='<%# Eval("SMParentId").ToString() != "9999" ? "d-none" : "" %>'>
                                                <th class="heading">
                                                    <%# Eval("ServiceName")%>
                                                </th>
                                                <td class='<%# "table-total TOTCELL ColsTotal1"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date1")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal2"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date2")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal3"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date3")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal4"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date4")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal5"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date5")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal6"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date6")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal7"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date7")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal8"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date8")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal9"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date9")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal10"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date10")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal11"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date11")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal12"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date12")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal13"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date13")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal14"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date14")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal15"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date15")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal16"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date16")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal17"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date17")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal18"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date18")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal19"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date19")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal20"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date20")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal21"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date21")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal22"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date22")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal23"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date23")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal24"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date24")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal25"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date25")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal26"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date26")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal27"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date27")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal28"+  Eval("OrderId")%>'>
                                                    <%# Eval("Date28")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal29"+  Eval("OrderId") + " " + Eval("VDate29") %>'>
                                                    <%# Eval("Date29")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal30"+  Eval("OrderId") + " " + Eval("VDate30") %>'>
                                                    <%# Eval("Date30")%>
                                                </td>
                                                <td class='<%# "table-total TOTCELL ColsTotal31"+  Eval("OrderId") + " " + Eval("VDate31") %>'>
                                                    <%# Eval("Date31")%>
                                                </td>
                                                <td class='<%# "table-total FinalTotal"+  Eval("OrderId")%>'>
                                                    <%# Eval("RowTotal")%>
                                                </td>
                                            </tr>
                                            <tr class='<%# Eval("SMParentId").ToString() != "0" ? "d-none" : "" %>'>
                                                <th colspan='<%# Eval("TotDay")%>' class="text-left">
                                                    <%# Eval("ServiceName")%>
                                                </th>
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
            $(this).parents("tr").find(".table-total").text(sum);

            //Column Sum
            var sum1 = 0;
            $(this).parents("table").find(".Cols" + ColClass).each(function () {
                sum1 += Number($(this).val());
            });
            $(this).parents("table").find(".ColsTotal" + ColClass).text(sum1);

            //FinalTotal
            var FinalTotal = 0;
            var FinalClass = $(this).parents("tr").attr("data-finaltot");
            $("." + FinalClass).parents("tr").find(".TOTCELL").each(function () {
                FinalTotal += Number($(this).text());
            });
            $("." + FinalClass).text(FinalTotal);
        });

        $(".entryform-table input").keydown(function () {
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
            });
            $(this).parents("table").find(".ColsTotal" + ColClass).text(sum1);

            //FinalTotal
            var FinalTotal = 0;
            var FinalClass = $(this).parents("tr").attr("data-finaltot");
            $("." + FinalClass).parents("tr").find(".TOTCELL").each(function () {
                FinalTotal += Number($(this).text());
            });
            $("." + FinalClass).text(FinalTotal);
        });

        $(".entryform-table input").keypress(function () {
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
            });
            $(this).parents("table").find(".ColsTotal" + ColClass).text(sum1);

            //FinalTotal
            var FinalTotal = 0;
            var FinalClass = $(this).parents("tr").attr("data-finaltot");
            $("." + FinalClass).parents("tr").find(".TOTCELL").each(function () {
                FinalTotal += Number($(this).text());
            });
            $("." + FinalClass).text(FinalTotal);
        });

        /*Save Data jquery*/
        $(".entryform-table input").focusout(function () {
            var RecId = 0;
            var ServiceId = $(this).parents("tr").attr("data-RecId");
            var CaseType = $("#CaseType").val();
            var HType = $("#HType").val();
            var Gender = $("#GenderType").val();
            var CMonth = $(".CMonth").val();
            var CVal = Number($(this).val());
            var CYear = $(".CYear").val();
            var CDay = $(this).attr("data-day");
            var CreatedBy = $("#CreatedBy").val();
            var StateId = $("#StateId").val();
            //console.log('{"RecId":' + RecId + ',"ServiceId":' + ServiceId + ',"HType":' + HType + ',"CaseType":' + CaseType + ',"Gender":' + Gender + ',"CMonth":' + CMonth + ',"CYear":' + CYear + ',"CDay":' + CDay + ',"CVal":' + CVal + ',"CreatedBy":' + CreatedBy + ',"StateId":' + StateId + '}');
            $.ajax({
                type: "POST",
                url: "Handler.ashx/SaveCaseDetailHandler",
                contentType: "application/json; charset=uft-8",
                data: '{"RecId":' + RecId + ',"ServiceId":' + ServiceId + ',"HType":' + HType + ',"CaseType":' + CaseType + ',"Gender":' + Gender + ',"CMonth":' + CMonth + ',"CYear":' + CYear + ',"CDay":' + CDay + ',"CVal":' + CVal + ',"CreatedBy":' + CreatedBy + ',"StateId":' + StateId + '}',
                beforeSend: function () {
                },
                success: function (response) {
                    //console.log(response);
                }
            });

        });
    </script>
</asp:Content>
