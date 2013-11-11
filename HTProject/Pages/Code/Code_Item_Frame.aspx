<%@ Page Language="C#" MasterPageFile="~/WebMaster/MainpageWithTree.Master" AutoEventWireup="True" CodeBehind="Code_Item_Frame.aspx.cs" Inherits="HTProject.Pages.Code.Code_Item_Frame"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <iframe width="100%" height="100%" name="left" scrolling="auto" frameborder="0" src='Code_Item_LeftTree.aspx?MainGuid=<%=Request.Params["MainGuid"]%>&ItemCode=<%=Request.Params["ItemCode"]%>&LEN=<%=Request.Params["LEN"]%>'>
    </iframe>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <iframe height="100%" name="main1" scrolling="auto" src='Code_Item_List.aspx?MainGuid=<%=Request.Params["MainGuid"]%>&ItemCode=' frameborder="0"  width="100%">
    </iframe>
</asp:Content>
