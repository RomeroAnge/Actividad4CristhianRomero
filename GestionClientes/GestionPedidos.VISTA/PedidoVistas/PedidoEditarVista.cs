using GestionPedidos.BSS;
using GestionPedidos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GestionPedidos.VISTA.PedidoVistas
{
    public partial class PedidoEditarVista : Form
    {
        int idx = 0;
        Pedido p = new Pedido();
        PedidoBss bss = new PedidoBss();
        public PedidoEditarVista(int id)
        {
            idx = id;
            InitializeComponent();
        }
        private void PedidoEditarVista_Load(object sender, EventArgs e)
        {
            p = bss.ObtenerPedidoIdBss(idx);
            dateTimePicker1.Value = p.Fecha;
            textBox2.Text = p.Total.ToString();
            textBox1.Text = p.Estado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            p.Fecha = dateTimePicker1.Value;
            p.Total= Convert.ToDecimal(textBox2.Text);
            p.Estado = textBox1.Text;
            bss.EditarPedidoBss(p);
            MessageBox.Show("Datos Actualizados");
        }
    }
}
