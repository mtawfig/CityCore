<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/CityCore.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CityCore.Modules.Projects.Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        $(function () {
            document.getElementById("nav_projects").classList.add("active");
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
                        <span class="sidebar-title">Project Information</span>
                        <b class="caret"></b>
                    </a>

                    <ul id="submenu-1" class="panel-collapse collapse panel-switch" role="menu">
                        <li><a href="OwnerInformation.aspx">Owner Information</a></li>
                        <li><a href="#">Project Information</a></li>
                        <li><a href="#">Main Contractor Information</a></li>
                        <li><a href="#">Subcontractor Soiltest</a></li>
                    </ul>
                </li>

                <%--Commented below is a sample of menu item with sub-items (accordion)--%>
                <li>
                    <a class="accordion-toggle collapsed toggle-switch" data-toggle="collapse" href="#submenu-2">
                        <span class="sidebar-title">Projects</span>
                        <b class="caret"></b>
                    </a>

                    <ul id="submenu-2" class="panel-collapse collapse panel-switch" role="menu">
                        <li><a href="#">Active Projects</a></li>
                        <li><a href="#">Full-done Projects</a></li>
                        <li><a href="#">Holding Projects</a></li>
                        <li><a href="#">Vacant Projects</a></li>
                        <li><a href="#">All Projects</a></li>
                    </ul>
                </li>
            </ul>
        </aside>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <div class="row">
        <div class="col-lg-12">
            <asp:Label ID="lblMsg" runat="server" Visible="false" />
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12">

            <asp:ListView ID="lvMain" runat="server">

                <LayoutTemplate>
                    <table class="listview table table-striped table-bordered table-hover">
                        <thead>
                            <tr class="active">
                                <th>ID</th>
                                <th>NAME</th>
                                <th>ADMID</th>
                                <th>LANDLORD</th>
                                <th>TENANT NAME</th>
                                <th>PROPERTY MNGR</th>
                                <th>AREA</th>
                                <th>SECTOR</th>
                                <th>PLOT</th>
                                <th>UNIT NO</th>
                                <th>STATUS</th>
                                <th>Actions</th>
                            </tr>
                        </thead>
                        <tbody>
                            <asp:PlaceHolder runat="server" ID="itemPlaceholder"></asp:PlaceHolder>
                        </tbody>
                    </table>
                </LayoutTemplate>

                <ItemTemplate>
                    <tr>
                        <td><%# Eval("ID") %></td>
                        <td>
                            <%--<asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("ID") %>' />--%>
                            <%# Eval("NAME") %>
                        </td>
                        <td><%# Eval("ADM_ID") %></td>
                        <td><%# Eval("LANDLORD") %></td>
                        <td><%# Eval("TENANT_NAME") %></td>
                        <td><%# Eval("PROPERTY_MNGR") %></td>
                        <td><%# Eval("AREA") %></td>
                        <td><%# Eval("SECTOR") %></td>
                        <td><%# Eval("PLOT") %></td>
                        <td><%# Eval("UNIT_NO") %></td>
                        <td><%# Eval("STATUS") %></td>
                        <td>
                            <asp:LinkButton ID="lbEdit" runat="server" CssClass="btn btn-primary btn-xs" ToolTip="Edit"
                                CommandArgument='<%# Eval("ID") %>'><i class="fa fa-edit"></i></asp:LinkButton>

                            <asp:LinkButton ID="lbDelete" runat="server" CssClass="btn btn-danger btn-xs" ToolTip="Delete"
                                CommandArgument='<%# Eval("ID") %>'><i class="fa fa-trash"></i></asp:LinkButton>
                            <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server"
                                ConfirmText="Do you want to delete?" TargetControlID="lbDelete"></ajaxToolkit:ConfirmButtonExtender>
                        </td>
                    </tr>
                </ItemTemplate>

                <EmptyDataTemplate>
                    <table class="table table-striped table-bordered table-hover">
                        <tr class="active">
                            <th>ID</th>
                            <th>NAME</th>
                            <th>ADM_ID</th>
                            <th>LANDLORD</th>
                            <th>TENANT_NAME</th>
                            <th>PROPERTY_MNGR</th>
                            <th>AREA</th>
                            <th>SECTOR</th>
                            <th>PLOT</th>
                            <th>UNIT_NO</th>
                            <th>STATUS</th>
                            <th>Actions</th>
                        </tr>
                        <tr>
                            <td colspan="11">No Data Found!</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>

            </asp:ListView>

        </div>
    </div>

    <script>
        $(document).ready(function () {
            $('.listview').DataTable();
        });
    </script>
</asp:Content>
