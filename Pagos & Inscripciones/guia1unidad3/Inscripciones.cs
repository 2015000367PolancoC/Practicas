using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace guia1unidad3
{
    public partial class Inscripciones : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=registros;Integrated Security=True");
        public Inscripciones()
        {
            InitializeComponent();
            registros();
            pago();
        }
        int grado = 1;

        private void registros()
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter("SELECT id as 'No. de Registro',FechaPago as 'Fecha de Pago',monto as 'Monto Pagado',NombreEstudiante as 'Nombre del Estudiante',ApellidoEstudiante as 'Apellidos del Estudiante',Grado,NombreEncargado as 'Nombre del Encargado',ApellidoEncargado as 'Apellido del Encargado',Direccion FROM inscripciones", conexion);
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

        private void pago()
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "Todos" || comboBox1.Text == "")
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
                else
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("INSERT INTO inscripciones (FechaPago,monto,NombreEstudiante,ApellidoEstudiante,Grado,NombreEncargado,ApellidoEncargado,Direccion) VALUES (@FechaPago,@monto,@NombreEstudiante,@ApellidoEstudiante,@Grado,@NombreEncargado,@ApellidoEncargado,@Direccion)", conexion);
                    comando.Parameters.AddWithValue("@FechaPago", dateTimePicker1.Value);
                    comando.Parameters.AddWithValue("@monto", Convert.ToInt32(textBox3.Text));
                    comando.Parameters.AddWithValue("@NombreEstudiante", textBox1.Text);
                    comando.Parameters.AddWithValue("@ApellidoEstudiante", textBox2.Text);
                    comando.Parameters.AddWithValue("@Grado", comboBox1.Text);
                    comando.Parameters.AddWithValue("@NombreEncargado", textBox4.Text);
                    comando.Parameters.AddWithValue("@ApellidoEncargado", textBox5.Text);
                    comando.Parameters.AddWithValue("@Direccion", textBox6.Text);
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
        private void button1_Click_1(object sender, EventArgs e)
        {


        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "Todos")
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
                else
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("UPDATE inscripciones set FechaPago = @FechaPago,monto = @monto,NombreEstudiante = @NombreEstudiante,ApellidoEstudiante = @ApellidoEstudiante,Grado = @Grado,NombreEncargado = @NombreEncargado,ApellidoEncargado = @ApellidoEncargado,Direccion = @Direccion WHERE ID = @ID", conexion);
                    comando.Parameters.AddWithValue("@FechaPago", dateTimePicker1.Value);
                    comando.Parameters.AddWithValue("@monto", Convert.ToInt32(textBox3.Text));
                    comando.Parameters.AddWithValue("@NombreEstudiante", textBox1.Text);
                    comando.Parameters.AddWithValue("@ApellidoEstudiante", textBox2.Text);
                    comando.Parameters.AddWithValue("@Grado", comboBox1.Text);
                    comando.Parameters.AddWithValue("@NombreEncargado", textBox4.Text);
                    comando.Parameters.AddWithValue("@ApellidoEncargado", textBox5.Text);
                    comando.Parameters.AddWithValue("@Direccion", textBox6.Text);
                    comando.Parameters.AddWithValue("@ID", textBox7.Text);
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

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Value = DateTime.Now;
                dateTimePicker1.Enabled = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            String consulta;
            switch (comboBox1.SelectedIndex)
            {
                case 0: grado = 0; break;
                case 1: grado = 1; break;
                case 2: grado = 2; break;
                case 3: grado = 3; break;
                case 4: grado = 4; break;
                case 5: grado = 5; break;
                default: grado = 1; break;
            }
            switch (grado)
            {
                case 1: consulta = "SELECT id as 'No. de Registro',FechaPago as 'Fecha de Pago',monto as 'Monto Pagado',NombreEstudiante as 'Nombre del Estudiante',ApellidoEstudiante as 'Apellidos del Estudiante',Grado,NombreEncargado as 'Nombre del Encargado',ApellidoEncargado as 'Apellido del Encargado',Direccion FROM inscripciones WHERE Grado = 'Primero Basico';"; break;
                case 2: consulta = "SELECT id as 'No. de Registro',FechaPago as 'Fecha de Pago',monto as 'Monto Pagado',NombreEstudiante as 'Nombre del Estudiante',ApellidoEstudiante as 'Apellidos del Estudiante',Grado,NombreEncargado as 'Nombre del Encargado',ApellidoEncargado as 'Apellido del Encargado',Direccion FROM inscripciones WHERE Grado = 'Segundo Basico';"; break;
                case 3: consulta = "SELECT id as 'No. de Registro',FechaPago as 'Fecha de Pago',monto as 'Monto Pagado',NombreEstudiante as 'Nombre del Estudiante',ApellidoEstudiante as 'Apellidos del Estudiante',Grado,NombreEncargado as 'Nombre del Encargado',ApellidoEncargado as 'Apellido del Encargado',Direccion FROM inscripciones WHERE Grado = 'Tercero Basico';"; break;
                case 4: consulta = "SELECT id as 'No. de Registro',FechaPago as 'Fecha de Pago',monto as 'Monto Pagado',NombreEstudiante as 'Nombre del Estudiante',ApellidoEstudiante as 'Apellidos del Estudiante',Grado,NombreEncargado as 'Nombre del Encargado',ApellidoEncargado as 'Apellido del Encargado',Direccion FROM inscripciones WHERE Grado = 'Cuarto Bachillerato';"; break;
                case 5: consulta = "SELECT id as 'No. de Registro',FechaPago as 'Fecha de Pago',monto as 'Monto Pagado',NombreEstudiante as 'Nombre del Estudiante',ApellidoEstudiante as 'Apellidos del Estudiante',Grado,NombreEncargado as 'Nombre del Encargado',ApellidoEncargado as 'Apellido del Encargado',Direccion FROM inscripciones WHERE Grado = 'Quinto Bachillerato';"; break;
                default: consulta = "SELECT id as 'No. de Registro',FechaPago as 'Fecha de Pago',monto as 'Monto Pagado',NombreEstudiante as 'Nombre del Estudiante',ApellidoEstudiante as 'Apellidos del Estudiante',Grado,NombreEncargado as 'Nombre del Encargado',ApellidoEncargado as 'Apellido del Encargado',Direccion FROM inscripciones;"; break;
            }

            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter(consulta, conexion);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // MessageBox.Show(dataGridView1.Rows[e.RowIndex].ToString() + dataGridView1.Columns[e.ColumnIndex].ToString());
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0) {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                textBox6.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                textBox7.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                dateTimePicker1.Value = (DateTime)dataGridView1.Rows[e.RowIndex].Cells[1].Value;
                comboBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            }
        }

        private void Inscripciones_Load(object sender, EventArgs e)
        {

        }
    }
}

//id as 'No. de Registro',FechaPago as 'Fecha de Pago',monto as 'Monto Pagado',NombreEstudiante as 'Nombre del Estudiante',ApellidoEstudiante as 'Apellidos del Estudiante',Grado,NombreEncargado as 'Nombre del Encargado',ApellidoEncargado as 'Apellido del Encargado',Direccion