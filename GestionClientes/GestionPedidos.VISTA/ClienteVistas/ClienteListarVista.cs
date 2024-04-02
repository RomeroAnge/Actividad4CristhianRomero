using GestionPedidos.BSS;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionPedidos.VISTA.ClienteVistas
{
    public partial class ClienteListarVista : Form
    {
        public int NumeroDePantalla;
        public ClienteListarVista(int n)
        {
            NumeroDePantalla = n;
            InitializeComponent();
        }
        ClienteBss clientebss = new ClienteBss();
        private void ClienteListarVista_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = clientebss.ListarClienteBss();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClienteInsertarVista fr = new ClienteInsertarVista();
            if (fr.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = clientebss.ListarClienteBss();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int IdClienteSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            ClienteEditarVista fr = new ClienteEditarVista(IdClienteSeleccionado);
            if (fr.ShowDialog() == DialogResult.OK)
            {
                dataGridView1.DataSource = clientebss.ListarClienteBss();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int IdClienteSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            DialogResult result = MessageBox.Show("¿Esta seguro de Eliminar este Cliente?", "Eliminando.....", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                clientebss.EliminarClienteBss(IdClienteSeleccionado);
                dataGridView1.DataSource = clientebss.ListarClienteBss();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (NumeroDePantalla == 1)
            {
                PedidoVistas.PedidoListarVista.IdClienteSeleccionado = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            else
            {
                PedidoVistas.PedidoInsertarVista.IdCliente = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            }
            
        }
    }
}
