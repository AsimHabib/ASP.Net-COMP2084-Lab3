<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="department-details.aspx.cs" Inherits="Lab3.department_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Department Details</h1>
    <div class="form-group">
        <label for="txtName" class="col-sm-3 control-label">Name:</label>
        <asp:TextBox ID="txtName" runat="server" required />
    </div>
    <div class="form-group">
        <label for="txtBudget" class="col-sm-3 control-label">Budget:</label>
        <asp:TextBox ID="txtBudget" runat="server" required Type="number" min="0" MaxLength="999999" step="1" />
    </div>
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" />
</asp:Content>
