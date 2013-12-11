<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="True"
    Inherits="HTProject.Pages.RG_OU.RG_OU_All_Detail" Title="������ϸ" CodeBehind="RG_OU_All_Detail.aspx.cs" %>

<%@ Register TagPrefix="uc1" TagName="FJ" Src="../../Ascx/FuJian.ascx" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script type="text/javascript">
        function check(message) { 
            if(window.confirm('ȷ�����е���ҵ��Ա����ҵ���ʶ��Ѿ�������?'))
            {
                return window.confirm(message);
            }
            return false;
        }
    </script>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="Div_ControlNoTop">
                <table border="0" cellpadding="0" cellspacing="0" runat="server" id="tabOP" width="500px">
                    <tr>
                        <td>
                            <epoint:Button ID="btnPass" runat="server" Text="���ͨ��" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClientClick="return check('ȷ�����ͨ����');" OnClick="btnPass_Click">
                            </epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnNoPass" runat="server" Text="��˲�ͨ��" CssClass="ButtonConNoBg"
                                OnClick="btnNoPass_Click" MouseOverClass="ButtonCon" OnClientClick="return check('ȷ����˲�ͨ����');">
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
                                Height="60px" Width="80%"></epoint:TextBox>
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
            m1 = new Menu("menuQY", 'qyInfo', 'A1', '100', show, my_on, my_off);
            m1.init();
            m2 = new Menu("menuZZ", 'zzInfo', 'A2', '100', show, my_on, my_off);
            m2.init();
            m3 = new Menu("menuRY", 'ryInfo', 'A3', '100', show, my_on, my_off);
            m3.init();
            m4 = new Menu("menuXM", 'xmInfo', 'A4', '100', show, my_on, my_off);
            m4.init();
        }
			
    </script>

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
                <table width="100%" height="100%" align="center">
                    <tr>
                        <td>
                            <div class="tit" id="menuQY" title="����鿴��ҵ��Ϣ">
                                <div class="titpic" id="pcQY">
                                </div>
                                <a title="����鿴��ҵ��Ϣ" target="" class="on" id="A1" tabindex="1">����鿴��ҵ��Ϣ </a>
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellspacing="1" align="center" id="qyInfo">
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
                            ����������
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="FaRen_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ֤������
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="FaRenZJType_2017" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��ҵ������
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="QiYeFZR_2017" runat="server" MaxLength="50" Width="80%"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ����������
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="JiShuFZR_2017" runat="server" MaxLength="50" Width="80%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ����������<br />
                            ���֤����
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
                            ��������<span style="color: Red">*</span>
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
                            ��������
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="YouZhengCode_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ��λ�绰
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="DanWeiTel_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            ��λ����
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="DanWeiXZ_2017" runat="server"></asp:Label>
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
                        </td>
                        <td class="TableSpecial1" width="15%">
                            ״̬
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="Status_2017" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="TJRGuid_2017" runat="server" MaxLength="50"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%" height="100%" align="center">
                    <tr>
                        <td>
                            <div class="tit" id="menuZZ" title="����鿴��ҵ����">
                                <div class="titpic" id="pcZZ">
                                </div>
                                <a title="����鿴��ҵ����" target="" class="off" id="A2" tabindex="2">����鿴��ҵ���� </a>
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellspacing="1" id="zzInfo">
                    <tr>
                        <td align="right" colspan="2" style="height: 31px" class="tablespecial">
                            <webdiyer:AspNetPager ID="PagerZZ" runat="server" AlwaysShow="True" SubmitButtonClass="backendbtn22"
                                InputBoxClass="inputtxt" ShowCustomInfoSection="Left" ButtonImageNameExtension="n"
                                DisabledButtonImageNameExtension="g" CpiButtonImageNameExtension="r" ImagePath="../../../images/page/"
                                PagingButtonType="Image" NavigationButtonType="Image" PageSize="20" OnPageChanged="PagerZZ_PageChanged">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:DataGrid ID="DGZZ" runat="server" CssClass="GridView" PageSize="20" BorderWidth="1px"
                                AccessKey="1" DataKeyField="RowGuid" AutoGenerateColumns="False" AllowPaging="True"
                                AllowSorting="True" Width="100%" OnItemCreated="DGZZ_ItemCreated">
                                <PagerStyle Visible="False"></PagerStyle>
                                <AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
                                <ItemStyle CssClass="RowStyle"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" CssClass="HeaderStyle"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="���">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="�������">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZiZhiText") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="���ʱ��">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZiZhiCode") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="���ʽ�ֹ����">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZiZhiEndDate", "{0:yyyy-MM-dd}") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="���״̬">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("���״̬", Convert.ToString(DataBinder.Eval(Container, "DataItem.Status"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="����">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <%#GetButton(DataBinder.Eval(Container, "DataItem.Status"),DataBinder.Eval(Container.DataItem,"RowGuid"),"../RG_QYZiZhi/RG_QYZiZhi_Detail.aspx")%>
                                            <%--<a href='javascript:OpenWindow("../RG_QYZiZhi/RG_QYZiZhi_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>")'>
                                                <img src='../../../images/bigview.gif' border='0'></a>--%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Visible="False"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                </table>
                <table width="100%" height="100%" align="center">
                    <tr>
                        <td>
                            <div class="tit" id="menuRY" title="����鿴��ҵ��Ա">
                                <div class="titpic" id="pcRY">
                                </div>
                                <a title="����鿴��ҵ��Ա" target="" class="off" id="A3" tabindex="3">����鿴��ҵ��Ա </a>
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellspacing="1" id="ryInfo">
                    <tr>
                        <td align="right" colspan="2" style="height: 31px" class="tablespecial">
                            <webdiyer:AspNetPager ID="PagerRY" runat="server" AlwaysShow="True" SubmitButtonClass="backendbtn22"
                                InputBoxClass="inputtxt" ShowCustomInfoSection="Left" ButtonImageNameExtension="n"
                                DisabledButtonImageNameExtension="g" CpiButtonImageNameExtension="r" ImagePath="../../../images/page/"
                                PagingButtonType="Image" NavigationButtonType="Image" PageSize="20" OnPageChanged="PagerRY_PageChanged">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:DataGrid ID="DGRY" runat="server" CssClass="GridView" PageSize="20" BorderWidth="1px"
                                AccessKey="1" DataKeyField="RowGuid" AutoGenerateColumns="False" AllowPaging="True"
                                AllowSorting="True" Width="100%" OnItemCreated="DGRY_ItemCreated">
                                <PagerStyle Visible="False"></PagerStyle>
                                <AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
                                <ItemStyle CssClass="RowStyle"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" CssClass="HeaderStyle"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="���">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="����">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.XM") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="�Ա�">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("�Ա�", Convert.ToString(DataBinder.Eval(Container, "DataItem.Sex"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ְ��">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("ְ��", Convert.ToString(DataBinder.Eval(Container, "DataItem.ZhiCheng"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="���֤����">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.IDNum") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��ͬ��ֹʱ��">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.HeTongEndDate", "{0:yyyy-MM-dd}") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ע��ӡ�º�">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.YinZhangNo") + ";" + DataBinder.Eval(Container, "DataItem.YinZhangNo1") + ";" + DataBinder.Eval(Container, "DataItem.YinZhangNo2")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="����רҵ">
                                        <ItemTemplate>
                                            <%# RG_DW.GetItemTextByLen2("29b7967e-8098-42d5-8b40-ec757b0865a5", DataBinder.Eval(Container, "DataItem.ZhuanYeCSCode"), 4)%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="ע��רҵ">
                                        <ItemTemplate>
                                            <%# RG_DW.GetItemTextByLen2("29b7967e-8098-42d5-8b40-ec757b0865a5", DataBinder.Eval(Container, "DataItem.ZhuanYeCSCode"), 0)%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="����">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.GongLing") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="״̬">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("���״̬", Convert.ToString(DataBinder.Eval(Container, "DataItem.Status"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="����">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <%#GetButton(DataBinder.Eval(Container, "DataItem.Status"), DataBinder.Eval(Container.DataItem, "RowGuid"), "../RG_QYUser/RG_QYUser_Detail.aspx")%>
                                            <%--<a href='javascript:OpenWindow("../RG_QYUser/RG_QYUser_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>")'>
                                                <img src='../../../images/bigview.gif' border='0'></a>--%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Visible="False"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                </table>
                <table width="100%" height="100%" align="center">
                    <tr>
                        <td>
                            <div class="tit" id="menuXM" title="����鿴��ҵ��Ŀ">
                                <div class="titpic" id="pcXM">
                                </div>
                                <a title="����鿴��ҵ��Ŀ" target="" class="off" id="A4" tabindex="4">����鿴��ҵ��Ŀ </a>
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellspacing="1" id="xmInfo">
                    <tr>
                        <td align="right" colspan="2" style="height: 31px" class="tablespecial">
                            <webdiyer:AspNetPager ID="PagerXM" runat="server" AlwaysShow="True" SubmitButtonClass="backendbtn22"
                                InputBoxClass="inputtxt" ShowCustomInfoSection="Left" ButtonImageNameExtension="n"
                                DisabledButtonImageNameExtension="g" CpiButtonImageNameExtension="r" ImagePath="../../../images/page/"
                                PagingButtonType="Image" NavigationButtonType="Image" PageSize="20" OnPageChanged="PagerXM_PageChanged">
                            </webdiyer:AspNetPager>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:DataGrid ID="DGXM" runat="server" CssClass="GridView" PageSize="20" BorderWidth="1px"
                                AccessKey="1" DataKeyField="RowGuid" AutoGenerateColumns="False" AllowPaging="True"
                                AllowSorting="True" Width="100%" OnItemCreated="DGXM_ItemCreated">
                                <PagerStyle Visible="False"></PagerStyle>
                                <AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
                                <ItemStyle CssClass="RowStyle"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" Height="30px" CssClass="HeaderStyle"></HeaderStyle>
                                <Columns>
                                    <asp:TemplateColumn HeaderText="���">
                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                        <ItemTemplate>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��Ŀ����">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.XMName") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��Ŀ�ص�">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("��Ŀ�ص�", Convert.ToString(DataBinder.Eval(Container, "DataItem.XMAdd")))%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��Ͷ��">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ToTalMoney") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="���ʵȼ�">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZiZhiDJ") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="���ʱ��">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZiZhiBH") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��ͬ�۸�">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.HeTongMoney") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��Ŀ������">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.XMFZR") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="���赥λ">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.JSDWName") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="��ģ���ȼ�">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("��Ŀ��ģ�ȼ�", Convert.ToString(DataBinder.Eval(Container, "DataItem.GuiMoDJ"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="���״̬" SortExpression="Status">
                                        <ItemTemplate>
                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("���״̬", Convert.ToString(DataBinder.Eval(Container, "DataItem.Status"))) %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="�鿴">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='javascript:OpenWindow("../RG_XMBeiAn/RG_XMBeiAnAD_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>")'>
                                                <img src='../../../images/bigview.gif' border='0'></a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Visible="False"></PagerStyle>
                            </asp:DataGrid>
                        </td>
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
