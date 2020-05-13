<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RecoverPassword.aspx.cs" Inherits="HelpDesk.Web.UserPages.RecoverPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView
        runat="server"
        ItemType="HelpDesk.ViewModels.EmployeeViewModel"
        DefaultMode="Insert"
        RenderOuterTable="False"
        InsertMethod="InsertValueAndResetPassword"
        OnItemInserted="FormViewMain_OnItemInserted"
        ID="FormViewMain">
        <InsertItemTemplate>
            <div class="box box-info">
                <div class="box-header with-border">
                    <h3 class="box-title">重置Windows 密碼</h3>
                </div>
                <div class="box-body">
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-md-2">工號：</label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TextBoxEmpNo" CssClass="form-control bg-yellow" Text="<%#: BindItem.EMPNO %>"/>
                            </div>
                        </div>
                    
                        <div class="form-group">
                            <label class="control-label col-md-2">Windows帳號：</label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" ID="TextBoxAccount" CssClass="form-control bg-yellow" Text="<%#: BindItem.CC_MAIL_NAME %>"/>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="box-footer">
                    <asp:LinkButton runat="server" ID="LinkButton_Submit" CommandName="Insert" CssClass="btn btn-primary btn-flat btnRunningWithFlag" OnClientClick="return window.flag=confirm('即將送出並變更密碼,是否確定(send to reset password,sure)?')">
                        <i class="fa fa-search"></i>送出
                    </asp:LinkButton>
                    <%-- <input type="reset" class="btn btn-default btn-flat" value="clear"/> --%>
                </div>
            </div>
        </InsertItemTemplate>
    </asp:FormView>
    <div class="box box-solid">
        <div class="box-header with-border">
            <i class="fa fa-text-width"></i>

            <h3 class="box-title">密碼重置功能說明(Password reset function description):</h3>
        </div>
        <!-- /.box-header -->
        <div class="box-body clearfix">
            <blockquote>
                <ul>
                    <li>Windows 密碼重置功能,會檢查ERP工號及Windows帳號.<br/>Windows password reset will check the ERP empNo and Windows account.</li>
                    <li>Windows 密碼重置後立即生效,您必須重新登入電腦,並使用新的密碼.<br/>The Windows password will take effect immediately after reset, you must log in to the computer again and use the new password.</li>
                    <li>ERP帳號若已停用,無法重置Windows密碼.<br/>If the ERP empNo is disabled, the Windows password cannot be reset.</li>
                </ul>
            </blockquote>
        </div>
        <!-- /.box-body -->
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
