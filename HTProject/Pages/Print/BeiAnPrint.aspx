<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BeiAnPrint.aspx.cs" Inherits="HTProject.Pages.Print.BeiAnPrint" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=10.5.3700.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <%--<rsweb:ReportViewer ID="BeiAn" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" Height="800px" Width="800px">
            <LocalReport ReportPath="Pages\Print\XMRYInfo.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource3" 
                        Name="HeTongInfo_RYOfXM" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>--%>
        <CR:CrystalReportViewer ID="CRV_BeiAn" runat="server" AutoDataBind="True" Height="50px"
            ReportSourceID="CRS_BeiAn" Width="350px" DisplayGroupTree="False" 
            DisplayPage="False" EnableDatabaseLogonPrompt="False" 
            EnableParameterPrompt="False" />
        <CR:CrystalReportSource ID="CRS_BeiAn" runat="server">
            <%--<Report FileName="E:\无锡市建设工程勘察设计合同备案管理系统\HTProject\Pages\Print\HeTongBeiAn.rpt">
            </Report>--%>
        </CR:CrystalReportSource>
    </div>
    </form>
</body>
</html>
