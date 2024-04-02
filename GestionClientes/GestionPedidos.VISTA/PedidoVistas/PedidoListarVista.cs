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
    public partial class PedidoListarVista : Form
    {
        public PedidoListarVista()
        {
            InitializeComponent();
        }
        PedidoBss pedidobss = new PedidoBss();
        private void PedidoListarVista_Load(object sender, EventArgs e)
        {
            ActualizarInformacion();
        }
        private void ActualizarInformacion()
        {
            dataGridView1.DataSource = pedidobss.ListarPedidoBss(IdClienteSeleccionado);
            label3.Text = pedidobss.MontoTotalPedidoBss(IdClienteSeleccionado);
        }


        private void button2_Click(object sender, EventArgs e)
        {
            PedidoInsertarVista fr = new PedidoInsertarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                ActualizarInformacion();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int IdPedidoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            PedidoEditarVista fr = new PedidoEditarVista(IdPedidoSeleccionado);
            if (fr.ShowDialog() == DialogResult.OK)
            {
                ActualizarInformacion();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int IdPedidoSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("¿Esta seguro de Eliminar esta Pedido?", "Eliminando....", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                pedidobss.EliminarPedidoBss(IdPedidoSeleccionado);
                ActualizarInformacion();
            }
        }
        ClienteBss bss = new ClienteBss();
        public static int IdClienteSeleccionado = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            ClienteListarVista fr = new ClienteListarVista(1);
            if (fr.ShowDialog() == DialogResult.OK)
            {
                Cliente cliente = bss.ObtenerClienteIdBss(IdClienteSeleccionado);
                textBox1.Text = cliente.Nombre + " " + cliente.Apellido;
                ActualizarInformacion();
            }
        }
    }
}
