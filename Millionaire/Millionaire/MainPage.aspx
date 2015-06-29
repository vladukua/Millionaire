<%@ Page Language="C#" MasterPageFile="~/DefaultPage.Master" AutoEventWireup="true" Theme="MainTheme" CodeBehind="MainPage.aspx.cs" Inherits="Millionaire.MainPage" %>

<%@ Register Src="~/Controlls/ScoreTable.ascx" TagPrefix="uc1" TagName="ScoreTable" %>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="head">
    
</asp:Content>

<asp:Content runat="server" ID="Content2" ContentPlaceHolderID="header">
    <uc1:ScoreTable runat="server" id="ScoreTableControl"/>
</asp:Content>

<asp:Content runat="server" ID="Content3" ContentPlaceHolderID="mainContent">
    <div id ="_questions">     
        <asp:Label runat="server" ID="lblUserName" Font-Size="16"></asp:Label>
        <table id="qtable" class="questtable">
            <tr>              
                <td colspan="2"><asp:Button CssClass ="questpanel" id="lblQuestion" runat="server" BorderStyle="None" /></td>
            </tr>
            <tr>
                <td class="leftblock"><asp:Button CssClass="btnAnwA" ID="btnAAnswer" runat="server" BorderStyle="None"  Text="A" OnClick="btnAAnswer_Click"/></td>
                <td class="rightblock"><asp:Button CssClass="btnAnwB" ID="btnBAnswer" runat="server" BorderStyle="None" Text="B" OnClick="btnBAnswer_Click"/></td>

            </tr>
            <tr>
                <td class="leftblock"><asp:Button CssClass="btnAnwC" ID="btnCAnswer" runat="server" BorderStyle="None"  Text="C" OnClick="btnCAnswer_Click"/></td>
                <td class="rightblock"><asp:Button CssClass="btnAnwD" ID="btnDAnswer" runat="server" BorderStyle="None"  Text="D" OnClick="btnDAnswer_Click"/></td>

            </tr>
        </table>
    </div>
</asp:Content>


