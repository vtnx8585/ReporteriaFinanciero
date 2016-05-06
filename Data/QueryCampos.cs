using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

namespace ReporteriaFinaciero.Data
{
    public class QueryCampos
    {
        public DataTable LlenadoCampoRubro(DataTable dtRubro) {
            try
            {
                DataTableStructure dtTable = new DataTableStructure();
                dtRubro = dtTable.dtRubro();
                DataRow dtRubroRow = dtRubro.NewRow();
                dtRubroRow["IdRubro"] = -1;
                dtRubroRow["Rubro"] = "";
                dtRubro.Rows.Add(dtRubroRow);

                string cs = ConfigurationManager.ConnectionStrings["ReportesConnection"].ConnectionString;
                String qry = "SELECT ID_COBROS AS IdRubro, DESCRIPCION AS Rubro FROM TM_COSTOS";
                OleDbConnection conn = new OleDbConnection(cs);
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = qry;
                OleDbDataAdapter oracleadap = new OleDbDataAdapter(cmd);
                oracleadap.Fill(dtRubro);
                conn.Close();

                return dtRubro;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public DataTable LlenadoCampoAuxiliar(DataTable dtAuxiliar, int IdRubro) {
            try
            {
                DataTableStructure dtTable = new DataTableStructure();
                dtAuxiliar = dtTable.dtAuxiliar();
                DataRow dtAuxiliarRow = dtAuxiliar.NewRow();
                dtAuxiliarRow["IdAuxiliar"] = -1;
                dtAuxiliarRow["Auxiliar"] = "";
                dtAuxiliar.Rows.Add(dtAuxiliarRow);

                string cs = ConfigurationManager.ConnectionStrings["ReportesConnection"].ConnectionString;
                String qry = " SELECT TDC.ID_DCOBROS AS IdAuxiliar, TDC.DESCRIPCION AS Auxiliar FROM TD_COSTOS TDC" +
                             " JOIN TM_COSTOS TMC ON TMC.ID_COBROS = TDC.ID_COBROS WHERE TDC.ID_COBROS= " + IdRubro;

                OleDbConnection conn = new OleDbConnection(cs);
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = qry;
                OleDbDataAdapter oracleadap = new OleDbDataAdapter(cmd);
                oracleadap.Fill(dtAuxiliar);
                conn.Close();

                return dtAuxiliar;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public DataTable LlenadoCampoDelegacionVentanilla(DataTable dtDelegacionVentanilla) {
            try
            {
                DataTableStructure dtTable = new DataTableStructure();
                dtDelegacionVentanilla = dtTable.dtDelegacionVentanilla();
                DataRow dtDelegacionVentanillaRow = dtDelegacionVentanilla.NewRow();
                dtDelegacionVentanillaRow["IdDelegacionVentanilla"] = -1;
                dtDelegacionVentanillaRow["DelegacionVentanilla"] = "";
                dtDelegacionVentanilla.Rows.Add(dtDelegacionVentanillaRow);

                string cs = ConfigurationManager.ConnectionStrings["ReportesConnection"].ConnectionString;
                String qry = " SELECT UNIQUE CODIGO_UNIDAD_ADMINISTRATIVA AS IdDelegacionVentanilla, DESCRIPCION AS DelegacionVentanilla FROM ALMACEN.TC_UNIDAD_ADMINISTRATIVA " +
                             " WHERE CODIGO_UNIDAD_ADMINISTRATIVA NOT IN (999999,171118,100000,14122)";
                OleDbConnection conn = new OleDbConnection(cs);
                conn.Open();
                OleDbCommand cmd = conn.CreateCommand();
                cmd.CommandText = qry;
                OleDbDataAdapter oracleadap = new OleDbDataAdapter(cmd);
                oracleadap.Fill(dtDelegacionVentanilla);
                conn.Close();

                return dtDelegacionVentanilla;
            }
            catch (Exception ex) {
                throw ex;
            }                      
        }
        
    }
}