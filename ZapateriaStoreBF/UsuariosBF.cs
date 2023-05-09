using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZapateriaStoreDAL;
namespace ZapateriaStoreBF
{
   public class UsuariosBF
    {
        public DataSet LoginUsuarioBF(string user , string pass)
        {
            DataSet ds = new DataSet();
            ZapateriaStoreDAL.UsuariosDAL capaDatos = new ZapateriaStoreDAL.UsuariosDAL();
            ds = capaDatos.LoginUsuario(user,pass);
            return ds;
        }
        public DataSet ReadAllUsuariosBF()
        {
            DataSet ds = new DataSet();
            ZapateriaStoreDAL.UsuariosDAL capaDatos = new ZapateriaStoreDAL.UsuariosDAL();
            ds = capaDatos.ReadAllUsuarios();
            return ds;
        }

        public bool CrearBF(string idUsuario, string pass, string Nombre)
        {
            bool transaction = false;
            ZapateriaStoreDAL.UsuariosDAL capaDatos = new ZapateriaStoreDAL.UsuariosDAL();
            transaction = capaDatos.Crear(idUsuario,pass,Nombre);
            return transaction;
        }
        public bool EditarBF(string idUsuario, string pass, string Nombre)
        {
            bool transaction = false;
            ZapateriaStoreDAL.UsuariosDAL capaDatos = new ZapateriaStoreDAL.UsuariosDAL();
            transaction = capaDatos.Editar(idUsuario, pass, Nombre);
            return transaction;
        }
        public bool EliminarBF(string codigo)
        {
            bool transaction = false;
            ZapateriaStoreDAL.UsuariosDAL capaDatos = new ZapateriaStoreDAL.UsuariosDAL();
            transaction = capaDatos.Eliminar(codigo);
            return transaction;
        }
    }
}
