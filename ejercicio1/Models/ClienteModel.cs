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
    }
}
