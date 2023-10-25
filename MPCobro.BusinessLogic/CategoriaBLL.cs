using MPCobro.DataAccessLogic;
using MPCobro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.BusinessLogic
{
    public class CategoriaBLL
    {
        private static CategoriaBLL _instance;
        public static CategoriaBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CategoriaBLL();

                return _instance;
            }
        }

        public List<Categoria> SelectAll()
        {
            List<Categoria> result = null;

            try
            {
                result = CategoriaDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Insert(Categoria entity)
        {
            bool result = false;

            try
            {
                result = CategoriaDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Categoria entity)
        {
            bool result = false;

            try
            {
                result = CategoriaDAL.Instance.Update(entity);
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
                result = CategoriaDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}

    

