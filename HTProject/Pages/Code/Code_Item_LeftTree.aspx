<%@ Page Language="C#" AutoEventWireup="True" CodeBehind="Code_Item_LeftTree.aspx.cs"
    Inherits="HTProject.Pages.Code.Code_Item_LeftTree" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<html>
<head id="Head1" runat="server">
    <base target="main1">
</head>
<body topmargin="0" leftmargin="5">
    <form id="Tree" method="post" runat="server">
    <div>
        <cc1:TreeView ID="TreeView1" RootNodeUrl='Code_Item_List.aspx?ItemCode=' runat="server"
            OnTreeNodePopulate="TreeView1_TreeNodePopulate1" ImgFolds="../../../Images/TreeImages"
            Target="main1" RootNodeText="所有代码项">
        </cc1:TreeView>
    </div>
    </form>
</body>
</html>
