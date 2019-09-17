<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterP1.aspx.cs" Inherits="Login_Project.RegisterP1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Regp1" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="Phone"></asp:Label><asp:TextBox ID="Regp1_phone" runat="server"></asp:TextBox>
        <asp:Label ID="lp" runat="server" Text=""></asp:Label>
        <br/>
        <asp:Label ID="Label2" runat="server" Text="Email"></asp:Label><asp:TextBox ID="Regp1_email" runat="server"></asp:TextBox>
        <asp:Label ID="le" runat="server" Text=""></asp:Label>
        <br />
        <asp:Label ID="msg" runat="server"></asp:Label>
        <br/>
        <asp:Button ID="Regp1_next" runat="server" Text="Next" OnClick="Regp1_next_Click" />
        <asp:Button ID="Regp1_check" runat="server" Text="Check" OnClick="Regp1_check_Click" />
        <br/>
        <asp:Button ID="Regp1_back" runat="server" Text="Back" />
    </div>
    </form>
</body>
</html>
