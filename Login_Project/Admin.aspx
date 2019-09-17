<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Login_Project.Admin" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="Lname" runat="server" Text="Name:"></asp:Label>
        <asp:TextBox ID="Tname" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Lprice" runat="server" Text="Price:"></asp:Label>
        <asp:TextBox ID="Tprice" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Lquantity" runat="server" Text="Quantity:"></asp:Label>
        <asp:TextBox ID="Tquantity" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Lcatagory" runat="server" Text="Catagory:"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>Audio</asp:ListItem>
            <asp:ListItem>Video</asp:ListItem>
            <asp:ListItem>Poratable</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Label ID="Ldescription" runat="server" Text="Description:"></asp:Label>
        <asp:TextBox ID="Tdescription" runat="server" TextMode="MultiLine"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:DropDownList ID="DropDownList2" runat="server">
            <asp:ListItem>Insert</asp:ListItem>
            <asp:ListItem>Update</asp:ListItem>
            <asp:ListItem>Delete</asp:ListItem>
        </asp:DropDownList>
        <br />
        <asp:Button ID="Confirm" runat="server" Text="Confirm" OnClick="Confirm_Click" />
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="Search:"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" OnClick="Button1_Click" />
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" BackColor="#CCCCCC" Width="545px" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black">
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
            <RowStyle BackColor="White" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="Button3" runat="server" Text="Log Out" OnClick="Button3_Click" />
        <asp:Label ID="msg" runat="server"></asp:Label>
        <br />
    </form>
</body>
</html>
