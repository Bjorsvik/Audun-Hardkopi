Imports MySql.Data.MySqlClient
Public Class minside
    Dim bg As New Blodgiver()
    Dim person As New Person()
    Dim postnr As New Postnummer()
    Dim res As New Reservasjoner
    Dim validering As New Validering()
    Dim resDato As String
    Dim fornavn As String
    Dim etternavn As String
    Dim fodselsdato As String
    Dim personnummer As String
    Dim telefon As Integer
    Dim adresse As String
    Dim epost As String
    Dim postnummer As Integer
    Dim personID As Integer


    Private Sub minside_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim personnummer = PubVar.personnummer

        visBruker()
        visPoststed()
        visHistorikk()

        MonthCalendar1.MinDate = Date.Today() 'Gjør slik at dato fra fortiden ikke kan velges

        'Henter karantene.
        Dim karanteneTabell As DataTable = bg.getKarantene(personID)
        Dim karantene As New ArrayList()
        Dim k As Date

        For Each i In karanteneTabell.Rows
            karantene.Add(i(0).ToString)
        Next
        k = (karantene(0))
        'MsgBox(k.ToString)

        If Date.Today() < k Then
            MonthCalendar1.MinDate = k
        End If

        'henter livstid.
        Dim livstidTabell As DataTable = bg.getLivstid(personID)
        Dim livstid As New ArrayList()
        Dim li As Boolean

        For Each i In livstidTabell.Rows
            livstid.Add(i(0).ToString)
        Next
        li = (livstid(0))
        'MsgBox(li.ToString)
        If li = True Then
            MsgBox("Din karantene for å gi blod er på livstid")
            MsgBox("Du vil nå bli logget ut")
            Me.Close()
            Application.Exit()
        End If


    End Sub
    Private Sub btnEndreInfo_Click(sender As Object, e As EventArgs) Handles btnEndreInfo.Click
        endreInfo()
        visBruker()
        visPoststed()
    End Sub

    Private Sub visBruker()
        Dim brukerTab As New DataTable()
        Dim postnummere As New DataTable()

        brukerTab = bg.GetPersonnummer()

        For Each row In brukerTab.Rows

            fornavn = row("fornavn")
            etternavn = row("etternavn")
            fodselsdato = row("fodselsdato")
            personnummer = row("personnummer")
            telefon = row("telefon")
            adresse = row("adresse")
            epost = row("epost")
            postnummer = row("postnummer")
            personID = row("personID")

            txtFornavn.Text = fornavn
            txtEtternavn.Text = etternavn
            txtFodselsdato.Text = fodselsdato
            txtPersonnummer.Text = personnummer
            txtTelefon.Text = telefon
            txtAdresse.Text = adresse
            txtEpost.Text = epost
            txtPostnummer.Text = postnummer
            lbPersonID.Text = personID

        Next row
    End Sub
    Private Sub visPoststed()

        Dim postnummerTab As New DataTable()

        Dim poststed As String

        postnummerTab = postnr.GetPoststed(txtPostnummer.Text)

        For Each row In postnummerTab.Rows
            poststed = row("poststed")

            lbPoststed.Text = poststed
        Next row

    End Sub

    Private Sub endreInfo()
        Dim brukerTab As New DataTable()
        Dim postnummere As New DataTable()

        brukerTab = bg.GetPersonnummer()

        Try
            For Each row In brukerTab.Rows

                fornavn = row("fornavn")
                etternavn = row("etternavn")
                fodselsdato = row("fodselsdato")
                personnummer = row("personnummer")
                telefon = row("telefon")
                adresse = row("adresse")
                epost = row("epost")
                postnummer = row("postnummer")

                'Validerer postnummer
                If Validering.ValidereUtfylt(txtPostnummer.Text) = False Then
                    MessageBox.Show("Fyll ut postnummer", "Feilmelding")
                ElseIf Validering.ValidereTall(txtPostnummer.Text) = False Then
                    MessageBox.Show("Postnummer skal bare inneholde tall", "Feilmelding")
                End If

                'Validerer telefon
                If validering.ValidereUtfylt(txtTelefon.Text) = False Then
                    MessageBox.Show("Fyll ut telefonnummer", "Feilmelding")
                ElseIf validering.ValidereTall(txttelefon.Text) = False Then
                    MessageBox.Show("Telefonnummer skal bare inneholde tall", "Feilmelding")
                End If

                'Validerer fornavn
                If Validering.ValidereUtfylt(txtFornavn.Text) = False Then
                    MessageBox.Show("Fyll ut Fornavn", "Feilmelding")
                ElseIf Validering.ValidereTall(txtFornavn.Text) = True Then
                    MessageBox.Show("Fornavn skal ikke inneholde tall", "Feilmelding")
                End If

                'Validerer etternavn
                If Validering.ValidereUtfylt(txtEtternavn.Text) = False Then
                    MessageBox.Show("Fyll ut etternavn", "Feilmelding")
                ElseIf Validering.ValidereTall(txtEtternavn.Text) = True Then
                    MessageBox.Show("Etternavn skal ikke inneholde tall", "Feilmelding")
                End If

                'Validerer fødselsdato
                If Validering.ValidereUtfylt(txtFodselsdato.Text) = False Then
                    MessageBox.Show("Fyll ut Fødselsdato", "Feilmelding")
                End If

                If Validering.ValidereUtfylt(txtAdresse.Text) = False Then
                    MessageBox.Show("Fyll ut adresse", "Feilmelding")
                End If

                'Validerer personnummer
                If Validering.ValidereUtfylt(txtPersonnummer.Text) = False Then
                    MessageBox.Show("Fyll ut personnummer", "Feilmelding")
                ElseIf Validering.ValidereTall(txtPersonnummer.Text) = False Then
                    MessageBox.Show("Personnummer skal bare inneholde tall", "Feilmelding")
                ElseIf Validering.ValiderePersonnummer(txtPersonnummer.Text) = False Then
                    MessageBox.Show("Et personnummer inneholder 11 tall", "Feilmelding")
                End If

                'Validerer epost
                If validering.ValidereUtfylt(txtEpost.Text) = False Then
                    MessageBox.Show("Fyll ut Epost", "Feilmelding")
                ElseIf validering.ValidereEmail(txtEpost.Text) = False Then
                    MessageBox.Show("Fyll inn med riktig format", "Feilmelding")
                End If



                person.endreFornavn(txtFornavn.Text)
                person.endreEtternavn(txtEtternavn.Text)
                person.endreFodselsdato(txtFodselsdato.Text)
                person.endreTelefon(txtTelefon.Text)
                person.endreAdresse(txtAdresse.Text)
                person.endreEpost(txtEpost.Text)
                person.endrePostnummer(txtPostnummer.Text)

            Next row

        Catch ex As Exception

        End Try

    End Sub

    Public Sub btnReserverTime_Click(sender As Object, e As EventArgs) Handles btnReserverTime.Click

        Dim personID As String = ""
        Dim tid As String = ComboBox1.SelectedValue.ToString()


        Dim id As New DataTable()

        id = bg.GetIDByPersonNr(personnummer)

        For Each rad In id.Rows
            personID = rad(0).ToString()
        Next rad
        Dim tempID As String = personID
        res.reserver(resDato, tempID, tid)
        'MsgBox(tid)


    End Sub

    Private Sub btnSkjema_Click(sender As Object, e As EventArgs) Handles btnSkjema.Click
        egenerklering.Show()
    End Sub

    Public Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        Dim dato As New Date()
        dato = MonthCalendar1.SelectionRange.Start
        resDato = dato.Year & "-" & dato.Month & "-" & dato.Day
        res.fyllCombobox(resDato, ComboBox1)
    End Sub


    Private Sub btnLogUt_Click(sender As Object, e As EventArgs) Handles btnLogUt.Click
        Me.Close()
        Hjemmeside.lbInput.Hide()
        Hjemmeside.lbPassord.Hide()
        Hjemmeside.txtInput.Hide()
        Hjemmeside.txtPassord.Hide()
        Hjemmeside.btnLogginn.Hide()
        Hjemmeside.btnRegistrer.Hide()
        Hjemmeside.btnBlodgiver.Show()
        Hjemmeside.btnAnsatt.Show()
        Hjemmeside.Show()
    End Sub

    Private Sub visHistorikk()
        Dim historikkTab As New DataTable
        Dim dato As String
        Dim blodposer As Integer

        gridHistorikk.Rows.Clear()

        historikkTab = bg.visHistorikk(personID)
        For Each row In historikkTab.Rows
            dato = row("dato")
            blodposer = row("blodposer")

            gridHistorikk.Rows.Add(dato, blodposer)
        Next row

    End Sub
End Class