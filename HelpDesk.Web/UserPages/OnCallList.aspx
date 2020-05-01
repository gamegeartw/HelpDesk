<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OnCallList.aspx.cs" Inherits="HelpDesk.Web.UserPages.OnCallList" %>

<%@ Register Src="~/Components/FormSearchComponent.ascx" TagPrefix="uc1" TagName="FormSearchComponent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:FormSearchComponent runat="server" ID="FormSearchComponent" ShowItems="SearchText" OnSearch="FormSearchComponent_OnSearch" />
    <div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">叫修案件清單</h3>
        </div>
        <div class="box-body">
            <asp:ListView 
                ItemType="HelpDesk.ViewModels.ServiceOnCallViewModel"
                SelectMethod="SelectValue"
                runat="server" 
                ID="ListViewMain">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover table-responsive">
                        <thead>
                        <tr>
                            <th>#</th>
                            <th>編號</th>
                            <th>送修單位</th>
                            <th>送修人員</th>
                            <th>送修時間</th>
                            <th>處理人員</th>
                            <th>目前進度</th>
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
                            <asp:LinkButton runat="server" ID="LinkButtonDetail" CssClass="btn btn-info btn-flat">
                                <i class="fa fa-list"></i>明細
                            </asp:LinkButton>
                        </td>
                        <td><%#: Item.DocNo %></td>
                        <td><%#: Item.DeptNo %>-<%#: Item.DeptName %></td>
                        <td><%#: Item.EmpNo %>-<%#: Item.EmpName%></td>
                        <td><asp:DynamicControl runat="server" ID="DynamicControlDate" DataField="CreateTime" DataFormatString="{0:yyyy/MM/dd HH:mm:ss}"/></td>
                        <td><%#: Item.ProcessUser %></td>
                        <td><%#: Item.ProcessStatus %></td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
