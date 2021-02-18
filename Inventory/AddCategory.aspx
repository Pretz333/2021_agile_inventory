<%@ Page Title="Add New Category" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCategory.aspx.cs" Inherits="Inventory.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SQLDSCategories" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Category]" />
    <h2>Fill Out the Field Below to Add a New Category:</h2>
    <asp:Label ID="lblCategoryDescription" runat="server" Text="Enter Category Description: "></asp:Label>
    <asp:TextBox ID="tbCategoryDescription" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="btnInsertCategory" runat="server" OnClick="InsertNewCategory" Text="Submit" />
</asp:Content>
