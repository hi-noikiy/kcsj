<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pdfReader.aspx.cs" Inherits="HTProject.Pages.Print.pdfReader" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>无标题页</title>

    <script type="text/javascript">

        window.moveTo(-4, -4);
        window.resizeTo(screen.availWidth + 8, screen.availHeight + 8);
    </script>

    <style type="text/css">
        html
        {
            overflow: hidden;
        }
    </style>
</head>
<body style="overflow: hidden;">
    <form id="form1" runat="server">
    如果您没有安装PDF，请点击【<a href="#" onclick="window.open('reader_win7.rar')"><span style="color: Red">windows7系统安装</span></a>】【<a
        href="#" onclick="window.open('reader_xp.rar')"><span style="color: Red">windowsXP系统安装</span></a>】链接进行安装
    <object classid="clsid:CA8A9780-280D-11CF-A24D-444553540000" width="100%" id="pdf"
        style="overflow: hidden;" border="0">
        <param name="_Version" value="65539" />
        <param name="_ExtentX" value="20108" />
        <param name="_ExtentY" value="10866" />
        <param name="_StockProps" value="0" />
        <param name="SRC" value='../../../AttachStorage/<%=Request["fileName"] %>' />
    </object>
    
    <object data='../../../AttachStorage/<%=Request["fileName"] %>' type="application/pdf"
        width="100%">
        <a href='http://get.adobe.com/cn/reader'>Adobe Reader.pdf </a>
    </object>
    
    </form>

    <script type="text/javascript">
        document.getElementById("pdf").height = screen.availHeight - 85;
    </script>

</body>
</html>
