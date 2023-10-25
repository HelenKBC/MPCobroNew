using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPCobro.Entities;

namespace MPCobro.DataAccessLogic
{
    public class EstadoDAL:Connection
    {
        private static EstadoDAL _instance;
        public static EstadoDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EstadoDAL();
                return _instance;
            }

        }
        public bool Insert(Estado entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_EstadoInsert", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public List<Estado> SelectAll()
        {
            List<Estado> listado = new List<Estado>();

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_EstadoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Estado entity = new Estado();
                                entity.EstadoId = dr.GetInt32(0);
                                entity.Nombre = dr.GetString(1);
                                listado.Add(entity);
                            }
                        }
                    }
                }
            }
            return listado;
        }

        public Estado SelectById(int id)
        {
            Estado result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_EstadoSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EstadoId", id);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                result = new Estado()
                                {
                                    EstadoId = dr.GetInt32(0),
                                    Nombre = dr.GetString(1),
                                };
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(Estado entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_EstadoUpdate", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);
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
                using (SqlCommand cmd = new SqlCommand("sp_EstadoDelete", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@EstadoId", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}
