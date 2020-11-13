<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Requests.aspx.cs" Inherits="WebApp.Requests" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Requests</title>

    <style>
        #request {
            padding: 25px;
            font-family: Arial;
        }
        .title {
            font-weight: bold;
            text-decoration: underline;
        }
        .list li {
            display: inline-block;
        }
        .dates {
            width: 50%;
        }
        .status {
            width: 20%;
        }
        .Canceled {
            color: dodgerblue;
        }
        .Approved {
            color: limegreen;
        }
        .Denied {
            color: red;
        }
        #BackButton {
            margin-right: 50px;
        }
    </style>
</head>
<body>
    <form id="request" runat="server">
        <div class="title">
            <h2> Requests </h2>
        </div>
        <br />

        <div id="RequestList" runat="server">
            
        </div>
        <br />
        <asp:Button ID="BackButton" runat="server" Text="Back" Width="125" OnClick="BackButton_Click" />
    </form>
</body>
</html>
