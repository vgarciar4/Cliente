using ejercicio1.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio1.Models.Clases
{
    public class ClienteModel
    {
        private readonly string cadenaConexion;
        Funciones funciones = new Funciones();

        public ClienteModel(string _conexion)
        {
            this.cadenaConexion = _conexion;
        }
        public int InsertarCliente(Cliente nuevoCliente)
        {
            int idCliente;

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_InsertarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idNewCliente = new SqlParameter("@idCliente", SqlDbType.Int);
                idNewCliente.Direction = ParameterDirection.ReturnValue;

                cmd.Parameters.Add(idNewCliente);
                cmd.Parameters.Add("@idTipoIdentificacion", SqlDbType.Int).Value = nuevoCliente.idTipoIdentificacion;
                cmd.Parameters.Add("@nit", SqlDbType.Int).Value = nuevoCliente.nit;
                cmd.Parameters.Add("@primerNombre", SqlDbType.VarChar).Value = nuevoCliente.primerNombre;
                cmd.Parameters.Add("@segundoNombre", SqlDbType.VarChar).Value = nuevoCliente.segundoNombre;
                cmd.Parameters.Add("@primerApellido", SqlDbType.VarChar).Value = nuevoCliente.primerApellido;
                cmd.Parameters.Add("@segundoApellido", SqlDbType.VarChar).Value = nuevoCliente.segundoApellido;
                cmd.Parameters.Add("@edad", SqlDbType.Int).Value = nuevoCliente.edad;
                cmd.Parameters.Add("@sexo", SqlDbType.VarChar).Value = nuevoCliente.sexo;
                cmd.Parameters.Add("@numeroIdentificacion", SqlDbType.Int).Value = nuevoCliente.numeroIdentificacion;

                cn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandTimeout = 300;

                idCliente = Convert.ToInt32(idNewCliente.Value);

            }
            catch (Exception ex)
            {
                idCliente = 0;
            }
            finally
            {
                if (cadenaConexion != null && cn.State != ConnectionState.Closed)
                    cn.Close();

            }

            return idCliente;

        }

        public void ActualizarCliente(Cliente clienteExistente)
        {
            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {
                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_ActualizarCliente", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = clienteExistente.idCliente;
                cmd.Parameters.Add("@idTipoIdentificacion", SqlDbType.Int).Value = clienteExistente.idTipoIdentificacion;
                cmd.Parameters.Add("@nit", SqlDbType.Int).Value = clienteExistente.nit;
                cmd.Parameters.Add("@primerNombre", SqlDbType.VarChar).Value = clienteExistente.primerNombre;
                cmd.Parameters.Add("@segundoNombre", SqlDbType.VarChar).Value = clienteExistente.segundoNombre;
                cmd.Parameters.Add("@primerApellido", SqlDbType.VarChar).Value = clienteExistente.primerApellido;
                cmd.Parameters.Add("@segundoApellido", SqlDbType.VarChar).Value = clienteExistente.segundoApellido;
                cmd.Parameters.Add("@edad", SqlDbType.Int).Value = clienteExistente.edad;
                cmd.Parameters.Add("@sexo", SqlDbType.VarChar).Value = clienteExistente.sexo;
                cmd.Parameters.Add("@numeroIdentificacion", SqlDbType.Int).Value = clienteExistente.numeroIdentificacion;

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

        /// <summary>
        /// se Optiene la tabla cliente y se para para viewbag
        /// </summary>
        /// <returns></returns>
        public List<Cliente> GetAllClientes()
        {

            string respuesta;
            DataTable dtClientes = new DataTable();

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_GetAllClientes", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.SelectCommand.CommandTimeout = 300;


                da.Fill(dtClientes);
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

            return funciones.ConvertDataTableToList<Cliente>(dtClientes);
        }

        /// <summary>
        /// Se optine la informacion de cliente por medio del id
        /// </summary>
        /// <param name="idCliente"></param>
        /// <returns></returns>
        public List<Cliente> GetCliente(int idCliente)
        {

            string respuesta;
            DataTable dt = new DataTable();

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_GetCliente", cn);
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

            return funciones.ConvertDataTableToList<Cliente>(dt);
        }
        public bool EliminarCliente(int idCliente)
        {
            bool resp;

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_EliminarCliente", cn);
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
