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
                <%-- <button type="button" class="btn btn-primary btn-flat" data-toggle="modal" data-target="#modal-default-ad"> --%>
                <%--     <i class="fa fa-user-plus"></i>建立AD帳號 --%>
                <%-- </button> --%>
                <%-- <button type="button" class="btn btn-info btn-flat" data-toggle="modal" data-target="#modal-default-vpn"> --%>
                <%--     <i class="fa fa-user-plus"></i>建立VPN帳號 --%>
                <%-- </button> --%>
            </div>
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
                        <tr class="bg-aqua">
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
    
    <div class="modal fade" id="modal-default-ad" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:FormView
                    runat="server"
                    RenderOuterTable="False"
                    DefaultMode="Insert"
                    ID="FormViewAD">
                    <InsertItemTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span></button>
                            <h4 class="modal-title">建立AD帳號</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="control-label col-md-2">登入帳號:</label>
                                    <div class="col-md-10">
                                        <asp:TextBox runat="server" ID="TextBoxADAccount" CssClass="form-control bg-yellow"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                            <asp:LinkButton 
                                CommandName="Insert" 
                                runat="server" 
                                ID="LinkButtonCreateAD" 
                                OnClientClick="return window.flag=confirm('即將建立AD帳號,是否確定?')"
                                CssClass="btn btn-flat btn-primary">
                                <i class="fa fa-user-plus"></i>建立AD帳號
                            </asp:LinkButton>

                        </div>
                    </InsertItemTemplate>
                </asp:FormView>

            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
    
    <div class="modal fade" id="modal-default-vpn" style="display: none;">
        <div class="modal-dialog">
            <div class="modal-content">
                <asp:FormView
                    runat="server"
                    DefaultMode="Insert"
                    ItemType="HelpDesk.ViewModels.ADUserViewModel"
                    InsertMethod="InsertValue"
                    OnItemInserted="OnItemInserted"
                    RenderOuterTable="False">
                    <InsertItemTemplate>
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                <span aria-hidden="true">×</span></button>
                            <h4 class="modal-title">建立VPN帳號</h4>
                        </div>
                        <div class="modal-body">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <label class="control-label col-md-2">登入帳號:</label>
                                    <div class="col-md-10">
                                        <asp:TextBox
                                            runat="server"
                                            ID="TextBoxVPNAccount"
                                            CssClass="form-control bg-yellow"
                                            Text="<%#: BindItem.Account %>"
                                            ToolTip="必要欄位(Required)"/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-2">顯示名稱:</label>
                                    <div class="col-md-10">
                                        <asp:TextBox
                                            runat="server"
                                            ID="TextBoxDisplayName"
                                            CssClass="form-control bg-yellow"
                                            Text="<%#: BindItem.DisplayName %>"
                                            ToolTip="必要欄位(Required)"/>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label class="control-label col-md-2">登入密碼:</label>
                                    <div class="col-md-10">
                                        <asp:TextBox
                                            runat="server"
                                            ID="TextBox1"
                                            CssClass="form-control bg-yellow"
                                            Text="<%#: BindItem.Password %>"
                                            ToolTip="必要欄位(Required)"/>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
                            <asp:LinkButton 
                                OnClientClick="return window.flag=confirm('即將建立VPN帳號,是否確定?')"
                                CommandName="Insert" 
                                runat="server" 
                                ID="LinkButtonCreateVPN" 
                                CssClass="btn btn-flat btn-info">
                                <i class="fa fa-user-plus"></i>建立VPN帳號
                            </asp:LinkButton>

                        </div>
                    </InsertItemTemplate>
                </asp:FormView>

            </div>
            <!-- /.modal-content -->
        </div>
        <!-- /.modal-dialog -->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
