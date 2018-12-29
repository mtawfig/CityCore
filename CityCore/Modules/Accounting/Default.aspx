<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/CityCore.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CityCore.Modules.Accounting.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            document.getElementById("nav_accounting").classList.add("active");
        });
    </script>
</asp:Content>

<asp:Content ContentPlaceHolderID="SidebarPlaceholder" runat="server">
    <div id="sidebar-wrapper">
        <aside id="sidebar">
            <ul id="sidemenu" class="sidebar-nav">

                <li>
                    <a class="accordion-toggle collapsed toggle-switch" data-toggle="collapse" href="#submenu-1">
                        <%--<span class="sidebar-icon"><i class="fa fa-dashboard"></i></span>--%>
                        <span class="sidebar-title">Quotation</span>
                        <b class="caret"></b>
                    </a>

                    <ul id="submenu-1" class="panel-collapse collapse panel-switch" role="menu">
                        <li><a href="OwnerInformation.aspx">Owner Information</a></li>
                        <li><a href="#">Fitout Project</a></li>
                        <li><a href="#">Direct Fincance Project</a></li>
                        <li><a href="#">FAB Project</a></li>
                        <li><a href="#">ADCE Project</a></li>
                    </ul>
                </li>
                
                <li>
                    <a class="accordion-toggle collapsed toggle-switch" data-toggle="collapse" href="#submenu-2">
                        <%--<span class="sidebar-icon"><i class="fa fa-dashboard"></i></span>--%>
                        <span class="sidebar-title">Agreement</span>
                        <b class="caret"></b>
                    </a>

                    <ul id="submenu-2" class="panel-collapse collapse panel-switch" role="menu">
                        <li><a href="#">Owner Information</a></li>
                        <li><a href="#">Fitout Project</a></li>
                        <li><a href="#">Direct Fincance Project</a></li>
                        <li><a href="#">FAB Project</a></li>
                        <li><a href="#">ADCE Project</a></li>
                    </ul>
                </li>
                
                <li>
                    <a href="#">
                        <span class="sidebar-title">Invoice</span>
                    </a>
                </li>
                
                <li>
                    <a class="accordion-toggle collapsed toggle-switch" data-toggle="collapse" href="#submenu-3">
                        <%--<span class="sidebar-icon"><i class="fa fa-dashboard"></i></span>--%>
                        <span class="sidebar-title">Received Payment</span>
                        <b class="caret"></b>
                    </a>

                    <ul id="submenu-3" class="panel-collapse collapse panel-switch" role="menu">
                        <li><a href="#">Cash</a></li>
                        <li><a href="#">Cheque</a></li>
                        <li><a href="#">LPO</a></li>
                    </ul>
                </li>

            </ul>
        </aside>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
