<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Connection_Test.aspx.cs" Inherits="Inventory.Connection_Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <br /><br />

        <div>

            <!-- Adding buttons to retrieve the database data -->
            <asp:Button ID="dashBtn" runat="server" Text="DashBoard" OnClick="Retrieve_Dashboard" /><br /><br />
            <asp:Button ID="categoriesBtn" runat="server" Text="Categories" OnClick="Retrieve_Categories" />

            <br />
            <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center"></asp:GridView>
        </div>

    </form>

</body>
</html>
