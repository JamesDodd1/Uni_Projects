<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApp.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>

    <style>
        #login {
            padding: 25px;
            font-family: Arial;
        }
        .title {
            font-weight: bold;
            text-decoration: underline;
        }
    </style>
</head>

<body>
    <form id="login" runat="server">
        <div class="title">
            <h2> Login </h2>
        </div>
        
        <!-- Username -->
        <p> 
            Username: &nbsp;&nbsp;
            <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
        </p>

        <!-- Password -->
        <p>
            Password: &nbsp;&nbsp;
            <asp:TextBox ID="PasswordTextBox" runat="server" TextMode="Password"></asp:TextBox>
        </p>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="errorLabel" runat="server" Font-Bold="True" Font-Overline="False" ForeColor="#FF3300" Text="Login Incorrect" Visible="False"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="LoginButton" runat="server" OnClick="LoginButton_Click" Text="Login" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <p>
            &nbsp;</p>
    </form>
</body>
</html>
