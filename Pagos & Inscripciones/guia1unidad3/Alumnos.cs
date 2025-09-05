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

namespace guia1unidad3
{
    public partial class Alumnos : Form
    {
        public Alumnos()
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
                SqlDataAdapter comando = new SqlDataAdapter("select distinct NombreEstudiante as 'Nombre del Estudiante',ApellidoEstudiante as 'Apellidos del Estudiante',Grado,Direccion from inscripciones", conexion);
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
        {/*
            DialogResult x = MessageBox.Show("Continuar? borrara todos los registros de este alumno", "Confirmar", MessageBoxButtons.YesNo);
            String nombre1,nombre2,ape1,ape2;
            if (x == DialogResult.Yes)
            {
                try
                {
                   if (nombre1 == null || nombre2 == null || ape1 == null || ape2 == null)
                    {
                        MessageBox.Show("Por favor, ingrese el I}.");
                    }
                    else
                    {
                        conexion.Open();
                        SqlCommand comando = new SqlCommand("delete from inscripciones where id = @ID", conexion);
                        comando.Parameters.AddWithValue("@ID", textBox7.Text);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Eliminado exitosamente");
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
                }
                finally
                {
                    conexion.Close();
                    registros();
                }

            }
            else
            {
                
            } */
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
