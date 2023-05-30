
Imports Pedidos_Inventario_EESS.EESS_Pedidos
Imports Pedidos_Inventario_EESS.Funciones


Public Class Listado
    Private Sub btnbuscar_Click(sender As Object, e As EventArgs) Handles btnbuscar.Click
        If EESS_Pedidos.funciones.listsemana = False Then

            LVListado.Items.Clear()
            EESS_Pedidos.funciones.buscar_porObjeto(TXTBnombre.Text)
        Else
            LVListado.Items.Clear()
            EESS_Pedidos.funciones.buscar_porObjeto(TXTBnombre.Text, TXTBsemana.Text, EESS_Pedidos.funciones.idEstacion)
        End If

    End Sub

    Private Sub Listado_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EESS_Pedidos.Hide()
    End Sub
    Private Sub onClose(sender As Object, e As FormClosedEventArgs) Handles MyBase.Closed
        EESS_Pedidos.Show()
    End Sub

    Private Sub btnadd_Click(sender As Object, e As EventArgs) Handles btnadd.Click
        Dim ind As Integer = CInt(LVListado.SelectedItems(0).Index)
        EESS_Pedidos.funciones.nombrelistado = LVListado.Items(ind).SubItems(0).Text
        EESS_Pedidos.funciones.codigolistado = LVListado.Items(ind).SubItems(1).Text
        EESS_Pedidos.funciones.añadirPorObjeto()
        Dim Pregunta As String

        Pregunta = MsgBox("¿Desea buscar otro articulo?", vbYesNo + vbQuestion)

        If Pregunta = vbNo Then

            Me.Close()

        End If
    End Sub

    Private Sub LVListado_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles LVListado.ColumnClick
        If LVListado.Sorting = SortOrder.Ascending Then
            LVListado.Sorting = SortOrder.Descending
        Else
            LVListado.Sorting = SortOrder.Ascending
        End If
        LVListado.Sort()
    End Sub
End Class