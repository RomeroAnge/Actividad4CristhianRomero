using GestionPedidos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPedidos.DAL
{
    public class PedidoDal
    {
        public DataTable ListarPedidoDal(int id)
        {
            string consulta = "select IDPEDIDO, FECHA, TOTAL, ESTADO from pedido where idcliente = " + id;
            DataTable lista = conexion.EjecutarDataTabla(consulta, "tabla");
            return lista;
        }
        public string MontoTotalPedidoDal(int id)
        {
            string consulta = "SELECT    SUM(PEDIDO.TOTAL)[MONTO] " +
                "FROM         PEDIDO " +
                "WHERE IDCLIENTE = "+id;
            DataTable tabla = conexion.EjecutarDataTabla(consulta, "tabla");
            if (tabla.Rows.Count > 0)
            {
                return  tabla.Rows[0]["monto"].ToString();
            }
            else
            {
                return "0";
            }  
        }
        public void InsertarPedidoDal(Pedido pedido)
        {
            string consulta = "insert into pedido values (" + pedido.IdCliente+ ",' "
                                                          + pedido.Fecha + "', "
                                                          + pedido.Total + ",'"
                                                          + pedido.Estado + "')";
            conexion.Ejecutar(consulta);
        }
        Pedido pedido = new Pedido();
        public Pedido ObtenerPedidoIdDal(int id)
        {
            string consulta = "select * from pedido where idpedido=" + id;
            DataTable tabla = conexion.EjecutarDataTabla(consulta, "tabla");
            if (tabla.Rows.Count > 0)
            {
                pedido.IdPedido = Convert.ToInt32(tabla.Rows[0]["idpedido"]);
                pedido.IdCliente = Convert.ToInt32(tabla.Rows[0]["idcliente"]);
                pedido.Fecha = Convert.ToDateTime(tabla.Rows[0]["fecha"]);
                pedido.Total = Convert.ToDecimal(tabla.Rows[0]["total"]);
                pedido.Estado = tabla.Rows[0]["estado"].ToString();
            }
            return pedido;
        }
        public void EditarPedidoDal(Pedido p)
        {
            string consulta = "update pedido set idcliente=" + p.IdCliente + "," +
                                                        "fecha='" + p.Fecha + "'," +
                                                        "total=" + p.Total+ "," +
                                                        "estado='" + p.Estado + "' " +
                                                "where idpedido=" + p.IdPedido;
            conexion.Ejecutar(consulta);
        }
        public void EliminarPedidoDal(int id)
        {
            string consulta = "delete from pedido where idpedido=" + id;
            conexion.Ejecutar(consulta);
        }
    }
}
