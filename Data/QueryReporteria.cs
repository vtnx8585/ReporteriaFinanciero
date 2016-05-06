using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using ReporteriaFinaciero.Data;

namespace ReporteriaFinaciero.Data
{
    public class QueryReporteria
    {
        public DataSet LlenadoReporteFinanciero(int IdRubro, int IdAuxiliar, String No63A, String NumeroCobro, int IdDelegacionVentanilla, String NIT) {
            try
            {
                DataSetReporteria ds = new DataSetReporteria();
                ds.Clear();

                string cs = ConfigurationManager.ConnectionStrings["ReportesConnection"].ConnectionString;
                //String qry = "SELECT TDP.CORRELATIVO_PAGO AS Columna FROM GESTION.TD_PAGOS TDP";
                //String qry = "SELECT CORRELATIVO_COBRO AS Columna FROM TM_FACTURACION";
                String qry = " SELECT TMCOS.DESCRIPCION AS RUBRO,TDCOS.DESCRIPCION AS AUXILIAR,TDPAG.CORRELATIVO_63A AS NO63_A2, TDPAG.AGENCIA_NUMERO AS AGENCIABANRURAL," +
                             " TDPAG.NUMERO_COBRO AS NUMEROCOBRO,TCADM.DESCRIPCION AS DELEGACIONVENTANILLA,TDPAG.AGENCIA_OPERADOR AS OPERADOR,TMFAC.NIT_PROPONENTE AS NIT, TDPAG.MONTO_PAGADO AS PAGO FROM GESTION.TD_PAGOS TDPAG" +
                             " JOIN GESTION.TM_FACTURACION TMFAC ON TMFAC.CORRELATIVO_COBRO = TDPAG.NUMERO_COBRO" +
                             " JOIN ALMACEN.TC_UNIDAD_ADMINISTRATIVA TCADM ON TCADM.CODIGO_UNIDAD_ADMINISTRATIVA = TMFAC.CODIGO_UNIDAD_ADMINISTRATIVA" +
                             " JOIN GESTION.TD_FACTURACION TDFAC ON TDFAC.CORRELATIVO_COBRO = TMFAC.CORRELATIVO_COBRO" +
                             " JOIN GESTION.TD_COSTOS TDCOS ON TDCOS.ID_COBROS = TDFAC.ID_COBROS AND TDCOS.ID_DCOBROS = TDFAC.ID_DCOBROS" +
                             " JOIN GESTION.TM_COSTOS TMCOS ON TMCOS.ID_COBROS = TDFAC.ID_COBROS";

                if (IdRubro != -1 || IdAuxiliar != -1 || No63A != "" || NumeroCobro != "" || IdDelegacionVentanilla != -1 || NIT != "")
                {
                    qry += " WHERE TDPAG.NUMERO_COBRO IS NOT NULL";

                    if (IdRubro != -1)
                    {
                        qry += " AND TMCOS.ID_COBROS = " + IdRubro;
                    }

                    if (IdAuxiliar != -1)
                    {
                        qry += " AND TDCOS.ID_DCOBROS = " + IdAuxiliar;
                    }

                    if (No63A != "")
                    {
                        qry += " AND TDPAG.CORRELATIVO_63A = " + No63A;
                    }

                    if (NumeroCobro != "")
                    {
                        qry += " AND TDPAG.NUMERO_COBRO = " + NumeroCobro;
                    }

                    if (IdDelegacionVentanilla != -1)
                    {
                        qry += " AND TCADM.CODIGO_UNIDAD_ADMINISTRATIVA = " + IdDelegacionVentanilla;
                    }

                    if (NIT != "")
                    {
                        qry += " AND TMFAC.NIT_PROPONENTE = " + NIT;
                    }
                }
                
                OleDbConnection conn = new OleDbConnection(cs);
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = qry;
                OleDbDataAdapter oracleadap = new OleDbDataAdapter(cmd);
                oracleadap.Fill(ds,"ReporteFinanciero");
                conn.Close();
                
                return ds;
            }
            catch (Exception ex) {
                throw ex;
            }
        }
    }
}