Imports System.Net.Mail
Public Class Reservasjoner

    Dim db As New Database()
    Dim ansatt As New Ansatt()
    Dim blodgiver As New Blodgiver()

    'Henter ut reservasjon ved valgt dato
    Public Function getResValgtDato(ByVal resDato As String)
        Return db.Query("SELECT * from Reservasjon WHERE dato = '" & resDato & "'")
    End Function

    'Henter ut personens reservasjon ved bruk av personID
    Public Function getPersResByPersID(ByVal personID As String) As DataTable
        Return db.Query("SELECT * from Reservasjon WHERE personID = '" & personID & "' AND dato >= NOW()")
    End Function

    'Henter ut siste resID
    Public Function getLastResID() As DataTable
        Return db.Query("SELECT MAX(resID) FROM Reservasjon")
    End Function

    'Henter ut alle tidspunkter
    Public Function getAlleTidspunkt() As DataTable
        Return db.Query("SELECT * from Tidspunkt")
    End Function

    'Henter ut timene som er okkupert
    Public Function getOpptattTimer(ByVal resDato) As DataTable
        Return db.Query("SELECT *
                FROM Reservasjon
                WHERE tidspunkt IN
                (   SELECT tidspunkt
                    FROM Reservasjon
                    Where dato = '" & resDato & "'
                    GROUP BY tidspunkt
                     HAVING COUNT(*) >=5
                )
                And dato = '" & resDato & "'
                group by tidspunkt")
    End Function

    'Henter ut siste resID ved bruk av personID
    Public Function getLastResIDByPersonID(personID As Integer) As DataTable
        Return db.Query("SELECT MAX(resID) As resID FROM Reservasjon JOIN Person ON Reservasjon.personID = Person.personID WHERE Person.personID = '" & personID & "'")
    End Function

    'Reserver time
    Public Sub reserver(ByVal dato As String, ByVal personID As Integer, ByVal tid As String)

        Dim resID As DataTable = getLastResID()
        Dim reservasjonID As String = ""
        Dim nextresID As Integer


        For Each id In resID.Rows
            reservasjonID = id(0).ToString()
        Next id

        If reservasjonID = "" Then
            reservasjonID = "0"
        End If

        nextresID = CInt(reservasjonID) + 1

        'MsgBox(CInt(reservasjonID))

        db.Query("INSERT INTO Reservasjon (resID, dato, personID, tidspunkt) VALUES ('" & nextresID & "', '" & dato & "', '" & personID & "', '" & tid & "');")
    End Sub

    'Fyller ut combobox med tilgjengelige tidspunkter utifra hvilken dato som er valgt
    Public Sub fyllCombobox(ByVal resDato, ByRef comboBox)
        Dim timer As DataTable = getAlleTidspunkt()
        Dim opptattTimer As DataTable = getOpptattTimer(resDato)
        Dim comboTimer As New ArrayList()
        Dim opptattArray As New ArrayList()
        Dim timeArray As New ArrayList()

        comboBox.DataSource = Nothing

        For Each time In timer.Rows
            timeArray.Add(time(0).ToString)
            'MsgBox(time(0).ToString)
        Next
        For Each opptatt In opptattTimer.Rows
            opptattArray.Add(opptatt(3).ToString)
            'MsgBox("time opptatt" & opptatt(0).ToString)
        Next

        'MsgBox(opptattArray.Count.ToString)
        For i = 0 To opptattArray.Count - 1
            'MsgBox(opptattArray(i).ToString)
            If timeArray.Contains(opptattArray(i).ToString) Then
                timeArray.Remove(opptattArray(i).ToString)
                'MsgBox("fjerner" & opptattArray(0).ToString)
            End If
        Next

        comboBox.DataSource = timeArray
        comboBox.DisplayMember = "Tidspunkt"
    End Sub

    'Legger til reservasjon
    Public Sub addReservasjon(ByRef ComboBox As Object, ByVal personnummer As String, ByVal resDato As String)
        Dim personID As String = ""
        Dim tid As String = ComboBox.SelectedValue.ToString()


        Dim id As New DataTable()

        id = blodgiver.GetIDByPersonNr(personnummer)

        For Each rad In id.Rows
            personID = rad(0).ToString()
        Next rad
        Dim tempID As String = personID
        reserver(resDato, tempID, tid)
    End Sub

    Public Sub fyllDatagrid(ByVal idato As Date, ByRef Reservasjonskalender As Object, ByVal resDato As String, ByRef ResGrid As Object, ByVal reservasjonsTabell As DataTable)
        Dim resArray As New ArrayList()
        Dim dato As Date
        Dim persid As String
        Dim tidspunkt As String
        Dim resid As String
        ResGrid.Rows.Clear()

        'MsgBox(dbDato)

        For Each reserv In reservasjonsTabell.Rows()
            resid = reserv(0).ToString
            dato = reserv(1).ToString
            persid = reserv(2).ToString
            tidspunkt = reserv(3).ToString
            ResGrid.Rows.Add(dato.ToString("yyyy-MM-dd"), tidspunkt, persid, resid)
        Next
    End Sub

    Public Function tilgjengeligePersAvBlodtype(ByVal blodtype As String)
        Return db.Query("")
    End Function

    Public Sub sendInnkalling(ByVal innEpost As String, ByVal dato As String, ByVal tidspunkt As String)
        Dim mail As New MailMessage()
        Try
            mail.From = New MailAddress("Blodigalvor113@gmail.com")
            mail.To.Add(innEpost)
            mail.Subject = "Innkalling til blodgivning"
            mail.Body = "Du får med denne eposten en innkalling til time ved St. Olavs hospital den " & dato & " klokken " & tidspunkt
            Dim Smtp As New SmtpClient("smtp.gmail.com")
            Smtp.Port = 587
            Smtp.EnableSsl = True
            Smtp.Credentials = New System.Net.NetworkCredential("Blodigalvor113@gmail.com", "vanadium")
            Smtp.Send(mail)
            MsgBox("Innkalling sendt")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Public Function getAlleResMulig() As DataTable
        Return db.Query("SELECT epost, Person.personID, MAX(dato)
                        FROM Person
                        LEFT JOIN Reservasjon ON Person.personID = Reservasjon.personID
                        Group by Person.personID")
    End Function
    Public Function getHasteResMulig(ByVal blodtype As String) As DataTable
        Return db.Query("SELECT epost, Person.personID, MAX(dato)
                        FROM Person
                        LEFT JOIN Reservasjon ON Person.personID = Reservasjon.personID
                        Where blodtype = '" & blodtype & "'
                        Group by Person.personID")
    End Function

End Class
