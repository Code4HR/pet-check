<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="status.aspx.cs" Inherits="APHIS.status" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblOutput" runat="server"></asp:Label>
    <br />
    <input id="btnBack" onclick="history.go(-1); return false;" type="button" value="back" />
</asp:Content>
