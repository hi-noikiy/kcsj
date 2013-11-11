<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPage.master" AutoEventWireup="True"
    Inherits="HTProject.Pages.RG_User.Record_Detail" Title="会员审核" CodeBehind="Record_Detail.aspx.cs" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script>

    function OpenUrl() {
        OpenDialogRefresh('RG_SendMessage.aspx?UserGuid=<%=Request["RowGuid"]%>', "", 600, 300);
    }
    </script>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td>
                <div id="Div_Control">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                            <td>
                                &nbsp;<epoint:Button MouseOverClass="ButtonOK" ForeColor="black" CssClass="ButtonOKNoBg"
                                    ID="btnCheck" runat="server" Text="审核通过" OnClick="Check_Click" />
                            </td>
                            <td>
                                &nbsp;<epoint:Button Text="不通过" ID="btnNotPass" MouseOverClass="ButtonDel" runat="server"
                                    CssClass="ButtonDelNoBg" OnClick="NotPass_Click" OnClientClick="OpenUrl();"  />
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
        <tr>
            <td id="tdContainer" valign="top" align="center" runat="server">
                <table width="100%" cellspacing="1">
                    <tr>
                        <td class="TableSpecial1" width="100%" style="text-align: center" colspan="4">
                            <font style="font-weight: bold">基本信息</font>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            会员类别:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="UserType_99" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            登&nbsp;陆&nbsp;名:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="LoginID_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            显示名称:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="DispName_99" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            手机号码:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="Mobile_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            是否接受短信提醒:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="isEnableSMS" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            是否启用在线聊天:
                        </td>
                        <td class="TableSpecial" width="35%" height="26">
                            <asp:Label ID="EnableOnlineChat" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trperson" runat="server">
                        <td class="TableSpecial1" width="15%">
                            身份证号码:
                        </td>
                        <td class="TableSpecial" width="35%" height="26" colspan="3">
                            <asp:Label ID="UserIdendity_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            用户角色:
                        </td>
                        <td class="TableSpecial" width="35%" height="26" colspan="3">
                            <asp:Label ID="RoleName" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" id="trDanwei">
                        <td class="TableSpecial1" width="15%">
                            所属单位
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <asp:Label ID="OUBelong" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr id="trOuType" runat="server">
                        <td class="TableSpecial1" width="15%">
                            单位类别
                        </td>
                        <td class="TableSpecial" height="26" align="left" colspan="3">
                            <asp:Label ID="OUType" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td class="TableSpecial1" width="100%" style="text-align: center" colspan="4">
                            <font style="font-weight: bold">个人信息</font>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="Sex_99" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            民&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;族
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="Race_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            生&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;日
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="BirthDay_99" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            住宅电话
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="HomeTel_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            办公电话
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="OfficeTel_99" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            邮政编码
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="PostCode_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            QQ&nbsp;号码
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="QQAccount_99" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            MSN号码
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="MSNAccount_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            电子信箱
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <asp:Label ID="EMail_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            所&nbsp;在&nbsp;地
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <asp:Label ID="SuoZaiDi_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            通讯地址
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <asp:Label ID="Address_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            其他联系方式
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <asp:Label ID="OtherContact_99" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            照&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;片
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <input id="Photo_99" runat="server" type="file" />&nbsp;<asp:Label ID="lbl_Photo_99"
                                runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                            <asp:Label ID="ChangeLog_99" Width="100%" runat="server" Height="100"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellspacing="1" id="tabou" runat="server">
                    <tr>
                        <td class="TableSpecial1" width="100%" style="text-align: center" colspan="4">
                            <font style="font-weight: bold">单位信息</font>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            单位名称
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left">
                            <asp:Label ID="EnterpriseName" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            组织机构代码证
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left">
                            <asp:Label ID="CodeCertificate" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            单位类型
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left" colspan="3">
                            <asp:Label ID="EnterpriseType" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            法人代表
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left">
                            <asp:Label ID="LegalPerson" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            营业执照编号
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left">
                            <asp:Label ID="BusinessLicenseNO" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            企业地域性质
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left">
                            <asp:Label ID="RegionCharacter" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            联 系 人
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left">
                            <asp:Label ID="Contacter" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            联系电话
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left">
                            <asp:Label ID="Tel" Width="100%" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            联系人身份证
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left" colspan="3">
                            <asp:Label ID="ContacterID" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            电子邮件
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left" colspan="3">
                            <asp:Label ID="Email" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            单位地址
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left" colspan="3">
                            <asp:Label ID="Address" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            注 册 地
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left" colspan="3">
                            <asp:Label ID="RegistAddress" Width="100%" runat="server"></asp:Label>
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注
                        </td>
                        <td class="TableSpecial" width="35%" height="25" align="left" colspan="3">
                            <asp:Label ID="BeiZhu" Width="100%" runat="server" Height="100px"></asp:Label>
                        </td>
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
