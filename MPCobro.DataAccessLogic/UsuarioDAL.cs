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
    public class UsuarioDAL : Connection
    {
        private static UsuarioDAL _instance;
        public static UsuarioDAL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UsuarioDAL();
                return _instance;
            }
        }
        public bool Insert(Usuario entity)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UsuarioInsert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmpleadoId", entity.EmpleadoId);
                    cmd.Parameters.AddWithValue("@NombreUser", entity.NombreUser);
                    cmd.Parameters.AddWithValue("@Clave", entity.Clave);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }

            return result;
        }
        public List<Usuario> SelectAll()
        {
            List<Usuario> usuarios = new List<Usuario>();

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UsuarioSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Usuario usuario = new Usuario
                            {
                                UsuarioId = dr.GetInt32(0),
                                EmpleadoId = dr.GetInt32(1),
                                NombreUser = dr.GetString(2),
                                Clave = dr.GetString(3)
                            };
                            usuarios.Add(usuario);
                        }
                    }
                }
            }

            return usuarios;
        }
        public Usuario SelectById(int usuarioId)
        {
            Usuario usuario = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UsuarioSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null && dr.Read())
                        {
                            usuario = new Usuario()
                            {
                                UsuarioId = dr.GetInt32(0),
                                EmpleadoId = dr.GetInt32(1),
                                NombreUser = dr.GetString(2)
                            };
                        }
                    }
                }
            }

            return usuario;
        }

        public bool Delete(int usuarioId)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UsuarioDelete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", usuarioId);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }

        public bool Update(Usuario usuario)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_UsuarioUpdate", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UsuarioId", usuario.UsuarioId);
                    cmd.Parameters.AddWithValue("@EmpleadoId", usuario.EmpleadoId);
                    cmd.Parameters.AddWithValue("@NombreUser", usuario.NombreUser);
                    cmd.Parameters.AddWithValue("@Clave", usuario.Clave);

                    conn.Open();
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}