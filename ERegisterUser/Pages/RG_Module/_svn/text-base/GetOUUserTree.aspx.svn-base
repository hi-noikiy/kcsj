<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetOUUserTree.aspx.cs"
    Inherits="EpointRegisterUser.Pages.RG_Module.GetOUUserTree" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
</head>
<body>
    <form id="form1" runat="server">
    <script type="text/javascript">
        function AutoSetPValue(check, displayName, OUTypeid) {
            OUTypeid = OUTypeid.split('&')[0];
            var options = parent.document.getElementById('<%=SelectID %>').options;
            var HidOUTypeList = parent.document.getElementById('<%=HiddenValueID %>');
            var HidOUTypeNameList = parent.document.getElementById('<%=HiddenNameID %>');
            if (check.checked) {
                for (var i = 0; i < options.length; i++) {
                    if (options[i].value == OUTypeid) {
                        return;
                    }
                }
                options.add(new Option(displayName, OUTypeid));
            }
            else {
                for (var i = 0; i < options.length; i++) {
                    if (options[i].value == OUTypeid) {
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
            HidOUTypeList.value = temp;
            HidOUTypeNameList.value = temp2;
        }

    </script>
    <div id="DivTree" style="padding-left: 5px; padding-top: 5px;">
        <epoint:TreeView ID="TreeViewOUUserList" runat="server" InputType="CheckBox" ImgFolds="../../../Images/TreeImages"
            RootNodeText="会员单位" OnTreeNodePopulate="TreeViewOUUserList_TreeNodePopulate" >
        </epoint:TreeView>
    </div>
    </form>
</body>
</html>
