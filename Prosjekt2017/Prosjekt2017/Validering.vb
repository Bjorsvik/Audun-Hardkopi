Public Class Validering

    'Tom konstruktør
    Public Sub New()

    End Sub

    'Validerer tall
    Public Function ValidereTall(tall As String) As Boolean
        If IsNumeric(tall) Then
            Return True

        Else
            Return False
        End If
    End Function

    'Validerer om tekstboksen har blitt fylt ut
    Public Function ValidereUtfylt(tekst As String) As Boolean
        If tekst = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    'Validerer epost
    Public Function ValidereEmail(email As String) As Boolean
        If email.Contains("@") Then
            Return True
        Else
            Return False
        End If
    End Function

    'Validerer telefon
    Public Function ValidereTelefon(telefonnummer As String) As Boolean
        If telefonnummer.Length = 8 Then
            Return True
        Else
            Return False
        End If
    End Function

    'Validerer personnummer
    Public Function ValiderePersonnummer(personnummer As String) As Boolean
        If personnummer.Length = 11 Then
            Return True
        Else
            Return False
        End If
    End Function

    'Validerer Blodtype
    Public Function ValidereBlodtype(blodtype As String) As Boolean
        If blodtype.Contains("A+") Then
            Return True
        ElseIf blodtype.Contains("A-") Then
            Return True
        ElseIf blodtype.Contains("B+") Then
            Return True
        ElseIf blodtype.Contains("B-") Then
            Return True
        ElseIf blodtype.Contains("0+") Then
            Return True
        ElseIf blodtype.Contains("0-") Then
            Return True
        ElseIf blodtype.Contains("AB-") Then
            Return True
        ElseIf blodtype.Contains("AB+") Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
