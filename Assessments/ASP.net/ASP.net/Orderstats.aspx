<%@ Page Title="" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="OrderStats.aspx.cs"
    Inherits="FoodOrderManagement.OrderStats" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Order Statistics</h2>

    <br />

    <b>Total Visitors:</b>

    <asp:Label ID="lblVisitors"
        runat="server"
        ForeColor="Blue">
    </asp:Label>

    <br /><br />

    <b>Current Active Users:</b>

    <asp:Label ID="lblUsers"
        runat="server"
        ForeColor="Green">
    </asp:Label>

</asp:Content>