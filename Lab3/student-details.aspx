<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="student-details.aspx.cs" Inherits="Lab3.student_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h1>Student Details</h1>
    <div class="form-group">
        <label for="txtFirstName" class="col-sm-3 control-label">First Name:</label>
        <asp:TextBox ID="txtFirstName" runat="server" required />
    </div>
    <div class="form-group">
        <label for="txtLastName" class="col-sm-3 control-label">Last Name:</label>
        <asp:TextBox ID="txtLastName" runat="server" required />
    </div>
    <div class="form-group">
        <label for="eDate" class="col-sm-3 control-label">Enrollment Date:</label>
        <asp:TextBox ID="eTxtDate" runat="server" type="datetime-local" required />
        <asp:button ID="btnCal" runat="server" text="Calendar" OnClick="btnCal_Click" CssClass="btn btn-info" />
        <asp:calendar ID="eCal" runat="server" OnSelectionChanged="eCal_SelectionChanged"></asp:calendar>
    </div>
    <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_Click" cssclass="btn btn-success" />
</asp:Content>
