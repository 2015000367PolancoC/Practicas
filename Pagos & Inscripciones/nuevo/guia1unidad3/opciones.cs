using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Borrador4
{
    public partial class opciones : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=192.168.68.51,9898;Initial Catalog=registros;User ID = gary; Password = zY-Oh_vQzPc[FYWf");
        //SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=registros;Integrated Security = true");
        string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre" };
        public opciones()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.mensualidad = int.Parse(textBox1.Text);
            Properties.Settings.Default.Inscripcion = int.Parse(textBox2.Text);
            Properties.Settings.Default.Save();
            Close();
        }

        private void opciones_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.mensualidad.ToString();
            textBox2.Text = Properties.Settings.Default.Inscripcion.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string consulta = "";
            DialogResult dialogResult = MessageBox.Show("Estas seguro? Esto borrara TODOS los pagos, esto solo se deberia de activar a fin de año", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                conexion.Open();
                for (int i = 0; i < 10; i++)
                {
                    consulta = $"UPDATE pagos SET {meses[i]} = 0, {meses[i] + "E"} = 0, {meses[i] + "FE"} = NULL,FechaPago = null, FechaEntrega = null;" +
                                $"UPDATE inscripciones SET monto = 0,fechapago = null";
                    SqlCommand comando = new SqlCommand(consulta, conexion);
                    comando.ExecuteNonQuery();
                }
                conexion.Close();
            }
        }
    }
}
