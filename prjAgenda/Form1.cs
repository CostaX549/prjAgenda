using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjAgenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cadastrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cadastro cadastroForm = new cadastro();
            cadastroForm.ShowDialog();

        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            buscar buscarForm = new buscar();
            buscarForm.ShowDialog();
        }

        private void alterarToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Alterar_Contato alterarForm =  new Alterar_Contato();
            alterarForm.ShowDialog();
        }
    }
}
