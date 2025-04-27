Imports MySqlConnector
Public Class Form1
    Dim conn As New MySqlConnection(Globales.stringConexion)

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            conn.Open()
            MessageBox.Show("Base de datos conectada.")
            conn.Close()
        Catch ex As MySqlException
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub login_btn_Click(sender As Object, e As EventArgs) Handles login_btn.Click
        validar_usuario()
    End Sub

    ' Agregar este método para capturar la tecla Enter en el TextBox
    Private Sub user_input_KeyDown(sender As Object, e As KeyEventArgs) Handles user_input.KeyDown
        ' Verificar si la tecla presionada es Enter
        If e.KeyCode = Keys.Enter Then
            ' Prevenir el sonido de beep al presionar Enter
            e.SuppressKeyPress = True
            ' Llamar a la misma función que se llama al hacer click en el botón
            validar_usuario()
        End If
    End Sub

    Private Sub validar_usuario()
        Dim userName As String = user_input.Text.Trim()
        If userName = "" Then
            MessageBox.Show("Por favor, ingresa un nombre de usuario.")
            Return ' Salir de la función si el nombre está vacío
        End If

        Try
            conn.Open()
            Dim query As String = "SELECT COUNT(*) FROM jugadores WHERE Nombre = @nombre"
            Dim cmd As New MySqlCommand(query, conn)
            cmd.Parameters.AddWithValue("@nombre", userName)
            Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())

            If count > 0 Then
                ' Obtener el ID del jugador
                Dim getIdQuery As String = "SELECT ID FROM jugadores WHERE Nombre = @nombre"
                Dim getIdCmd As New MySqlCommand(getIdQuery, conn)
                getIdCmd.Parameters.AddWithValue("@nombre", userName)
                Dim reader As MySqlDataReader = getIdCmd.ExecuteReader()

                If reader.Read() Then
                    ' Actualizar las variables en el módulo Globales
                    Globales.jugadorID = reader.GetInt32("ID")
                    Globales.jugadorNombre = userName
                End If
                reader.Close()

                MessageBox.Show("¡Bienvenido de nuevo, " & userName & "!")

                'abrir el siguiente formulario
                Dim GameWindow As New GameWindow()
                GameWindow.Show()
                Me.Hide()
                AddHandler GameWindow.FormClosed, AddressOf GameWindow_closed
            Else
                Dim result As DialogResult = MessageBox.Show("Usuario no encontrado. ¿Deseas crear un nuevo perfil con este nombre?", "Crear perfil", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    Dim insertQuery As String = "INSERT INTO jugadores (Nombre) VALUES (@nombre)"
                    Dim insertCmd As New MySqlCommand(insertQuery, conn)
                    insertCmd.Parameters.AddWithValue("@nombre", userName)
                    insertCmd.ExecuteNonQuery()

                    ' Actualizar las variables en el módulo Globales
                    Globales.jugadorID = CInt(insertCmd.LastInsertedId)
                    Globales.jugadorNombre = userName

                    MessageBox.Show("Perfil creado exitosamente.")

                    'abrir el siguiente formulario
                    Dim GameWindow As New GameWindow()
                    GameWindow.Show()
                    Me.Hide()
                    AddHandler GameWindow.FormClosed, AddressOf GameWindow_closed
                End If
            End If
        Catch ex As MySqlException
            MessageBox.Show("Error: " & ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
        End Try
    End Sub

    Private Sub GameWindow_closed(sender As Object, e As FormClosedEventArgs)
        ' When the game form is closed, terminate the application
        Application.Exit()
    End Sub
End Class
