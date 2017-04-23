<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Registreringsskjema
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
        Me.lblFornavn = New System.Windows.Forms.Label()
        Me.lblEtternavn = New System.Windows.Forms.Label()
        Me.lblPersonnummer = New System.Windows.Forms.Label()
        Me.lblAdresse = New System.Windows.Forms.Label()
        Me.lblPostnummer = New System.Windows.Forms.Label()
        Me.lblPoststed = New System.Windows.Forms.Label()
        Me.txtFornavn = New System.Windows.Forms.TextBox()
        Me.txtEtternavn = New System.Windows.Forms.TextBox()
        Me.txtPersonnummer = New System.Windows.Forms.TextBox()
        Me.txtAdresse = New System.Windows.Forms.TextBox()
        Me.txtPostnummer = New System.Windows.Forms.TextBox()
        Me.btnRegistrer = New System.Windows.Forms.Button()
        Me.txtTlf = New System.Windows.Forms.TextBox()
        Me.lbTlf = New System.Windows.Forms.Label()
        Me.txtPassord = New System.Windows.Forms.TextBox()
        Me.lbPassord = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBekreftPassord = New System.Windows.Forms.TextBox()
        Me.lbPoststed = New System.Windows.Forms.Label()
        Me.lbEpost = New System.Windows.Forms.Label()
        Me.txtEpost = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFodselsdato = New System.Windows.Forms.TextBox()
        Me.lbFødselsdato = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblFornavn
        '
        Me.lblFornavn.AutoSize = True
        Me.lblFornavn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFornavn.Location = New System.Drawing.Point(123, 57)
        Me.lblFornavn.Name = "lblFornavn"
        Me.lblFornavn.Size = New System.Drawing.Size(80, 24)
        Me.lblFornavn.TabIndex = 0
        Me.lblFornavn.Text = "Fornavn"
        '
        'lblEtternavn
        '
        Me.lblEtternavn.AutoSize = True
        Me.lblEtternavn.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEtternavn.Location = New System.Drawing.Point(114, 96)
        Me.lblEtternavn.Name = "lblEtternavn"
        Me.lblEtternavn.Size = New System.Drawing.Size(89, 24)
        Me.lblEtternavn.TabIndex = 1
        Me.lblEtternavn.Text = "Etternavn"
        '
        'lblPersonnummer
        '
        Me.lblPersonnummer.AutoSize = True
        Me.lblPersonnummer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPersonnummer.Location = New System.Drawing.Point(360, 96)
        Me.lblPersonnummer.Name = "lblPersonnummer"
        Me.lblPersonnummer.Size = New System.Drawing.Size(141, 24)
        Me.lblPersonnummer.TabIndex = 2
        Me.lblPersonnummer.Text = "Personnummer"
        '
        'lblAdresse
        '
        Me.lblAdresse.AutoSize = True
        Me.lblAdresse.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAdresse.Location = New System.Drawing.Point(109, 159)
        Me.lblAdresse.Name = "lblAdresse"
        Me.lblAdresse.Size = New System.Drawing.Size(80, 24)
        Me.lblAdresse.TabIndex = 3
        Me.lblAdresse.Text = "Adresse"
        '
        'lblPostnummer
        '
        Me.lblPostnummer.AutoSize = True
        Me.lblPostnummer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPostnummer.Location = New System.Drawing.Point(72, 201)
        Me.lblPostnummer.Name = "lblPostnummer"
        Me.lblPostnummer.Size = New System.Drawing.Size(117, 24)
        Me.lblPostnummer.TabIndex = 4
        Me.lblPostnummer.Text = "Postnummer"
        '
        'lblPoststed
        '
        Me.lblPoststed.AutoSize = True
        Me.lblPoststed.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPoststed.Location = New System.Drawing.Point(108, 241)
        Me.lblPoststed.Name = "lblPoststed"
        Me.lblPoststed.Size = New System.Drawing.Size(81, 24)
        Me.lblPoststed.TabIndex = 5
        Me.lblPoststed.Text = "Poststed"
        '
        'txtFornavn
        '
        Me.txtFornavn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFornavn.Location = New System.Drawing.Point(209, 57)
        Me.txtFornavn.Name = "txtFornavn"
        Me.txtFornavn.Size = New System.Drawing.Size(100, 26)
        Me.txtFornavn.TabIndex = 1
        '
        'txtEtternavn
        '
        Me.txtEtternavn.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEtternavn.Location = New System.Drawing.Point(209, 94)
        Me.txtEtternavn.Name = "txtEtternavn"
        Me.txtEtternavn.Size = New System.Drawing.Size(100, 26)
        Me.txtEtternavn.TabIndex = 2
        '
        'txtPersonnummer
        '
        Me.txtPersonnummer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPersonnummer.Location = New System.Drawing.Point(507, 96)
        Me.txtPersonnummer.Name = "txtPersonnummer"
        Me.txtPersonnummer.Size = New System.Drawing.Size(100, 26)
        Me.txtPersonnummer.TabIndex = 6
        '
        'txtAdresse
        '
        Me.txtAdresse.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAdresse.Location = New System.Drawing.Point(208, 159)
        Me.txtAdresse.Name = "txtAdresse"
        Me.txtAdresse.Size = New System.Drawing.Size(100, 26)
        Me.txtAdresse.TabIndex = 3
        '
        'txtPostnummer
        '
        Me.txtPostnummer.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPostnummer.Location = New System.Drawing.Point(208, 201)
        Me.txtPostnummer.Name = "txtPostnummer"
        Me.txtPostnummer.Size = New System.Drawing.Size(100, 26)
        Me.txtPostnummer.TabIndex = 4
        '
        'btnRegistrer
        '
        Me.btnRegistrer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRegistrer.Location = New System.Drawing.Point(496, 340)
        Me.btnRegistrer.Name = "btnRegistrer"
        Me.btnRegistrer.Size = New System.Drawing.Size(97, 41)
        Me.btnRegistrer.TabIndex = 11
        Me.btnRegistrer.Text = "Registrer"
        Me.btnRegistrer.UseVisualStyleBackColor = True
        '
        'txtTlf
        '
        Me.txtTlf.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTlf.Location = New System.Drawing.Point(507, 158)
        Me.txtTlf.Name = "txtTlf"
        Me.txtTlf.Size = New System.Drawing.Size(100, 26)
        Me.txtTlf.TabIndex = 7
        '
        'lbTlf
        '
        Me.lbTlf.AutoSize = True
        Me.lbTlf.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTlf.Location = New System.Drawing.Point(427, 160)
        Me.lbTlf.Name = "lbTlf"
        Me.lbTlf.Size = New System.Drawing.Size(74, 24)
        Me.lbTlf.TabIndex = 14
        Me.lbTlf.Text = "Telefon"
        '
        'txtPassord
        '
        Me.txtPassord.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassord.Location = New System.Drawing.Point(313, 337)
        Me.txtPassord.Name = "txtPassord"
        Me.txtPassord.Size = New System.Drawing.Size(100, 26)
        Me.txtPassord.TabIndex = 9
        '
        'lbPassord
        '
        Me.lbPassord.AutoSize = True
        Me.lbPassord.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPassord.Location = New System.Drawing.Point(229, 340)
        Me.lbPassord.Name = "lbPassord"
        Me.lbPassord.Size = New System.Drawing.Size(78, 24)
        Me.lbPassord.TabIndex = 18
        Me.lbPassord.Text = "Passord"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(168, 375)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(139, 24)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Bekreft passord"
        '
        'txtBekreftPassord
        '
        Me.txtBekreftPassord.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBekreftPassord.Location = New System.Drawing.Point(313, 372)
        Me.txtBekreftPassord.Name = "txtBekreftPassord"
        Me.txtBekreftPassord.Size = New System.Drawing.Size(100, 26)
        Me.txtBekreftPassord.TabIndex = 10
        '
        'lbPoststed
        '
        Me.lbPoststed.AutoSize = True
        Me.lbPoststed.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbPoststed.Location = New System.Drawing.Point(204, 241)
        Me.lbPoststed.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lbPoststed.Name = "lbPoststed"
        Me.lbPoststed.Size = New System.Drawing.Size(0, 24)
        Me.lbPoststed.TabIndex = 21
        '
        'lbEpost
        '
        Me.lbEpost.AutoSize = True
        Me.lbEpost.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbEpost.Location = New System.Drawing.Point(443, 201)
        Me.lbEpost.Name = "lbEpost"
        Me.lbEpost.Size = New System.Drawing.Size(58, 24)
        Me.lbEpost.TabIndex = 22
        Me.lbEpost.Text = "Epost"
        '
        'txtEpost
        '
        Me.txtEpost.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEpost.Location = New System.Drawing.Point(507, 199)
        Me.txtEpost.Name = "txtEpost"
        Me.txtEpost.Size = New System.Drawing.Size(100, 26)
        Me.txtEpost.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(613, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Eks.  1995-03-25"
        '
        'txtFodselsdato
        '
        Me.txtFodselsdato.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFodselsdato.Location = New System.Drawing.Point(507, 55)
        Me.txtFodselsdato.Name = "txtFodselsdato"
        Me.txtFodselsdato.Size = New System.Drawing.Size(100, 26)
        Me.txtFodselsdato.TabIndex = 5
        '
        'lbFødselsdato
        '
        Me.lbFødselsdato.AutoSize = True
        Me.lbFødselsdato.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFødselsdato.Location = New System.Drawing.Point(388, 57)
        Me.lbFødselsdato.Name = "lbFødselsdato"
        Me.lbFødselsdato.Size = New System.Drawing.Size(113, 24)
        Me.lbFødselsdato.TabIndex = 26
        Me.lbFødselsdato.Text = "Fødselsdato"
        '
        'Registreringsskjema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(736, 449)
        Me.Controls.Add(Me.lbFødselsdato)
        Me.Controls.Add(Me.txtFodselsdato)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtEpost)
        Me.Controls.Add(Me.lbEpost)
        Me.Controls.Add(Me.lbPoststed)
        Me.Controls.Add(Me.txtBekreftPassord)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbPassord)
        Me.Controls.Add(Me.txtPassord)
        Me.Controls.Add(Me.lbTlf)
        Me.Controls.Add(Me.txtTlf)
        Me.Controls.Add(Me.btnRegistrer)
        Me.Controls.Add(Me.txtPostnummer)
        Me.Controls.Add(Me.txtAdresse)
        Me.Controls.Add(Me.txtPersonnummer)
        Me.Controls.Add(Me.txtEtternavn)
        Me.Controls.Add(Me.txtFornavn)
        Me.Controls.Add(Me.lblPoststed)
        Me.Controls.Add(Me.lblPostnummer)
        Me.Controls.Add(Me.lblAdresse)
        Me.Controls.Add(Me.lblPersonnummer)
        Me.Controls.Add(Me.lblEtternavn)
        Me.Controls.Add(Me.lblFornavn)
        Me.Name = "Registreringsskjema"
        Me.Text = "Registreringsskjema"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblFornavn As Label
    Friend WithEvents lblEtternavn As Label
    Friend WithEvents lblPersonnummer As Label
    Friend WithEvents lblAdresse As Label
    Friend WithEvents lblPostnummer As Label
    Friend WithEvents lblPoststed As Label
    Friend WithEvents txtFornavn As TextBox
    Friend WithEvents txtEtternavn As TextBox
    Friend WithEvents txtPersonnummer As TextBox
    Friend WithEvents txtAdresse As TextBox
    Friend WithEvents txtPostnummer As TextBox
    Friend WithEvents btnRegistrer As Button
    Friend WithEvents txtTlf As TextBox
    Friend WithEvents lbTlf As Label
    Friend WithEvents txtPassord As TextBox
    Friend WithEvents lbPassord As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents txtBekreftPassord As TextBox
    Friend WithEvents lbPoststed As Label
    Friend WithEvents lbEpost As Label
    Friend WithEvents txtEpost As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFodselsdato As TextBox
    Friend WithEvents lbFødselsdato As Label
End Class
