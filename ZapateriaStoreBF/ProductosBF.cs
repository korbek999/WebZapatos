using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ZapateriaStoreDAL;
namespace ZapateriaStoreBF
{
    public class ProductosBF
    {
        public DataSet BuscarProductosBF(int codigo)
        {
            DataSet ds = new DataSet();
            ZapateriaStoreDAL.ProductosDAL capaDatos = new ZapateriaStoreDAL.ProductosDAL();
            ds = capaDatos.BuscarProductos(codigo);
            return ds;
        }

        public DataSet ReadAllBF()
        {
            DataSet ds = new DataSet();
            ZapateriaStoreDAL.ProductosDAL capaDatos = new ZapateriaStoreDAL.ProductosDAL();
            ds = capaDatos.ReadAllProductos();
            return ds;
        }

        public bool CrearBF(int idProducto, string Nombre, string Descripcion, int Precio, string Modificar)
        {
            bool transaction = false;

            ZapateriaStoreDAL.ProductosDAL capaDatos = new ZapateriaStoreDAL.ProductosDAL();
            transaction = capaDatos.Crear( idProducto,  Nombre,  Descripcion,  Precio,  Modificar);
            return transaction;

        }
        public bool EditarBF(int idProducto, string Nombre, string Descripcion, int Precio, string Modificar)
        {
            bool transaction = false;
            ZapateriaStoreDAL.ProductosDAL capaDatos = new ZapateriaStoreDAL.ProductosDAL();
            transaction = capaDatos.Editar(idProducto, Nombre, Descripcion, Precio, Modificar);
            return transaction;
        }

        public bool EliminarBF(int codigo)
        {
            bool transaction = false;

            ZapateriaStoreDAL.ProductosDAL capaDatos = new ZapateriaStoreDAL.ProductosDAL();
            transaction = capaDatos.Eliminar(codigo);
            return transaction;
        }
    }
}
