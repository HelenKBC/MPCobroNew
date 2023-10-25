using MPCobro.DataAccessLogic;
using MPCobro.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPCobro.BusinessLogic
{
    public class UsuarioBLL
    {
        private static UsuarioBLL _instance;

        public static UsuarioBLL Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new UsuarioBLL();

                return _instance;
            }
        }

        public List<Usuario> SelectAll()
        {
            List<Usuario> result = null;

            try
            {
                result = UsuarioDAL.Instance.SelectAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Insert(Usuario entity)
        {
            bool result = false;

            try
            {
                result = UsuarioDAL.Instance.Insert(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Update(Usuario entity)
        {
            bool result = false;

            try
            {
                result = UsuarioDAL.Instance.Update(entity);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public bool Delete(int usuarioId)
        {
            bool result = false;

            try
            {
                result = UsuarioDAL.Instance.Delete(usuarioId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }

        public Usuario SelectById(int usuarioId)
        {
            Usuario result = null;

            try
            {
                result = UsuarioDAL.Instance.SelectById(usuarioId);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return result;
        }
    }
}