<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Booking.aspx.cs" Inherits="WebApp.Booking" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Book a Holiday</title>

    <style>
        #booking {
            padding: 25px;
            font-family: Arial;
        }
        .title {
            font-weight: bold;
            text-decoration: underline;
        }
        .dateSelect li {
            display: inline-block;
        }
        .dateSelect .from {
            padding-right: 50px;
        }
        .dateSelect .to {
            padding-left: 50px;
        }
        #BackButton {
            margin-right: 50px;
        }
    </style>
</head>

<body>
    <form id="booking" runat="server">
        <div class="title">
            <h2> Book a Holiday </h2>
        </div>
        <br />

        <!-- Date select calendars -->
        <ul class="dateSelect">
            <li class="from"> 
                <b> From </b> 
                <asp:Calendar ID="FromCalendar" runat="server"></asp:Calendar>
            </li>
            <li class="to"> 
                <b> To </b> 
                <asp:Calendar ID="ToCalendar" runat="server"></asp:Calendar>
            </li>
        </ul>

        <br />
        <asp:Button ID="BackButton" runat="server" Text="Back" Width="125" OnClick="BackButton_Click" />
        <asp:Button ID="BookButton" runat="server" Text="Book Holiday" Width="125" OnClick="BookButton_Click" />
    &nbsp;&nbsp;&nbsp;
        <asp:Label ID="MsgLabel" runat="server" Text="Error" Visible="False" Font-Bold="True" ForeColor="#FF3300"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="OkButton" runat="server" Text="Ok" Width="125" OnClick="Ok_Click" Visible="False" />
        </form>
</body>
</html>
