using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Borrador4
{
    public partial class Alumnos : Form
    {
        //SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=registros;Integrated Security = true");
        SqlConnection conexion = new SqlConnection("Data Source=192.168.68.51,9898;Initial Catalog=registros;User ID = gary; Password = zY-Oh_vQzPc[FYWf");
        public Alumnos()
        {
            InitializeComponent();
            Registros(registro);
        }
        String registro = "select id AS 'Codigo',Activo,NombreEstudiante AS 'Nombre del Estudiante', ApellidoEstudiante AS 'Apellido del Estudiante',Grado,fechaNacimiento as 'Fecha de Nacimiento',CONCAT(beca,'%') AS '% Beca',direccion as 'Dirección',NombreCompletoE1 AS 'Nombre completo Encargado 1',NombreCompletoE2 AS 'Nombre completo Encargado 2',LEFT(telefonoE1,4) + '-' + RIGHT(telefonoE1,4) AS 'Telefono 1',LEFT(telefonoE2,4) + '-' + RIGHT(telefonoE2,4) AS 'Telefono 2' from alumno";
        private void Registros(String query)
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter(query + " ORDER BY CASE WHEN grado = 'Primero Básico' THEN 1 WHEN grado = 'Segundo Básico' THEN 2 WHEN grado = 'Tercero Básico' THEN 3 WHEN grado = 'Cuarto Bachillerato' THEN 4 WHEN grado = 'Quinto Bachillerato' THEN 5 ELSE 1000 END asc,ApellidoEstudiante asc", conexion);
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
                if (!Int32.TryParse(textBox5.Text, out int x) || x > 100 || x < 0)
                {
                    MessageBox.Show("Beca invalida");
                }
                else
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("INSERT INTO Alumno(NombreEstudiante,ApellidoEstudiante,Grado,Direccion,fechaNacimiento,Activo,bECA,NombreCompletoE1, NombreCompletoE2, telefonoE1,telefonoE2) VALUES (@nombre, @apellido,@grado,@direccion,@fechaNacimiento,@activo,@beca,@papa1,@papa2,@tel1,@tel2);" +
                                                        "INSERT INTO pagos(idalumno) VALUES ((SELECT TOP 1 id FROM alumno ORDER BY id DESC));" +
                                                        "INSERT INTO inscripciones(idEstudiante) VALUES ((SELECT TOP 1 id FROM alumno ORDER BY id DESC))", conexion);
                    comando.Parameters.AddWithValue("@nombre", textBox1.Text);
                    comando.Parameters.AddWithValue("@apellido", textBox2.Text);
                    comando.Parameters.AddWithValue("@grado", comboBox1.Text);
                    comando.Parameters.AddWithValue("@direccion", textBox3.Text);
                    comando.Parameters.AddWithValue("@fechaNacimiento", dateTimePicker1.Value);
                    comando.Parameters.AddWithValue("@activo", checkBox1.Checked);
                    comando.Parameters.AddWithValue("@beca", textBox5.Text);
                    comando.Parameters.AddWithValue("@papa1", textBox9.Text);
                    comando.Parameters.AddWithValue("@papa2", textBox8.Text);
                    comando.Parameters.AddWithValue("@tel1", textBox7.Text);
                    comando.Parameters.AddWithValue("@tel2", textBox6.Text);
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
                Registros(registro);
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
                    SqlCommand comando = new SqlCommand("UPDATE Alumno set NombreEstudiante = @NombreEstudiante,ApellidoEstudiante = @ApellidoEstudiante,Grado = @Grado,Direccion = @Direccion,fechaNacimiento = @fechaNacimiento, Activo = @activo,beca = @beca,NombreCompletoE1 = @papa1,NombreCompletoE2 = @papa2,telefonoE1 = @tel1,telefonoE2 = @tel2 WHERE id = @id", conexion);
                    comando.Parameters.AddWithValue("@NombreEstudiante", textBox1.Text);
                    comando.Parameters.AddWithValue("@ApellidoEstudiante", textBox2.Text);
                    comando.Parameters.AddWithValue("@grado", comboBox1.Text);
                    comando.Parameters.AddWithValue("@direccion", textBox3.Text);
                    comando.Parameters.AddWithValue("@fechaNacimiento", dateTimePicker1.Value);
                    comando.Parameters.AddWithValue("@id", textBox4.Text);
                    comando.Parameters.AddWithValue("@activo", checkBox1.Checked);
                    comando.Parameters.AddWithValue("@beca", textBox5.Text);
                    comando.Parameters.AddWithValue("@papa1", textBox9.Text);
                    comando.Parameters.AddWithValue("@papa2", textBox8.Text);
                    comando.Parameters.AddWithValue("@tel1", textBox7.Text);
                    comando.Parameters.AddWithValue("@tel2", textBox6.Text);
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
                Registros(registro);
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
                Registros(registro);
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
                if (dataGridView1.Rows[e.RowIndex].Cells[5].Value == DBNull.Value || dataGridView1.Rows[e.RowIndex].Cells[5].Value == null)
                {
                    dateTimePicker1.Value = DateTime.Now;
                }
                else
                {
                    dateTimePicker1.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[5].Value;
                }

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
                Registros(registro + " WHERE Grado = '" + comboBox2.SelectedItem.ToString() + "'");
                btnLimpiarFiltro.Enabled = true;
            }
        }
        private void btnLimpiarFiltro_Click(object sender, EventArgs e)
        {
            Registros(registro);
            comboBox2.SelectedIndex = -1;
            btnLimpiarFiltro.Enabled = false;
        }
        private void label6_Click(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            comboBox1.SelectedIndex = -1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Estas seguro? Esto pasara de año siguiente a todos los alumnos, y eliminara a todos los alumnos de Quinto Bachillerato", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                conexion.Open();
                SqlCommand updateCmd1 = new SqlCommand("UPDATE alumno set grado = 'Segundo Básico' WHERE grado = 'Primero Básico';", conexion);
                SqlCommand updateCmd2 = new SqlCommand("UPDATE alumno set grado = 'Tercero Básico' WHERE grado = 'Segundo Básico'", conexion);
                SqlCommand updateCmd3 = new SqlCommand("UPDATE alumno set grado = 'Cuarto Bachillerato' WHERE grado = 'Tercero Básico'", conexion);
                SqlCommand updateCmd4 = new SqlCommand("UPDATE alumno set grado = 'Quinto Bachillerato' WHERE grado = 'Cuarto Bachillerato'", conexion);
                SqlCommand updateCmd5 = new SqlCommand("DELETE FROM alumno WHERE grado = 'Quinto Bachillerato'", conexion);
                updateCmd5.ExecuteNonQuery();
                updateCmd4.ExecuteNonQuery();
                updateCmd3.ExecuteNonQuery();
                updateCmd2.ExecuteNonQuery();
                updateCmd1.ExecuteNonQuery();
                conexion.Close();
                Registros(registro);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Estas seguro? Esto borrara a todos los estudiantes que no esten marcados como activos", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                conexion.Open();
                SqlCommand updateCmd = new SqlCommand("DELETE FROM alumno WHERE Activo = 0 ", conexion);
                updateCmd.ExecuteNonQuery();
                conexion.Close();
                Registros(registro);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Registros(registro + " where NombreEstudiante like '%" + textBox1.Text + "%' ");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Registros(registro);
        }
    }
}