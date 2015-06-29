<%@ Page Language="C#" Theme="OverTheme" MasterPageFile="DefaultPage.Master" AutoEventWireup="true" CodeBehind="GameOverPage.aspx.cs" Inherits="Millionaire.GameOverPage" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <div class="initOver">
        <asp:Label runat="server" ID="lblCaption"></asp:Label>
        <br/>
        <asp:ImageButton runat="server" ID="btnRestart" ImageUrl="~/Resources/restart.png" OnClick="btnRestart_OnClick"></asp:ImageButton>
    </div>
</asp:Content>