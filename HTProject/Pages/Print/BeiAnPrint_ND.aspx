<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BeiAnPrint_ND.aspx.cs" Inherits="HTProject.Pages.Print.BeiAnPrint_ND" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <CR:CrystalReportViewer ID="CRV_BeiAn" runat="server" AutoDataBind="True" Height="50px"
            ReportSourceID="CRS_BeiAn" Width="350px" DisplayGroupTree="False" 
            DisplayPage="False" EnableDatabaseLogonPrompt="False" 
            EnableParameterPrompt="False" />
        <CR:CrystalReportSource ID="CRS_BeiAn" runat="server">
            
        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
