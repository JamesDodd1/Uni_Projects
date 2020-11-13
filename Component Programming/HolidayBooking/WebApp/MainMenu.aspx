<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainMenu.aspx.cs" Inherits="WebApp.MainMenu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Main Menu</title>

    <style>
        #mainMenu {
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
    <form id="mainMenu" runat="server">
        <!-- Page title -->
        <div class="title">
            <h2> <b> <u> Main Menu </u> </b> </h2>
        </div>
        <br />
        
        <!-- Menu buttons -->
        <asp:Button ID="BookingButton" runat="server" OnClick="BookingButton_Click" Text="Book Holiday" Width="125" />
        <br />
        <br />
        
        <asp:Button ID="RequestsButton" runat="server" OnClick="RequestsButton_Click" Text="View Requests" Width="125" />
        <br />
        <br />
        
        <asp:Button ID="LogoutButton" runat="server" OnClick="LogoutButton_Click" Text="Logout" Width="125" />
    </form>
</body>
</html>
