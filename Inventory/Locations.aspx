<%@ Page Title="Locations" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Locations.aspx.cs" Inherits="Inventory.Locations" %>
<asp:Content ID="LocationContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:SqlDataSource ID="SQLDSLocations" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [Location]" />
    <asp:GridView ID="gvLocations" runat="server" DataSourceID="SQLDSLocations">
    </asp:GridView>
    
    <asp:Button ID="btnExport" runat="server" OnClick="Button2_Click" Text="Export" />
    
    <br />
    <br />
    <asp:Label ID="lblInsert" runat="server" Text="Insert New Location: "></asp:Label>
    <asp:TextBox ID="tbInsert" runat="server"></asp:TextBox>
    <asp:Button ID="btnInsert" runat="server" OnClick="InsertNew" Text="Insert" />
</asp:Content>