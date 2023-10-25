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
    public class EdificioDAL: Connection
    {
        private static  EdificioDAL instance;
        public static   EdificioDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new EdificioDAL();
                return instance;
            }

        }

        public bool Insert(Edificio entity)  // **INSERT
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_EdificioInsert", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@CantidadLocales", entity.CantidadLocales);
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }


        public bool Update(Edificio entity)  //UPDATE
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_EdificioUpdate", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@EdificioId", entity.EdificioId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@CantidadLocales", entity.CantidadLocales);
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
                using (SqlCommand cmd = new SqlCommand("sp_EdificioDelete", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@EdificioId", id);
                    cmd.CommandType = CommandType.StoredProcedure;

                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }


        public List<Edificio> SelectAll() //SELECTALL **** 
        {
            List<Edificio> listado = new List<Edificio>();

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_EdificioSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Edificio _entity = new Edificio();
                                _entity.EdificioId = dr.GetInt32(0);
                                _entity.Nombre = dr.GetString(1);
                                _entity.CantidadLocales = dr.GetInt32(2);
                                listado.Add(_entity);
                            }
                        }
                    }
                }
            }
            return listado;
        }

        public Edificio SelectById(int Id) //SELECTBYID
        {
            Edificio result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_EdificioSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EdificioId", Id);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new Edificio();
                            while (dr.Read())
                            {
                                result.EdificioId = dr.GetInt32(0);
                                result.Nombre = dr.GetString(1);
                                result.CantidadLocales = dr.GetInt32(2);
                              
                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}
    

 