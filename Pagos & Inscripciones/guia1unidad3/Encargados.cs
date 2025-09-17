using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Borrador3
{
    public partial class Encargados : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=registros;Integrated Security=True");

        public Encargados()
        {
            InitializeComponent();
            registros();
        }
        private void registros()
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter("select NombreCompletoE1 AS 'Nombre completo Encargado 1',NombreCompletoE2 AS 'Nombre completo Encargado 2',telefonoE1 AS 'Telefono 1',telefonoE2 AS 'Telefono 2', a.NombreEstudiante + ' ' + a.ApellidoEstudiante AS 'Nombre estudiante' FROM encargado e\r\ninner join alumno a ON a.id = e.idalumno;", conexion);
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
                if (textBox1.Text == "" || textBox2.Text == "")
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
                else
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("INSERT INTO info_Encargados VALUES (@nombres, @apellidos,@grados)", conexion);
                    comando.Parameters.AddWithValue("@nombres", textBox1.Text);
                    comando.Parameters.AddWithValue("@apellidos", textBox2.Text);

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
                if (textBox1.Text == "" || textBox2.Text == "" | textBox4.Text == "")
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
                else
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("UPDATE info_Encargados set nombres_alumno = @nombres_alumno,apellidos_alumno = @apellidos_alumno,grado = @grado WHERE id_alumno = @id", conexion);
                    comando.Parameters.AddWithValue("@nombres_alumno", textBox1.Text);
                    comando.Parameters.AddWithValue("@apellidos_alumno", textBox2.Text);
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
                    SqlCommand comando = new SqlCommand("DELETE FROM info_Encargados WHERE id_alumno =" + textBox4.Text, conexion);
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
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
        }
        private void Encargados_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void Encargados_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter("", conexion);
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
        }
    }
}
