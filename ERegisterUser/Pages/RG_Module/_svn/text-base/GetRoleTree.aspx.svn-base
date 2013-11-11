<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetRoleTree.aspx.cs" Inherits="EpointRegisterUser.Pages.RG_Module.GetRoleTree" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript">
        function AutoSetPValue(check, displayName, roleid) {
            var options = parent.document.getElementById('<%=SelectID %>').options;
            var HidRoleList = parent.document.getElementById('<%=HiddenValueID %>');
            var HidRoleNameList = parent.document.getElementById('<%=HiddenNameID %>');
            if (check.checked) {
                for (var i = 0; i < options.length; i++) {
                    if (options[i].value == roleid) {
                        return;
                    }
                }
                options.add(new Option(displayName, roleid));
            }
            else {
                for (var i = 0; i < options.length; i++) {
                    if (options[i].value == roleid) {
                        options[i] = null; i--;
                    }
                }
            }
            options = parent.document.getElementById('<%=SelectID %>').options;
            var temp = "";
            var temp2 = "";
            for (var i = 0; i < options.length; i++) {
                temp = temp + options[i].value + ";";
                temp2 = temp2 + options[i].text + ";";
            }
            HidRoleList.value = temp;
            HidRoleNameList.value = temp2;
        }

    </script>
    <div id="DivTree" style="padding-left: 5px; padding-top: 5px;">
        <epoint:TreeView ID="TreeViewRoleList" runat="server" CheckChildCheckBox="false" InputType="CheckBox" ImgFolds="../../../Images/TreeImages"
            OnTreeNodePopulate="TreeViewRoleList_TreeNodePopulate" RootNodeText="账号类型">
        </epoint:TreeView>
    </div>
    </form>
</body>
</html>
