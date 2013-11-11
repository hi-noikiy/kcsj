<%@ Page Language="C#" MasterPageFile="~/WebMaster/Blank.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_DongTai.RG_DongTai_Detail" CodeBehind="RG_DongTai_Detail.aspx.cs"
    Title="查看数据明细" %>

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
    <table cellpadding="0" cellspacing="0" border="0" width="100%">
        <tr style="display: none">
            <td height="36" style="font-weight: bold; font-size: 28px; color: #000000; background-repeat: repeat-x"
                align="center" valign="middle">
                <%=ViewState ["TableName"]%>
            </td>
        </tr>
        <tr>
            <td id="tdContainer" valign="top" align="center" runat="server">
                <table width="100%" cellspacing="1" align="center">
                    <%--<tr>
                        <td class="TableSpecial1" width="15%">
                            公司荣誉
                        </td>
                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                            <asp:Label ID="GongSiRY_2019" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            团队荣誉
                        </td>
                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                            <asp:Label ID="TuanDuiRY_2019" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            各种补贴
                        </td>
                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                            <asp:Label ID="BuTie_2019" runat="server"></asp:Label>
                        </td>
                    </tr>--%>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            公司荣誉
                        </td>
                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                            <%--<epoint:TextBox ID="GongSiRY_2019" runat="server" CssClass="inputtxt" Width="90%"
                                        TextMode="MultiLine" Height="50px" AllowNull="false" RelationName="公司荣誉:"></epoint:TextBox>--%>
                            <asp:DataGrid ID="grdGongSi" runat="server" AutoGenerateColumns="False" Width="100%"
                                DataKeyField="RowGuid" PageSize="100">
                                <Columns>
                                    <asp:TemplateColumn HeaderText="序号">
                                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        <ItemTemplate>
                                            <%#this.grdGongSi.Items.Count + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="名称">
                                        <HeaderStyle HorizontalAlign="center" Width="25%" />
                                        <ItemStyle HorizontalAlign="left" Width="25%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="tbRongYuName" CssClass="inputtxt" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.s_rongYuName") %>'
                                                Width="90%">
                                            </asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="tbRongYuNameNew" CssClass="inputtxt" runat="server" Width="90%">
                                            </asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="内容概要">
                                        <HeaderStyle HorizontalAlign="center" Width="35%" />
                                        <ItemStyle HorizontalAlign="left" Width="35%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="tbNeiRongGY" CssClass="inputtxt" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.s_neiRongGY") %>'
                                                Width="90%">
                                            </asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="tbNeiRongGYNew" CssClass="inputtxt" runat="server" Width="90%">
                                            </asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="取得日期">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" />
                                        <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                        <ItemTemplate>
                                            <epoint:DateTextBox CssClass="inputtxt" ID="tbGetDate" runat="server" InputDateType="Input"
                                                Character="HX" Width="80px" MaxYear="2900" MinYear="1900" Text='<%# DataBinder.Eval(Container, "DataItem.d_getDate","{0:yyyy-M-d}") %>'></epoint:DateTextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <epoint:DateTextBox CssClass="inputtxt" ID="tbGetDateNew" runat="server" InputDateType="Input"
                                                Character="HX" Width="80px" MaxYear="2900" MinYear="1900"></epoint:DateTextBox>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="颁发单位">
                                        <HeaderStyle HorizontalAlign="center" Width="35%" />
                                        <ItemStyle HorizontalAlign="left" Width="35%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="tbBanFaDW" CssClass="inputtxt" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.s_banFaDW") %>'
                                                Width="90%">
                                            </asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="tbBanFaDWNew" CssClass="inputtxt" runat="server" Width="90%">
                                            </asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="操作" Visible="false">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Button ID="btDelete" CssClass="ButtonDelNoBg" MouseOverClass="ButtonDel" runat="server"
                                                CommandName="dele" Text="删除" OnClientClick="return confirm('确定删除？');" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.RowGuid") %>'>
                                            </asp:Button>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="btAdd" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon" runat="server"
                                                CommandName="alert" Text="添加"></asp:Button>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            团队荣誉
                        </td>
                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                            <%--<epoint:TextBox ID="TuanDuiRY_2019" runat="server" CssClass="inputtxt" Width="90%"
                                        TextMode="MultiLine" Height="50px" AllowNull="false" RelationName="团队荣誉:"></epoint:TextBox>--%>
                            <%--<epoint:Button runat="server" ID="btUpdateTuanDui" CssClass="ButtonSaveNoBg" MouseOverClass="ButtonSave"
                                Text="保存修改" CausesValidation="false" OnClick="btTuanDui_Click" /><br />--%>
                            <asp:DataGrid ID="grdTuanDui" runat="server" AutoGenerateColumns="False" Width="100%"
                                DataKeyField="RowGuid" PageSize="100">
                                <Columns>
                                    <asp:TemplateColumn HeaderText="序号">
                                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        <ItemTemplate>
                                            <%#this.grdTuanDui.Items.Count + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="名称">
                                        <HeaderStyle HorizontalAlign="center" Width="25%" />
                                        <ItemStyle HorizontalAlign="left" Width="25%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="tbRongYuName" CssClass="inputtxt" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.s_rongYuName") %>'
                                                Width="90%">
                                            </asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="tbRongYuNameNew" CssClass="inputtxt" runat="server" Width="90%">
                                            </asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="内容概要">
                                        <HeaderStyle HorizontalAlign="center" Width="35%" />
                                        <ItemStyle HorizontalAlign="left" Width="35%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="tbNeiRongGY" CssClass="inputtxt" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.s_neiRongGY") %>'
                                                Width="90%">
                                            </asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="tbNeiRongGYNew" CssClass="inputtxt" runat="server" Width="90%">
                                            </asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="取得日期">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" />
                                        <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                        <ItemTemplate>
                                            <epoint:DateTextBox CssClass="inputtxt" ID="tbGetDate" runat="server" InputDateType="Input"
                                                Character="HX" Width="80px" MaxYear="2900" MinYear="1900" Text='<%# DataBinder.Eval(Container, "DataItem.d_getDate","{0:yyyy-M-d}") %>'></epoint:DateTextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <epoint:DateTextBox CssClass="inputtxt" ID="tbGetDateNew" runat="server" InputDateType="Input"
                                                Character="HX" Width="80px" MaxYear="2900" MinYear="1900"></epoint:DateTextBox>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="颁发单位">
                                        <HeaderStyle HorizontalAlign="center" Width="35%" />
                                        <ItemStyle HorizontalAlign="left" Width="35%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="tbBanFaDW" CssClass="inputtxt" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.s_banFaDW") %>'
                                                Width="90%">
                                            </asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="tbBanFaDWNew" CssClass="inputtxt" runat="server" Width="90%">
                                            </asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="操作" Visible="false">
                                        <HeaderStyle HorizontalAlign="center" />
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                        <FooterStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Button ID="btDelete" CssClass="ButtonDelNoBg" MouseOverClass="ButtonDel" runat="server"
                                                CommandName="dele" Text="删除" OnClientClick="return confirm('确定删除？');" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.RowGuid") %>'>
                                            </asp:Button>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="btAdd" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon" runat="server"
                                                CommandName="alert" Text="添加"></asp:Button>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            各种补贴
                        </td>
                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                            <%--<epoint:TextBox ID="BuTie_2019" runat="server" CssClass="inputtxt" Width="90%" TextMode="MultiLine"
                                        Height="50px" AllowNull="false" RelationName="各种补贴:"></epoint:TextBox>--%>
                            <%--<epoint:Button runat="server" ID="btUpdateBuTie" CssClass="ButtonSaveNoBg" MouseOverClass="ButtonSave"
                                Text="保存修改" CausesValidation="false" OnClick="btBuTie_Click" /><br />--%>
                            <asp:DataGrid ID="grdBuTie" runat="server" AutoGenerateColumns="False" Width="100%"
                                DataKeyField="RowGuid" PageSize="100">
                                <Columns>
                                    <asp:TemplateColumn HeaderText="序号">
                                        <HeaderStyle HorizontalAlign="Center" Width="5%"></HeaderStyle>
                                        <ItemStyle HorizontalAlign="Center" Width="5%"></ItemStyle>
                                        <ItemTemplate>
                                            <%#this.grdBuTie.Items.Count + 1%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="名称">
                                        <HeaderStyle HorizontalAlign="center" Width="25%" />
                                        <ItemStyle HorizontalAlign="left" Width="25%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="tbMingChen" CssClass="inputtxt" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.s_mingChen") %>'
                                                Width="90%">
                                            </asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="tbMingChenNew" CssClass="inputtxt" runat="server" Width="90%">
                                            </asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="金额">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" />
                                        <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="tbJinE" CssClass="inputtxt" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.f_jinE") %>'
                                                Width="80%">
                                            </asp:TextBox>元
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck"
                                                Type="Double" ErrorMessage="无效数字" ControlToValidate="tbJinE" Display="Dynamic"></asp:CompareValidator>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="tbJinENew" CssClass="inputtxt" runat="server" Width="80%">
                                            </asp:TextBox>元
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck"
                                                Type="Double" ErrorMessage="无效数字" ControlToValidate="tbJinENew" Display="Dynamic"></asp:CompareValidator>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="取得日期">
                                        <HeaderStyle HorizontalAlign="center" Width="15%" />
                                        <ItemStyle HorizontalAlign="left" Width="15%"></ItemStyle>
                                        <ItemTemplate>
                                            <epoint:DateTextBox CssClass="inputtxt" ID="tbGetDate" runat="server" InputDateType="Input"
                                                Character="HX" Width="80px" MaxYear="2900" MinYear="1900" Text='<%# DataBinder.Eval(Container, "DataItem.d_getDate","{0:yyyy-M-d}") %>'></epoint:DateTextBox>
                                        </ItemTemplate>
                                        <FooterStyle HorizontalAlign="Right" />
                                        <FooterTemplate>
                                            <epoint:DateTextBox CssClass="inputtxt" ID="tbGetDateNew" runat="server" InputDateType="Input"
                                                Character="HX" Width="80px" MaxYear="2900" MinYear="1900"></epoint:DateTextBox>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="实施期限">
                                        <HeaderStyle HorizontalAlign="center" Width="40%" />
                                        <ItemStyle HorizontalAlign="left" Width="40%"></ItemStyle>
                                        <ItemTemplate>
                                            <asp:TextBox ID="tbQiXian" CssClass="inputtxt" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.s_qiXian") %>'
                                                Width="90%">
                                            </asp:TextBox>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:TextBox ID="tbQiXianNew" CssClass="inputtxt" runat="server" Width="90%" MaxLength="100">
                                            </asp:TextBox>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="操作" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                        <ItemTemplate>
                                            <asp:Button ID="btDelete" CssClass="ButtonDelNoBg" MouseOverClass="ButtonDel" runat="server"
                                                CommandName="dele" Text="删除" OnClientClick="return confirm('确定删除？');" CommandArgument='<%# DataBinder.Eval(Container, "DataItem.RowGuid") %>'>
                                            </asp:Button>
                                        </ItemTemplate>
                                        <FooterTemplate>
                                            <asp:Button ID="btAdd" CssClass="ButtonConNoBg" MouseOverClass="ButtonCon" runat="server"
                                                CommandName="alert" Text="添加"></asp:Button>
                                        </FooterTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            其他附件
                        </td>
                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                            <uc1:CaiLiao ID="CL_QTFJ" runat="server" YeWuMC="企业-动态附件" ReadOnly="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            公司专利及专有技术
                        </td>
                        <td class="TableSpecial" width="85%" colspan="3" height="26" align="left">
                            <%--<epoint:TextBox ID="ZhuanLiJiShu_2019" runat="server" CssClass="inputtxt" Width="90%"
                                        TextMode="MultiLine" Height="50px"></epoint:TextBox>--%>
                            <%--<epoint:Button ForeColor="black" MouseOverClass="ButtonAdd" CssClass="ButtonAddNoBg"
                                ID="btnAddZL" OnClientClick="OpenUrl();return false;" runat="server" Text="新增记录" />&nbsp;<epoint:DeleteButton
                                    Text="删除选定" ID="btnDelZL" MouseOverClass="ButtonDel" runat="server" CssClass="ButtonDelNoBg"
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
                                    <asp:TemplateColumn HeaderText="专利号" SortExpression="ZhuanLiNo">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZhuanLiNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="专利名称" SortExpression="ZhuanLiName">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZhuanLiName")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="专利类型" SortExpression="ZhuanLiType">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZhuanLiType")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="专利状态" SortExpression="ZhuanLiStatus">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZhuanLiStatus")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="持有人" SortExpression="ChiYouRen">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ChiYouRen")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="查看">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='javascript:OpenWindow("../RG_ZhuanLi/RG_ZhuanLi_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&DWGuid=<%#DataBinder.Eval(Container.DataItem,"DWGuid")%>",500,400)'>
                                                <img src='../../../images/bigview.gif' border='0'></a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="修改" Visible="false">
                                        <ItemStyle HorizontalAlign="Center" Width="40"></ItemStyle>
                                        <ItemTemplate>
                                            <a href='javascript:OpenWindow("../RG_ZhuanLi/RG_ZhuanLi_Edit.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&DWGuid=<%#DataBinder.Eval(Container.DataItem,"DWGuid")%>",500,400)'>
                                                <img src='../../../images/add1.gif' border='0'></a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Visible="False"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%" rowspan="2">
                            营业执照
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="YingYeZZNo_2019" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <uc1:CaiLiao ID="CL_YYZZ" runat="server" YeWuMC="企业-营业执照" ReadOnly="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%" rowspan="2">
                            税务登记证书
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="ShuiWuDJBo_2019" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <uc1:CaiLiao ID="CL_SWDJZ" runat="server" YeWuMC="企业-税务登记证书" ReadOnly="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%" rowspan="2">
                            组织机构代码证
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="ZuZhiJGDMNo_2019" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <uc1:CaiLiao ID="CL_ZZJGDM" runat="server" YeWuMC="企业-组织机构代码证" ReadOnly="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%" rowspan="2">
                            商务部批准证书
                        </td>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <asp:Label ID="ShangWuBPZNo_2019" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial" width="85%" height="26" align="left" colspan="3">
                            <uc1:CaiLiao ID="CL_SWPZZ" runat="server" YeWuMC="企业-商务部批准证书" ReadOnly="true" />
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            更新人
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="UpdateUserName_2019" runat="server" MaxLength="50"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            更新时间
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="UpdateTime_2019" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" width="15%">
                            审核人
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="CheckUserName_2019" runat="server"></asp:Label>
                        </td>
                        <td class="TableSpecial1" width="15%">
                            审核时间
                        </td>
                        <td class="TableSpecial" width="35%" height="26" align="left">
                            <asp:Label ID="CheckTime_2019" runat="server"></asp:Label>
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
                                    <asp:TemplateColumn HeaderText="营业执照">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.YingYeZZNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="税务登记证书">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ShuiWuDJBo")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="组织机构代码证">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ZuZhiJGDMNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="商务部批准证书">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.ShangWuBPZNo")%>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="更新人" SortExpression="UpdateUserName">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.UpdateUserName") %>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                    <asp:TemplateColumn HeaderText="更新日期" SortExpression="UpdateTime">
                                        <ItemTemplate>
                                            <%# DataBinder.Eval(Container, "DataItem.UpdateTime", "{0:yyyy-MM-dd}") %>
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
                                            <a href='javascript:OpenWindow("RG_DongTai_Detail.aspx?RowGuid=<%#DataBinder.Eval(Container.DataItem,"RowGuid")%>&DWGuid=<%#DataBinder.Eval(Container.DataItem,"DWGuid")%>",800,700)'>
                                                <img src='../../../images/bigview.gif' border='0'></a>
                                        </ItemTemplate>
                                    </asp:TemplateColumn>
                                </Columns>
                                <PagerStyle Visible="False"></PagerStyle>
                            </asp:DataGrid>
                        </td>
                    </tr>
                    <tr style="display: none">
                        <td class="TableSpecial1" width="15%" colspan="4">
                            <asp:Label ID="UpdateUserGuid_2019" runat="server" MaxLength="50"></asp:Label>
                            <%--<asp:Label ID="UpdateUserName_2019" runat="server" MaxLength="50"></asp:Label>--%>
                            <%--<asp:Label ID="UpdateTime_2019" runat="server"></asp:Label>
                            <asp:Label ID="CheckUserName_2019" runat="server" MaxLength="50"></asp:Label>--%>
                            <asp:Label ID="CheckUserGuid_2019" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="IsHistory_2019" runat="server" MaxLength="50"></asp:Label>
                            <asp:Label ID="DWGuid_2019" runat="server" MaxLength="50"></asp:Label>
                            <%--<asp:Label ID="CheckTime_2019" runat="server"></asp:Label>--%>
                            <asp:Label ID="Status_2019" runat="server" MaxLength="50"></asp:Label>
                            <asp:PlaceHolder ID="controlHolder" runat="server"></asp:PlaceHolder>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
