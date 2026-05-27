<%@ Page Title="" Language="C#"
    MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="MenuDetails.aspx.cs"
    Inherits="FoodOrderManagement.MenuDetails" %>

<asp:Content ID="Content1"
    ContentPlaceHolderID="MainContent"
    runat="server">

    <h2>Menu Details</h2>

    <asp:DetailsView ID="DetailsView1"
        runat="server"
        AutoGenerateRows="True">
    </asp:DetailsView>

</asp:Content>