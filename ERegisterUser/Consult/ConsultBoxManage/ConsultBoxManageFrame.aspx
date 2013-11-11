<%@ Page Language="C#" MasterPageFile="~/WebMaster/MainpageWithTree.Master" AutoEventWireup="true"
    CodeBehind="ConsultBoxManageFrame.aspx.cs" Inherits="EpointRegisterUser.Consult.ConsultBoxManage.ConsultBoxManageFrame"
    Title="咨询回复" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <iframe height="100%" name="left1" scrolling="auto" src='ConsultBoxListTree.aspx'
        width="100%" frameborder="0"></iframe>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <iframe height="100%" name="main1" scrolling="auto" src='ConsultBoxListMana.aspx'
        width="100%" frameborder="0"></iframe>
</asp:Content>
