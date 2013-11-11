<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_XMBeiAn.RG_XMBeiAn_Add" Title="新增数据记录" CodeBehind="RG_XMBeiAn_Add.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script>
        function window.document.onkeydown() {
            if (event.keyCode == 13) {
                if (window.document.activeElement.tagName != 'TEXTAREA') {
                    event.keyCode = 9;
                }
            }
        }
        function MyPageValidate() {
            var message = '确定项目所属行业/专项/事务所是[' + document.getElementById('<%=ZiZhiDJ_2021.ClientID %>').value + ']?\r\n 保存后该内容将不允许再修改！';
            var bRet = false;
            if (Page_ClientValidate()) {
                return window.confirm(message);
            }
            else {
                bRet = false;
            }
            return bRet;
        }
    </script>

    <epoint:AjaxFileUpload ID="AjaxFileUpload1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="Div_ControlNoTop">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <epoint:Button ID="btnAdd" runat="server" Text="添加保存" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnAdd_Click" OnClientClick="return MyPageValidate();"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                                Text="取消添加" runat="server" CausesValidation="false" OnClientClick="window.close();">
                            </epoint:Button>
                        </td>
                        <td style="width: 90%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="4">
                            <asp:Label ID="lblTips" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td height="36" style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x;"
                        align="center" valign="middle">
                        <%=ViewState["TableName"]%>
                    </td>
                </tr>
                <tr>
                    <td id="tdContainer" valign="top" align="center" runat="server">
                        <table width="100%" cellspacing="1" align="center" id="tabContent">
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    项目名称<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="XMName_2021" runat="server" MaxLength="500" AllowNull="false"
                                        Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    项目类别<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <asp:RadioButtonList ID="XMLB_2021" runat="server" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    项目地址<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="XMAddress_2021" runat="server" MaxLength="500" AllowNull="false"
                                        Width="80%"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    项目所在地区<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="XMAdd_2021" runat="server" Width="80%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    总投资<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="ToTalMoney_2021" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px" AllowNull="false" Width="80%"><NumericProperty TextBoxType="Numeric" Precision="4" /></epoint:NumericTextBox>万元
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    规模<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="GuiMoDJ_2021" runat="server" Width="80%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    技术指标<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="ZhiBiao_2021" runat="server" MaxLength="500" AllowNull="false"
                                        Width="80%" TextMode="MultiLine" Height="50px"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%" rowspan="2">
                                    建设单位<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left" rowspan="2">
                                    <epoint:TextBox ID="JSDWName_2021" runat="server" MaxLength="500" AllowNull="false"
                                        Width="80%"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    项目联系人
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="XMLXR_JS_2021" runat="server" MaxLength="50" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    联系人电话
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LXDH_JS_2021" runat="server" MaxLength="50" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%" rowspan="3">
                                    项目所属行业/专项<br />
                                    /事务所<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left" rowspan="3">
                                    <asp:DropDownList ID="ZiZHiDJ" runat="server" Width="80%" Height="100%" OnSelectedIndexChanged="ZiZHiDJ_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                    <br />
                                    <epoint:TextBox ID="ZiZhiBH_2021" runat="server" MaxLength="50" AllowNull="false"
                                        Width="80%" contenteditable="false"></epoint:TextBox>
                                    <epoint:TextBox ID="ZiZhiDJ_2021" runat="server" MaxLength="500" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="ZiZhiDJCode_2021" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="ZiZhiDJRowGuid_2021" runat="server" MaxLength="500" Style="display: none"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    项目联系人<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="XMLXR_KS_2021" runat="server" MaxLength="50" AllowNull="false"
                                        Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    联系电话<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LXDH_KS_2021" runat="server" MaxLength="50" AllowNull="false"
                                        Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    手机号码<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="SJ_KS_2021" runat="server" MaxLength="50" AllowNull="false" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    合同价格<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="HeTongMoney_2021" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px" AllowNull="false" Width="80%"><NumericProperty TextBoxType="Numeric" Precision="4" /></epoint:NumericTextBox>万元
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    项目负责人<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="XMFZR_2021" runat="server" MaxLength="50" AllowNull="false" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    备注
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="BeiZhu_2021" runat="server" MaxLength="500" Width="80%" TextMode="MultiLine"
                                        Height="50px"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td class="TableSpecial1" width="15%">
                                    审核状态
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="Status_2021" runat="server" Width="100%" Height="100%">
                                    </asp:DropDownList>
                                    <epoint:TextBox ID="DWGuid_2021" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="DWName_2021" runat="server" MaxLength="500"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    删除状态
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="DelStatus_2021" runat="server" Width="100%" Height="100%">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblZiZhiType" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                ShowMessageBox="True"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
