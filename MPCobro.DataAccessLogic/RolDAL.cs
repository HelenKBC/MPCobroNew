using MPCobro.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace MPCobro.DataAccessLogic
{
    public class RolDAL : Connection

    {
        private static RolDAL _instance;
        public static RolDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RolDAL();
                return _instance;
            }

        }
        public bool Insert(Rol entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_RolInsert", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public List<Rol> SelectAll()
        {
            List<Rol> listado = new List<Rol>();

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_RolSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Rol entity = new Rol();
                                entity.RolId = dr.GetInt32(0);
                                entity.Nombre = dr.GetString(1);
                                listado.Add(entity);
                            }
                        }
                    }
                }
            }
            return listado;
        }

        public Rol SelectById(int id)
        {
            Rol result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_RolSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@RolId", id);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                result = new Rol()
                                {
                                    RolId = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                };
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(Rol entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_RolUpdate", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@RolId", entity.RolId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.CommandType = CommandType.StoredProcedure;
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
                using (SqlCommand cmd = new SqlCommand("sp_RolDelete", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@RolId", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        /*
        public List<Rol> SelectProductoByRolId(int id)
        {

        }
        */
    }
}
