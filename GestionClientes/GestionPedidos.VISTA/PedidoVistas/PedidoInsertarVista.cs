using GestionPedidos.BSS;
using GestionPedidos.Modelos;
using GestionPedidos.VISTA.ClienteVistas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPedidos.VISTA.PedidoVistas
{
    public partial class PedidoInsertarVista : Form
    {
        public PedidoInsertarVista()
        {
            InitializeComponent();
        }

        PedidoBss pedidobss = new PedidoBss();

        private void button1_Click(object sender, EventArgs e)
        {
            Pedido p = new Pedido();
            p.IdCliente= IdCliente;
            p.Fecha = dateTimePicker1.Value;
            p.Total = Convert.ToDecimal(textBox2.Text);
            p.Estado = textBox3.Text;

            pedidobss.InsertarPedidoBss(p);
            MessageBox.Show("Se guardó correctamente a Pedido");
        }
        public static int IdCliente = 0;
        ClienteBss bss = new ClienteBss();
        private void button3_Click(object sender, EventArgs e)
        {
            ClienteListarVista fr = new ClienteListarVista(2);
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Cliente cliente = bss.ObtenerClienteIdBss(IdCliente);
                textBox1.Text = cliente.Nombre + " " + cliente.Apellido;
            }
        }
    }
}
