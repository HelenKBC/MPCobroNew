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
    public class LocalesDAL : Connection
    {
        private static LocalesDAL instance;
        public static LocalesDAL Instance
        {
            get
            {
                if (instance == null)
                    instance = new LocalesDAL();
                return instance;
            }

        }
        public bool Insert (Locales entity) // Insert
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LocalesInsert", conn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EdificioId", entity.EdificioId);
                    cmd.Parameters.AddWithValue("@CategoriaId", entity.CategoriaId);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@CodigoDeBarras", entity.CodigoDeBarras);
                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public List<Locales> SelectAll() //SelectAll
        {
            List<Locales> result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LocalesSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new List<Locales>();

                            while (dr.Read())
                            {
                                Locales entity = new Locales();
                                entity.LocalesId = dr.GetInt32(0);
                                entity.EdificioId = dr.GetInt32(1);
                                entity.CategoriaId = dr.GetInt32(2);
                                entity.EstadoId = dr.GetInt32(3);
                                entity.Nombre = dr.GetString(4);
                                entity.CodigoDeBarras = dr.GetString(5); 
                                result.Add(entity);
                            }
                        }
                    }
                }
            }
            return result;
        }
        public Locales SelectById(int Id) //SELECTBYID
        {
                Locales result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LocalesSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LocalesId", Id); 
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new Locales();
                            while (dr.Read())
                            {
                                result.LocalesId = dr.GetInt32(0);
                                result.EdificioId = dr.GetInt32(1);
                                result.CategoriaId = dr.GetInt32(2);
                                result.EstadoId = dr.GetInt32(3);
                                result.Nombre = dr.GetString(4);
                                result.CodigoDeBarras = dr.GetString(5); //money 
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(Locales entity) //Update
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LocalesUpdate", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@LocalesId", entity.LocalesId);
                    cmd.Parameters.AddWithValue("@EdificioId", entity.EdificioId);
                    cmd.Parameters.AddWithValue("@CategoriaId", entity.CategoriaId);
                    cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                    cmd.Parameters.AddWithValue("@CodigoDeBarras", entity.CodigoDeBarras);
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public bool UpdateLocales(Locales entity) //UpdateEstados
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LocalesUpdateStates", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@LocalesId", entity.LocalesId);
                    cmd.Parameters.AddWithValue("@EstadoId", entity.EstadoId);
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
        public bool Delete(int id)  //Delete
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_LocalesDelete", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@LocalesId", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}
    





