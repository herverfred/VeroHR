Public Class Waiting_Form

    Private Sub Waiting_Form_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Application.DoEvents()
    End Sub

    Private Sub Waiting_Form_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        Application.DoEvents()
    End Sub

    Private Sub Waiting_Form_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Application.DoEvents()
        StopTest()
    End Sub

    Private Sub Waiting_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.StartPosition = FormStartPosition.CenterParent
        Me.StartPosition = FormStartPosition.CenterScreen
        Main_Form.StopBoolean = False
    End Sub

    Private Sub END_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles END_Cmd.Click
        Application.DoEvents()
        StopTest()
    End Sub

    Private Sub StopTest()
        Main_Form.StopBoolean = True
        Me.Close()
    End Sub


End Class