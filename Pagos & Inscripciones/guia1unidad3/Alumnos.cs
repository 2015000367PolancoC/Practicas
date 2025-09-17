using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Borrador3
{
    public partial class Alumnos : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=registros;Integrated Security=True");

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
                SqlDataAdapter comando = new SqlDataAdapter("select NombreEstudiante AS 'Nombre del Estudiante', ApellidoEstudiante AS 'Apellido del Estudiante',Grado,fechaNacimiento as 'Fecha de Nacimiento',direccion as 'Dirección' from alumno", conexion);
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
                    SqlCommand comando = new SqlCommand("INSERT INTO Alumnos VALUES (@nombre, @apellido,@grado,@direccion)", conexion);
                    comando.Parameters.AddWithValue("@nombres", textBox1.Text);
                    comando.Parameters.AddWithValue("@apellidos", textBox2.Text);
                    comando.Parameters.AddWithValue("@grados", comboBox1.Text);
                    comando.Parameters.AddWithValue("@direccion", textBox3.Text);

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
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                dateTimePicker1.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[3].Value;

            }
        }
        private void Alumnos_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Alumnos_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter("select NombreEstudiante AS 'Nombre del Estudiante', ApellidoEstudiante AS 'Apellido del Estudiante',Grado,Direccion as 'Dirección' from alumno where grado = '" + comboBox2.SelectedItem.ToString() + "' ORDER BY ApellidoEstudiante asc;", conexion);
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

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}


/* Y un sabio dijo:
 *                  foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
    {
        // Solo cambia celdas que no estén en modo de encabezado y que sean editables
        if (!cell.ReadOnly)
        {
            cell.Value = "OK";
        }
    } */