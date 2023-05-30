Imports USB_Barcode_Scanner

Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.Data.Odbc.OdbcCommand
Imports MySql.Data.MySqlClient
Imports System.IO
Imports Microsoft.VisualBasic.FileIO.TextFieldParser
Imports Pedidos_Inventario_EESS.Funciones

Public Class EESS_Pedidos
    Public pedidos_list As New List(Of Pedidos)()
    Public editIndex As Integer
    WithEvents barcodeScanner As BarcodeScanner
    'Para no olvidar, instancias una unica version de Funciones pero que sea global, asi no tienes porque iniciarla y guardar los parametros para las siguientes
    Public funciones As Funciones = New Funciones
    Public isLogged As Boolean
    Private Sub CBEstacion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CBEstacion.KeyPress
        e.Handled = True
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        isLogged = False
        barcodeScanner = New BarcodeScanner(txtBoxObjeto)
        funciones.set_estaciones()
        CBEstacion.SelectedIndex = 0
        funciones.revisar_lista()


    End Sub
    Private Sub barcodeScanner_BarcodeScanned(sender As Object, e As BarcodeScannerEventArgs) Handles barcodeScanner.BarcodeScanned
        'Esto se encarga de leer el codigo de barras
        funciones.nombre_V2 = ""
        funciones.poscode_resultado = ""
        funciones.nombre_V2 = e.Barcode
        ' funciones.buscar_poscode()
        funciones.buscar_codigo_item()
        If funciones.existe_item = True Then
            funciones.buscar_nombre_item_v2()

        End If


    End Sub

    Private Sub btnguardar_Click(sender As Object, e As EventArgs) Handles btnguardar.Click
        funciones.guardar_lista_mod()
        MsgBox("Se ha guardado correctamente")


    End Sub

    Private Sub btneliminar_Click(sender As Object, e As EventArgs) Handles btneliminar.Click
        funciones.eliminar_pedido(listPedidos.SelectedIndex)

    End Sub

    Private Sub btnañadir_Click(sender As Object, e As EventArgs) Handles btnañadir.Click
        funciones.es_pack()

        funciones.generar_pedido()
        txtBoxObjeto.Clear()


    End Sub

    Private Sub btneditar_Click(sender As Object, e As EventArgs) Handles btneditar.Click
        If listPedidos.SelectedIndex = -1 Then
            MsgBox("Selecciona el pedido a editar")
        Else
            editIndex = listPedidos.SelectedIndex
            funciones.editForm = New Form2()
            funciones.editForm.ShowDialog()
        End If

    End Sub

    Private Sub AdministrarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AdministrarToolStripMenuItem.Click
        funciones.loginform = New Form3()
        funciones.loginform.ShowDialog()

    End Sub

    Private Sub btnenviar_Click(sender As Object, e As EventArgs) Handles btnenviar.Click

        funciones.SimpleReadWriteTest()
        funciones.inserts_BD()
        funciones.espdf = True
        funciones.adjunto = New System.Net.Mail.Attachment(funciones.rutaExcel)

        funciones.envio_correo()



    End Sub

    Private Sub CBEstacion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CBEstacion.SelectedIndexChanged
        If isLogged = True Then
            funciones.revisar_lista_por_estaciones(funciones.usuario)

        End If
    End Sub

    Private Sub BusquedaPorProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BusquedaPorProductoToolStripMenuItem.Click
        funciones.listsemana = False
        funciones.listadoform = New Listado()
        funciones.listadoform.LVListado.Columns.Item(2).Width = 0
        funciones.listadoform.LVListado.Columns.Item(3).Width = 0
        funciones.listadoform.LVListado.Columns.Item(1).Width = 560
        funciones.listadoform.TXTBsemana.Visible = False
        funciones.listadoform.lbsemana.Visible = False
        funciones.listadoform.ShowDialog()

    End Sub

    Private Sub BusquedaPorSemanasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BusquedaPorSemanasToolStripMenuItem.Click
        funciones.listsemana = True
        funciones.listadoform = New Listado()
        funciones.listadoform.btnadd.Hide()

        funciones.listadoform.ShowDialog()
    End Sub

    Private Sub AyudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaToolStripMenuItem.Click
        funciones.ayudaform = New Ayuda()
        funciones.ayudaform.ShowDialog()


    End Sub

    Private Sub ReclamarPedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReclamarPedidoToolStripMenuItem.Click
        funciones.reclamacionform = New Reclamacion()
        funciones.reclamacionform.ShowDialog()
    End Sub

    Private Sub cbCaja_CheckedChanged(sender As Object, e As EventArgs) Handles cbCaja.CheckedChanged

    End Sub
End Class
