using MPCobro.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.DataAccessLogic
{
    public class CategoriaDAL: Connection
    {
            private static CategoriaDAL instance;
            public static CategoriaDAL Instance
            {
                get
                {
                    if (instance == null)
                        instance = new CategoriaDAL();
                    return instance;
                }

            }

            public bool Insert(Categoria entity)  // **INSERT
            {
                bool result = false;
                using (SqlConnection conn = new SqlConnection(_cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CategoriaInsert", conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
                        cmd.CommandType = CommandType.StoredProcedure;
                        result = cmd.ExecuteNonQuery() > 0;
                    }
                }
                return result;
            }


            public bool Update(Categoria entity)  //UPDATE
            {
                bool result = false;
                using (SqlConnection conn = new SqlConnection(_cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CategoriaUpdate", conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@CategoriaId", entity.CategoriaId);
                        cmd.Parameters.AddWithValue("@Nombre", entity.Nombre);
                        cmd.Parameters.AddWithValue("@Descripcion", entity.Descripcion);
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
                    using (SqlCommand cmd = new SqlCommand("sp_CategoriaDelete", conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@CategoriaId", id);
                        cmd.CommandType = CommandType.StoredProcedure;

                        result = cmd.ExecuteNonQuery() > 0;
                    }
                }
                return result;
            }


            public List<Categoria> SelectAll() //SELECTALL **** 
            {
                List<Categoria> listado = new List<Categoria>();

                using (SqlConnection conn = new SqlConnection(_cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_CategoriaSelectAll", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        conn.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                        {
                            if (dr != null)
                            {
                                while (dr.Read())
                                {
                                    Categoria _entity = new Categoria();
                                    _entity.CategoriaId = dr.GetInt32(0);
                                    _entity.Nombre = dr.GetString(1);
                                    _entity.Descripcion = dr.GetString(2);
                                    listado.Add(_entity);
                                }
                            }
                        }
                    }
                }
                return listado;
            }


        public Categoria SelectById(int Id) //SELECTBYID
        {
            Categoria result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CategoriaSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CategoriaId", Id);
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            result = new Categoria();
                            while (dr.Read())
                            {
                                result.CategoriaId = dr.GetInt32(0);
                                result.Nombre = dr.GetString(1);
                                result.Descripcion = dr.GetString(2);

                            }
                        }
                    }
                }
            }
            return result;
        }
    }
}





