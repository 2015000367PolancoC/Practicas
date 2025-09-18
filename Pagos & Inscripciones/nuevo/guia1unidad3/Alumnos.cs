using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Borrador4
{
    public partial class Alumnos : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=registros;Integrated Security=True");
        public Alumnos()
        {
            InitializeComponent();
            Registros();
        }
        String registro = "select id AS 'Codigo',Activo,NombreEstudiante AS 'Nombre del Estudiante', ApellidoEstudiante AS 'Apellido del Estudiante',Grado,fechaNacimiento as 'Fecha de Nacimiento',CONCAT(beca,'%') AS '% Beca',direccion as 'Dirección' from alumno";
        private void Registros()
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter(registro + " ORDER BY CASE WHEN grado = 'Primero Básico' THEN 1 WHEN grado = 'Segundo Básico' THEN 2 WHEN grado = 'Tercero Básico' THEN 3 WHEN grado = 'Cuarto Bachillerato' THEN 4 WHEN grado = 'Quinto Bachillerato' THEN 5 ELSE 1000 END asc", conexion);
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
                    SqlCommand comando = new SqlCommand("INSERT INTO Alumnos(NombreEstudiante,ApellidoEstudiante,Grado,Direccion,fechaNacimiento) VALUES (@nombre, @apellido,@grado,@direccion,@fechaNacimiento)", conexion);
                    comando.Parameters.AddWithValue("@nombres", textBox1.Text);
                    comando.Parameters.AddWithValue("@apellidos", textBox2.Text);
                    comando.Parameters.AddWithValue("@grados", comboBox1.Text);
                    comando.Parameters.AddWithValue("@direccion", textBox3.Text);
                    comando.Parameters.AddWithValue("@fechaNacimiento", dateTimePicker1.Value);

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
                Registros();
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
                    SqlCommand comando = new SqlCommand("UPDATE Alumno set NombreEstudiante = @NombreEstudiante,ApellidoEstudiante = @ApellidoEstudiante,Grado = @Grado,Direccion = @Direccion,fechaNacimiento = @fechaNacimiento, Activo = @activo,beca = @beca WHERE id = @id", conexion);
                    comando.Parameters.AddWithValue("@NombreEstudiante", textBox1.Text);
                    comando.Parameters.AddWithValue("@ApellidoEstudiante", textBox2.Text);
                    comando.Parameters.AddWithValue("@grado", comboBox1.Text);
                    comando.Parameters.AddWithValue("@direccion", textBox3.Text);
                    comando.Parameters.AddWithValue("@fechaNacimiento", dateTimePicker1.Value);
                    comando.Parameters.AddWithValue("@id", textBox4.Text);
                    comando.Parameters.AddWithValue("@activo", checkBox1.Checked);
                    comando.Parameters.AddWithValue("@beca", textBox5.Text);
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
                Registros();
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
                    SqlCommand comando = new SqlCommand("DELETE FROM Alumno WHERE id =" + textBox4.Text, conexion);
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
                Registros();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString().Trim('%');
                checkBox1.Checked = Convert.ToBoolean(dataGridView1.Rows[e.RowIndex].Cells[1].Value);
                //dateTimePicker1.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[4].Value;

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
            if (comboBox2.SelectedIndex >= 0)
            {
                try
                {
                    conexion.Open();
                    SqlDataAdapter comando = new SqlDataAdapter(registro + " where grado = '" + comboBox2.SelectedItem.ToString() + "' ORDER BY CASE WHEN grado = 'Primero Básico' THEN 1 WHEN grado = 'Segundo Básico' THEN 2 WHEN grado = 'Tercero Básico' THEN 3 WHEN grado = 'Cuarto Bachillerato' THEN 4 WHEN grado = 'Quinto Bachillerato' THEN 5 ELSE 1000 END asc;", conexion);
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
                    btnLimpiarFiltro.Enabled = true;
                }
            }
        }
        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            Registros();
            comboBox2.SelectedIndex = -1;
            btnLimpiarFiltro.Enabled = false;
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