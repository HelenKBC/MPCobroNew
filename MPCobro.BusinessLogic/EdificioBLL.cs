using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPCobro.Entities;
using MPCobro.DataAccessLogic;
 
namespace MPCobro.BusinessLogic
{
    public class EdificioBLL
    {
        
        private static EdificioBLL _instance;
        public static EdificioBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EdificioBLL();

                return _instance;
            }
        }

        public List<Edificio> SelectAll()
        {
            List<Edificio> result = null;

            try
            {
                result = EdificioDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Insert(Edificio entity)
        {
            bool result = false;

            try
            {
                result = EdificioDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Edificio entity)
        {
            bool result = false;

            try
            {
                result = EdificioDAL.Instance.Update(entity);
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
                result = EdificioDAL.Instance.Delete(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
