<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="HelpDesk.Web.Admins.UserDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">使用者明細</h3>
        </div>
        <div class="box-body">
            <asp:FormView 
                ID="FormViewAD"
                ItemType="Landpy.ActiveDirectory.Entity.Object.UserObject"
                SelectMethod="SelectUser"
                runat="server">
                <ItemTemplate>
                    <table class="table table-hover table-responsive table-bordered">
                        <tr>
                            <th>帳號</th>
                            <td><%#: Item.SAMAccountName %></td>
                            <th>顯示名稱</th>
                            <td><%#: Item.DisplayName %></td>
                        </tr>
                        <tr>
                            <th>電子郵件</th>
                            <td><%#: Item.Email %></td>
                            <th>註記</th>
                            <td><%#: Item.Description %></td>
                        </tr>
                        <tr>
                            <th>系統管理員</th>
                            <td><%#: Item.IsDomainAdmin %></td>
                            <th>帳號管理員</th>
                            <td><%#: Item.IsAccountOperator %></td>
                        </tr>
                        <tr>

                        </tr>
                        <tr>
                            <th>是否啟用</th>
                            <td><%#: Item.IsEnabled %></td>
                            <th>是否鎖定</th>
                            <td><%#: Item.IsLocked %></td>
                        </tr>

                    </table>
                </ItemTemplate>
            </asp:FormView>
            
            <asp:FormView 
                ID="FormViewDBUser"
                ItemType="HelpDesk.Models.UserData"
                SelectMethod="SelectDBUser"
                runat="server">
                <ItemTemplate>
                    <table class="table table-hover table-responsive table-bordered"></table>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
