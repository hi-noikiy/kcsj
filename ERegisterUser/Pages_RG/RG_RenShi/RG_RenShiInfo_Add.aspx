<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_RenShi.RG_RenShiInfo_Add" Title="新增数据记录"
    CodeBehind="RG_RenShiInfo_Add.aspx.cs" %>

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
        function recheck(txtBox) {
            if (txtBox.value.trim() == "") {
                txtBox.value = "姓名、毕业院校、主要工作经历、本公司担任职务等";
                txtBox.style.color = 'Silver';
            }
        }
        function check(txtBox) {
            if (txtBox.value == "姓名、毕业院校、主要工作经历、本公司担任职务等") {
                txtBox.value = "";
                txtBox.style.color = 'Black';
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
                        <td style="display: none">
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
                                    员工人数
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="YuanGong_2022" runat="server"><NumericProperty TextBoxType="Int" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    兼职人数
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="JianZhi_2022" runat="server"><NumericProperty TextBoxType="Int" /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    博士人数
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="BoShi_2022" runat="server"><NumericProperty TextBoxType="Int" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    硕士人数
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="ShuoShi_2022" runat="server"><NumericProperty TextBoxType="Int" /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    本科人数
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="BenKe_2022" runat="server"><NumericProperty TextBoxType="Int" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    其他人员数量
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="OtherRenYaun_2022" runat="server"><NumericProperty TextBoxType="Int" /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    海归人数
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="HaiGui_2022" runat="server"><NumericProperty TextBoxType="Int" /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    季度
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList runat="server" ID="jpdYear">
                                    </asp:DropDownList>
                                    年
                                    <asp:DropDownList runat="server" ID="jpdMonth">
                                    </asp:DropDownList>
                                    季度
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    海外归国人员信息
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="HaiGuiInfo" runat="server" TextMode="MultiLine" Height="50px"
                                        Width="90%" onBlur="recheck(this)" onfocus="check(this)" Style="color: Silver"
                                        Value="姓名、毕业院校、主要工作经历、本公司担任职务等"></epoint:TextBox>
                                        
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td class="TableSpecial1" width="15%" colspan="4">
                                    <epoint:TextBox ID="UpdateUserName_2022" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="IsHistory_2022" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="Status_2022" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="UpdateUserGuid_2022" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:DateTextBox ID="UpdateTime_2022" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
                                    <epoint:TextBox ID="CheckUserName_2022" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="CheckUserGuid_2022" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="DWName_2022" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="DWGuid_2022" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:DateTextBox ID="CheckTime_2022" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
                                    <asp:PlaceHolder ID="controlHolder" runat="server"></asp:PlaceHolder>
                                    <epoint:DateTextBox CssClass="inputtxt" ID="s_qiJian_2022" runat="server" InputDateType="Input"
                                        Width="202px" Character="HX" Style="display: none"></epoint:DateTextBox>
                                    <epoint:TextBox ID="HaiGuiInfo_2022" runat="server" TextMode="MultiLine" Height="50px"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <script type="text/javascript">

                document.getElementById("<%=HaiGuiInfo.ClientID %>").focus();
                document.getElementById("<%=HaiGuiInfo.ClientID %>").blur();
                
            </script>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowSummary="False"
                ShowMessageBox="True"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
