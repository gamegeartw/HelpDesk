<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OnCall.aspx.cs" Inherits="HelpDesk.Web.UserPages.OnCall" %>
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
                OnItemInserting="FormViewMain_OnItemInserting"
                InsertMethod="InsertValue"
                DefaultMode="Insert"
                RenderOuterTable="False"
                ID="FormViewMain">
                <InsertItemTemplate>
                    <div class="form-horizontal">
                        <%-- <div class="form-group"> --%>
                        <%--     <label class="control-label col-md-2">叫修單位(Dept)</label> --%>
                        <%--     <div class="col-md-10"> --%>
                        <%--         <uc1:DeptListComponent runat="server" ID="DeptListComponent" DefaultValues="<%#: BindItem.DeptNo %>" /> --%>
                        <%--     </div> --%>
                        <%-- </div> --%>
                        <div class="form-group">
                            <label class="control-label col-md-2">申請人(User)</label>
                            <div class="col-md-10">
                                <uc1:UsersComponent runat="server" id="UsersComponent" DefaultValues="<%#: BindItem.EmpNo %>" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">叫修項目(Type)</label>
                            <div class="col-md-10">
                                <uc1:OnCallComponent runat="server" ID="OnCallComponent" DefaultValue="<%#: BindItem.OnCallType %>" />
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">連絡電話(ExtNumber)</label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" CssClass="form-control bg-yellow" ID="TextBoxExtNumber" Text="<%#: BindItem.ExtNumber %>"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">叫修原因(Reason)</label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TextBoxOnCallReason" Text="<%#: BindItem.OnCallReason %>" TextMode="MultiLine" Rows="5" CssClass="form-control"/>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="col-md-push-2 col-md-10">
                                <asp:LinkButton runat="server" ID="LinkButtonSubmit" CssClass="btn btn-primary btn-flat btnRunningWithFlag" CommandName="Insert" OnClientClick="return window.flag=confirm('即將送出,是否確定?(Sure to submit?)')">
                                    <i class="fa fa-upload"></i>送出表單(Submit)
                                </asp:LinkButton>
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
