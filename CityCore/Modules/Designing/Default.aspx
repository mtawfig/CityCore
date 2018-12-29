<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/CityCore.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CityCore.Modules.Designing.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            document.getElementById("nav_designing").classList.add("active");
        });
    </script>
</asp:Content>

<asp:Content ContentPlaceHolderID="SidebarPlaceholder" runat="server">
    <div id="sidebar-wrapper">
        <aside id="sidebar">
            <ul id="sidemenu" class="sidebar-nav">
                <li>
                    <a href="#">
                        <span class="sidebar-title">Conceptual Design</span>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <span class="sidebar-title">Site Owner Meeting</span>
                    </a>
                </li>
                <li>
                    <a href="#">
                        <span class="sidebar-title">Site Measurement</span>
                    </a>
                </li>

            </ul>
        </aside>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
