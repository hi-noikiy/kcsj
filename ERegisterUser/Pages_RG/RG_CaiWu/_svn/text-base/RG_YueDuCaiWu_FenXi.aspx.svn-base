<%@ Page Language="C#" MasterPageFile="~/WebMaster/Blank.master" AutoEventWireup="True"
    Inherits="EpointRegisterUser.Pages_RG.RG_CaiWu.RG_YueDuCaiWu_FenXi" CodeBehind="RG_YueDuCaiWu_FenXi.aspx.cs"
    Title="财务数据趋势分析" %>

<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X.TextBoxControls"
    TagPrefix="epoint" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="epoint" %>
<%@ Register TagPrefix="webdiyer" Namespace="Wuqi.Webdiyer" Assembly="AspNetPager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr class="tablespecial" style="display:none">
            <td id="tdCl" valign="middle" align="center" colspan="2" style="width: 100%">
                <table width="100%">
                    <tr>
                        <td class="tablespecial" align="right">
                            年度
                        </td>
                        <td class="tablespecial">
                            <table>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="DDLYear" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        &nbsp;
                                        <epoint:Button ID="btnOK" MouseOverClass="ButtonSearch" ForeColor="black" runat="server"
                                            Text="查找" CssClass="ButtonSearchNoBg" OnClick="btnAdd_Click"></epoint:Button>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellspacing="1" align="center">
                    <tr>
                        <td class="TableSpecial1" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_HuoBiZiJin" runat="server"
                                Enable3D="true">
                                <Title Text="货币资金" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                        <td class="TableSpecial1" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_QiTaYingShou" runat="server"
                                Enable3D="true">
                                <Title Text="其他应收款" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_CunHuo" runat="server" Enable3D="true">
                                <Title Text="存货" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                        <td class="TableSpecial" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_YingShouZhangKuan" runat="server"
                                Enable3D="true">
                                <Title Text="应收账款" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_LiuDongZiChan" runat="server"
                                Enable3D="true">
                                <Title Text="流动资产" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                        <td class="TableSpecial1" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_ZongZiChan" runat="server"
                                Enable3D="true">
                                <Title Text="总资产" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_LiuDongFuZhai" runat="server"
                                Enable3D="true">
                                <Title Text="流动负债" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                        <td class="TableSpecial" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_ZongFuZhai" runat="server"
                                Enable3D="true">
                                <Title Text="总负债" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_SuoYouQuanYi" runat="server"
                                Enable3D="true">
                                <Title Text="所有者权益" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                        <td class="TableSpecial1" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_ZongShouRu" runat="server"
                                Enable3D="true">
                                <Title Text="当期总收入" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_ZhuYingShouRu" runat="server"
                                Enable3D="true">
                                <Title Text="主营业务收入" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                        <td class="TableSpecial" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_MaoLiLv" runat="server" Enable3D="true">
                                <Title Text="毛利率" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_GuanLiFei" runat="server"
                                Enable3D="true">
                                <Title Text="管理费用" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                        <td class="TableSpecial1" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_YanFaFei" runat="server" Enable3D="true">
                                <Title Text="研发费用" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_DangQiLiRun" runat="server"
                                Enable3D="true">
                                <Title Text="当期利润" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                        <td class="TableSpecial" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_DangQiJingLi" runat="server"
                                Enable3D="true">
                                <Title Text="当期净利润" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_YingYun" runat="server"
                                Enable3D="true">
                                <Title Text="营运资本" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="金额" />
                            </epoint:Chart>
                        </td>
                        <td class="TableSpecial1" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_LiuDongBiLv" runat="server" Enable3D="true">
                                <Title Text="流动比率" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="比率" />
                            </epoint:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_ZiChanFuZhaiLv" runat="server"
                                Enable3D="true">
                                <Title Text="资产负债率" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="百分比" />
                            </epoint:Chart>
                        </td>
                        <td class="TableSpecial" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_XiaoShouJingLiLv" runat="server"
                                Enable3D="true">
                                <Title Text="销售净利率" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="百分比" />
                            </epoint:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_ZongZiChanJingLiLv" runat="server"
                                Enable3D="true">
                                <Title Text="总资产净利率" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="百分比" />
                            </epoint:Chart>
                        </td>
                        <td class="TableSpecial1" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_QuanYiJingLiLv" runat="server" Enable3D="true">
                                <Title Text="权益净利率" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="百分比" />
                            </epoint:Chart>
                        </td>
                    </tr>
                    <tr>
                        <td class="TableSpecial1" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart_XinChou" runat="server"
                                Enable3D="true">
                                <Title Text="薪酬总额" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="百分比" />
                            </epoint:Chart>
                        </td>
                        <td class="TableSpecial1" align="center">
                            <epoint:Chart Width="420" Height="250" Theme="Theme1" ShadowEnabled="true" CornerRadius="7"
                                BorderThickness="0.5" BorderColor="Gray" ID="chart2" runat="server" Enable3D="true">
                                <Title Text="备用" FontFamily="Arial" FontSize="14"></Title>
                                <PlotArea CornerRadius="0" BorderThickness="0" BorderColor="LightGray" />
                                <AxesX Title="月份" />
                                <AxesY Title="百分比" />
                            </epoint:Chart>
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
