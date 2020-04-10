<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="HelpDesk.Web.Admins.UserDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">使用者明細</h3>
        </div>
        <div class="box-body">
            <asp:FormView 
                ID="FormViewAD"
                ItemType="Landpy.ActiveDirectory.Entity.Object.UserObject"
                SelectMethod="SelectUser"
                OnItemCommand="FormViewAD_OnItemCommand"
                RenderOuterTable="False"
                runat="server">
                <ItemTemplate>
                    <div class="btn-group">
                        <a href="#" class="btn btn-info btn-flat" onclick="history.back();">
                            <i class="fa fa-backward"></i>&nbsp;回上一頁
                        </a>
                        <a href="#" class="btn btn-info btn-flat" data-toggle="modal" data-target="#modal-default">
                            <i class="fa fa-edit"></i>&nbsp;變更密碼
                        </a>

                    </div>
                    <table class="table table-hover table-responsive table-bordered">
                        <tr>
                            <th>帳號</th>
                            <td><%#: Item.SAMAccountName %></td>
                            <th>顯示名稱</th>
                            <td><%#: Item.DisplayName %></td>
                        </tr>
                        <tr>
                            <th>是否啟用</th>
                            <td><%#: Item.IsEnabled %></td>
                            <th>連絡電話</th>
                            <td><%#: Item.Telephone %></td>
                        </tr>
                        <tr>
                            <th>主管</th>
                            <td><%#: Item.Manager %></td>
                            <th>部門</th>
                            <td><%#: Item.Department %></td>
                        </tr>
                        <tr>
                            <th>電子郵件</th>
                            <td><%#: Item.Email %></td>
                            <th>註記</th>
                            <td><%#: Item.Description %></td>
                        </tr>
                        <tr>
                            <th>系統管理員</th>
                            <td><%#: Item.IsDomainAdmin %></td>
                            <th>帳號管理員</th>
                            <td><%#: Item.IsAccountOperator %></td>
                        </tr>
                        <tr>

                        </tr>


                    </table>
                    
                    <div class="modal fade in" id="modal-default" style="display: none; padding-right: 16px;">
                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                                        <span aria-hidden="true">×</span></button>
                                    <h4 class="modal-title">變更密碼</h4>
                                </div>
                                <div class="modal-body">
                                    <p>
                                        <div class="form-horizontal">
                                            <label class="control-label">密碼:</label>
                                            <asp:TextBox
                                                runat="server"
                                                ID="TextBoxResetPassword"
                                                AutoCompleteType="None"
                                                Required="required"
                                                CssClass="form-control"/>
                                        </div>

                                    </p>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default pull-left btn-flat" data-dismiss="modal">Close</button>
                                    <asp:LinkButton
                                        runat="server"
                                        CommandName="ResetPassword"
                                        CommandArgument="<%#: Item.SAMAccountName %>"
                                        CssClass="btn btn-primary btn-flat btnRunningWithFlag"
                                        OnClientClick="return window.flag=confirm('即將變更,是否確定?')"
                                        ID="LinkButtonSubmit">
                                        <i class="fa fa-save"></i>&nbsp;變更密碼
                                    </asp:LinkButton>
                                </div>
                            </div>
                            <!-- /.modal-content -->
                        </div>
                        <!-- /.modal-dialog -->
                    </div>
                </ItemTemplate>
            </asp:FormView>
            
            <asp:FormView 
                ID="FormViewDBUser"
                ItemType="HelpDesk.Models.UserData"
                SelectMethod="SelectDBUser"
                runat="server">
                <ItemTemplate>
                    <table class="table table-hover table-responsive table-bordered"></table>
                </ItemTemplate>
            </asp:FormView>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
