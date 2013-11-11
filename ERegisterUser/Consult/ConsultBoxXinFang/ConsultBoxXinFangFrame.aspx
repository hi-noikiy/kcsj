<%@ Page Language="C#" MasterPageFile="~/WebMaster/MainpageWithTree.Master" AutoEventWireup="true" CodeBehind="ConsultBoxXinFangFrame.aspx.cs" Inherits="EpointRegisterUser.Consult.ConsultBoxXinFang.ConsultBoxXinFangFrame" Title="ÐÅ·Ã¾Ö¹ýÂË" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<iframe  height="100%" name="left1" scrolling="auto" src='ConsultBoxXinFangListTree.aspx'
        width="100%" frameborder=0></iframe></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
<iframe  height="100%" name="main1" scrolling="auto" src='ConsultBoxXinFangListMana.aspx'
        width="100%" frameborder=0></iframe></asp:Content>
