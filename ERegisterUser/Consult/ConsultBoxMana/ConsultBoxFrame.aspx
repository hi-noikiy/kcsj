<%@ Page Language="C#" MasterPageFile="~/WebMaster/MainpageWithTree.Master" AutoEventWireup="true"
    Codebehind="ConsultBoxFrame.aspx.cs" Inherits="EpointRegisterUser.Consult.ConsultBoxMana.ConsultBoxFrame"
    Title="ÐÅÏä¹ÜÀí" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <iframe height="100%" name="left1" scrolling="auto" src='ConsultBoxTree.aspx' width="100%"
        frameborder="0"></iframe>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <iframe height="100%" name="main1" scrolling="auto" src='ConsultBoxMana.aspx' width="100%"
        frameborder="0"></iframe>
</asp:Content>
