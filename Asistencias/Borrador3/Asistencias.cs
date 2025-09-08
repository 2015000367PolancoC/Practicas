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

namespace Borrador3
{
    public partial class Asistencias : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=asistencias_control;Integrated Security=True");
        public Asistencias()
        {
            InitializeComponent();
            registros();
        }
        DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
        private void registros()
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter("select nombres_alumno as 'Nombre',apellidos_alumno as 'Apellido',grado as 'Grado' from info_alumnos;", conexion);
                DataSet d = new DataSet();
                comando.Fill(d, "nombre");
                dataGridView1.DataSource = d.Tables["nombre"].DefaultView;

                chk.HeaderText = "Presente";
                chk.Name = "estado";
                chk.TrueValue = true;
                chk.FalseValue = false;

                dataGridView1.Columns.Add(chk);
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
        private void limpiarfiltros()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = 0;
            dataGridView1.ReadOnly = false;
            button3.Enabled = true;
            button4.Enabled = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }
        private void administrarAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Alumnos v = new Alumnos();
            v.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //TODO: Revisar por que la mera verdad no revise nada
            if (radioButton2.Checked && comboBox1.SelectedIndex > 0)
            {
                try 
                {
                    dataGridView1.Columns.Remove("estado");
                    conexion.Open();
                    SqlDataAdapter comando = new SqlDataAdapter("select a.nombres_alumno as 'Nombre',a.apellidos_alumno as 'Apellido', a.grado as 'Grado', s.fecha as 'Fecha',s.estado as 'Presente' from info_alumnos a inner join asistencias s on a.id_alumno = s.id_alumno where grado='" + comboBox1.SelectedItem.ToString()+"';", conexion);
                    DataSet d = new DataSet();
                    comando.Fill(d, "nombre");
                    dataGridView1.DataSource = d.Tables["nombre"].DefaultView;
                    dataGridView1.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
                }
                finally
                {
                    conexion.Close();
                    button3.Enabled = false;
                    button4.Enabled = true;
                }
            }
            else if(radioButton1.Checked && textBox1.Text != "" && textBox2.Text != null)
            {
                try
                {
                    dataGridView1.Columns.Remove("estado");
                    conexion.Open();
                    SqlDataAdapter comando = new SqlDataAdapter("select a.nombres_alumno as 'Nombre',a.apellidos_alumno as 'Apellido', a.grado as 'Grado', s.fecha as 'Fecha',s.estado as 'Presente' from info_alumnos a inner join asistencias s on a.id_alumno = s.id_alumno where nombres_alumno='" + textBox1.Text + "' and apellidos_alumno='" + textBox2.Text + "';", conexion);
                    DataSet d = new DataSet();
                    comando.Fill(d, "nombre");
                    dataGridView1.DataSource = d.Tables["nombre"].DefaultView;
                    dataGridView1.ReadOnly = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
                }
                finally
                {
                    conexion.Close();
                    button3.Enabled = false;
                    button4.Enabled = true;
                }

            }
            else
            {
                MessageBox.Show("Seleccione un filtro y llene el campo de busqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.Columns.Remove("estado");
                limpiarfiltros();
                registros();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            registros();
            limpiarfiltros();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    // Evita la fila nueva vacía
                    if (row.IsNewRow) continue;

                    string nombre = row.Cells["Nombre"].Value?.ToString();
                    string apellido = row.Cells["Apellido"].Value?.ToString();
                    string grado = row.Cells["Grado"].Value?.ToString();
                    bool presente = Convert.ToBoolean(row.Cells["estado"].Value);

                    // Buscar el id_alumno
                    int idAlumno = -1;
                    using (SqlCommand cmd = new SqlCommand("SELECT id_alumno FROM info_alumnos WHERE nombres_alumno=@nombre AND apellidos_alumno=@apellido AND grado=@grado", conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@grado", grado);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                            idAlumno = Convert.ToInt32(result);
                    }

                    if (idAlumno != -1)
                    {
                        // Insertar asistencia
                        using (SqlCommand cmd = new SqlCommand("INSERT INTO asistencias (id_alumno, fecha, estado) VALUES (@id, @fecha, @estado)", conexion))
                        {
                            cmd.Parameters.AddWithValue("@id", idAlumno);
                            cmd.Parameters.AddWithValue("@fecha", dateTimePicker2.Value);
                            cmd.Parameters.AddWithValue("@estado", presente);
                            cmd.ExecuteNonQuery();
                        }
                    }
                }
                MessageBox.Show("Asistencias registradas correctamente.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al registrar asistencias: " + ex.Message);
            }
            finally
            {
                conexion.Close();
            }
        }
    }
}
