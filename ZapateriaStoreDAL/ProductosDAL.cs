using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ZapateriaStoreDAL
{
    public class ProductosDAL
    {
        public DataSet BuscarProductos(int codigo)
        {
            List<productos> list = new List<productos>();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Precio", typeof(string));
            dt.Columns.Add("Modificacion", typeof(string));

            ZapateriaEntities context = new ZapateriaEntities();
            list = (from productos in context.productos where productos.id == codigo select productos).ToList();

            foreach (productos items in list)
            {
                DataRow row = dt.NewRow();
                row["id"] = items.id;
                row["Producto"] = items.nombre_producto;
                row["Descripcion"] = items.descripcion;
                row["Precio"] = items.precio;
                row["Modificacion"] = items.ultima_modificacion;
                dt.Rows.Add(row);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }
        public DataSet ReadAllProductos()
        {
            List<productos> list = new List<productos>();
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("Producto", typeof(string));
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Precio", typeof(string));
            dt.Columns.Add("Modificacion", typeof(string));

            ZapateriaEntities context = new ZapateriaEntities();
            list = (from productos in context.productos select productos).ToList();


            foreach (productos items in list)
            {
                DataRow row = dt.NewRow();
                row["id"] = items.id;
                row["Producto"] = items.nombre_producto;
                row["Descripcion"] = items.descripcion;
                row["Precio"] = items.precio;
                row["Modificacion"] = items.ultima_modificacion;
                dt.Rows.Add(row);
            }

            DataSet ds = new DataSet();
            ds.Tables.Add(dt);
            return ds;
        }

        public bool Crear(int idProducto, string Nombre, string Descripcion, int Precio, string Modificar)
        {
            bool transaction = false;
            try
            {
                ZapateriaEntities context = new ZapateriaEntities();
                productos objprod = new productos();
                objprod.id = idProducto;
                objprod.nombre_producto = Nombre;
                objprod.descripcion = Descripcion;
                objprod.precio = Precio;
                objprod.ultima_modificacion = Modificar;
                context.productos.Add(objprod);
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
        public bool Editar(int idProducto, string Nombre, string Descripcion, int Precio , string Modificar)
        {
            bool transaction = false;
            try
            {
                ZapateriaEntities context = new ZapateriaEntities();
                productos objPro = context.productos.Single(productos => productos.id == idProducto);
                objPro.nombre_producto = Nombre;
                objPro.descripcion = Descripcion;
                objPro.precio = Precio;
                objPro.ultima_modificacion = Modificar;
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

        public bool Eliminar(int codigo)
        {
            bool transaction = false;
            try
            {
                ZapateriaEntities context = new ZapateriaEntities();
                var deleteOrderDetails =
                from details in context.productos
                where details.id == codigo
                select details;

                foreach (var detail in deleteOrderDetails)
                {
                    context.productos.Remove(detail);
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
