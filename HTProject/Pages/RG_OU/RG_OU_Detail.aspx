<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="True"
    Inherits="HTProject.Pages.RG_OU.RG_OU_Detail" Title="数据明细" CodeBehind="RG_OU_Detail.aspx.cs" %>

<%@ Register TagPrefix="uc1" TagName="FJ" Src="../../Ascx/FuJian.ascx" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Div_ControlNoTop">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <epoint:Button ID="btnPass" runat="server" Text="审核通过" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                        OnClientClick="return window.confirm('确定审核通过？');" OnClick="btnPass_Click"></epoint:Button>
                </td>
                <td>
                    <epoint:Button ID="btnNoPass" runat="server" Text="审核不通过" CssClass="ButtonConNoBg"
                        MouseOverClass="ButtonCon" OnClientClick="return window.confirm('确定审核不通过？');" OnClick="btnNoPass_Click">
                    </epoint:Button>
                </td>
                <td>
                    <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                        Visible="false" Text="关闭" runat="server" CausesValidation="false" OnClientClick="window.close();">
                    </epoint:Button>
                </td>
            </tr>
        </table>
    </div>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                valign="middle" align="center" height="36">
                <font face="宋体"></font>
                <%=ViewState ["TableName"]%>
            </td>
        </tr>
        <tr>
            <td id="tdContainer" valign="top" align="center" runat="server">
                <table width="100%" cellspacing="1" align="center">
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
                            法定代表人
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="FaRen_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            证件类型
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="FaRenZJType_2017" runat="server">
                            </asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            企业负责人
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="QiYeFZR_2017" runat="server" MaxLength="50" Width="80%"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            技术负责人
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="JiShuFZR_2017" runat="server" MaxLength="50" Width="80%"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            法定代表人<br />
                            身份证号码
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
                            邮政编码
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="YouZhengCode_2017" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            单位电话
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="DanWeiTel_2017" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            单位性质
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="DanWeiXZ_2017" runat="server"></asp:Label>
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
