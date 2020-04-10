<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ADUserManager.aspx.cs" Inherits="HelpDesk.Web.Admins.ADUserManager" %>

<%@ Register Src="~/Components/FormSearchComponent.ascx" TagPrefix="uc1" TagName="FormSearchComponent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:FormSearchComponent
        runat="server"
        ID="FormSearchComponent"
        ShowItems="SearchText"
        OnSearch="FormSearchComponent_OnSearch" />
    
    <div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">人員清單</h3>
        </div>
        <div class="box-body">
            <div>
                <asp:DataPager runat="server" ID="DataPager1" PagedControlID="ListViewMain">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-info btn-flat" NextPreviousButtonCssClass="btn btn-default btn-flat" NumericButtonCssClass="btn btn-default btn-flat" />
                        <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </div>
            <asp:ListView
                ItemType="Landpy.ActiveDirectory.Entity.Object.UserObject"
                runat="server"
                SelectMethod="SelectUsers"
                OnItemCommand="ListViewMain_OnItemCommand"
                ID="ListViewMain">
                <LayoutTemplate>
                    <table class="table table-hover table-responsive table-bordered">
                        <thead>
                        <tr>
                            <th>#</th>
                            <th>帳號</th>
                            <th>顯示名稱</th>
                            <th>目前狀態</th>
                            <th>連絡電話</th>
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
                            <div class="btn-group">
                                <asp:LinkButton
                                    runat="server"
                                    CommandName="DisableUser"
                                    CommandArgument="<%#: Item.SAMAccountName %>"
                                    OnClientClick="return window.flag=confirm('即將停用,是否確定?')"
                                    CssClass="btn btn-flat btn-sm btn-danger btnRunningWithFlag">
                                    <i class="fa fa-user-times"></i>停用帳戶
                                </asp:LinkButton>
                                <asp:LinkButton
                                    runat="server"
                                    CommandName="EnableUser"
                                    CommandArgument="<%#: Item.SAMAccountName %>"
                                    OnClientClick="return window.flag=confirm('即將啟用,是否確定?')"
                                    CssClass="btn btn-flat btn-sm btn-primary btnRunningWithFlag">
                                    <i class="fa fa-user"></i>啟用帳戶
                                </asp:LinkButton>
                                <asp:LinkButton
                                    runat="server"
                                    CommandName="Unlock"
                                    CommandArgument="<%#: Item.SAMAccountName %>"
                                    OnClientClick="return window.flag=confirm('即將解鎖,是否確定?')"
                                    CssClass="btn btn-flat btn-sm btn-info btnRunningWithFlag">
                                    <i class="fa fa-unlock"></i>解除鎖定
                                </asp:LinkButton>
                                <asp:LinkButton
                                    runat="server"
                                    CommandName="Detail"
                                    CommandArgument="<%#: Item.SAMAccountName %>"
                                    CssClass="btn btn-flat btn-sm btn-default btnRunning">
                                    <i class="fa fa-list"></i>查看明細
                                </asp:LinkButton>
                            </div>

                        </td>
                        <td><%#: Item.SAMAccountName %></td>
                        <td><%#: Item.DisplayName %></td>
                        <td>
                            <asp:DynamicControl runat="server" DataField="IsEnabled"/>
                        </td>
                        <td>
                            <asp:DynamicControl runat="server" DataField="Telephone"/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
    

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
