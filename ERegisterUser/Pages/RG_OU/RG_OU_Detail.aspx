<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPageNoTop.master" AutoEventWireup="true"
    Inherits="EpointRegisterUser.Pages.RG_OU.RG_OU_Detail" Title="查看数据明细" CodeBehind="RG_OU_Detail.aspx.cs" %>

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
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                valign="middle" align="center" height="36">
                <font face="宋体"></font>
                <%=ViewState ["TableName"]%>
            </td>
        </tr>
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
                            <asp:Label ID="ZhuCeDi_XX_2017" runat="server" ></asp:Label>
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
                            
                            <asp:Label ID="YunYingDi2_2017" runat="server" ></asp:Label>
                            <asp:Label ID="YunYingDi2Code_2017" runat="server" MaxLength="50" Style="display: none"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            运营详细地址2
                        </td>
                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                            <asp:Label ID="YunYingDi2_XX_2017" runat="server" ></asp:Label>
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
                            <asp:Label ID="LianXiRenZW_2017" runat="server" ></asp:Label>
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
                            <asp:Label ID="Is_GX_2017" runat="server" >
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
                    <tr style="display: none">
                        <td>
                            <asp:Label ID="UpdateUserName_2017" runat="server" MaxLength="100"></asp:Label>
                            <asp:Label ID="UpdateUserGuid_2017" runat="server" MaxLength="100"></asp:Label>
                            <asp:Label ID="IsHistory_2017" runat="server" MaxLength="100"></asp:Label>
                            <asp:Label ID="UpdateTime_2017" runat="server" InputDateType="Input" Character="HX"></asp:Label>
                            <asp:Label ID="CheckUserName_2017" runat="server" MaxLength="100"></asp:Label>
                            <asp:Label ID="CheckUserGuid_2017" runat="server" MaxLength="100"></asp:Label>
                            <asp:Label ID="Status_2017" runat="server" MaxLength="100"></asp:Label>
                            <asp:Label ID="DelFlag_2017" runat="server" MaxLength="100"></asp:Label>
                            <asp:Label ID="DWGuid_2017" runat="server" MaxLength="100"></asp:Label>
                            <asp:Label ID="CheckTime_2017" runat="server" InputDateType="Input" Character="HX"></asp:Label>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center" colspan="4" height="40">
                <asp:Label ID="lblMessage" runat="server" ForeColor="Red" Visible="False">没有数据！</asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
