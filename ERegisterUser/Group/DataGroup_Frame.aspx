<%@ Page Language="C#" MasterPageFile="~/WebMaster/MainpageWithTree.Master" AutoEventWireup="true"
    CodeBehind="DataGroup_Frame.aspx.cs" Inherits="EpointRegisterUser.Group.DataGroup_Frame"
    Title="业务数据归档管理" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <iframe frameborder="0" height="100%" name="left1" scrolling="auto" src="DataGroup_LeftTree.aspx"
        width="100%"></iframe>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <table cellpadding="0" cellspacing="0" border="0" height="100%" width="100%">
        <tr>
            <td>
                <iframe frameborder="0" height="100%" name="FrameRight" scrolling="yes" width="100%"
                    src="DataGroup_List.aspx?ParentGuid="></iframe>
            </td>
        </tr>
    </table>
</asp:Content>
