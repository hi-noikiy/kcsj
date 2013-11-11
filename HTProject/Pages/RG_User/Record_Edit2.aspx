<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="True"
    Inherits="HTProject.Pages.RG_User.Record_Edit2" Title="修改会员信息" CodeBehind="Record_Edit2.aspx.cs" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script type="text/javascript">
        function window.document.onkeydown() {
            if (event.keyCode == 13) {
                if (window.document.activeElement.tagName != 'TEXTAREA') {
                    event.keyCode = 9;
                }
            }
        }
        
        function SelDW() {
            var strUrl = "SelDW.aspx";
            var rtnVal = OpenDialog(strUrl, 800, 500);
            if (rtnVal != null && rtnVal != "") {
                var ss;
                ss = rtnVal.split("/");
                document.getElementById("<%=DanWeiGuid_2010.ClientID %>").value = ss[0];
                document.getElementById("<%=TxtDanWei.ClientID %>").value = ss[1];

            }
        }
        function OpenChangePwd() {
            OpenDialogArgs('ChangePwd.aspx', null, 400, 200);
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
                            <epoint:Button ID="btnEdit" runat="server" Text="修改保存" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btnEdit_Click"></epoint:Button>
                        </td>
                        <td style="display:none">
                            <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                                Text="取消修改" runat="server" CausesValidation="false" OnClientClick="window.close();">
                            </epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnInitPwd" CssClass="ButtonOkNoBg" MouseOverClass="ButtonOkNoBg"
                                Text="初始密码" runat="server" CausesValidation="false" OnClick="btnInitPwd_Click" OnClientClick="return window.confirm('确定密码初始化？'); ">
                            </epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnChangePwd" CssClass="ButtonAddNoBg" MouseOverClass="ButtonAdd"
                                Text="修改密码" runat="server" CausesValidation="false" OnClientClick="OpenChangePwd();return false;">
                            </epoint:Button>
                        </td>
                        <td>
                            <asp:HiddenField ID="HidTag" runat="server" />
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
                        <asp:HiddenField ID="PIN_2010" runat="server" />
                        <table width="100%" cellspacing="1" align="center">
                            <tr>
                                <td class="TableSpecial1" width="100%" style="text-align: center" colspan="4">
                                    <font style="font-weight: bold">基本信息</font>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    显示名称<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="DispName_2010" runat="server" MaxLength="200" CssClass="inputtxt"
                                        Width="50%"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="req_DispName_2010" runat="server" Display="Dynamic"
                                        ControlToValidate="DispName_2010" ErrorMessage="显示名称：必填！" EnableClientScript="true"
                                        ForeColor="red"></asp:RequiredFieldValidator>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    登录名<font color="red">(*)</font>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LoginID_2010" runat="server" MaxLength="50" CssClass="inputtxt"
                                        contenteditable="false" Width="50%"></epoint:TextBox>
                                    <asp:RequiredFieldValidator ID="req_LoginID_2010" runat="server" Display="Dynamic"
                                        ControlToValidate="LoginID_2010" ErrorMessage="登录名：必填！" EnableClientScript="true"
                                        ForeColor="red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    手机号码
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="Mobile_2010" runat="server" MaxLength="50" CssClass="inputtxt"
                                        Width="50%"></epoint:TextBox><font color="red">用于接收短信</font>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    所属单位
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="DanWeiGuid_2010" runat="server" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="TxtDanWei" runat="server" contenteditable="false" Width="90%"
                                        AllowNull="false" RelationName="所属单位:" CssClass="inputtxt"></epoint:TextBox>
                                    <%--<input id="btnSelDW" type="button" class="Btnbg" value="选择" onclick="SelDW();" />--%>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    性&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;别
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="Sex_2010" runat="server" RepeatLayout="Flow" RepeatDirection="Horizontal"
                                        Width="97%" Height="100%">
                                    </asp:RadioButtonList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    办公电话
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="OfficeTel_2010" runat="server" MaxLength="50" CssClass="inputtxt"
                                        Width="50%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td class="TableSpecial1" width="15%">
                                    单位类别
                                </td>
                                <td class="TableSpecial" colspan="3" height="26" align="left">
                                    <asp:CheckBoxList ID="cblOUType" RepeatLayout="Flow" runat="server" RepeatDirection="Horizontal"
                                        Width="97%" Height="100%">
                                    </asp:CheckBoxList>
                                </td>
                            </tr>
                            <%-- <tr runat="server" id="trPersonal" style="display: none">
                                <td colspan="4">
                                    <table width="100%">
                                        <tr>
                                            <td class="TableSpecial1" width="100%" style="text-align: center" colspan="4">
                                                <font style="font-weight: bold">个人信息</font>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                民&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;族
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left">
                                                <epoint:TextBox ID="Race_2010" runat="server" MaxLength="50" CssClass="inputtxt"
                                                    Width="90%"></epoint:TextBox>
                                            </td>
                                            <td class="TableSpecial1" width="15%">
                                                住宅电话
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left">
                                                <epoint:TextBox ID="HomeTel_2010" runat="server" MaxLength="50" CssClass="inputtxt"
                                                    Width="90%"></epoint:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                生&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;日
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                                <epoint:DateTextBox ID="BirthDay_2010" runat="server" InputDateType="Input" Character="HX"></epoint:DateTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                QQ&nbsp;号码
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left">
                                                <epoint:TextBox ID="QQAccount_2010" runat="server" MaxLength="50" CssClass="inputtxt"
                                                    Width="90%"></epoint:TextBox>
                                            </td>
                                            <td class="TableSpecial1" width="15%">
                                                MSN号码
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left">
                                                <epoint:TextBox ID="MSNAccount_2010" runat="server" MaxLength="50" CssClass="inputtxt"
                                                    Width="90%"></epoint:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                邮政编码
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left">
                                                <epoint:TextBox ID="PostCode_2010" runat="server" MaxLength="50" CssClass="inputtxt"
                                                    Width="90%"></epoint:TextBox>
                                                <asp:RegularExpressionValidator ID="reg_PostCode_2010" runat="server" Display="Dynamic"
                                                    ControlToValidate="PostCode_2010" ErrorMessage="邮政编码：不符合格式要求！" EnableClientScript="true"
                                                    ValidationExpression="\d{6}" ForeColor="red"></asp:RegularExpressionValidator>
                                            </td>
                                            <td class="TableSpecial1" width="15%">
                                                电子信箱
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left">
                                                <epoint:TextBox ID="EMail_2010" runat="server" MaxLength="50" CssClass="inputtxt"
                                                    Width="90%"></epoint:TextBox>
                                                <asp:RegularExpressionValidator ID="reg_EMail_2010" runat="server" Display="Dynamic"
                                                    ControlToValidate="EMail_2010" ErrorMessage="电子信箱：不符合格式要求！" EnableClientScript="true"
                                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="red"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                所&nbsp;在&nbsp;地
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                                <epoint:TextBox ID="SuoZaiDi_2010" runat="server" MaxLength="500" CssClass="inputtxt"
                                                    Width="90%"></epoint:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                通讯地址
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                                <epoint:TextBox ID="Address_2010" runat="server" MaxLength="500" CssClass="inputtxt"
                                                    Width="90%"></epoint:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                其他联系方式
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                                <epoint:TextBox ID="OtherContact_2010" runat="server" MaxLength="200" CssClass="inputtxt"
                                                    Width="90%"></epoint:TextBox>
                                            </td>
                                        </tr>
                                        <tr style="display: none">
                                            <td class="TableSpecial1" width="15%">
                                                照&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;片
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                                <input id="Photo_2010" runat="server" type="file" />&nbsp;<asp:Label ID="lbl_Photo_2010"
                                                    runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                                <epoint:TextBox TextMode="MultiLine" Height="70" CssClass="inputtxt" Width="90%"
                                                    ID="ChangeLog_2010" runat="server" MaxLength="200"></epoint:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="display: none">
                                    <epoint:TextBox ID="UserIdendity_2010" runat="server" Text="0"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr id="trOUInfo" runat="server" style="display: none">
                                <td colspan="4">
                                    <table width="100%">
                                        <tr>
                                            <td class="TableSpecial1" width="100%" style="text-align: center" colspan="4">
                                                <font style="font-weight: bold">单位信息</font>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                单位名称<font color="red">(*)</font>
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left">
                                                <epoint:TextBox ID="EnterpriseName" runat="server" MaxLength="100" Width="100%"></epoint:TextBox>
                                                
                                            </td>
                                            <td class="TableSpecial1" width="15%">
                                                组织机构代码证<font color="red">(*)</font>
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left">
                                                <epoint:TextBox ID="CodeCertificate" runat="server" MaxLength="50" Width="100%"></epoint:TextBox>
                                                
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                单位类型
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                                <asp:CheckBoxList ID="OUType" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow"
                                                    Width="100%">
                                                </asp:CheckBoxList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                法人代表
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left">
                                                <epoint:TextBox ID="LegalPerson" runat="server" MaxLength="50" Width="100%"></epoint:TextBox>
                                            </td>
                                            <td class="TableSpecial1" width="15%">
                                                营业执照编号
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left">
                                                <epoint:TextBox ID="BusinessLicenseNO" runat="server" MaxLength="50" Width="100%"></epoint:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                单位地域性质
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left">
                                                <epoint:TextBox ID="RegionCharacter" runat="server" MaxLength="50" Width="100%"></epoint:TextBox>
                                            </td>
                                            <td class="TableSpecial1" width="15%">
                                                联&nbsp;系&nbsp;人
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left">
                                                <epoint:TextBox ID="Contacter" runat="server" MaxLength="50" Width="100%"></epoint:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                联系电话
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left">
                                                <epoint:TextBox ID="Tel" runat="server" MaxLength="50" Width="100%"></epoint:TextBox>
                                            </td>
                                            <td class="TableSpecial1" width="15%">
                                                联系人身份证号
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left">
                                                <epoint:SpecialTextBox SpecialType="IdentityCard" Width="100%" runat="server" ID="ContacterID"></epoint:SpecialTextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                电子邮件
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                                <epoint:TextBox ID="Email" runat="server" MaxLength="50" Width="100%"></epoint:TextBox>
                                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" Display="Dynamic"
                                                    ControlToValidate="EMail" ErrorMessage="电子信箱：不符合格式要求！" EnableClientScript="true"
                                                    ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="red"></asp:RegularExpressionValidator>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                单位地址
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                                <epoint:TextBox ID="Address" runat="server" MaxLength="200" Width="100%"></epoint:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                注&nbsp;册&nbsp;地
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                                <epoint:TextBox ID="RegistAddress" runat="server" MaxLength="200" Width="100%"></epoint:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                附件上传
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                                <epoint:CtlMisAttachments ID="AttachGuid" width="100%" runat="server" AttachDescCode='' />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="TableSpecial1" width="15%">
                                                备&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;注
                                            </td>
                                            <td class="TableSpecial" width="35%" height="26" align="left" colspan="3">
                                                <epoint:TextBox ID="BeiZhu" runat="server" TextMode="MultiLine" Height="100px" MaxLength="500"></epoint:TextBox>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>--%>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
