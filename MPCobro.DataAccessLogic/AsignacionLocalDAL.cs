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
    public class AsignacionLocalDAL : Connection
    {
        private static AsignacionLocalDAL instance;
        public static AsignacionLocalDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new AsignacionLocalDAL();
                return instance;
            }

        }
        public bool Insert(AsignacionLocal entity) //Insert
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_AsignacionLocalInsert", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LocalId", entity.LocalId);
                    cmd.Parameters.AddWithValue("@ArrendatarioId", entity.ArrendatarioId);
                    cmd.Parameters.AddWithValue("@FechaInicio", entity.FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaUltimoPago", entity.FechaUltimoPago);
                    cmd.Parameters.AddWithValue("@Monto", entity.Monto);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }


       
        public bool Update(AsignacionLocal entity)  // *** UPDATE
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_AsignacionLocalUpdate", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@AsignacionLocalId", entity.AsignacionLocalId);
                    cmd.Parameters.AddWithValue("@LocalId", entity.LocalId);
                    cmd.Parameters.AddWithValue("@ArrendatarioId", entity.ArrendatarioId);
                    cmd.Parameters.AddWithValue("@FechaInicio", entity.FechaInicio);
                    cmd.Parameters.AddWithValue("@FechaUltimoPago", entity.FechaUltimoPago);
                    cmd.Parameters.AddWithValue("@Monto", entity.Monto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public bool Delete(int id) // DELETE *** 
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_AsignacionLocalDelete", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@AsignacionLocalId", id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public List<AsignacionLocal> SelectAll() //SelectAll
        {
            List<AsignacionLocal> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_AsignacionLocalSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<AsignacionLocal>();

                            while (dr.Read())
                            {
                                AsignacionLocal _entity = new AsignacionLocal();
                                _entity.AsignacionLocalId = dr.GetInt32(0);
                                _entity.LocalId = dr.GetInt32(1);
                                _entity.ArrendatarioId = dr.GetInt32(2);
                                _entity.FechaInicio = dr.GetDateTime(3);
                                _entity.FechaUltimoPago = dr.GetDateTime(4);
                                _entity.Monto = dr.GetDecimal(5); //GetMonto
                                result.Add(_entity);
                            }
                        }
                    }
                }
            }
            return result;
        }
        public AsignacionLocal SelectById(int Id) //SELECTBYID
        {
            AsignacionLocal result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_AsignacionLocalSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AsignacionLocalId", Id); //IDAsignacionLocal?
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new AsignacionLocal();
                            while (dr.Read())
                            {
                                result.AsignacionLocalId = dr.GetInt32(0);
                                result.LocalId = dr.GetInt32(1);
                                result.ArrendatarioId = dr.GetInt32(2);
                                result.FechaInicio= dr.GetDateTime(3);
                                result.FechaUltimoPago = dr.GetDateTime(4);
                                result.Monto = dr.GetInt32(5); //money 
                            }
                        }
                    }
                }
            }
            return result;
        }


    }
}

    

