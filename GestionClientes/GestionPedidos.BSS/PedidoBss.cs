using GestionPedidos.DAL;
using GestionPedidos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPedidos.BSS
{
    public class PedidoBss
    {
        PedidoDal dal = new PedidoDal();
        public DataTable ListarPedidoBss(int id)
        {
            return dal.ListarPedidoDal(id);
        }
        public string MontoTotalPedidoBss(int id)
        {
            return dal.MontoTotalPedidoDal(id);
        }
        public void InsertarPedidoBss(Pedido pedido)
        {
            dal.InsertarPedidoDal(pedido);
        }
        public Pedido ObtenerPedidoIdBss(int id)
        {
            return dal.ObtenerPedidoIdDal(id);
        }
        public void EditarPedidoBss(Pedido p)
        {
            dal.EditarPedidoDal(p);
        }
        public void EliminarPedidoBss(int id)
        {
            dal.EliminarPedidoDal(id);
        }
    }
}
