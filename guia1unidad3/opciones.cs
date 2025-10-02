using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace Borrador4
{
    public partial class opciones : Form
    {
        //SqlConnection conexion = new SqlConnection("Data Source=192.168.68.51,9898;Initial Catalog=registros;User ID = gary; Password = zY-Oh_vQzPc[FYWf");
        SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=registros;Integrated Security = true");
        string[] meses = { "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre" };
        public opciones()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.mensualidad = int.Parse(textBox1.Text);
            Properties.Settings.Default.InscripcionBAS1 = int.Parse(textBox2.Text);
            Properties.Settings.Default.FechaMora = dateTimePicker1.Value;
            textBox3.Text = Properties.Settings.Default.InscripcionBAC1.ToString();
            Properties.Settings.Default.Save();
            Close();
        }

        private void opciones_Load(object sender, EventArgs e)
        {
            textBox2.Text = Properties.Settings.Default.InscripcionBAS1.ToString();
            textBox3.Text = Properties.Settings.Default.InscripcionBAC1.ToString();
            textBox4.Text = Properties.Settings.Default.InscripcionBAS2.ToString();
            textBox5.Text = Properties.Settings.Default.InscripcionBAC2.ToString();
            dateTimePicker1.Value = Properties.Settings.Default.FechaMora;
            textBox1.Text = Properties.Settings.Default.mensualidad.ToString();
            groupBox1.Text += Properties.Settings.Default.FechaMora.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            groupBox2.Text += Properties.Settings.Default.FechaMora.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string consulta = "";
            DialogResult dialogResult = MessageBox.Show("Estas seguro? Esto borrara TODOS los pagos, esto solo se debería  de activar a fin de año y después de crear reportes para tener un respaldo", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
