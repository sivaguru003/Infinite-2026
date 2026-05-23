<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Assignment1.Validator" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Validation Form</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>User Details</h2>

        Name :
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator
            ID="rfvName"
            runat="server"
            ControlToValidate="txtName"
            ErrorMessage="Name Required"
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <br /><br />

        Family Name :
        <asp:TextBox ID="txtFamily" runat="server"></asp:TextBox>

        <asp:RequiredFieldValidator
            ID="rfvFamily"
            runat="server"
            ControlToValidate="txtFamily"
            ErrorMessage="Family Name Required"
            ForeColor="Red">
        </asp:RequiredFieldValidator>

        <br /><br />

        <asp:CompareValidator
            ID="cvName"
            runat="server"
            ControlToValidate="txtName"
            ControlToCompare="txtFamily"
            Operator="NotEqual"
            Type="String"
            ErrorMessage="Name must differ from Family Name"
            ForeColor="Red">
        </asp:CompareValidator>

        <br /><br />

        Address :
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>

        <asp:RegularExpressionValidator
            ID="revAddress"
            runat="server"
            ControlToValidate="txtAddress"
            ValidationExpression=".{2,}"
            ErrorMessage="At least 2 characters"
            ForeColor="Red">
        </asp:RegularExpressionValidator>

        <br /><br />

        City :
        <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>

        <asp:RegularExpressionValidator
            ID="revCity"
            runat="server"
            ControlToValidate="txtCity"
            ValidationExpression=".{2,}"
            ErrorMessage="At least 2 characters"
            ForeColor="Red">
        </asp:RegularExpressionValidator>

        <br /><br />

        Zip Code :
        <asp:TextBox ID="txtZip" runat="server"></asp:TextBox>

        <asp:RegularExpressionValidator
            ID="revZip"
            runat="server"
            ControlToValidate="txtZip"
            ValidationExpression="\d{5}"
            ErrorMessage="Zip code must be 5 digits"
            ForeColor="Red">
        </asp:RegularExpressionValidator>

        <br /><br />

        Phone :
        <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>

        <asp:RegularExpressionValidator
            ID="revPhone"
            runat="server"
            ControlToValidate="txtPhone"
            ValidationExpression="(\d{2}-\d{7})|(\d{3}-\d{7})"
            ErrorMessage="Format: XX-XXXXXXX or XXX-XXXXXXX"
            ForeColor="Red">
        </asp:RegularExpressionValidator>

        <br /><br />

        Email :
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>

        <asp:RegularExpressionValidator
            ID="revEmail"
            runat="server"
            ControlToValidate="txtEmail"
            ValidationExpression="\w+([-.+']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
            ErrorMessage="Invalid Email"
            ForeColor="Red">
        </asp:RegularExpressionValidator>

        <br /><br />

        <asp:Button
            ID="btnCheck"
            runat="server"
            Text="Check"
            OnClick="btnCheck_Click" />

        <br /><br />

        <asp:Label
            ID="lblMessage"
            runat="server"
            ForeColor="Green"
            Font-Bold="true">
        </asp:Label>

        <br /><br />

        <asp:ValidationSummary
            ID="ValidationSummary1"
            runat="server"
            ForeColor="Red" />

    </form>
</body>
</html>