<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPass.aspx.cs" Inherits="Login_Project.ResetPass" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="U" runat="server" Text="Username:"></asp:Label><asp:TextBox ID="TU" runat="server"></asp:TextBox><br/>
        <asp:Label ID="Q" runat="server" Text="Security Question:"></asp:Label><asp:Label ID="LQ" runat="server"></asp:Label><br/>
        <asp:Label ID="LA" runat="server" Text="Answer"></asp:Label><asp:TextBox ID="TA" runat="server"></asp:TextBox><br/>
        <asp:Label ID="LNP" runat="server" Text="New Password:"></asp:Label><asp:TextBox ID="TNP" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text="No spaces"></asp:Label>
        <br/>
        <asp:Label ID="LCP" runat="server" Text="Confirm Password:"></asp:Label><asp:TextBox ID="TCP" runat="server"></asp:TextBox>
        <br />
        <br/>
        
        <asp:Button ID="CFM" runat="server" Text="Confirm" OnClick="CFM_Click" />
        <asp:Label ID="msg" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
