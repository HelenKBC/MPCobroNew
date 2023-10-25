using MPCobro.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.DataAccessLogic
{
    public class EmpleadoDAL:Connection
    {
        public static EmpleadoDAL _instance;
        public static EmpleadoDAL Instance
        {
            get
            {
                if(_instance == null)
                    _instance = new EmpleadoDAL();
                return _instance;
            }
        }
        public bool Insert(Empleado entity) 
        { 
         bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_EmpleadoInsert", conn)) 
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@RolId", entity.RolId);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", entity.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@DUI", entity.DUI);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", entity.CorreoElectronico);
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
        public List<Empleado> SelectAll()
        {
            List<Empleado> listado = new List<Empleado>();

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_EmpleadoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Empleado entity = new Empleado();
                                entity.EmpleadoId = dr.GetInt32(0);
                                entity.RolId = dr.GetInt32(1);
                                entity.EstadoId = dr.GetInt32(2);
                                entity.Nombre = dr.GetString(3);
                                entity.Apellido = dr.GetString(4);
                                entity.Telefono = dr.GetString(5);
                                entity.DUI = dr.GetString(6);
                                entity.CorreoElectronico = dr.GetString(7);
                                listado.Add(entity);
                            }
                        }
                    }
                }
            }
            return listado;
        }
        public Empleado SelectById(int empleadoId)
        {
            Empleado empleado = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_EmpleadoSelectByDUI", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@DUI", empleadoId);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null && dr.Read())
                        {
                            empleado = new Empleado()
                            {
                                EmpleadoId = dr.GetInt32(0),
                                RolId = dr.GetInt32(1),
                                EstadoId = dr.GetInt32(2),
                                Nombre = dr.GetString(3),
                                Apellido = dr.GetString(4),
                                Telefono = dr.GetString(5),
                                DUI = dr.GetString(6),
                                CorreoElectronico = dr.IsDBNull(7) ? null : dr.GetString(7)
                            };
                        }
                    }
                }
            }

            return empleado;
        }

        public bool Delete(int empleadoId)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_EmpleadoDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpleadoId", empleadoId);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public bool Update(Empleado empleado)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_EmpleadoUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpleadoId", empleado.EmpleadoId);
                    cmd.Parameters.AddWithValue("@RolId", empleado.RolId);
                    cmd.Parameters.AddWithValue("@EstadoId", empleado.EstadoId);
                    cmd.Parameters.AddWithValue("@Nombre", empleado.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", empleado.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", empleado.Telefono);
                    cmd.Parameters.AddWithValue("@DUI", empleado.DUI);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", empleado.CorreoElectronico ?? (object)DBNull.Value);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}