Imports Pedidos_Inventario_EESS.EESS_Pedidos
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text
Imports Pedidos_Inventario_EESS.Funciones
Public Class Form3
    Dim user As String
    Dim pass As String
    Dim userLogin As String
    Dim passLogin As String
    Dim filereader As StreamReader
    Dim stringreader As String
    Dim txtlog As String
    Dim objWriter As StreamWriter
    Dim pltsin As String
    Dim contadorParam As Integer
    Dim funciones As Funciones
    Dim conexion As String
    Private Sub login(ByVal user As String)

        Select Case user
            Case "Dani"
                EESS_Pedidos.funciones.set_estaciones_login("Dani")
                Me.Close()
            Case "Jorge"
                EESS_Pedidos.funciones.set_estaciones_login("Jorge")
                Me.Close()
            Case Else
                MsgBox("No es un usuario registrado")


        End Select
    End Sub
    Private Sub comprobar_login()
        ' funciones = New Funciones
        user = txtbuser.Text
        pass = txtbcontra.Text
        Select Case user
            Case "Dani"
                EESS_Pedidos.funciones.set_estaciones_login("Dani")
                Me.Close()
            Case "Jorge"
                EESS_Pedidos.funciones.set_estaciones_login("jorge")
                Me.Close()
            Case Else
                MsgBox("No es un usuario registrado")

        End Select

    End Sub
    Sub DecodingPass()
        Dim cipherText As String = My.Computer.FileSystem.ReadAllText(Application.StartupPath + "/code.txt")
        Dim passwd As String = txtbcontra.Text
        Dim wrapper As New Simple3Des(passwd)
        Try
            pltsin = wrapper.DecryptData(cipherText)

            If txtbuser.Text = "Dani" Then

                If pltsin = passwd Then
                    login("Dani")
                Else
                    MsgBox("entra")
                End If

            Else
                If txtbuser.Text = "Jorge" Then
                    If pltsin = passwd Then
                        login("Jorge")
                    Else
                        MsgBox("La contraseña no es correcta")
                    End If

                Else
                    MsgBox("Contraseña o usuario erroneo")
                End If

            End If


        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub EncodingPass()
        objWriter = New StreamWriter(Application.StartupPath + "/code.txt", True)

        Dim passwd As String = txtbcontra.Text
        Dim wrapper As New Simple3Des(passwd)
        Try
            Dim pltext As String = wrapper.EncryptData(passwd)
            MsgBox("el texto es:" + pltext)
            txtlog = pltext
            objWriter.WriteLine(txtlog)
            objWriter.Close()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnaceptar_Click(sender As Object, e As EventArgs) Handles btnaceptar.Click
        DecodingPass()



    End Sub
    Private Sub onClose(sender As Object, e As FormClosedEventArgs) Handles MyBase.Closed
        EESS_Pedidos.Show()
    End Sub
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        EESS_Pedidos.Hide()
    End Sub
End Class
Public NotInheritable Class Simple3Des
    Private TripleDes As New TripleDESCryptoServiceProvider
    Dim sha1 As New SHA1CryptoServiceProvider



    Private Function TruncateHash(ByVal key As String, ByVal length As Integer) As Byte()
        Dim keyBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(key)
        Dim hash() As Byte = sha1.ComputeHash(keyBytes)
        ReDim Preserve hash(length - 1)
        Return hash
    End Function

    Sub New(ByVal key As String)

        TripleDes.Key = TruncateHash(key, TripleDes.KeySize \ 8)
        TripleDes.IV = TruncateHash("", TripleDes.BlockSize \ 8)
    End Sub

    Public Function EncryptData(ByVal pltext As String) As String
        Dim pltextBytes() As Byte = System.Text.Encoding.Unicode.GetBytes(pltext)
        Dim ms As New System.IO.MemoryStream
        Dim encStream As New CryptoStream(ms, TripleDes.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

        encStream.Write(pltextBytes, 0, pltextBytes.Length)
        encStream.FlushFinalBlock()
        Return Convert.ToBase64String(ms.ToArray)

    End Function

    Public Function DecryptData(ByVal encryptedtext As String) As String
        Dim encryptedBytes() As Byte = Convert.FromBase64String(encryptedtext)
        Dim ms As New System.IO.MemoryStream
        Dim decStream As New CryptoStream(ms, TripleDes.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write)

        decStream.Write(encryptedBytes, 0, encryptedBytes.Length)
        decStream.FlushFinalBlock()
        Return System.Text.Encoding.Unicode.GetString(ms.ToArray)
    End Function

End Class