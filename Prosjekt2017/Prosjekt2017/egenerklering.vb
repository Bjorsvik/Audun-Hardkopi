Imports MySql.Data.MySqlClient

Public Class egenerklering
    Private tilkobling As MySqlConnection
    Dim blodgiver As New Blodgiver()
    Dim personID As Integer
    Dim db As New Database()
    Dim dato As New Date()
    Dim dbDato As Date
    Dim dbKDato As Date


    Private Sub egenerklering_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim personnummer = PubVar.personnummer
        visBrukerEgenerklering()
        dato = Date.Now
        dbDato = dato.ToString("yyyy-MM-dd")
        lblDato.Text = dbDato
        Me.Show()
        Label1.Select() 'Får formen til å loade øverst på siden
    End Sub
    'Legger inn navn, etternavn og brukernummer i formen automatisk
    Private Sub visBrukerEgenerklering()
        Dim brukerTab As New DataTable()

        Dim fornavn As String
        Dim etternavn As String

        brukerTab = blodgiver.GetPersonByGlobalPersonnummer()

        For Each row In brukerTab.Rows

            fornavn = row("fornavn")
            etternavn = row("etternavn")
            personID = row("personID")

            lblFornavn.Text = fornavn
            lblEtternavn.Text = etternavn
            lblPersonID.Text = personID
        Next row
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSendInn.Click


        If chkSjekk.Checked Then

            'varsling_epost
            Dim spmEpost As String
            If rbEpostJa.Checked Then
                spmEpost = 1
            Else
                spmEpost = 0
            End If

            Dim varsling_epost As String = spmEpost
            'Vi har valgt å dele inn spørsmålene i bolker.
            'varsling_sms
            Dim spmSMS As String
            If rbSMSJa.Checked Then
                spmSMS = 1
            Else
                spmSMS = 0
            End If

            Dim varsling_sms As String = spmSMS
            'Vi regner en ny bolk for hver tjukke overskrift.
            '#Region "bolk1"

            Dim controllListe As String = ""

            For Each ctrl As Control In Me.Controls
                If TypeOf ctrl Is Panel Then
                    For Each valg In ctrl.Controls.OfType(Of RadioButton)
                        If DirectCast(valg, RadioButton).Checked Then
                            controllListe += "1"
                        Else
                            controllListe += "0"
                        End If
                    Next
                End If
            Next

            'MsgBox(spmListe)

            'karantenedato = Date.Now
            Dim karanteneTid As Integer
            Dim kDato As New Date()

            If rb811.Checked Or rb511.Checked Or rb521.Checked Or rb531.Checked Or rb541.Checked Or
                rb551.Checked Or rb561.Checked Or rb571.Checked Or rb581.Checked Or rb591.Checked Or
                rb5101.Checked Or rb5111.Checked Or rb5121.Checked Or rb5131.Checked Or rb5141.Checked Or
                rb5151.Checked Or rb911.Checked Or rb921.Checked Then
                blodgiver.addLivstid(personID)


            ElseIf rb411.Checked Then
                kDato = dato.AddYears(2) 'To års karantenetid, selv ved skuddår
                dbKDato = kDato.ToString("yyyy-MM-dd")
                blodgiver.addKarantene(dbKDato, personID)


            ElseIf rb311.Checked Or rb311.Checked Or rb321.Checked Or rb331.Checked Or rb341.Checked Or
                rb351.Checked Or rb361.Checked Or rb371.Checked Or rb381.Checked Or rb311.Checked Or
                rb311.Checked Or rb711.Checked Or rb721.Checked Then
                kDato = dato.AddMonths(12) 'Ett års karantenetid, selv ved skuddår
                dbKDato = kDato.ToString("yyyy-MM-dd")
                blodgiver.addKarantene(dbKDato, personID)


            ElseIf rb311.Checked Or rb321.Checked Or rb331.Checked Or rb341.Checked Or rb351.Checked Or
                rb361.Checked Or rb371.Checked Or rb381.Checked Or rb391.Checked Or rb3101.Checked Or
                rb611.Checked Or rb621.Checked Or rb631.Checked Or rb641.Checked Or rb651.Checked Or
                rb661.Checked Or rb671.Checked Or rb741.Checked Then
                kDato = dato.AddMonths(6) 'Halvt års karantenetid, selv ved skuddår
                dbKDato = kDato.ToString("yyyy-MM-dd")
                blodgiver.addKarantene(dbKDato, personID)

            ElseIf rb211.Checked Or rb212.Checked Or rb231.Checked Or rb241.Checked Or rb251.Checked Then
                karanteneTid = 28
                kDato = dato.AddDays(karanteneTid)
                dbKDato = kDato.ToString("yyyy-MM-dd")
                blodgiver.addKarantene(dbKDato, personID)
            End If

            blodgiver.registrerEgenerklering(dbDato, spmEpost, spmSMS, controllListe, personID)



            'db.Query("insert into Egenerklering (dato, varsling_epost, varsling_sms, bolk1, bolk2, bolk3, bolk4, bolk5, bolk6, bolk7, bolk8, bolk9, personID, karantene) 
            '               values (CURDATE(), @varsling_epost, @varsling_sms, @bolk1, @bolk2, @bolk3, @bolk4, @bolk5, @bolk6, @bolk7, @bolk8, @bolk9, @personID, DATE_ADD(CURDATE(), INTERVAL + @karantene DAY))")

            'Dim sqlbolker As New MySqlCommand(sqlSporring, tilkobling)

            'sqlbolker.Parameters.AddWithValue("@varsling_epost", varsling_epost)
            'sqlbolker.Parameters.AddWithValue("@varsling_sms", varsling_sms)
            'sqlbolker.Parameters.AddWithValue("@bolk1", bolk1)
            'sqlbolker.Parameters.AddWithValue("@bolk2", bolk2)
            'sqlbolker.Parameters.AddWithValue("@bolk3", bolk3)
            'sqlbolker.Parameters.AddWithValue("@bolk4", bolk4)
            'sqlbolker.Parameters.AddWithValue("@bolk5", bolk5)
            'sqlbolker.Parameters.AddWithValue("@bolk6", bolk6)
            'sqlbolker.Parameters.AddWithValue("@bolk7", bolk7)
            'sqlbolker.Parameters.AddWithValue("@bolk8", bolk8)
            'sqlbolker.Parameters.AddWithValue("@bolk9", bolk9)
            'sqlbolker.Parameters.AddWithValue("@personID", personID)
            'sqlbolker.Parameters.AddWithValue("@karantene", karantene)


            'sqlbolker.ExecuteNonQuery()
            MsgBox("Din egenerklæring er nå registrert.")
                Me.Close()
            Else
                MsgBox("Du må bekrefte at du har lest informasjonen øverst i spørreskjemaet", MsgBoxStyle.Information)
        End If
    End Sub
    'Knappen som sender inn spørreskjemaet
    Private Sub btnInfo_Click(sender As Object, e As EventArgs) Handles btnInfo.Click
        listbox1_egenerklering.Show()
        'Denne knappen åpner formen listbox1_egenerklering
    End Sub
    ''Denne suben gjør at når man trykker på en av radioknappene i bolk7 (besvares av kvinner)
    'vil det ikke være mulig å trykke på noen av spørsmålene i bolk 8 (besvares av menn)
    Private Sub rb711_CheckedChanged(sender As Object, e As EventArgs) Handles rb711.CheckedChanged,
        rb712.CheckedChanged, rb721.CheckedChanged, rb722.CheckedChanged, rb731.CheckedChanged,
        rb732.CheckedChanged, rb741.CheckedChanged, rb741.CheckedChanged

        If rb711.Checked = True Or rb712.Checked = True Or rb811.Checked = True Or
            rb721.Checked = True Or rb722.Checked = True Or rb731.Checked = True Or
            rb732.Checked = True Or rb741.Checked = True Or rb742.Checked = True Then

            rb811.Enabled = False
            rb812.Enabled = False
        End If

    End Sub
    'Denne suben gjør at når man trykker på en av radioknappene i bolk8 (besvares av herrer)
    'vil det ikke være mulig å trykke på noen av spørsmålene i bolk 7 (besvares av kvinner)
    Private Sub rb811_CheckedChanged(sender As Object, e As EventArgs) Handles rb811.CheckedChanged, rb812.CheckedChanged
        If rb811.Checked = True Or rb812.Checked Then
            rb711.Enabled = False
            rb712.Enabled = False
            rb721.Enabled = False
            rb722.Enabled = False
            rb731.Enabled = False
            rb732.Enabled = False
            rb741.Enabled = False
            rb742.Enabled = False
        End If
    End Sub


End Class