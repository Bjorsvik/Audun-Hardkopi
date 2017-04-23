Imports MySql.Data.MySqlClient
Public Class Blodgiver
    Inherits Person
    Private db As New Database()

    Private passord As String

    'Tom konstruktør
    Public Sub New()

    End Sub

    'Oppretter et objekt av blodgiver
    Public Sub New(passord As String, ByVal fornavn As String, ByVal etternavn As String, ByVal fodselsdato As String, ByVal personnummer As String, ByVal telefon As Integer,
                   ByVal adresse As String, ByVal postnummer As Integer, ByVal epost As String)
        MyBase.New(fornavn, etternavn, fodselsdato, personnummer, telefon, adresse, postnummer, epost)
        Me.passord = passord
    End Sub

    'Registrering av Blodgiver
    Public Sub regBlodgiver()
        regPerson()
        Dim pID As DataTable = getLastPersonID()
        Dim personID As String = ""

        For Each id In pID.Rows
            personID = id(0).ToString()
        Next id

        MsgBox(personID)
        db.Query("INSERT INTO Blodgiver(personID, Bpassord) VALUES('" & personID & "', '" & passord & "' )")
    End Sub

    'Viser historikken til blodgiveren (dato og blodtapping)
    Public Function visHistorikk(personID As Integer)
        Return db.Query("SELECT Reservasjon.dato, Blodtype.blodposer FROM Person
                         JOIN Reservasjon ON Person.personID = Reservasjon.personID
                         JOIN Blodtype ON Reservasjon.resID = Blodtype.resID
                         WHERE Person.personID = " & "'" & personID & "' " &
                         "Group By Blodtype.blodID")
    End Function
    'Henter ut brukeren/blodgiveren ved bruk av personnummer
    Public Function GetBruker(personnummer As String) As DataTable
        Return db.Query("SELECT * FROM Person JOIN Blodgiver ON Person.personID = Blodgiver.personID WHERE personnummer = " & "'" & personnummer & "'")
    End Function
    'Henter ut alle blodgivere
    Public Function getAlleBlodgivere() As DataTable
        Return db.Query("SELECT * FROM Person JOIN Blodgiver ON Person.personID = Blodgiver.personID")
    End Function
    'Henter ut personID ved å benytte seg av personnummer
    Public Function GetIDByPersonNr(ByVal personnummer As String) As DataTable
        Return db.Query("SELECT personID FROM Person WHERE personnummer = " & "'" & personnummer & "'")
    End Function
    'Legger til karantene
    Public Sub addKarantene(ByVal dbKDato As Date, ByVal personID As Integer)
        db.Query("UPDATE Blodgiver SET karantene = '" & dbKDato.ToString("yyyy-MM-dd") & "' WHERE personID = '" & personID & "'")
    End Sub
    'Legger til livstid karantene
    Public Sub addLivstid(ByVal personID As Integer)
        db.Query("UPDATE Blodgiver SET livstid = True Where personID = '" & personID & "'")
    End Sub
    'Registrering av egenerklæring
    Public Sub registrerEgenerklering(ByVal dbDato As Date, spmEpost As Boolean, spmSMS As Boolean, controllListe As String, personID As Integer)
        db.Query("Insert into Egenerklering (dato, varsling_epost, varsling_sms, bolk1, personID) values ('" & dbDato.ToString("yyyy-MM-dd") & "', " & spmEpost & ", " & spmSMS & ", '" & controllListe & "', " & personID & ");")
    End Sub
    'Henter ut karantene info
    Public Function getKarantene(ByVal personID As Integer)
        Return db.Query("SELECT karantene from Blodgiver Where personID = '" & personID & "'")
    End Function
    'Henter ut livstids karantene info
    Public Function getLivstid(ByVal personID As Integer)
        Return db.Query("SELECT livstid from Blodgiver WHERE personID = '" & personID & "'")
    End Function

End Class
