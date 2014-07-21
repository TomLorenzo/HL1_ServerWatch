<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Servername = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Server = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Port = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Spieler = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Checkit = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(188, 19)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "HalfLife Server-Watch"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.[Single]
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Servername, Me.Server, Me.Port, Me.Spieler, Me.Checkit})
        Me.DataGridView1.Location = New System.Drawing.Point(12, 41)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.ShowCellToolTips = False
        Me.DataGridView1.Size = New System.Drawing.Size(464, 104)
        Me.DataGridView1.StandardTab = True
        Me.DataGridView1.TabIndex = 8
        '
        'Servername
        '
        Me.Servername.HeaderText = "Servername"
        Me.Servername.Name = "Servername"
        Me.Servername.ReadOnly = True
        '
        'Server
        '
        Me.Server.HeaderText = "Server-IP"
        Me.Server.Name = "Server"
        Me.Server.ReadOnly = True
        Me.Server.Width = 130
        '
        'Port
        '
        Me.Port.HeaderText = "Port"
        Me.Port.Name = "Port"
        Me.Port.ReadOnly = True
        Me.Port.Width = 70
        '
        'Spieler
        '
        Me.Spieler.HeaderText = "Spieler"
        Me.Spieler.Name = "Spieler"
        Me.Spieler.ReadOnly = True
        Me.Spieler.Width = 60
        '
        'Checkit
        '
        Me.Checkit.HeaderText = "Checken?"
        Me.Checkit.Name = "Checkit"
        Me.Checkit.ReadOnly = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(504, 157)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Label2)
        Me.Name = "Form1"
        Me.Text = "Server-Watch"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Servername As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Server As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Port As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Spieler As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Checkit As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
