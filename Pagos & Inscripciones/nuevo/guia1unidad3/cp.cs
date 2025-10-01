using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
namespace Borrador4
{
    public partial class cp : Form
    {
        //SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=registros;Integrated Security = true");
        SqlConnection conexion = new SqlConnection("Data Source=192.168.68.51,9898;Initial Catalog=registros;User ID = gary; Password = zY-Oh_vQzPc[FYWf");
        string consulta = "select NombreEstudiante AS 'Nombre del alumno',ApellidoEstudiante AS 'Apellido del alumno',DATEDIFF(YEAR,fechanacimiento,GETDATE()) AS 'Edad',CONCAT(beca,'%') AS '% Beca',Fechapago AS 'Fecha de pago',FechaEntrega AS 'Fecha de entrega',Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Septiembre,Octubre,(Enero+Febrero+Marzo+Abril+Mayo+Junio+Julio+Agosto+Septiembre+Octubre) as 'Total',alumno.id from alumno INNER JOIN pagos on alumno.id = pagos.idAlumno ";
        string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre" };
        int idalumno;
        int mensualidad = Properties.Settings.Default.mensualidad;
        public cp()
        {
            InitializeComponent();
            Registros(consulta);
        }
        private void Registros(String query)
        {
            try
            {
                conexion.Open();
                SqlDataAdapter DatosAlumnos = new SqlDataAdapter(query + " ORDER BY CASE WHEN grado = 'Primero Básico' THEN 1 WHEN grado = 'Segundo Básico' THEN 2 WHEN grado = 'Tercero Básico' THEN 3 WHEN grado = 'Cuarto Bachillerato' THEN 4 WHEN grado = 'Quinto Bachillerato' THEN 5 ELSE 1000 END asc, ApellidoEstudiante asc", conexion);
                DataSet d = new DataSet();
                DatosAlumnos.Fill(d, "nombre");
                dataGridView1.DataSource = d.Tables["nombre"].DefaultView;
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.Index >= 6 && column.Index <= 16)
                    {
                        column.DefaultCellStyle.Format = "C2";
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    }
                    if (column.Index == 16)
                    {
                        column.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
                    }
                }
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        idalumno = (int)dataGridView1.Rows[cell.RowIndex].Cells[17].Value;
                        if (cell.ColumnIndex >= 6 && cell.ColumnIndex <= 15)
                        {
                            int mesIndex = cell.ColumnIndex - 6;
                            string columnaBit = meses[mesIndex] + "E";
                            SqlCommand cmd = new SqlCommand($"SELECT {columnaBit} FROM pagos where idalumno = @idalumno", conexion);
                            cmd.Parameters.AddWithValue("@idalumno", idalumno);
                            object result = cmd.ExecuteScalar();
                            if (result != null && result != DBNull.Value && (bool)result)
                            {
                                cell.Style.BackColor = Color.LimeGreen;
                            }
                        }
                        if (cell.Value != null && decimal.TryParse(cell.Value.ToString(), out decimal valor) && valor == 0)
                        {
                            cell.Style.ForeColor = Color.Gray;
                        }
                    }
                }
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
        private void filtrar()
        {
            string filtro = "";
            if (cbxFiltro1.SelectedIndex > 0 && cboxfiltro2.SelectedIndex == 0)
            {
                filtro += "WHERE Grado = '" + cbxFiltro1.SelectedItem.ToString() + "'";
                if (checkBox1.Checked)
                {
                    filtro += " AND Fechapago is null";
                }
                if (checkBox2.Checked)
                {
                    filtro += " AND Fechaentrega is null";
                }
            }
            else if (cbxFiltro1.SelectedIndex == 0 && cboxfiltro2.SelectedIndex > 0)
            {
                filtro += "WHERE " + cboxfiltro2.SelectedItem.ToString() + "";
                if (checkBox1.Checked)
                {
                    filtro += " != " + mensualidad;
                }
                else
                {
                    filtro += " is not null";
                }
                if (checkBox2.Checked)
                {
                    filtro += " AND " + cboxfiltro2.SelectedItem.ToString() + "E = 0";
                }
            }
            else if (cbxFiltro1.SelectedIndex > 0 && cboxfiltro2.SelectedIndex > 0)
            {
                filtro += "WHERE Grado = '" + cbxFiltro1.SelectedItem.ToString() + "' AND " + cboxfiltro2.SelectedItem.ToString() + "";
                if (checkBox1.Checked)
                {
                    filtro += " != " + mensualidad;
                }
                else
                {
                    filtro += " is not null";
                }
                if (checkBox2.Checked)
                {
                    filtro += " AND " + cboxfiltro2.SelectedItem.ToString() + "E = 0";
                }
            }
            Registros(consulta + filtro);
        }
        private void btnEnvio_Click(object sender, EventArgs e)
        {
            if (idalumno == 0)
            {
                MessageBox.Show("Seleccione un alumno.");
                return;
            }
            if (dataGridView1.SelectedRows.Count > 1)
            {
                MessageBox.Show("Seleccionar solo 1 fila de meses a la vez");
                return;
            }
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {

                int mesIndex = cell.ColumnIndex - 6;
                if (mesIndex >= 0 && mesIndex < meses.Length)
                {
                    string columnaBit = meses[mesIndex] + "E";
                    string Fechas = meses[mesIndex] + "FE";
                    string query = $"UPDATE pagos SET {columnaBit} = 1,{Fechas} = @fecha,FechaEntrega = @fecha WHERE idalumno = @idalumno";
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd.Parameters.AddWithValue("@idalumno", idalumno);
                    cmd.ExecuteNonQuery();
                    conexion.Close();
                }
            }
            filtrar();
        }
        public void pagar(decimal monto, int id, int mesInicio)
        {
            if (mesInicio == -1)
            {
                MessageBox.Show("Seleccione un mes.");
                return;
            }
            int mesesDisponibles = meses.Length - mesInicio;
            int maximoRepartible = mesesDisponibles * mensualidad;
            if (monto > maximoRepartible)
            {
                MessageBox.Show("El monto excede el límite permitido hasta el mes de Octubre.");
                return;
            }

            // Crear un diccionario para los valores de cada mes
            Dictionary<string, decimal> valoresMes = new Dictionary<string, decimal>();
            foreach (string mes in meses)
                valoresMes[mes] = 0;
            // Repartir el monto mes a mes
            int mesfinal = mesInicio;
            while (monto > 0 && mesInicio < meses.Length)
            {
                if (monto >= mensualidad)
                {
                    valoresMes[meses[mesInicio]] = mensualidad;
                    monto -= mensualidad;
                }
                else
                {
                    valoresMes[meses[mesInicio]] = monto;
                    monto = 0;
                }
                mesInicio++;
            }
            try
            {
                conexion.Open();
                string setmeses = string.Join(", ", meses.Select(m => $"{m} = {m} + @{m}"));
                string query = $"UPDATE Pagos SET {setmeses},Fechapago=@Fechapago WHERE idalumno=@idalumno";
                SqlCommand cmd = new SqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@idalumno", id);
                cmd.Parameters.AddWithValue("@Fechapago", DateTime.Now);
                foreach (var mes in meses)
                {
                    cmd.Parameters.AddWithValue("@" + mes, valoresMes[mes]);
                }
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el pago: " + ex.Message);

            }
            finally
            {
                conexion.Close();
            }
        }
        private void btnPago_Click(object sender, EventArgs e)
        {
            int mesInicio = comboBox1.SelectedIndex;
            if (!decimal.TryParse(textBox3.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                if (cell.Value != null && decimal.TryParse(cell.Value.ToString(), out decimal valor) && valor >= mensualidad)
                {
                    MessageBox.Show("Este mes ya ha sido pagado"); return;
                }
            }
            pagar(monto, idalumno, mesInicio);
            MessageBox.Show("Pago registrado con éxito.");
            filtrar();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                idalumno = (int)dataGridView1.Rows[e.RowIndex].Cells[17].Value;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            }
            if (e.RowIndex >= 0 && e.ColumnIndex >= 5 && e.ColumnIndex < 16)
            {
                comboBox1.SelectedIndex = e.ColumnIndex - 6;
            }
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count == 0)
            {
                return;
            }
            foreach (DataGridViewCell cell in dataGridView1.SelectedCells)
            {
                if (cell.RowIndex >= 0 && cell.ColumnIndex >= 0)
                {
                    idalumno = (int)dataGridView1.Rows[cell.RowIndex].Cells[17].Value;
                    textBox1.Text = dataGridView1.Rows[cell.RowIndex].Cells[0].Value.ToString();
                    textBox2.Text = dataGridView1.Rows[cell.RowIndex].Cells[1].Value.ToString();
                }
                if (cell.RowIndex >= 0 && cell.ColumnIndex >= 5 && cell.ColumnIndex < 16)
                {
                    comboBox1.SelectedIndex = cell.ColumnIndex - 6;
                }
            }
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxfiltro2.SelectedIndex == 0)
            {
                checkBox1.Enabled = false;
                checkBox2.Enabled = false;
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else
            {
                checkBox1.Enabled = true;
                checkBox2.Enabled = true;
            }
            filtrar();
        }
        private void cp_Load(object sender, EventArgs e)
        {
            Registros(consulta);
            cbxFiltro1.SelectedIndex = 0;
            cboxfiltro2.SelectedIndex = 0;
        }
        private void generarResumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resumen v = new Resumen("select Grado,sum(enero+febrero+marzo+abril+mayo+junio+julio+agosto+septiembre+octubre) as 'Total', SUM(CASE WHEN EneroE = 1 THEN Enero ELSE 0 END + CASE WHEN FebreroE = 1 THEN Febrero ELSE 0 END + CASE WHEN MarzoE = 1 THEN Marzo ELSE 0 END + CASE WHEN AbrilE = 1 THEN Abril ELSE 0 END + CASE WHEN MayoE = 1 THEN Mayo ELSE 0 END + CASE WHEN JunioE = 1 THEN Junio ELSE 0 END + CASE WHEN JulioE = 1 THEN Julio ELSE 0 END +CASE WHEN AgostoE = 1 THEN Agosto ELSE 0 END + CASE WHEN SeptiembreE = 1 THEN Septiembre ELSE 0 END + CASE WHEN OctubreE = 1 THEN Octubre ELSE 0 END) AS 'Total Entregado' from pagos inner join alumno on pagos.idalumno = alumno.id group by ROLLUP(grado) ORDER BY CASE WHEN grado = 'Primero Básico' THEN 1 WHEN grado = 'Segundo Básico' THEN 2 WHEN grado = 'Tercero Básico' THEN 3 WHEN grado = 'Cuarto Bachillerato' THEN 4 WHEN grado = 'Quinto Bachillerato' THEN 5 ELSE 1000 END asc", 1);
            v.ShowDialog();
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }
    }
}
