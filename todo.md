private void ExportSqlTableToExistingExcel(string filePath)
{
    SqlDataAdapter da = new SqlDataAdapter("SELECT a.nombres_alumno AS 'Nombre',a.apellidos_alumno AS 'Apellido', a.grado AS 'Grado', s.fecha AS 'Fecha',s.estado AS 'Presente' from info_alumnos a INNER JOIN asistencias s ON a.id_alumno = s.id_alumno", conexion);
    DataTable dt = new DataTable();
    da.Fill(dt);

    // Abre el archivo existente
    using (var package = new ExcelPackage(new System.IO.FileInfo(filePath)))
    {
        // Usa la primera hoja o crea una si no existe
        var worksheet = package.Workbook.Worksheets.FirstOrDefault() ?? package.Workbook.Worksheets.Add("Sheet1");

        // Opcional: limpia la hoja antes de escribir (si quieres sobrescribir)
        worksheet.Cells.Clear();

        // Escribe encabezados
        for (int i = 0; i < dt.Columns.Count; i++)
        {
            worksheet.Cells[1, i + 1].Value = dt.Columns[i].ColumnName;
        }

        // Escribe filas
        for (int x = 0; x < dt.Rows.Count; x++)
        {
            for (int y = 0; y < dt.Columns.Count; y++)
            {
                worksheet.Cells[x + 2, y + 1].Value = dt.Rows[x][y];
            }
        }

        package.Save();
    }
}
