<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_OU.RG_OU_Edit" Title="�޸����ݼ�¼" CodeBehind="RG_OU_Edit.aspx.cs" %>

<%@ Register TagPrefix="uc1" TagName="FJ" Src="../../Ascx/FuJian.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script>
        function window.document.onkeydown() {
            if (event.keyCode == 13) {
                if (window.document.activeElement.tagName != 'TEXTAREA') {
                    event.keyCode = 9;
                }
            }
        }
        function MyPageValidate(message) {
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
                            <epoint:Button ID="btnEdit" runat="server" Text="�޸ı���" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnEdit_Click" OnClientClick="return MyPageValidate('ȷ���޸ģ��޸ĺ�״̬��Ϊ[�����]���뼰ʱ�ύ���');"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btSubmit" runat="server" Text="�ύ���" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btSubmit_Click" OnClientClick="return MyPageValidate('ȷ���ύ��');"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                                Text="ȡ���޸�" runat="server" CausesValidation="false" OnClientClick="window.close();">
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
                    <td height="36" style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                        align="center" valign="middle">
                        <%=ViewState ["TableName"]%>
                    </td>
                </tr>
                <tr>
                    <td id="tdContainer" valign="top" align="center" runat="server">
                        <table width="100%" cellspacing="1" align="center">
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ҵ��������<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="EnterpriseName_2017" runat="server" MaxLength="200" AllowNull="false"
                                        Width="80%" RelationName="��ҵ��������"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ҵӢ������
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="EnterpriseEName_2017" runat="server" MaxLength="500" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    Ӫҵִ�պ���<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YingYeZZ_2017" runat="server" MaxLength="50" AllowNull="false"
                                        Width="80%" RelationName="Ӫҵִ�պ���"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��֯��������<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ZuZhiJGDM_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="��֯��������"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ����������<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="FaRen_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="����������"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ����������֤������
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="FaRenZJType_2017" runat="server" Height="100%" Width="80%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ҵ������<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="QiYeFZR_2017" runat="server" MaxLength="50"  AllowNull="false" RelationName="��ҵ������"
                                        Width="80%"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ����������<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="JiShuFZR_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="����������"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ����������֤����<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="FaRenZJH_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="����������֤����"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ע���ʱ�<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="ZhuCeZiBen_2017" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px" Width="80%" AllowNull="false" RelationName="ע���ʱ�"><NumericProperty TextBoxType="Numeric" Precision="4" /></epoint:NumericTextBox>��Ԫ
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��������<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="ChengLiDate_2017" runat="server" InputDateType="Select" Character="HX"
                                        AllowNull="false" RelationName="��������"></epoint:DateTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ע�����<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextTreeView ID="RegionTreeView" runat="server" DivHeight="450px" RelationName="ע�����"
                                        DivWidth="180px" ImgFolds="../../../Images/TreeImages" OnTreeNodePopulate="RegionTreeView_TreeNodePopulate"
                                        RootNodeText="��������ѡ��" TextCssClass="Inputtxt" Width="200px" OnlyReturnLeaf="true"
                                        InputType="Radio" AllowNull="false">
                                    </epoint:TextTreeView>
                                    <epoint:TextBox ID="RegistAddress_2017" runat="server" MaxLength="100" Height="28px"
                                        Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="RegistAddressCode_2017" runat="server" MaxLength="100" Height="28px"
                                        Style="display: none"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ע����ϸ��ַ<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="ZhuCeDi_XX_2017" runat="server" MaxLength="200" Width="80%" AllowNull="false" RelationName="ע����ϸ��ַ"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��������<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YouZhengCode_2017" runat="server" MaxLength="50" AllowNull="false"
                                        Width="80%" RelationName="��������"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��λ�绰<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="DanWeiTel_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="��λ�绰"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��λ����<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="DanWeiXZ_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="��λ����"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    �Ƿ���ȱ�����ҵ
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsNDBA_2017" runat="server" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ϵ��<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRen_2017" runat="server" MaxLength="50" AllowNull="false"
                                        Width="80%" RelationName="��ϵ��"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��ϵ�˵绰<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenTel_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="��ϵ�˵绰"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ϵ���ֻ�<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenMobile_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="��ϵ���ֻ�"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��ϵ��Email<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenEmail_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="��ϵ��Email"></epoint:TextBox>
                                    <asp:RegularExpressionValidator ID="reg_LianXiRenEmail_2017" runat="server" Display="Dynamic"
                                        ControlToValidate="LianXiRenEmail_2017" ErrorMessage="��ϵ��Email�������ϸ�ʽҪ��" EnableClientScript="true"
                                        ValidationExpression="\w+([']-+.]\w+)*@\w+([']-.]\w+)*\.\w+([']-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ظ���
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <uc1:FJ ID="QY_GSZZ_Z" runat="server">
                                    </uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_GSZZ_F" runat="server">
                                    </uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_ZZJGDMZ" runat="server">
                                    </uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_FRSFZ" runat="server">
                                    </uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_FRQM" runat="server">
                                    </uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_SBZM" runat="server">
                                    </uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_QYQT" runat="server">
                                    </uc1:FJ>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td class="TableSpecial1" width="15%">
                                    ɾ��״̬
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="DelFlag_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ״̬
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="Status_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="TJRGuid_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
