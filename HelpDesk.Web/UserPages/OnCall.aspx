<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OnCall.aspx.cs" Inherits="HelpDesk.Web.UserPages.OnCall" %>

<%@ Register Src="~/Components/DeptListComponent.ascx" TagPrefix="uc1" TagName="DeptListComponent" %>
<%@ Register Src="~/Components/UsersComponent.ascx" TagPrefix="uc1" TagName="UsersComponent" %>
<%@ Register Src="~/Components/OnCallComponent.ascx" TagPrefix="uc1" TagName="OnCallComponent" %>



<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">叫修作業(Service OnCall)</h3>
        </div>
        <div class="box-body">
            <asp:FormView
                ItemType="HelpDesk.ViewModels.ServiceOnCallViewModel"
                runat="server"
                OnItemCreated="FormViewMain_OnItemCreated"
                InsertMethod="InsertValue"
                DefaultMode="Insert"
                RenderOuterTable="False"
                ID="FormViewMain">
                <InsertItemTemplate>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-md-2">叫修單位(Dept)</label>
                            <div class="col-md-10">
                                <uc1:DeptListComponent runat="server" ID="DeptListComponent" DefaultValues="<%#: BindItem.EmpNo %>" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">申請人(User)</label>
                            <div class="col-md-10">
                                <uc1:UsersComponent runat="server" id="UsersComponent" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">叫修項目(Type)</label>
                            <div class="col-md-10">
                                <uc1:OnCallComponent runat="server" ID="OnCallComponent" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">叫修原因(Reason)</label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TextBoxOnCallReason" Text="<%#: BindItem.OnCallReason %>" TextMode="MultiLine" Rows="5" CssClass="form-control"/>
                            </div>
                        </div>
                    </div>
                    
                    
                </InsertItemTemplate>

            </asp:FormView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
