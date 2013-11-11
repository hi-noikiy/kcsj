<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.Master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages.RG_Module.Record_Add" Title="���ģ��" CodeBehind="Record_Add.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <script>
        function window.document.onkeydown() {
            if (event.keyCode == 13) {
                if (window.document.activeElement.tagName != 'TEXTAREA') {
                    event.keyCode = 9;
                }
            }
        }
        function openicon(controlName, Dir) {
            var url = "../../../Pages/Modules/selectIcon.aspx?Dir=" + Dir;
            var returnIcon;
            returnIcon = OpenDialog(url, "520px", "420px");
            if (returnIcon != "" && typeof (returnIcon) != "undefined") {
                if (controlName == "BigImgAddress_103") {
                    var txt1 = document.getElementById("<%=BigImgAddress_103.ClientID%>");
                    txt1.value = returnIcon;
                }
                else {
                    var txt1 = document.getElementById("<%=SmallImgAddress_103.ClientID%>");
                    txt1.value = returnIcon;
                }

            }
        }
    </script>
    <epoint:AjaxFileUpload ID="AjaxFileUpload1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div id="Div_ControlNoTop">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <epoint:Button ID="btnAdd" runat="server" Text="��ӱ���" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnAdd_Click"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                                Text="ȡ�����" runat="server" CausesValidation="false" OnClientClick="window.close();">
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
                    <td id="tdContainer" valign="top" align="center" runat="server">
                        <table width="100%" cellspacing="1" align="center" id="tabContent">
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ģ������<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ModuleName_103" runat="server" Width="80%" MaxLength="100"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="req_ModuleName_103" runat="server" Display="Dynamic"
                                        ControlToValidate="ModuleName_103" ErrorMessage="ģ�����ƣ����" EnableClientScript="true"
                                        ForeColor="red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="trBelongtoApp" runat="server">
                                <td class="TableSpecial1" width="15%">
                                    �ҽ�Ӧ��ϵͳ
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="BelongToApp" runat="server" Width="80%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ģ���ַ
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ModuleAddress_103" runat="server" Width="80%" MaxLength="200"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ���ص�ַ
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="HidUrl_103" runat="server" Width="80%" MaxLength="200"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ����
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="OrderNum_103" runat="server" Width="80%"><NumericProperty TextBoxType=Int /></epoint:NumericTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    �Ƿ�����ҵ��
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsBelongtoBus_103" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="80%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    �Ƿ����
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsForbid_103" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="80%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    �Ƿ�����
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsHidden_103" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="80%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    �Ƿ񵯳��´���
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsBlank_103" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="80%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ģ��ͼƬ����
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="BigImgAddress_103" CssClass="inputtxt" runat="server" MaxLength="200"
                                        Width="80%"></epoint:TextBox>
                                    <%-- <asp:TextBox ID="txtbigIconAddress" CssClass="inputtxt" runat="server"></asp:TextBox>--%>
                                    <input class="BtnTime" onclick="openicon('BigImgAddress_103','Images/ModuleImages/BigIcon')"
                                        type="button">
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    ģ��ͼƬ��С��
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="SmallImgAddress_103" CssClass="inputtxt" runat="server" MaxLength="200"
                                        Width="80%"></epoint:TextBox>
                                    <input class="BtnTime" onclick="openicon('SmallImgAddress_103','Images/ModuleImages/SmallIcon')"
                                        type="button">
                                </td>
                            </tr>
                            <tr>
                                <td style="display: none">
                                    <asp:RadioButtonList ID="IsBelongtoApp_103" runat="server" RepeatDirection="Horizontal"
                                        RepeatLayout="Flow" Width="80%" Height="100%">
                                    </asp:RadioButtonList>
                                    <epoint:TextBox ID="ParentGuid_103" runat="server"></epoint:TextBox>
                                    <epoint:TextBox ID="AppGuid_103" runat="server"></epoint:TextBox>
                                    <epoint:TextBox ID="ModuleCode_103" runat="server"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <span style="color: Red; padding-left: 10px">ע�⣺���ص�ַ����������ʽ�����¼�ĵ�ַ��������ģ��ʱ���ص�ַΪ�գ���ḳ������Ӧ��ϵͳ�����ص�ַ��</span>
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
