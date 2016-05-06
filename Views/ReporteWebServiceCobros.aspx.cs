using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ReporteriaFinaciero.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace ReporteriaFinaciero.Views
{
    public partial class ReporteWebServiceCobros : System.Web.UI.Page
    {
        QueryCampos querydt = new QueryCampos();
        QueryReporteria queryrpt = new QueryReporteria();

        protected void Page_Load(object sender, EventArgs e)
        {            
            try
            {
                if (!IsPostBack)
                {
                    DataTable dtRubro = new DataTable();                    
                    DataTable dtDelegacionVentanilla = new DataTable();

                    dtRubro = querydt.LlenadoCampoRubro(dtRubro);
                    dtDelegacionVentanilla = querydt.LlenadoCampoDelegacionVentanilla(dtDelegacionVentanilla);

                    ddlRubro.DataSource = dtRubro;
                    ddlRubro.DataTextField = "Rubro";
                    ddlRubro.DataValueField = "IdRubro";
                    ddlRubro.DataBind();

                    ddlDelegacionVentanilla.DataSource = dtDelegacionVentanilla;
                    ddlDelegacionVentanilla.DataTextField = "DelegacionVentanilla";
                    ddlDelegacionVentanilla.DataValueField = "IdDelegacionVentanilla";
                    ddlDelegacionVentanilla.DataBind();

                }
            }
            catch (Exception ex) {
                throw ex;
            }
            
        }

        protected void ddlRubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlRubro.Text != "") { 
                    DataTable dtAuxiliar = new DataTable();
                    Int32 IdRubro = Convert.ToInt32(ddlRubro.SelectedValue);
                    dtAuxiliar = querydt.LlenadoCampoAuxiliar(dtAuxiliar,IdRubro);

                    ddlAuxiliar.DataSource = dtAuxiliar;
                    ddlAuxiliar.DataTextField = "Auxiliar";
                    ddlAuxiliar.DataValueField = "IdAuxiliar";
                    ddlAuxiliar.DataBind();
                }

            }
            catch (Exception ex) {
                throw ex;
            }
        }

        protected void btnGenerarReporte_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet dsReporte = new DataSet();
                Int32 IdRubro = Convert.ToInt32(ddlRubro.SelectedValue);
                Int32 IdAuxiliar = Convert.ToInt32(ddlAuxiliar.SelectedValue);
                String No63A = txtNum63A2.Text;
                String NumeroCobro = txtNumeroCobro.Text;
                Int32 IdDelegacionVentanilla = Convert.ToInt32(ddlDelegacionVentanilla.SelectedValue);
                String NIT = txtNITProponente.Text;

                dsReporte = queryrpt.LlenadoReporteFinanciero(IdRubro, IdAuxiliar, No63A, NumeroCobro, IdDelegacionVentanilla, NIT);
                CrystalReportSource1.ReportDocument.SetDataSource(dsReporte);
                CrystalReportViewer1.RefreshReport();
            }
            catch (Exception ex) {
                throw ex;
            }            
        }
    }
}