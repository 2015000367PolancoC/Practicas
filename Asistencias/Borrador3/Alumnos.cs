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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Borrador3
{
    public partial class Alumnos : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=asistencias_control;Integrated Security=True");
        public Alumnos()
        {
            InitializeComponent();
            registros();
        }
        private void registros()
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter("select id_alumno as 'Codigo',nombres_alumno as 'Nombre',apellidos_alumno as 'Apellido',grado as 'Grado' from info_alumnos;", conexion);
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
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                
            }
        }
    }
}
