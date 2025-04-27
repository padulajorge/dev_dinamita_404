Imports MySqlConnector

Public Class GameWindow
    ' Variable para rastrear el segmento actual
    Private segmentoActual As Integer = 0
    ' Hacer que el diccionario sea accesible a nivel de clase
    Private codigosPorSegmento As New Dictionary(Of Integer, String)()
    ' Lista para almacenar los segmentos ordenados
    Private listaSegmentos As New List(Of Integer)()
    ' Timer para el auto-clic
    Private WithEvents autoClicTimer As New Timer()
    Private nivelBucles As Integer = 0 ' Guardamos el nivel de la mejora "Bucles"

    Private Sub GameWindow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AddHandler code_label.MouseDown, AddressOf siguiente_codigo
        fetch_mejoras()
        fetch_bits()
        fetch_code()
        ' SOLO iniciar el Timer si el nivel de Bucles es mayor a 0
        If nivelBucles > 0 Then
            autoClicTimer.Interval = CalcularIntervaloAutoClic(nivelBucles)
            autoClicTimer.Start()
        End If
    End Sub

    Private Sub GameWindow_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' Usar versión síncrona para asegurar que se complete antes del cierre
        enviar_bits_sincrono()
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        enviar_bits()
        If TabControl1.SelectedTab.Text = "Mejoras" Then
            precio_mejoras()
        End If
    End Sub

    Private Sub encapsulamiento_btn_Click(sender As Object, e As EventArgs) Handles encapsulamiento_btn.Click
        Dim btn As Button = DirectCast(sender, Button)
        mejora_handler(btn)
    End Sub

    Private Sub clases_btn_Click(sender As Object, e As EventArgs) Handles clases_btn.Click
        Dim btn As Button = DirectCast(sender, Button)
        mejora_handler(btn)
    End Sub

    Private Sub herencia_btn_Click(sender As Object, e As EventArgs) Handles herencia_btn.Click
        Dim btn As Button = DirectCast(sender, Button)
        mejora_handler(btn)
    End Sub

    Private Sub agregacion_btn_Click(sender As Object, e As EventArgs) Handles agregacion_btn.Click
        Dim btn As Button = DirectCast(sender, Button)
        mejora_handler(btn)
    End Sub

    Private Sub asociacion_btn_Click(sender As Object, e As EventArgs) Handles asociacion_btn.Click
        Dim btn As Button = DirectCast(sender, Button)
        mejora_handler(btn)
    End Sub

    Private Sub bucles_btn_Click(sender As Object, e As EventArgs) Handles bucles_btn.Click
        Dim btn As Button = DirectCast(sender, Button)
        mejora_handler(btn)
    End Sub

    Private Sub autoClicTimer_Tick(sender As Object, e As EventArgs) Handles autoClicTimer.Tick
        siguiente_codigo()
        autoClicTimer.Interval = CalcularIntervaloAutoClic(nivelBucles)
    End Sub

    Private Sub precio_mejoras()
        If Globales.jugadorID > 0 Then
            Dim conexion As New MySqlConnection(Globales.stringConexion)
            Try
                conexion.Open()
                Dim consulta As String =
                    "SELECT mejoras.costo, mejoras.nombre " &
                    "FROM mejoras_jugadores mj " &
                    "JOIN mejoras ON mj.mejora_id = mejoras.id " &
                    "WHERE mj.jugador_id = @jugador_id;"
                Dim comando As New MySqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
                Dim lector As MySqlDataReader = comando.ExecuteReader()
                While lector.Read()
                    Dim costo As Integer = lector.GetInt32("costo")
                    Dim nombre As String = lector.GetString("nombre")
                    If nombre = "Encapsulamiento" Then
                        encapsulamiento_label.Text = costo.ToString()
                    ElseIf nombre = "Clases" Then
                        clases_label.Text = costo.ToString()
                    ElseIf nombre = "Herencia" Then
                        herencia_label.Text = costo.ToString()
                    ElseIf nombre = "Agregación" Then
                        agregacion_label.Text = costo.ToString()
                    ElseIf nombre = "Asociación" Then
                        asociacion_label.Text = costo.ToString()
                    ElseIf nombre = "Bucles" Then
                        bucles_label.Text = costo.ToString()
                    End If
                End While
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                conexion.Close()
            End Try
        Else
            MessageBox.Show("No hay un jugador en el sistema.")
            Form1.Show()
            Me.Close()
        End If
    End Sub

    Private Function CalcularIntervaloAutoClic(nivel As Integer) As Integer
        Dim intervaloBase As Integer = 1000
        Dim reduccionPorNivel As Integer = 100
        Dim intervaloMinimo As Integer = 10

        Dim nuevoIntervalo As Integer = intervaloBase - (nivel * reduccionPorNivel)
        Return Math.Max(nuevoIntervalo, intervaloMinimo)
    End Function

    Private Sub enviar_bits_sincrono()
        Dim conexion As New MySqlConnection(Globales.stringConexion)
        If Globales.jugadorID > 0 Then
            Try
                conexion.Open() ' Versión síncrona
                Dim consulta As String = "UPDATE estadisticas SET bits = @bits WHERE jugador_estadistica_id = @jugador_id;"
                Dim comando As New MySqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@bits", bits_box.Text)
                comando.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
                comando.ExecuteNonQuery() ' Síncrono
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                conexion.Close()
            End Try
        End If
    End Sub

    Private Async Sub enviar_bits()
        Dim conexion As New MySqlConnection(Globales.stringConexion)
        If Globales.jugadorID > 0 Then
            Try
                Await conexion.OpenAsync() ' Uso de la versión asincrónica
                Dim consulta As String =
                    "UPDATE estadisticas SET bits = @bits WHERE jugador_estadistica_id = @jugador_id;"
                Dim comando As New MySqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@bits", bits_box.Text)
                comando.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
                Await comando.ExecuteNonQueryAsync() ' Asíncrono
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                conexion.Close()
            End Try
        Else
            MessageBox.Show("No hay un jugador en el sistema.")
            Form1.Show()
            Me.Close()
        End If
    End Sub

    Private Async Sub siguiente_codigo()
        ' Si no hay elementos en la lista, salir
        If listaSegmentos.Count = 0 Then
            Return
        End If

        ' Obtener el segmento actual
        Dim segmento As Integer = listaSegmentos(segmentoActual)

        ' Mostrar el código correspondiente al segmento actual
        code_label.Text = codigosPorSegmento(segmento)

        ' Incrementar el índice para el siguiente clic
        segmentoActual += 1

        ' Si llegamos al final, volver al principio
        If segmentoActual >= listaSegmentos.Count Then
            segmentoActual = 0
            aumentar_bits(Await bonus_mejoras(8))
        End If
    End Sub

    Private Sub aumentar_bits(cantidad)
        bits_box.Text = (Convert.ToInt32(bits_box.Text) + cantidad).ToString()
    End Sub

    Private Async Function bonus_mejoras(bits As Integer) As Task(Of Integer)
        Dim total As Integer = 8

        If Globales.jugadorID > 0 Then
            Dim conexion As New MySqlConnection(Globales.stringConexion)
            Try
                Await conexion.OpenAsync()
                Dim consulta As String =
                   "SELECT mejoras.id, mj.nivel " &
                   "FROM mejoras_jugadores mj " &
                   "JOIN mejoras ON mj.mejora_id = mejoras.id " &
                   "WHERE mj.jugador_id = @jugador_id;"
                Dim comando As New MySqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
                Dim lector As MySqlDataReader = Await comando.ExecuteReaderAsync()

                ' Procesar los resultados
                While Await lector.ReadAsync()
                    Dim nivel As Integer = lector.GetInt32("nivel")
                    Dim id As Integer = lector.GetInt32("id")

                    ' Calcular el total en función del ID y el nivel
                    Select Case id
                        'encapsulamiento
                        'suma 8 bits por cada nivel de la mejora
                        Case 1
                            total += bits * nivel
                        'clases
                        Case 2
                            If nivel = 0 Then
                                total += 0
                            Else
                                total += bits * Math.Pow(2, nivel)
                            End If
                        'herencia
                        Case 3
                            total += nivel * 2 * bits
                        'agregacion
                        Case 4
                            total += nivel * total
                        'asociacion
                        Case 5
                            total += Math.Pow(8, nivel)
                    End Select
                End While
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                conexion.Close()
            End Try
        Else
            MessageBox.Show("No hay un jugador en el sistema.")
            Form1.Show()
            Me.Close()
        End If
        bits_label.Text = ("+" & total.ToString()) ' Actualiza el label de bits
        Return total
    End Function

    Private Async Sub fetch_mejoras()
        TreeView1.Nodes.Clear()
        Dim nodoRaiz As New TreeNode("Proyecto POO")
        TreeView1.Nodes.Add(nodoRaiz)

        Dim conexion As New MySqlConnection(Globales.stringConexion)
        If Globales.jugadorID > 0 Then
            Try
                Await conexion.OpenAsync() ' Uso de la versión asincrónica
                Dim consulta As String =
            "SELECT mejoras.nombre, mejoras.tipo, mj.nivel
            from mejoras_jugadores mj
            join jugadores on mj.jugador_id = jugadores.id
            join mejoras on mj.mejora_id = mejoras.id
            where mj.jugador_id = @jugador_id;"
                Dim comando As New MySqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
                Dim lector As MySqlDataReader = Await comando.ExecuteReaderAsync() ' Asíncrono

                While Await lector.ReadAsync()
                    Dim tipo As String = lector.GetString("tipo")
                    Dim nombre As String = lector.GetString("nombre")
                    Dim nivel As Integer = lector.GetInt32("nivel")
                    Dim nodoTipo As TreeNode = Nothing
                    For Each nodo As TreeNode In nodoRaiz.Nodes
                        If nodo.Text = tipo Then
                            nodoTipo = nodo
                            Exit For
                        End If
                    Next
                    If nodoTipo Is Nothing Then
                        nodoTipo = New TreeNode(tipo)
                        nodoRaiz.Nodes.Add(nodoTipo)
                    End If

                    ' Crear el nodo del nombre
                    Dim nodoMejora As New TreeNode(nombre)
                    nodoTipo.Nodes.Add(nodoMejora)

                    ' Crear nodos para cada nivel
                    For i As Integer = 1 To nivel
                        Dim nodoNivel As New TreeNode("Nivel " & i)
                        nodoMejora.Nodes.Add(nodoNivel)
                    Next
                    If nombre = "Bucles" Then
                        nivelBucles = nivel
                    End If
                End While
                If nivelBucles > 0 Then
                    autoClicTimer.Interval = CalcularIntervaloAutoClic(nivelBucles)
                    autoClicTimer.Start()
                End If
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                conexion.Close()
            End Try
        Else
            MessageBox.Show("No hay un jugador en el sistema.")
            Form1.Show()
            Me.Close()
        End If

        TreeView1.ExpandAll()
    End Sub

    Private Sub fetch_bits()
        Dim conexion As New MySqlConnection(Globales.stringConexion)
        If Globales.jugadorID > 0 Then
            Try
                conexion.Open()
                Dim consulta As String =
                    "select e.bits
                    from estadisticas e
                    join jugadores on e.jugador_estadistica_id = jugadores.id
                    where e.jugador_estadistica_id = @jugador_id;"
                Dim comando As New MySqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
                Dim lector As MySqlDataReader = comando.ExecuteReader()
                If lector.Read() Then
                    bits_box.Text = lector.GetInt32("bits").ToString()
                End If
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                conexion.Close()
            End Try
        Else
            MessageBox.Show("No hay un jugador en el sistema.")
            Form1.Show()
            Me.Close()
        End If
    End Sub

    Private Sub fetch_code()
        Dim conexion As New MySqlConnection(Globales.stringConexion)
        ' Limpiamos el diccionario antes de llenarlo nuevamente
        codigosPorSegmento.Clear()
        listaSegmentos.Clear()

        If Globales.jugadorID > 0 Then
            Try
                conexion.Open()
                Dim consulta As String =
                "select codigo.segmento, codigo.codigo " &
                "from estadisticas e " &
                "join jugadores on e.jugador_estadistica_id = jugadores.id " &
                "join codigo on e.codigo_nivel = codigo.nivel " &
                "where e.jugador_estadistica_id = @jugador_id;"
                Dim comando As New MySqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
                Dim lector As MySqlDataReader = comando.ExecuteReader()

                ' Leer todos los resultados y almacenarlos en el diccionario
                While lector.Read()
                    Dim segmento As Integer = lector.GetInt32("segmento")
                    Dim codigo As String = lector.GetString("codigo")
                    codigosPorSegmento.Add(segmento, codigo)
                    listaSegmentos.Add(segmento)
                End While

                ' Ordenar la lista de segmentos para un acceso secuencial
                listaSegmentos.Sort()

                ' Mostrar el primer código si hay alguno disponible
                If listaSegmentos.Count > 0 Then
                    segmentoActual = 0
                    code_label.Text = codigosPorSegmento(listaSegmentos(0))
                End If

            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                conexion.Close()
            End Try
        Else
            MessageBox.Show("No hay un jugador en el sistema.")
            Form1.Show()
            Me.Close()
        End If
    End Sub

    Private Async Sub mejora_handler(btn As Button)
        Dim conexion As New MySqlConnection(Globales.stringConexion)
        If Globales.jugadorID > 0 Then
            Try
                Await conexion.OpenAsync()

                ' Get the name from the button (removing "_btn" suffix)
                Dim nombreMejora As String = btn.Name.Replace("_btn", "")

                ' First query: Get current level and cost for this specific improvement
                Dim consulta As String =
                "SELECT mj.nivel, mejoras.costo " &
                "FROM mejoras_jugadores mj " &
                "JOIN mejoras ON mj.mejora_id = mejoras.id " &
                "WHERE mj.jugador_id = @jugador_id AND mejoras.nombre = @nombre;"

                Dim comando As New MySqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
                comando.Parameters.AddWithValue("@nombre", nombreMejora)

                Dim lector As MySqlDataReader = Await comando.ExecuteReaderAsync()

                If Await lector.ReadAsync() Then
                    Dim nivel As Integer = lector.GetInt32("nivel")
                    Dim costo As Integer = lector.GetInt32("costo")

                    ' Verificar si el jugador tiene suficiente bits para la mejora
                    If Convert.ToInt32(bits_box.Text) >= costo Then
                        ' Close the first reader before executing another command
                        lector.Close()

                        ' Actualizar el nivel de la mejora
                        Dim nuevoNivel As Integer = nivel + 1
                        Dim consultaActualizar As String =
                        "UPDATE mejoras_jugadores SET nivel = @nivel " &
                        "WHERE jugador_id = @jugador_id AND mejora_id = (SELECT id FROM mejoras WHERE nombre = @nombre);"

                        Dim comandoActualizar As New MySqlCommand(consultaActualizar, conexion)
                        comandoActualizar.Parameters.AddWithValue("@nivel", nuevoNivel)
                        comandoActualizar.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
                        comandoActualizar.Parameters.AddWithValue("@nombre", nombreMejora)

                        Await comandoActualizar.ExecuteNonQueryAsync()

                        ' Restar el costo de los bits
                        bits_box.Text = (Convert.ToInt32(bits_box.Text) - costo).ToString()

                        ' Update the TreeView to reflect changes
                        fetch_mejoras()
                    Else
                        lector.Close()
                        MessageBox.Show("No tienes suficientes bits para esta mejora.")
                    End If
                Else
                    lector.Close()
                    MessageBox.Show("No se encontró la mejora seleccionada.")
                End If

            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                conexion.Close()
            End Try
        Else
            MessageBox.Show("No hay un jugador en el sistema.")
            Form1.Show()
            Me.Close()
        End If
    End Sub

End Class