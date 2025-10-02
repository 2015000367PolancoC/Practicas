using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
namespace Borrador4
{
    public partial class Inscripciones : Form
    {
        //SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=registros;Integrated Security = true");
        SqlConnection conexion = new SqlConnection("Data Source=192.168.68.51,9898;Initial Catalog=registros;User ID = gary; Password = zY-Oh_vQzPc[FYWf");
        int inscripcionBS = 0, inscripcionBC = 0;
        int idalumno;
        public Inscripciones()
        {
            InitializeComponent();
            monto();
            filtrar();
        }
        private void monto()
        {
            if (DateTime.Now < Properties.Settings.Default.FechaMora)
            {
                inscripcionBS = Properties.Settings.Default.InscripcionBAS1;
                inscripcionBC = Properties.Settings.Default.InscripcionBAC1;
            }
            else
            {
                inscripcionBS = Properties.Settings.Default.InscripcionBAS2;
                inscripcionBC = Properties.Settings.Default.InscripcionBAC2;
            }
        }
        private void filtrar()
        {
            String filtro = "";
            if (comboBox2.SelectedIndex > 0)
            {
                filtro += " where grado = '" + comboBox2.SelectedItem.ToString() + "'";
            }
            Registros(filtro);
        }
        private void Registros(String filtro)
        {
            string consulta = "select NombreEstudiante as 'Nombre',ApellidoEstudiante as 'Apellido',DATEDIFF(YEAR,fechanacimiento,GETDATE()) AS 'Edad',fechanacimiento,CONCAT(beca,'%') as 'Beca',monto as 'Aporte',CASE WHEN grado = 'Cuarto Bachillerato' OR grado ='Quinto Bachillerato' THEN CASE WHEN " + inscripcionBC + " - monto < 0 THEN 0 ELSE " + inscripcionBC + " - monto END ELSE CASE WHEN " + inscripcionBS + " - monto < 0 THEN 0 ELSE " + inscripcionBS + " - monto END END as 'Aporte pendiente',Fechapago as 'Fecha de pago',NombreCompletoE1 as 'Nombre de Encargado',NombreCompletoE2 as 'Nombre de Encargado',LEFT(telefonoE1,4) + '-' + RIGHT(telefonoE1,4) AS 'Telefono 1',LEFT(telefonoE2,4) + '-' + RIGHT(telefonoE2,4) AS 'Telefono 2' from inscripciones i inner join alumno a on  i.idEstudiante = a.id";
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter(consulta + filtro + " ORDER BY CASE WHEN grado = 'Primero Básico' THEN 1 WHEN grado = 'Segundo Básico' THEN 2 WHEN grado = 'Tercero Básico' THEN 3 WHEN grado = 'Cuarto Bachillerato' THEN 4 WHEN grado = 'Quinto Bachillerato' THEN 5 ELSE 1000 END asc, ApellidoEstudiante asc,NombreEstudiante asc", conexion);
                DataSet d = new DataSet();
                comando.Fill(d, "nombre");
                dataGridView1.DataSource = d.Tables["nombre"].DefaultView;

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    if (column.Index >= 5 && column.Index <= 6)
                    {
                        column.DefaultCellStyle.Font = new Font(dataGridView1.Font, FontStyle.Bold);
                        column.DefaultCellStyle.Format = "C2";
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
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
        private void btnPago_Click(object sender, EventArgs e)
        {
            bool d = false;
            if (!decimal.TryParse(textBox3.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }
            if (idalumno == 0)
            {
                MessageBox.Show("Seleccione un alumno.");
                return;
            }
            try
            {
                /*if (monto > 600)
                {
                    d = true;
                    monto = 600;
                    pago.pagar(monto - 600, idalumno, 0);
                    MessageBox.Show("Actualizado exitosamente, el monto extra se agrego a la mensualidad");
                }*/
                conexion.Open();
                SqlCommand comando = new SqlCommand("UPDATE inscripciones set monto = monto + @monto WHERE idEstudiante = @id", conexion);
                comando.Parameters.AddWithValue("@monto", monto);
                comando.Parameters.AddWithValue("@id", idalumno);
                comando.ExecuteNonQuery();
                if (!d)
                {
                    MessageBox.Show("Actualizado exitosamente");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar el pago: " + ex);
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
                idalumno = (int)dataGridView1.Rows[e.RowIndex].Cells[12].Value;
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
                textBox5.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            }
        }
        private void Inscripciones_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= 1; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            for (int i = 2; i < dataGridView1.Columns.Count; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            filtrar();
        }

        private void generarResumenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Resumen v = new Resumen("select Grado,count(activo) as 'Inscritos',SUM(monto) as 'Aporte',SUM(CASE WHEN " + 600 + " - monto < 0 THEN 0 ELSE " + 600 + " - monto END) as 'Aporte Pendiente' from alumno a inner join inscripciones i on i.idEstudiante = a.id group by ROLLUP(grado) ORDER BY CASE WHEN grado = 'Primero Básico' THEN 1 WHEN grado = 'Segundo Básico' THEN 2 WHEN grado = 'Tercero Básico' THEN 3 WHEN grado = 'Cuarto Bachillerato' THEN 4 WHEN grado = 'Quinto Bachillerato' THEN 5 ELSE 1000 END asc", 0);
            v.ShowDialog();
        }
    }
}