<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/CityCore.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CityCore.Modules.Permitting.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            document.getElementById("nav_permitting").classList.add("active");
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
                        <span class="sidebar-title">Documents follow up</span>
                        <b class="caret"></b>
                    </a>

                    <ul id="submenu-1" class="panel-collapse collapse panel-switch" role="menu">
                        <li><a href="OwnerInformation.aspx">Received Documents</a></li>
                        <li><a href="#">Requested Documents</a></li>
                    </ul>
                </li>

                 <li>
                   <a class="accordion-toggle collapsed toggle-switch" data-toggle="collapse" href="#submenu-3">
                        <%--<span class="sidebar-icon"><i class="fa fa-dashboard"></i></span>--%>
                        <span class="sidebar-title">Site Approval</span>
                        <b class="caret"></b>
                    </a>

                    <ul id="submenu-3" class="panel-collapse collapse panel-switch" role="menu">
                        <li><a href="#">Resedential/New,Add,Mod</a></li>
                        <li><a href="#">Industrial/Mod</a></li>
                        <li><a href="#">Industrial/New,Add</a></li>
                        <li><a href="#">Commercial/Mod</a></li>
                        <li><a href="#">Commercial/New,Add</a></li>
                        <li><a href="#">Development/Mod</a></li>
                        <li><a href="#">Development/New,Add</a></li>
                    </ul>
                </li>
                
                <li>
                   <a class="accordion-toggle collapsed toggle-switch" data-toggle="collapse" href="#submenu-4">
                        <%--<span class="sidebar-icon"><i class="fa fa-dashboard"></i></span>--%>
                        <span class="sidebar-title">Pre-approval</span>
                        <b class="caret"></b>
                    </a>

                    <ul id="submenu-4" class="panel-collapse collapse panel-switch" role="menu">
                        <li><a href="#">Soil test</a></li>
                        <li><a href="#">Core test</a></li>
                        <li><a href="#">ADCD Maint. agreement</a></li>
                        <li><a href="#">Temp. fence approval</a></li>
                        <li><a href="#">DOT approval</a></li>
                        <li><a href="#">ADCD Approval</a></li>
                        <li><a href="#">ICAD Approval</a></li>
                        <li><a href="#">HAAD Approval</a></li>
                        <li><a href="#">AWQAF Approval</a></li>
                        <li><a href="#">Landlord Approval</a></li>
                    </ul>
                </li>
                
                <li>
                   <a class="accordion-toggle collapsed toggle-switch" data-toggle="collapse" href="#submenu-5">
                        <%--<span class="sidebar-icon"><i class="fa fa-dashboard"></i></span>--%>
                        <span class="sidebar-title">Project approval</span>
                        <b class="caret"></b>
                    </a>

                    <ul id="submenu-5" class="panel-collapse collapse panel-switch" role="menu">
                        <li><a href="#">A_Architectural</a></li>
                        <li><a href="#">B_Structural</a></li>
                        <li><a href="#">C_Civil defense</a></li>
                        <li><a href="#">D_ADDC Elec. LDN</a></li>
                        <li><a href="#">E_ADDC Water WDN</a></li>
                        <li><a href="#">F_Traffic study</a></li>
                        <li><a href="#">G_ESTIDAMA</a></li>
                        <li><a href="#">H_Telephone</a></li>
                        <li><a href="#">I_Drainage</a></li>
                        <li><a href="#">J_Storm Water</a></li>
                        <li><a href="#">K_Heat Load Calc.</a></li>
                    </ul>
                </li>
                
                <li>
                   <a class="accordion-toggle collapsed toggle-switch" data-toggle="collapse" href="#submenu-6">
                        <%--<span class="sidebar-icon"><i class="fa fa-dashboard"></i></span>--%>
                        <span class="sidebar-title">Building permit</span>
                        <b class="caret"></b>
                    </a>

                    <ul id="submenu-6" class="panel-collapse collapse panel-switch" role="menu">
                        <li><a href="#">B.Permit Document</a></li>
                        <li><a href="#">HSE Plan</a></li>
                        <li><a href="#">Land Markation</a></li>
                    </ul>
                </li>

                <li>
                    <a href="#">
                        <span class="sidebar-title">Archived Requests</span>
                    </a>
                </li>
            </ul>
        </aside>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
