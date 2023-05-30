<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Ayuda
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Ayuda))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TXTNombre = New System.Windows.Forms.TextBox()
        Me.TXTEstacion = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TXTBConsulta = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Nombre"
        '
        'TXTNombre
        '
        Me.TXTNombre.Location = New System.Drawing.Point(63, 28)
        Me.TXTNombre.Name = "TXTNombre"
        Me.TXTNombre.Size = New System.Drawing.Size(278, 20)
        Me.TXTNombre.TabIndex = 1
        '
        'TXTEstacion
        '
        Me.TXTEstacion.Location = New System.Drawing.Point(63, 72)
        Me.TXTEstacion.Name = "TXTEstacion"
        Me.TXTEstacion.Size = New System.Drawing.Size(278, 20)
        Me.TXTEstacion.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Estación"
        '
        'TXTBConsulta
        '
        Me.TXTBConsulta.Location = New System.Drawing.Point(16, 132)
        Me.TXTBConsulta.Multiline = True
        Me.TXTBConsulta.Name = "TXTBConsulta"
        Me.TXTBConsulta.Size = New System.Drawing.Size(325, 148)
        Me.TXTBConsulta.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(266, 300)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 5
        Me.Button1.Text = "Enviar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 113)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(85, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Error o Consulta "
        '
        'Ayuda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(353, 354)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TXTBConsulta)
        Me.Controls.Add(Me.TXTEstacion)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TXTNombre)
        Me.Controls.Add(Me.Label1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Ayuda"
        Me.Text = "Ayuda"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TXTNombre As TextBox
    Friend WithEvents TXTEstacion As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents TXTBConsulta As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Label3 As Label
End Class
