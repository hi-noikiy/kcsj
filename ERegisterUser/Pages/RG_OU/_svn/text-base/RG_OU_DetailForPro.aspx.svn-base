<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="true"
    Inherits="EpointRegisterUser.Pages.RG_OU.RG_OU_DetailForPro" Title="查看企业信息" CodeBehind="RG_OU_DetailForPro.aspx.cs" %>

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
<%@ Register Assembly="Infragistics2.WebUI.UltraWebTab.v6.3, Version=6.3.20063.53, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb"
    Namespace="Infragistics.WebUI.UltraWebTab" TagPrefix="igtab" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <igtab:UltraWebTab ID="MultiTab" runat="server" BorderWidth="1px" ThreeDEffect="False"
        Height="100%" Width="100%" BorderStyle="Solid" LoadAllTargetUrls="False" ImageDirectory="../../../images/"
        DynamicTabs="False">
        <DefaultTabStyle Height="22px" Font-Size="8pt" Font-Names="Verdana" ForeColor="Black"
            BackColor="GhostWhite">
            <Padding Top="1px"></Padding>
        </DefaultTabStyle>
        <RoundedImage LeftSideWidth="7" RightSideWidth="6" ShiftOfImages="2" SelectedImage="ig_tab_winXPs1.gif"
            NormalImage="ig_tab_winXPs3.gif" HoverImage="ig_tab_winXPs2.gif" FillStyle="LeftMergedWithCenter">
        </RoundedImage>
        <SelectedTabStyle>
            <Padding Bottom="2px"></Padding>
        </SelectedTabStyle>
        <Tabs>
            <igtab:Tab Text="&#160;&#160;企业信息&#160;&#160;">
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
                                            <asp:Label ID="EnterpriseName_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            企业英文名称
                                        </td>
                                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                            <asp:Label ID="EnterpriseEName_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            注册商标
                                        </td>
                                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                            <uc1:CaiLiao ID="CL_SB" runat="server" YeWuMC="企业-注册商标" ReadOnly="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            Logo
                                        </td>
                                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                            <uc1:CaiLiao ID="CL_Logo" runat="server" YeWuMC="企业-Logo" ReadOnly="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            成立日期
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="ChengLiDate_2017" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableSpecial1" width="15%">
                                            注册地
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="ZhuCeDi_2017" runat="server"></asp:Label>
                                            <asp:Label ID="ZhuCeDiCode_2017" runat="server" MaxLength="50" Style="display: none"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            注册详细地址
                                        </td>
                                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                            <asp:Label ID="ZhuCeDi_XX_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            运营地1
                                        </td>
                                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                            <asp:Label ID="YunYingDi1_2017" runat="server"></asp:Label>
                                            <asp:Label ID="YunYingDi1Code_2017" runat="server" MaxLength="50" Style="display: none"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            运营详细地址1
                                        </td>
                                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                            <asp:Label ID="YunYingDi1_XX_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            运营地2
                                        </td>
                                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                            <asp:Label ID="YunYingDi2_2017" runat="server"></asp:Label>
                                            <asp:Label ID="YunYingDi2Code_2017" runat="server" MaxLength="50" Style="display: none"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            运营详细地址2
                                        </td>
                                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                            <asp:Label ID="YunYingDi2_XX_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            运营地3
                                        </td>
                                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                            <asp:Label ID="YunYingDi3_2017" runat="server"></asp:Label>
                                            <asp:Label ID="YunYingDi3Code_2017" runat="server" MaxLength="50" Style="display: none"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            运营详细地址3
                                        </td>
                                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                                            <asp:Label ID="YunYingDi3_XX_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            招商载体
                                        </td>
                                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                            <asp:Label ID="ZhaoShangZT_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            企业类型
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="QiYeType_2017" runat="server">
                                            </asp:Label>
                                        </td>
                                        <td class="TableSpecial1" width="15%">
                                            联系人
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="LianXiRen_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            联系人电话
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="LianXiRenTel_2017" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableSpecial1" width="15%">
                                            联系人手机
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="LianXiRenMobile_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            联系人Email
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="LianXiRenEmail_2017" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableSpecial1" width="15%">
                                            联系人职务
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="LianXiRenZW_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            公司简介
                                        </td>
                                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                            <asp:Label ID="GongSiJJ_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            公司介绍PPT
                                        </td>
                                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                            <uc1:CaiLiao ID="CL_GSJS" runat="server" YeWuMC="企业-公司介绍" ReadOnly="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            税收征管方式
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="ShuiShouFS_2017" runat="server">
                                            </asp:Label>
                                        </td>
                                        <td class="TableSpecial1" width="15%">
                                            说明
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="WenZiSM_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            高新技术企业
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="Is_GX_2017" runat="server">
                                            </asp:Label>
                                        </td>
                                        <td class="TableSpecial1" width="15%">
                                            批准日期
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="PiZhunDate_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            证书
                                        </td>
                                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                            <uc1:CaiLiao ID="CL_ZS" runat="server" YeWuMC="企业-证书" ReadOnly="true" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            董事席数
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="DongShiXS_2017" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableSpecial1" width="15%">
                                            董事姓名
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="DongShiXM_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            监事席数
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="JianShiXS_2017" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableSpecial1" width="15%">
                                            监事名单
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="JianShiXM_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <%--<tr>
                                        <td class="TableSpecial1" width="15%">
                                            高管名单
                                        </td>
                                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                                            <asp:Label ID="GaoGuanMD_2017" runat="server"></asp:Label>
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
                                                    <a href='javascript:OpenWindow("../RG_GaoGuan/RG_GaoGuan_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&DWGuid=<%#DataBinder.Eval(Container.DataItem,"DWGuid")%>",400,400)'>
                                                        <img src='../../../images/bigview.gif' border='0'></a>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                            <asp:TemplateColumn HeaderText="修改" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                                <ItemTemplate>
                                                    <a href='javascript:OpenWindow("../RG_GaoGuan/RG_GaoGuan_Edit.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&DWGuid=<%#DataBinder.Eval(Container.DataItem,"DWGuid")%>",400,400)'>
                                                        <img src='../../../images/add1.gif' border='0'></a>
                                                </ItemTemplate>
                                            </asp:TemplateColumn>
                                        </Columns>
                                        <PagerStyle Visible="False"></PagerStyle>
                                    </asp:DataGrid>
                                </td>
                            </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            更新人
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="UpdateUserName_2017" runat="server" MaxLength="50"></asp:Label>
                                        </td>
                                        <td class="TableSpecial1" width="15%">
                                            更新时间
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="UpdateTime_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%">
                                            审核人
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="CheckUserName_2017" runat="server"></asp:Label>
                                        </td>
                                        <td class="TableSpecial1" width="15%">
                                            审核时间
                                        </td>
                                        <td class="TableSpecial" width="35%" height="26" align="left">
                                            <asp:Label ID="CheckTime_2017" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="TableSpecial1" width="15%" colspan="4">
                                            历史记录
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="4" style="height: 31px" class="tablespecial">
                                            <webdiyer:AspNetPager ID="Pager" runat="server" AlwaysShow="True" SubmitButtonClass="backendbtn22"
                                                InputBoxClass="inputtxt" ShowCustomInfoSection="Left" ButtonImageNameExtension="n"
                                                DisabledButtonImageNameExtension="g" CpiButtonImageNameExtension="r" ImagePath="../../../images/page/"
                                                PagingButtonType="Image" NavigationButtonType="Image" PageSize="20" OnPageChanged="Pager_PageChanged">
                                            </webdiyer:AspNetPager>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="4">
                                            <asp:DataGrid ID="Datagrid1" runat="server" CssClass="GridView" PageSize="20" BorderWidth="1px"
                                                AccessKey="1" DataKeyField="RowGuid" AutoGenerateColumns="False" AllowPaging="True"
                                                AllowSorting="True" Width="100%" OnItemCreated="Datagrid1_ItemCreated" OnSortCommand="Datagrid1_SortCommand">
                                                <PagerStyle Visible="False"></PagerStyle>
                                                <AlternatingItemStyle CssClass="RowStyle"></AlternatingItemStyle>
                                                <ItemStyle CssClass="RowStyle"></ItemStyle>
                                                <HeaderStyle HorizontalAlign="Center" Height="30px" CssClass="HeaderStyle"></HeaderStyle>
                                                <Columns>
                                                    <asp:TemplateColumn>
                                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                                        <HeaderTemplate>
                                                            <input id="chkAddAll" onclick="javascript:AllSelect(this)" type="checkbox" name="chkAdd">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <asp:CheckBox ID="chkAdd" runat="server"></asp:CheckBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="序号">
                                                        <HeaderStyle HorizontalAlign="Center" Width="40px"></HeaderStyle>
                                                        <ItemStyle HorizontalAlign="Center" Width="40px"></ItemStyle>
                                                        <ItemTemplate>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="企业中文名称" SortExpression="EnterpriseName">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container, "DataItem.EnterpriseName") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="企业英文名称" SortExpression="EnterpriseEName">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container, "DataItem.EnterpriseEName") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="成立日期" SortExpression="ChengLiDate">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container, "DataItem.ChengLiDate", "{0:yyyy-M-d}") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="高新技术企业" SortExpression="Is_GX">
                                                        <ItemTemplate>
                                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("是否", Convert.ToString(DataBinder.Eval(Container, "DataItem.Is_GX"))) %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="企业类型" SortExpression="QiYeType">
                                                        <ItemTemplate>
                                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("企业_企业类型", Convert.ToString(DataBinder.Eval(Container, "DataItem.QiYeType")))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="税收征管方式" SortExpression="ShuiShouFS">
                                                        <ItemTemplate>
                                                            <%# new Epoint.MisBizLogic2.Code.DB_CodeMain().GetCodeText_FromHash("企业_税收征管方式", Convert.ToString(DataBinder.Eval(Container, "DataItem.ShuiShouFS")))%>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="审核人" SortExpression="CheckUserName">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container, "DataItem.CheckUserName") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="审核日期" SortExpression="CheckTime">
                                                        <ItemTemplate>
                                                            <%# DataBinder.Eval(Container, "DataItem.CheckTime", "{0:yyyy-MM-dd}") %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="状态" SortExpression="Status">
                                                        <ItemTemplate>
                                                            <%#GetStatus( DataBinder.Eval(Container, "DataItem.Status")) %>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                    <asp:TemplateColumn HeaderText="查看">
                                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                                        <ItemTemplate>
                                                            <a href='javascript:OpenWindow("RG_OU_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&DWGuid=<%#DataBinder.Eval(Container.DataItem,"DWGuid")%>",800,700)'>
                                                                <img src='../../../images/bigview.gif' border='0'></a>
                                                        </ItemTemplate>
                                                    </asp:TemplateColumn>
                                                </Columns>
                                                <PagerStyle Visible="False"></PagerStyle>
                                            </asp:DataGrid>
                                        </td>
                                    </tr>
                                    <tr style="display: none">
                                        <td>
                                            
                                            <asp:Label ID="UpdateUserGuid_2017" runat="server" MaxLength="100"></asp:Label>
                                            <asp:Label ID="IsHistory_2017" runat="server" MaxLength="100"></asp:Label>
                                            
                                            <asp:Label ID="CheckUserGuid_2017" runat="server" MaxLength="100"></asp:Label>
                                            <asp:Label ID="Status_2017" runat="server" MaxLength="100"></asp:Label>
                                            <asp:Label ID="DelFlag_2017" runat="server" MaxLength="100"></asp:Label>
                                            <asp:Label ID="DWGuid_2017" runat="server" MaxLength="100"></asp:Label>
                                            
                                            <asp:PlaceHolder ID="controlHolder" runat="server"></asp:PlaceHolder>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </igtab:Tab>
            <igtab:Tab Text="&#160;&#160;动态信息&#160;&#160;">
                <ContentTemplate>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                        <tr>
                            <td id="Td1" align="right" colspan="2" runat="server">
                                <iframe width="100%" height="100%" name="left" runat="server" id="ifDT" scrolling="auto"
                                    frameborder="0"></iframe>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </igtab:Tab>
            <igtab:Tab Text="&#160;&#160;月度财务信息&#160;&#160;">
                <ContentTemplate>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                        <tr>
                            <td id="Td4" align="right" colspan="2" runat="server">
                                <iframe width="100%" height="100%" name="left" runat="server" id="ifCW" scrolling="auto"
                                    frameborder="0"></iframe>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </igtab:Tab>
            <igtab:Tab Text="&#160;&#160;其他重要信息&#160;&#160;">
                <ContentTemplate>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                        <tr>
                            <td id="Td5" align="right" colspan="2" runat="server">
                                <iframe width="100%" height="100%" name="left" runat="server" id="ifOther" scrolling="auto"
                                    frameborder="0"></iframe>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </igtab:Tab>
            <igtab:Tab Text="&#160;&#160;人事信息&#160;&#160;">
                <ContentTemplate>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                        <tr>
                            <td id="Td6" align="right" colspan="2" runat="server">
                                <iframe width="100%" height="100%" name="left" runat="server" id="ifRS" scrolling="auto"
                                    frameborder="0"></iframe>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </igtab:Tab>
            <igtab:Tab Text="&#160;&#160;定期事项&#160;&#160;">
                <ContentTemplate>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                        <tr>
                            <td id="Td2" align="right" colspan="2" runat="server">
                                <iframe width="100%" height="100%" name="left" runat="server" id="ifDQ" scrolling="auto"
                                    frameborder="0"></iframe>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </igtab:Tab>
            <igtab:Tab Text="&#160;&#160;趋势分析&#160;&#160;">
                <ContentTemplate>
                    <table cellspacing="0" cellpadding="0" width="100%" border="0" height="100%">
                        <tr>
                            <td id="Td3" align="right" colspan="2" runat="server">
                                <iframe width="100%" height="100%" name="left" runat="server" id="ifCWFX" scrolling="auto"
                                    frameborder="0"></iframe>
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </igtab:Tab>
        </Tabs>
    </igtab:UltraWebTab>
</asp:Content>
