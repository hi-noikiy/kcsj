<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_OU.RG_OU_Add" Title="新增数据记录" CodeBehind="RG_OU_Add.aspx.cs" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Ajax.FileUpload" Namespace="Epoint.Ajax.FileUpload"
    TagPrefix="cc1" %>
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
                            <epoint:Button ID="btnAdd" runat="server" Text="添加保存" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnAdd_Click"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                                Text="取消添加" runat="server" CausesValidation="false" OnClientClick="window.close();">
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
                        <table width="100%" cellspacing="1" align="center" id="tabContent">
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    企业中文名称
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="EnterpriseName_2017" runat="server" MaxLength="200" AllowNull="false"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    企业英文名称
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="EnterpriseEName_2017" runat="server" MaxLength="500"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    注册商标
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:CtlMisAttachments ID="ShangBiao_2017" width="100%" runat="server" AttachDescCode='' />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    Logo
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:CtlMisAttachments ID="Logo_2017" width="100%" runat="server" AttachDescCode='' />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    成立日期
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="ChengLiDate_2017" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    注册地
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ZhuCeDi_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="ZhuCeDiCode_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    注册详细地址
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="ZhuCeDi_XX_2017" runat="server" MaxLength="200"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    运营地1
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YunYingDi1_2017" runat="server" MaxLength="200"></epoint:TextBox>
                                    <epoint:TextBox ID="YunYingDi1Code_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    运营详细地址1
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YunYingDi1_XX_2017" runat="server" MaxLength="200"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    运营地2
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YunYingDi2_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="YunYingDi2Code_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    运营详细地址2
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YunYingDi2_XX_2017" runat="server" MaxLength="200"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    运营地3
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YunYingDi3_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="YunYingDi3Code_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    运营详细地址3
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="YunYingDi3_XX_2017" runat="server" MaxLength="200"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    招商载体
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ZhaoShangZT_2017" runat="server"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    企业类型
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="QiYeType_2017" runat="server" Width="100%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    联系人
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRen_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    联系人电话
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenTel_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    联系人手机
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenMobile_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    联系人Email
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenEmail_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                    <asp:RegularExpressionValidator ID="reg_LianXiRenEmail_2017" runat="server" Display="Dynamic"
                                        ControlToValidate="LianXiRenEmail_2017" ErrorMessage="联系人Email：不符合格式要求！" EnableClientScript="true"
                                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="red"></asp:RegularExpressionValidator>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    联系人职务
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenZW_2017" runat="server" MaxLength="100"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    公司简介
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="GongSiJJ_2017" runat="server"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    公司介绍PPT
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:CtlMisAttachments ID="GongSiJS_2017" width="100%" runat="server" AttachDescCode='' />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    税收征管方式
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="ShuiShouFS_2017" runat="server" Width="100%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    说明
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="WenZiSM_2017" runat="server"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    高新技术企业
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="Is_GX_2017" runat="server" RepeatDirection="Horizontal"
                                        Width="97%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    批准日期
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="PiZhunDate_2017" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    证书
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:CtlMisAttachments ID="ZhengShu_2017" width="100%" runat="server" AttachDescCode='' />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    董事席数
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="DongShiXS_2017" runat="server"><NumericProperty TextBoxType="Int" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    董事姓名
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="DongShiXM_2017" runat="server" MaxLength="100"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    监事席数
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="JianShiXS_2017" runat="server"><NumericProperty TextBoxType="Int" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    监事名单
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="JianShiXM_2017" runat="server" MaxLength="100"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    高管名单
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <%--<epoint:TextBox ID="GaoGuanMD_2017" runat="server"></epoint:TextBox>--%>
                                    <span style="color:Red">保存后可添加高管信息</span>
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
