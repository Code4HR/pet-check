<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Disclaimer.aspx.cs" Inherits="APHIS.Disclaimer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
       <div>DISCLAIMER: This web site is not affiliated with or funded by the United States Deparment of Agriculture (USDA) or the Animal Plant Heath Inspection Service (APHIS). The sole purpose of this website is to make inspection histories available to consumers at the Point of Sale.</div> 
        <br />
    <input id="btnBack" onclick="history.go(-1); return false;" type="button" value="back" />
</asp:Content>

