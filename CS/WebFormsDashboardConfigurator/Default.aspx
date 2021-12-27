<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsDashboardConfigurator.Default" %>

<!DOCTYPE html>

<html>
<head runat="server">
    <title>Web Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="position: absolute; left: 0; right: 0; top:0; bottom:0;">
            <dx:ASPxDashboard ID="ASPxDashboard1" runat="server" Width="100%" Height="100%"  ClientInstanceName="webDashboard">
            </dx:ASPxDashboard>
        </div>
    </form>
</body>
</html>
