Public Class ShJuCaiJi_Form

    Private Sub Load_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load_Cmd.Click

        Dim ds As DataSet
        ds = Class_SQL.ShJuCaiJiSearch(User_No_Text.Text, StartTime.Text.Replace("/", ""), EndTime.Text.Replace("/", ""))
        DataGridView1.DataSource = ds.Tables("ShJuCaiJi")

    End Sub

    Private Sub UpLoadFile_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpLoadFile_Cmd.Click

        '開啟檔案上傳視窗選定後會執行上傳函式
        If Me.OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            Class_SQL.UpLoadShKi(Me.OpenFileDialog1.FileName)
        End If

    End Sub

    Private Sub Exit_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_Cmd.Click
        Me.Close()
    End Sub

End Class