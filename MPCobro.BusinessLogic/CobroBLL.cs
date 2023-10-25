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
    }
}
