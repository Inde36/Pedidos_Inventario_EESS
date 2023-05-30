

Imports Pedidos_Inventario_EESS.EESS_Pedidos
Imports Pedidos_Inventario_EESS.Funciones
Public Class Ayuda
    Private Sub Ayuda_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EESS_Pedidos.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        EESS_Pedidos.funciones.asunto = "Consulta de error o ayuda de " + TXTNombre.Text + " de la estacion " + TXTEstacion.Text
        EESS_Pedidos.funciones.espdf = False
        EESS_Pedidos.funciones.cuerpo = TXTBConsulta.Text
        EESS_Pedidos.funciones.envio_correo()
        Me.Close()
        EESS_Pedidos.Show()

    End Sub
    Private Sub onClose(sender As Object, e As FormClosedEventArgs) Handles MyBase.Closed
        EESS_Pedidos.Show()
    End Sub
End Class