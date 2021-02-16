<%@ Page Title="Items" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Items.aspx.cs" Inherits="Inventory.Locations" %>
<asp:Content ID="ItemContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SQLDSItems" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Item]" />
    <asp:GridView ID="gvItems" runat="server" DataSourceID="SQLDSItems">
    </asp:GridView>
</asp:Content>