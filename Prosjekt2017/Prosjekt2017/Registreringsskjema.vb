Imports MySql.Data.MySqlClient
Public Class Registreringsskjema
    Dim postnr As New Postnummer()
    Dim validering As New Validering()

    Private Sub Registreringsskjema_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Maxlengde på postnummer = 4
        txtPostnummer.MaxLength = 4
    End Sub

    'Funksjon for uppercase for registrering
    Public Function ToUpperFirst(Value As String) As String

        If Value <> "" Then
            Dim FirstChar As String = Value.Chars(0).ToString
            Dim Rest As String = Value.Remove(0, 1)
            Return FirstChar.ToUpper & Rest.ToLower
        Else
            Return ""
        End If

    End Function


    Private Sub btnRegistrer_Click(sender As Object, e As EventArgs) Handles btnRegistrer.Click
        Dim passord = txtPassord.Text
        Dim bpassord = txtBekreftPassord.Text


        Try

#Region "Validerings kode"
            'Validerer postnummer
            If validering.ValidereUtfylt(txtPostnummer.Text) = False Then
                MessageBox.Show("Fyll ut postnummer", "Feilmelding")
            ElseIf validering.ValidereTall(txtPostnummer.Text) = False Then
                MessageBox.Show("Postnummer skal bare inneholde tall", "Feilmelding")
            End If

            'Validerer telefon
            If validering.ValidereUtfylt(txtTlf.Text) = False Then
                MessageBox.Show("Fyll ut telefonnummer", "Feilmelding")
            ElseIf validering.ValidereTall(txtTlf.Text) = False Then
                MessageBox.Show("Telefonnummer skal bare inneholde tall", "Feilmelding")
            End If

            'Validerer fornavn
            If validering.ValidereUtfylt(txtFornavn.Text) = False Then
                MessageBox.Show("Fyll ut Fornavn", "Feilmelding")
            ElseIf validering.ValidereTall(txtFornavn.Text) = True Then
                MessageBox.Show("Fornavn skal ikke inneholde tall", "Feilmelding")
            End If

            'Validerer etternavn
            If validering.ValidereUtfylt(txtEtternavn.Text) = False Then
                MessageBox.Show("Fyll ut etternavn", "Feilmelding")
            ElseIf validering.ValidereTall(txtEtternavn.Text) = True Then
                MessageBox.Show("Etternavn skal ikke inneholde tall", "Feilmelding")
            End If

            'Validerer fødselsdato
            If validering.ValidereUtfylt(txtFodselsdato.Text) = False Then
                MessageBox.Show("Fyll ut Fødselsdato", "Feilmelding")
            End If

            If validering.ValidereUtfylt(txtAdresse.Text) = False Then
                MessageBox.Show("Fyll ut adresse", "Feilmelding")
            End If

            'Validerer personnummer
            If validering.ValidereUtfylt(txtPersonnummer.Text) = False Then
                MessageBox.Show("Fyll ut personnummer", "Feilmelding")
            ElseIf validering.ValidereTall(txtPersonnummer.Text) = False Then
                MessageBox.Show("Personnummer skal bare inneholde tall", "Feilmelding")
            ElseIf validering.ValiderePersonnummer(txtPersonnummer.Text) = False Then
                MessageBox.Show("Et personnummer inneholder 11 tall", "Feilmelding")
            End If

            'Validerer passord
            If validering.ValidereUtfylt(txtPassord.Text) = False Then
                MessageBox.Show("Fyll ut passord", "Feilmelding")
            End If

            'Validerer epost
            If validering.ValidereUtfylt(txtEpost.Text) = False Then
                MessageBox.Show("Fyll ut Epost", "Feilmelding")
            ElseIf validering.ValidereEmail(txtEpost.Text) = False Then
                MessageBox.Show("Fyll inn med riktig format", "Feilmelding")
            End If
#End Region

            'Bekreftelse av passord og registrering av brukeren om dette stemmer
            If bpassord = passord Then
                Dim nyBruker As New Blodgiver(txtPassord.Text, txtFornavn.Text, txtEtternavn.Text, txtFodselsdato.Text, txtPersonnummer.Text,
                                                 txtTlf.Text, txtAdresse.Text, txtPostnummer.Text, txtEpost.Text)
                nyBruker.regBlodgiver()

                Me.Close()
            Else
                MsgBox("Passordene er ikke like")
            End If

        Catch ex As Exception

        End Try

    End Sub

    Private Sub txtPostnummer_TextChanged(sender As Object, e As EventArgs) Handles txtPostnummer.TextChanged
        'En tekstboks for postnummer som setter igang en prosedyre for framvisning av poststed ved bokstavlengde 4
        If txtPostnummer.TextLength = 4 Then
            visPoststed()
        End If
    End Sub

    Private Sub visPoststed()
        'Viser poststedet som tilhører postnummeret
        Dim postnummerTab As New DataTable()
        Dim poststed As String

        postnummerTab = postnr.GetPoststed(txtPostnummer.Text)

        For Each row In postnummerTab.Rows
            poststed = row("poststed")
            lbPoststed.Text = poststed
        Next row
    End Sub

    Private Sub txtPassord_TextChanged(sender As Object, e As EventArgs) Handles txtPassord.TextChanged
        'txtPassord.PasswordChar = "*"
    End Sub
    Private Sub txtBekreftPassord_TextChanged(sender As Object, e As EventArgs) Handles txtBekreftPassord.TextChanged
        'txtBekreftPassord.PasswordChar = "*"
    End Sub

    Private Sub txtFornavn_TextChanged(sender As Object, e As EventArgs) Handles txtFornavn.TextChanged
        'Uppercase førstebokstav i tekstboks
        txtFornavn.Text = ToUpperFirst(txtFornavn.Text)
        txtFornavn.Select(txtFornavn.Text.Length, 0)
    End Sub

    Private Sub txtEtternavn_TextChanged(sender As Object, e As EventArgs) Handles txtEtternavn.TextChanged
        'Uppercase førstebokstav i tekstboks
        txtEtternavn.Text = ToUpperFirst(txtEtternavn.Text)
        txtEtternavn.Select(txtEtternavn.Text.Length, 0)
    End Sub

    Private Sub txtAdresse_TextChanged(sender As Object, e As EventArgs) Handles txtAdresse.TextChanged
        'Uppercase førstebokstav i tekstboks
        txtAdresse.Text = ToUpperFirst(txtAdresse.Text)
        txtAdresse.Select(txtAdresse.Text.Length, 0)
    End Sub


End Class