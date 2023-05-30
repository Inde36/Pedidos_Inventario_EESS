<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EESS_Pedidos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EESS_Pedidos))
        Me.txtBoxUnidades = New System.Windows.Forms.TextBox()
        Me.txtBoxObjeto = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.listPedidos = New System.Windows.Forms.ListBox()
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.CBEstacion = New System.Windows.Forms.ComboBox()
        Me.btneliminar = New System.Windows.Forms.Button()
        Me.btnañadir = New System.Windows.Forms.Button()
        Me.btneditar = New System.Windows.Forms.Button()
        Me.btnenviar = New System.Windows.Forms.Button()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.AdministrarToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ProductosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BusquedaPorProductoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BusquedaPorSemanasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReclamarPedidoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.cbCaja = New System.Windows.Forms.CheckBox()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtBoxUnidades
        '
        Me.txtBoxUnidades.Location = New System.Drawing.Point(313, 57)
        Me.txtBoxUnidades.Name = "txtBoxUnidades"
        Me.txtBoxUnidades.Size = New System.Drawing.Size(62, 20)
        Me.txtBoxUnidades.TabIndex = 1
        Me.txtBoxUnidades.Text = "1"
        '
        'txtBoxObjeto
        '
        Me.txtBoxObjeto.Location = New System.Drawing.Point(162, 57)
        Me.txtBoxObjeto.Name = "txtBoxObjeto"
        Me.txtBoxObjeto.Size = New System.Drawing.Size(130, 20)
        Me.txtBoxObjeto.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(51, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Estacion:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(159, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Objeto a Pedir"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(310, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Unidades"
        '
        'listPedidos
        '
        Me.listPedidos.FormattingEnabled = True
        Me.listPedidos.Location = New System.Drawing.Point(17, 114)
        Me.listPedidos.Name = "listPedidos"
        Me.listPedidos.Size = New System.Drawing.Size(438, 199)
        Me.listPedidos.TabIndex = 6
        '
        'btnguardar
        '
        Me.btnguardar.Location = New System.Drawing.Point(381, 319)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(75, 23)
        Me.btnguardar.TabIndex = 7
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.UseVisualStyleBackColor = True
        '
        'CBEstacion
        '
        Me.CBEstacion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBEstacion.FormattingEnabled = True
        Me.CBEstacion.Location = New System.Drawing.Point(17, 57)
        Me.CBEstacion.Name = "CBEstacion"
        Me.CBEstacion.Size = New System.Drawing.Size(121, 21)
        Me.CBEstacion.TabIndex = 8
        '
        'btneliminar
        '
        Me.btneliminar.Location = New System.Drawing.Point(98, 319)
        Me.btneliminar.Name = "btneliminar"
        Me.btneliminar.Size = New System.Drawing.Size(75, 23)
        Me.btneliminar.TabIndex = 10
        Me.btneliminar.Text = "Elimina"
        Me.btneliminar.UseVisualStyleBackColor = True
        '
        'btnañadir
        '
        Me.btnañadir.Location = New System.Drawing.Point(381, 54)
        Me.btnañadir.Name = "btnañadir"
        Me.btnañadir.Size = New System.Drawing.Size(75, 23)
        Me.btnañadir.TabIndex = 11
        Me.btnañadir.Text = "Añadir"
        Me.btnañadir.UseVisualStyleBackColor = True
        '
        'btneditar
        '
        Me.btneditar.Location = New System.Drawing.Point(17, 319)
        Me.btneditar.Name = "btneditar"
        Me.btneditar.Size = New System.Drawing.Size(75, 23)
        Me.btneditar.TabIndex = 12
        Me.btneditar.Text = "Editar"
        Me.btneditar.UseVisualStyleBackColor = True
        '
        'btnenviar
        '
        Me.btnenviar.Enabled = False
        Me.btnenviar.Location = New System.Drawing.Point(300, 319)
        Me.btnenviar.Name = "btnenviar"
        Me.btnenviar.Size = New System.Drawing.Size(75, 23)
        Me.btnenviar.TabIndex = 13
        Me.btnenviar.Text = "Enviar"
        Me.btnenviar.UseVisualStyleBackColor = True
        Me.btnenviar.Visible = False
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AdministrarToolStripMenuItem, Me.ProductosToolStripMenuItem, Me.AyudaToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(477, 24)
        Me.MenuStrip1.TabIndex = 14
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'AdministrarToolStripMenuItem
        '
        Me.AdministrarToolStripMenuItem.Name = "AdministrarToolStripMenuItem"
        Me.AdministrarToolStripMenuItem.Size = New System.Drawing.Size(81, 20)
        Me.AdministrarToolStripMenuItem.Text = "Administrar"
        '
        'ProductosToolStripMenuItem
        '
        Me.ProductosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BusquedaPorProductoToolStripMenuItem, Me.BusquedaPorSemanasToolStripMenuItem, Me.ReclamarPedidoToolStripMenuItem})
        Me.ProductosToolStripMenuItem.Name = "ProductosToolStripMenuItem"
        Me.ProductosToolStripMenuItem.Size = New System.Drawing.Size(73, 20)
        Me.ProductosToolStripMenuItem.Text = "Productos"
        '
        'BusquedaPorProductoToolStripMenuItem
        '
        Me.BusquedaPorProductoToolStripMenuItem.Name = "BusquedaPorProductoToolStripMenuItem"
        Me.BusquedaPorProductoToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.BusquedaPorProductoToolStripMenuItem.Text = "Busqueda por Producto"
        '
        'BusquedaPorSemanasToolStripMenuItem
        '
        Me.BusquedaPorSemanasToolStripMenuItem.Name = "BusquedaPorSemanasToolStripMenuItem"
        Me.BusquedaPorSemanasToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.BusquedaPorSemanasToolStripMenuItem.Text = "Busqueda por semanas"
        '
        'ReclamarPedidoToolStripMenuItem
        '
        Me.ReclamarPedidoToolStripMenuItem.Name = "ReclamarPedidoToolStripMenuItem"
        Me.ReclamarPedidoToolStripMenuItem.Size = New System.Drawing.Size(199, 22)
        Me.ReclamarPedidoToolStripMenuItem.Text = "Reclamar Pedido(NO)"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.AyudaToolStripMenuItem.Text = "Ayuda"
        '
        'cbCaja
        '
        Me.cbCaja.AutoSize = True
        Me.cbCaja.Location = New System.Drawing.Point(381, 34)
        Me.cbCaja.Name = "cbCaja"
        Me.cbCaja.Size = New System.Drawing.Size(47, 17)
        Me.cbCaja.TabIndex = 15
        Me.cbCaja.Text = "Caja"
        Me.cbCaja.UseVisualStyleBackColor = True
        '
        'EESS_Pedidos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(477, 354)
        Me.Controls.Add(Me.cbCaja)
        Me.Controls.Add(Me.btnenviar)
        Me.Controls.Add(Me.btneditar)
        Me.Controls.Add(Me.btnañadir)
        Me.Controls.Add(Me.btneliminar)
        Me.Controls.Add(Me.CBEstacion)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.listPedidos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtBoxObjeto)
        Me.Controls.Add(Me.txtBoxUnidades)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "EESS_Pedidos"
        Me.Text = "EESS_Pedidos"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBoxUnidades As TextBox
    Friend WithEvents txtBoxObjeto As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents listPedidos As ListBox
    Friend WithEvents btnguardar As Button
    Friend WithEvents CBEstacion As ComboBox
    Friend WithEvents btneliminar As Button
    Friend WithEvents btnañadir As Button
    Friend WithEvents btneditar As Button
    Friend WithEvents btnenviar As Button
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents AdministrarToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ProductosToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BusquedaPorSemanasToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents BusquedaPorProductoToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents cbCaja As CheckBox
    Friend WithEvents ReclamarPedidoToolStripMenuItem As ToolStripMenuItem
End Class
