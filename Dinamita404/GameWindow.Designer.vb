<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameWindow
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        BackgroundWorker1 = New ComponentModel.BackgroundWorker()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        bits_label = New Label()
        code_label = New Label()
        TreeView1 = New TreeView()
        bits_box = New TextBox()
        TabPage2 = New TabPage()
        asociacion_label = New Label()
        agregacion_label = New Label()
        herencia_label = New Label()
        clases_label = New Label()
        encapsulamiento_label = New Label()
        agregacion_btn = New Button()
        herencia_btn = New Button()
        asociacion_btn = New Button()
        clases_btn = New Button()
        encapsulamiento_btn = New Button()
        ToolTip1 = New ToolTip(components)
        ToolTip2 = New ToolTip(components)
        bucles_btn = New Button()
        bucles_label = New Label()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Location = New Point(12, 12)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(776, 426)
        TabControl1.TabIndex = 0
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(bits_label)
        TabPage1.Controls.Add(code_label)
        TabPage1.Controls.Add(TreeView1)
        TabPage1.Controls.Add(bits_box)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(768, 398)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Código"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' bits_label
        ' 
        bits_label.Location = New Point(632, 32)
        bits_label.Name = "bits_label"
        bits_label.Size = New Size(130, 23)
        bits_label.TabIndex = 4
        ' 
        ' code_label
        ' 
        code_label.BorderStyle = BorderStyle.FixedSingle
        code_label.Location = New Point(142, 6)
        code_label.Name = "code_label"
        code_label.Size = New Size(484, 386)
        code_label.TabIndex = 3
        ' 
        ' TreeView1
        ' 
        TreeView1.Location = New Point(6, 6)
        TreeView1.Name = "TreeView1"
        TreeView1.Size = New Size(130, 386)
        TreeView1.TabIndex = 2
        ' 
        ' bits_box
        ' 
        bits_box.Location = New Point(632, 6)
        bits_box.Name = "bits_box"
        bits_box.Size = New Size(130, 23)
        bits_box.TabIndex = 1
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(asociacion_label)
        TabPage2.Controls.Add(agregacion_label)
        TabPage2.Controls.Add(herencia_label)
        TabPage2.Controls.Add(bucles_label)
        TabPage2.Controls.Add(clases_label)
        TabPage2.Controls.Add(encapsulamiento_label)
        TabPage2.Controls.Add(agregacion_btn)
        TabPage2.Controls.Add(herencia_btn)
        TabPage2.Controls.Add(asociacion_btn)
        TabPage2.Controls.Add(bucles_btn)
        TabPage2.Controls.Add(clases_btn)
        TabPage2.Controls.Add(encapsulamiento_btn)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(768, 398)
        TabPage2.TabIndex = 1
        TabPage2.Text = "Mejoras"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' asociacion_label
        ' 
        asociacion_label.AutoSize = True
        asociacion_label.Location = New Point(640, 320)
        asociacion_label.Name = "asociacion_label"
        asociacion_label.Size = New Size(40, 15)
        asociacion_label.TabIndex = 1
        asociacion_label.Text = "precio"
        ' 
        ' agregacion_label
        ' 
        agregacion_label.AutoSize = True
        agregacion_label.Location = New Point(528, 320)
        agregacion_label.Name = "agregacion_label"
        agregacion_label.Size = New Size(40, 15)
        agregacion_label.TabIndex = 1
        agregacion_label.Text = "precio"
        ' 
        ' herencia_label
        ' 
        herencia_label.AutoSize = True
        herencia_label.Location = New Point(528, 199)
        herencia_label.Name = "herencia_label"
        herencia_label.Size = New Size(40, 15)
        herencia_label.TabIndex = 1
        herencia_label.Text = "precio"
        ' 
        ' clases_label
        ' 
        clases_label.AutoSize = True
        clases_label.Location = New Point(220, 154)
        clases_label.Name = "clases_label"
        clases_label.Size = New Size(40, 15)
        clases_label.TabIndex = 1
        clases_label.Text = "precio"
        ' 
        ' encapsulamiento_label
        ' 
        encapsulamiento_label.AutoSize = True
        encapsulamiento_label.Location = New Point(74, 150)
        encapsulamiento_label.Name = "encapsulamiento_label"
        encapsulamiento_label.Size = New Size(40, 15)
        encapsulamiento_label.TabIndex = 1
        encapsulamiento_label.Text = "precio"
        ' 
        ' agregacion_btn
        ' 
        agregacion_btn.Location = New Point(494, 238)
        agregacion_btn.Name = "agregacion_btn"
        agregacion_btn.Size = New Size(108, 79)
        agregacion_btn.TabIndex = 0
        agregacion_btn.Text = "Agregación"
        agregacion_btn.UseVisualStyleBackColor = True
        ' 
        ' herencia_btn
        ' 
        herencia_btn.Location = New Point(494, 118)
        herencia_btn.Name = "herencia_btn"
        herencia_btn.Size = New Size(108, 78)
        herencia_btn.TabIndex = 0
        herencia_btn.Text = "Herencia"
        herencia_btn.UseVisualStyleBackColor = True
        ' 
        ' asociacion_btn
        ' 
        asociacion_btn.Location = New Point(608, 238)
        asociacion_btn.Name = "asociacion_btn"
        asociacion_btn.Size = New Size(108, 78)
        asociacion_btn.TabIndex = 0
        asociacion_btn.Text = "Asociación"
        asociacion_btn.UseVisualStyleBackColor = True
        ' 
        ' clases_btn
        ' 
        clases_btn.Location = New Point(186, 69)
        clases_btn.Name = "clases_btn"
        clases_btn.Size = New Size(108, 78)
        clases_btn.TabIndex = 0
        clases_btn.Text = "Clases"
        clases_btn.UseVisualStyleBackColor = True
        ' 
        ' encapsulamiento_btn
        ' 
        encapsulamiento_btn.Location = New Point(42, 69)
        encapsulamiento_btn.Name = "encapsulamiento_btn"
        encapsulamiento_btn.Size = New Size(108, 78)
        encapsulamiento_btn.TabIndex = 0
        encapsulamiento_btn.Text = "Encapsulamiento"
        encapsulamiento_btn.UseVisualStyleBackColor = True
        ' 
        ' bucles_btn
        ' 
        bucles_btn.Location = New Point(276, 229)
        bucles_btn.Name = "bucles_btn"
        bucles_btn.Size = New Size(108, 78)
        bucles_btn.TabIndex = 0
        bucles_btn.Text = "Bucles"
        bucles_btn.UseVisualStyleBackColor = True
        ' 
        ' bucles_label
        ' 
        bucles_label.AutoSize = True
        bucles_label.Location = New Point(310, 314)
        bucles_label.Name = "bucles_label"
        bucles_label.Size = New Size(40, 15)
        bucles_label.TabIndex = 1
        bucles_label.Text = "precio"
        ' 
        ' GameWindow
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(TabControl1)
        Name = "GameWindow"
        Text = "GameWindow"
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents bits_box As TextBox
    Friend WithEvents TreeView1 As TreeView
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ToolTip2 As ToolTip
    Friend WithEvents code_label As Label
    Friend WithEvents agregacion_btn As Button
    Friend WithEvents herencia_btn As Button
    Friend WithEvents asociacion_btn As Button
    Friend WithEvents clases_btn As Button
    Friend WithEvents encapsulamiento_btn As Button
    Friend WithEvents herencia_label As Label
    Friend WithEvents clases_label As Label
    Friend WithEvents encapsulamiento_label As Label
    Friend WithEvents asociacion_label As Label
    Friend WithEvents agregacion_label As Label
    Friend WithEvents bits_label As Label
    Friend WithEvents bucles_label As Label
    Friend WithEvents bucles_btn As Button
End Class
