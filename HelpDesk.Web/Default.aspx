<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HelpDesk.Web._Default" %>

<%@ Register Src="~/Components/FormSearchComponent.ascx" TagPrefix="uc1" TagName="FormSearchComponent" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="col-md-6">
        <div class="box box-info">
            <div class="box-header with-border">
                <h3 class="box-title">常用作業項目</h3>
            </div>
        </div>
    </div>
    <div class="col-md-12">
        <div class="box box-default">
            <div class="box-header with-border">
                <h3 class="box-title">電話號碼查詢</h3>
            </div>
            <div class="box-body">
                <div>
                    <uc1:FormSearchComponent
                        runat="server"
                        ID="FormSearchComponent"
                        ShowItems="SearchText"
                        OnSearch="FormSearchComponent_OnSearch" />
                </div>
                <div style="padding-bottom: 10px">
                    <asp:DataPager runat="server" ID="DataPager1" PagedControlID="ListViewMain">
                        <Fields>
                            <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField CurrentPageLabelCssClass="btn btn-info btn-flat" NextPreviousButtonCssClass="btn btn-default btn-flat" NumericButtonCssClass="btn btn-default btn-flat" />
                            <asp:NextPreviousPagerField ButtonCssClass="btn btn-default btn-flat" ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>

                    </asp:DataPager>
                </div>
                <asp:ListView
                    ID="ListViewMain"
                    ItemType="Landpy.ActiveDirectory.Entity.Object.UserObject"
                    SelectMethod="SelectValue"
                    runat="server">
                    <LayoutTemplate>
                        <table class="table table-responsive table-hover table-bordered">
                            <thead>
                                <tr class="bg-aqua">
                                    <th>單位</th>
                                    <th>姓名</th>
                                    <th>連絡電話</th>
                                </tr>
                            </thead>
                            <tbody>
                                <asp:PlaceHolder runat="server" ID="itemPlaceholder" />
                            </tbody>
                        </table>
                    </LayoutTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#: Item.Department %></td>
                            <td><%#: Item.DisplayName %></td>
                            <td>
                                <asp:DynamicControl runat="server" DataField="Telephone" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>

</asp:Content>
