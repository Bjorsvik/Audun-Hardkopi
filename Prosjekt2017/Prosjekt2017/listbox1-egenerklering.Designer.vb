<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class listbox1_egenerklering
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.btnLukk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(23, 9)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(630, 407)
        Me.ListBox1.TabIndex = 426
        '
        'btnLukk
        '
        Me.btnLukk.Location = New System.Drawing.Point(542, 369)
        Me.btnLukk.Name = "btnLukk"
        Me.btnLukk.Size = New System.Drawing.Size(75, 23)
        Me.btnLukk.TabIndex = 428
        Me.btnLukk.Text = "Lukk"
        Me.btnLukk.UseVisualStyleBackColor = True
        '
        'listbox1_egenerklering
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(675, 428)
        Me.Controls.Add(Me.btnLukk)
        Me.Controls.Add(Me.ListBox1)
        Me.Name = "listbox1_egenerklering"
        Me.Text = "listbox1_egenerklering"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents btnLukk As Button
End Class
