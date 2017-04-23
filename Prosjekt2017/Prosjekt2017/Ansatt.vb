Public Class Ansatt
    Dim db As New Database
    Dim Abrukernavn = PubVar.ansattBruker

    'Henter ut alle ansatte
    Public Function getAlleAnsatt() As DataTable
        Return db.Query("SELECT * FROM Person JOIN Ansatt ON Person.personID = Ansatt.personID")
    End Function

    'Sletter reservasjon ved bruk av resID
    Public Function slettResAvResID(ByVal resID As Integer)
        Return db.Query("DELETE FROM Reservasjon WHERE resID = " & resID)
    End Function


End Class
