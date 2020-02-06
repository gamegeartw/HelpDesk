<%@ Control Language="C#"
    AutoEventWireup="true"
    CodeBehind="FormViewSearchComponent.ascx.cs"
    Inherits="HelpDesk.Components.FormViewSearchComponent" %>
<div class="box box-info">
    <div class="box-header with-border">
        <h3 class="box-title">
            <asp:Literal runat="server" meta:resourcekey="LiteralBoxTitle" ID="LiteralBoxTitle" /></h3>
    </div>
    <div class="box-body">
        <asp:FormView
            runat="server"
            DefaultMode="Insert"
            RenderOuterTable="False"
            ID="FormViewMain"
            OnItemCreated="FormViewMain_OnItemCreated"
            InsertMethod="InsertFormViewModel"
            ItemType="HelpDesk.ViewModels.FormSearchViewModel">
            <InsertItemTemplate>
                <div class="form-inline">

                    <asp:Panel runat="server" ID="PanelDeptNo" Visible="False">
                        <label class="control-label">
                            <asp:Literal runat="server" meta:resourcekey="LiteralDeptNo" ID="LiteralDeptNo" />
                            部門:
                        </label>
                    </asp:Panel>
                    <asp:Panel runat="server" ID="PanelDocNo" Visible="False">
                        <label class="control-label">
                            <asp:Literal runat="server" meta:resourcekey="LiteralDocNo" ID="LiteralDocNo" />
                        </label>
                        <asp:TextBox runat="server" ID="TextBoxDocNo" CssClass="form-control" Text="<%#: BindItem.DocNo %>" />
                    </asp:Panel>
                    <asp:Panel runat="server" Visible="False" ID="PanelStartDate">
                        <label class="control-label">
                            <asp:Literal runat="server" meta:resourcekey="LiteralStartDate" ID="LiteralStartDate" />
                        </label>
                        <asp:TextBox runat="server" ID="TextBoxStartDate" CssClass="form-control" Text="<%# BindItem.StartDate %>" />
                        <ajaxtoolkit:calendarextender runat="server" targetcontrolid="TextBoxStartDate" format="yyyy/MM/dd" behaviorid="" />
                    </asp:Panel>
                    <asp:Panel runat="server" Visible="False" ID="PanelCloseDate">
                        <label class="control-label">
                            <asp:Literal runat="server" meta:resourcekey="LiteralCloseDate" ID="LiteralCloseDate" />
                        </label>

                        <asp:TextBox runat="server" ID="TextBoxCloseDate" CssClass="form-control" Text="<%# BindItem.CloseDate %>" />
                        <ajaxtoolkit:calendarextender runat="server" targetcontrolid="TextBoxCloseDate" format="yyyy/MM/dd" />
                    </asp:Panel>
                </div>
                <div class="box-footer">
                    <asp:LinkButton runat="server" CssClass="btn btn-info btn-flat running2">
                        <i class="fa fa fa-search"></i>
                        <asp:Literal runat="server" ID="LiteralButtonSearch" meta:resourcekey="LiteralButtonSearch"/>
                    </asp:LinkButton>
                </div>
            </InsertItemTemplate>
        </asp:FormView>
    </div>
</div>
