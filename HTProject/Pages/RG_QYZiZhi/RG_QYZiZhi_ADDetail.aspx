<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_QYZiZhi.RG_QYZiZhi_ADDetail" Title="查看数据明细" CodeBehind="RG_QYZiZhi_ADDetail.aspx.cs" %>

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

                <script type="text/javascript">
                    function OpenEdit() {
                        OpenWindow('RG_QYZiZhi_Edit2.aspx?RowGuid=<%=Request["RowGuid"] %>');
                    }
                </script>

                <table border="0" cellpadding="0" cellspacing="0" runat="server" id="tabOP" width="500px">
                    <tr>
                        <td>
                            <epoint:Button ID="btnPass" runat="server" Text="审核通过" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClientClick="return window.confirm('确定审核通过？');" OnClick="btnPass_Click"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnNoPass" runat="server" Text="审核不通过" CssClass="ButtonConNoBg"
                                OnClick="btnNoPass_Click" MouseOverClass="ButtonCon" OnClientClick="return window.confirm('确定审核不通过？');">
                            </epoint:Button>
                        </td>
                        <td style="width: 100%">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            审核意见
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
                            审核意见
                        </td>
                        <td style="width: 80%">
                            <asp:Label ID="lblSHOpinion" runat="server"></asp:Label>
                        </td>
                        <td>
                            <epoint:Button ID="Button1" runat="server" Text="修改信息" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClientClick="OpenEdit();return false;"></epoint:Button>
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
        //修改菜单的上下箭头符号
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
        //添加菜单	
        window.onload = function() {
            m1 = new Menu("menu1", 'qyinfo', 'dtu', '100', show, my_on, my_off);
            m1.init();

        }
			
    </script>

    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                valign="middle" align="center" height="36">
                <font face="宋体"></font>
                <%=ViewState ["TableName"]%>
            </td>
        </tr>
        <%--<tr>
            <td id="tdContainerOU" valign="top" align="center" runat="server">
            </td>
        </tr>--%>
        <tr>
            <td id="tdContainer" valign="top" align="center" runat="server">
                <table width="100%" cellspacing="1">
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            资质类别:
                        </td>
                        <td class="TableSpecial" width="85%" height="26" colspan="3">
                            <asp:Label ID="ZiZhiText_2020" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            资质编号:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="ZiZhiCode_2020" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            资质截止日期:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="ZiZhiEndDate_2020" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            首次资质取得时间
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="FirstGetDate_2020" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            现有资质取得时间
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="XianYouDate_2020" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            发证机关
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <asp:Label ID="FaZhengJG_2020" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            相关附件
                        </td>
                        <td class="TableSpecial" width="85%" colspan="3">
                            <uc1:FJ ID="ZiZhiZS_Z" runat="server" ClientTag="企业资质证书(正本)" ReadOnly="true"></uc1:FJ>
                            <br />
                            <uc1:FJ ID="ZiZhiZS_F" runat="server" ClientTag="企业资质证书(副本)" ReadOnly="true"></uc1:FJ>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="TableSpecial1" width="15%">
                            资质类别Code:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="ZiZhiTextCode_2020" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            DWGuid:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="DWGuid_2020" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="TableSpecial1" width="15%">
                            删除状态:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="DelStatus_2020" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            审核状态:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="Status_2020" Width="100%" runat="server"></asp:Label>
                            <asp:Label ID="TJRGuid_2020" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%" height="100%" align="center">
                    <tr>
                        <td>
                            <div class="tit" id="menu1" title="点击查看企业信息">
                                <div class="titpic" id="pc1">
                                </div>
                                <a title="点击查看企业信息" target="" class="on" id="A1" tabindex="1">点击查看企业信息 </a>
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellspacing="1" id="qyinfo" class="list">
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            企业中文名称
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="EnterpriseName_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            企业英文名称
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="EnterpriseEName_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            营业执照号码
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="YingYeZZ_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            组织机构代码
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ZuZhiJGDM_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            法人
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="FaRen_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            法人证件类型
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="FaRenZJType_2017" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            法人证件号
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="FaRenZJH_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            注册资本
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ZhuCeZiBen_2017" runat="server"></asp:Label>万元
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            成立日期
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="ChengLiDate_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            注册地区
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="RegistAddress_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            注册详细地址
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="ZhuCeDi_XX_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            联系人
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="LianXiRen_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            联系人电话
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="LianXiRenTel_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            联系人手机
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="LianXiRenMobile_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            联系人Email
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="LianXiRenEmail_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            相关附件
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
                            删除状态
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="DelFlag_2017" runat="server" MaxLength="50"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            状态
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
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False">没有数据！</asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
