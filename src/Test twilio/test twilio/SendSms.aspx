<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SendSms.aspx.cs" Inherits="test_twilio.SendSms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <h4>To Number</h4>
        <asp:TextBox  ID="ToNumber" runat="server" Enabled="False"></asp:TextBox>
    <h4>SMS Message:</h4>
        <asp:TextBox ID="MyMessage" runat="server" Enabled="False"></asp:TextBox>
        <br/>
        <br/>
        <asp:Button ID="sendMessage"  Text="Send Message" runat="server"  OnClick="sendMessage_OnClick" Enabled="False"/>
    </div>
    </form>
</body>
</html>
