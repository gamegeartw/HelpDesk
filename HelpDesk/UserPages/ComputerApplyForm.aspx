<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ComputerApplyForm.aspx.cs" Inherits="HelpDesk.UserPages.ComputerApplyForm" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="box box-info">
        <div class="box-header">
            <h3 class="box-title">電腦及設備申請</h3>
        </div>
        <div class="box-body">
            <div class="form-horizontal">
                <div class="form-group">
                    <label class="control-label col-md-2">申請電腦(Apply computer)：</label>
                    <div class="col-md-10">
                        <asp:ListBox runat="server" ID="ListBoxComputers" CssClass="form-control">
                            
                        </asp:ListBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label col-md-2">申請其他項目(Apply items)：</label>
                    <div class="col-md-10">
                        <div class="col-md-12">
                            <asp:ListBox runat="server" ID="ListBoxItems" CssClass="form-control"/>
                        </div>
                        <div class="col-md-12">
                            <asp:TextBox runat="server" ID="TextBoxItems" TextMode="MultiLine" Rows="5"/>
                        </div>
                    </div>
                </div>
                <div class="form-group">
                    <div class="col-md-3">
                        <asp:LinkButton runat="server" ID="LinkButtonSubmit" CssClass="btn btn-primary btn-block btn-flat" OnClientClick="return confirm('即將送出,是否確定?')">
                            <a class="fa fa-floppy-o"></a>送出
                        </asp:LinkButton>
                    </div>
                    
                    <div class="col-md-3">
                        <input type="reset" value="重置"/>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ScriptContent" runat="server">
</asp:Content>
