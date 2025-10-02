using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Table;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
namespace Borrador4
{
    public partial class cp : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=registros;Integrated Security = true");
        //SqlConnection conexion = new SqlConnection("Data Source=192.168.68.51,9898;Initial Catalog=registros;User ID = gary; Password = zY-Oh_vQzPc[FYWf");
        string consulta = "select NombreEstudiante AS 'Nombre del alumno',ApellidoEstudiante AS 'Apellido del alumno',DATEDIFF(YEAR,fechanacimiento,GETDATE()) AS 'Edad',CONCAT(beca,'%') AS '% Beca',Fechapago AS 'Fecha de pago',FechaEntrega AS 'Fecha de entrega',Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Septiembre,Octubre,(Enero+Febrero+Marzo+Abril+Mayo+Junio+Julio+Agosto+Septiembre+Octubre) as 'Total',alumno.id from alumno INNER JOIN pagos on alumno.id = pagos.idAlumno ";
        string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre" };
        int idalumno;
        int mensualidad = Properties.Settings.Default.mensualidad;
        int MesHoy = Int32.Parse(DateTime.Now.ToString("MM"));
        public cp()
        {
            InitializeComponent();
            filtrar();
        }
        private void Registros(String filtro)
        {
            try
            {
                conexion.Open();
                SqlDataAdapter DatosAlumnos = new SqlDataAdapter(consulta + filtro + " ORDER BY CASE WHEN grado = 'Primero Básico' THEN 1 WHEN grado = 'Segundo Básico' THEN 2 WHEN grado = 'Tercero Básico' THEN 3 WHEN grado = 'Cuarto Bachillerato' THEN 4 WHEN grado = 'Quinto Bachillerato' THEN 5 ELSE 1000 END asc, ApellidoEstudiante asc,NombreEstudiante asc", conexion);
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
                    filtro += " AND Fechaentrega is null ";
                }
                if (checkBox3.Checked)
                {
                    filtro += " AND (";
                    for (int i = 0; i < MesHoy - 1; i++)
                    {
                        filtro += $"{meses[i]} != {mensualidad} OR ";
                    }
                    filtro = filtro.Substring(0, filtro.Length - 4);
                    filtro += ")";
                }
                if (checkBox4.Checked)
                {
                    filtro += " AND Activo = 1";
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
                if (checkBox3.Checked)
                {
                    filtro += " AND (";
                    for (int i = 0; i < MesHoy - 1; i++)
                    {
                        filtro += $"{meses[i]} != {mensualidad} OR ";
                    }
                    filtro = filtro.Substring(0, filtro.Length - 4);
                    filtro += ") ";
                }
                if (checkBox4.Checked)
                {
                    filtro += " AND Activo = 1 ";
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
                if (checkBox3.Checked)
                {
                    filtro += " AND (";
                    for (int i = 0; i < MesHoy - 1; i++)
                    {
                        filtro += $"{meses[i]} != {mensualidad} OR ";
                    }
                    filtro = filtro.Substring(0, filtro.Length - 4);
                    filtro += ")";
                }
                if (checkBox4.Checked)
                {
                    filtro += " AND Activo = 1 ";
                }
            }
            Registros(filtro);
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
        private void button2_Click(object sender, EventArgs e)
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
                    string query = $"UPDATE pagos SET {columnaBit} = 0,{Fechas} = @fecha WHERE idalumno = @idalumno";
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@fecha", DBNull.Value);
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
                    MessageBox.Show("Este mes ya ha sido pagado");
                    return;
                }
            }
            pagar(monto, idalumno, mesInicio);
            MessageBox.Show("Pago registrado con éxito.");
            filtrar();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
             {
                if (comboBox1.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
                else
                {
                    String mesSel = meses[comboBox1.SelectedIndex];
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE pagos SET "+mesSel+"= @monto WHERE idalumno=@idalumno", conexion);
                    cmd.Parameters.AddWithValue("@monto", decimal.Parse(textBox3.Text));
                    cmd.Parameters.AddWithValue("@idalumno", idalumno);
                    MessageBox.Show("UPDATE Pagos SET " + meses[comboBox1.SelectedIndex] + " = "+textBox3.Text+" WHERE idalumno="+idalumno);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al consultar la base de datos: " + ex.Message);
            }
            finally
            {
                conexion.Close();
                filtrar();
            }
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
        private void btnFiltro(object sender, EventArgs e)
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
            for (int i = 0; i <= 1; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            for (int i = 2; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            filtrar();
            cbxFiltro1.SelectedIndex = 0;
            cboxfiltro2.SelectedIndex = 0;
        }
        private void generarResumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resumen v = new Resumen("select Grado,sum(enero+febrero+marzo+abril+mayo+junio+julio+agosto+septiembre+octubre) as 'Total', SUM(CASE WHEN EneroE = 1 THEN Enero ELSE 0 END + CASE WHEN FebreroE = 1 THEN Febrero ELSE 0 END + CASE WHEN MarzoE = 1 THEN Marzo ELSE 0 END + CASE WHEN AbrilE = 1 THEN Abril ELSE 0 END + CASE WHEN MayoE = 1 THEN Mayo ELSE 0 END + CASE WHEN JunioE = 1 THEN Junio ELSE 0 END + CASE WHEN JulioE = 1 THEN Julio ELSE 0 END +CASE WHEN AgostoE = 1 THEN Agosto ELSE 0 END + CASE WHEN SeptiembreE = 1 THEN Septiembre ELSE 0 END + CASE WHEN OctubreE = 1 THEN Octubre ELSE 0 END) AS 'Total Entregado' from pagos inner join alumno on pagos.idalumno = alumno.id group by ROLLUP(grado) ORDER BY CASE WHEN grado = 'Primero Básico' THEN 1 WHEN grado = 'Segundo Básico' THEN 2 WHEN grado = 'Tercero Básico' THEN 3 WHEN grado = 'Cuarto Bachillerato' THEN 4 WHEN grado = 'Quinto Bachillerato' THEN 5 ELSE 1000 END asc", 1);
            v.ShowDialog();
        }
        private void alumnosFaltantesExcelTralaleroTralalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog();
            s.Filter = "Excel files (*.xlsx)|*.*";
            s.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            s.FileName = "Pagos";
            if (s.ShowDialog() == DialogResult.OK)
            {
                string filePath = s.FileName;
                Guardar(filePath+".xlsx");
            }
        }
        private void Guardar(string filePath)
        {
            if (MesHoy > 10)
            {
                MesHoy = 10;
            }
            string mesesNum = "";
            string mes = "";
            for (int i = 0; i < MesHoy; i++)
            {
                mes += " CASE WHEN " + meses[i] + " != " + mensualidad + " THEN 1 ELSE 0 END + ";
                mesesNum += "(CASE WHEN " + meses[i] + " != " + mensualidad + "  THEN ' " + meses[i] + ",' ELSE '' END) + ";
            }
            mes = mes.Substring(0, mes.Length - 2);
            mesesNum = mesesNum.Substring(0, mesesNum.Length - 2);
            conexion.Open();
            SqlDataAdapter da = new SqlDataAdapter
                (
                "SELECT NombreEstudiante +' '+ ApellidoEstudiante as 'Nombre',Grado," +
                $"({mes}) AS 'Meses sin pagar',LTRIM ({mesesNum}) AS 'Lista Meses No Pagados'" +
                " FROM pagos p inner join alumno a on p.idalumno = a.id ORDER BY Nombre;"
                , conexion);
            SqlCommand columnas = new SqlCommand("SELECT COUNT(*) FROM alumno", conexion);
            int col = Int32.Parse(columnas.ExecuteScalar().ToString());
            conexion.Close();
            DataTable dt = new DataTable();
            da.Fill(dt);
            SqlDataAdapter da2 = new SqlDataAdapter("select Grado,sum(enero+febrero+marzo+abril+mayo+junio+julio+agosto+septiembre+octubre) as 'Total', SUM(CASE WHEN EneroE = 1 THEN Enero ELSE 0 END + CASE WHEN FebreroE = 1 THEN Febrero ELSE 0 END + CASE WHEN MarzoE = 1 THEN Marzo ELSE 0 END + CASE WHEN AbrilE = 1 THEN Abril ELSE 0 END + CASE WHEN MayoE = 1 THEN Mayo ELSE 0 END + CASE WHEN JunioE = 1 THEN Junio ELSE 0 END + CASE WHEN JulioE = 1 THEN Julio ELSE 0 END +CASE WHEN AgostoE = 1 THEN Agosto ELSE 0 END + CASE WHEN SeptiembreE = 1 THEN Septiembre ELSE 0 END + CASE WHEN OctubreE = 1 THEN Octubre ELSE 0 END) AS 'Total Entregado' from pagos inner join alumno on pagos.idalumno = alumno.id group by ROLLUP(grado) ORDER BY CASE WHEN grado = 'Primero Básico' THEN 1 WHEN grado = 'Segundo Básico' THEN 2 WHEN grado = 'Tercero Básico' THEN 3 WHEN grado = 'Cuarto Bachillerato' THEN 4 WHEN grado = 'Quinto Bachillerato' THEN 5 ELSE 1000 END asc", conexion);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            SqlDataAdapter da3 = new SqlDataAdapter("WITH PagosDesglosados AS (SELECT \r\n    a.Grado,\r\n    'Enero' AS Mes,\r\n    p.Enero AS Monto,\r\n    p.EneroFE AS Fecha\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.EneroE = 1 AND p.EneroFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Febrero' AS Mes,\r\n    p.Febrero,\r\n    p.FebreroFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.FebreroE = 1 AND p.FebreroFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Marzo' AS Mes,\r\n    p.Marzo,\r\n    p.MarzoFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.MarzoE = 1 AND p.MarzoFE IS NOT NULL\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Abril' AS Mes,\r\n    p.Abril,\r\n    p.AbrilFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.AbrilE = 1 AND p.AbrilFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Mayo' AS Mes,  \r\n    p.Mayo,\r\n    p.MayoFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.MayoE = 1 AND p.MayoFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Junio' AS Mes,\r\n    p.Junio,\r\n    p.JunioFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.JunioE = 1 AND p.JunioFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Julio' AS Mes,\r\n    p.Julio,\r\n    p.JulioFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.JulioE = 1 AND p.JulioFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Agosto' AS Mes,\r\n    p.Agosto,\r\n    p.AgostoFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.AgostoE = 1 AND p.AgostoFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Septiembre' AS Mes,\r\n    p.Septiembre,\r\n    p.SeptiembreFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.SeptiembreE = 1 AND p.SeptiembreFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Octubre' AS Mes,\r\n    p.Octubre,\r\n    p.OctubreFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.OctubreE = 1 AND p.OctubreFE IS NOT NULL\r\n\r\n)\r\n\r\nSELECT \r\n    Grado,\r\n    Fecha,\r\n    SUM(Monto) AS 'Entregado'\r\n\r\nFROM PagosDesglosados\r\nGROUP BY Grado, Fecha\r\nORDER BY Fecha desc,CASE\r\n\tWHEN grado = 'Primero Básico' THEN 1\r\n\tWHEN grado = 'Segundo Básico' THEN 2\r\n\tWHEN grado = 'Tercero Básico' THEN 3\r\n\tWHEN grado = 'Cuarto Bachillerato' THEN 4\r\n\tWHEN grado = 'Quinto Bachillerato' THEN 5\r\nELSE 1000 END asc;", conexion);
            DataTable dt3 = new DataTable();
            da3.Fill(dt3);
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                ExcelWorksheet meses = package.Workbook.Worksheets.Add("Alumnos");
                meses.Cells["A1"].LoadFromDataTable(dt, true);
                var table = meses.Tables.Add(meses.Cells["A1:D" + (col+1)], "Pagos");
                table.ShowHeader = true;
                table.ShowFirstColumn = true;
                table.TableStyle = TableStyles.None;
                using (ExcelRange range = meses.Cells[1, 1, 1, dt.Columns.Count])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                }
                using (ExcelRange range = meses.Cells[1, 1, dt.Rows.Count + 1, dt.Columns.Count])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                meses.Cells[meses.Dimension.Address].AutoFitColumns();
                ExcelWorksheet resumen = package.Workbook.Worksheets.Add("Resumen por grado");
                using (ExcelRange range = resumen.Cells[1, 1, 1, dt2.Columns.Count])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                }
                using (ExcelRange range = resumen.Cells[1, 1, dt2.Rows.Count + 1, dt2.Columns.Count])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                resumen.Cells[resumen.Dimension.Address].AutoFitColumns();
                resumen.Cells["A1"].LoadFromDataTable(dt2, true);
                ExcelWorksheet resumen2 = package.Workbook.Worksheets.Add("Resumen por fecha");
                resumen2.Cells["A1"].LoadFromDataTable(dt3, true);
                using (ExcelRange range = resumen2.Cells[1, 1, 1, dt3.Columns.Count])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.LightBlue);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                    range.Style.Border.BorderAround(ExcelBorderStyle.Thin, Color.Black);
                }
                using (ExcelRange range = resumen2.Cells[1, 1, dt3.Rows.Count + 1, dt3.Columns.Count])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }
                resumen2.Cells[resumen2.Dimension.Address].AutoFitColumns();
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
    }
}