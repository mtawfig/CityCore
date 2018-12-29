<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/CityCore.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="CityCore.Pages.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            document.getElementById("nav_home").classList.add("active");
        });
    </script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
