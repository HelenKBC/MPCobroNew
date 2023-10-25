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
    public class RolBLL
    {
        private static RolBLL _instance;
        public static RolBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new RolBLL();

                return _instance;
            }
        }

        public List<Rol> SelectAll()
        {
            List<Rol> result = null;
            try
            {
                result = RolDAL.Instance.SelectAll();
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


        public Rol SelectById(int id)
        {
            Rol result = null;
            try
            {
                result = RolDAL.Instance.SelectById(id);
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

        public bool Insert(Rol entity)
        {
            bool result = false;
            try
            {
                if (!VerificarRol(entity.Nombre))
                    result = RolDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Rol entity)
        {
            bool result = false;
            try
            {
                if (!VerificarRol(entity.Nombre))
                    result = RolDAL.Instance.Update(entity);
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
                result = RolDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool VerificarRol(string criteria)
        {
            bool result = false;
            try
            {
                var query = RolDAL.Instance.SelectAll()
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
