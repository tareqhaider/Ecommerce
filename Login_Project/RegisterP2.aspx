<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterP2.aspx.cs" Inherits="Login_Project.RegisterP2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="Regp2" runat="server">
    <div>
         <asp:Label ID="Label1" runat="server" Text="UserName"></asp:Label><asp:TextBox ID="Regp2_username" runat="server"></asp:TextBox>
         <asp:Label ID="lu" runat="server"></asp:Label>
         <br/>
        <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label><asp:TextBox ID="Regp2_password" runat="server" Width="128px"></asp:TextBox><asp:Label ID="lp" runat="server"></asp:Label><br/>
         <asp:Label ID="Label3" runat="server" Text="Secret Question"></asp:Label>
        <asp:DropDownList ID="Regp2_question" runat="server" Height="19px" Width="290px">
            <asp:ListItem>What is the name of your favorite pet?</asp:ListItem>
            <asp:ListItem>What is the name of your last played game?</asp:ListItem>
         </asp:DropDownList><br/>
         <asp:Label ID="Label4" runat="server" Text="Answer"></asp:Label>
         <asp:TextBox ID="Regp2_answer" runat="server" Width="150px"></asp:TextBox><asp:Label ID="la" runat="server"></asp:Label>
         <br/>
        <asp:Button ID="Regp2_confirm" runat="server" Text="Confirm" OnClick="Regp2_confirm_Click" /><br/>
        <asp:Button ID="Regp2_back" runat="server" Text="Back" />
         <br />
         <asp:Label ID="msg" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
