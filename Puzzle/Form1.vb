Public Class Form1
    Dim grilla(8) As Integer
    Dim automatico As Boolean
    Dim automatico2 As Boolean

    Dim contador_tiempo1 As Double
    Dim contador_tiempo2 As Double
    Dim contador_tiempo3 As Double
    Dim contador_tiempo_total As Double
    Dim movimientos As Integer
    Dim dificultad As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btn_0.BackgroundImage = Nothing
        btn_1.BackgroundImage = ImageList1.Images(1)
        btn_2.BackgroundImage = ImageList1.Images(2)
        btn_3.BackgroundImage = ImageList1.Images(3)
        btn_4.BackgroundImage = ImageList1.Images(4)
        btn_5.BackgroundImage = ImageList1.Images(5)
        btn_6.BackgroundImage = ImageList1.Images(6)
        btn_7.BackgroundImage = ImageList1.Images(7)
        btn_8.BackgroundImage = ImageList1.Images(8)
        grilla = {0, 1, 2, 3, 4, 5, 6, 7, 8}
    End Sub

    Private Sub check_button(ByRef btnA As Button, ByRef btnB As Button, ByVal A As Integer, ByVal B As Integer)
        Dim temporal As Integer
        'Dim btn As Button
        If btnB.BackgroundImage Is Nothing Then
            If automatico = False Then
                'MessageBox.Show(A, "A1")
                'MessageBox.Show(grilla(A), "A2")
                'MessageBox.Show(B, "B1")
                'MessageBox.Show(grilla(B), "B2")
                temporal = grilla(B)
                grilla(B) = grilla(A)
                grilla(A) = temporal
                If automatico2 = False Then
                    movimientos = movimientos + 1
                End If
                'For x = 0 To 8 'actualizar resultados
                '    btn = DirectCast(Controls("btn_" & x.ToString), Button)
                '    btn.Text = grilla(x)
                'Next
            End If

            btnB.BackgroundImage = btnA.BackgroundImage
            btnA.BackgroundImage = Nothing
        End If
    End Sub

    Private Sub resuelto()
        'Dim btn As Button
        Dim contador As Integer = 0
        'btn = DirectCast(Controls("btn_" & MyValue.ToString), Button)
        'btn.BackgroundImage = Nothing
        'btn.Text = MyValue
        If automatico = False Then

            For i As Integer = 0 To 8
                If grilla(i) = i Then
                Else
                    contador += 1
                End If
            Next
            If contador = 0 Then
                AxWindowsMediaPlayer1.URL = Application.StartupPath + "\sonidos\musicawin.mp3"
                AxWindowsMediaPlayer2.URL = Application.StartupPath + "\sonidos\ganar.mp3"
                Timer1.Stop()
                MessageBox.Show("Ganastee! :D", "Ganasteee")
            End If
        End If

    End Sub

    Private Sub btn_0_Click(sender As Object, e As EventArgs) Handles btn_0.Click
        check_button(btn_0, btn_1, 0, 1)
        check_button(btn_0, btn_3, 0, 3)
        resuelto()
    End Sub
    Private Sub btn_1_Click(sender As Object, e As EventArgs) Handles btn_1.Click
        check_button(btn_1, btn_0, 1, 0)
        check_button(btn_1, btn_2, 1, 2)
        check_button(btn_1, btn_4, 1, 4)
        resuelto()
    End Sub
    Private Sub btn_2_Click(sender As Object, e As EventArgs) Handles btn_2.Click
        check_button(btn_2, btn_1, 2, 1)
        check_button(btn_2, btn_5, 2, 5)
        resuelto()
    End Sub
    Private Sub btn_3_Click(sender As Object, e As EventArgs) Handles btn_3.Click
        check_button(btn_3, btn_0, 3, 0)
        check_button(btn_3, btn_4, 3, 4)
        check_button(btn_3, btn_6, 3, 6)
        resuelto()
    End Sub
    Private Sub btn_4_Click(sender As Object, e As EventArgs) Handles btn_4.Click
        check_button(btn_4, btn_1, 4, 1)
        check_button(btn_4, btn_3, 4, 3)
        check_button(btn_4, btn_5, 4, 5)
        check_button(btn_4, btn_7, 4, 7)
        resuelto()
    End Sub
    Private Sub btn_5_Click(sender As Object, e As EventArgs) Handles btn_5.Click
        check_button(btn_5, btn_2, 5, 2)
        check_button(btn_5, btn_4, 5, 4)
        check_button(btn_5, btn_8, 5, 8)
        resuelto()
    End Sub
    Private Sub btn_6_Click(sender As Object, e As EventArgs) Handles btn_6.Click
        check_button(btn_6, btn_3, 6, 3)
        check_button(btn_6, btn_7, 6, 7)
        resuelto()
    End Sub
    Private Sub btn_7_Click(sender As Object, e As EventArgs) Handles btn_7.Click
        check_button(btn_7, btn_4, 7, 4)
        check_button(btn_7, btn_6, 7, 6)
        check_button(btn_7, btn_8, 7, 8)
        resuelto()
    End Sub
    Private Sub btn_8_Click(sender As Object, e As EventArgs) Handles btn_8.Click
        check_button(btn_8, btn_5, 8, 5)
        check_button(btn_8, btn_7, 8, 7)
        resuelto()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'super ataque
        contador_tiempo1 = contador_tiempo1 - 0.5
        If contador_tiempo1 <= -0.5 Then
            AxWindowsMediaPlayer2.URL = Application.StartupPath + "\sonidos\superataque.mp3"
            JugarToolStripMenuItem.PerformClick()
            If dificultad = 0 Then
                DificilToolStripMenuItem.PerformClick()
            ElseIf dificultad = 1 Then
                NormalToolStripMenuItem.PerformClick()
            ElseIf dificultad = 2 Then
                PesadillaToolStripMenuItem.PerformClick()
            End If
        End If
        lbl_tiempo1.Text = contador_tiempo1.ToString + " s"

        'ataque 2
        Dim btn As Button
        Dim Myvalue As Integer
        contador_tiempo2 = contador_tiempo2 - 0.5

        If contador_tiempo2 <= -0.5 Then
            AxWindowsMediaPlayer3.URL = Application.StartupPath + "\sonidos\ataque2.mp3"
            automatico2 = True
            For x = 0 To 4
                Myvalue = Int(9 * Rnd()) '0-8 
                btn = DirectCast(Controls("btn_" & Myvalue.ToString), Button)
                btn.PerformClick()
            Next
            automatico2 = False
            If dificultad = 0 Then
                contador_tiempo2 = 16
            ElseIf dificultad = 1 Then
                contador_tiempo2 = 9
            ElseIf dificultad = 2 Then
                contador_tiempo2 = 5
            End If
        End If
        lbl_tiempo2.Text = contador_tiempo2.ToString + " s"

        'ataque 3
        contador_tiempo3 = contador_tiempo3 - 0.5
        If contador_tiempo3 <= -0.5 Then
            AxWindowsMediaPlayer4.URL = Application.StartupPath + "\sonidos\ataque3.mp3"
            automatico2 = True
            For x = 0 To 2
                Myvalue = Int(9 * Rnd()) '0-8 
                btn = DirectCast(Controls("btn_" & Myvalue.ToString), Button)
                btn.PerformClick()
            Next
            automatico2 = False
            If dificultad = 0 Then
                contador_tiempo3 = 9
            ElseIf dificultad = 1 Then
                contador_tiempo3 = 4
            ElseIf dificultad = 2 Then
                contador_tiempo3 = 2
            End If

        End If
        lbl_tiempo3.Text = contador_tiempo3.ToString + " s"

        lbl_movimientos.Text = movimientos.ToString
        contador_tiempo_total = contador_tiempo_total + 0.5
        lbl_tiempo_total.Text = contador_tiempo_total
    End Sub

    Private Sub jugar()

        btn_0.Enabled = True
        btn_1.Enabled = True
        btn_2.Enabled = True
        btn_3.Enabled = True
        btn_4.Enabled = True
        btn_5.Enabled = True
        btn_6.Enabled = True
        btn_7.Enabled = True
        btn_8.Enabled = True
        AxWindowsMediaPlayer1.URL = Application.StartupPath + "\sonidos\megalovania.mp3"
        AxWindowsMediaPlayer1.settings.setMode("Loop", True)
        '012
        '345
        '678
        Dim MyValue As Integer
        Dim btn As Button
        Dim actual(1) As Integer
        Dim temporal As Integer

        automatico = True
        For i = 0 To 1000
            Threading.Thread.Sleep(0.4)

            For j = 0 To 8
                btn = DirectCast(Controls("btn_" & j.ToString), Button)
                If btn.BackgroundImage Is Nothing Then
                    actual(0) = j
                End If
            Next

            MyValue = Int(9 * Rnd()) '0-8 0-1
            btn = DirectCast(Controls("btn_" & MyValue.ToString), Button)
            btn.PerformClick()

            For l = 0 To 8

                btn = DirectCast(Controls("btn_" & l.ToString), Button)
                If btn.BackgroundImage Is Nothing Then

                    If l <> actual(0) Then
                        actual(1) = l
                        temporal = grilla(actual(0))
                        grilla(actual(0)) = grilla(actual(1))
                        grilla(actual(1)) = temporal
                    End If
                End If
            Next

        Next
        automatico = False

        'For x = 0 To 8 'actualizar resultados
        '    btn = DirectCast(Controls("btn_" & x.ToString), Button)
        '    btn.Text = grilla(x)
        'Next
    End Sub
    Private Sub NormalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NormalToolStripMenuItem.Click
        dificultad = 0
        jugar()
        contador_tiempo1 = 200
        contador_tiempo2 = 16
        contador_tiempo3 = 9
        Timer1.Start()
        lbl_dificultad.Text = "Normal"
        lbl_dificultad.Font = NormalToolStripMenuItem.Font
        lbl_dificultad.ForeColor = NormalToolStripMenuItem.ForeColor
        lbl_dificultad.Size = NormalToolStripMenuItem.Size

    End Sub

    Private Sub DificilToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DificilToolStripMenuItem.Click
        dificultad = 1
        jugar()
        contador_tiempo1 = 150
        contador_tiempo2 = 9
        contador_tiempo3 = 4
        Timer1.Start()
        lbl_dificultad.Text = "Dificil"
        lbl_dificultad.Font = DificilToolStripMenuItem.Font
        lbl_dificultad.ForeColor = DificilToolStripMenuItem.ForeColor
        lbl_dificultad.Size = DificilToolStripMenuItem.Size

    End Sub
    Private Sub PesadillaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PesadillaToolStripMenuItem.Click
        dificultad = 2
        jugar()
        contador_tiempo1 = 120
        contador_tiempo2 = 5
        contador_tiempo3 = 2
        Timer1.Start()
        lbl_dificultad.Text = "Pesadilla"
        lbl_dificultad.Font = PesadillaToolStripMenuItem.Font
        lbl_dificultad.ForeColor = PesadillaToolStripMenuItem.ForeColor
        lbl_dificultad.Size = PesadillaToolStripMenuItem.Size

    End Sub

    Private Sub ReiniciarToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReiniciarToolStripMenuItem.Click
        Timer1.Stop()
        movimientos = 0
        lbl_movimientos.Text = movimientos.ToString
        contador_tiempo_total = 0
        lbl_tiempo_total.Text = contador_tiempo_total
        lbl_dificultad.Text = ""
        lbl_tiempo1.Text = contador_tiempo1.ToString + " s"
        lbl_tiempo2.Text = contador_tiempo2.ToString + " s"
        lbl_tiempo3.Text = contador_tiempo3.ToString + " s"

        btn_0.BackgroundImage = Nothing
        btn_1.BackgroundImage = ImageList1.Images(1)
        btn_2.BackgroundImage = ImageList1.Images(2)
        btn_3.BackgroundImage = ImageList1.Images(3)
        btn_4.BackgroundImage = ImageList1.Images(4)
        btn_5.BackgroundImage = ImageList1.Images(5)
        btn_6.BackgroundImage = ImageList1.Images(6)
        btn_7.BackgroundImage = ImageList1.Images(7)
        btn_8.BackgroundImage = ImageList1.Images(8)
        AxWindowsMediaPlayer1.Ctlcontrols.stop()
        AxWindowsMediaPlayer2.Ctlcontrols.stop()
        AxWindowsMediaPlayer3.Ctlcontrols.stop()
        AxWindowsMediaPlayer4.Ctlcontrols.stop()
        grilla = {0, 1, 2, 3, 4, 5, 6, 7, 8}
        btn_0.Enabled = False
        btn_1.Enabled = False
        btn_2.Enabled = False
        btn_3.Enabled = False
        btn_4.Enabled = False
        btn_5.Enabled = False
        btn_6.Enabled = False
        btn_7.Enabled = False
        btn_8.Enabled = False
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Close()
    End Sub
End Class