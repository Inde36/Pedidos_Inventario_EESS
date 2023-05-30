Imports Pedidos_Inventario_EESS.EESS_Pedidos
Imports Pedidos_Inventario_EESS.Funciones

Public Class Form2
    Public pedidos_list As New List(Of Funciones.Pedidos)()
    Public editIndex As Integer
    Dim funciones As Funciones


    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click

        editIndex = EESS_Pedidos.editIndex
        'funciones = New Funciones
        EESS_Pedidos.funciones.modificar_unidades(editIndex, Convert.ToInt32(txtbeditunidades.Text))
        Me.Close()

    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class