<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        user_input = New TextBox()
        login_btn = New Button()
        SuspendLayout()
        ' 
        ' user_input
        ' 
        user_input.Location = New Point(252, 148)
        user_input.Name = "user_input"
        user_input.Size = New Size(236, 23)
        user_input.TabIndex = 0
        ' 
        ' login_btn
        ' 
        login_btn.Location = New Point(334, 219)
        login_btn.Name = "login_btn"
        login_btn.Size = New Size(75, 23)
        login_btn.TabIndex = 1
        login_btn.Text = "Ingresar"
        login_btn.UseVisualStyleBackColor = True
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(login_btn)
        Controls.Add(user_input)
        Name = "Form1"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents user_input As TextBox
    Friend WithEvents login_btn As Button

End Class
