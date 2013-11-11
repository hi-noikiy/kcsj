<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_QYUser.RG_QYUser_Detail" Title="�鿴������ϸ" CodeBehind="RG_QYUser_Detail.aspx.cs" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<%@ Register TagPrefix="uc1" TagName="FJ" Src="../../Ascx/FuJian.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="Div_ControlNoTop">
                <table border="0" cellpadding="0" cellspacing="0" runat="server" id="tabOP" width="500px">
                    <tr>
                        <td>
                            <epoint:Button ID="btnPass" runat="server" Text="���ͨ��" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClientClick="return window.confirm('ȷ�����ͨ����');" OnClick="btnPass_Click"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnNoPass" runat="server" Text="��˲�ͨ��" CssClass="ButtonConNoBg"
                                OnClick="btnNoPass_Click" MouseOverClass="ButtonCon" OnClientClick="return window.confirm('ȷ����˲�ͨ����');">
                            </epoint:Button>
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
                            <epoint:TextBox ID="SHOpinion" runat="server" MaxLength="100" TextMode="MultiLine"
                                Height="60px"></epoint:TextBox>
                        </td>
                    </tr>
                </table>
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td>
                            ������
                        </td>
                        <td style="width: 90%">
                            <asp:Label ID="lblSHOpinion" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script language="JavaScript" type="text/javascript" src="../../../JavaScript/navbar.js"></script>

    <link href="../../../JavaScript/navbar-pix.css" rel="stylesheet" type="text/css" />

    <script type="text/javascript">
        var show = false;
        var hide = true
        //�޸Ĳ˵������¼�ͷ����
        function my_on(head, body) {
            var tag_a;
            for (var i = 0; i < head.childNodes.length; i++) {
                if (head.childNodes[i].nodeName == "A") {
                    tag_a = head.childNodes[i];
                    break;
                }
            }
            tag_a.className = "on";
        }
        function my_off(head, body) {
            var tag_a;
            for (var i = 0; i < head.childNodes.length; i++) {
                if (head.childNodes[i].nodeName == "A") {
                    tag_a = head.childNodes[i];
                    break;
                }
            }
            tag_a.className = "off";
        }
        //��Ӳ˵�	
        window.onload = function() {
            m1 = new Menu("menu1", 'ryinfo', 'dtu', '100', show, my_on, my_off);
            m1.init();

        }
			
    </script>

    <%--<div id="Div_ControlNoTop">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <epoint:Button ID="btnPass" runat="server" Text="���ͨ��" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                       OnClientClick="return window.confirm('ȷ�����ͨ����');" ></epoint:Button>
                </td>
                <td>
                    <epoint:Button ID="btnNoPass" runat="server" Text="��˲�ͨ��" CssClass="ButtonConNoBg"
                        MouseOverClass="ButtonCon" OnClientClick="return window.confirm('ȷ����˲�ͨ����');"></epoint:Button>
                </td>
                <td>
                    <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle" Visible="false"
                        Text="�ر�" runat="server" CausesValidation="false" OnClientClick="window.close();">
                    </epoint:Button>
                </td>
            </tr>
        </table>
    </div>--%>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                valign="middle" align="center" height="36">
                <font face="����"></font>
                <%=ViewState ["TableName"]%>
            </td>
        </tr>
        <tr>
            <td id="tdContainer" valign="top" align="center" runat="server">
                <table width="100%" cellspacing="1">
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ����:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="XM_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td rowspan="5" class="TableSpecial1" width="15%">
                            ��Ƭ
                        </td>
                        <td rowspan="5" class="TableSpecial" width="35%" height="26" align="left">
                            <img style='height: 126px' src='RetrieveImageData.aspx?RowGuid=<%=Request["RowGuid"] %>' />
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            �Ա�:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="Sex_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ֤������:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="IDNum_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ����:
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="mz_2019" runat="server" MaxLength="100"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��������:
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="csrq_2019" runat="server" InputDateType="Input" Character="HX"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            סַ:
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ryzz_2019" runat="server" MaxLength="100"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��֤����:
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="fzjg_2019" runat="server" MaxLength="100"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ���֤��Ч��ʼ:
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="sfzyxqs_2019" runat="server" InputDateType="Input" Character="HX"
                                Width="120px"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ���֤��Ч��ֹ:
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="sfzyxqz_2019" runat="server" InputDateType="Input" Character="HX"
                                Width="120px"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ������ƹ���:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="GongLing_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��ѧרҵ:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="ZhuanYe_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ѧ��:
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="XueLi_2019" runat="server">
                            </asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��ҵʱ��:
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="BiYeDate_2019" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ҵԺУ:
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <asp:Label ID="BiYeXueXiao_2019" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ����רҵ��ע��רҵ:
                        </td>
                        <td class="TableSpecial" width="85%" height="26" colspan="3">
                            <asp:Label ID="ZhuanYeCS_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ע��ӡ�º�:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="YinZhangNo_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ְ��:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="ZhiCheng_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ע������Ч��:
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ZCZ_YXQ_2019" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            Ƹ�ú�ͬ��:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="HeTongNo_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��ͬ��ֹʱ��:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="HeTongEndDate_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ظ���
                        </td>
                        <td class="TableSpecial" width="85%" colspan="3">
                            <uc1:FJ ID="SFZ" runat="server" ClientTag="���֤��" ReadOnly="true"></uc1:FJ>
                            <br />
                            <uc1:FJ ID="BYZ" runat="server" ClientTag="��ҵ֤" ReadOnly="true"></uc1:FJ>
                            <br />
                            <uc1:FJ ID="ZCZJ" runat="server" ClientTag="ע��֤�鼰��ӡ��" ReadOnly="true"></uc1:FJ>
                            <br />
                            <uc1:FJ ID="ZhiCheng" runat="server" ClientTag="ְ��֤" ReadOnly="true"></uc1:FJ>
                            <br />
                            <uc1:FJ ID="LDHT" runat="server" ClientTag="�Ͷ���ͬ" ReadOnly="true"></uc1:FJ>
                            <br />
                            <uc1:FJ ID="GRQM" runat="server" ClientTag="����ǩ��" ReadOnly="true"></uc1:FJ>
                            <br />
                            <uc1:FJ ID="GRQT" runat="server" ClientTag="����" ReadOnly="true"></uc1:FJ>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="TableSpecial1" width="15%">
                            ����רҵCode:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="ZhuanYeCSCode_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��ҵGuid:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="DWGuid_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="TableSpecial1" width="15%">
                            ״̬:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="Status_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ɾ��״̬:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="DelStatus_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%" height="100%" align="center">
                    <tr>
                        <td>
                            <div class="tit" id="menu1" title="����鿴��ҵ��Ϣ">
                                <div class="titpic" id="pc1">
                                </div>
                                <a title="����鿴��ҵ��Ϣ" target="" class="on" id="A1" tabindex="1">����鿴��ҵ��Ϣ </a>
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellspacing="1" id="ryinfo" class="list">
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ҵ��������
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="EnterpriseName_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ҵӢ������
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="EnterpriseEName_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            Ӫҵִ�պ���
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="YingYeZZ_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��֯��������
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ZuZhiJGDM_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ����
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="FaRen_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ����֤������
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="FaRenZJType_2017" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ����֤����
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="FaRenZJH_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ע���ʱ�
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ZhuCeZiBen_2017" runat="server"></asp:Label>��Ԫ
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��������
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ChengLiDate_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ע�����
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="RegistAddress_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ע����ϸ��ַ
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="ZhuCeDi_XX_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ϵ��
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="LianXiRen_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��ϵ�˵绰
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="LianXiRenTel_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ϵ���ֻ�
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="LianXiRenMobile_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��ϵ��Email
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="LianXiRenEmail_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ظ���
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <uc1:FJ ID="GSZZ_Z" runat="server" ReadOnly="true"></uc1:FJ>
                            <br />
                            <uc1:FJ ID="GSZZ_F" runat="server" ReadOnly="true"></uc1:FJ>
                            <br />
                            <uc1:FJ ID="ZZJGDMZ" runat="server" ReadOnly="true"></uc1:FJ>
                            <br />
                            <uc1:FJ ID="FRSFZ" runat="server" ReadOnly="true"></uc1:FJ>
                            <br />
                            <uc1:FJ ID="FRQM" runat="server" ReadOnly="true"></uc1:FJ>
                            <br />
                            <uc1:FJ ID="SBZM" runat="server" ReadOnly="true"></uc1:FJ>
                            <br />
                            <uc1:FJ ID="QT" runat="server" ReadOnly="true"></uc1:FJ>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="TableSpecial1" width="15%">
                            ɾ��״̬
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="DelFlag_2017" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="IDType_2019" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ״̬
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="Status_2017" runat="server" MaxLength="50"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" height="40">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False">û�����ݣ�</asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
