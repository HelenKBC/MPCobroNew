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
    public class ArqueoDAL:Connection
    {
            private static ArqueoDAL _instance;

            public static ArqueoDAL Instance
            {
                get
                {
                    if (_instance == null)
                        _instance = new ArqueoDAL();
                    return _instance;
                }
            }

            public bool Insert(Arqueo entity)
            {
                bool result = false;
                using (SqlConnection conn = new SqlConnection(_cadena))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ArqueoInsert", conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@UsuarioId", entity.UsuarioId);
                        cmd.Parameters.AddWithValue("@CantidadDe1", entity.CantidadDe1);
                        cmd.Parameters.AddWithValue("@CantidadDe5", entity.CantidadDe5);
                        cmd.Parameters.AddWithValue("@CantidadDe10", entity.CantidadDe10);
                        cmd.Parameters.AddWithValue("@CantidadDe20", entity.CantidadDe20);
                        cmd.Parameters.AddWithValue("@CierreCaja", entity.CierreCaja);
                        cmd.Parameters.AddWithValue("@TotalApertura", entity.TotalApertura);
                        cmd.Parameters.AddWithValue("@FinalDia", entity.FinalDia);
                        cmd.Parameters.AddWithValue("@TotalVentaDelDia", entity.TotalVentaDelDia);
                        cmd.Parameters.AddWithValue("@TotalSobrante", entity.TotalSobrante);
                        cmd.Parameters.AddWithValue("@TotalFaltante", entity.TotalFaltante);
                        cmd.Parameters.AddWithValue("@FechaArqueo", entity.FechaArqueo);
                        cmd.CommandType = CommandType.StoredProcedure;
                        result = cmd.ExecuteNonQuery() > 0;
                    }
                }
                return result;
            }
        public List<Arqueo> SelectAll()
        {
            List<Arqueo> listado = new List<Arqueo>();

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ArqueoSelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                Arqueo entity = new Arqueo();
                                entity.ArqueoId = dr.GetInt32(0);
                                entity.UsuarioId = dr.GetInt32(1);
                                entity.CantidadDe1 = dr.GetInt32(2);
                                entity.CantidadDe5 = dr.GetInt32(3);
                                entity.CantidadDe10 = dr.GetInt32(4);
                                entity.CantidadDe20 = dr.GetInt32(5);
                                entity.CierreCaja = dr.GetDecimal(6);
                                entity.TotalApertura = dr.GetDecimal(7);
                                entity.FinalDia = dr.GetDecimal(8);
                                entity.TotalVentaDelDia = dr.GetDecimal(9);
                                entity.TotalSobrante = dr.GetDecimal(10);
                                entity.TotalFaltante = dr.GetDecimal(11);
                                entity.FechaArqueo = dr.GetDateTime(12);
                                listado.Add(entity);
                            }
                        }
                    }
                }
            }
            return listado;
        }
        public Arqueo SelectById(int id)
        {
            Arqueo result = null;

            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ArqueoSelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ArqueoId", id);
                    conn.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        if (dr != null)
                        {
                            while (dr.Read())
                            {
                                result = new Arqueo()
                                {
                                    ArqueoId = dr.GetInt32(0),
                                    UsuarioId = dr.GetInt32(1),
                                    CantidadDe1 = dr.GetInt32(2),
                                    CantidadDe5 = dr.GetInt32(3),
                                    CantidadDe10 = dr.GetInt32(4),
                                    CantidadDe20 = dr.GetInt32(5),
                                    CierreCaja = dr.GetDecimal(6),
                                    TotalApertura = dr.GetDecimal(7),
                                    FinalDia = dr.GetDecimal(8),
                                    TotalVentaDelDia = dr.GetDecimal(9),
                                    TotalSobrante = dr.GetDecimal(10),
                                    TotalFaltante = dr.GetDecimal(11),
                                    FechaArqueo = dr.GetDateTime(12)
                                };
                            }
                        }
                    }
                }
            }
            return result;
        }

        public bool Update(Arqueo entity)
        {
            bool result = false;
            using (SqlConnection conn = new SqlConnection(_cadena))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ArqueoUpdate", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@ArqueoId", entity.ArqueoId);
                    cmd.Parameters.AddWithValue("@UsuarioId", entity.UsuarioId);
                    cmd.Parameters.AddWithValue("@CantidadDe1", entity.CantidadDe1);
                    cmd.Parameters.AddWithValue("@CantidadDe5", entity.CantidadDe5);
                    cmd.Parameters.AddWithValue("@CantidadDe10", entity.CantidadDe10);
                    cmd.Parameters.AddWithValue("@CantidadDe20", entity.CantidadDe20);
                    cmd.Parameters.AddWithValue("@CierreCaja", entity.CierreCaja);
                    cmd.Parameters.AddWithValue("@TotalApertura", entity.TotalApertura);
                    cmd.Parameters.AddWithValue("@FinalDia", entity.FinalDia);
                    cmd.Parameters.AddWithValue("@TotalVentaDelDia", entity.TotalVentaDelDia);
                    cmd.Parameters.AddWithValue("@TotalSobrante", entity.TotalSobrante);
                    cmd.Parameters.AddWithValue("@TotalFaltante", entity.TotalFaltante);
                    cmd.Parameters.AddWithValue("@FechaArqueo", entity.FechaArqueo);
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
                using (SqlCommand cmd = new SqlCommand("sp_ArqueoDelete", conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@ArqueoId", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    result = cmd.ExecuteNonQuery() > 0;
                }
            }
            return result;
        }
    }
}
