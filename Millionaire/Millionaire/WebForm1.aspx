<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Millionaire.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="css/styles.css" />
</head>
<body>
    <form id="form1" runat="server">
        <header class="init">
            <table id="scoretable" class="scoretable" runat="server">
                <tr>
                    <td>
                        <asp:ImageButton ID="btnHint1" runat="server" CssClass="hint" runat="server" BorderStyle="None" ImageUrl="~/Resources/50_50_hint.png" OnClick="btnHint1_Click" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnHint2" runat="server" CssClass="help" runat="server" BorderStyle="None" ImageUrl="~/Resources/hall_hint.png" OnClick="btnHint2_Click" />
                    </td>
                    <td>
                        <asp:ImageButton ID="btnHint3" runat="server" CssClass="help" runat="server" BorderStyle="None" ImageUrl="~/Resources/phone_hint.png" OnClick="btnHint3_Click" />
                    </td>
                </tr>
                <tr id="row15" class="orangetext">
                    <td>15</td>
                    <td colspan="2">1 000 000</td>
                </tr>
                 <tr id="row14">
                    <td>14</td>
                    <td colspan="2">500 000</td>
                </tr>
                 <tr id="row13">
                    <td>13</td>
                    <td colspan="2">250 000</td>
                </tr>
                 <tr id="row12">
                    <td>12</td>
                    <td colspan="2">125 000</td>
                </tr>
                 <tr id="row11">
                    <td>11</td>
                    <td colspan="2">64 000</td>
                </tr>
                 <tr id="row10" class="ld">
                    <td>10</td>
                    <td colspan="2">32 000</td>
                </tr>
                 <tr id="row9">
                    <td>9</td>
                    <td colspan="2">16 000</td>
                </tr>
                 <tr id="row8">
                    <td>8</td>
                    <td colspan="2">8 000</td>
                </tr>
                 <tr id="row7">
                    <td>7</td>
                    <td colspan="2">4 000</td>
                </tr>
                 <tr id="row6">
                    <td>6</td>
                    <td colspan="2">2 000</td>
                </tr>
                 <tr id="row5" class="ld">
                    <td>5</td>
                    <td colspan="2">1 000</td>
                </tr>
                 <tr id="row4">
                    <td>4</td>
                    <td colspan="2">500</td>
                </tr>
                 <tr id="row3">
                    <td>3</td>
                    <td colspan="2">300</td>
                </tr>
                 <tr id="row2">
                    <td>2</td>
                    <td colspan="2">200</td>
                </tr>
                 <tr id="row1">
                    <td>1</td>
                    <td colspan="2">100</td>
                </tr>

            </table>
        </header>
        <div id ="_questions">     
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
    
    </form>
</body>
</html>
