using MPCobro.DataAccessLogic;
using MPCobro.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.BusinessLogic
{
    public class EstadoBLL
    {
        private static EstadoBLL _instance;

        public static EstadoBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EstadoBLL();
                return _instance;
            }
        }

        public List<Estado> SelectAll()
        {
            List<Estado> result = null;
            try
            {
                result = EstadoDAL.Instance.SelectAll();
            }
            catch (SqlException ex)
            {
                //Que hacer
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return result;
        }


        public Estado SelectById(int id)
        {
            Estado result = null;
            try
            {
                result = EstadoDAL.Instance.SelectById(id);
            }
            catch (SqlException ex)
            {
                //Que hacer
                throw new Exception(ex.Message);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

            return result;
        }

        public bool Insert(Estado entity)
        {
            bool result = false;
            try
            {
                if (!VerificarEstado(entity.Nombre))
                    result = EstadoDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Estado entity)
        {
            bool result = false;
            try
            {
                if (!VerificarEstado(entity.Nombre))
                    result = EstadoDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Delete(int id)
        {
            bool result = false;
            try
            {
                result = EstadoDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool VerificarEstado(string criteria)
        {
            bool result = false;
            try
            {
                var query = EstadoDAL.Instance.SelectAll()
                    .Where(x => x.Nombre.ToLower().Equals(criteria.ToLower())).ToList();

                result = query.Count > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
    }
}
