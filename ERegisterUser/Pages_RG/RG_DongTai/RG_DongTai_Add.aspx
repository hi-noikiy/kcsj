<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_DongTai.RG_DongTai_Add" Title="新增数据记录"
    CodeBehind="RG_DongTai_Add.aspx.cs" %>

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
                        <table width="100%" cellspacing="1" align="center">
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    公司荣誉
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <%--<epoint:TextBox ID="GongSiRY_2019" runat="server" CssClass="inputtxt" Width="90%"
                                        TextMode="MultiLine" Height="50px" AllowNull="false" RelationName="公司荣誉:"></epoint:TextBox>--%>
                                    <span style="display: none">保存后可添加公司荣誉</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    团队荣誉
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <%--<epoint:TextBox ID="TuanDuiRY_2019" runat="server" CssClass="inputtxt" Width="90%"
                                        TextMode="MultiLine" Height="50px" AllowNull="false" RelationName="团队荣誉:"></epoint:TextBox>--%>
                                    <span style="display: none">保存后可添加团队荣誉</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    各种补贴
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <%--<epoint:TextBox ID="BuTie_2019" runat="server" CssClass="inputtxt" Width="90%" TextMode="MultiLine"
                                        Height="50px" AllowNull="false" RelationName="各种补贴:"></epoint:TextBox>--%>
                                    <span style="display: none">保存后可添加各种补贴</span>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    其他附件
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <uc1:CaiLiao ID="CL_QTFJ" runat="server" YeWuMC="企业-动态附件" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%" rowspan="2">
                                    公司专利及专有技术
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextBox ID="ZhuanLiJiShu_2019" runat="server" CssClass="inputtxt" Width="90%"
                                        TextMode="MultiLine" Height="50px"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <uc1:CaiLiao ID="CL_ZLJS" runat="server" YeWuMC="企业-专利及技术" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%" rowspan="2">
                                    营业执照
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="YingYeZZNo_2019" runat="server" CssClass="inputtxt" Width="90%"
                                        MaxLength="50"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <uc1:CaiLiao ID="CL_YYZZ" runat="server" YeWuMC="企业-营业执照" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%" rowspan="2">
                                    税务登记证书
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="ShuiWuDJBo_2019" runat="server" CssClass="inputtxt" Width="90%"
                                        MaxLength="50"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <uc1:CaiLiao ID="CL_SWDJZ" runat="server" YeWuMC="企业-税务登记证书" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%" rowspan="2">
                                    组织机构代码证
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="ZuZhiJGDMNo_2019" runat="server" CssClass="inputtxt" Width="90%"
                                        MaxLength="50"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <uc1:CaiLiao ID="CL_ZZJGDM" runat="server" YeWuMC="企业-组织机构代码证" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%" rowspan="2">
                                    商务部批准证书
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="ShangWuBPZNo_2019" runat="server" CssClass="inputtxt" Width="90%"
                                        MaxLength="50"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <uc1:CaiLiao ID="CL_SWPZZ" runat="server" YeWuMC="企业-商务部批准证书" />
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td class="TableSpecial1" width="15%" colspan="4">
                                    <epoint:TextBox ID="UpdateUserGuid_2019" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="UpdateUserName_2019" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:DateTextBox ID="UpdateTime_2019" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
                                    <epoint:TextBox ID="CheckUserName_2019" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="CheckUserGuid_2019" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="IsHistory_2019" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="DWGuid_2019" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:DateTextBox ID="CheckTime_2019" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
                                    <epoint:TextBox ID="Status_2019" runat="server" MaxLength="50"></epoint:TextBox>
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
