<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GetUserTree.aspx.cs" Inherits="EpointRegisterUser.Pages.RG_Module.GetUserTree" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>无标题页</title>
    <style>
        /*Textbox Watermark*/.unwatermarked
        {
            height: 18px;
            width: 168px;
        }
        .watermarked
        {
            height: 20px;
            width: 170px;
            padding: 2px 0 0 2px;
            border: 1px solid #BEBEBE;
            background-color: #F0F8FF;
            color: gray;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" AllowCustomErrorsRedirect="false"
        EnablePageMethods="true">
    </asp:ScriptManager>
    <script type="text/javascript">
        function AutoSetPValue(check, displayName, roleid) {
            var options = parent.document.getElementById('<%=SelectID %>').options;
            var HidUserList = parent.document.getElementById('<%=HiddenValueID %>');
            var HidUserNameList = parent.document.getElementById('<%=HiddenNameID %>');
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
            HidUserList.value = temp;
            HidUserNameList.value = temp2;
        }

    </script>
    <div id="DivTree" style="padding-left: 5px; padding-top: 5px;">
        <table cellpadding="0" cellspacing="0" border="0" width="100%">
            <tr>
                <td align="left" nowrap>
                    <asp:TextBox ID="txtDisplayName" CssClass="unwatermarked" AutoPostBack='true' Width="200"
                        runat="server" /><br />
                    <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtDisplayName"
                        WatermarkText="搜索人员（支持拼音首字母检索）" WatermarkCssClass="watermarked" />
                </td>
            </tr>
            <tr>
                <td>
                    <epoint:TreeView ID="TreeViewUserList" runat="server" ExpandWhenClick="true" CheckChildCheckBox="true"
                        RunClickEvtWhenCheckChild="false" InputType="CheckBox" ImgFolds="../../../Images/TreeImages"
                        OnTreeNodePopulate="TreeViewUserList_TreeNodePopulate" RootNodeText="用户账号">
                    </epoint:TreeView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
