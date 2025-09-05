using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace guia1unidad3
{
    public partial class cp : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=registros;Integrated Security=True");
        public cp()
        {
            InitializeComponent();
            registros();
        }
        int mes, filaSeleccionada, columnaSeleccionada;
        string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre" };

        private void registros()
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter("SELECT id AS 'ID de estudiante',NombreEstudiante AS 'Nombre de Estudiante',ApellidoEstudiante AS 'Apellido de Estudiante',Enero, Febrero, Marzo, Abril, Mayo, Junio, Julio, Agosto, Septiembre, Octubre,Eneroentregado, Febreroentregado, Marzoentregado, Abrilentregado, Mayoentregado,Junioentregado, Julioentregado, Agostoentregado, Septiembreentregado, Octubreentregado " +
                    "FROM inscripciones", conexion);
                // SqlDataAdapter comando2 = new SqlDataAdapter("select id as 'ID de estudiante',NombreEstudiante as 'Nombre de Estudiante',ApellidoEstudiante as 'Apellido de Estudiante',Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Septiembre,Octubre from inscripciones;", conexion);
                DataSet d = new DataSet();
                comando.Fill(d, "nombre");
                dataGridView1.DataSource = d.Tables["nombre"].DefaultView;

                // Pintar las celdas según el estado de entregado
                for (int x = 0; x < dataGridView1.Rows.Count; x++)
                {
                    for (int y = 0; y < meses.Length; y++)
                    {
                        // El índice de la columna de coloreado en el DataTable es 13 + y (después de las 3 primeras y los 10 meses)
                        int colColoreado = 13 + y;
                        var valor = dataGridView1.Rows[x].Cells[colColoreado].Value;
                        if (valor != DBNull.Value && Convert.ToBoolean(valor))
                        {
                            // La columna de datos del mes está en 3 + y
                            dataGridView1.Rows[x].Cells[3 + y].Style.BackColor = Color.Yellow;
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
        private void button1_Click(object sender, EventArgs e)
        {
            if (filaSeleccionada >= 0 && columnaSeleccionada >= 3)
            {
                dataGridView1.Rows[filaSeleccionada].Cells[columnaSeleccionada].Style.BackColor = Color.Green;
                // Obtener el nombre del estudiante y el mes
                string nombreEstudiante = dataGridView1.Rows[filaSeleccionada].Cells[1].Value.ToString();
                string apellidoEstudiante = dataGridView1.Rows[filaSeleccionada].Cells[2].Value.ToString();
                int mesIndex = columnaSeleccionada - 3; // Ajusta según el índice de columna de los meses

                if (mesIndex >= 0 && mesIndex < meses.Length)
                {
                    string columnaBit = meses[mesIndex] + "entregado";
                    string query = $"UPDATE inscripciones SET {columnaBit} = 1 WHERE NombreEstudiante = @nombre AND ApellidoEstudiante = @apellido";

                    conexion.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conexion))
                    {
                        cmd.Parameters.AddWithValue("@nombre", nombreEstudiante);
                        cmd.Parameters.AddWithValue("@apellido", apellidoEstudiante);
                        cmd.ExecuteNonQuery();
                    }
                    conexion.Close();
                }
            }
        
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(textBox2.Text, out decimal monto))
            {
                MessageBox.Show("Ingrese un monto válido.");
                return;
            }

            // Lista de meses en orden
           

            // Mes seleccionado
            int mesInicio = comboBox1.SelectedIndex;
            if (mesInicio == -1)
            {
                MessageBox.Show("Seleccione un mes.");
                return;
            }
            int mesesDisponibles = meses.Length - mesInicio;
            decimal maximoRepartible = mesesDisponibles * 50;

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
            int i = mesInicio;
            int mesfinal = mesInicio;
            while (monto > 0 && i < meses.Length)
            {
                if (monto >= 50)
                {
                    valoresMes[meses[i]] = 50;
                    monto -= 50;
                }
                else
                {
                    valoresMes[meses[i]] = monto;
                    monto = 0;
                }
                i++;
                mesInicio++;
            }

            // Generar el INSERT dinámico
            string colmeses = string.Join(", ", meses);
            string valmeses = string.Join(", ", meses.Select(m => "@" + m));
            string query = $"INSERT INTO Pagos ({colmeses}) VALUES ({valmeses})";


            conexion.Open();
            using (SqlCommand cmd = new SqlCommand(query, conexion))
            {
                foreach (var mes in meses)
                {
                    cmd.Parameters.AddWithValue("@" + mes, valoresMes[mes]);
                }
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Pago insertado correctamente.");
            conexion.Close();
            registros();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                filaSeleccionada = e.RowIndex;
                columnaSeleccionada = e.ColumnIndex;
            }
        }
    }
}
