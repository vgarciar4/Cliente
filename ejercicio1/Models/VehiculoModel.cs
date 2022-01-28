using ejercicio1.Models.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ejercicio1.Models
{
    public class VehiculoModel
    {

        private readonly string cadenaConexion;
        public VehiculoModel(string _conexion)
        {
            this.cadenaConexion = _conexion;
        }
        public void InsertarVehiculo(int IdCliente, Vehiculo insertarVehiculo)
        {

            SqlConnection cn = null/* TODO Change to default(_) if this is not a reference type */;
            SqlCommand cmd = null/* TODO Change to default(_) if this is not a reference type */;
            try
            {

                cn = new SqlConnection(cadenaConexion);
                cmd = new SqlCommand("SP_InsertarVehiculo", cn);
                cmd.CommandType = CommandType.StoredProcedure;



                cmd.Parameters.Add("@idCliente", SqlDbType.Int).Value = IdCliente;
                cmd.Parameters.Add("@marcaVehiculo", SqlDbType.VarChar).Value = insertarVehiculo.marcaVehiculo;
                cmd.Parameters.Add("@modeloVehiculo", SqlDbType.Int).Value = insertarVehiculo.modeloVehiculo;
                cmd.Parameters.Add("@lineaVehiculo", SqlDbType.VarChar).Value = insertarVehiculo.lineaVehiculo;
                cmd.Parameters.Add("@costoAproVehiculo", SqlDbType.Decimal).Value = insertarVehiculo.costoAproVehiculo;


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

