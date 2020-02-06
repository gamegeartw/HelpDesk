<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DevicesManatain.aspx.cs" Inherits="HelpDesk.UserPages.DevicesManatain" %>

<%@ Register Src="~/Components/FormViewSearchComponent.ascx" TagPrefix="uc1" TagName="FormViewSearchComponent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:FormViewSearchComponent runat="server" ID="FormViewSearchComponent" />
    <asp:Panel runat="server" ID="PanelMain" CssClass="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">清單列表</h3>
        </div>
        <div class="box-body">
            <div>
                <asp:LinkButton
                    runat="server"
                    ID="LinkButtonCreate"
                    CssClass="btn btn-flat btn-primary">
                        <i class="fa fa-file"></i>新建
                </asp:LinkButton>
                <asp:LinkButton
                    runat="server"
                    ID="LinkButtonPrint"
                    CssClass="btn btn-flat btn-info">
                        <i class="fa fa-print"></i>列印
                </asp:LinkButton>
            </div>
            <div>
                <asp:DataPager runat="server" ID="DataPager1">
                    <Fields>
                        <asp:NextPreviousPagerField ButtonCssClass="btn btn-default" ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-info" NextPreviousButtonCssClass="btn btn-default" NumericButtonCssClass="btn btn-default" />
                        <asp:NextPreviousPagerField ButtonCssClass="btn btn-default" ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
                <asp:Literal runat="server" ID="Literal1" />
            </div>
            <asp:ListView
                runat="server"
                ItemType="HelpDesk.ViewModels.DeviceViewModel"
                SelectMethod="Select"
                DeleteMethod="Delete"
                ID="ListViewMain">
                <LayoutTemplate>
                    <table class="table table-responsive table-bordered table-hover">
                        <thead>
                            <tr>
                                <th>#</th>
                                <th>編號</th>
                                <th>品名</th>
                                <th>數量</th>
                                <th>成本</th>
                                <th>保管人</th>
                                <th>保管地點</th>
                                <th>入帳時間</th>
                                <th>建檔時間</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                        </tbody>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <div class="btn btn-group">
                                <asp:LinkButton
                                    runat="server"
                                    ID="LinkButtonEdit"
                                    CommandName="Edit"
                                    CssClass="btn btn-sm btn-flat btn-info">
                                        <i class="fa fa-floppy-o"></i>編輯
                                </asp:LinkButton>
                                <asp:LinkButton
                                    runat="server"
                                    ID="LinkButtonRevoke"
                                    CommandName="Revoke"
                                    CssClass="btn btn-sm btn-flat btn-warning">
                                        <i class="fa fa-remove"></i>除帳
                                </asp:LinkButton>
                            </div>
                        </td>
                        <td><%#: Item.No %></td>
                        <td><%#: Item.Name %></td>
                        <td><%#: Item.Count %></td>
                        <td><%#: Item.Amount%></td>
                        <td><%#: Item.User %></td>
                        <td><%#: Item.Location %></td>
                        <td>
                            <asp:DynamicControl
                                runat="server"
                                ID="DynamicControlImportTime"
                                DataField="ImportTime"
                                DataFormatString="{0:yyyy/MM/dd}" />
                        </td>
                        <td>
                            <asp:DynamicControl
                                runat="server"
                                ID="DynamicControlCreateTime"
                                DataField="CreateTime"
                                DataFormatString="{0:yyyy/MM/dd}" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>

    </asp:Panel>

    <asp:Panel runat="server" ID="PanelEdit" CssClass="box box-info" Visible="False">
        <div class="box-header with-border">
            <h3 class="box-title">
                項目
            </h3>
        </div>
        <asp:FormView
            ID="FormViewMain"
            ItemType="HelpDesk.ViewModels.DeviceViewModel"
            InsertMethod="Insert"
            UpdateMethod="Update"
            SelectMethod="SelectItem"
            DataKeyNames="No"
            DefaultMode="ReadOnly"
            RenderOuterTable="False"
            runat="server">
            <ItemTemplate>
                <div class="box-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-md-2">
                                編號
                            </label>
                            <div class="col-md-10">
                                <asp:DynamicControl CssClass="form-control-static" runat="server" ID="DynamicControlNo" DataField="No" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">
                                品名
                            </label>
                            <div class="col-md-10">
                                <asp:DynamicControl CssClass="form-control-static" runat="server" ID="DynamicControl1" DataField="Name" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">
                                數量
                            </label>
                            <div class="col-md-10">
                                <asp:DynamicControl CssClass="form-control-static" runat="server" ID="DynamicControl2" DataField="Count" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">
                                成本
                            </label>
                            <div class="col-md-10">
                                <asp:DynamicControl CssClass="form-control-static" runat="server" ID="DynamicControl3" DataField="Amount" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">
                                保管人
                            </label>
                            <div class="col-md-10">
                                <asp:DynamicControl CssClass="form-control-static" runat="server" ID="DynamicControl4" DataField="User" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">
                                保管地點
                            </label>
                            <div class="col-md-10">
                                <asp:DynamicControl CssClass="form-control-static" runat="server" ID="DynamicControl5" DataField="Location" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">
                                匯入時間
                            </label>
                            <div class="col-md-10">
                                <asp:DynamicControl CssClass="form-control-static" runat="server" ID="DynamicControl6" DataField="ImportTime" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">
                                建檔時間
                            </label>
                            <div class="col-md-10">
                                <asp:DynamicControl CssClass="form-control-static" runat="server" ID="DynamicControl7" DataField="CreateTime" />
                            </div>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <InsertItemTemplate>
                <div class="box-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-md-2">
                                編號
                            </label>
                            <div class="col-md-10">
                                <asp:DynamicControl CssClass="form-control" runat="server" ID="DynamicControlNo" DataField="No" Mode="Insert"  />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">
                                品名
                            </label>
                            <div class="col-md-10">
                                <asp:DynamicControl CssClass="form-control" runat="server" ID="DynamicControl1" DataField="Name" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">
                                數量
                            </label>
                            <div class="col-md-10">
                                <asp:DynamicControl CssClass="form-control" runat="server" ID="DynamicControl2" DataField="Count" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">
                                成本
                            </label>
                            <div class="col-md-10">
                                <asp:DynamicControl CssClass="form-control" runat="server" ID="DynamicControl3" DataField="Amount" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">
                                保管人
                            </label>
                            <div class="col-md-10">
                                <asp:DynamicControl CssClass="form-control" runat="server" ID="DynamicControl4" DataField="User" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">
                                保管地點
                            </label>
                            <div class="col-md-10">
                                <asp:DynamicControl CssClass="form-control" runat="server" ID="DynamicControl5" DataField="Location" />
                            </div>
                        </div>
                    </div>

                </div>
                <div class="box-footer">
                    <input type="reset" class="btn btn-flat btn-default"/>
                    <asp:LinkButton 
                        runat="server"
                        CommandName="Insert"
                        OnClientClick="return window.flag=confirm('即將存檔,是否確定?')"
                        CssClass="btn btn-primary btn-flat pull-right">
                        <i class="fa fa-floppy-o"></i>新增
                    </asp:LinkButton>
                </div>
            </InsertItemTemplate>
        </asp:FormView>


    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
