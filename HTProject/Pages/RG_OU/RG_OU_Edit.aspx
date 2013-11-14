<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_OU.RG_OU_Edit" Title="修改数据记录" CodeBehind="RG_OU_Edit.aspx.cs" %>

<%@ Register TagPrefix="uc1" TagName="FJ" Src="../../Ascx/FuJian.ascx" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">

    <script>
        function window.document.onkeydown() {
            if (event.keyCode == 13) {
                if (window.document.activeElement.tagName != 'TEXTAREA') {
                    event.keyCode = 9;
                }
            }
        }
        function MyPageValidate(message) {
            var bRet = false;
            if (Page_ClientValidate()) {
                return window.confirm(message);
            }
            else {
                bRet = false;
            }
            return bRet;
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
                                OnClick="btnEdit_Click" OnClientClick="return MyPageValidate('确定修改？修改后状态变为[变更中]，请及时提交审核');"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btSubmit" runat="server" Text="提交审核" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon"
                                OnClick="btSubmit_Click" OnClientClick="return MyPageValidate('确定提交？');"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btnCancle" CssClass="ButtonCancleNoBg" MouseOverClass="ButtonCancle"
                                Text="取消修改" runat="server" CausesValidation="false" OnClientClick="window.close();">
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
                    <td height="36" style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                        align="center" valign="middle">
                        <%=ViewState ["TableName"]%>
                    </td>
                </tr>
                <tr>
                    <td id="tdContainer" valign="top" align="center" runat="server">
                        <table width="100%" cellspacing="1" align="center">
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    企业中文名称<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="EnterpriseName_2017" runat="server" MaxLength="200" AllowNull="false"
                                        Width="80%" RelationName="企业中文名称"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    企业英文名称
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="EnterpriseEName_2017" runat="server" MaxLength="500" Width="80%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    营业执照号码<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YingYeZZ_2017" runat="server" MaxLength="50" AllowNull="false"
                                        Width="80%" RelationName="营业执照号码"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    组织机构代码<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="ZuZhiJGDM_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="组织机构代码"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    法定代表人<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="FaRen_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="法定代表人"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    法定代表人证件类型
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="FaRenZJType_2017" runat="server" Height="100%" Width="80%">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    企业负责人<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="QiYeFZR_2017" runat="server" MaxLength="50"  AllowNull="false" RelationName="企业负责人"
                                        Width="80%"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    技术负责人<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="JiShuFZR_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="技术负责人"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    法定代表人证件号<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="FaRenZJH_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="法定代表人证件号"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    注册资本<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="ZhuCeZiBen_2017" runat="server" TextAlign="Right" Style="padding-right: 2px;
                                        padding-left: 2px" Width="80%" AllowNull="false" RelationName="注册资本"><NumericProperty TextBoxType="Numeric" Precision="4" /></epoint:NumericTextBox>万元
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    成立日期<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:DateTextBox ID="ChengLiDate_2017" runat="server" InputDateType="Select" Character="HX"
                                        AllowNull="false" RelationName="成立日期"></epoint:DateTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    注册地区<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextTreeView ID="RegionTreeView" runat="server" DivHeight="450px" RelationName="注册地区"
                                        DivWidth="180px" ImgFolds="../../../Images/TreeImages" OnTreeNodePopulate="RegionTreeView_TreeNodePopulate"
                                        RootNodeText="行政区划选择" TextCssClass="Inputtxt" Width="200px" OnlyReturnLeaf="true"
                                        InputType="Radio" AllowNull="false">
                                    </epoint:TextTreeView>
                                    <epoint:TextBox ID="RegistAddress_2017" runat="server" MaxLength="100" Height="28px"
                                        Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="RegistAddressCode_2017" runat="server" MaxLength="100" Height="28px"
                                        Style="display: none"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    注册详细地址<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="ZhuCeDi_XX_2017" runat="server" MaxLength="200" Width="80%" AllowNull="false" RelationName="注册详细地址"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    邮政编码<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="YouZhengCode_2017" runat="server" MaxLength="50" AllowNull="false"
                                        Width="80%" RelationName="邮政编码"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    单位电话<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="DanWeiTel_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="单位电话"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    单位性质<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="DanWeiXZ_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="单位性质"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    是否年度备案企业
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:RadioButtonList ID="IsNDBA_2017" runat="server" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    联系人<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRen_2017" runat="server" MaxLength="50" AllowNull="false"
                                        Width="80%" RelationName="联系人"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    联系人电话<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenTel_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="联系人电话"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    联系人手机<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenMobile_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="联系人手机"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    联系人Email<span style="color: Red">*</span>
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenEmail_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="联系人Email"></epoint:TextBox>
                                    <asp:RegularExpressionValidator ID="reg_LianXiRenEmail_2017" runat="server" Display="Dynamic"
                                        ControlToValidate="LianXiRenEmail_2017" ErrorMessage="联系人Email：不符合格式要求！" EnableClientScript="true"
                                        ValidationExpression="\w+([']-+.]\w+)*@\w+([']-.]\w+)*\.\w+([']-.]\w+)*" ForeColor="Red"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    相关附件
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <uc1:FJ ID="QY_GSZZ_Z" runat="server">
                                    </uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_GSZZ_F" runat="server">
                                    </uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_ZZJGDMZ" runat="server">
                                    </uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_FRSFZ" runat="server">
                                    </uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_FRQM" runat="server">
                                    </uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_SBZM" runat="server">
                                    </uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_QYQT" runat="server">
                                    </uc1:FJ>
                                </td>
                            </tr>
                            <tr style="display: none">
                                <td class="TableSpecial1" width="15%">
                                    删除状态
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="DelFlag_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    状态
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="Status_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                    <epoint:TextBox ID="TJRGuid_2017" runat="server" MaxLength="50"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
