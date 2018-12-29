<%@ Page Title="" Language="C#" MasterPageFile="~/Modules/CityCore.Master" AutoEventWireup="true" CodeBehind="AddEdit.aspx.cs" Inherits="CityCore.Modules.Projects.AddEdit" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SidebarPlaceholder" runat="server">
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
                        <li class="active"><a href="#">Project Information</a></li>
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>

    <asp:UpdatePanel ID="UP" runat="server">
        <ContentTemplate>
            <asp:Panel ID="pnlForm" runat="server">
                <div class="table" style="padding: 20px;">

                    <div class="row">
                        <div class="col-lg-12 panel-footer text-right">
                            <asp:LinkButton ID="lbSaveTop" runat="server" CssClass="btn btn-primary"
                                ValidationGroup="vgMain" OnClick="SaveClick"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                            <asp:LinkButton ID="lbCancelTop" runat="server" OnClick="CancelClick"
                                CssClass="btn btn-danger"><i class="fa fa-undo"></i>&nbsp;Cancel</asp:LinkButton>

                            <ul class="nav nav-tabs text-primary pull-left">
                                <li class="active"><a data-toggle="tab" href="#details">Details</a></li>
                                <li><a data-toggle="tab" href="#tasks">Tasks</a></li>
                                <li><a data-toggle="tab" href="#log">Audit Log</a></li>
                            </ul>

                        </div>
                    </div>


                    <div class="tab-content">
                        <div id="details" class="tab-pane fade in active">
                            <h3>DETAILS</h3>
                            <div class="row">
                                <div class="col-lg-12 panel-body">
                                    <fieldset>

                                        <asp:HiddenField ID="hfID" runat="server" />

                                        <div class="row">

                                            <div class="col-lg-3 form-group">
                                                <label>Project Manager<span class="text-danger">*</span></label>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" CssClass="label label-warning"
                                                    ControlToValidate="ddlProjectManager" runat="server" ValidationGroup="vgMain" />
                                                <asp:DropDownList ID="ddlProjectManager" runat="server" CssClass="form-control"
                                                    AppendDataBoundItems="true" ToolTip="Project Manager">
                                                    <asp:ListItem Text="-- SELECT --" Value="" />
                                                </asp:DropDownList>
                                            </div>

                                            <div class="col-lg-3 form-group">
                                                <label>Managing Director<span class="text-danger">*</span></label>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" CssClass="label label-warning"
                                                    ControlToValidate="ddlManagingDirector" runat="server" ValidationGroup="vgMain" />
                                                <asp:DropDownList ID="ddlManagingDirector" runat="server" CssClass="form-control"
                                                    AppendDataBoundItems="true" ToolTip="Managing Director">
                                                    <asp:ListItem Text="-- SELECT --" Value="" />
                                                </asp:DropDownList>
                                            </div>

                                            <div class="col-lg-3 form-group">
                                                <label>Name<span class="text-danger">*</span></label>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" CssClass="label label-warning"
                                                    ControlToValidate="txtName" runat="server" ValidationGroup="vgMain" />
                                                <asp:TextBox ID="txtName" runat="server" MaxLength="200"
                                                    CssClass="form-control" placeholder="Name"
                                                    ToolTip="Name" autofocus="true" />
                                            </div>

                                            <div class="col-lg-3 form-group">
                                                <label>ADM ID<span class="text-danger">*</span></label>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" CssClass="label label-warning"
                                                    ControlToValidate="txtAdmID" runat="server" ValidationGroup="vgMain" />
                                                <asp:TextBox ID="txtAdmID" runat="server" MaxLength="20"
                                                    CssClass="form-control" placeholder="ADM ID"
                                                    ToolTip="ADM ID" />
                                            </div>

                                            <div class="col-lg-3 form-group">
                                                <label>File Name<span class="text-danger">*</span></label>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="txtFileName"
                                                    runat="server" ValidationGroup="vgMain" CssClass="label label-warning" />
                                                <asp:TextBox ID="txtFileName" runat="server" MaxLength="100"
                                                    CssClass="form-control" placeholder="File Name" ToolTip="File Name" />
                                            </div>

                                            <div class="col-lg-3 form-group">
                                                <label>Landlord<span class="text-danger">*</span></label>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="txtLandlord"
                                                    runat="server" ValidationGroup="vgMain" CssClass="label label-warning" />
                                                <asp:TextBox ID="txtLandlord" runat="server" MaxLength="100"
                                                    CssClass="form-control" placeholder="Landlord" ToolTip="Landlord" />
                                            </div>

                                            <div class="col-lg-3 form-group">
                                                <label>Tenant Name<span class="text-danger">*</span></label>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="txtTenantName"
                                                    runat="server" ValidationGroup="vgMain" CssClass="label label-warning" />
                                                <asp:TextBox ID="txtTenantName" runat="server" MaxLength="100"
                                                    CssClass="form-control" placeholder="Tenant Name" ToolTip="Tenant Name" />
                                            </div>

                                            <div class="col-lg-3 form-group">
                                                <label>Property Manager<span class="text-danger">*</span></label>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="txtPropertyManager"
                                                    runat="server" ValidationGroup="vgMain" CssClass="label label-warning" />
                                                <asp:TextBox ID="txtPropertyManager" runat="server" MaxLength="100"
                                                    CssClass="form-control" placeholder="Property Manager" ToolTip="Property Manager" />
                                            </div>

                                            <div class="col-lg-3 form-group">
                                                <label>Area<span class="text-danger">*</span></label>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="txtArea"
                                                    runat="server" ValidationGroup="vgMain" CssClass="label label-warning" />
                                                <asp:TextBox ID="txtArea" runat="server" MaxLength="100"
                                                    CssClass="form-control" placeholder="Area" ToolTip="Area" />
                                            </div>

                                            <div class="col-lg-3 form-group">
                                                <label>Sector<span class="text-danger">*</span></label>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="txtSector"
                                                    runat="server" ValidationGroup="vgMain" CssClass="label label-warning" />
                                                <asp:TextBox ID="txtSector" runat="server" MaxLength="100"
                                                    CssClass="form-control" placeholder="Sector" ToolTip="Sector" />
                                            </div>

                                            <div class="col-lg-3 form-group">
                                                <label>Plot<span class="text-danger">*</span></label>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="txtPlot"
                                                    runat="server" ValidationGroup="vgMain" CssClass="label label-warning" />
                                                <asp:TextBox ID="txtPlot" runat="server" MaxLength="100"
                                                    CssClass="form-control" placeholder="Plot" ToolTip="Plot" />
                                            </div>

                                            <div class="col-lg-3 form-group">
                                                <label>Unit No<span class="text-danger">*</span></label>
                                                <asp:RequiredFieldValidator ErrorMessage="Required" ControlToValidate="txtUnitNo"
                                                    runat="server" ValidationGroup="vgMain" CssClass="label label-warning" />
                                                <asp:TextBox ID="txtUnitNo" runat="server" MaxLength="100"
                                                    CssClass="form-control" placeholder="Unit No" ToolTip="Unit No" />
                                            </div>

                                            <div class="col-lg-3 form-group">
                                                <label>Status</label>
                                                <asp:TextBox ID="txtStatus" runat="server" MaxLength="20" Enabled="false"
                                                    CssClass="form-control" placeholder="Status" ToolTip="Status" />
                                            </div>

                                            <div class="col-lg-6 form-group">
                                                <label>Notes</label>
                                                <asp:TextBox ID="txtNotes" runat="server" MaxLength="500"
                                                    CssClass="form-control" placeholder="Notes" ToolTip="Notes" />
                                            </div>

                                        </div>

                                    </fieldset>
                                </div>
                            </div>
                        </div>
                        <div id="tasks" class="tab-pane fade">
                            <h3>TASKS</h3>
                            <div class="row">
                                <div class="col-lg-12 panel-body">

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
                                                <td>
                                                    <asp:HiddenField ID="hfID" runat="server" Value='<%# Eval("ID") %>' />
                                                    <asp:HiddenField ID="hfTaskID" runat="server" Value='<%# Eval("ID") %>' />
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
                        </div>
                        <div id="log" class="tab-pane fade">
                            <h3>AUDIT LOG</h3>
                            <p>Some content in menu 2.</p>
                        </div>
                    </div>


                    <div class="row">
                        <div class="col-lg-12 panel-footer text-right">
                            <asp:LinkButton ID="lbSaveBottom" runat="server" CssClass="btn btn-primary"
                                ValidationGroup="vgMain" OnClick="SaveClick"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                            <asp:LinkButton ID="lbCancelBottom" runat="server" OnClick="CancelClick"
                                CssClass="btn btn-danger"><i class="fa fa-undo"></i>&nbsp;Cancel</asp:LinkButton>
                        </div>
                    </div>

                </div>
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
