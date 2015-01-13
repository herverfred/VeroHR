Public Class KaoZhong_Form

    Public AAA, BBB As String
    Public PEOName, CardNo, SPEONo, EPEONo, SDep, EDep As String
    Public SDate, EDate As String

    Private Sub KaoZhong_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '所有按钮 Enabled = False
        Cmd.CmdFalse(AForm:=Me)
        '各按钮依权限开启 Enabled = True
        Cmd.CmdTrue(AForm:=Me)

        Exit_Cmd.Enabled = True

        '禁止添加行
        DataGridView1.AllowUserToAddRows = False
        '禁止删除行
        DataGridView1.AllowUserToDeleteRows = False
        '可以调整行大小
        DataGridView1.AllowUserToResizeColumns = True
        '可以调整列大小
        DataGridView1.AllowUserToResizeRows = False

        SDate_Text.Text = "    /  /  "
        EDate_Text.Text = "    /  /  "
        PEOName_Text.Text = ""
        CardNo_Text.Text = ""
        SPEONo_Text.Text = ""
        EPEONo_Text.Text = ""
        SDep_Text.Text = ""
        EDep_Text.Text = ""

        SDate_Text.MaxLength = 10
        EDate_Text.MaxLength = 10
        PEOName_Text.MaxLength = 10
        CardNo_Text.MaxLength = 10
        SPEONo_Text.MaxLength = 10
        EPEONo_Text.MaxLength = 10
        SDep_Text.MaxLength = 10
        EDep_Text.MaxLength = 10

        Serving_Radio.Checked = True

        SZ_Radio.Checked = True
        Company_GB.Enabled = False

        SDate_Text.Focus()

    End Sub

    '获得焦点
    Private Sub SDate_Text_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SDate_Text.GotFocus, EDate_Text.GotFocus
        sender.SelectionStart = 0
        sender.SelectionLength = 0
    End Sub

    '键按下（是否为Delete）
    Private Sub SDate_Text_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles SDate_Text.KeyDown, EDate_Text.KeyDown
        If Trim(e.KeyCode.ToString) = "Delete" Then
            e.Handled = True
            SendKeys.Send(Chr(32))
        End If
    End Sub

    Private Sub SDate_Text_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles SDate_Text.KeyPress, EDate_Text.KeyPress
        TextOverAll(sender, e)
    End Sub

    Private Sub SDate_Text_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SDate_Text.LostFocus
        If sender.Text <> "    /  /  " Then
            EDate_Text.Text = sender.Text
        End If
    End Sub

    '控件完成验证时发生（不做作LostFocus，是因为会掉入廻圈中）
    Private Sub SDate_Text_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles SDate_Text.Validated, EDate_Text.Validated
        If sender.Text <> "    /  /  " AndAlso Not IsDate(sender.Text) Then
            MessageBox.Show("不是时间格式,请重新输入", "错误讯息")
            sender.Focus()
            sender.SelectionStart = 0
            Exit Sub
        End If
        If IsDate(SDate_Text.Text) And IsDate(EDate_Text.Text) And SDate_Text.Text <> "    /  /  " And EDate_Text.Text <> "    /  /  " Then
            If Date.Parse(SDate_Text.Text) > Date.Parse(EDate_Text.Text) Then
                MsgBox("起始日期不可大于截止日期", , "日期错误")
                sender.Focus()
                sender.SelectionStart = 0
                Exit Sub
            End If
        End If
    End Sub

    '控件正在验证时，补0
    Private Sub SDate_Text_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles SDate_Text.Validating, EDate_Text.Validating
        '解决空白的问题，把空白补0
        If sender.Text <> "    /  /  " Then sender.Text = Replace(sender.Text, " ", "0")
    End Sub

    Private Sub PEOName_Text_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PEOName_Text.KeyPress, CardNo_Text.KeyPress, SPEONo_Text.KeyPress, EPEONo_Text.KeyPress, SDep_Text.KeyPress, EDep_Text.KeyPress
        If e.KeyChar = Chr(13) Then SendKeys.Send("{Tab}")
    End Sub

    Private Sub SPEONo_Text_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SPEONo_Text.LostFocus
        If RTrim(sender.text) <> "" Then EPEONo_Text.Text = RTrim(sender.text)
    End Sub

    Private Sub SDep_Text_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SDep_Text.LostFocus
        If RTrim(sender.text) <> "" Then EDep_Text.Text = RTrim(sender.text)
    End Sub

    '-----日期TEXTBOX的判断-----
    Private Sub TextOverAll(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        If e.KeyChar = vbBack Then
            sender.SelectionStart = IIf(sender.SelectionStart = 0, 0, sender.SelectionStart - 1)
            sender.SelectionLength = 1
            If sender.SelectedText = "/" Then
                sender.SelectionStart = IIf(sender.SelectionStart = 0, 0, sender.SelectionStart - 1)
            End If
            e.KeyChar = Chr(32)
            SendKeys.Send("{left}")
        Else

            sender.SelectionLength = 1
            If sender.SelectedText = "/" Then
                sender.SelectionStart = sender.SelectionStart + 1
            End If

        End If

        If e.KeyChar <> vbBack And e.KeyChar <> Chr(13) Then
            sender.SelectionLength = 1
            ' 将 Text1 输入光标位置的字符变成「被选取的字符」
            If sender.SelectedText <> "" And sender.TextLength = 10 Then
                sender.SelectionLength = 1
                'EDate_Text.SelectedText = e.KeyChar
                ' 「被选取的字符」取代成为「输入的字符」
                'e.KeyChar = Chr(0)
                ' 将此一字符吞掉，不再传给 TextBox
            Else
                sender.SelectionLength = 0
            End If
        End If

        If e.KeyChar = Chr(13) Then SendKeys.Send("{Tab}")

        If e.KeyChar <> Chr(13) And e.KeyChar <> Chr(32) And e.KeyChar <> vbBack And Not Char.IsNumber(e.KeyChar) Then
            e.KeyChar = Chr(0)
            sender.SelectionLength = 0
        End If

    End Sub

    '查询员工
    Private Sub Load_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load_Cmd.Click

        DataGridViewSet.ClearDataBase(DataGridView1)

        DataGridView1.Columns.Add("XH_No", "序")
        DataGridView1.Columns.Add("EmployeeCode", "员工工号")
        DataGridView1.Columns.Add("EmployeeCnName", "员工姓名")
        DataGridView1.Columns.Add("CardCardNo", "刷卡卡号")
        DataGridView1.Columns.Add("EmployeeDate", "入司日期")
        DataGridView1.Columns.Add("DepartmentCode", "部门编号")
        DataGridView1.Columns.Add("DepartmentName", "部门名称")
        DataGridView1.Columns.Add("EmployeeStateName", "员工状态")
        DataGridView1.Columns.Add("CorporationShortName", "公司别")
        DataGridView1.Columns.Add("JobName", "职称")

        SDate = IIf(SDate_Text.Text = "    /  /  ", "", SDate_Text.Text)
        EDate = IIf(EDate_Text.Text = "    /  /  ", "", EDate_Text.Text)
        PEOName = RTrim(PEOName_Text.Text)
        CardNo = RTrim(CardNo_Text.Text)
        SPEONo = RTrim(SPEONo_Text.Text)
        EPEONo = RTrim(EPEONo_Text.Text)
        SDep = RTrim(SDep_Text.Text)
        EDep = RTrim(EDep_Text.Text)

        If SDate = "" And EDate = "" And PEOName = "" And CardNo = "" And SPEONo = "" And EPEONo = "" And SDep = "" And EDep = "" Then
            MsgBox("最少要输入一个条件", , "条件")
            SDate_Text.Focus()
            Exit Sub
        End If

        AAA = ""

        '假如找不到这个按钮对应的权限就不执行程式
        If Array.IndexOf(Main_Form.AllCmd, Replace(Me.Name, "_Form", "_Cmd") & sender.Name) >= 0 Then

            Power_Lab.Text = ShareSQL.PowerLab(Array.IndexOf(Main_Form.AllCmd, Replace(Me.Name, "_Form", "_Cmd") & sender.Name))

            '带入 SZ_Radio 跟 SH_Radio 看勾选了哪一个，再带入权限表中定位的 Rows
            AAA = AAA & ShareSQL.CorporationSQL(SZ_Radio.Checked, SH_Radio.Checked, Array.IndexOf(Main_Form.AllCmd, Replace(Me.Name, "_Form", "_Cmd") & sender.Name))

        Else
            MsgBox("权限表里面没有这个按钮", , "权限不够")
            Exit Sub
        End If

        If Serving_Radio.Checked = True Then
            AAA = AAA & " AND (CodeInfoB.ScName = '试用' Or CodeInfoB.ScName = '正式') "
        End If

        If Quit_Radio.Checked = True Then
            AAA = AAA & " AND CodeInfoB.ScName = '离职' "
        End If

        Class_SQL.KaoZhongLoad(AForm:=Me)

        Dim DSTablesName As String = "KaoZhongLoad"

        If Class_SQL.DS1.Tables(DSTablesName).Rows.Count > 0 Then
            For i As Integer = 0 To Class_SQL.DS1.Tables(DSTablesName).Rows.Count - 1
                DataGridView1.Rows.Add()

                DataGridView1.Rows(i).Cells("XH_No").Value = i + 1
                DataGridView1.Rows(i).Cells("EmployeeCode").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("EmployeeCode").ToString)
                DataGridView1.Rows(i).Cells("EmployeeCnName").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("EmployeeCnName").ToString)
                DataGridView1.Rows(i).Cells("CardCardNo").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("CardCardNo").ToString)
                'DataGridView1.Rows(i).Cells("EmployeeDate").Value = Date.Parse(Class_SQL.DS1.Tables("DSTablesName").Rows(i).Item("EmployeeDate").ToString).ToString("yyyy/MM/dd")
                DataGridView1.Rows(i).Cells("EmployeeDate").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("EmployeeDate")).ToString("yyyy/MM/dd")
                DataGridView1.Rows(i).Cells("DepartmentCode").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("DepartmentCode").ToString)
                DataGridView1.Rows(i).Cells("DepartmentName").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("DepartmentName").ToString)
                DataGridView1.Rows(i).Cells("EmployeeStateName").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("EmployeeStateName").ToString)
                DataGridView1.Rows(i).Cells("CorporationShortName").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("CorporationShortName").ToString)
                DataGridView1.Rows(i).Cells("JobName").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("JobName").ToString)
            Next

            DataGridViewSet.AutoMode(Me.DataGridView1)

        Else
            MsgBox("查无资料", , "查无资料")
        End If

    End Sub

    '-----汇出到EXECL-----
    Private Sub OutExecl_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutExecl_Cmd.Click
        If Me.DataGridView1.RowCount > 0 Then

            Dim OutDataGridView As New DataGridView
            '禁止添加行
            OutDataGridView.AllowUserToAddRows = False
            '禁止删除行
            OutDataGridView.AllowUserToDeleteRows = False
            '可以调整行大小
            OutDataGridView.AllowUserToResizeColumns = True
            '可以调整列大小
            OutDataGridView.AllowUserToResizeRows = False

            OutDataGridView.Columns.Add("XH_No", "序")
            OutDataGridView.Columns.Add("EmployeeCnName", "员工姓名")
            OutDataGridView.Columns.Add("CardCardNo", "刷卡卡号")

            For i As Integer = 0 To Me.DataGridView1.RowCount - 1
                OutDataGridView.Rows.Add()
                OutDataGridView.Rows(i).Cells("XH_No").Value = ""
                OutDataGridView.Rows(i).Cells("EmployeeCnName").Value = DataGridView1.Rows(i).Cells("EmployeeCnName").Value
                OutDataGridView.Rows(i).Cells("CardCardNo").Value = DataGridView1.Rows(i).Cells("CardCardNo").Value
            Next

            '-----（DataGridView1, 是否删除栏位名称）-----
            Dim UserFileTemp As String = ""
            OutExecl.OutExecl(OutDataGridView, UserFileTemp, False)

            GC.Collect()

            If UserFileTemp <> "" Then
                System.Diagnostics.Process.Start(UserFileTemp)
            End If
        Else
            MsgBox("无资料可汇出", , "无资料")
        End If

    End Sub

    Private Sub Exit_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_Cmd.Click
        Me.Close()
    End Sub


End Class