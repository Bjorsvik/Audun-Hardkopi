Imports MySql.Data.MySqlClient
Public Class Postnummer
    Dim db As New Database

    'Tom konstruktør
    Public Sub New()
    End Sub
    'Henter ut poststed som tilhører postnummeret som blir skrevet inn
    Public Function GetPoststed(postnummer As Integer) As DataTable
        Return db.Query("SELECT poststed From Postnummer WHERE postnummer = " & "'" & postnummer & "'")
    End Function
End Class
