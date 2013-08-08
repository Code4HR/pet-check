<%@ Page Title="License Check" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="APHIS._Default" %>
<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
        <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>                
            </hgroup>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <p id="IntroBlurb" style="display:block" runat="server">
        Check on your pets history BEFORE you purchase!<br /><br />
        We provide you, the consumer, with the latest APHIS reports on licensees, updated daily.<br /><br />
        Ask the pet store staff, breeder or supplier for the USDA Certificate number of the breeder they purchased this animal from OR, if you are visiting a breeder ask them for their certificate number.<br /><br />
        The certificate id should follow this format" ##-A-####<br /><br />
<br /><br />    </p>
    <h3 id="Instructions" runat="server">Enter the USDA License below:</h3>    
    <asp:Label ID="lblInspection" runat="server"></asp:Label>
     <p style="display:block" runat="server">
        <asp:TextBox Width="46px" ID="txtPre" MaxLength="2" runat="server"></asp:TextBox>-
        <asp:DropDownList ID="ddlType" runat="server">
            <asp:ListItem Text="A" Value="A"></asp:ListItem>
            <asp:ListItem Text="B" Value="B"></asp:ListItem>
        </asp:DropDownList>
             -
        <asp:TextBox Width="63px" ID="txtSuffix" MaxLength="4" runat="server"></asp:TextBox>
    <br /><br />
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    </p>		
    </asp:Content>
