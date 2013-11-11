<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="ZZZYGX_LeftTree.aspx.cs"
    Inherits="HTProject.Pages.RG_XMBeiAn.ZZZYGX_LeftTree" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<html>
<head id="Head1" runat="server">
    <base target="main1">
</head>
<body topmargin="0" leftmargin="5">
    <form id="Tree" method="post" runat="server">
    <div>
        <cc1:TreeView ID="TreeView1" RootNodeUrl='ZZZYGX_List.aspx?ItemCode=' runat="server" ImgFolds="../../../Images/TreeImages" Target="main1" RootNodeText="资质"
            OnTreeNodePopulate="TreeView1_TreeNodePopulate1">
        </cc1:TreeView>
    </div>
    </form>
</body>
</html>
