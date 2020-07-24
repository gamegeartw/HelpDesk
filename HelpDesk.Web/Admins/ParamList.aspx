<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ParamList.aspx.cs" Inherits="HelpDesk.Web.Admins.ParamList" %>

<%@ Register Src="~/Components/FormSearchComponent.ascx" TagPrefix="uc1" TagName="FormSearchComponent" %>
<%@ Register Src="~/Components/ButtonListComponent.ascx" TagPrefix="uc1" TagName="ButtonListComponent" %>
<%@ Register Src="~/Components/DataPageComponent.ascx" TagPrefix="uc1" TagName="DataPageComponent" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:FormSearchComponent runat="server" ID="FormSearchComponent" ShowItems="SearchText" OnSearch="FormSearchComponent_OnSearch" />
    
    <div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">參數清單</h3>
        </div>
        <div class="box-body">

            <uc1:DataPageComponent runat="server" ID="DataPageComponent" PagedControlID="ListViewMain"/>
            <asp:ListView
                ItemType="HelpDesk.Models.ParamData"
                SelectMethod="SelectList"
                UpdateMethod="UpdateData"
                InsertMethod="InsertData"
                DeleteMethod="DeleteData"
                OnItemInserted="ListViewMain_OnItemInserted"
                OnItemUpdated="ListViewMain_OnItemUpdated"
                OnItemDeleted="ListViewMain_OnItemDeleted"
                InsertItemPosition="FirstItem"
                DataKeyNames="Id"
                runat="server"
                ID="ListViewMain">
                <LayoutTemplate>
                    <table class="table table-bordered table-hover table-responsive">
                        <thead>
                        <tr>
                            <th>#</th>
                            <th>Program</th>
                            <th>Key</th>
                            <th>Data</th>
                            <th>IsEnable</th>
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
                            <uc1:ButtonListComponent runat="server" ID="ButtonListComponent" ShowBtns="Edit,Delete" IsSmallIcon="True"/>
                        </td>
                        <td>
                            <%#: Item.Program %>
                        </td>
                        <td>
                            <%#: Item.Key %>
                        </td>
                        <td>
                            <%#: Item.Data %>
                        </td>
                        <td>
                            <asp:DynamicControl runat="server" ID="DynamicControlIsEnable" DataField="IsEnable"/>
                        </td>
                    </tr>
                </ItemTemplate>
                <InsertItemTemplate>
                    <tr>
                        <td>
                            <uc1:ButtonListComponent runat="server" ID="ButtonListComponent" ShowBtns="Insert" IsSmallIcon="True" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TextBoxInsertProgram" CssClass="form-control bg-yellow" Text="<%#: BindItem.Program %>"/>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TextBoxInsertKey" CssClass="form-control bg-yellow" Text="<%#: BindItem.Key %>"/>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TextBoxInsertData" CssClass="form-control" Text="<%#: BindItem.Data %>"/>
                        </td>
                        <td>
                            <asp:DropDownList
                                runat="server"
                                CssClass="form-control"
                                SelectedValue="<%#: BindItem.IsEnable %>"
                                ID="DropDownListInsertIsEnable">
                                <Items>
                                    <asp:ListItem Text="是" Value="True"/>
                                    <asp:ListItem Text="否" Value="False"/>
                                </Items>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </InsertItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <uc1:ButtonListComponent runat="server" ID="ButtonListComponent" ShowBtns="Update,Cancel" IsSmallIcon="True" />
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TextBoxEditProgram" CssClass="form-control bg-yellow" Text="<%#: BindItem.Program %>"/>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TextBoxEditKey" CssClass="form-control bg-yellow" Text="<%#: BindItem.Key %>"/>

                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="TextBoxEditData" CssClass="form-control" Text="<%#: BindItem.Data %>"/>
                        </td>
                        <td>
                            <asp:DropDownList
                                runat="server"
                                CssClass="form-control"
                                SelectedValue="<%#: BindItem.IsEnable %>"
                                ID="DropDownListIsEnable">
                                <Items>
                                    <asp:ListItem Text="是" Value="True"/>
                                    <asp:ListItem Text="否" Value="False"/>
                                </Items>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
