using MPCobro.DataAccessLogic;
using MPCobro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.BusinessLogic
{
    public class EmpleadoBLL
    {
        private static EmpleadoBLL _instance;

        public static EmpleadoBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new EmpleadoBLL();

                return _instance;
            }
        }

        public List<Empleado> SelectAll()
        {
            List<Empleado> result = null;

            try
            {
                result = EmpleadoDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Insert(Empleado entity)
        {
            bool result = false;

            try
            {
                result = EmpleadoDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Empleado entity)
        {
            bool result = false;

            try
            {
                if (VerificarEmpleado(entity.DUI))
                {
                    result = EmpleadoDAL.Instance.Update(entity);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        private bool VerificarEmpleado(string dui)
        {
            bool result = false;
            try
            {
                var query = EmpleadoDAL.Instance.SelectAll()
                    .Where(x => x.DUI.ToLower().Equals(dui.ToLower())).ToList();
                result = query.Count > 0;
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }

        public bool Delete(int empleadoId)
        {
            bool result = false;

            try
            {
                result = EmpleadoDAL.Instance.Delete(empleadoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public Empleado SelectById(int empleadoId)
        {
            Empleado result = null;

            try
            {
                result = EmpleadoDAL.Instance.SelectById(empleadoId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}
