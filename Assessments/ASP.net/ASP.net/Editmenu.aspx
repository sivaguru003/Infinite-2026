<%@ Page Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Editmenu.aspx.cs"
    Inherits="FoodOrderManagement.EditMenu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Add / Edit Menu</h2>

    Item Name:
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <br /><br />

    Category:
    <asp:TextBox ID="txtCategory" runat="server"></asp:TextBox>
    <br /><br />

    Food Type:
    <asp:DropDownList ID="ddlType" runat="server">
        <asp:ListItem Text="Veg" Value="Veg"></asp:ListItem>
        <asp:ListItem Text="NonVeg" Value="NonVeg"></asp:ListItem>
    </asp:DropDownList>
    <br /><br />

    Price:
    <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
    <br /><br />

    Quantity:
    <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
    <br /><br />

    <asp:Button ID="btnSave"
        runat="server"
        Text="Save"
        OnClick="btnSave_Click" />

</asp:Content>