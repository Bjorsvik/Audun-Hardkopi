Imports MySql.Data.MySqlClient
Public Class Ansattside
    'PersonID her blir satt til 0 for å feilsjekke om ukjent personnummer
    'Oppretter tomme variabler
    'Oppretter tomme konstruktører koblet opp mot klassene for å hente ut funskjoner og prosedyrer 
    Dim Postnr As New Postnummer()
    Dim Blodlager As New Blodlager()
    Dim blodgiver As New Blodgiver()
    Dim person As New Person()
    Dim res As New Reservasjoner()
    Dim ansatt As New Ansatt()
    Dim validering As New Validering()
    Dim personID As String = "0"
    Dim idato As Date
    Dim resDato As String
    Dim innkBlodtype As String


    'Viser alle tilgjengelige blodprodukter og gjør klar kalender ved oppstart
    Private Sub Ansattside_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        visAlleBlodplasma()
        visAlleBlodCeller()
        visAlleBlodplater()
        Reservasjonskalender.MinDate = Date.Now
        cboBlodtypeInnkalling.Items.Clear()
        Dim columns() As String = {"A+", "A-", "AB+", "AB-", "B+", "B-", "O+", "O-"}
        cboBlodtypeInnkalling.MaxDropDownItems = columns.Length
        For Each column As String In columns
            cboBlodtypeInnkalling.Items.Add(column)
        Next

        'MsgBox(inkallDato)

    End Sub


    'Gruppert blodlager kode
#Region "Blodlager kode"
    'Knapp som legger inn blodprodukter og oppdaterer datagrid
    Private Sub btnInsert_Click(sender As Object, e As EventArgs) Handles btnInsert.Click

        leggTilBlodProdukter()
        visAlleBlodplasma()
        visAlleBlodplater()
        visAlleBlodCeller()

    End Sub

    Private Sub LeggtilBlod()
        'Oppretter tomme variabler og tabeller
        'Kobler personnummer til txtLagerpersonnummer for senere bruk og blodposer til numBlodmengde
        Dim personnummer As String = txtPersonnr.Text
        Dim pID As String = ""
        Dim blodtype As String = ""
        Dim bID As String = ""
        Dim rID As String = ""
        Dim blodposer As Integer = numBlodmengde.Text
        Dim personIDTab As New DataTable
        Dim blodIDTab As New DataTable
        Dim resIDTab As New DataTable

        'Henter ut hele brukeren ved å kalle opp funksjonen GetBruker og legger det inn i en tabell
        personIDTab = person.getPersonID(personnummer)

        'Løkke for å lese alle verdiene i tabellen og setter det inn i variabler.
        For Each row In personIDTab.Rows
            pID = row("personID")
            blodtype = row("blodtype")

        Next

        'Henter ut siste reservasjonsID som er koblet til personID
        resIDTab = res.getLastResIDByPersonID(pID)

        'Leser reservasjonsID og legger det inn i en variabel
        For Each row In resIDTab.Rows
            rID = row("resID")
        Next

        'Legger inn blodposer
        Blodlager.leggInnBlodposer(blodtype, blodposer, rID)
        MessageBox.Show("Blodpose har blitt lagt inn", "Fullført")

    End Sub

    'Knapp som legger inn blodposer fra tappingen
    Private Sub btnBlodgivning_Click(sender As Object, e As EventArgs) Handles btnBlodgivning.Click
        LeggtilBlod()
    End Sub

    Private Sub leggTilBlodProdukter()
        'Oppretter tomme variabler og tabeller.
        'Kobler personnummer til txtLagerpersonnummer for senere bruk
        'lagerID er uansett 1 siden vi har nå bare 1 lager, kan utvides om det kommer flere lagere.
        Dim personnummer As String = txtLagerPersonnummer.Text
        Dim pID As String = ""
        Dim bID As String = ""
        Dim rID As String = ""
        Dim lagerID As Integer = "1"
        Dim personIDTab As New DataTable
        Dim blodIDTab As New DataTable
        Dim resIDTab As New DataTable

        'Finner personID utifra personnummeret som blir skrevet inn
        personIDTab = person.getPersonID(personnummer)

        For Each row In personIDTab.Rows
            pID = row("personID")

        Next

        'Finner siste reservasjonID ved bruk av personID
        resIDTab = res.getLastResIDByPersonID(pID)

        For Each row In resIDTab.Rows
            rID = row("resID")
        Next


        'Finner siste blodtappingsID ved bruk av reservasjonsID
        blodIDTab = Blodlager.getLastBlodIDByResID(rID)

        For Each row In blodIDTab.Rows
            bID = row("blodID")
        Next


#Region "Validerings kode"
        'Validerer checkbox blodlegeme
        If validering.ValidereTall(cboBlodlegeme.Text) = False Then
            MessageBox.Show("Fyll inn blodlegeme med riktig format", "Feilmelding")
        End If

        'Validerer checkbox blodplasma
        If validering.ValidereTall(cboBlodplasma.Text) = False Then
            MessageBox.Show("Fyll inn blodplasma med riktig format", "Feilmelding")
        End If

        'Validerer checkbox blodplater
        If validering.ValidereTall(cboBlodplater.Text) = False Then
            MessageBox.Show("Fyll inn blodplater med riktig format", "Feilmelding")
        End If
#End Region


        'Legger inn checkbox verdiene inn i integer variabler
        Dim celleposer As Integer = cboBlodlegeme.Text
        Dim plasmaposer As Integer = cboBlodplasma.Text
        Dim plateposer As Integer = cboBlodplater.Text
        Dim dato As String = Date.Now.ToString("yyyy-MM-dd")

        'Henter ut prosedyrer for å legg inn verdiene rett inn i databasen
        Blodlager.leggInnBlodcelle(lagerID, bID, celleposer, dato)
        Blodlager.leggInnBlodplasma(lagerID, bID, plasmaposer)
        Blodlager.leggInnBlodplate(lagerID, bID, plateposer, dato)

        MessageBox.Show("Blodprodukter har blitt lagt inn", "Fullført")

    End Sub

    Private Sub skrivUtBlodProdukter()
        'Legger inn checkbox verdiene inn i integer variabler
        Dim ant_plasmaposer As Integer = cboBlodplasma.Text
        Dim ant_celleposer As Integer = cboBlodlegeme.Text
        Dim ant_plateposer As Integer = cboBlodplater.Text
        Dim blodtype As String = cboBlod.Text

        'Henter ut prosedyrer for å trekke fra verdiene i databasen
        Blodlager.skrivUtBlodceller(ant_celleposer, blodtype)
        Blodlager.skrivUtBlodplater(ant_plateposer, blodtype)
        Blodlager.skrivUtBlodplasma(ant_plasmaposer, blodtype)
    End Sub


    Private Sub visAlleBlodplasma()
        'Oppretter en tom tabell
        Dim blodPlasmaTab As New DataTable()

        Dim blodtype As String
        Dim blodplasma As String

        'Tømmer datagridview
        gridBlodplasma.Rows.Clear()

        'Fyller blodplasma tabell med verdier fra databasen på antall tilgjengelige blodplasma
        blodPlasmaTab = Blodlager.getAlleTilgjengeligeBlodPlasma()


        'Løkke for å lese alle verdiene i tabellen og setter det inn i variabler.
        For Each row In blodPlasmaTab.Rows
            blodtype = row("blodtype")
            blodplasma = row("Plasmaposer")

            'Legger inn verdier i datagrid
            gridBlodplasma.Rows.Add(blodtype, blodplasma)

        Next row

    End Sub

    Private Sub visAlleBlodplater()
        'Oppretter en tom tabell
        Dim blodPlaterTab As New DataTable()

        Dim blodtype As String
        Dim blodplater As String

        'Tømmer datagridview
        gridBlodplater.Rows.Clear()

        'Fyller blodplatertabellen med verdier fra databasen på antall tilgjengelige blodplater
        blodPlaterTab = Blodlager.getAlleTilgjengeligeBlodplater
        For Each row In blodPlaterTab.Rows
            blodtype = row("blodtype")
            blodplater = row("PlaterPoser")

            'Legger inn verdier i datagrid
            gridBlodplater.Rows.Add(blodtype, blodplater)
        Next row

    End Sub

    Private Sub visAlleBlodCeller()
        'Oppretter en tom tabell
        Dim blodCellerTab As New DataTable()

        Dim blodtype As String
        Dim blodceller As String

        'Tømmer datagridview
        gridBlodceller.Rows.Clear()

        'Fyller blodcellertabellen med verdier fra databasen på antall tilgjengelige blodceller
        blodCellerTab = Blodlager.getAlleTilgjengeligeBlodceller
        For Each row In blodCellerTab.Rows
            blodtype = row("blodtype")
            blodceller = row("Cellerposer")

            'Legger inn verdier i datagrid
            gridBlodceller.Rows.Add(blodtype, blodceller)
        Next row
    End Sub

    'Knapp som skriver ut blodprodukter og oppdaterer datagrid
    Private Sub btnSkrivUt_Click(sender As Object, e As EventArgs) Handles btnSkrivUt.Click

        skrivUtBlodProdukter()
        visAlleBlodCeller()
        visAlleBlodplasma()
        visAlleBlodplater()

    End Sub

    'Låser blodtype til en person ved inntasting av personnummer
    Private Sub txtLagerPersonnummer_TextChanged(sender As Object, e As EventArgs) Handles txtLagerPersonnummer.TextChanged
        'Oppgir max grense for lengden på personnummer tekstboksen
        txtLagerPersonnummer.MaxLength = 11

        'Når tekstboksen når 11 bokstaver så hentes blodtypen til blodgiveren inn automatisk
        'Checkboks blodtype blir da låst for å hindre registrering av feil blodtype
        If txtLagerPersonnummer.TextLength = 11 Then
            Dim BlodtypeTab As New DataTable()
            Dim blodtype As String
            Dim personID As Integer

            'Henter ut hele brukeren ved å kalle opp funksjonen getPersonByPersonnummer og legger det inn i en tabell
            BlodtypeTab = person.getPersonByPersonnummer(txtLagerPersonnummer.Text)

            'Løkke for å lese alle verdiene i tabellen og setter det inn i variabler.
            For Each row In BlodtypeTab.Rows
                blodtype = row("blodtype")
                personID = row("personID")
                cboBlod.Text = blodtype
                cboBlod.Enabled = False
            Next row

            'Feilsjekk om personnummeret ikke finnes ved å se om personID = 0
            If personID = "0" Then
                MsgBox("Personnummeret du søker etter eksisterer ikke")
            End If

        End If
    End Sub
#End Region



    'Gruppert søk/endre kode
#Region "Søk/Endre kode"
    'Knapp som viser brukerinfo
    Private Sub btnSok_Click(sender As Object, e As EventArgs) Handles btnSok.Click
        'Global variabel personnummer blir skrevet over av txtSok.text for senere bruk
        PubVar.personnummer = txtSok.Text
        visBruker()
        visPoststed()
    End Sub

    'Knapp som endrer brukerinfo og oppdaterer tekstboksene
    Private Sub btnEndreInfo_Click(sender As Object, e As EventArgs) Handles btnEndreInfo.Click
        endreInfo()
        visBruker()
        visPoststed()
    End Sub

    Private Sub visBruker()
        'Oppretter tomme variabler og tabeller
        PubVar.personnummer = txtSok.Text
        Dim brukerTab As New DataTable()
        Dim postnummere As New DataTable()

        Dim fornavn As String
        Dim etternavn As String
        Dim fodselsdato As Date
        Dim telefon As Integer
        Dim adresse As String
        Dim postnummer As Integer
        Dim blodtype As String
        Dim epost As String

        'Henter ut hele brukeren ved å kalle opp funksjonen GetBruker og legger det inn i en tabell
        brukerTab = blodgiver.GetBruker(txtSok.Text)

        'Løkke for å lese alle verdiene i tabellen og setter det inn i variabler.
        For Each row In brukerTab.Rows
            fornavn = row("fornavn")
            etternavn = row("etternavn")
            fodselsdato = row("fodselsdato")
            telefon = row("telefon")
            adresse = row("adresse")
            postnummer = row("postnummer")
            blodtype = row("blodtype")
            epost = row("epost")

            'Framvisning i tekstbokser ved å legge variabel verdiene inn
            txtFornavn.Text = fornavn
            txtEtternavn.Text = etternavn
            txtFodselsdato.Text = fodselsdato
            txtTelefon.Text = telefon
            txtAdresse.Text = adresse
            txtPostnummer.Text = postnummer
            cboBlodType.Text = blodtype
            txtEpost.Text = epost

        Next row

    End Sub

    Private Sub endreInfo()

        'Oppretter tomme variabler og tabeller
        Dim brukerTab As New DataTable()
        Dim postnummere As New DataTable()
        Dim fornavn As String
        Dim etternavn As String
        Dim fodselsdato As String
        Dim telefon As Integer
        Dim adresse As String
        Dim postnummer As Integer
        Dim blodtype As String
        Dim epost As String

        Try

            'Henter ut hele brukeren ved å kalle opp funksjonen GetBruker og legger det inn i en tabell
            brukerTab = blodgiver.GetBruker(txtSok.Text)

            'Løkke for å lese alle verdiene i tabellen og setter det inn i variabler.
            For Each row In brukerTab.Rows

                fornavn = row("fornavn")
                etternavn = row("etternavn")
                fodselsdato = row("fodselsdato")
                telefon = row("telefon")
                adresse = row("adresse")
                postnummer = row("postnummer")
                blodtype = row("blodtype")
                epost = row("epost")

#Region "Validering av info"
                'Validerer postnummer
                If validering.ValidereUtfylt(txtPostnummer.Text) = False Then
                    MessageBox.Show("Fyll ut postnummer", "Feilmelding")
                ElseIf validering.ValidereTall(txtPostnummer.Text) = False Then
                    MessageBox.Show("Postnummer skal bare inneholde tall", "Feilmelding")
                End If

                'Validerer telefon
                If validering.ValidereUtfylt(txtTelefon.Text) = False Then
                    MessageBox.Show("Fyll ut telefonnummer", "Feilmelding")
                ElseIf validering.ValidereTall(txtTelefon.Text) = False Then
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

                'Validerer epost
                If validering.ValidereUtfylt(txtEpost.Text) = False Then
                    MessageBox.Show("Fyll ut Epost", "Feilmelding")
                ElseIf validering.ValidereEmail(txtEpost.Text) = False Then
                    MessageBox.Show("Fyll inn epost med riktig format", "Feilmelding")
                End If

                If validering.ValidereBlodtype(cboBlodType.Text) = False Then
                    MessageBox.Show("Blodtypen finns ikke", "Feilmelding")
                End If
#End Region


                'Kaller opp prosedyrer og bruker verdiene i tekstboksene for å endre det som ligger i databasen
                person.endreFornavn(txtFornavn.Text)
                person.endreEtternavn(txtEtternavn.Text)
                person.endreFodselsdato(txtFodselsdato.Text)
                person.endreTelefon(txtTelefon.Text)
                person.endreAdresse(txtAdresse.Text)
                person.endrePostnummer(txtPostnummer.Text)
                person.endreBlodtype(cboBlodType.Text)
                person.endreEpost(txtEpost.Text)

            Next row

        Catch ex As Exception

        End Try

    End Sub
#End Region



    'Gruppert reservasjon kode
#Region "Reservasjon kode"
    Private Sub Reservasjonskalender_DateChanged(sender As Object, e As DateRangeEventArgs) Handles Reservasjonskalender.DateChanged

        idato = Reservasjonskalender.SelectionRange.Start
        resDato = idato.ToString("yyyy-MM-dd")
        Dim reservasjonsTabell As New DataTable
        reservasjonsTabell = res.getResValgtDato(resDato)
        res.fyllDatagrid(idato, Reservasjonskalender, resDato, ResGrid, reservasjonsTabell)

        res.fyllCombobox(resDato, resTidComboBox)



    End Sub

    Private Sub ResGrid_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles ResGrid.CellContentClick
        If e.ColumnIndex <> 4 Then
            Exit Sub
        End If

        Dim resID As Integer
        If e.ColumnIndex = 4 Then

            resID = ResGrid.Rows(e.RowIndex).Cells(3).Value
            ansatt.slettResAvResID(resID)
            MsgBox(resID)

            ResGrid.Rows.RemoveAt(e.RowIndex)


        End If
    End Sub

    Private Sub personnummer_TextChanged(sender As Object, e As EventArgs) Handles personnummer.TextChanged
        personnummer.MaxLength = 11
        If personnummer.TextLength = 11 Then
            Dim IDTab As New DataTable()

            IDTab = blodgiver.GetIDByPersonNr(personnummer.Text)

            For Each row In IDTab.Rows
                personID = row(0)
                MsgBox(personID)
            Next row

            If personID = "0" Then
                MsgBox("Personnummeret du søker etter eksisterer ikke")
            End If

        End If
    End Sub

    Private Sub btnLeggInnReservasjon_Click(sender As Object, e As EventArgs) Handles btnLeggInnReservasjon.Click

        res.addReservasjon(resTidComboBox, personnummer.Text, resDato)
        Dim reservasjonsTabell As New DataTable
        reservasjonsTabell = res.getResValgtDato(resDato)
        res.fyllDatagrid(idato, Reservasjonskalender, resDato, ResGrid, reservasjonsTabell)

    End Sub

    Private Sub btnSokPersonnummer_Click(sender As Object, e As EventArgs) Handles btnSokPersonnummer.Click

        Dim reservasjonsTabell As New DataTable
        reservasjonsTabell = res.getPersResByPersID(personID)
        res.fyllDatagrid(idato, Reservasjonskalender, resDato, ResGrid, reservasjonsTabell)

    End Sub
#End Region



    'Henter ut poststedet som postnummeret er koblet til og viser det fram i en tekstboks
    Private Sub visPoststed()

        Try

            Dim postnummerTab As New DataTable()

            Dim poststed As String

            postnummerTab = Postnr.GetPoststed(txtPostnummer.Text)

            For Each row In postnummerTab.Rows
                poststed = row("poststed")

                lbPoststed.Text = poststed
            Next row

        Catch ex As Exception

        End Try

    End Sub

    'Log ut knapp, fører brukeren til startsiden
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

    Private Sub btnInnkalling_Click(sender As Object, e As EventArgs) Handles btnInnkalling.Click
        Dim liste As DataTable = res.getAlleResMulig()
        Dim epostListe As New ArrayList()
        Dim persIDListe As New ArrayList()
        Dim datoListe As New ArrayList()
        Dim innkEpost As String
        Dim innkPersID As Integer
        Dim inkTime As String = ""
        Dim mnd As Date = Date.Now.AddMonths(-3)
        Dim send As Boolean = False
        Dim innkallDato As Date
        innkallDato = Date.Now.AddDays(7)
        res.fyllCombobox(innkallDato.ToString("yyyy-MM-dd"), innkallingTidspunktComboBox)

        For Each row In liste.Rows
            epostListe.Add(row(0).ToString)
            persIDListe.Add(row(1))
            datoListe.Add(row(2))
        Next

        For i = 0 To datoListe.Count - 1
            res.fyllCombobox(innkallDato.ToString("yyyy-MM-dd"), innkallingTidspunktComboBox)
            While innkallingTidspunktComboBox.SelectedItem Is Nothing
                innkallDato = innkallDato.AddDays(1)
                res.fyllCombobox(innkallDato.ToString("yyyy-MM-dd"), innkallingTidspunktComboBox)
            End While

            If innkallingTidspunktComboBox.SelectedItem IsNot Nothing Then
                If innkallingTidspunktComboBox.Items.Count > 15 Then
                    inkTime = innkallingTidspunktComboBox.Items.Item(15)
                Else
                    inkTime = innkallingTidspunktComboBox.Items.Item(0)
                End If
            End If
            If IsDBNull(datoListe.Item(i)) Then
                innkEpost = epostListe.Item(i).ToString()
                innkPersID = persIDListe.Item(i)
                'MsgBox(innkEpost & " Null")
                send = True
            ElseIf datoListe.Item(i) <= mnd Then
                Dim listeDato As Date = datoListe.Item(i)
                innkEpost = epostListe.Item(i).ToString()
                innkPersID = persIDListe.Item(i)
                'MsgBox(innkEpost & " Eldre eller lik")
                send = True
            ElseIf datoListe.Item(i) >= mnd Then
                Dim listeDato As Date = datoListe.Item(i)
                innkEpost = epostListe.Item(i).ToString()
                innkPersID = persIDListe.Item(i)
                'MsgBox(innkEpost & " Nyere")
                send = False
            End If

            If send = True Then
                res.reserver(innkallDato.ToString("yyyy-MM-dd"), innkPersID, inkTime)
                res.sendInnkalling(innkEpost, innkallDato.ToString("yyyy-MM-dd"), inkTime)
                MsgBox(innkEpost)
            Else
                MsgBox("Ingen blodgivere har vært borte i 3 måneder eller mer")
            End If
            res.fyllCombobox(innkallDato.ToString("yyyy-MM-dd"), innkallingTidspunktComboBox)
        Next


    End Sub

    Private Sub btnHasteInnkalling_Click(sender As Object, e As EventArgs) Handles btnHasteInnkalling.Click
        innkBlodtype = cboBlodtypeInnkalling.Text
        Dim liste As DataTable = res.getHasteResMulig(innkBlodtype)
        Dim epostListe As New ArrayList()
        Dim persIDListe As New ArrayList()
        Dim datoListe As New ArrayList()
        Dim hastInnkEpost As String
        Dim hastInnkPersID As Integer
        Dim hastInkTime As String = ""
        Dim mnd As Date = Date.Now.AddMonths(-3)
        Dim send As Boolean = False
        Dim hastInnkallDato As Date
        hastInnkallDato = Date.Now.AddDays(7)
        res.fyllCombobox(hastInnkallDato.ToString("yyyy-MM-dd"), innkallingTidspunktComboBox)

        For Each row In liste.Rows
            epostListe.Add(row(0).ToString)
            persIDListe.Add(row(1))
            datoListe.Add(row(2))
        Next

        For i = 0 To datoListe.Count - 1
            res.fyllCombobox(hastInnkallDato.ToString("yyyy-MM-dd"), innkallingTidspunktComboBox)
            While innkallingTidspunktComboBox.SelectedItem Is Nothing
                hastInnkallDato = hastInnkallDato.AddDays(1)
                res.fyllCombobox(hastInnkallDato.ToString("yyyy-MM-dd"), innkallingTidspunktComboBox)
            End While

            If innkallingTidspunktComboBox.SelectedItem IsNot Nothing Then
                If innkallingTidspunktComboBox.Items.Count > 15 Then
                    hastInkTime = innkallingTidspunktComboBox.Items.Item(15)
                Else
                    hastInkTime = innkallingTidspunktComboBox.Items.Item(0)
                End If
            End If
            If IsDBNull(datoListe.Item(i)) Then
                hastInnkEpost = epostListe.Item(i).ToString()
                hastInnkPersID = persIDListe.Item(i)
                MsgBox(hastInnkEpost & " Null")
                send = True
            ElseIf datoListe.Item(i) <= mnd Then
                Dim listeDato As Date = datoListe.Item(i)
                hastInnkEpost = epostListe.Item(i).ToString()
                hastInnkPersID = persIDListe.Item(i)
                MsgBox(hastInnkEpost & " Eldre eller lik")
                send = True
            ElseIf datoListe.Item(i) >= mnd Then
                Dim listeDato As Date = datoListe.Item(i)
                hastInnkEpost = epostListe.Item(i).ToString()
                hastInnkPersID = persIDListe.Item(i)
                MsgBox(hastInnkEpost & " Nyere")
                send = False
            End If

            If send = True Then
                'res.reserver(hastInnkallDato.ToString("yyyy-MM-dd"), hastInnkPersID, hastInkTime)
                'res.sendInnkalling(hastInnkEpost, hastInnkallDato.ToString("yyyy-MM-dd"), hastInkTime)
                MsgBox(hastInnkEpost & "Sendt")
            End If
            res.fyllCombobox(hastInnkallDato.ToString("yyyy-MM-dd"), innkallingTidspunktComboBox)
        Next
    End Sub

    Private Sub cboBlodtypeInnkalling_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBlodtypeInnkalling.SelectedIndexChanged
        innkBlodtype = cboBlodtypeInnkalling.Text
        Dim muligBlodgiver As DataTable = res.getHasteResMulig(innkBlodtype)
        Dim teller As Integer = 0
        For Each row In muligBlodgiver.Rows
            teller += 1
        Next
        txtboxTilgjengelig.Text = teller.ToString

    End Sub
End Class