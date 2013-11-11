<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_Other.RG_OtherInfo_Add" Title="新增重要事项"
    CodeBehind="RG_OtherInfo_Add.aspx.cs" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TreeViewControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Ajax.FileUpload" Namespace="Epoint.Ajax.FileUpload"
    TagPrefix="cc1" %>
<%@ Register Src="../../Ascx/CaiLiao.ascx" TagName="CaiLiao" TagPrefix="uc1" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
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
                        <td style="display:none">
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
                                    年
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="ddlYear" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    月
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="ddlMonth" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    上年度研发费用
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="ShangNianDuYFFY_2021" runat="server" TextAlign="Right"
                                        Style="padding-right: 2px; padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    薪酬总额
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="XinChouZongE_2021" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    注册资本
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="ZhuCeZiBen_2021" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px"><NumericProperty TextBoxType=TextBoxType="Numeric" Precision="2" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    每月财务报表
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <uc1:CaiLiao ID="CL_CWBB" runat="server" YeWuMC="企业-每月财务报表" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    年度审计报告
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <uc1:CaiLiao ID="CL_NDSJBG" runat="server" YeWuMC="企业-年度审计报告" />
                                </td>
                            </tr>
                            <tr>
                                <td style="display: none">
                                    <epoint:TextBox ID="Status_2021" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="UpdateUserName_2021" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="UpdateUserGuid_2021" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:DateTextBox ID="UpdateTime_2021" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
                                    <epoint:TextBox ID="CheckUserName_2021" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="CheckUserGuid_2021" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:DateTextBox ID="CheckTime_2021" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
                                    <epoint:TextBox ID="IsHistory_2021" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="DWName_2021" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="DWGuid_2021" runat="server" MaxLength="50"></epoint:TextBox>
                                    <asp:PlaceHolder ID="controlHolder" runat="server"></asp:PlaceHolder>
                                    <epoint:TextBox ID="Year_2021" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="Month_2021" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                    <epoint:DateTextBox ID="YearMonth_2021" runat="server" InputDateType="Input" Character="HX"
                                        Style="display: none"></epoint:DateTextBox>
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
