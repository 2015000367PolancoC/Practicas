using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Borrador2
{
    public partial class Form2 : Form
    {
        string conexion = "Server=.\\SQLEXPRESS;Database=asistencias_control;Trusted_Connection=True;";
        public Form2()
        {
            InitializeComponent();
            ConfigurarDataGridView();
            CargarAlumnos();
            CargarGrados();

        }
        private void CargarGrados()
        {
            comboBoxGrado.Items.Add("Todos");
            comboBoxGrado.Items.Add("Primero Basico");
            comboBoxGrado.Items.Add("Segundo Basico");
            comboBoxGrado.Items.Add("Tercero Basico");
            comboBoxGrado.Items.Add("Cuarto Bachillerato");
            comboBoxGrado.Items.Add("Quinto Bachillerato");
            comboBoxGrado.SelectedIndex = 0;
        }
        private void ConfigurarDataGridView()
        {
            dataGridView1.Columns.Add("id_alumno", "ID");
            dataGridView1.Columns.Add("nombre", "Nombre");
            dataGridView1.Columns.Add("apellido", "Apellido");
            dataGridView1.Columns.Add("grado", "Grado");

            DataGridViewCheckBoxColumn chk = new DataGridViewCheckBoxColumn();
            chk.HeaderText = "Presente";
            chk.Name = "estado";
            chk.TrueValue = true;
            chk.FalseValue = false;
            dataGridView1.Columns.Add(chk);
        }

        private void CargarAlumnos()
        {
            dataGridView1.Rows.Clear();
            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();
                SqlCommand cmd = new SqlCommand("SELECT id_alumno, nombres_alumno, apellidos_alumno, grado FROM info_alumnos", cn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dataGridView1.Rows.Add(dr["id_alumno"], dr["nombres_alumno"], dr["apellidos_alumno"], dr["grado"], false);
                }
            }
        }


        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void btnConsultas_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns["estado"].ReadOnly = true;

            DateTime fecha = dateTimePicker1.Value.Date;
            dataGridView1.Rows.Clear();

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();

                // Construir la consulta base con filtro por fecha
                string query = "SELECT inf_a.id_alumno, inf_a.nombres_alumno, inf_a.apellidos_alumno, inf_a.grado, asis.estado " +
                               "FROM asistencias asis " +
                               "JOIN info_alumnos inf_a ON asis.id_alumno = inf_a.id_alumno " +
                               "WHERE asis.fecha = @fecha";

                // Agregar filtros adicionales según la selección
                if (rbtnGrado.Checked && comboBoxGrado.SelectedItem != null && comboBoxGrado.SelectedItem.ToString() != "Todos")
                {
                    query += " AND inf_a.grado = @grado";
                }
                else if (rbtnNombre.Checked)
                {
                    // Validar que ambos campos estén completos
                    if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
                    {
                        MessageBox.Show("Debe ingresar tanto el nombre como el apellido para buscar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    query += " AND inf_a.nombres_alumno = @nombre AND inf_a.apellidos_alumno = @apellido";
                }

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@fecha", fecha);

                // Agregar parámetros según los filtros seleccionados
                if (rbtnGrado.Checked && comboBoxGrado.SelectedItem != null && comboBoxGrado.SelectedItem.ToString() != "Todos")
                {
                    cmd.Parameters.AddWithValue("@grado", comboBoxGrado.SelectedItem.ToString());
                }

                if (rbtnNombre.Checked)
                {
                    cmd.Parameters.AddWithValue("@nombre", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@apellido", textBox2.Text.Trim());
                }

                SqlDataReader dr = cmd.ExecuteReader();
                bool encontroRegistros = false;
                while (dr.Read())
                {
                    encontroRegistros = true;
                    bool presente = dr["estado"] != DBNull.Value && (bool)dr["estado"];
                    dataGridView1.Rows.Add(dr["id_alumno"], dr["nombres_alumno"], dr["apellidos_alumno"], dr["grado"], presente);
                }

                // Mostrar mensaje si no se encontraron registros con el filtro de nombre
                if (rbtnNombre.Checked && !encontroRegistros)
                {
                    MessageBox.Show($"No se encontró ningún registro para: {textBox1.Text} {textBox2.Text}", "Búsqueda sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns["estado"].ReadOnly = true;
            dataGridView1.Rows.Clear();

            DateTime fecha = dateTimePicker1.Value.Date;

            using (SqlConnection cn = new SqlConnection(conexion))
            {
                cn.Open();

                // Consulta base (siempre filtra por fecha)
                string query = "SELECT inf_a.id_alumno, inf_a.nombres_alumno, inf_a.apellidos_alumno, inf_a.grado, asis.estado " +
                               "FROM info_alumnos inf_a " +
                               "LEFT JOIN asistencias asis ON asis.id_alumno = inf_a.id_alumno AND asis.fecha = @fecha ";

                // Filtro adicional por grado (solo si el rbtn está activo)
                if (rbtnGrado.Checked && comboBoxGrado.SelectedItem != null)
                {
                    query += "WHERE inf_a.grado = @grado";
                }

                SqlCommand cmd = new SqlCommand(query, cn);
                cmd.Parameters.AddWithValue("@fecha", fecha);

                if (rbtnGrado.Checked && comboBoxGrado.SelectedItem != null)
                {
                    cmd.Parameters.AddWithValue("@grado", comboBoxGrado.SelectedItem.ToString());
                }

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    bool estado;

                    if (dr["estado"] == DBNull.Value)
                        estado = false; // No registrado -> checkbox desmarcado
                    else
                        estado = (bool)dr["estado"]; // Si en DB está true/false, se refleja directo

                    dataGridView1.Rows.Add(
                        dr["id_alumno"],
                        dr["nombres_alumno"],
                        dr["apellidos_alumno"],
                        dr["grado"],
                        estado
                    );
                }
            }
            MessageBox.Show("Asistencias guardadas correctamente");
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {

        }

        private void rbtnNombre_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void rbtnFecha_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
