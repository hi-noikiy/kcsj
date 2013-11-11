<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_QYZiZhi.RG_QYZiZhi_Edit2" Title="�޸����ݼ�¼" CodeBehind="RG_QYZiZhi_Edit2.aspx.cs" %>

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
                            <epoint:Button ID="btnEdit" runat="server" Text="�޸ı���" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnEdit_Click" CausesValidation="false"></epoint:Button>
                        </td>
                        <td>
                            <%--<epoint:Button ID="btnSubmit" runat="server" Text="�ύ���" CssClass="ButtonConNoBg"
                                MouseOverClass="ButtonCon" OnClick="btSubmit_Click" OnClientClick="return MyPageValidate('ȷ���ύ��');">
                            </epoint:Button>--%>
                        </td>
                        <td style="width: 100%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            ������
                        </td>
                        <td colspan="2">
                            <asp:Label ID="lblSHOpinion" runat="server"></asp:Label>
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
                                    �������<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextTreeView ID="RegionTreeView" runat="server" DivHeight="250px" RelationName="�������"
                                        DivWidth="300px" ImgFolds="../../../Images/TreeImages" OnTreeNodePopulate="RegionTreeView_TreeNodePopulate"
                                        RootNodeText="���ѡ��" TextCssClass="Inputtxt" Width="300px" OnlyReturnLeaf="true"
                                        AllowNull="false">
                                    </epoint:TextTreeView>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ���ʱ��<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ZiZhiCode_2020" runat="server" MaxLength="50" AllowNull="false"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ���ʽ�ֹ����<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="ZiZhiEndDate_2020" runat="server" InputDateType="Input" Character="HX"
                                        AllowNull="false"></epoint:DateTextBox><span style="color:Red">���ǳ��ڣ���ͳһ�ڵ�ǰʱ��<br />�Ļ����ϼ�5��</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    �״�����ȡ��ʱ��<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="FirstGetDate_2020" runat="server" InputDateType="Input" Character="HX"
                                        AllowNull="false"></epoint:DateTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ��������ȡ��ʱ��<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="XianYouDate_2020" runat="server" InputDateType="Input" Character="HX"
                                        AllowNull="false"></epoint:DateTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��֤����<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="FaZhengJG_2020" runat="server" MaxLength="100" AllowNull="false"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ��ظ���
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3">
                                    <uc1:FJ ID="ZZ_ZS_Z" runat="server" ClientTag="��ҵ����֤��(����)" ></uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="ZZ_ZS_F" runat="server" ClientTag="��ҵ����֤��(����)" ></uc1:FJ>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td class="TableSpecial1" width="15%">
                                    �������Code
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ZiZhiTextCode_2020" runat="server" MaxLength="500"></epoint:TextBox>
                                    <epoint:TextBox ID="ZiZhiText_2020" runat="server" MaxLength="500"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    DWGuid
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="DWGuid_2020" runat="server" MaxLength="50"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td class="TableSpecial1" width="15%">
                                    ɾ��״̬
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="DelStatus_2020" runat="server" Width="100%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    ���״̬
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="Status_2020" runat="server" Width="100%" Height="100%">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblDWName" runat="server"></asp:Label>
                                    <epoint:TextBox ID="ZuZhiJGDM_2020" runat="server" Width="80%"></epoint:TextBox>
                                </td>
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
