Public Class RenYuanPaiBan_Form

   
    Private Sub Load_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load_Cmd.Click

        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()
        DataGridView2.Rows.Clear()
        DataGridView2.Columns.Clear()
        Label5.Text = ""
        Label6.Text = ""
        Label8.Text = ""
        DataGridView1.Focus()

        Dim dst1, dst2 As DataTable

        dst1 = Class_SQL.PaiBanSearch1(User_No_Text.Text, PEOName_Text.Text).Tables("employee")
        dst2 = Class_SQL.PaiBanSearch2().Tables("rank")

        DataGridView1.RowHeadersVisible = False
        DataGridView1.Columns.Add("Number", "nb")
        DataGridView1.Columns("Number").Visible = False
        DataGridView1.Columns.Add("user_no", "卡号")
        DataGridView1.Columns("user_no").Width = 60
        DataGridView1.Columns.Add("name", "姓名")
        DataGridView1.Columns("name").Width = 55
        DataGridView1.Columns.Add("Expr9", "部门")
        DataGridView1.Columns.Add("Expr26", "st")
        DataGridView1.Columns("Expr26").Visible = False

        '2015/01/09 新增加离职未结清人员--Tim
        DataGridView1.Columns.Add("SalaryOver", "over")
        DataGridView1.Columns("SalaryOver").Visible = False
        '----------------------------------------------------

        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DataGridView1.ReadOnly = True

        Dim line As Integer

        '繞行Dataset若無排班資料則紅色提示
        For index = 0 To dst1.Rows.Count - 1
            line = DataGridView1.Rows.Add()
            DataGridView1.Rows(line).Cells("Number").Value = dst1.Rows(index)("Number").ToString()
            DataGridView1.Rows(line).Cells("user_no").Value = dst1.Rows(index)("Code").ToString()
            DataGridView1.Rows(line).Cells("name").Value = dst1.Rows(index)("CnName").ToString()
            DataGridView1.Rows(line).Cells("Expr9").Value = dst1.Rows(index)("Expr9").ToString()
            DataGridView1.Rows(line).Cells("Expr26").Value = dst1.Rows(index)("Expr26").ToString()

            '2015/01/09 --- Tim
            DataGridView1.Rows(line).Cells("SalaryOver").Value = dst1.Rows(index)("SalaryOver").ToString()
            '-------------------

            For index2 = 0 To dst2.Rows.Count - 1
                If dst2.Rows.Count > 0 Then
                    If dst1.Rows(index)("Number").ToString() = dst2.Rows(index2)("Number").ToString() Then
                        DataGridView1.Rows(line).DefaultCellStyle.BackColor = Color.Yellow

                        '2015/01/09 将未结清人员设定颜色提示
                        If IsDBNull(dst1.Rows(index)("SalaryOver")) Then
                            DataGridView1.Rows(line).DefaultCellStyle.BackColor = Color.White
                        End If
                        '--------------------------------

                        Exit For
                    Else
                        DataGridView1.Rows(line).DefaultCellStyle.BackColor = Color.Red
                    End If

                Else
                    DataGridView1.Rows(line).DefaultCellStyle.BackColor = Color.Red
                End If
            Next
        Next

    End Sub

    Private Sub DataGridView1_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        Class_SQL.doubleclk(DataGridView1, DataGridView2)
        Label5.Text = DataGridView1.SelectedRows(0).Cells("user_no").Value
        Label6.Text = DataGridView1.SelectedRows(0).Cells("name").Value
        Label8.Text = DataGridView1.SelectedRows(0).Cells("Expr9").Value
        Label9.Text = DataGridView1.SelectedRows(0).Cells("Number").Value
        Label10.Text = DataGridView1.SelectedRows(0).Cells("Expr26").Value

        '2015/01/09----Tim--no use
        'Label12.Text = DataGridView1.SelectedRows(0).Cells("SalaryOver").Value
        '--------------------

        If DataGridView1.SelectedRows(0).DefaultCellStyle.BackColor = Color.Red Then
            Label11.Text = "red"
        End If
        DataGridView2.Focus()

    End Sub

    Private Sub SAVE_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVE_Cmd.Click

        SAVE_Cmd.Enabled = False
        Dim paiban As New Dictionary(Of String, String)
        paiban.Add("Number", Label9.Text)
        paiban.Add("Code", Label5.Text)
        paiban.Add("CnName", Label6.Text)
        paiban.Add("jobName", Label8.Text)
        paiban.Add("state", Label10.Text)

        Dim rank As Integer = 0
        For index = 0 To DataGridView2.Rows.Count - 1
            If DataGridView2.Rows(index).Cells("ck").Value = True Then
                rank += 1
            End If
        Next

        '判斷排班數量
        If rank <= 10 And rank <> 0 Then

            '建立排班編號字串
            Dim ranklist As String = ""
            For index = 0 To DataGridView2.Rows.Count - 1
                If DataGridView2.Rows(index).Cells("ck").Value = True Then
                    ranklist += DataGridView2.Rows(index).Cells("Code").Value + "/"
                End If
            Next
            paiban.Add("Rank", ranklist)

            '存入資料庫
            If Label11.Text = "red" Then
                Class_SQL.rankadd(paiban, "insert")
            Else
                Class_SQL.rankadd(paiban, "update")
            End If

            '存入資料庫後紅色轉為白色
            For index = 0 To DataGridView1.Rows.Count - 1
                If DataGridView1.Rows(index).DefaultCellStyle.BackColor = Color.Red Then
                    If DataGridView1.Rows(index).Cells("Number").Value = paiban("Number") Then
                        DataGridView1.Rows(index).DefaultCellStyle.BackColor = Color.White
                    End If
                End If
            Next

        Else
            MessageBox.Show("排班数量需小于6或高于0")
        End If
        SAVE_Cmd.Enabled = True

    End Sub

    Private Sub Exit_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_Cmd.Click
        Me.Close()
    End Sub
End Class