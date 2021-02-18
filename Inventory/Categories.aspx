<%@ Page Title="Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Inventory.Locations" %>
<asp:Content ID="CategoryContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SQLDSCategories" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Category]" />
    <asp:GridView ID="gvCategories" runat="server" DataSourceID="SQLDSCategories">
    </asp:GridView>
    <br />
    <a runat="server" href="~/AddCategory">Create a Category</a>
</asp:Content>