using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Borrador4
{
    public partial class Resumen : Form
    {
        SqlConnection conexion = new SqlConnection("Data Source=localhost\\SQLEXPRESS;Initial Catalog=registros;Integrated Security = true");
        //SqlConnection conexion = new SqlConnection("Data Source=192.168.68.51,9898;Initial Catalog=registros;User ID = gary; Password = zY-Oh_vQzPc[FYWf");
        int ventana = 0;
        bool vista = false;
        public Resumen(string consulta, int vent)
        {
            ventana = vent;
            InitializeComponent();
            generar(consulta);
        }
        public void generar(string query)
        {
            try
            {
                conexion.Open();
                SqlDataAdapter comando = new SqlDataAdapter(query, conexion);
                DataSet d = new DataSet();
                comando.Fill(d, "nombre");
                tabla.DataSource = d.Tables["nombre"].DefaultView;

                tabla.ColumnHeadersDefaultCellStyle.BackColor = Color.MistyRose;
                tabla.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
                tabla.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                foreach (DataGridViewColumn column in tabla.Columns)
                {
                    if (column.Index > 0)
                    {
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.Format = "C2";
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
        private void Resumen_Load(object sender, EventArgs e)
        {
            if (ventana == 1)
            {
                button1.Visible = true;
            }
            if (tabla.Columns[1].Name == "Inscritos")
            {
                tabla.Columns["Inscritos"].DefaultCellStyle.Format = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            vista = !vista;
            if (vista)
            {
                generar("\r\nWITH PagosDesglosados AS (SELECT \r\n    a.Grado,\r\n    'Enero' AS Mes,\r\n    p.Enero AS Monto,\r\n    p.EneroFE AS Fecha\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.EneroE = 1 AND p.EneroFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Febrero' AS Mes,\r\n    p.Febrero,\r\n    p.FebreroFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.FebreroE = 1 AND p.FebreroFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Marzo' AS Mes,\r\n    p.Marzo,\r\n    p.MarzoFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.MarzoE = 1 AND p.MarzoFE IS NOT NULL\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Abril' AS Mes,\r\n    p.Abril,\r\n    p.AbrilFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.AbrilE = 1 AND p.AbrilFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Mayo' AS Mes,  \r\n    p.Mayo,\r\n    p.MayoFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.MayoE = 1 AND p.MayoFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Junio' AS Mes,\r\n    p.Junio,\r\n    p.JunioFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.JunioE = 1 AND p.JunioFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Julio' AS Mes,\r\n    p.Julio,\r\n    p.JulioFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.JulioE = 1 AND p.JulioFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Agosto' AS Mes,\r\n    p.Agosto,\r\n    p.AgostoFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.AgostoE = 1 AND p.AgostoFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Septiembre' AS Mes,\r\n    p.Septiembre,\r\n    p.SeptiembreFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.SeptiembreE = 1 AND p.SeptiembreFE IS NOT NULL\r\n\r\nUNION ALL\r\n\r\nSELECT \r\n    a.Grado,\r\n    'Octubre' AS Mes,\r\n    p.Octubre,\r\n    p.OctubreFE\r\nFROM pagos p\r\nJOIN alumno a ON p.idalumno = a.id\r\nWHERE p.OctubreE = 1 AND p.OctubreFE IS NOT NULL\r\n\r\n)\r\n\r\nSELECT \r\n    Grado,\r\n    Fecha,\r\n    SUM(Monto) AS 'Entregado'\r\n\r\nFROM PagosDesglosados\r\nGROUP BY Grado, Fecha\r\nORDER BY Fecha desc,CASE\r\n\tWHEN grado = 'Primero Básico' THEN 1\r\n\tWHEN grado = 'Segundo Básico' THEN 2\r\n\tWHEN grado = 'Tercero Básico' THEN 3\r\n\tWHEN grado = 'Cuarto Bachillerato' THEN 4\r\n\tWHEN grado = 'Quinto Bachillerato' THEN 5\r\nELSE 1000 END asc;");
                tabla.Columns["Fecha"].DefaultCellStyle.Format = null;
            }
            else
            {
                generar("select Grado, sum(enero + febrero + marzo + abril + mayo + junio + julio + agosto + septiembre + octubre) as 'Total', SUM(CASE WHEN EneroE = 1 THEN Enero ELSE 0 END + CASE WHEN FebreroE = 1 THEN Febrero ELSE 0 END + CASE WHEN MarzoE = 1 THEN Marzo ELSE 0 END + CASE WHEN AbrilE = 1 THEN Abril ELSE 0 END + CASE WHEN MayoE = 1 THEN Mayo ELSE 0 END + CASE WHEN JunioE = 1 THEN Junio ELSE 0 END + CASE WHEN JulioE = 1 THEN Julio ELSE 0 END + CASE WHEN AgostoE = 1 THEN Agosto ELSE 0 END + CASE WHEN SeptiembreE = 1 THEN Septiembre ELSE 0 END + CASE WHEN OctubreE = 1 THEN Octubre ELSE 0 END) AS 'Total Entregado' from pagos inner join alumno on pagos.idalumno = alumno.id group by ROLLUP(grado) ORDER BY CASE WHEN grado = 'Primero Básico' THEN 1 WHEN grado = 'Segundo Básico' THEN 2 WHEN grado = 'Tercero Básico' THEN 3 WHEN grado = 'Cuarto Bachillerato' THEN 4 WHEN grado = 'Quinto Bachillerato' THEN 5 ELSE 1000 END asc");
            }
        }
    }
}
