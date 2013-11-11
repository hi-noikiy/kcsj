<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="true"
    Inherits="EpointRegisterUser.Pages.RG_OU.RG_OU_Edit" Title="修改单位信息" CodeBehind="RG_OU_Edit.aspx.cs" %>

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
                    <td id="tdContainer" valign="top" align="center" runat="server">
                        <table width="100%" cellspacing="1" align="center">
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    企业中文名称
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="EnterpriseName_2017" runat="server" MaxLength="200" AllowNull="false"
                                        CssClass="inputtxt" Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    企业英文名称
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="EnterpriseEName_2017" runat="server" MaxLength="500"
                                        CssClass="inputtxt" Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    注册商标
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <%--<epoint:CtlMisAttachments ID="ShangBiao_2017" width="100%" runat="server" AttachDescCode='' />--%>
                                    <uc1:CaiLiao ID="CL_SB" runat="server" YeWuMC="企业-注册商标" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    Logo
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <%--<epoint:CtlMisAttachments ID="Logo_2017" width="100%" runat="server" AttachDescCode='' />--%>
                                    <uc1:CaiLiao ID="CL_Logo" runat="server" YeWuMC="企业-Logo" />
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
                                    <epoint:TextTreeView ID="tvZCD" runat="server" AllowNull="false" DivHeight="450px"
                                        RelationName="注册地区" DivWidth="180px" ImgFolds="../../../Images/TreeImages" OnTreeNodePopulate="RegionTreeView_TreeNodePopulate"
                                        RootNodeText="行政区划选择" TextCssClass="Inputtxt" Width="200px" OnlyReturnLeaf="true"
                                        InputType="Radio">
                                    </epoint:TextTreeView>
                                    <epoint:TextBox ID="ZhuCeDi_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="ZhuCeDiCode_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    注册详细地址
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="ZhuCeDi_XX_2017" runat="server" MaxLength="200" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    运营地1
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextTreeView ID="tvYYD1" runat="server"  DivHeight="450px"
                                         DivWidth="180px" ImgFolds="../../../Images/TreeImages" OnTreeNodePopulate="RegionTreeView_TreeNodePopulate"
                                        RootNodeText="行政区划选择" TextCssClass="Inputtxt" Width="300px" OnlyReturnLeaf="true"
                                        InputType="Radio">
                                    </epoint:TextTreeView>
                                    <epoint:TextBox ID="YunYingDi1_2017" runat="server" MaxLength="200" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="YunYingDi1Code_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    运营详细地址1
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextBox ID="YunYingDi1_XX_2017" runat="server" MaxLength="200" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    运营地2
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextTreeView ID="tvYYD2" runat="server"  DivHeight="450px"
                                         DivWidth="180px" ImgFolds="../../../Images/TreeImages" OnTreeNodePopulate="RegionTreeView_TreeNodePopulate"
                                        RootNodeText="行政区划选择" TextCssClass="Inputtxt" Width="300px" OnlyReturnLeaf="true"
                                        InputType="Radio">
                                    </epoint:TextTreeView>
                                    <epoint:TextBox ID="YunYingDi2_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="YunYingDi2Code_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    运营详细地址2
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextBox ID="YunYingDi2_XX_2017" runat="server" MaxLength="200" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    运营地3
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextTreeView ID="tvYYD3" runat="server"  DivHeight="450px"
                                         DivWidth="180px" ImgFolds="../../../Images/TreeImages" OnTreeNodePopulate="RegionTreeView_TreeNodePopulate"
                                        RootNodeText="行政区划选择" TextCssClass="Inputtxt" Width="300px" OnlyReturnLeaf="true"
                                        InputType="Radio">
                                    </epoint:TextTreeView>
                                    <epoint:TextBox ID="YunYingDi3_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                    <epoint:TextBox ID="YunYingDi3Code_2017" runat="server" MaxLength="50" Style="display: none"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    运营详细地址3
                                </td>
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="YunYingDi3_XX_2017" runat="server" MaxLength="200" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    招商载体
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextBox ID="ZhaoShangZT_2017" runat="server" CssClass="inputtxt" Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    企业类型
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="QiYeType_2017" runat="server" Width="90%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    联系人
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRen_2017" runat="server" MaxLength="50" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    联系人电话
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenTel_2017" runat="server" MaxLength="50" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    联系人手机
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenMobile_2017" runat="server" MaxLength="50" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    联系人Email
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenEmail_2017" runat="server" MaxLength="50" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                    <asp:RegularExpressionValidator ID="reg_LianXiRenEmail_2017" runat="server" Display="Dynamic"
                                        ControlToValidate="LianXiRenEmail_2017" ErrorMessage="联系人Email：不符合格式要求！" EnableClientScript="true"
                                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ForeColor="red"></asp:RegularExpressionValidator>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    联系人职务
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="LianXiRenZW_2017" runat="server" MaxLength="100" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    公司简介
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextBox ID="GongSiJJ_2017" runat="server" CssClass="inputtxt" Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    公司介绍PPT
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <%--<epoint:CtlMisAttachments ID="GongSiJS_2017" width="100%" runat="server" AttachDescCode='' />--%>
                                    <uc1:CaiLiao ID="CL_GSJS" runat="server" YeWuMC="企业-公司介绍" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    税收征管方式
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <asp:DropDownList ID="ShuiShouFS_2017" runat="server" Width="90%" Height="100%">
                                    </asp:DropDownList>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    说明
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="WenZiSM_2017" runat="server" CssClass="inputtxt" Width="90%"></epoint:TextBox>
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
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <%--<epoint:CtlMisAttachments ID="ZhengShu_2017" width="100%" runat="server" AttachDescCode='' />--%>
                                    <uc1:CaiLiao ID="CL_ZS" runat="server" YeWuMC="企业-证书" />
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    董事席数
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="DongShiXS_2017" runat="server" CssClass="inputtxt" Width="90%"><NumericProperty TextBoxType=Int /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    董事姓名
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="DongShiXM_2017" runat="server" MaxLength="100" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    监事席数
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:NumericTextBox ID="JianShiXS_2017" runat="server" CssClass="inputtxt" Width="90%"><NumericProperty TextBoxType=Int /></epoint:NumericTextBox>
                                </td>
                                <td class="TableSpecial1" width="15%">
                                    监事名单
                                </td>
                                <td class="TableSpecial" width="35%" height="26" align="left">
                                    <epoint:TextBox ID="JianShiXM_2017" runat="server" MaxLength="100" CssClass="inputtxt"
                                        Width="90%"></epoint:TextBox>
                                </td>
                            </tr>
                            <%--<tr>
                                <td class="TableSpecial1" width="15%">
                                    高管名单
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <epoint:TextBox ID="GaoGuanMD_2017" runat="server" CssClass="inputtxt" Width="90%"></epoint:TextBox>
                                </td>
                            </tr>--%>
                            <tr>
                                <td class="TableSpecial1" width="15%">
                                    高管名单
                                </td>
                                <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                    <%--<epoint:TextBox ID="GaoGuanMD_2017" runat="server" CssClass="inputtxt" Width="90%"></epoint:TextBox>--%>
                                    <%--<epoint:Button ForeColor="black" MouseOverClass="ButtonAdd" CssClass="ButtonAddNoBg"
                                        ID="btnAddRecord" OnClientClick="OpenUrl();return false;" runat="server" Text="新增记录" />&nbsp;<epoint:DeleteButton
                                            Text="删除选定" ID="btnDel" MouseOverClass="ButtonDel" runat="server" CssClass="ButtonDelNoBg"
                                            OnClick="btnDel_Click" OnClientClick="if(!Check_SelectedStatus('chkAdd')) return false;"
                                            RaiseMsg="您确定删除选定记录吗?" /><br />--%>
                                    <webdiyer:AspNetPager ID="Pager2" runat="server" AlwaysShow="True" SubmitButtonClass="backendbtn22"
                                        InputBoxClass="inputtxt" ShowCustomInfoSection="Left" ButtonImageNameExtension="n"
                                        DisabledButtonImageNameExtension="g" CpiButtonImageNameExtension="r" ImagePath="../../../images/page/"
                                        PagingButtonType="Image" NavigationButtonType="Image" PageSize="500" Visible="false">
                                    </webdiyer:AspNetPager>
                                    <asp:DataGrid ID="Datagrid2" runat="server" CssClass="GridView" PageSize="500" BorderWidth="1px"
                                        AccessKey="1" DataKeyField="RowGuid" AutoGenerateColumns="False" AllowPaging="True"
                                        AllowSorting="True" Width="100%" OnItemCreated="Datagrid2_ItemCreated" OnSortCommand="Datagrid2_SortCommand">
                                        <PagerStyle Visible="False"></PagerStyle>
                                        <AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
                                        <ItemStyle CssClass="RowStyle"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center" Height="30px" CssClass="HeaderStyle"></HeaderStyle>
                                        <Columns>
                                            <asp:TemplateColumn Visible="false">
                                                <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                                <HeaderTemplate>
                                                    <input id="chkAddAll" onclick="javascript:AllSelect(this)" type="checkbox" name="chkAdd2">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkAdd2" runat="server"></asp:CheckBox>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="序号">
                                                <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                                <ItemTemplate>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="姓名" SortExpression="Name">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container, "DataItem.Name")%>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="国籍" SortExpression="GuoJi">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container, "DataItem.GuoJi")%>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="职务" SortExpression="ZhiWu">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container, "DataItem.ZhiWu")%>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="查看">
                                                <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                                <ItemTemplate>
                                                    <a href='javascript:OpenWindow("../../Pages_RG/RG_GaoGuan/RG_GaoGuan_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&DWGuid=<%#DataBinder.Eval(Container.DataItem,"DWGuid")%>",400,400)'>
                                                        <img src='../../../images/bigview.gif' border='0'></a>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="修改" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                                <ItemTemplate>
                                                    <a href='javascript:OpenWindow("../../Pages_RG/RG_GaoGuan/RG_GaoGuan_Edit.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&DWGuid=<%#DataBinder.Eval(Container.DataItem,"DWGuid")%>",400,400)'>
                                                        <img src='../../../images/add1.gif' border='0'></a>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <PagerStyle Visible="False"></PagerStyle>
                                    </asp:DataGrid>
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
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
                ShowSummary="False"></asp:ValidationSummary>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
