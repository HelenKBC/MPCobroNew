using MPCobro.DataAccessLogic;
using MPCobro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.BusinessLogic
{
    public class ArqueoBLL
    {
        private static ArqueoBLL _instance;

        public static ArqueoBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ArqueoBLL();

                return _instance;
            }
        }

        public List<Arqueo> SelectAll()
        {
            List<Arqueo> result = null;

            try
            {
                result = ArqueoDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Insert(Arqueo entity)
        {
            bool result = false;

            try
            {
                result = ArqueoDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Arqueo entity)
        {
            bool result = false;

            try
            {
                result = ArqueoDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Delete(int arqueoId)
        {
            bool result = false;

            try
            {
                result = ArqueoDAL.Instance.Delete(arqueoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public Arqueo SelectById(int arqueoId)
        {
            Arqueo result = null;

            try
            {
                result = ArqueoDAL.Instance.SelectById(arqueoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}