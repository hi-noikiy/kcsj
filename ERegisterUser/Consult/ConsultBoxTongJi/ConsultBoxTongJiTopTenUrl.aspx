<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultBoxTongJiTopTenUrl.aspx.cs"
    Inherits="EpointRegisterUser.Consult.ConsultBoxTongJi.ConsultBoxTongJiTopTenUrl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <script language="JavaScript" src="../../FusionChart/FusionCharts.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <table>
        <tr>
            <td align="left">
                <div id="chartdiv" style="width: 800px;">
                </div>
                <script type="text/javascript">
		   var chart = new FusionCharts("../../FusionChart/FCF_Column3D.swf", "ChartId", "800", "350");
		   chart.setDataURL("readxmldata.aspx?type=<% =Request.QueryString["type"]%>");		   
		   chart.render("chartdiv");
                </script>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
