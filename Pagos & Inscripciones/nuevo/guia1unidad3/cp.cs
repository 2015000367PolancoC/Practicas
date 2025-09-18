using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace Borrador4
{
    public partial class cp : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=registros;Integrated Security=True");
        public cp()
        {
            InitializeComponent();
            Registros();
        }
        private void Registros()
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter("select id,NombreEstudiante + ' ' +ApellidoEstudiante AS 'Nombre del alumno',DATEDIFF(YEAR,fechanacimiento,GETDATE()) AS 'Edad',CONCAT(beca,'%') AS '% Beca' from alumno", conexion);
                // SqlDataAdapter comando2 = new SqlDataAdapter("select id as 'ID de estudiante',NombreEstudiante as 'Nombre de Estudiante',ApellidoEstudiante as 'Apellido de Estudiante',Enero,Febrero,Marzo,Abril,Mayo,Junio,Julio,Agosto,Septiembre,Octubre from inscripciones;", conexion);
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
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
