<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Hjemmeside
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.lbInput = New System.Windows.Forms.Label()
        Me.lbPassord = New System.Windows.Forms.Label()
        Me.txtInput = New System.Windows.Forms.TextBox()
        Me.txtPassord = New System.Windows.Forms.TextBox()
        Me.btnLogginn = New System.Windows.Forms.Button()
        Me.btnRegistrer = New System.Windows.Forms.Button()
        Me.btnBlodgiver = New System.Windows.Forms.Button()
        Me.btnAnsatt = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lbInput
        '
        Me.lbInput.AutoSize = True
        Me.lbInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbInput.Location = New System.Drawing.Point(250, 125)
        Me.lbInput.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbInput.Name = "lbInput"
        Me.lbInput.Size = New System.Drawing.Size(157, 25)
        Me.lbInput.TabIndex = 0
        Me.lbInput.Text = "Personnummer"
        '
        'lbPassord
        '
        Me.lbPassord.AutoSize = True
        Me.lbPassord.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPassord.Location = New System.Drawing.Point(298, 165)
        Me.lbPassord.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbPassord.Name = "lbPassord"
        Me.lbPassord.Size = New System.Drawing.Size(91, 25)
        Me.lbPassord.TabIndex = 1
        Me.lbPassord.Text = "Passord"
        '
        'txtInput
        '
        Me.txtInput.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInput.Location = New System.Drawing.Point(423, 122)
        Me.txtInput.Margin = New System.Windows.Forms.Padding(2)
        Me.txtInput.Name = "txtInput"
        Me.txtInput.Size = New System.Drawing.Size(133, 31)
        Me.txtInput.TabIndex = 2
        '
        'txtPassord
        '
        Me.txtPassord.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassord.Location = New System.Drawing.Point(423, 162)
        Me.txtPassord.Margin = New System.Windows.Forms.Padding(2)
        Me.txtPassord.Name = "txtPassord"
        Me.txtPassord.Size = New System.Drawing.Size(133, 31)
        Me.txtPassord.TabIndex = 3
        '
        'btnLogginn
        '
        Me.btnLogginn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogginn.Location = New System.Drawing.Point(206, 245)
        Me.btnLogginn.Margin = New System.Windows.Forms.Padding(2)
        Me.btnLogginn.Name = "btnLogginn"
        Me.btnLogginn.Size = New System.Drawing.Size(144, 76)
        Me.btnLogginn.TabIndex = 4
        Me.btnLogginn.Text = "Logg inn"
        Me.btnLogginn.UseVisualStyleBackColor = True
        '
        'btnRegistrer
        '
        Me.btnRegistrer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistrer.Location = New System.Drawing.Point(442, 245)
        Me.btnRegistrer.Margin = New System.Windows.Forms.Padding(2)
        Me.btnRegistrer.Name = "btnRegistrer"
        Me.btnRegistrer.Size = New System.Drawing.Size(137, 76)
        Me.btnRegistrer.TabIndex = 5
        Me.btnRegistrer.Text = "Ny blodgiver?"
        Me.btnRegistrer.UseVisualStyleBackColor = True
        '
        'btnBlodgiver
        '
        Me.btnBlodgiver.Location = New System.Drawing.Point(206, 150)
        Me.btnBlodgiver.Name = "btnBlodgiver"
        Me.btnBlodgiver.Size = New System.Drawing.Size(176, 137)
        Me.btnBlodgiver.TabIndex = 6
        Me.btnBlodgiver.Text = "Blodgiver"
        Me.btnBlodgiver.UseVisualStyleBackColor = True
        '
        'btnAnsatt
        '
        Me.btnAnsatt.Location = New System.Drawing.Point(423, 150)
        Me.btnAnsatt.Name = "btnAnsatt"
        Me.btnAnsatt.Size = New System.Drawing.Size(176, 137)
        Me.btnAnsatt.TabIndex = 7
        Me.btnAnsatt.Text = "Ansatt"
        Me.btnAnsatt.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(237, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(295, 25)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Velkommen til blodbanken!"
        '
        'Hjemmeside
        '
        Me.AcceptButton = Me.btnLogginn
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 449)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAnsatt)
        Me.Controls.Add(Me.btnBlodgiver)
        Me.Controls.Add(Me.btnRegistrer)
        Me.Controls.Add(Me.btnLogginn)
        Me.Controls.Add(Me.txtPassord)
        Me.Controls.Add(Me.txtInput)
        Me.Controls.Add(Me.lbPassord)
        Me.Controls.Add(Me.lbInput)
        Me.Margin = New System.Windows.Forms.Padding(2)
        Me.Name = "Hjemmeside"
        Me.Text = "Hjemmeside"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lbInput As Label
    Friend WithEvents lbPassord As Label
    Friend WithEvents txtInput As TextBox
    Friend WithEvents txtPassord As TextBox
    Friend WithEvents btnLogginn As Button
    Friend WithEvents btnRegistrer As Button
    Friend WithEvents btnBlodgiver As Button
    Friend WithEvents btnAnsatt As Button
    Friend WithEvents Label1 As Label
End Class
