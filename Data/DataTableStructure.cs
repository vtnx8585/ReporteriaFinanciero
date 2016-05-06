using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;


namespace ReporteriaFinaciero.Data
{
    public class DataTableStructure
    {
        public DataTable dtRubro() {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("IdRubro", typeof(Int32));
                dt.Columns.Add("Rubro", typeof(String));

                return dt;
            }
            catch (Exception ex) {
                throw ex;
            }
        }

        public DataTable dtAuxiliar()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("IdAuxiliar", typeof(Int32));
                dt.Columns.Add("Auxiliar", typeof(String));

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable dtDelegacionVentanilla()
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("IdDelegacionVentanilla", typeof(Int32));
                dt.Columns.Add("DelegacionVentanilla", typeof(String));

                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}