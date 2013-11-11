<%@ Page Language="C#" MasterPageFile="~/WebMaster/ContentPage.master" AutoEventWireup="true"
    CodeBehind="ConsultBoxTongJiTopTen.aspx.cs" Inherits="EpointRegisterUser.Consult.ConsultBoxTongJi.ConsultBoxTongJiTopTen"
    Title="咨询投诉 — 受理统计" %>

<%@ Register TagPrefix="igtab" Namespace="Infragistics.WebUI.UltraWebTab" Assembly="Infragistics2.WebUI.UltraWebTab.v6.3, Version=6.3.20063.53, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb" %>
<%@ Register Assembly="System.Web.Extensions, Version=1.0.61025.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Register Assembly="Epoint.Web.UI.WebControls2X" Namespace="Epoint.Web.UI.WebControls2X"
    TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table width="99%" align="center">
        <tr>
            <td align="center">
                <igtab:UltraWebTab ID="UltraWebTab1" runat="server" BorderWidth="1px" ThreeDEffect="true"
                    Width="100%" BorderStyle="Solid" SelectedTab="0" Height="440px" LoadAllTargetUrls="False">
                    <defaulttabstyle height="22px" font-size="8pt" font-names="Verdana" forecolor="Black"
                        backcolor="GhostWhite" borderwidth="1">
                        <Padding Top="1px"></Padding>
                    </defaulttabstyle>
                    <roundedimage leftsidewidth="7" rightsidewidth="6" shiftofimages="2" selectedimage="../../../Images/ig_tab_winXPs1.gif"
                        normalimage="../../../Images/ig_tab_winXPs3.gif" hoverimage="../../../Images/ig_tab_winXPs2.gif"
                        fillstyle="LeftMergedWithCenter"></roundedimage>
                    <selectedtabstyle>
                        <Padding Bottom="2px"></Padding>
                    </selectedtabstyle>
                    <tabs>
                    </tabs>
                </igtab:UltraWebTab>
            </td>
        </tr>
        <tr>
            <td>
                <span style="font-style: normal; font-size: large">
                    <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">统计明细</asp:LinkButton></span>
            </td>
        </tr>
    </table>
</asp:Content>
