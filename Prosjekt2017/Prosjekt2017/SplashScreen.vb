Public Class SplashScreen
    Private Sub SplashScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.CenterToScreen()
        Timer1.Interval = 10
        Timer1.Enabled = True
        pbLoad.BackColor = Color.Orange
        pbLoad.ForeColor = Color.OrangeRed
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        pbLoad.Increment(1)
        lblProsent.Text = pbLoad.Value.ToString() & "%"

        If pbLoad.Value = 100 Then
            Hjemmeside.Show()
            Me.Hide()
            Timer1.Enabled = False
        End If
    End Sub


End Class