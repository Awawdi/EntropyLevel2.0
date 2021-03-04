<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EntropyLevel2._0._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <table>
            <tr>
                <td>Please enter a password to check: &nbsp;</td>
                <td><asp:TextBox ID="txtInput" runat="server"></asp:TextBox></td>
                <td><asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" Width="100px"/></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="lblOutput" runat="server" Font-Bold="True"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
