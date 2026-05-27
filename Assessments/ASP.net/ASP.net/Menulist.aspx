<%@ Page Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="MenuList.aspx.cs"
    Inherits="FoodOrderManagement.MenuList" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Menu Items</h2>

    <asp:GridView ID="GridView1"
        runat="server"
        AutoGenerateColumns="False"
        BorderWidth="1">

        <Columns>

            <asp:BoundField DataField="menuid"
                HeaderText="ID" />

            <asp:BoundField DataField="itemname"
                HeaderText="Name" />

            <asp:BoundField DataField="category"
                HeaderText="Category" />

            <asp:BoundField DataField="foodtype"
                HeaderText="Food Type" />

            <asp:BoundField DataField="price"
                HeaderText="Price" />

            <asp:BoundField DataField="quantity"
                HeaderText="Quantity" />

        </Columns>

    </asp:GridView>

</asp:Content>