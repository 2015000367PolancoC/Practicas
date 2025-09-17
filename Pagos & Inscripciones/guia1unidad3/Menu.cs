using Borrador3;
using System;
using System.Windows.Forms;
namespace guia1unidad3
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Inscripciones v = new Inscripciones();
            v.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            cp v = new cp();
            v.ShowDialog();
        }
        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alumnos v = new Alumnos();
            v.ShowDialog();
        }
        private void encargadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Encargados v = new Encargados();
            v.ShowDialog();
        }
    }
}