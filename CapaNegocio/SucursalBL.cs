using CapaDatos;
using CapaEntidad;

namespace CapaNegocio
{
    public class SucursalBL
    {   
        public List<SucursalCLS> listarSucursal()
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.listarSucursales();
        }

        public List<SucursalCLS> recuperarSucursal(int idSucursal)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.recuperarSucursal(idSucursal);
        }

        public List<SucursalCLS> filtrarSucursal(string nombre)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.filtrarSucursal(nombre);
        }


    }
}
