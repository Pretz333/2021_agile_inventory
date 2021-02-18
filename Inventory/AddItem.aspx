<%@ Page Title="Add New Item" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddItem.aspx.cs" Inherits="Inventory.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Fill Out the Fields Below to Add a New Item:</h2>
    <asp:SqlDataSource ID="SQLDSCategories" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Category]" />
    <asp:GridView ID="gvCategories" runat="server" DataSourceID="SQLDSCategories">
    </asp:GridView><br />
    <asp:Label ID="lblCategoryID" runat="server" Text="Enter Item's Category ID: "></asp:Label>
    <asp:TextBox ID="tbCategoryID" runat="server"></asp:TextBox><br /><br />
    <asp:Label ID="lblItemDescription" runat="server" Text="Enter Item Description: "></asp:Label>
    <asp:TextBox ID="tbItemDescription" runat="server"></asp:TextBox><br /><br />
    <asp:Button ID="btnInsertItem" runat="server" OnClick="InsertNewItem" Text="Submit" />
</asp:Content>
