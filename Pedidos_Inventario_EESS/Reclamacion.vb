Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Office.Interop.Excel
Imports System.Data.OleDb
Imports Pedidos_Inventario_EESS
Public Class Reclamacion

    Public Sub Reclamacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lvlista.View = View.Details
        lvlista.MultiSelect = True
        lvlista.Columns.Add("Producto", 210)
        lvlista.Columns.Add("Codigo", 110)
        lvlista.Columns.Add("Unidades", 90)
        lvlista.Columns.Add("Estacion", 90)
        lvlista.Columns.Add("Semana", 90)
        lvlista.Columns.Add("Preparado", 90)
        lvlista.Columns.Add("Recepcionado", 90)
        lvlista.GridLines = True
        Dim connStr As String = "Provider=Microsoft.ACE.OLEDB.12.0;data source =  S:\10.02 Gwin_BALONES\Z_programas Andres\Pedidos (En prueba)\Excel\pedidos_semana40.xlsx;extended properties=excel 12.0;"
        Dim conn As New OleDb.OleDbConnection(connStr)

        conn.Open()
        Dim cmd As New OleDbCommand("Select * from [Hoja1$]", conn)
        Dim da As OleDbDataReader = cmd.ExecuteReader
        Do While da.Read = True
            Dim list1 = lvlista.Items.Add(da(0))
            list1.Subitems.Add(da(1))
            list1.Subitems.Add(da(2))
            list1.Subitems.Add(da(3))
            list1.Subitems.Add(da(4))

        Loop
        conn.Close()
    End Sub
End Class