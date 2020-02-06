<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DevicesManatain.aspx.cs" Inherits="HelpDesk.UserPages.DevicesManatain" %>

<%@ Register Src="~/Components/FormViewSearchComponent.ascx" TagPrefix="uc1" TagName="FormViewSearchComponent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:FormViewSearchComponent runat="server" ID="FormViewSearchComponent" />
    <asp:Panel runat="server" ID="PanelMain">
        <div class="box box-info">
            <div class="box-header with-border">
                <h3 class="box-title">清單列表</h3>
            </div>
            <div class="box-body">
                <div>
                    <asp:LinkButton runat="server" ID="LinkButtonCreate" CssClass="btn btn-flat btn-primary"><i class="fa fa-file"></i>新建</asp:LinkButton>
                    <asp:LinkButton runat="server" ID="LinkButtonPrint" CssClass="btn btn-flat btn-info"><i class="fa fa-print"></i>列印</asp:LinkButton>
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
                            <td><%#: Item.No %></td>
                            <td><%#: Item.Name %></td>
                            <td><%#: Item.Count %></td>
                            <td><%#: Item.Amount%></td>
                            <td><%#: Item.User %></td>
                            <td><%#: Item.Location %></td>
                            <td><%#: Item.ImportTime %></td>
                            <td><%#: Item.CreateTime %></td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>

    </asp:Panel>

    <asp:Panel runat="server" ID="PanelEdit" Visible="False">
        <asp:FormView 
            ID="FormViewMain"
            ItemType="HelpDesk.ViewModels.DeviceViewModel"
            InsertMethod="Insert"
            UpdateMethod="Update"
            SelectMethod="SelectItem"
            DataKeyNames="No"
            DefaultMode="ReadOnly"
            runat="server">

        </asp:FormView>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
