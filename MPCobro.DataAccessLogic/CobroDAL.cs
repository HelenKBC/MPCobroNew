using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPCobro.Entities;

namespace MPCobro.DataAccessLogic
{
    public class CobroDAL: Connection
    {
        private static CobroDAL _instance;
        public static CobroDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CobroDAL();
                return _instance;
            }

        }
        public bool Insert(Cobro entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CobroInsert", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@CobroId", entity.CobroId);
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@LocalId", entity.LocalId);
                    cmd.Parameters.AddWithValue("@FechaCobro", entity.FechaCobro);
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public List<Cobro> SelectAll()
        {
            List<Cobro> listado = new List<Cobro>();

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CobroSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Cobro entity = new Cobro();
                                entity.CobroId = dr.GetInt32(0);
                                entity.EmpleadoId = dr.GetInt32(1);
                                entity.LocalId = dr.GetInt32(2);
                                entity.FechaCobro = dr.GetDateTime(3);
                                listado.Add(entity);
                            }
                        }
                    }
                }
            }
            return listado;
        }

        public Cobro SelectById(int id)
        {
            Cobro result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CobroSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CobroId", id);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                result = new Cobro()
                                {
                                    CobroId = dr.GetInt32(0),
                                    EmpleadoId = dr.GetInt32(1),
                                    LocalId = dr.GetInt32(2),
                                    FechaCobro = dr.GetDateTime(3),
                                };
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(Cobro entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CobroUpdate", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@CobroId", entity.CobroId);
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@LocalId", entity.LocalId);
                    cmd.Parameters.AddWithValue("@FechaCobro", entity.FechaCobro);
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
                using (SqlCommand cmd = new SqlCommand("sp_CobroDelete", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@CobroId", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}
