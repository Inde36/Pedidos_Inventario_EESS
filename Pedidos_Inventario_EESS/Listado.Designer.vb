<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Listado
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Listado))
        Me.LVListado = New System.Windows.Forms.ListView()
        Me.CLNombre = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CCodigo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CSemana = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.CUnidades = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnbuscar = New System.Windows.Forms.Button()
        Me.TXTBnombre = New System.Windows.Forms.TextBox()
        Me.TXTBsemana = New System.Windows.Forms.TextBox()
        Me.lbsemana = New System.Windows.Forms.Label()
        Me.btnadd = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'LVListado
        '
        Me.LVListado.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.CLNombre, Me.CCodigo, Me.CSemana, Me.CUnidades})
        Me.LVListado.HideSelection = False
        Me.LVListado.Location = New System.Drawing.Point(12, 98)
        Me.LVListado.Name = "LVListado"
        Me.LVListado.Size = New System.Drawing.Size(776, 340)
        Me.LVListado.TabIndex = 0
        Me.LVListado.UseCompatibleStateImageBehavior = False
        Me.LVListado.View = System.Windows.Forms.View.Details
        '
        'CLNombre
        '
        Me.CLNombre.Text = "Nombre"
        Me.CLNombre.Width = 209
        '
        'CCodigo
        '
        Me.CCodigo.Text = "Codigo"
        Me.CCodigo.Width = 331
        '
        'CSemana
        '
        Me.CSemana.Text = "Semana"
        Me.CSemana.Width = 112
        '
        'CUnidades
        '
        Me.CUnidades.Text = "Unidades"
        Me.CUnidades.Width = 121
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nombre"
        '
        'btnbuscar
        '
        Me.btnbuscar.Location = New System.Drawing.Point(58, 69)
        Me.btnbuscar.Name = "btnbuscar"
        Me.btnbuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnbuscar.TabIndex = 2
        Me.btnbuscar.Text = "Buscar"
        Me.btnbuscar.UseVisualStyleBackColor = True
        '
        'TXTBnombre
        '
        Me.TXTBnombre.Location = New System.Drawing.Point(58, 35)
        Me.TXTBnombre.Name = "TXTBnombre"
        Me.TXTBnombre.Size = New System.Drawing.Size(100, 20)
        Me.TXTBnombre.TabIndex = 3
        '
        'TXTBsemana
        '
        Me.TXTBsemana.Location = New System.Drawing.Point(209, 35)
        Me.TXTBsemana.Name = "TXTBsemana"
        Me.TXTBsemana.Size = New System.Drawing.Size(100, 20)
        Me.TXTBsemana.TabIndex = 5
        '
        'lbsemana
        '
        Me.lbsemana.AutoSize = True
        Me.lbsemana.Location = New System.Drawing.Point(164, 38)
        Me.lbsemana.Name = "lbsemana"
        Me.lbsemana.Size = New System.Drawing.Size(46, 13)
        Me.lbsemana.TabIndex = 4
        Me.lbsemana.Text = "Semana"
        '
        'btnadd
        '
        Me.btnadd.Location = New System.Drawing.Point(139, 69)
        Me.btnadd.Name = "btnadd"
        Me.btnadd.Size = New System.Drawing.Size(75, 23)
        Me.btnadd.TabIndex = 6
        Me.btnadd.Text = "Añadir"
        Me.btnadd.UseVisualStyleBackColor = True
        '
        'Listado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.btnadd)
        Me.Controls.Add(Me.TXTBsemana)
        Me.Controls.Add(Me.lbsemana)
        Me.Controls.Add(Me.TXTBnombre)
        Me.Controls.Add(Me.btnbuscar)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.LVListado)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Listado"
        Me.Text = "Listado"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LVListado As ListView
    Friend WithEvents Label1 As Label
    Friend WithEvents btnbuscar As Button
    Friend WithEvents TXTBnombre As TextBox
    Friend WithEvents TXTBsemana As TextBox
    Friend WithEvents lbsemana As Label
    Friend WithEvents CLNombre As ColumnHeader
    Friend WithEvents CCodigo As ColumnHeader
    Friend WithEvents CSemana As ColumnHeader
    Friend WithEvents CUnidades As ColumnHeader
    Friend WithEvents btnadd As Button
End Class
