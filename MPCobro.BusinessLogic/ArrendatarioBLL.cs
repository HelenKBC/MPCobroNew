using MPCobro.DataAccessLogic;
using MPCobro.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MPCobro.BusinessLogic
{
    public class ArrendatarioBLL
    {
        private static ArrendatarioBLL _instance;

        public static ArrendatarioBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ArrendatarioBLL();
                return _instance;
            }
        }

        public List<Arrendatario> SelectAll()
        {
            List<Arrendatario> result = null;
            try
            {
                result = ArrendatarioDAL.Instance.SelectAll();
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


        public Arrendatario SelectById(int id)
        {
            Arrendatario result = null;
            try
            {
                result = ArrendatarioDAL.Instance.SelectById(id);
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

        public bool Insert(Arrendatario entity)
        {
            bool result = false;
            try
            {
                if (!VerificarArrendatario(entity.Nombre))
                    result = ArrendatarioDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Arrendatario entity)
        {
            bool result = false;
            try
            {
                if (!VerificarArrendatario(entity.Nombre))
                    result = ArrendatarioDAL.Instance.Update(entity);
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
                result = ArrendatarioDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool VerificarArrendatario(string criteria)
        {
            bool result = false;
            try
            {
                var query = ArrendatarioDAL.Instance.SelectAll()
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
