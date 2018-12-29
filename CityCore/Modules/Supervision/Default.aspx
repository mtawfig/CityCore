<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/CityCore.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CityCore.Modules.Supervision.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            document.getElementById("nav_supervision").classList.add("active");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
