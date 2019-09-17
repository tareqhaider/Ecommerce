<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login_Project.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Login" runat="server">
    <div>
        <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label><asp:TextBox ID="Login_username" runat="server"></asp:TextBox><br/>
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label><asp:TextBox ID="Login_password" runat="server"></asp:TextBox><br/>
        <asp:CheckBox ID="Login_remember" runat="server"/><asp:Label ID="Label3" runat="server" Text="Remember Me"></asp:Label><br/>
        <asp:Button ID="Login_login" runat="server" Text="Login" OnClick="Login_login_Click" /><br/>
        <asp:Button ID="Login_register" runat="server" Text="Register" /><br/>
        <asp:HyperLink ID="Login_forgot" NavigateUrl="RegisterP2.aspx" runat="server">Forgot Password?</asp:HyperLink>
        <br />
        <asp:Label ID="msg" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
