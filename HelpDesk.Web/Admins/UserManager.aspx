<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserManager.aspx.cs" Inherits="HelpDesk.Web.Admins.UserManager" %>

<%@ Register Src="~/Components/FormSearchComponent.ascx" TagPrefix="uc1" TagName="FormSearchComponent" %>
<%@ Register Src="~/Components/ButtonListComponent.ascx" TagPrefix="uc1" TagName="ButtonListComponent" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:FormSearchComponent runat="server" ID="FormSearchComponent" />
    <div class="box box-info">
        <div class="box-header">
            <h3 class="box-title"><i class="fa fa-group"></i>人員清單</h3>
        </div>
        <div class="box-body">
            <asp:ListView 
                runat="server" 
                ItemType="HelpDesk.Models.UserData"
                OnItemCommand="ListViewMain_OnItemCommand"
                SelectMethod="SelectUsers"
                UpdateMethod="UpdateUser"
                DeleteMethod="DeleteUser"
                InsertMethod="InsertUser"
                InsertItemPosition="FirstItem"
                ID="ListViewMain">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover table-responsive">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>工號</th>
                                <th>姓名</th>
                                <th>單位編號</th>
                                <th>單位名稱</th>
                                <th>權限</th>
                            </tr>
                        </thead>
                        <tbody>
                        <asp:PlaceHolder runat="server" ID="itemPlaceholder"/>
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <uc1:ButtonListComponent
                                IsSmallIcon="True"
                                ShowBtns="Detail,Edit,Delete"
                                runat="server" ID="ButtonListComponent" />
                        </td>
                        <td>
                            <%#: Item.EmpNo %>
                        </td>
                        <td>
                            <%#: Item.EmpName %>
                        </td>
                        <td>
                            <%#: Item.Dept %>
                        </td>
                        <td>
                            <%#: Item.Boss %>
                        </td>
                    </tr>
                </ItemTemplate>
                <InsertItemTemplate>
                    <tr>
                        <td>
                            <uc1:ButtonListComponent
                                IsSmallIcon="True"
                                ShowBtns="Insert"
                                runat="server" ID="ButtonListComponent" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" CssClass="form-control" ID="TextBoxEmpNo" Text="<%#: Item.EmpNo %>"/>
                        </td>
                        <td>
                            <asp:TextBox runat="server" CssClass="form-control" ID="TextBoxEmpName" Text="<%#: Item.EmpName %>"/>
                            <%#: Item.EmpName %>
                        </td>
                        <td>
                            <%#: Item.Dept %>
                        </td>
                        <td>
                            <%#: Item.Boss %>
                        </td>
                    </tr>
                </InsertItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
