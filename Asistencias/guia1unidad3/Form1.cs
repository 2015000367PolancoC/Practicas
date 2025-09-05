using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace guia1unidad3
{
    public partial class Form1 : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=LAB-A-PC27\\SQLEXPRESS;Initial Catalog=Guia1U3;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }
        private void registros()
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter("SELECT * FROM postres", conexion);
                DataSet d = new DataSet();
                comando.Fill(d,"nombre");
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
            conexion.Open();
            MessageBox.Show("Conexión exitosa");
            conexion.Close();
            MessageBox.Show("Conexión cerrada");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                }
                else
                {
                    conexion.Open();
                    SqlCommand comando = new SqlCommand("INSERT INTO postres VALUES (@Nombre, @Precio,@Descripcion,@Tamaño, @Stock)", conexion);
                    comando.Parameters.AddWithValue("@Nombre", textBox1.Text);
                    comando.Parameters.AddWithValue("@Precio", textBox2.Text);
                    comando.Parameters.AddWithValue("@Descripcion", textBox4.Text);
                    comando.Parameters.AddWithValue("@Tamaño", textBox5.Text);
                    comando.Parameters.AddWithValue("@Stock", Convert.ToInt32(textBox3.Text));
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

        private void Form1_Load(object sender, EventArgs e)
        {
            registros();
        }
    }
}

// LAB-A-PC27\SQLEXPRESS