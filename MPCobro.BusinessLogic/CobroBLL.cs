using MPCobro.DataAccessLogic;
using MPCobro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.BusinessLogic
{
    public class CobroBLL
    {
        private static CobroBLL _instance;
        public static CobroBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new CobroBLL();

                return _instance;
            }
        }

        public List<Cobro> SelectAll()
        {
            List<Cobro> result = null;

            try
            {
                result = CobroDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
        public bool Insert(Cobro entity)
        {
            bool result = false;

            try
            {
                result = CobroDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Cobro entity)
        {
            bool result = false;

            try
            {
                result = CobroDAL.Instance.Update(entity);
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
                result = CobroDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
