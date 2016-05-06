<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ReporteWebServiceCobros.aspx.cs" Inherits="ReporteriaFinaciero.Views.ReporteWebServiceCobros" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="panel panel-default">        
        <div class="row">
            <div class="col-lg-12 col-md-12 col-sm-12">
                <div class="panel panel-default">
                    <div class="panel-heading">Reporte WebService Cobros</div>
                    <div>
                        <ol class="breadcrumb">
                            <li><a href="#">Home</a></li>
                            <li><a href="#">Library</a></li>
                            <li class="active">Data</li>
                        </ol>
                    </div>
                    <div class="panel-body">                         
                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">Rubro:</div>
                                    <asp:DropDownList ID="ddlRubro" runat="server" CssClass="form-control dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="ddlRubro_SelectedIndexChanged"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">Auxiliar:</div>
                                    <asp:DropDownList ID="ddlAuxiliar" runat="server" CssClass="form-control dropdown-toggle"></asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">No. de 63-A2:</div>
                                    <asp:TextBox ID="txtNum63A2" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>  
                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">No. Cobro:</div>
                                    <asp:TextBox ID="txtNumeroCobro" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">Delegacion/Ventanilla:</div>
                                    <asp:DropDownList ID="ddlDelegacionVentanilla" runat="server" CssClass="form-control dropdown-toggle"></asp:DropDownList>
                                </div>
                            </div>
                        </div>   
                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <div class="form-group">
                                <div class="input-group">
                                    <div class="input-group-addon">NIT proponente:</div>
                                    <asp:TextBox ID="txtNITProponente" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div> 
                         
                        <br />
                        
                        <div class="col-lg-2 col-md-2 col-sm-2">
                            <asp:Button ID="btnGenerarReporte" runat="server" Text="Generar Reporte" CssClass="btn btn-primary" OnClick="btnGenerarReporte_Click"/>
                        </div>  
                        
                        <br />
                       
                        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="true" HasCrystalLogo="False"
    EnableDatabaseLogonPrompt="False" EnableParameterPrompt="False"
    GroupTreeImagesFolderUrl="/aspnet_client/system_web/2_0_50727/CrystalReportWebFormViewer3/images/tree/"
    ToolbarImagesFolderUrl="/aspnet_client/system_web/2_0_50727/CrystalReportWebFormViewer3/images/toolbar/" ReportSourceID="CrystalReportSource1" />
                        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
                            <Report FileName="ReporteCobros.rpt">
                            </Report>
                        </CR:CrystalReportSource>
                        
                       
                    </div>
                </div>
            </div>
        </div>
        <div>

        </div>
    </div>
</asp:Content>

