Imports USB_Barcode_Scanner

Imports System.Windows.Forms
Imports System.Data.SqlClient
Imports System.Data.Odbc
Imports System.Data.Odbc.OdbcCommand
Imports MySql.Data.MySqlClient
Imports System.IO
Imports Microsoft.VisualBasic.FileIO.TextFieldParser
Imports Pedidos_Inventario_EESS.EESS_Pedidos
Imports Pedidos_Inventario_EESS.Form2
Imports Microsoft.Office.Interop
Imports System.Web.Mail
Imports ExcelLibrary.SpreadSheet

Imports Microsoft.Office.Interop.Excel.XlFileFormat

Public Class Funciones
    Dim cnn As MySqlConnection
    Dim conexion As String
    WithEvents barcodeScanner As BarcodeScanner
    Public nombreBuscar As String
    Public nombre_V2 As String
    Dim contador As Integer
    Dim consultaSqlCustomer As String

    Public poscode_resultado As String
    Dim nombre_resultado As String
    Dim acol As String
    Dim fcol As String
    Public esta_enviado As Boolean
    Public existe_item As Boolean
    Dim pedido_repetido As Boolean
    Dim pedido_check As New Pedidos
    Dim index_pedido As Integer
    Dim sum1 As Integer
    Dim sum2 As Integer
    Dim i As Integer
    Dim objWriter As StreamWriter
    Dim txtlog As String
    Dim lector As StreamReader
    Dim linea As String
    Dim pedido_safe As Pedidos
    Public editForm As Form2
    Dim unidades_pack As Integer
    Dim pedido_mod As Pedidos
    Public loginform As Form3
    Public listadoform As Listado
    Public ayudaform As Ayuda
    Public listsemana As Boolean
    Dim codigo_list As String
    Dim semana_list As String
    Dim unidades_list As String
    Public pedidos_list_semana_anterior As New List(Of Pedidos)()
    Public pedidos_list_actual As New List(Of Pedidos)()
    Public pedidos_list_enviados As New List(Of String)()
    Dim insertSQL As String
    Public idEstacion As Integer
    Public semana As Integer
    Dim year As Integer
    Public usuario As String
    Dim repetido As Boolean
    Dim rutalog As String
    Dim m_Excel As Excel.Application
    Dim objBook As Excel._Workbook
    Public rutaExcel As String
    Dim rutaAdmin As String
    Public nombrelistado As String
    Public codigolistado As String
    Public nombreEstacion As String
    Public reclamacionform As Reclamacion
    'Variables Correo
    Public smtp As New System.Net.Mail.SmtpClient
    Public correo As New System.Net.Mail.MailMessage
    Public espdf As Boolean
    Public cuerpo As String
    Public adjunto As System.Net.Mail.Attachment
    Public asunto As String
    Public pack_bool As Boolean
    Public Class Pedidos

        Public Property unidades_producto
        Public Property nombre_producto

        Public Property estacion_id
        Public Property producto_id
        Public Property semana

        Public Property preparado
        Public Property recepcionado

        Public Property espack


    End Class
    Public Sub eliminar_pedido(ByVal index As Integer)


        EESS_Pedidos.pedidos_list.Remove(EESS_Pedidos.pedidos_list(index))
        EESS_Pedidos.listPedidos.Items.RemoveAt(index)

    End Sub
    Public Sub modificar_unidades(ByVal index As Integer, ByVal num As Integer)



        EESS_Pedidos.pedidos_list(index).unidades_producto = (num).ToString

        EESS_Pedidos.listPedidos.Items.Clear()
        cargar_lista()

    End Sub
    Public Sub sumar_unidades(ByVal index As Integer, ByVal num As Integer)
        sum1 = EESS_Pedidos.pedidos_list(index).unidades_producto



        EESS_Pedidos.pedidos_list(index).unidades_producto = (sum1 + num).ToString
        EESS_Pedidos.listPedidos.Items.Clear()

    End Sub

    Public Function comprobar_pedido() As Boolean
        i = 0

        For Each ped As Pedidos In EESS_Pedidos.pedidos_list
            If ped.nombre_producto = pedido_check.nombre_producto Then
                sumar_unidades(i, pedido_check.unidades_producto)

                Return True
            End If
            i += 1
        Next
        Return False
    End Function
    Public Sub cargar_lista()
        EESS_Pedidos.listPedidos.Items.Clear()

        contador = 0
        If EESS_Pedidos.pedidos_list.Count = 0 Then

        Else

            If EESS_Pedidos.cbCaja.Checked Then
                Do
                    If EESS_Pedidos.pedidos_list(contador).unidades_producto = 1 Then
                        EESS_Pedidos.listPedidos.Items.Add(EESS_Pedidos.pedidos_list(contador).nombre_producto & " ( 1 Caja o pack ) ")

                        contador = contador + 1
                    Else


                        EESS_Pedidos.listPedidos.Items.Add(EESS_Pedidos.pedidos_list(contador).nombre_producto & " ( " & EESS_Pedidos.pedidos_list(contador).unidades_producto & " Cajas o packs ) ")
                        contador = contador + 1
                    End If

                Loop Until contador = EESS_Pedidos.pedidos_list.Count
            Else
                Do
                    If EESS_Pedidos.pedidos_list(contador).espack = "False" Or EESS_Pedidos.pedidos_list(contador).espack = "" Then
                        EESS_Pedidos.listPedidos.Items.Add(EESS_Pedidos.pedidos_list(contador).nombre_producto & " (" & EESS_Pedidos.pedidos_list(contador).unidades_producto & " unidades)")
                        contador = contador + 1


                    Else
                        EESS_Pedidos.listPedidos.Items.Add(EESS_Pedidos.pedidos_list(contador).nombre_producto & " (" & EESS_Pedidos.pedidos_list(contador).unidades_producto & "Cajas o pack )")
                        contador = contador + 1

                    End If

                Loop Until contador = EESS_Pedidos.pedidos_list.Count
            End If

        End If


    End Sub
    Public Sub generar_pedido()
        EESS_Pedidos.listPedidos.Items.Clear()
        Dim fechamod As Date = CDate(Now)
        generar_semana(fechamod)
        If EESS_Pedidos.cbCaja.Checked Then
            pedido_check = New Pedidos With {.estacion_id = idEstacion,
        .nombre_producto = nombre_resultado, .producto_id = nombreBuscar, .unidades_producto = EESS_Pedidos.txtBoxUnidades.Text, .semana = semana, .espack = "True"}
            pedido_repetido = comprobar_pedido()
        Else
            pedido_check = New Pedidos With {.estacion_id = idEstacion,
        .nombre_producto = nombre_resultado, .producto_id = nombreBuscar, .unidades_producto = EESS_Pedidos.txtBoxUnidades.Text, .semana = semana, .espack = "False"}
            pedido_repetido = comprobar_pedido()
        End If

        If pedido_repetido = True Then
            cargar_lista()


        Else
            EESS_Pedidos.pedidos_list.Add(pedido_check)
            cargar_lista()
        End If


    End Sub
    Public Sub set_estaciones()
        lector = My.Computer.FileSystem.OpenTextFileReader(Application.StartupPath + "/estaciones.txt")
        EESS_Pedidos.CBEstacion.Items.Clear()
        linea = lector.ReadLine()
        Dim fechamod As Date = CDate(Now)
        generar_semana(fechamod)
        If linea IsNot Nothing Then
            idEstacion = linea
            Select Case linea
                Case 1
                    EESS_Pedidos.CBEstacion.Items.Add("11.Textiles")
                    EESS_Pedidos.CBEstacion.SelectedIndex = 0
                    rutaAdmin = Application.StartupPath + "\pedidos.txt"
                    rutalog = Application.StartupPath + "\log.txt"
                    rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"
                Case 2
                    EESS_Pedidos.CBEstacion.Items.Add("12.Balones")
                    nombreEstacion = "2.Balones"
                    EESS_Pedidos.CBEstacion.SelectedIndex = 0
                    rutaAdmin = Application.StartupPath + "\pedidos.txt"
                    rutalog = Application.StartupPath + "\log.txt"
                    rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"

                Case 3
                    EESS_Pedidos.CBEstacion.Items.Add("13.Aldaia")
                    EESS_Pedidos.CBEstacion.SelectedIndex = 0
                    rutaAdmin = Application.StartupPath + "\pedidos.txt"
                    rutalog = Application.StartupPath + "\log.txt"
                    rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"
                Case 4
                    EESS_Pedidos.CBEstacion.Items.Add("14.Genoves")
                    EESS_Pedidos.CBEstacion.SelectedIndex = 0
                    rutaAdmin = Application.StartupPath + "\pedidos.txt"
                    rutalog = Application.StartupPath + "\log.txt"
                    rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"
                Case 5
                    EESS_Pedidos.CBEstacion.Items.Add("21.Gandia")
                    EESS_Pedidos.CBEstacion.SelectedIndex = 0
                    rutaAdmin = Application.StartupPath + "\pedidos.txt"
                    rutalog = Application.StartupPath + "\log.txt"
                    rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"
                Case 6
                    EESS_Pedidos.CBEstacion.Items.Add("22.Naquera")
                    EESS_Pedidos.CBEstacion.SelectedIndex = 0
                    rutaAdmin = Application.StartupPath + "\pedidos.txt"
                    rutalog = Application.StartupPath + "\log.txt"
                    rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"
                Case 7
                    EESS_Pedidos.CBEstacion.Items.Add("23.Albal")
                    EESS_Pedidos.CBEstacion.SelectedIndex = 0
                    rutaAdmin = Application.StartupPath + "\pedidos.txt"
                    rutalog = Application.StartupPath + "\log.txt"
                    rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"
                Case 8
                    EESS_Pedidos.CBEstacion.Items.Add("31.Carolina")
                    EESS_Pedidos.CBEstacion.SelectedIndex = 0
                    rutaAdmin = Application.StartupPath + "\pedidos.txt"
                    rutalog = Application.StartupPath + "\log.txt"
                    rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"
            End Select

        End If
        lector.Close()

    End Sub

    Public Sub set_estaciones_login(ByVal user As String)
        EESS_Pedidos.CBEstacion.Items.Clear()

        usuario = user
        EESS_Pedidos.isLogged = True
        EESS_Pedidos.btnenviar.Enabled = True
        EESS_Pedidos.btnenviar.Visible = True
        Select Case user
            Case "Dani"

                EESS_Pedidos.CBEstacion.Items.Add("13.Aldaia")
                EESS_Pedidos.CBEstacion.Items.Add("22.Naquera")
                EESS_Pedidos.CBEstacion.Items.Add("23.Albal")
                EESS_Pedidos.CBEstacion.Items.Add("31.Carolina")
                EESS_Pedidos.CBEstacion.SelectedIndex = 0
                revisar_lista_por_estaciones(user)
            Case "Jorge"
                EESS_Pedidos.CBEstacion.Items.Add("11.Textiles")
                EESS_Pedidos.CBEstacion.Items.Add("12.Balones")
                EESS_Pedidos.CBEstacion.Items.Add("14.Genoves")
                EESS_Pedidos.CBEstacion.Items.Add("21.Gandia")
                EESS_Pedidos.CBEstacion.SelectedIndex = 0
                revisar_lista_por_estaciones(user)
        End Select

    End Sub
    Public Sub revisar_lista_por_estaciones(ByVal user As String)
        'revisa si un admin esta logeado, si es asi les muestra las estaciones que les corresponden a cada uno de ellos
        'modificar la ruta respecto a cada usuario
        EESS_Pedidos.listPedidos.Items.Clear()
        Select Case user
            Case "Dani"
                Select Case EESS_Pedidos.CBEstacion.SelectedIndex
                    Case 0
                        rutaAdmin = ""
                        EESS_Pedidos.pedidos_list.Clear()
                        rutaAdmin = Application.StartupPath + "\pedidos.txt"
                        lector = My.Computer.FileSystem.OpenTextFileReader(rutaAdmin)
                        rutalog = Application.StartupPath + "\log.txt"
                        rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"

                        idEstacion = 3

                    Case 1
                        rutaAdmin = ""
                        EESS_Pedidos.pedidos_list.Clear()
                        rutaAdmin = Application.StartupPath + "\pedidos.txt"
                        lector = My.Computer.FileSystem.OpenTextFileReader(rutaAdmin)
                        rutalog = Application.StartupPath + "\log.txt"
                        rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"
                        idEstacion = 6

                    Case 2
                        rutaAdmin = ""
                        EESS_Pedidos.pedidos_list.Clear()
                        rutaAdmin = Application.StartupPath + "\pedidos.txt"
                        lector = My.Computer.FileSystem.OpenTextFileReader(rutaAdmin)
                        rutalog = Application.StartupPath + "\log.txt"
                        rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"
                        idEstacion = 7

                    Case 3
                        rutaAdmin = ""
                        EESS_Pedidos.pedidos_list.Clear()
                        rutaAdmin = Application.StartupPath + "\pedidos.txt"
                        lector = My.Computer.FileSystem.OpenTextFileReader(rutaAdmin)
                        rutalog = Application.StartupPath + "\log.txt"
                        rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"
                        idEstacion = 8

                End Select
            Case "Jorge"
                Select Case EESS_Pedidos.CBEstacion.SelectedIndex
                    Case 0
                        rutaAdmin = ""
                        EESS_Pedidos.pedidos_list.Clear()
                        rutaAdmin = Application.StartupPath + "\pedidos.txt"

                        lector = My.Computer.FileSystem.OpenTextFileReader(rutaAdmin)
                        rutalog = Application.StartupPath + "\log.txt"
                        rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"
                        idEstacion = 1
                    Case 1
                        rutaAdmin = ""
                        EESS_Pedidos.pedidos_list.Clear()
                        rutaAdmin = Application.StartupPath + "\pedidos.txt"

                        lector = My.Computer.FileSystem.OpenTextFileReader(rutaAdmin)
                        rutalog = Application.StartupPath + "\log.txt"
                        rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"


                        idEstacion = 2
                    Case 2
                        rutaAdmin = ""
                        EESS_Pedidos.pedidos_list.Clear()
                        rutaAdmin = Application.StartupPath + "\pedidos.txt"

                        lector = My.Computer.FileSystem.OpenTextFileReader(rutaAdmin)
                        rutalog = Application.StartupPath + "\log.txt"
                        rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"
                        idEstacion = 4
                    Case 3
                        rutaAdmin = ""
                        EESS_Pedidos.pedidos_list.Clear()
                        rutaAdmin = Application.StartupPath + "\pedidos.txt"
                        lector = My.Computer.FileSystem.OpenTextFileReader(rutaAdmin)
                        rutalog = Application.StartupPath + "\log.txt"
                        rutaExcel = Application.StartupPath + "\Excel\pedidos_semana" & semana & ".xls"
                        idEstacion = 5
                End Select

        End Select
                Do
            linea = lector.ReadLine()

            If linea IsNot Nothing Then




                Dim lineaArray() As String = Split(linea, ";")
                If lineaArray(4) = semana Then

                    If lineaArray(5).ToString = "True" Then
                        pedido_safe = New Pedidos With {.estacion_id = idEstacion,
            .nombre_producto = lineaArray(2).ToString, .producto_id = lineaArray(1).ToString, .unidades_producto = lineaArray(3).ToString, .semana = lineaArray(4).ToString, .espack = "Si"}
                        EESS_Pedidos.pedidos_list.Add(pedido_safe)
                    Else
                        pedido_safe = New Pedidos With {.estacion_id = idEstacion,
                                    .nombre_producto = lineaArray(2).ToString, .producto_id = lineaArray(1).ToString, .unidades_producto = lineaArray(3).ToString, .semana = lineaArray(4).ToString, .espack = "NO"}
                        EESS_Pedidos.pedidos_list.Add(pedido_safe)


                    End If



                End If




            Else
                Exit Do
            End If
        Loop
        lector.Close()

        cargar_lista()
    End Sub
    Public Sub revisar_lista()
        'lee el documento en busca de pedidos, si los tiene, los muestra
        set_estaciones()
        Dim dia

        lector = My.Computer.FileSystem.OpenTextFileReader(rutaAdmin)
        Dim fechamod As Date = CDate(Now)
        generar_semana(fechamod)
        dia = Weekday(fechamod)

        If dia = vbMonday Then

            semana = semana - 1

        End If
        Do
            linea = lector.ReadLine()

            If linea IsNot Nothing Then
                Dim lineaArray() As String = Split(linea, ";")



                If lineaArray(4) = semana Then

                    pedido_safe = New Pedidos With {.estacion_id = lineaArray(0).ToString,
                .nombre_producto = lineaArray(2).ToString, .producto_id = lineaArray(1).ToString, .unidades_producto = lineaArray(3).ToString, .semana = lineaArray(4).ToString, .espack = lineaArray(5)}
                    EESS_Pedidos.pedidos_list.Add(pedido_safe)

                End If



            Else

                Exit Do
            End If
        Loop

        cargar_lista()

        lector.Close()


    End Sub
    Public Sub guardar_lista_mod()
        pedidos_list_semana_anterior.Clear()
        Try
            lector = My.Computer.FileSystem.OpenTextFileReader(rutaAdmin)
            Dim fechamod As Date = CDate(Now)
            generar_semana(fechamod)
            Do
                linea = lector.ReadLine()


                If linea IsNot Nothing Then
                    Dim lineaArray() As String = Split(linea, ";")

                    If lineaArray(4) <> semana Then

                        If EESS_Pedidos.cbCaja.Checked = True Then


                            pedido_safe = New Pedidos With {.estacion_id = lineaArray(0).ToString,
                        .nombre_producto = lineaArray(2).ToString + " (Caja o pack)", .producto_id = lineaArray(1).ToString, .unidades_producto = lineaArray(3).ToString, .semana = lineaArray(4).ToString, .espack = "True"}
                            pedidos_list_semana_anterior.Add(pedido_safe)
                        Else


                            pedido_safe = New Pedidos With {.estacion_id = lineaArray(0).ToString,
                        .nombre_producto = lineaArray(2).ToString + "ert", .producto_id = lineaArray(1).ToString, .unidades_producto = lineaArray(3).ToString, .semana = lineaArray(4).ToString, .espack = "False"}
                            pedidos_list_semana_anterior.Add(pedido_safe)


                        End If

                    End If


                Else

                    Exit Do
                End If
            Loop
            lector.Close()

            My.Computer.FileSystem.DeleteFile(rutaAdmin)

            If pedidos_list_semana_anterior.Count <> 0 Then
                objWriter = New StreamWriter(rutaAdmin, True)
                contador = 0
                Do

                    txtlog = pedidos_list_semana_anterior(contador).estacion_id & ";" & pedidos_list_semana_anterior(contador).producto_id & ";" & pedidos_list_semana_anterior(contador).nombre_producto & ";" & pedidos_list_semana_anterior(contador).unidades_producto & ";" & pedidos_list_semana_anterior(contador).semana & ";" & pedidos_list_semana_anterior(contador).espack & ";"


                    objWriter.WriteLine(txtlog)
                    contador = contador + 1
                Loop Until contador = pedidos_list_semana_anterior.Count
                objWriter.Close()

            End If
            If EESS_Pedidos.pedidos_list.Count <> 0 Then
                objWriter = New StreamWriter(rutaAdmin, True)



                contador = 0
                Do
                    txtlog = EESS_Pedidos.pedidos_list(contador).estacion_id & ";" & EESS_Pedidos.pedidos_list(contador).producto_id & ";" & EESS_Pedidos.pedidos_list(contador).nombre_producto & ";" & EESS_Pedidos.pedidos_list(contador).unidades_producto & ";" & EESS_Pedidos.pedidos_list(contador).semana & ";" & EESS_Pedidos.pedidos_list(contador).espack & ";"
                    objWriter.WriteLine(txtlog)
                    contador = contador + 1
                Loop Until contador = EESS_Pedidos.pedidos_list.Count
                objWriter.Close()

            End If
        Catch ex As Exception
            MsgBox("No se ha podido guardar la lista ")

        End Try

    End Sub
    Public Sub guardar_lista()
        'borra la lista de pedidos locales y guarda la nueva con las modificaciones
        Dim fechamod As Date = CDate(Now)

        generar_semana(fechamod)
        Try
            My.Computer.FileSystem.DeleteFile(rutaAdmin)
            objWriter = New StreamWriter(rutaAdmin, True)
            If EESS_Pedidos.pedidos_list.Count <> 0 Then

                contador = 0
                Do
                    txtlog = EESS_Pedidos.pedidos_list(contador).estacion_id & ";" & EESS_Pedidos.pedidos_list(contador).producto_id & ";" & EESS_Pedidos.pedidos_list(contador).nombre_producto & ";" & EESS_Pedidos.pedidos_list(contador).unidades_producto & ";" & EESS_Pedidos.pedidos_list(contador).semana & ";" & EESS_Pedidos.pedidos_list(contador).espack

                    objWriter.WriteLine(txtlog)
                    contador = contador + 1
                Loop Until contador = EESS_Pedidos.pedidos_list.Count
                objWriter.Close()


            End If
        Catch ex As Exception
            MsgBox("No se ha podido guardar la lista" & ex.ToString)
        End Try
    End Sub
    Public Sub unix_to_date(ByVal unix As Double)

        Dim dtDate As DateTime
        dtDate = New DateTime(1970, 1, 1, 0, 0, 0, 0)
        dtDate.AddSeconds(unix)

    End Sub
    Public Function conectar_BD() As MySqlConnection

        'conexion = "Database=BBDD_Pedidos;server=127.0.0.1;port=3306;UID=root;Password=gasolinera"
        conexion = "Database=BBDD_Pedidos;server=185.58.196.195;port=3306;UID=Tecnico;Password=gasolinera123"
        cnn = New MySqlConnection(conexion)

        Try
            cnn.Open()

            Return cnn
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

        If cnn.State <> ConnectionState.Open Then

            MsgBox("Error, la conexion no es estable o no esta correctamente abierta")
        End If

    End Function
    Public Sub generar_semana(ByVal strDate As Date)
        'te genera en numero la semana correspondiente
        semana = 0
        semana = DatePart("ww", strDate, vbMonday, vbFirstFullWeek)

        year = DatePart("yyyy", strDate)



    End Sub
    Public Function buscar_porObjeto(ByVal obj As String, Optional ByVal sem As String = "", Optional ByVal est As String = "")

        If listsemana = False Then

            Dim nombrelist As String
            Dim cpnt As Integer
            Try
                nombrelist = Listado.TXTBnombre.Text
                cpnt = 0
                cnn = conectar_BD()
                consultaSqlCustomer =
                "SELECT * " +
                "FROM " +
                "productos " +
                "WHERE Nombre Like '%" + obj + "%';"
            Dim cmd As New MySqlCommand(consultaSqlCustomer)
                cmd.Connection = cnn
                Dim resultado As MySqlDataReader
                resultado = cmd.ExecuteReader
                While resultado.Read


                    If resultado.HasRows() Then
                        cpnt = cpnt + 1

                        nombre_resultado = resultado("Nombre")
                        codigo_list = resultado("Codigos")
                        Dim linea As New ListViewItem(nombre_resultado)

                        linea.SubItems.Add(codigo_list)
                        listadoform.LVListado.Items.Add(linea)



                    End If
                End While
            Catch ex As Exception
                MsgBox("No se ha encontrado el producto, o hay algun error con la busqueda")
            End Try
        Else
            Dim semlist As String
            Dim estalist As String
            Dim nombrelist As String
            Dim cpnt As Integer
            Try
                nombrelist = Listado.TXTBnombre.Text

                cpnt = 0
                cnn = conectar_BD()
                consultaSqlCustomer =
                "SELECT * " +
                "FROM " +
                "pedidos " +
                "WHERE producto_nombre LIKE '%" + obj + "%' AND estacion_id LIKE '%" +
                est + "%' AND semana = '" + sem + "';"
                Dim cmd As New MySqlCommand(consultaSqlCustomer)
                cmd.Connection = cnn
                Dim resultado As MySqlDataReader
                resultado = cmd.ExecuteReader
                While resultado.Read


                    If resultado.HasRows() Then
                        cpnt = cpnt + 1
                        nombre_resultado = resultado("producto_nombre")
                        codigo_list = resultado("producto_id")
                        semana_list = resultado("semana")
                        unidades_list = resultado("unidades_producto")

                        Dim linea As New ListViewItem(nombre_resultado)

                        linea.SubItems.Add(codigo_list)
                        linea.SubItems.Add(semana_list)
                        linea.SubItems.Add(unidades_list)
                        listadoform.LVListado.Items.Add(linea)



                    End If
                End While
            Catch ex As Exception
                MsgBox("No se ha encontrado el producto, o hay algun error con la busqueda")
            End Try
        End If


    End Function
    Public Function añadirPorObjeto()
        EESS_Pedidos.listPedidos.Items.Clear()
        Dim fechamod As Date = CDate(Now)
        generar_semana(fechamod)
        pedido_check = New Pedidos With {.estacion_id = idEstacion,
         .nombre_producto = nombrelistado, .producto_id = codigolistado, .unidades_producto = "1", .semana = semana}
        pedido_repetido = comprobar_pedido()
        If pedido_repetido = True Then
            cargar_lista()


        Else
            EESS_Pedidos.pedidos_list.Add(pedido_check)
            cargar_lista()
        End If
    End Function
    Public Function envio_correo()

        With smtp
            .Port = 587
            .Host = "mail.gasolwin.com"
            .Credentials = New System.Net.NetworkCredential("ontinyent@gasolwin.com", "jMm1JGHtwGrK")
            .EnableSsl = False
        End With

        If espdf = False Then
            With correo
                .From = New System.Net.Mail.MailAddress("ontinyent@gasolwin.com")
                .To.Add("tecnico2@gasolwin.com")
                .Subject = asunto
                .Body = cuerpo
                .Priority = System.Net.Mail.MailPriority.Normal
            End With
        Else

            With correo
                .From = New System.Net.Mail.MailAddress("ontinyent@gasolwin.com")
                .To.Add("tecnico2@gasolwin.com")
                .Subject = "Pedido de esta semana de la estacion " + nombreEstacion
                .Body = "Buenos dias, este es el excel con el pedido de esta semana. Gracias"
                .Attachments.Add(adjunto)
                .Priority = System.Net.Mail.MailPriority.Normal
            End With
        End If



        Try
            smtp.Send(correo)
            MsgBox("Su mensaje ha sido enviado")
        Catch ex As Exception
            MsgBox("Error en el envio de correo")
        End Try

    End Function
    Public Function inserts_BD()
        Try

            'funcion encargada de que los pedidos guardados en local se envien y se inserten en la BD
            Dim fechaactual As Double = (DateTime.Now - New Date(1970, 1, 1, 0, 0, 0)).TotalSeconds
            unix_to_date(fechaactual)
            fechaactual = Math.Round(fechaactual)
            Dim fechamod As Date = CDate(Now)
            generar_semana(fechamod)
            cnn = conectar_BD()
            lector = My.Computer.FileSystem.OpenTextFileReader(rutaAdmin)
            Do
                linea = lector.ReadLine()

                If linea = "" Then

                    envio_log()


                    Exit Do

                Else

                    Dim lineaArray() As String = Split(linea, ";")

                    Dim uni As Integer = Integer.Parse(lineaArray(3))
                    Dim proid As Double = Convert.ToInt64(lineaArray(1))

                    If lineaArray(4) = semana Then

                        insertSQL =
                         " INSERT INTO `pedidos`( `producto_id`, `estacion_id`,  `producto_nombre`, `unidades_producto`, `fecha`, `semana`, `year`  ) 
                             VALUES ('" & proid & "' ,'" & idEstacion & "','" & lineaArray(2) & "','" & uni & "','" & fechaactual & "','" & semana & "','" & year & "')"

                        pedidos_list_enviados.Add(proid & ";" & idEstacion & ";" & lineaArray(2) & ";" & uni & ";" & fechaactual & ";" & semana & ";" & year & ";")

                        Dim cmd As New MySqlCommand(insertSQL, cnn)
                        cmd.ExecuteNonQuery()
                    End If

                End If

            Loop
            MsgBox("Se ha enviado correctamente")
            EESS_Pedidos.listPedidos.Items.Clear()
            lector.Close()
        Catch ex As Exception
            MsgBox("No se ha podido insertar correctamente en la BD " & ex.Message)
        End Try

    End Function
    Public Sub generar_excelV2()
        Dim fechamod As Date = CDate(Now)

        generar_semana(fechamod)
        Try
            If EESS_Pedidos.pedidos_list.Count <> 0 Then
                Dim appXL As Excel.Application
                Dim wbXl As Excel.Workbook
                Dim shXL As Excel.Worksheet
                Dim indice As Integer = 2
                appXL = CreateObject("Excel.Application")
                wbXl = appXL.Workbooks.Add
                shXL = wbXl.ActiveSheet
                Dim formatRange As Excel.Range
                formatRange = shXL.Range("a1")
                formatRange.EntireRow.Font.Bold = True
                shXL.Cells(1, 1).Value = "Producto"
                shXL.Cells(1, 2).Value = "Codigo de barras"
                shXL.Cells(1, 3).Value = "Unidades"
                shXL.Cells(1, 4).Value = "Estacion"
                shXL.Cells(1, 5).Value = "Semana"
                shXL.Cells(1, 6).Value = "Pack"
                shXL.Cells(1, 7).Value = "Recepcionado"
                i = 0
                Do

                    shXL.Cells(indice, 1).Value = EESS_Pedidos.pedidos_list(i).nombre_producto
                    shXL.Cells(indice, 2).Value = EESS_Pedidos.pedidos_list(i).producto_id
                    shXL.Cells(indice, 3).Value = EESS_Pedidos.pedidos_list(i).unidades_producto
                    shXL.Cells(indice, 4).Value = EESS_Pedidos.pedidos_list(i).estacion_id
                    shXL.Cells(indice, 5).Value = EESS_Pedidos.pedidos_list(i).semana
                    shXL.Cells(indice, 6).Value = EESS_Pedidos.pedidos_list(i).espack
                    indice += 1
                    i = i + 1
                Loop Until i = EESS_Pedidos.pedidos_list.Count
                wbXl.SaveAs(rutaExcel, xlOpenXMLWorkbook)
                appXL.Workbooks.Close()
                ' Eliminamos el objeto excel
                appXL.Quit()
                MsgBox("Se ha generado el Excel con exito")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub



    Public Sub SimpleReadWriteTest()
        Dim tempFilePath As String = Application.StartupPath + "\Excel\pedidos_semana" + semana.ToString + ".xls"

        Dim indice As Integer = 2

        i = 0
        If True Then
            Dim workbook As Workbook = New Workbook()
            Dim worksheet As Worksheet = New Worksheet("Pedidos_Semana")

            Dim ruta As String = Application.StartupPath + "\LOGO GASOLWIN.png"
            'logo


            Dim pic As Picture = New Picture
            pic.Image = Image.FromFile(ruta)



            'esto añade la info a las celdas

            worksheet.Cells(0, 1) = New Cell("Producto")

            worksheet.Cells(0, 2) = New Cell("Codigo de barras")

            worksheet.Cells(0, 3) = New Cell("Unidades")
            worksheet.Cells(0, 4) = New Cell("Estacion")
            worksheet.Cells(0, 5) = New Cell("Semana")
            worksheet.Cells(0, 6) = New Cell("Pack o Caja")
            worksheet.Cells(0, 7) = New Cell("Recepcionado")


            Do

                worksheet.Cells(indice, 1) = New Cell(EESS_Pedidos.pedidos_list(i).nombre_producto)
                worksheet.Cells(indice, 2) = New Cell(EESS_Pedidos.pedidos_list(i).producto_id)
                worksheet.Cells(indice, 3) = New Cell(EESS_Pedidos.pedidos_list(i).unidades_producto)
                worksheet.Cells(indice, 4) = New Cell(EESS_Pedidos.pedidos_list(i).estacion_id)
                worksheet.Cells(indice, 5) = New Cell(EESS_Pedidos.pedidos_list(i).semana)
                worksheet.Cells(indice, 6) = New Cell(EESS_Pedidos.pedidos_list(i).espack)
                indice += 1
                i += 1
            Loop Until i = EESS_Pedidos.pedidos_list.Count
            'logo

            worksheet.AddPicture(pic)
            workbook.Worksheets.Add(worksheet)
            workbook.Save(tempFilePath)
        End If

    End Sub
    Private Sub envio_log()
        Dim fechamod As Date = CDate(Now)

        generar_semana(fechamod)
        Try
            objWriter = New StreamWriter(rutalog, True)
            If pedidos_list_enviados.Count <> 0 Then

                contador = 0
                Do
                    txtlog = pedidos_list_enviados(contador)
                    objWriter.WriteLine(txtlog)
                    contador = contador + 1
                Loop Until contador = pedidos_list_enviados.Count
                objWriter.Close()
                pedidos_list_enviados.Clear()


            End If
        Catch ex As Exception
            MsgBox("No se ha podido guardar el log   " & ex.Message)
        End Try
    End Sub
    Public Sub buscar_poscode()
        Try
            'se encarga de identificar si el codigo introducido es correcto
            cnn = conectar_BD()
            consultaSqlCustomer =
            "SELECT * " +
            "FROM " +
            "codigoBarras " +
            "WHERE codbarras = '" + nombre_V2 + "';"
            Dim cmd As New MySqlCommand(consultaSqlCustomer)
            cmd.Connection = cnn
            Dim resultado As MySqlDataReader
            resultado = cmd.ExecuteReader
            Dim cmn As New MySqlCommand(consultaSqlCustomer)


            While resultado.Read
                If resultado.HasRows() Then
                    poscode_resultado = resultado("poscode")
                    buscar_nombre_item()
                End If
            End While


            If poscode_resultado = Nothing Then


                MsgBox("Ese codigo de barras no esta en nuestra BD")
                EESS_Pedidos.txtBoxObjeto.Clear()
            End If
        Catch ex As Exception
            MsgBox("No se ha encontrado el codigo, o no es un codigo de un producto valido" + ex.Message)
        End Try
    End Sub
    Public Sub buscar_codigo_item()
        'ya no se usa por mejora de codigo V2
        Try
            'se encarga de identificar si el codigo introducido es correcto
            cnn = conectar_BD()
            consultaSqlCustomer =
            "SELECT * " +
            "FROM " +
            "productos " +
            "WHERE Codigos = '" + nombre_V2 + "';"
            Dim cmd As New MySqlCommand(consultaSqlCustomer)
            cmd.Connection = cnn
            Dim resultado As MySqlDataReader
            resultado = cmd.ExecuteReader

            While resultado.Read
                If resultado.HasRows() Then
                    poscode_resultado = resultado("Codigos")
                    existe_item = True
                End If
            End While
            If poscode_resultado = Nothing Then
                existe_item = False
                buscar_poscode()


            End If
        Catch ex As Exception
            MsgBox("No se ha encontrado el codigo, o no es un codigo de un producto valido" + ex.Message)
        End Try
    End Sub
    Public Sub buscar_nombre_item()
        'lee el codigo de barras y lo filtra en la BD para que el ususario pueda ver y comprobar el pedido
        Try
            cnn = conectar_BD()
            consultaSqlCustomer =
            "SELECT * " +
            "FROM " +
            "productos " +
            "WHERE ID = '" + poscode_resultado + "';"
            Dim cmd As New MySqlCommand(consultaSqlCustomer)
            cmd.Connection = cnn

            Dim resultado As MySqlDataReader
            resultado = cmd.ExecuteReader
            While resultado.Read
                If resultado.HasRows() Then
                    nombre_resultado = resultado("nombre")


                    EESS_Pedidos.txtBoxObjeto.Text = nombre_resultado

                End If
            End While


        Catch ex As Exception

            MsgBox("No se ha encontrado el producto, o hay algun error con la busqueda")

        End Try
    End Sub
    Public Sub buscar_nombre_item_v2()
        'lee el codigo de barras y lo filtra en la BD para que el usuario pueda ver y comprobar el pedido 


        Try
            cnn = conectar_BD()
            consultaSqlCustomer =
            "SELECT * " +
            "FROM " +
            "productos " +
            "WHERE Codigos = '" + poscode_resultado + "';"
            Dim cmd As New MySqlCommand(consultaSqlCustomer)
            cmd.Connection = cnn
            Dim resultado As MySqlDataReader
            resultado = cmd.ExecuteReader
            While resultado.Read
                If resultado.HasRows() Then
                    nombre_resultado = resultado("nombre")

                    EESS_Pedidos.txtBoxObjeto.Text = nombre_resultado
                End If
            End While
        Catch ex As Exception
            MsgBox("No se ha encontrado el producto, o hay algun error con la busqueda")
        End Try
    End Sub



    Public Sub es_pack()


        If EESS_Pedidos.cbCaja.Checked = True Then
            Try

                cnn = conectar_BD()
                consultaSqlCustomer =
                "SELECT * " +
                "FROM " +
                "codigoBarras " +
                "WHERE poscode = '" + poscode_resultado + "';"
                Dim cmd As New MySqlCommand(consultaSqlCustomer)

                cmd.Connection = cnn
                Dim resultado As MySqlDataReader
                resultado = cmd.ExecuteReader
                While resultado.Read
                    If resultado.HasRows() Then

                        pack_bool = True
                    Else
                        pack_bool = False
                    End If
                End While
            Catch ex As Exception
                MsgBox("No se ha encontrado el producto, o hay algun error con la busqueda")
            End Try
        End If
    End Sub



    Public Sub comprobar_caja()
        If EESS_Pedidos.cbCaja.Checked = True Then
            Try
                'primero deberia de ver si existe en la BBDD un pack para ese objeto, si es asi dejar validar como pack y mostrar solo 1 caja
                'Solo esos productos se veran modificados como pack o cajas, los demas no 
                'se puede modificar el guardado del excel para que guarde y se cargue de forma correcta

                cnn = conectar_BD()

                consultaSqlCustomer =
                "SELECT * " +
                "FROM " +
                "codigoBarras " +
                "WHERE poscode = '" + poscode_resultado + "';"
                Dim cmd As New MySqlCommand(consultaSqlCustomer)
                cmd.Connection = cnn
                'modificar las unidades del pack teniendo en cuenta la anterior, i cargar la lista con las unidades al iniciar, 
                'se tiene que guardar tambien en el log como si fuera un pack i no como un objeto de X unidades

                Dim resultado As MySqlDataReader
                resultado = cmd.ExecuteReader
                While resultado.Read
                    If resultado.HasRows() Then
                        unidades_pack = resultado("cantidad")


                    End If
                End While
            Catch ex As Exception
                MsgBox("No se ha encontrado el producto, o hay algun error con la busqueda")

            End Try
        End If
    End Sub



End Class
