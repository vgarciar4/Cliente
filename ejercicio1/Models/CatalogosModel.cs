using ejercicio1.Models.Clases;
using ejercicio1.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio1.Models
{
    public class CatalogosModel
    {
        private readonly string cadenaConexion;

        Funciones _funciones = new Funciones();

        public CatalogosModel(string _conexion)
        {
            this.cadenaConexion = _conexion;
        }

        public List<TipoIdentificacion> getAllTipoIdentificacion()
        {

            string respuesta;
            DataTable dtIdentificacion = new DataTable();

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_GetAllTipoIdentificacion", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandTimeout = 300;


                da.Fill(dtIdentificacion);
                respuesta = "OK";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (cadenaConexion != null && cn.State != ConnectionState.Closed)
                    cn.Close();

            }

            return _funciones.ConvertDataTableToList<TipoIdentificacion>(dtIdentificacion);
        }

        public List<TipoTarjeta> getAllTipoTarjeta()
        {

            string respuesta;
            DataTable dtTarjeta = new DataTable();

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_GetAllTipoTarjeta", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandTimeout = 300;


                da.Fill(dtTarjeta);
                respuesta = "OK";

            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (cadenaConexion != null && cn.State != ConnectionState.Closed)
                    cn.Close();

            }

            return _funciones.ConvertDataTableToList<TipoTarjeta>(dtTarjeta);
        }
    }
}
