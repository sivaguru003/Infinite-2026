<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="Assignment1.Product" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Product Store</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Product Store</h2>

        Select Product :

        <asp:DropDownList
            ID="ddlProducts"
            runat="server"
            AutoPostBack="true"
            OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">

            <asp:ListItem Text="Watch" Value="Watch"></asp:ListItem>
            <asp:ListItem Text="Camera" Value="Camera"></asp:ListItem>
            <asp:ListItem Text="Speaker" Value="Speaker"></asp:ListItem>

        </asp:DropDownList>

        <br /><br />

        <asp:Image
            ID="imgProduct"
            runat="server"
            Width="200px"
            Height="200px" />

        <br /><br />

        <asp:Button
            ID="btnPrice"
            runat="server"
            Text="Get Price"
            OnClick="btnPrice_Click" />

        <br /><br />

        <asp:Label
            ID="lblPrice"
            runat="server"
            Font-Bold="true"
            ForeColor="Blue">
        </asp:Label>

    </form>
</body>
</html>