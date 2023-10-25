using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPCobro.Entities;
using System.Text.RegularExpressions;

namespace MPCobro.DataAccessLogic
{
    public class ArrendatarioDAL : Connection
    {
        private static ArrendatarioDAL _instance;

        public static ArrendatarioDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ArrendatarioDAL();
                return _instance;
            }
        }

        public bool Insert(Arrendatario entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ArrendatarioInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", entity.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Dui", entity.Dui);
                    cmd.Parameters.AddWithValue("CorreoElectronico", entity.CorreoElectronico);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0; // Retorna el numero de registros affectados                   
                }
            }
            return result;
        }

        public List<Arrendatario> SelectAll()
        {
            List<Arrendatario> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ArrendatarioSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Arrendatario>();
                            while (dr.Read())
                            {
                                Arrendatario entity = new Arrendatario()
                                {
                                    ArrendatarioId = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                    Apellido = dr.GetString(2),
                                    Telefono = dr.GetString(3),
                                    Dui = dr.GetString(4),
                                    CorreoElectronico = dr.GetString(5),
                                };
                                result.Add(entity);
                            }
                        }
                    }
                }
            }
            return result;
        }

        public Arrendatario SelectById(int id)
        {
            Arrendatario result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ArrendatarioSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArrendatarioId", id);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                result = new Arrendatario()
                                {
                                    ArrendatarioId = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                    Apellido = dr.GetString(2),
                                    Telefono = dr.GetString(3),
                                    Dui = dr.GetString(4),
                                    CorreoElectronico = dr.GetString(5),

                                };
                            }
                        }
                    }


                }
            }
            return result;
        }

        public bool Update(Arrendatario entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ArrendatarioUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArrendatarioId", entity.ArrendatarioId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", entity.Apellido);
                    cmd.Parameters.AddWithValue("@Telefono", entity.Telefono);
                    cmd.Parameters.AddWithValue("@Dui", entity.Dui);
                    cmd.Parameters.AddWithValue("@CorreoElectronico", entity.CorreoElectronico);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ArrendatarioDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArrendatarioId", id);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        //public List<Producto> SelectProductoByMarcaId(int id)
        //{

        //}
    }
}