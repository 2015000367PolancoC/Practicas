using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace guia1unidad3
{
    public partial class Encargados : Form
    {
        public Encargados()
        {
            InitializeComponent();
            registros();
        }
        SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=registros;Integrated Security=True");
        private void registros()
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter("select distinct NombreEncargado,ApellidoEncargado,NombreEstudiante,ApellidoEstudiante from inscripciones;", conexion);
                DataSet d = new DataSet();
                comando.Fill(d, "nombre");
                dataGridView1.DataSource = d.Tables["nombre"].DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult x = MessageBox.Show("Continuar? borrara todos los registros de este encargado (junto a su alumno)", "Confirmar", MessageBoxButtons.YesNo);
            if (x == DialogResult.Yes)
            {

            }
            else
            {

            }
        }
    }
}
