<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages.RG_OU.RG_OU_Add" Title="�������ݼ�¼" CodeBehind="RG_OU_Add.aspx.cs" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TreeViewControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Ajax.FileUpload" Namespace="Epoint.Ajax.FileUpload"
    TagPrefix="cc1" %>
<%@ Register Src="../../Ascx/CaiLiao.ascx" TagName="CaiLiao" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script>
        function window.document.onkeydown() {
            if (event.keyCode == 13) {
                if (window.document.activeElement.tagName != 'TEXTAREA') {
                    event.keyCode = 9;
                }
            }
        }
    </script>
    <cc1:AjaxFileUpload ID="AjaxFileUpload1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="Div_ControlNoTop">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <epoint:Button ID="btnAdd" runat="server" Text="��ӱ���" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnAdd_Click"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                                Text="ȡ�����" runat="server" CausesValidation="false" OnClientClick="window.close();">
                            </epoint:Button>
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
                        <table width="100%" cellspacing="1" align="center">
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ҵ��������
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="EnterpriseName_2017" runat="server" MaxLength="200" AllowNull="false"
                                        CssClass="inputtxt" Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ҵӢ������
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="EnterpriseEName_2017" runat="server" MaxLength="500"
                                        CssClass="inputtxt" Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ע���̱�
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <%--<epoint:CtlMisAttachments ID="ShangBiao_2017" width="100%" runat="server" AttachDescCode='' />--%>
                                    <uc1:CaiLiao ID="CL_SB" runat="server" YeWuMC="��ҵ-ע���̱�" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    Logo
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <%--<epoint:CtlMisAttachments ID="Logo_2017" width="100%" runat="server" AttachDescCode='' />--%>
                                    <uc1:CaiLiao ID="CL_Logo" runat="server" YeWuMC="��ҵ-Logo" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��������
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="ChengLiDate_2017" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ע���
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextTreeView ID="tvZCD" runat="server" AllowNull="false" DivHeight="450px"
                                        RelationName="ע�����" DivWidth="180px" ImgFolds="../../../Images/TreeImages" OnTreeNodePopulate="RegionTreeView_TreeNodePopulate"
                                        RootNodeText="��������ѡ��" TextCssClass="Inputtxt" Width="200px" OnlyReturnLeaf="true"
                                        InputType="Radio">
                                    </epoint:TextTreeView>
                                    <epoint:TextBox ID="ZhuCeDi_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="ZhuCeDiCode_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ע����ϸ��ַ
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="ZhuCeDi_XX_2017" runat="server" MaxLength="200" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��Ӫ��1
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextTreeView ID="tvYYD1" runat="server" DivHeight="450px"
                                        DivWidth="180px" ImgFolds="../../../Images/TreeImages" OnTreeNodePopulate="RegionTreeView_TreeNodePopulate"
                                        RootNodeText="��������ѡ��" TextCssClass="Inputtxt" Width="300px" OnlyReturnLeaf="true"
                                        InputType="Radio">
                                    </epoint:TextTreeView>
                                    <epoint:TextBox ID="YunYingDi1_2017" runat="server" MaxLength="200" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="YunYingDi1Code_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��Ӫ��ϸ��ַ1
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextBox ID="YunYingDi1_XX_2017" runat="server" MaxLength="200" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��Ӫ��2
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextTreeView ID="tvYYD2" runat="server" DivHeight="450px"
                                       DivWidth="180px" ImgFolds="../../../Images/TreeImages" OnTreeNodePopulate="RegionTreeView_TreeNodePopulate"
                                        RootNodeText="��������ѡ��" TextCssClass="Inputtxt" Width="300px" OnlyReturnLeaf="true"
                                        InputType="Radio">
                                    </epoint:TextTreeView>
                                    <epoint:TextBox ID="YunYingDi2_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="YunYingDi2Code_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��Ӫ��ϸ��ַ2
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextBox ID="YunYingDi2_XX_2017" runat="server" MaxLength="200" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��Ӫ��3
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextTreeView ID="tvYYD3" runat="server" DivHeight="450px"
                                        DivWidth="180px" ImgFolds="../../../Images/TreeImages" OnTreeNodePopulate="RegionTreeView_TreeNodePopulate"
                                        RootNodeText="��������ѡ��" TextCssClass="Inputtxt" Width="300px" OnlyReturnLeaf="true"
                                        InputType="Radio">
                                    </epoint:TextTreeView>
                                    <epoint:TextBox ID="YunYingDi3_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="YunYingDi3Code_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��Ӫ��ϸ��ַ3
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="YunYingDi3_XX_2017" runat="server" MaxLength="200" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��������
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextBox ID="ZhaoShangZT_2017" runat="server" CssClass="inputtxt" Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ҵ����
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="QiYeType_2017" runat="server" Width="90%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��ϵ��
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRen_2017" runat="server" MaxLength="50" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ϵ�˵绰
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenTel_2017" runat="server" MaxLength="50" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��ϵ���ֻ�
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenMobile_2017" runat="server" MaxLength="50" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ϵ��Email
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenEmail_2017" runat="server" MaxLength="50" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                    <asp:RegularExpressionValidator ID="reg_LianXiRenEmail_2017" runat="server" Display="Dynamic"
                                        ControlToValidate="LianXiRenEmail_2017" ErrorMessage="��ϵ��Email�������ϸ�ʽҪ��" EnableClientScript="true"
                                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="red"></asp:RegularExpressionValidator>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��ϵ��ְ��
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenZW_2017" runat="server" MaxLength="100" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��˾���
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextBox ID="GongSiJJ_2017" runat="server" CssClass="inputtxt" Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��˾����PPT
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <%--<epoint:CtlMisAttachments ID="GongSiJS_2017" width="100%" runat="server" AttachDescCode='' />--%>
                                    <uc1:CaiLiao ID="CL_GSJS" runat="server" YeWuMC="��ҵ-��˾����" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ˰�����ܷ�ʽ
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="ShuiShouFS_2017" runat="server" Width="90%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ˵��
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="WenZiSM_2017" runat="server" CssClass="inputtxt" Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ���¼�����ҵ
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="Is_GX_2017" runat="server" RepeatDirection="Horizontal"
                                        Width="97%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��׼����
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="PiZhunDate_2017" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ֤��
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <%--<epoint:CtlMisAttachments ID="ZhengShu_2017" width="100%" runat="server" AttachDescCode='' />--%>
                                    <uc1:CaiLiao ID="CL_ZS" runat="server" YeWuMC="��ҵ-֤��" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ����ϯ��
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="DongShiXS_2017" runat="server" CssClass="inputtxt" Width="90%"><NumericProperty TextBoxType="Int" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��������
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="DongShiXM_2017" runat="server" MaxLength="100" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ����ϯ��
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="JianShiXS_2017" runat="server" CssClass="inputtxt" Width="90%"><NumericProperty TextBoxType="Int" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��������
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="JianShiXM_2017" runat="server" MaxLength="100" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    �߹�����
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <%--<epoint:TextBox ID="GaoGuanMD_2017" runat="server" CssClass="inputtxt" Width="90%"></epoint:TextBox>--%>
                                    <span style="color:Red">��������Ӹ߹���Ϣ</span>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td>
                                    <epoint:TextBox ID="UpdateUserName_2017" runat="server" MaxLength="100"></epoint:TextBox>
                                    <epoint:TextBox ID="UpdateUserGuid_2017" runat="server" MaxLength="100"></epoint:TextBox>
                                    <epoint:TextBox ID="IsHistory_2017" runat="server" MaxLength="100"></epoint:TextBox>
                                    <epoint:DateTextBox ID="UpdateTime_2017" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
                                    <epoint:TextBox ID="CheckUserName_2017" runat="server" MaxLength="100"></epoint:TextBox>
                                    <epoint:TextBox ID="CheckUserGuid_2017" runat="server" MaxLength="100"></epoint:TextBox>
                                    <epoint:TextBox ID="Status_2017" runat="server" MaxLength="100"></epoint:TextBox>
                                    <epoint:TextBox ID="DelFlag_2017" runat="server" MaxLength="100"></epoint:TextBox>
                                    <epoint:TextBox ID="DWGuid_2017" runat="server" MaxLength="100"></epoint:TextBox>
                                    <epoint:DateTextBox ID="CheckTime_2017" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
                                </td>
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
