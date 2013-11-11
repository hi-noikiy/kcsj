<%@ Page Language="C#" MasterPageFile="~/WebMaster/OpenWin_FixHead.master" AutoEventWireup="true"
    Inherits="HTProject.Pages.RG_OU.RG_OU_Edit2" Title="修改数据记录" CodeBehind="RG_OU_Edit2.aspx.cs" %>

<%@ Register TagPrefix="uc1" TagName="FJ" Src="../../Ascx/FuJian.ascx" %>
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
                                OnClick="btnEdit_Click" CausesValidation="false"></epoint:Button>
                        </td>
                        <td>
                            <epoint:Button ID="btSubmit" runat="server" Text="提交审核" CssClass="ButtonConNoBg"
                                MouseOverClass="ButtonCon" OnClick="btSubmit_Click" OnClientClick="return MyPageValidate('确定提交？');">
                            </epoint:Button>
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

            <script language="JavaScript" type="text/javascript" src="../../../JavaScript/navbar.js"></script>

            <link href="../../../JavaScript/navbar-pix.css" rel="stylesheet" type="text/css" />

            <script type="text/javascript">
                var show = false;
                var hide = true
                //修改菜单的上下箭头符号
                function my_on(head, body) {
                    var tag_a;
                    for (var i = 0; i < head.childNodes.length; i++) {
                        if (head.childNodes[i].nodeName == "A") {
                            tag_a = head.childNodes[i];
                            break;
                        }
                    }
                    tag_a.className = "on";
                }
                function my_off(head, body) {
                    var tag_a;
                    for (var i = 0; i < head.childNodes.length; i++) {
                        if (head.childNodes[i].nodeName == "A") {
                            tag_a = head.childNodes[i];
                            break;
                        }
                    }
                    tag_a.className = "off";
                }
                //添加菜单	
                window.onload = function() {
                    m1 = new Menu("menuQY", 'qyInfo', 'A1', '100', show, my_on, my_off);
                    m1.init();
                    m2 = new Menu("menuZZ", 'zzInfo', 'A2', '100', show, my_on, my_off);
                    m2.init();
                    m3 = new Menu("menuRY", 'ryInfo', 'A3', '100', show, my_on, my_off);
                    m3.init();
                    m4 = new Menu("menuXM", 'xmInfo', 'A4', '100', show, my_on, my_off);
                    m4.init();
                }
			
            </script>

            <table cellpadding="0" cellspacing="0" border="0" width="100%">
                <tr>
                    <td height="36" style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                        align="center" valign="middle">
                        <%=ViewState ["TableName"]%>
                    </td>
                </tr>
                <tr>
                    <td id="tdContainer" valign="top" align="center" runat="server">
                        <table width="100%" height="100%" align="center">
                            <tr>
                                <td>
                                    <div class="tit" id="menuQY" title="点击查看企业信息">
                                        <div class="titpic" id="pcQY">
                                        </div>
                                        <a title="点击查看企业信息" target="" class="on" id="A1" tabindex="1">点击查看企业信息 </a>
                                    </div>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" cellspacing="1" align="center" id="qyInfo">
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
                                    <epoint:NumericTextBox ID="ZhuCeZiBen_2017" runat="server" TextAlign="Right" AllowNull="false" RelationName="注册资本" Style="padding-right: 2px;
                                        padding-left: 2px" Width="80%"><NumericProperty TextBoxType="Numeric" Precision="4" /></epoint:NumericTextBox>万元
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
                                <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                    <epoint:TextBox ID="DanWeiXZ_2017" runat="server" MaxLength="50" Width="80%" AllowNull="false" RelationName="单位性质"></epoint:TextBox>
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
                                    <uc1:FJ ID="QY_GSZZ_Z" runat="server"></uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_GSZZ_F" runat="server"></uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_ZZJGDMZ" runat="server"></uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_FRSFZ" runat="server"></uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_FRQM" runat="server"></uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_SBZM" runat="server"></uc1:FJ>
                                    <br />
                                    <uc1:FJ ID="QY_QYQT" runat="server"></uc1:FJ>
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
                                </td>
                            </tr>
                            <tr>
                            </tr>
                        </table>
                        <table width="100%" height="100%" align="center">
                            <tr>
                                <td>
                                    <div class="tit" id="menuZZ" title="点击查看企业资质">
                                        <div class="titpic" id="pcZZ">
                                        </div>
                                        <a title="点击查看企业资质" target="" class="off" id="A2" tabindex="2">点击查看企业资质 </a>
                                    </div>
                                </td>
                            </tr>
                        </table>

                        <script type="text/javascript">
                            function OpenZZUrl() {
                                OpenWindow('../RG_QYZiZhi/RG_QYZiZhi_Add.aspx?ParentRowGuid=<%=Request.QueryString["ParentRowGuid"]%>&DWGuid=<%=Request["RowGuid"]%>', 800, 700);
                            }
                        </script>

                        <table width="100%" cellspacing="1" id="zzInfo">
                            <tr>
                                <td colspan="2">
                                    &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonAdd" CssClass="ButtonAddNoBg"
                                        ID="btnAddZZ" OnClientClick="OpenZZUrl();return false;" runat="server" Text="新增资质" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" style="height: 31px" class="tablespecial">
                                    <webdiyer:AspNetPager ID="PagerZZ" runat="server" AlwaysShow="True" SubmitButtonClass="backendbtn22"
                                        InputBoxClass="inputtxt" ShowCustomInfoSection="Left" ButtonImageNameExtension="n"
                                        DisabledButtonImageNameExtension="g" CpiButtonImageNameExtension="r" ImagePath="../../../images/page/"
                                        PagingButtonType="Image" NavigationButtonType="Image" PageSize="20" OnPageChanged="PagerZZ_PageChanged">
                                    </webdiyer:AspNetPager>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:DataGrid ID="DGZZ" runat="server" CssClass="GridView" PageSize="20" BorderWidth="1px"
                                        AccessKey="1" DataKeyField="RowGuid" AutoGenerateColumns="False" AllowPaging="True"
                                        AllowSorting="True" Width="100%" OnItemCreated="DGZZ_ItemCreated">
                                        <PagerStyle Visible="False"></PagerStyle>
                                        <AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
                                        <ItemStyle CssClass="RowStyle"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center" Height="30px" CssClass="HeaderStyle"></HeaderStyle>
                                        <Columns>
                                            <asp:TemplateColumn HeaderText="序号">
                                                <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                                <ItemTemplate>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="资质类别">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container, "DataItem.ZiZhiText") %>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="资质编号">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container, "DataItem.ZiZhiCode") %>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="资质截止日期">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container, "DataItem.ZiZhiEndDate", "{0:yyyy-MM-dd}") %>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="审核状态">
                                                <ItemTemplate>
                                                    <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("审核状态", Convert.ToString(DataBinder.Eval(Container, "DataItem.Status"))) %>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="查看">
                                                <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                                <ItemTemplate>
                                                    <a href='javascript:OpenWindow("../RG_QYZiZhi/RG_QYZiZhi_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>")'>
                                                        <img src='../../../images/bigview.gif' border='0'></a>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="修改">
                                                <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                                <ItemTemplate>
                                                    <%# new HTProject_Bizlogic.DB_RG_DW().GetOperateButton(DataBinder.Eval(Container, "DataItem.RowGuid"), DataBinder.Eval(Container, "DataItem.Status"), "../RG_QYZiZhi/RG_QYZiZhi_Edit.aspx", "../../../images/add1.gif","ouedit")%>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <PagerStyle Visible="False"></PagerStyle>
                                    </asp:DataGrid>
                                </td>
                            </tr>
                        </table>
                        <table width="100%" height="100%" align="center">
                            <tr>
                                <td>
                                    <div class="tit" id="menuRY" title="点击查看企业人员">
                                        <div class="titpic" id="pcRY">
                                        </div>
                                        <a title="点击查看企业人员" target="" class="off" id="A3" tabindex="3">点击查看企业人员 </a>
                                    </div>
                                </td>
                            </tr>
                        </table>

                        <script type="text/javascript">
                            function OpenRYUrl() {
                                OpenWindow('../RG_QYUser/RG_QYUser_Add.aspx?ParentRowGuid=<%=Request.QueryString["ParentRowGuid"]%>&DWGuid=<%=Request["RowGuid"]%>', 800, 700);
                            }
                        </script>

                        
                        <table width="100%" cellspacing="1" id="ryInfo">
                            <tr>
                                <td colspan="2">
                                    &nbsp;<epoint:Button ForeColor="black" MouseOverClass="ButtonAdd" CssClass="ButtonAddNoBg"
                                        ID="btnAddRY" OnClientClick="OpenRYUrl();return false;" runat="server" Text="新增人员" />
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="2" style="height: 31px" class="tablespecial">
                                    <webdiyer:AspNetPager ID="PagerRY" runat="server" AlwaysShow="True" SubmitButtonClass="backendbtn22"
                                        InputBoxClass="inputtxt" ShowCustomInfoSection="Left" ButtonImageNameExtension="n"
                                        DisabledButtonImageNameExtension="g" CpiButtonImageNameExtension="r" ImagePath="../../../images/page/"
                                        PagingButtonType="Image" NavigationButtonType="Image" PageSize="20" OnPageChanged="PagerRY_PageChanged">
                                    </webdiyer:AspNetPager>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:DataGrid ID="DGRY" runat="server" CssClass="GridView" PageSize="20" BorderWidth="1px"
                                        AccessKey="1" DataKeyField="RowGuid" AutoGenerateColumns="False" AllowPaging="True"
                                        AllowSorting="True" Width="100%" OnItemCreated="DGRY_ItemCreated">
                                        <PagerStyle Visible="False"></PagerStyle>
                                        <AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
                                        <ItemStyle CssClass="RowStyle"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center" Height="30px" CssClass="HeaderStyle"></HeaderStyle>
                                        <Columns>
                                            <asp:TemplateColumn HeaderText="序号">
                                                <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                                <ItemTemplate>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="姓名">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container, "DataItem.XM") %>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="性别">
                                                <ItemTemplate>
                                                    <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("性别", Convert.ToString(DataBinder.Eval(Container, "DataItem.Sex"))) %>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="身份证号码">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container, "DataItem.IDNum") %>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="职称">
                                                <ItemTemplate>
                                                    <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("职称", Convert.ToString(DataBinder.Eval(Container, "DataItem.ZhiCheng"))) %>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="合同截止时间">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container, "DataItem.HeTongEndDate", "{0:yyyy-MM-dd}") %>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="执业印章号">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container, "DataItem.YinZhangNo") %>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="从事专业">
                                                <ItemTemplate>
                                                    <%# RG_DW.GetItemTextByLen2("29b7967e-8098-42d5-8b40-ec757b0865a5", DataBinder.Eval(Container, "DataItem.ZhuanYeCSCode"), 4)%>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="注册专业">
                                                <ItemTemplate>
                                                    <%# RG_DW.GetItemTextByLen2("29b7967e-8098-42d5-8b40-ec757b0865a5", DataBinder.Eval(Container, "DataItem.ZhuanYeCSCode"), 0)%>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="工龄">
                                                <ItemTemplate>
                                                    <%# DataBinder.Eval(Container, "DataItem.GongLing") %>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="状态">
                                                <ItemTemplate>
                                                    <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("审核状态", Convert.ToString(DataBinder.Eval(Container, "DataItem.Status"))) %>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="查看">
                                                <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                                <ItemTemplate>
                                                    <a href='javascript:OpenWindow("../RG_QYUser/RG_QYUser_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>")'>
                                                        <img src='../../../images/bigview.gif' border='0'></a>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="修改">
                                                <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                                <ItemTemplate>
                                                    <%# new HTProject_Bizlogic.DB_RG_DW().GetOperateButton(DataBinder.Eval(Container, "DataItem.RowGuid"), DataBinder.Eval(Container, "DataItem.Status"), "../RG_QYUser/RG_QYUser_Edit.aspx", "../../../images/add1.gif", "ouedit")%>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <PagerStyle Visible="False"></PagerStyle>
                                    </asp:DataGrid>
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
