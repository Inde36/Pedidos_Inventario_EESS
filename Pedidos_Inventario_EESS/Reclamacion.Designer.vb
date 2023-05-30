<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reclamacion
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
        Me.lvlista = New System.Windows.Forms.ListView()
        Me.btnaceptar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SuspendLayout()
        '
        'lvlista
        '
        Me.lvlista.HideSelection = False
        Me.lvlista.Location = New System.Drawing.Point(12, 12)
        Me.lvlista.Name = "lvlista"
        Me.lvlista.Size = New System.Drawing.Size(776, 292)
        Me.lvlista.TabIndex = 0
        Me.lvlista.UseCompatibleStateImageBehavior = False
        '
        'btnaceptar
        '
        Me.btnaceptar.Location = New System.Drawing.Point(641, 392)
        Me.btnaceptar.Name = "btnaceptar"
        Me.btnaceptar.Size = New System.Drawing.Size(137, 36)
        Me.btnaceptar.TabIndex = 1
        Me.btnaceptar.Text = "Button1"
        Me.btnaceptar.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Location = New System.Drawing.Point(12, 310)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(571, 118)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Reclamación"
        '
        'Reclamacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnaceptar)
        Me.Controls.Add(Me.lvlista)
        Me.Name = "Reclamacion"
        Me.Text = "Reclamacion"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lvlista As ListView
    Friend WithEvents btnaceptar As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
