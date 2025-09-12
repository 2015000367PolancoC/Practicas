using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
namespace Borrador3
{
    public partial class Asistencias : Form
    {
        //Cambiar a la ip de Beatriz (o configurar el server de la miss a esta ip y puerto)
        String consultafiltro = "SELECT a.nombres_alumno AS 'Nombre',a.apellidos_alumno AS 'Apellido', a.grado AS 'Grado', s.fecha AS 'Fecha',s.estado AS 'Presente' from info_alumnos a INNER JOIN asistencias s ON a.id_alumno = s.id_alumno ";
        int count;
        SqlConnection conexion = new SqlConnection("Data Source=192.168.0.37,49172;Initial Catalog=asistencias_control;User ID = dario2;Password = admin");
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
                SqlDataAdapter comando = new SqlDataAdapter
                    (
                        "SELECT nombres_alumno AS 'Nombre',apellidos_alumno AS 'Apellido',grado AS 'Grado' from info_alumnos\r\n" +
                        "ORDER BY \r\n" +
                        "    CASE \r\n" +
                        "        WHEN grado = 'Primero Básico' THEN 1\r\n" +
                        "        WHEN grado = 'Segundo Básico' THEN 2\r\n" +
                        "        WHEN grado = 'Tercero Básico' THEN 3\r\n" +
                        "        WHEN grado = 'Cuarto Bachillerato' THEN 4\r\n" +
                        "        WHEN grado = 'Quinto Bachillerato' THEN 5\r\n" +
                        "        ELSE 1000\r\n" +
                        "    END asc, apellidos_alumno asc;"
                    ,conexion);
                DataSet dt = new DataSet();
                comando.Fill(dt, "nombre");
                dataGridView1.DataSource = dt.Tables["nombre"].DefaultView;
                
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
        public void eliminarcolumna()
        {
            // :(
            dataGridView1.Columns.Remove("estado");
        }
        public void agregarcolumna()
        {
            chk.HeaderText = "Presente";
            chk.Name = "estado";
            chk.TrueValue = true;
            chk.FalseValue = false;
            dataGridView1.Columns.Add(chk);
        }
        private void limpiarfiltros()
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.SelectedIndex = 0;
            dataGridView1.ReadOnly = false;
            btnVerReg.Enabled = true;
            btnLimpiarReg.Enabled = false;
            dateTimePicker1.Value = DateTime.Now;
        }
        private void limpiarregistros()
        {
            textBox3.Clear();
            textBox4.Clear();
            comboBox2.SelectedIndex = 0;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        { 
            agregarcolumna();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }
        private void ExportSqlTableToExcel(string filePath)
        { //Creditos a so
            SqlDataAdapter da = new SqlDataAdapter(consultafiltro +
                        "ORDER BY fecha asc,\r\n" +
                        "    CASE \r\n" +
                        "        WHEN grado = 'Primero Básico' THEN 1\r\n" +
                        "        WHEN grado = 'Segundo Básico' THEN 2\r\n" +
                        "        WHEN grado = 'Tercero Básico' THEN 3\r\n" +
                        "        WHEN grado = 'Cuarto Bachillerato' THEN 4\r\n" +
                        "        WHEN grado = 'Quinto Bachillerato' THEN 5\r\n" +
                        "        ELSE 1000\r\n" +
                        "    END asc, apellidos_alumno asc;", conexion);
            DataTable dt = new DataTable();
            da.Fill(dt);
            using (var package = new ExcelPackage(new System.IO.FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets.FirstOrDefault();

                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cells[1, i + 1].Value = dt.Columns[i].ColumnName;
                }
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    for (int y = 0; y < dt.Columns.Count; y++)
                    {
                        worksheet.Cells[x + 2, y + 1].Value = dt.Rows[x][y];
                    }
                }
                try
                {
                    package.Save();
                    MessageBox.Show("Archivo guardado exitosamente");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al guardar el archivo: " + ex.Message);
                }
            }
        }
        private void administrarAlumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiarfiltros();
            registros();
            eliminarcolumna();
            agregarcolumna();
            Alumnos v = new Alumnos(this);
            v.FormClosed += (s, args) => registros();
            v.Show();
        }
        private void filtrar(String query)
        {
            try
            {
                eliminarcolumna();
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter(query +"CASE         WHEN grado = 'Primero Básico' THEN 1        WHEN grado = 'Segundo Básico' THEN 2        WHEN grado = 'Tercero Básico' THEN 3        WHEN grado = 'Cuarto Bachillerato' THEN 4        WHEN grado = 'Quinto Bachillerato' THEN 5        ELSE 1000    END asc, apellidos_alumno asc", conexion);
                DataSet dt = new DataSet();
                comando.Fill(dt, "nombre");
                dataGridView1.DataSource = dt.Tables["nombre"].DefaultView;
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
        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    if (!checkBox1.Checked)
                    {
                        filtrar(consultafiltro + "where fecha ='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "' ORDER BY fecha asc,");
                        dataGridView1.ReadOnly = true;
                        btnVerReg.Enabled = false;
                        btnLimpiarReg.Enabled = true;
                        //Workaround por que crashea si se abre mientras haya un filtro activo
                        btnAlumnos.Enabled = false;
                        radioButton3.Enabled = false;
                        radioButton4.Enabled = false;
                        btnLimpiarFiltro.Enabled = false;
                        btnActualizar.Enabled = false;
                        btnGuardar.Enabled = false;
                    }
                    else
                    {
                        filtrar(consultafiltro + "ORDER BY fecha asc,");
                        dataGridView1.ReadOnly = true;
                        btnVerReg.Enabled = false;
                        btnLimpiarReg.Enabled = true;
                        //Workaround por que crashea si se abre mientras haya un filtro activo
                        btnAlumnos.Enabled = false;
                        radioButton3.Enabled = false;
                        radioButton4.Enabled = false;
                        btnLimpiarFiltro.Enabled = false;
                        btnActualizar.Enabled = false;
                        btnGuardar.Enabled = false;
                    }
                }
                else
                {
                    if (!checkBox1.Checked)
                    {
                        filtrar(consultafiltro + " where grado ='" + comboBox1.SelectedItem.ToString() + "' AND fecha ='" + dateTimePicker1.Value.ToString("yyyy-MM-dd") + "'  ORDER BY fecha asc,");
                        dataGridView1.ReadOnly = true;
                        btnVerReg.Enabled = false;
                        btnLimpiarReg.Enabled = true;
                        //Workaround por que crashea si se abre mientras haya un filtro activo
                        btnAlumnos.Enabled = false;
                        radioButton3.Enabled = false;
                        radioButton4.Enabled = false;
                        btnLimpiarFiltro.Enabled = false;
                        btnActualizar.Enabled = false;
                        btnGuardar.Enabled = false;
                    }
                    else
                    {
                        filtrar(consultafiltro + "where grado ='" + comboBox1.SelectedItem.ToString() + "'  ORDER BY fecha asc,");
                        dataGridView1.ReadOnly = true;
                        btnVerReg.Enabled = false;
                        btnLimpiarReg.Enabled = true;
                        //Workaround por que crashea si se abre mientras haya un filtro activo
                        btnAlumnos.Enabled = false;
                        radioButton3.Enabled = false;
                        radioButton4.Enabled = false;
                        btnLimpiarFiltro.Enabled = false;
                        btnActualizar.Enabled = false;
                        btnGuardar.Enabled = false;
                    }
                }
            }
            else if (radioButton1.Checked && textBox1.Text != "" && textBox2.Text != "")
            {
                filtrar(consultafiltro + "where nombres_alumno='" + textBox1.Text + "' and apellidos_alumno='" + textBox2.Text + "'  ORDER BY fecha asc,");
                dataGridView1.ReadOnly = true;
                btnVerReg.Enabled = false;
                btnLimpiarReg.Enabled = true;
                //Workaround por que crashea si se abre mientras haya un filtro activo
                btnAlumnos.Enabled = false;
                radioButton3.Enabled = false;
                radioButton4.Enabled = false;
                btnLimpiarFiltro.Enabled = false;
                btnActualizar.Enabled = false;
                btnGuardar.Enabled = false;
            }
            else
            {
                MessageBox.Show("Seleccione un filtro y llene el campo de busqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dataGridView1.Columns.Remove("estado");
                limpiarfiltros();
                registros();
                agregarcolumna();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            limpiarfiltros();
            registros();
            agregarcolumna();
            btnAlumnos.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            btnLimpiarFiltro.Enabled = true;
            btnActualizar.Enabled = true;
            btnGuardar.Enabled = true;
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();

            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string nombre = row.Cells["Nombre"].Value?.ToString();
                    string apellido = row.Cells["Apellido"].Value?.ToString();
                    string grado = row.Cells["Grado"].Value?.ToString();
                    bool presente = Convert.ToBoolean(row.Cells["estado"].Value);

                    int idAlumno = -1;
                    SqlCommand asignar = new SqlCommand("SELECT id_alumno FROM info_alumnos WHERE nombres_alumno=@nombre AND apellidos_alumno=@apellido AND grado=@grado", conexion);
                    asignar.Parameters.AddWithValue("@nombre", nombre);
                    asignar.Parameters.AddWithValue("@apellido", apellido);
                    asignar.Parameters.AddWithValue("@grado", grado);
                    object result = asignar.ExecuteScalar();
                    if (result != null)
                        idAlumno = Convert.ToInt32(result);
                    if (idAlumno != -1)
                    {
                        SqlCommand seleccionar = new SqlCommand("SELECT COUNT(*) FROM asistencias WHERE id_alumno=@id AND fecha=@fecha", conexion);
                        seleccionar.Parameters.AddWithValue("@id", idAlumno);
                        seleccionar.Parameters.AddWithValue("@fecha", dateTimePicker2.Value.Date);
                        count = (int)seleccionar.ExecuteScalar();
                        if (count == 0)
                        {
                            SqlCommand insertar = new SqlCommand("INSERT INTO asistencias (id_alumno, fecha, estado) VALUES (@id, @fecha, @estado)", conexion);
                            insertar.Parameters.AddWithValue("@id", idAlumno);
                            insertar.Parameters.AddWithValue("@fecha", dateTimePicker2.Value.Date);
                            insertar.Parameters.AddWithValue("@estado", presente);
                            insertar.ExecuteNonQuery();
                        }
                    }
                }
                if (count == 0)
                {
                    MessageBox.Show("Asistencias registradas correctamente.");
                }
                else
                {
                    MessageBox.Show("Ya hay registros este dia");
                }
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
        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Estas seguro?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    conexion.Open();
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string nombre = row.Cells["Nombre"].Value?.ToString();
                        string apellido = row.Cells["Apellido"].Value?.ToString();
                        string grado = row.Cells["Grado"].Value?.ToString();
                        bool presente = Convert.ToBoolean(row.Cells["estado"].Value);

                        int idAlumno = -1;
                        SqlCommand cmd = new SqlCommand("SELECT id_alumno FROM info_alumnos WHERE nombres_alumno=@nombre AND apellidos_alumno=@apellido AND grado=@grado", conexion);
                        cmd.Parameters.AddWithValue("@nombre", nombre);
                        cmd.Parameters.AddWithValue("@apellido", apellido);
                        cmd.Parameters.AddWithValue("@grado", grado);

                        object result = cmd.ExecuteScalar();
                        if (result != null)
                            idAlumno = Convert.ToInt32(result);


                        if (idAlumno != -1)
                        {
                            SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM asistencias WHERE id_alumno=@id AND fecha=@fecha", conexion);
                            checkCmd.Parameters.AddWithValue("@id", idAlumno);
                            checkCmd.Parameters.AddWithValue("@fecha", dateTimePicker2.Value.Date);
                            int count = (int)checkCmd.ExecuteScalar();
                            if (count != 0)
                            {
                                SqlCommand updateCmd = new SqlCommand("UPDATE asistencias SET estado=@estado WHERE id_alumno=@id AND fecha=@fecha", conexion);
                                updateCmd.Parameters.AddWithValue("@id", idAlumno);
                                updateCmd.Parameters.AddWithValue("@fecha", dateTimePicker2.Value.Date);
                                updateCmd.Parameters.AddWithValue("@estado", presente);
                                updateCmd.ExecuteNonQuery();
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
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Enabled = false;
            }
            else
            {
                dateTimePicker1.Enabled = true;
            }
        }

        private void generarEstadisticasToolStripMenuItem_Click(object sender, EventArgs e)
        { //Creditos especiales al departamento de computacion del don bosco por NO enseñarme a llamar el Guardar como.
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Excel files (*.xlsx)|*.*";
            s.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            s.FileName = "Estadisticas.xlsm";
            if (s.ShowDialog() == DialogResult.OK)
            {
                string filePath = s.FileName;
                ExportSqlTableToExcel(filePath);
            }
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            limpiarregistros();
            registros();
            eliminarcolumna();
            agregarcolumna();
            btnVerReg.Enabled = true;
            btnLimpiarFiltro.Enabled = false;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            filtrar("select nombres_alumno AS 'Nombre',apellidos_alumno AS 'Apellido',grado AS 'Grado' from info_alumnos where grado = '" + comboBox2.SelectedItem.ToString() + "' ORDER BY ");
            agregarcolumna();
            btnVerReg.Enabled = false;
            btnLimpiarFiltro.Enabled = true;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                filtrar("select nombres_alumno as 'Nombre',apellidos_alumno as 'Apellido',grado as 'Grado' from info_alumnos where nombres_alumno = '" + textBox1.Text + "' and apellidos_alumno = '" + textBox2.Text + "' ORDER BY ");
                agregarcolumna();
                btnVerReg.Enabled = false;
                btnLimpiarFiltro.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["estado"].Value = true;
                }
            }
            else
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    row.Cells["estado"].Value = false;
                }
            }
        }
    }
}
