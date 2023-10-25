using MPCobro.DataAccessLogic;
using MPCobro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.BusinessLogic
{
    public class LocalesBLL
    {
        private static LocalesBLL _instance;
        public static LocalesBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new LocalesBLL();

                return _instance;
            }
        }

        public List<Locales> SelectAll()
        {
            List<Locales> result = null;

            try
            {
                result = LocalesDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Insert(Locales entity)
        {
            bool result = false;

            try
            {
                result = LocalesDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Locales entity)
        {
            bool result = false;

            try
            {
                result = LocalesDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}

    

