<%@ Page Language="C#" MasterPageFile="~/WebMaster/MainpageWithTree.Master" AutoEventWireup="true"
    CodeBehind="Record_Frame.aspx.cs" Inherits="EpointRegisterUser.Pages.RG_Module.Record_Frame"
    Title="模块管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <iframe frameborder="0" height="100%" name="left1" scrolling="auto" src="Record_LeftTree.aspx"
        width="100%"></iframe>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" height="100%" width="100%">
        <tr>
            <td>
                <iframe frameborder="0" height="100%" name="FrameRight" scrolling="yes" width="100%"
                    src="Record_List.aspx?ParentGuid=&IsBelongtoApp=0"></iframe>
            </td>
        </tr>
    </table>
</asp:Content>
