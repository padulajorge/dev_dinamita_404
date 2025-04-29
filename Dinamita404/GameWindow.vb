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
        actualizar_labels_estado()
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
        Try
            bits_box.Text = (Convert.ToInt32(bits_box.Text) + cantidad).ToString()
        Catch ex As OverflowException
            autoClicTimer.Stop()
            Prestigio()
        End Try
    End Sub

    Private Async Function bonus_mejoras(bits As Integer) As Task(Of Integer)
        Dim total As Integer = 8
        Dim prestigioBonus As Integer = 0

        If Globales.jugadorID > 0 Then
            Dim conexion As New MySqlConnection(Globales.stringConexion)
            Try
                Await conexion.OpenAsync()

                ' Obtener el prestigio actual del lenguaje
                Dim consultaPrestigio As String = "SELECT prestigio_lenguaje FROM estadisticas WHERE jugador_estadistica_id = @jugador_id;"
                Dim comandoPrestigio As New MySqlCommand(consultaPrestigio, conexion)
                comandoPrestigio.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
                Dim prestigioActual As Integer = Convert.ToInt32(comandoPrestigio.ExecuteScalar())

                ' Aplicar beneficios basados en el prestigio
                Select Case prestigioActual
                    Case 1 ' Nivel 1: Sin bonus
                        prestigioBonus = 0
                    Case 2 ' Nivel 2: Beneficio hexadecimal (base 16)
                        prestigioBonus = 32 ' 32 bits base
                    Case 3 ' Nivel 3: Beneficio de 64 bits
                        prestigioBonus = 64 ' 64 bits base
                    Case 4 ' Nivel 4: Beneficio de 128 bits
                        prestigioBonus = 128 ' 128 bits base
                    Case 5 ' Nivel 5: Beneficio de 256 bits
                        prestigioBonus = 256 ' 256 bits base
                End Select

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

                    Try
                        ' Calcular el total en función del ID y el nivel
                        Select Case id
                    'encapsulamiento
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
                                If nivel = 0 Then
                                    total += 0
                                Else
                                    total += Math.Pow(8, nivel)
                                End If
                        End Select

                    Catch ex As OverflowException
                        autoClicTimer.Stop()
                        Prestigio()
                    End Try
                End While

                ' Aplicar el bonus de prestigio al total final
                total += prestigioBonus

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


    Private Async Sub Prestigio()
        Dim conexion As New MySqlConnection(Globales.stringConexion)
        Await conexion.OpenAsync()

        ' Detener el timer de auto-clic
        autoClicTimer.Stop()

        ' Obtener el prestigio actual y el nombre del siguiente lenguaje
        Dim consultaPrestigio As String = "SELECT prestigio_lenguaje FROM estadisticas WHERE jugador_estadistica_id = @jugador_id;"
        Dim comandoPrestigio As New MySqlCommand(consultaPrestigio, conexion)
        comandoPrestigio.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
        Dim prestigioActual As Integer = Convert.ToInt32(comandoPrestigio.ExecuteScalar())

        ' Obtener el nombre del siguiente lenguaje
        Dim consultaLenguaje As String = "SELECT nombre FROM lenguajes WHERE id = @prestigio + 1;"
        Dim comandoLenguaje As New MySqlCommand(consultaLenguaje, conexion)
        comandoLenguaje.Parameters.AddWithValue("@prestigio", prestigioActual)
        Dim nombreLenguaje As String = Convert.ToString(comandoLenguaje.ExecuteScalar())

        ' Actualizar el prestigio
        Dim consultaActualizarPrestigio As String = "
            UPDATE estadisticas SET prestigio_lenguaje = prestigio_lenguaje + 1,
            codigo_nivel = 0
            WHERE jugador_estadistica_id = @jugador_id;"
        Dim comandoActualizarPrestigio As New MySqlCommand(consultaActualizarPrestigio, conexion)
        comandoActualizarPrestigio.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
        Await comandoActualizarPrestigio.ExecuteNonQueryAsync()

        ' Reiniciar los niveles de las mejoras
        Dim consultaResetMejoras As String = "UPDATE mejoras_jugadores SET nivel = 0 WHERE jugador_id = @jugador_id;"
        Dim comandoResetMejoras As New MySqlCommand(consultaResetMejoras, conexion)
        comandoResetMejoras.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
        Await comandoResetMejoras.ExecuteNonQueryAsync()

        ' Reiniciar los bits
        Dim consultaResetBits As String = "UPDATE estadisticas SET bits = 0 WHERE jugador_estadistica_id = @jugador_id;"
        Dim comandoResetBits As New MySqlCommand(consultaResetBits, conexion)
        comandoResetBits.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
        Await comandoResetBits.ExecuteNonQueryAsync()
        Await conexion.CloseAsync()

        ' Actualizar la interfaz
        bits_box.Text = "0"
        fetch_mejoras()
        fetch_code()
        actualizar_labels_estado() ' Actualizar las etiquetas después del cambio de prestigio

        ' Mostrar mensaje de felicitación
        MessageBox.Show("¡Felicidades! Has alcanzado un nuevo nivel de prestigio." & vbCrLf &
                      "Ahora jugarás con: " & nombreLenguaje & vbCrLf &
                      "Tus mejoras han sido reiniciadas y comenzarás de nuevo.")

    End Sub

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
        actualizar_labels_estado()
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
                "select codigo.segmento, codigo.codigo, e.prestigio_lenguaje " &
                "from estadisticas e " &
                "join jugadores on e.jugador_estadistica_id = jugadores.id " &
                "join codigo on e.codigo_nivel = codigo.nivel " &
                "where e.jugador_estadistica_id = @jugador_id " &
                "AND codigo.lenguaje_id = e.prestigio_lenguaje;"
                Dim comando As New MySqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
                Dim lector As MySqlDataReader = comando.ExecuteReader()

                ' Leer todos los resultados y almacenarlos en el diccionario
                While lector.Read()
                    Dim segmento As Integer = lector.GetInt32("segmento")
                    Dim codigo As String = lector.GetString("codigo")
                    If Not codigosPorSegmento.ContainsKey(segmento) Then
                        codigosPorSegmento.Add(segmento, codigo)
                    End If

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

                        ' Después de actualizar, recorrer todas las mejoras para determinar el código_nivel
                        Dim consultaMejoras As String =
                    "SELECT mejoras.id, mj.nivel " &
                    "FROM mejoras_jugadores mj " &
                    "JOIN mejoras ON mj.mejora_id = mejoras.id " &
                    "WHERE mj.jugador_id = @jugador_id " &
                    "ORDER BY mejoras.id;"
                        Dim comandoMejoras As New MySqlCommand(consultaMejoras, conexion)
                        comandoMejoras.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
                        Dim lectorMejoras As MySqlDataReader = Await comandoMejoras.ExecuteReaderAsync()

                        Dim nuevoCodigo As Integer = 0
                        ' Revisar cada mejora del 1 al 5
                        While Await lectorMejoras.ReadAsync()
                            Dim idMejora As Integer = lectorMejoras.GetInt32("id")
                            Dim nivelMejora As Integer = lectorMejoras.GetInt32("nivel")

                            ' Si la mejora tiene nivel mayor que 0, actualizamos el código
                            If nivelMejora > 0 AndAlso idMejora >= 1 AndAlso idMejora <= 5 Then
                                nuevoCodigo = idMejora
                            End If
                        End While

                        ' Cerramos el lector de mejoras
                        lectorMejoras.Close()

                        ' Actualizar el código_nivel en la tabla estadisticas
                        If nuevoCodigo > 0 Then
                            Dim consultaCodigoNivel As String =
                        "UPDATE estadisticas SET codigo_nivel = @codigo_nivel " &
                        "WHERE jugador_estadistica_id = @jugador_id;"
                            Dim comandoCodigoNivel As New MySqlCommand(consultaCodigoNivel, conexion)
                            comandoCodigoNivel.Parameters.AddWithValue("@codigo_nivel", nuevoCodigo)
                            comandoCodigoNivel.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
                            Await comandoCodigoNivel.ExecuteNonQueryAsync()
                            fetch_code()
                        End If

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

    Private Sub actualizar_labels_estado()
        Dim conexion As New MySqlConnection(Globales.stringConexion)
        If Globales.jugadorID > 0 Then
            Try
                conexion.Open()
                ' Consulta para obtener el prestigio y el nombre del lenguaje
                Dim consulta As String = "
                    SELECT e.prestigio_lenguaje, l.nombre as nombre_lenguaje
                    FROM estadisticas e
                    JOIN lenguajes l ON e.prestigio_lenguaje = l.id
                    WHERE e.jugador_estadistica_id = @jugador_id;"
                Dim comando As New MySqlCommand(consulta, conexion)
                comando.Parameters.AddWithValue("@jugador_id", Globales.jugadorID)
                Dim lector As MySqlDataReader = comando.ExecuteReader()

                If lector.Read() Then
                    Dim prestigio As Integer = lector.GetInt32("prestigio_lenguaje")
                    Dim nombreLenguaje As String = lector.GetString("nombre_lenguaje")

                    ' Actualizar los labels
                    lenguaje_label.Text = nombreLenguaje
                    prestigio_label.Text = "Nivel " & prestigio.ToString()

                    ' Determinar el bonus actual basado en el prestigio
                    Dim bonusDescripcion As String = ""
                    Select Case prestigio
                        Case 1
                            bonusDescripcion = "Sin bonus especial"
                        Case 2
                            bonusDescripcion = "Bonus +32 bits base"
                        Case 3
                            bonusDescripcion = "Bonus +64 bits base"
                        Case 4
                            bonusDescripcion = "Bonus +128 bits base"
                        Case 5
                            bonusDescripcion = "Bonus +256 bits base"
                        Case Else
                            bonusDescripcion = "Sin bonus especial"
                    End Select
                    bonus_label.Text = bonusDescripcion
                    
                    ' Configurar el label de bonus para word wrap
                    bonus_label.AutoSize = False
                    bonus_label.Width = 150 ' Ancho fijo
                    bonus_label.Height = 40 ' Altura inicial
                    bonus_label.TextAlign = ContentAlignment.MiddleLeft
                End If
            Catch ex As MySqlException
                MessageBox.Show(ex.Message)
            Finally
                conexion.Close()
            End Try
        End If
    End Sub
End Class