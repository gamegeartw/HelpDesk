<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RegisterADAccount.aspx.cs" Inherits="HelpDesk.Web.UserPages.RegisterADAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box box-info">
        <div class="box-header with-border">
            <h3 class="box-title">AD帳號申請</h3>
        </div>
        <div class="box-body">
            <asp:FormView
                ItemType="HelpDesk.ViewModels.ADUserViewModel"
                OnItemCommand="OnItemCommand"
                InsertMethod="InsertValue"
                OnItemInserting="OnItemInserting"
                runat="server"
                DefaultMode="Insert">
                <InsertItemTemplate>
                    <div class="form-horizontal">
                        <div class="form-group">
                            <label class="control-label col-md-2">工號(WorkNo):</label>
                            <div class="col-md-8">
                                <asp:TextBox
                                    runat="server"
                                    CssClass="form-control bg-yellow"
                                    Text="<%#: BindItem.EmpNo %>"
                                    ID="TextBoxWorkNo" />
                            </div>
                            <div class="col-md-2">
                                <asp:LinkButton runat="server" ID="LinkButtonCheckAccount">
                                    <i class="fa fa-check"></i>檢查工號
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">連絡電話(ext number):</label>
                            <div class="col-md-10">
                                <asp:TextBox
                                    runat="server"
                                    CssClass="form-control bg-yellow"
                                    Text="<%#: BindItem.ExtNumber %>"
                                    ID="TextBox1" />
                            </div>
                            <div class="col-md-pull-2 col-md-10">
                                <small><span class="text-red">請填入分機號碼,如果沒有分機號碼,請填輔導員連絡電話(Fill in the extension number, if there is no extension number, please fill in the telephone number of the counselor)</span></small>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="control-label col-md-2">帳號名稱(Account):</label>
                            <div class="col-md-10">
                                <asp:TextBox runat="server" CssClass="form-control bg-yellow" ID="TextBoxAccount" ToolTip="格式:英文名.英文姓(format:firstName.lastName)" />
                            </div>
                            <div class="col-md-pull-2 col-md-10">
                                <small><span class="text-red">AD帳號等於Email帳號(AD Account is also email account)</span></small>
                            </div>
                        </div>
                        <div class="form-group">
                            <asp:LinkButton runat="server" ID="LinkButtonSubmit" OnClientClick="return window.flag=confirm('即將送出,是否確定?')"></asp:LinkButton>
                        </div>
                    </div>
                </InsertItemTemplate>
            </asp:FormView>
            <asp:Panel runat="server" Visible="False" ID="PanelDetails">
                <div class="box box-info">
                    <div class="box-header with-border">
                        <h3 class="box-title">申請結果</h3>
                    </div>
                    <div class="box-body">
                        <asp:Literal runat="server" ID="LiteralDetails"/>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentJs" runat="server">
</asp:Content>
