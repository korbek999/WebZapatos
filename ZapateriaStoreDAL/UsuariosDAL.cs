using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ZapateriaStoreDAL
{
   public class UsuariosDAL
    {
        public DataSet LoginUsuario(string nomuser,string pass)
        {
            List<usuarios> list = new List<usuarios>();
            DataTable dt = new DataTable();
            dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("UsuarioNombre", typeof(string));


            ZapateriaEntities context = new ZapateriaEntities();
            list = (from user in context.usuarios where user.usuario == nomuser && user.contrasenna == pass select user).ToList();

            foreach (usuarios items in list)
            {
                DataRow row = dt.NewRow();
                row["Usuario"] = items.usuario;
                row["Password"] = items.contrasenna;
                row["UsuarioNombre"] = items.nombre_usuario;

                dt.Rows.Add(row);
            }
            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
        public DataSet ReadAllUsuarios()
        {
            List<usuarios> list = new List<usuarios>();
            DataTable dt = new DataTable();
            dt.Columns.Add("Usuario", typeof(string));
            dt.Columns.Add("Password", typeof(string));
            dt.Columns.Add("UsuarioNombre", typeof(string));


            ZapateriaEntities context = new ZapateriaEntities();
            list = (from usuarios in context.usuarios select usuarios).ToList();


            foreach (usuarios items in list)
            {
                DataRow row = dt.NewRow();
                row["Usuario"] = items.usuario;
                row["Password"] = items.contrasenna;
                row["UsuarioNombre"] = items.nombre_usuario;

                dt.Rows.Add(row);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        public bool Crear(string idUsuario, string pass, string Nombre)
        {
            bool transaction = false;
            try
            {
                ZapateriaEntities context = new ZapateriaEntities();
                usuarios objprod = new usuarios();
                objprod.usuario = idUsuario;
                objprod.contrasenna = pass;
                objprod.nombre_usuario = Nombre;
                context.usuarios.Add(objprod);
                context.SaveChanges();
                transaction = true;
            }
            catch (Exception ex)
            {
                transaction = false;
                Console.WriteLine(ex);
            }
            return transaction;
        }
        public bool Editar(string idUsuario, string pass, string Nombre)
        {
            bool transaction = false;
            try
            {
                ZapateriaEntities context = new ZapateriaEntities();
                usuarios objPro = context.usuarios.Single(usua => usua.usuario == idUsuario);
                objPro.contrasenna = pass;
                objPro.nombre_usuario = Nombre;
                context.SaveChanges();
                transaction = true;
            }
            catch (Exception ex)
            {
                transaction = false;
                Console.WriteLine(ex);
            }
            return transaction;
        }
        public bool Eliminar(string idUsuario)
        {
            bool transaction = false;
            try
            {
                ZapateriaEntities context = new ZapateriaEntities();
                var deleteOrderDetails =
                from details in context.usuarios
                where details.usuario == idUsuario
                select details;

                foreach (var detail in deleteOrderDetails)
                {
                    context.usuarios.Remove(detail);
                }
                context.SaveChanges();
                transaction = true;
            }
            catch (Exception ex)
            {
                transaction = false;
                Console.WriteLine(ex);
            }
            return transaction;
        }
    }

}
