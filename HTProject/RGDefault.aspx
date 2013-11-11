<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RGDefault.aspx.cs" Inherits="HTProject.RGDefault"
    MasterPageFile="~/WebMaster/Blank.master" %>

<%@ Register TagPrefix="uc1" TagName="OUEdit" Src="Ascx/OUEdit.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%" cellpadding="0" cellspacing="0">
        <tr>
            <td width="25">
            </td>
            <td>
                <table border="0" width="100%" cellpadding="0" cellspacing="0" height="100%">
                    <tr>
                        <td align="center">
                            <uc1:OUEdit ID="OUEdit" runat="server"></uc1:OUEdit>
                        </td>
                    </tr>
                </table>
            </td>
            <td width="25">
            </td>
        </tr>
    </table>
</asp:Content>
