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
        private Asistencias asistenciasForm;

        public Alumnos(Asistencias asistencias)
        {
            InitializeComponent();
            asistenciasForm = asistencias;
            registros();
        }
        private void registros()
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter("select id_alumno as 'Codigo',nombres_alumno AS 'Nombre',apellidos_alumno AS 'Apellido',grado AS 'Grado' from info_alumnos\r\nORDER BY \r\n    CASE \r\n        WHEN grado = 'Primero Basico' THEN 1\r\n        WHEN grado = 'Segundo Basico' THEN 2\r\n        WHEN grado = 'Tercero Basico' THEN 3\r\n        WHEN grado = 'Cuarto Bachillerato' THEN 4\r\n        WHEN grado = 'Quinto Bachillerato' THEN 5\r\n        ELSE 1000\r\n    END asc, apellidos_alumno asc;", conexion);
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
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "")
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
                else
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("INSERT INTO info_alumnos VALUES (@nombres, @apellidos,@grados)", conexion);
                    comando.Parameters.AddWithValue("@nombres", textBox1.Text);
                    comando.Parameters.AddWithValue("@apellidos", textBox2.Text);
                    comando.Parameters.AddWithValue("@grados", comboBox1.Text);

                    comando.ExecuteNonQuery();
                    MessageBox.Show("Agregado exitosamente");
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
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
                else
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("UPDATE info_alumnos set nombres_alumno = @nombres_alumno,apellidos_alumno = @apellidos_alumno,grado = @grado WHERE id_alumno = @id", conexion);
                    comando.Parameters.AddWithValue("@nombres_alumno", textBox1.Text);
                    comando.Parameters.AddWithValue("@apellidos_alumno", textBox2.Text);
                    comando.Parameters.AddWithValue("@grado", comboBox1.Text);
                    comando.Parameters.AddWithValue("@id", textBox4.Text);
                    comando.ExecuteNonQuery();
                    MessageBox.Show("Actualizado exitosamente");
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
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox4.Text == "")
                {
                    MessageBox.Show("Por favor, ingresar el codigo.");
                }
                else
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("DELETE FROM info_alumnos WHERE id_alumno =" + textBox4.Text, conexion);
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
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }
        private void Alumnos_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (asistenciasForm != null)
            {
                asistenciasForm.eliminarcolumna();
                asistenciasForm.agregarcolumna();
            }
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter("select id_alumno as 'Codigo',nombres_alumno AS 'Nombre',apellidos_alumno AS 'Apellido',grado AS 'Grado' from info_alumnos where grado = '"+comboBox2.SelectedItem.ToString()+"'\r\nORDER BY \r\n    CASE \r\n        WHEN grado = 'Primero Basico' THEN 1\r\n        WHEN grado = 'Segundo Basico' THEN 2\r\n        WHEN grado = 'Tercero Basico' THEN 3\r\n        WHEN grado = 'Cuarto Bachillerato' THEN 4\r\n        WHEN grado = 'Quinto Bachillerato' THEN 5\r\n        ELSE 1000\r\n    END asc, apellidos_alumno asc;", conexion);
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
        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            registros();
            comboBox2.SelectedIndex = 0; // Deseleccionar cualquier selección en el ComboBox
        }
    }
}
