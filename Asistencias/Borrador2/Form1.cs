using System;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Borrador2
{
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=asistencias_control;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        private void registros()
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter("SELECT clave, nombres_alumno, apellidos_alumno, grado, fecha_actual FROM asistencias_clase;", conexion);
                DataSet d = new DataSet();
                comando.Fill(d, "nombres_alumno");
                dataGridView1.DataSource = d.Tables["nombres_alumno"].DefaultView;
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

        private void Form1_Load(object sender, EventArgs e)
        {
            registros();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.Text == "" || textBox4.Text == "")
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
                else
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("INSERT INTO asistencias_clase (nombres_alumno,apellidos_alumno,grado,clave,fecha_actual) VALUES (@nombres_alumno,@apellidos_alumno,@grado,@clave,@fecha_actual)", conexion);
                    /*comando.Parameters.AddWithValue("@fecha_actual", dateTimePicker1.Value);*/
                    comando.Parameters.AddWithValue("@clave", Convert.ToInt32(textBox4.Text));
                    comando.Parameters.AddWithValue("@nombres_alumno", textBox1.Text);
                    comando.Parameters.AddWithValue("@apellidos_alumno", textBox2.Text);
                    comando.Parameters.AddWithValue("@Grado", comboBox1.Text);
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
    }
    }
