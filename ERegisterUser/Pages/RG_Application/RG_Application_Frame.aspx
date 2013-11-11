<%@ Page Language="C#" MasterPageFile="~/WebMaster/MainpageWithTree_NoAJax.Master"
    AutoEventWireup="true" CodeBehind="RG_Application_Frame.aspx.cs" Inherits="EpointRegisterUser.Pages.RG_Application.RG_Application_Frame"
    Title="应用子系统维护" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <iframe frameborder="0" height="100%" name="left1" scrolling="auto" src="RG_Application_LeftTree.aspx"
        width="100%"></iframe>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" height="100%" width="100%">
        <tr>
            <td>
                <iframe frameborder="0" height="100%" name="FrameRight" scrolling="yes" width="100%" src="../RG_Module/Record_List.aspx?IsBelongtoApp=1&ParentGuid=&AppGuid=all">
                </iframe>
            </td>
        </tr>
    </table>
</asp:Content>
