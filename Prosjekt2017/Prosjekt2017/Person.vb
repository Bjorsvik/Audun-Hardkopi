Public Class Person
    Private db As New Database()

    Private fornavn As String
    Private etternavn As String
    Private fodselsdato As String
    Private personnummer As String
    Private telefon As Integer
    Private adresse As String
    Private postnummer As Integer
    Private epost As String

    'Tom konstruktør
    Public Sub New()

    End Sub

    'Opprette objekt av person
    Public Sub New(fornavn As String, etternavn As String, fodselsdato As String, personnummer As String,
                   telefon As Integer, adresse As String, postnummer As Integer, epost As String)


        Me.fornavn = fornavn
        Me.etternavn = etternavn
        Me.fodselsdato = fodselsdato
        Me.personnummer = personnummer
        Me.telefon = telefon
        Me.adresse = adresse
        Me.postnummer = postnummer
        Me.epost = epost

    End Sub
    'Registrere person
    Public Sub regPerson()
        db.Query("INSERT INTO Person(fornavn, etternavn, fodselsdato, telefon, epost, postnummer, adresse, personnummer) VALUES('" & fornavn & "', '" & etternavn &
                 "', '" & fodselsdato & "', '" & telefon & "', '" & epost & "', '" & postnummer & "', '" & adresse & "', '" & personnummer & "')")
    End Sub
    'Henter person fra personnummer
    Public Function getPersonByPersonnummer(personnummer As String) As DataTable
        Return db.Query("SELECT * FROM Person WHERE personnummer = '" & personnummer & "'")
    End Function
    'Endrer fornavn
    Public Sub endreFornavn(fornavn As String)
        db.Query("UPDATE Person SET fornavn = '" & fornavn & "' WHERE personnummer = '" & PubVar.personnummer & "'")
    End Sub
    'Endrer etternavn
    Public Sub endreEtternavn(etternavn As String)
        db.Query("UPDATE Person SET etternavn = '" & etternavn & "' WHERE personnummer = '" & PubVar.personnummer & "'")
    End Sub
    'Endrer fødselsdato
    Public Sub endreFodselsdato(fodselsdato As String)
        db.Query("UPDATE Person SET fodselsdato = '" & fodselsdato & "' WHERE personnummer = '" & PubVar.personnummer & "'")
    End Sub
    'Endrer telefonnummer
    Public Sub endreTelefon(telefon As Integer)
        db.Query("UPDATE Person SET telefon = '" & telefon & "' WHERE personnummer = '" & PubVar.personnummer & "'")
    End Sub
    'Endrer adresse
    Public Sub endreAdresse(adresse As String)
        db.Query("UPDATE Person SET adresse = '" & adresse & "' WHERE personnummer = '" & PubVar.personnummer & "'")
    End Sub
    'Endrer postnummer
    Public Sub endrePostnummer(postnummer As String)
        db.Query("UPDATE Person SET postnummer = '" & postnummer & "' WHERE personnummer = '" & PubVar.personnummer & "'")
    End Sub
    'Endrer blodtype
    Public Sub endreBlodtype(blodtype As String)
        db.Query("UPDATE Person SET blodtype = '" & blodtype & "' WHERE personnummer = '" & PubVar.personnummer & "'")
    End Sub
    'Endrer epost
    Public Sub endreEpost(epost As String)
        db.Query("UPDATE Person SET epost = '" & epost & "' WHERE personnummer = '" & PubVar.personnummer & "'")
    End Sub
    'Henter person ved bruk av et globalt variabel av personnummer
    Public Function GetPersonByGlobalPersonnummer() As DataTable
        Return db.Query("SELECT * FROM Person JOIN Blodgiver WHERE Person.personID = Blodgiver.personID And personnummer = " & "'" & PubVar.personnummer & "'")
    End Function
    'Henter siste personID som har blitt registrert i person
    Public Function getLastPersonID() As DataTable
        Return db.Query("SELECT MAX(personID) FROM Person")
    End Function
    'Henter ut personen ved bruk av personID
    Public Function getPersonID(ByVal personnummer As String) As DataTable
        Return db.Query("SELECT * FROM Person WHERE personnummer = '" & personnummer & "'")
    End Function
    'Henter ut blodtypen til personen
    Public Function getBlodtype(ByVal personnummer As String) As DataTable
        Return db.Query("SELECT * FROM Person WHERE personnummer = '" & personnummer & "'")
    End Function

    Public Function getPersonIDByEpost(ByVal epost As String) As DataTable
        Return db.Query("SELECT personID FROM Person WHERE epost = '" & epost & "'")
    End Function

    Public Function getPersonIDByBlodtype(ByVal blodtype As String) As DataTable
        Return db.Query("SELECT personID FROM Person WHERE blodtype = '" & blodtype & "'")
    End Function



End Class
