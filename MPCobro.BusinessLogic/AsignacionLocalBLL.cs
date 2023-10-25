using MPCobro.DataAccessLogic;
using MPCobro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.BusinessLogic
{
    public class AsignacionLocalBLL
    {
        private static AsignacionLocalBLL _instance;
        public static AsignacionLocalBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new AsignacionLocalBLL();

                return _instance;
            }
        }

        public List<AsignacionLocal> SelectAll()
        {
            List<AsignacionLocal> result = null;

            try
            {
                result = AsignacionLocalDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Insert(AsignacionLocal entity)
        {
            bool result = false;

            try
            {
                result = AsignacionLocalDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(AsignacionLocal entity)
        {
            bool result = false;

            try
            {
                result = AsignacionLocalDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
    
