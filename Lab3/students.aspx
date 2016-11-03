<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="students.aspx.cs" Inherits="Lab3.students" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Students</h1>
    <a href="student-details.aspx">Add a Student</a>   
    <asp:GridView ID="grdStudents" runat="server" CssClass="table table-striped" autogeneratecolumns="false"
        DataKeyName="Student_ID" OnRowDeleting="grdStudents_RowDeleting">
        <Columns>
            <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
            <asp:BoundField DataField="LastName" HeaderText="Last Name" />
            <asp:BoundField DataField="FirstMidName" HeaderText="First Name" />
            <asp:BoundField DataField="EnrollmentDate" HeaderText="Date Enrolled" /> 
            <asp:HyperLinkField HeaderText="Edit" Text="Edit" NavigateUrl="~/student-details.aspx"
                DataNavigateUrlFields="StudentID" DataNavigateUrlFormatString="~/student-details.aspx?StudentID={0}" />
            <asp:CommandField HeaderText="Delete" ShowDeleteButton="true" ControlStyle-CssClass="confirmation" />            
        </Columns>
    </asp:GridView>
</asp:Content>
