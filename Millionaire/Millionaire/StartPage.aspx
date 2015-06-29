<%@ Page Language="C#" MasterPageFile="DefaultPage.Master" AutoEventWireup="true" Theme="StartTheme" CodeBehind="StartPage.aspx.cs" Inherits="Millionaire.StartPage" %>

<asp:Content runat="server" ContentPlaceHolderID="mainContent">
    <br/>
    <asp:Label ID="lblCaprionText" runat="server" Text="Введіть ім'я користувача:"></asp:Label>
    <br/>
    <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvUserName" runat="server"
                                ErrorMessage="Потрібно ввести своє ім'я" ControlToValidate="txtUserName"
                                ForeColor="Red" Display="Dynamic"/>

    <asp:RegularExpressionValidator ID="revUserName" runat="server"
                                    ErrorMessage="Некоректні дані" ControlToValidate="txtUserName"
                                    ValidationExpression="^[а-яА-Яa-zA-Z]{3,12}$"
                                    ForeColor="Red" Display="Dynamic"/>
    <asp:Label ID="lblEnterText" runat="server" Text=""></asp:Label>
    <br/>
    <asp:Button ID="btnAcceptUserName" runat="server" Text="Прийняти" OnClick="btnAcceptUserName_OnClick"/>
</asp:Content>
