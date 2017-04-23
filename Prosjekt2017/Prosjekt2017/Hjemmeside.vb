Imports MySql.Data.MySqlClient
Imports System.Data
Public Class Hjemmeside
    'Tilkoblinger mot klassene
    Dim bruker As New Blodgiver()
    Dim ansatt As New Ansatt()

    'Skjuler alt av login knapper og tekstbokser ved load
    Private Sub Hjemmeside_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbInput.Hide()
        lbPassord.Hide()
        txtInput.Hide()
        txtPassord.Hide()
        btnLogginn.Hide()
        btnRegistrer.Hide()
    End Sub

    'Setter logginn knappen som default
    Private Sub SetDefault(ByVal btnLogginn As Button)
        Me.AcceptButton = btnLogginn
    End Sub

    'Knapp som viser registreringskjema
    Private Sub Registreringsknapp_Click(sender As Object, e As EventArgs) Handles btnRegistrer.Click
        Registreringsskjema.Show()
    End Sub

    'Log inn knapp
    Private Sub Logginnknapp_Click(sender As Object, e As EventArgs) Handles btnLogginn.Click
        'Oppretter variabel for passord og brukertype
        'Brukertype variabel for å angi om brukeren er en ansatt eller blodgiver
        Dim passord As String = txtPassord.Text
        Dim brukertype As String = PubVar.brukerType

        'Om brukertype er blodgiver sammenlignes inputten mot blodgiver i databasen
        If PubVar.brukerType = "Blodgiver" Then
            Dim personnummer As String = txtInput.Text
            PubVar.personnummer = personnummer

            Dim brukerTabell As New DataTable
            Dim sjekkPassord As String
            Dim sjekkPersonnummer As String
            Dim riktigPass As Boolean = False

            brukerTabell = bruker.getAlleBlodgivere
            For Each row In brukerTabell.Rows
                sjekkPersonnummer = row("personnummer")
                sjekkPassord = row("Bpassord")

                If personnummer = sjekkPersonnummer And passord = sjekkPassord Then

                    riktigPass = True

                    txtInput.Clear()
                    txtPassord.Clear()
                    Me.Hide()
                    'MsgBox("Velkommen til minside!")
                    minside.Show()

                End If

            Next row

            If riktigPass = False Then
                MessageBox.Show("Feil personnummer eller passord", "Feilmelding")
            End If

        End If



        'Sammenligner input mot ansatt i databasen
        If PubVar.brukerType = "Ansatt" Then
            Dim Abrukernavn As String = txtInput.Text
            PubVar.ansattBruker = txtInput.Text

            Dim ansattTabell As New DataTable
            Dim sjekkAbrukernavn As String
            Dim sjekkApassord As String
            Dim riktigPass As Boolean = False

            ansattTabell = ansatt.getAlleAnsatt
            For Each row In ansattTabell.Rows
                sjekkAbrukernavn = row("Abrukernavn")
                sjekkApassord = row("Apassord")

                If Abrukernavn = sjekkAbrukernavn And passord = sjekkApassord Then

                    riktigPass = True

                    txtInput.Clear()
                    txtPassord.Clear()
                    Me.Hide()
                    'MsgBox("Velkommen til minside!")
                    Ansattside.Show()

                End If

            Next row

            If riktigPass = False Then
                MessageBox.Show("Feil brukernavn eller passord", "Feilmelding")
            End If

        End If

    End Sub

    'Brukertype blir endret til blodgiver når blodgiver knappen blir klikket på
    'Blodgiveren blir henvist til login som er egnet for de
    Private Sub btnBlodgiver_Click(sender As Object, e As EventArgs) Handles btnBlodgiver.Click
        '
        lbInput.Show()
        lbPassord.Show()
        btnBlodgiver.Hide()
        btnAnsatt.Hide()
        txtInput.Show()
        txtPassord.Show()
        btnLogginn.Show()
        btnRegistrer.Show()

        txtInput.Select()
        lbInput.Text = "Personnummer"
        PubVar.brukerType = "Blodgiver"
    End Sub
    'Brukertype blir endret til ansatt når ansatt knappen blir klikket på
    'Ansatt blir henvist til login som er egnet for de
    Private Sub btnAnsatt_Click(sender As Object, e As EventArgs) Handles btnAnsatt.Click
        lbInput.Show()
        lbPassord.Show()
        btnBlodgiver.Hide()
        btnAnsatt.Hide()
        txtInput.Show()
        txtPassord.Show()
        btnLogginn.Show()
        btnRegistrer.Hide()

        txtInput.Select()
        lbInput.Text = "Brukernavn"
        PubVar.brukerType = "Ansatt" ' <- Endre til "Ansatt" når databasetabellen er klar.
    End Sub
    'Skjuler passordet med passwordchar
    Private Sub txtPassord_TextChanged(sender As Object, e As EventArgs) Handles txtPassord.TextChanged
        txtPassord.PasswordChar = "*"
    End Sub
End Class
