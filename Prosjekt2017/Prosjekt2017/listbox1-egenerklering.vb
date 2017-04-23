Public Class listbox1_egenerklering
    Private Sub listbox1_egenerklering_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListBox1.Items.Clear()
        ListBox1.Items.Add("Blodoverføring er en uerstattelig del av moderne medisinsk behandling.")
        ListBox1.Items.Add("Likevell kan både det å motta blodoverføring og det å gi blod medøre rosiko")
        ListBox1.Items.Add(" ")
        ListBox1.Items.Add("    - Noen sykdommer kan overføres med blod fra blodgiver til pasient")
        ListBox1.Items.Add("      Man kan være bærer av overførbare smittestoffer uten selv")
        ListBox1.Items.Add("      å vite om det. En nylig smittet person kan være smittefarlig selv om")
        ListBox1.Items.Add("      testene ikke viser noe galt. Av den grunn må personer som kan ha blitt")
        ListBox1.Items.Add("      utsatt for smitte, ikke gi blod. Vi stiller derfor mange spørsmål som")
        ListBox1.Items.Add("      vedrører situasjoner der man kan ha blitt utsatt for smitte")
        ListBox1.Items.Add(" ")
        ListBox1.Items.Add("    - Hvis folk er frisk, er risikoen ved å gi blod svært liten. Noen sykdommer")
        ListBox1.Items.Add("      kan gi økt risiko for komplikasjoner etter blodgivning. Vi stiller derfor")
        ListBox1.Items.Add("      mange spørsmål om blodgiverens egen helse, for å være sikre på at han eller")
        ListBox1.Items.Add("      hun trygt kan gi blod")
        ListBox1.Items.Add(" ")
        ListBox1.Items.Add("Vennligst besvar spørsmålene nedefor ærlig og oppriktig under forutsetning av")
        ListBox1.Items.Add("blodbankpersonalets taushetsplikt. Blodbanken må ha full tillit til ar de opplysningene")
        ListBox1.Items.Add("som gis er riktige. Er du i tvil om du kan være blodgiver, kan du drøfte dette")
        ListBox1.Items.Add("med den som kontrollerer spørsmålene")
        ListBox1.Items.Add(" ")
        ListBox1.Items.Add("Blodbanken har informasjonsmateriell om blodgivningen. Hvis du ikke har lest dette")
        ListBox1.Items.Add("tidligere, oppfordrer vi deg til å gjøre å gjøre det nå!")
    End Sub
    Private Sub btnLukk_Click(sender As Object, e As EventArgs) Handles btnLukk.Click
        Me.Close()
    End Sub

End Class