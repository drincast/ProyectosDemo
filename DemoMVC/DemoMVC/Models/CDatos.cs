using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DemoMVC.Models
{
    public class CDatos
    {
        private SqlConnection con;
        private string strConn;
        private SqlTransaction sqlTransaccion;

        public CDatos(string strC)
        {
            this.strConn = strC;
            this.con = new SqlConnection(this.strConn);
        }

        public CDatos()
        {
            this.strConn = ConfigurationManager.ConnectionStrings["SIAM"].ToString();
            this.con = new SqlConnection(this.strConn);
        }
         
        public DataSet EjecutarConsulta(string strConsulta)
        {
            SqlDataAdapter sqlDataAdapter = null;
            DataSet res;

            try
            {
                this.con.Open();

                sqlDataAdapter = new SqlDataAdapter(strConsulta, this.con);
                res = new DataSet();
                sqlDataAdapter.Fill(res);
                
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlDataAdapter != null) { 
                    sqlDataAdapter.Dispose();
                }
            }

            return res;
        }

        /// <summary>
        /// Ejecuta una consulta SELECT, pero abre una conexion a la base de datos
        /// </summary>
        /// <param name="strConsulta">consulta select</param>
        /// <returns></returns>
        public DataTable EjecutarConsultaTabla(string strConsulta)
        {
            SqlDataAdapter sqlDataAdapter = null;
            DataTable res;

            try
            {
                this.con.Open();

                sqlDataAdapter = new SqlDataAdapter(strConsulta, this.con);
                res = new DataTable();
                sqlDataAdapter.Fill(res);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (sqlDataAdapter != null)
                {
                    sqlDataAdapter.Dispose();
                }
            }

            return res;
        }

        /// <summary>
        /// Ejecuta una sentencia DML y retorna el numero de filas afectadas, no cierra la conexion.
        /// </summary>
        /// <param name="consulta">cadena de consulta</param>
        /// <returns>numero de filas afectadas</returns>
        public long EjecutarSentenciaDML(string consulta)
        {
            SqlCommand sql = null;
            long filasAfectadas = 0;

            try
            {
                this.sqlTransaccion = this.con.BeginTransaction("tranDML");

                sql = new SqlCommand(consulta, this.con);
                sql.Transaction = this.sqlTransaccion;

                filasAfectadas = sql.ExecuteNonQuery();

                sqlTransaccion.Commit();
            }
            catch (Exception ex)
            {
                this.sqlTransaccion.Rollback();
                throw ex;
            }
            finally
            {
                sql.Dispose();
            }

            return filasAfectadas;
        }
    }
}