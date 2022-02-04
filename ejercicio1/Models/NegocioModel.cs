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
    public class NegocioModel
    {

        private readonly string cadenaConexion;
        Funciones funciones = new Funciones();
        public NegocioModel(string _conexion)
        {
            this.cadenaConexion = _conexion;
        }
        public void InsertarNegocio(int IdCliente, Negocio insertarNegocio)
        {

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_InsertarNegocio", cn);
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = IdCliente;
                cmd.Parameters.Add("@nitNegocio", SqlDbType.Int).Value = insertarNegocio.nitNegocio;
                cmd.Parameters.Add("@nombreNegocio", SqlDbType.VarChar).Value = insertarNegocio.nombreNegocio;
                cmd.Parameters.Add("@direccionNegocio", SqlDbType.VarChar).Value = insertarNegocio.direccionNegocio;
                cmd.Parameters.Add("@telefonoNegocio", SqlDbType.Int).Value = insertarNegocio.telefonoNegocio;


                cn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandTimeout = 300;



            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (cadenaConexion != null && cn.State != ConnectionState.Closed)
                    cn.Close();

            }

            return;

        }
        public void ActualizarNegocio(int idCliente, Negocio insertarNegocio)
        {

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_ActualizarNegocio", cn);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;
                cmd.Parameters.Add("@nitNegocio", SqlDbType.Int).Value = insertarNegocio.nitNegocio;
                cmd.Parameters.Add("@nombreNegocio", SqlDbType.VarChar).Value = insertarNegocio.nombreNegocio;
                cmd.Parameters.Add("@direccionNegocio", SqlDbType.VarChar).Value = insertarNegocio.direccionNegocio;
                cmd.Parameters.Add("@telefonoNegocio", SqlDbType.Int).Value = insertarNegocio.telefonoNegocio;


                cn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandTimeout = 300;



            }
            catch (Exception ex)
            {

            }
            finally
            {
                if (cadenaConexion != null && cn.State != ConnectionState.Closed)
                    cn.Close();

            }

            return;

        }
        public List<Negocio> GetNegocio(int idCliente)
        {

            string respuesta;
            DataTable dt = new DataTable();

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_GetNegocio", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

                cn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandTimeout = 300;


                da.Fill(dt);

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

            return funciones.ConvertDataTableToList<Negocio>(dt);

        }

        public bool EliminarNegocio(int idCliente)
        {
            bool resp;

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_EliminarNegocio", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = idCliente;

                cn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandTimeout = 300;

                resp = true;

            }
            catch (Exception ex)
            {
                resp = false;
            }
            finally
            {
                if (cadenaConexion != null && cn.State != ConnectionState.Closed)
                    cn.Close();

            }

            return resp;

        }
    }
}

