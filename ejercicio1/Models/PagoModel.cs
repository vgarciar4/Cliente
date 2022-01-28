using ejercicio1.Models.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio1.Models
{
    public class PagoModel
    {
        private readonly string cadenaConexion;
        public PagoModel(string _conexion)
        {
            this.cadenaConexion = _conexion;
        }
        public void InsertarPago(int IdCliente, Pago insertarPago)
        {

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_InsertarPago", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter idNewCliente = new SqlParameter("@idCliente", SqlDbType.Int);
                idNewCliente.Direction = ParameterDirection.ReturnValue;


                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = IdCliente;
                cmd.Parameters.Add("@IdTipoTarjeta", SqlDbType.Int).Value = insertarPago.idTipoTarjeta;
                cmd.Parameters.Add("@numeroTarjeta", SqlDbType.Int).Value = insertarPago.numeroTarjeta;
                cmd.Parameters.Add("@vencimiento", SqlDbType.DateTime).Value = insertarPago.vencimiento;
                cmd.Parameters.Add("@ccv", SqlDbType.Int).Value = insertarPago.ccv;


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
    }
}
