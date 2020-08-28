<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormsDashboardConfigurator.Default" %>

<%@ Register Assembly="DevExpress.Web.v18.2, Version=18.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Dashboard.v18.2.Web.WebForms, Version=18.2.13.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.DashboardWeb" TagPrefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
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
