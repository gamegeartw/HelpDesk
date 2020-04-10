<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="HelpDesk.Web.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Panel runat="server" DefaultButton="LinkButtonSubmit">
        <div class="login-box">
            <!-- /.login-logo -->
            <div class="login-box-body">
                <p class="login-box-msg">Sign in to start your session</p>
                <div>
                    <div class="form-group has-feedback">
                        <input type="text" class="form-control" placeholder="Account" id="account" runat="server" />
                        <span class="glyphicon glyphicon-envelope form-control-feedback"></span>
                    </div>
                    <div class="form-group has-feedback">
                        <input type="password" class="form-control" placeholder="Password" id="password" runat="server" />
                        <span class="glyphicon glyphicon-lock form-control-feedback"></span>
                    </div>
                    <div class="row">
                        <%-- <div class="col-xs-8"> --%>
                        <%--   <div class="checkbox"> --%>
                        <%--     <label> --%>
                        <%--       $1$ <asp:CheckBox runat="server" ID="CheckBoxRemember"/> Remember Me #1# --%>
                        <%--     </label> --%>
                        <%--   </div> --%>
                        <%-- </div> --%>
                        <!-- /.col -->
                        <div class="col-xs-push-8 col-xs-4">
                            <asp:LinkButton CssClass="btn btn-primary btn-block btn-flat" ID="LinkButtonSubmit" runat="server" OnClick="Unnamed1_Click"><i class="fa fa-user-o"></i>&nbsp;登入</asp:LinkButton>
                        </div>
                        <!-- /.col -->
                    </div>
                </div>


                <!-- /.social-auth-links -->

            </div>
            <!-- /.login-box-body -->
        </div>

    </asp:Panel>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
