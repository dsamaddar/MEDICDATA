<%@ Page Title="MEDICDATA | USERS" Language="C#" MasterPageFile="~/site.master" AutoEventWireup="true"
    CodeFile="HospitalList.aspx.cs" Inherits="UserList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="form-padding">
        <h3 class="tittle-agileits mb-4">
            Hospital</h3>
        <div class="form-row">
            <div class="form-group input-area col-md-4">
                <asp:TextBox runat="server" ID="txtSearch" placeholder="Search..." class="form-control txtHospital"></asp:TextBox>
            </div>
            <div class="form-group col-md-2">
                <asp:LinkButton runat="server" ID="btnSearch" class="btn btn-primary" OnClick="btnSearch_Click"><i class="fa fa-search mr-1"></i>Search</asp:LinkButton>
            </div>
            <div class="form-group col-md-6 text-right">
                <asp:LinkButton runat="server" ID="btnAdd" class="btn btn-primary" 
                    onclick="btnAdd_Click"><i class="fa fa-plus mr-1"></i>Add</asp:LinkButton>
            </div>
        </div>
        <div class="row">
            <div class="col-md-4">
                <b class="total-record">Total Record :
                    <asp:Label ID="lbltotrecords" runat="server" Text="0" Visible="true">
                    </asp:Label></b>
            </div>
            <div class="col-md-8">
                <span class="pull-right Derror" id="spErrorMsg" runat="server"></span>
            </div>
        </div>
        <div class="table-responsive mt-2">
            <table class="table table-bordered table-striped">
                <thead>
                    <tr>
                        <th>
                            Hospital
                        </th>
                        <th style="width: 200px;">
                            CGuid
                        </th>
                        <th>
                            Email
                        </th>
                        <th>
                            State
                        </th>
                        <th>
                            City
                        </th>
                        <th>
                            Contact
                        </th>
                        <th>
                            Edit
                        </th>
                        <th>
                            Active
                        </th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="RptUserList" runat="server" OnItemCommand="RptUserList_ItemCommand"
                        OnItemDataBound="RptUserList_ItemDataBound">
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <%# Eval("CName")%>
                                </td>
                                <td>
                                    <%# Eval("CGuid")%>
                                </td>
                                <td>
                                    <%# Eval("Email")%>
                                </td>
                                <td>
                                    <%# Eval("StateName")%>
                                </td>
                                <td>
                                    <%# Eval("City")%>
                                </td>
                                <td>
                                    <%# Eval("Contact")%>
                                </td>
                                <td class="text-center">
                                    <asp:LinkButton ID="btnEdit" CommandName="Edit" CommandArgument='<%# Eval("RecId")%>'
                                        runat="server"><i class="far fa-edit mr-1 font20"></i></asp:LinkButton>
                                </td>
                                <td class="text-center">
                                    <asp:LinkButton ID="btnDeactive" CommandName="Deactive" CommandArgument='<%# Eval("RecId")%>' ToolTip='<%#Eval("IsActive") %>'
                                        runat="server"><i class='<%#Eval("IsActiveCss_W") %> font20'> </i></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
        <div class="row mt-1">
            <div class="col-lg-12">
                <ul class="pagination justify-content-end">
                    <asp:Repeater ID="RptPaging" runat="server" OnItemCommand="RptPaging_ItemCommand"
                        OnItemDataBound="RptPaging_ItemDataBound">
                        <ItemTemplate>
                            <li id="lipage" runat="server" class="page-item">
                                <asp:LinkButton ID="btnPage" CssClass="page-link" CommandName="Page" CommandArgument="<%# Container.DataItem %>"
                                    runat="server">
                                                                <%# Container.DataItem %>
                                </asp:LinkButton></li>
                            <asp:HiddenField ID="hfPage" runat="server" Value='<%# Container.ItemIndex %>' />
                        </ItemTemplate>
                    </asp:Repeater>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
</asp:Content>
