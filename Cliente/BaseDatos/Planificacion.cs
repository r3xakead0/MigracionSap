using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using BE = MigracionSap.Cliente.BaseDatos.Entidades;

namespace MigracionSap.Cliente.BaseDatos
{
    public class Planificacion
    {


        public List<BE.Planificacion> Listar()
        {
            var lstBePlanificacion = new List<BE.Planificacion>();
            try
            {

                string sp = "SpTbPlanificacionListar";


                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var bePlaninficacion = new BE.Planificacion();

                        bePlaninficacion.Id = int.Parse(reader["IdPlanificacion"].ToString());
                        bePlaninficacion.Dia = int.Parse(reader["Dia"].ToString());
                        bePlaninficacion.Hora = DateTime.Parse(reader["Hora"].ToString());

                        lstBePlanificacion.Add(bePlaninficacion);
                    }

                    cnn.Close();
                }
                   
                return lstBePlanificacion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insertar(ref BE.Planificacion planificacion)
        {
            try
            {
                string sp = "SpTbPlanificacionInsertar";
                int rowsAffected = 0;

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDPLANIFICACION", planificacion.Id));
                    cmd.Parameters["@IDPLANIFICACION"].Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(new SqlParameter("@DIA", planificacion.Dia));
                    
                    //cmd.Parameters.Add(new SqlParameter("@HORA", planificacion.Hora.TimeOfDay));
                    cmd.Parameters.Add("@HORA", SqlDbType.Time).Value = planificacion.Hora.TimeOfDay;

                    rowsAffected = cmd.ExecuteNonQuery();
                    planificacion.Id = int.Parse(cmd.Parameters["@IDPLANIFICACION"].Value.ToString());
                }

                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Eliminar(int id)
        {
            try
            {
                string sp = "SpTbPlanificacionEliminar";
                int rowsAffected = 0;

                using (var cnn = new SqlConnection(Conexion.strCnxBD))
                {
                    cnn.Open();

                    var cmd = new SqlCommand(sp, cnn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@IDPLANIFICACION", id));

                    rowsAffected = cmd.ExecuteNonQuery();
                }

                return rowsAffected > 0;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
