Public Class RollCall_Form

    Public AAA, BBB As String
    Public PEOName, SPEONo, EPEONo, SDep, EDep As String
    Public SDate, EDate As String

    Private Sub RollCall_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect

        SDate_Text.Text = "    /  /  "
        EDate_Text.Text = "    /  /  "
        PEOName_Text.Text = ""
        SPEONo_Text.Text = ""
        EPEONo_Text.Text = ""
        SDep_Text.Text = ""
        EDep_Text.Text = ""

        SDate_Text.MaxLength = 10
        EDate_Text.MaxLength = 10
        PEOName_Text.MaxLength = 10
        SPEONo_Text.MaxLength = 10
        EPEONo_Text.MaxLength = 10
        SDep_Text.MaxLength = 10
        EDep_Text.MaxLength = 10

        SZ_Radio.Checked = True
        Company_GB.Enabled = False

        SDate_Text.Focus()


    End Sub

    '部门List 双击
    Private Sub Dep_List_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dep_List.DoubleClick

        SDep_Text.Text = Mid(sender.SelectedItem, 1, 6)
        EDep_Text.Text = Mid(sender.SelectedItem, 1, 6)

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

    Private Sub PEOName_Text_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles PEOName_Text.KeyPress, SPEONo_Text.KeyPress, EPEONo_Text.KeyPress, SDep_Text.KeyPress, EDep_Text.KeyPress, Serving_CB.KeyPress, Dep_List.KeyPress
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

    '查询
    Private Sub Load_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load_Cmd.Click

        DataGridViewSet.ClearDataBase(DataGridView1)

        DataGridView1.Columns.Add("XH_No", "序")
        DataGridView1.Columns.Add("员工工号", "员工工号")
        DataGridView1.Columns.Add("员工姓名", "员工姓名")
        DataGridView1.Columns.Add("职称", "职称")
        DataGridView1.Columns.Add("部门名称", "部门名称")
        DataGridView1.Columns.Add("日期", "日期")
        DataGridView1.Columns.Add("星期", "星期")
        DataGridView1.Columns.Add("班次名称", "班次名称")
        DataGridView1.Columns.Add("假勤名称", "假勤名称")
        DataGridView1.Columns.Add("班次开始时间", "班次开始时间")
        DataGridView1.Columns.Add("班次结束时间", "班次结束时间")
        DataGridView1.Columns.Add("实际上班刷卡时间", "实际上班刷卡时间")
        DataGridView1.Columns.Add("实际下班刷卡时间", "实际下班刷卡时间")
        DataGridView1.Columns.Add("当天有效刷卡", "当天有效刷卡")
        DataGridView1.Columns.Add("当天所有刷卡", "当天所有刷卡")
        DataGridView1.Columns.Add("第1次", "第1次")
        DataGridView1.Columns.Add("第2次", "第2次")
        DataGridView1.Columns.Add("第3次", "第3次")
        DataGridView1.Columns.Add("第4次", "第4次")
        DataGridView1.Columns.Add("第5次", "第5次")
        DataGridView1.Columns.Add("第6次", "第6次")
        DataGridView1.Columns.Add("第7次", "第7次")
        DataGridView1.Columns.Add("第8次", "第8次")
        DataGridView1.Columns.Add("第9次", "第9次")
        DataGridView1.Columns.Add("第10次", "第10次")
        DataGridView1.Columns.Add("第11次", "第11次")
        DataGridView1.Columns.Add("第12次", "第12次")
        DataGridView1.Columns.Add("公司别", "公司别")

        SDate = IIf(SDate_Text.Text = "    /  /  ", "", SDate_Text.Text)
        EDate = IIf(EDate_Text.Text = "    /  /  ", "", EDate_Text.Text)
        PEOName = RTrim(PEOName_Text.Text)
        SPEONo = RTrim(SPEONo_Text.Text)
        EPEONo = RTrim(EPEONo_Text.Text)
        SDep = RTrim(SDep_Text.Text)
        EDep = RTrim(EDep_Text.Text)

        If SDate = "" And EDate = "" And PEOName = "" And SPEONo = "" And EPEONo = "" And SDep = "" And EDep = "" Then
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

        '含离职员工
        If Serving_CB.Checked = True Then

        Else
            AAA = AAA & " And (CodeInfoB.ScName = '试用' Or CodeInfoB.ScName = '正式') "
            '第一个CodeInfo 是为了员工属性，内招、蓝英、希望、润友
            '第二个CodeInfo 是为了员工状态，试用、正式、离职
        End If

        Class_SQL.RollCallLoad(AForm:=Me)

        Dim DSTablesName As String = "RollCallLoad"
        Dim IPTemp() As String

        If Class_SQL.DS1.Tables(DSTablesName).Rows.Count > 0 Then
            For i As Integer = 0 To Class_SQL.DS1.Tables(DSTablesName).Rows.Count - 1
                DataGridView1.Rows.Add()

                DataGridView1.Rows(i).Cells("XH_No").Value = i + 1
                DataGridView1.Rows(i).Cells("员工工号").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("员工工号").ToString)
                DataGridView1.Rows(i).Cells("员工姓名").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("员工姓名").ToString)
                DataGridView1.Rows(i).Cells("职称").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("职称").ToString)
                DataGridView1.Rows(i).Cells("部门名称").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("部门名称").ToString)
                DataGridView1.Rows(i).Cells("日期").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("日期")).ToString("yyyy/MM/dd")
                'DataGridView1.Rows(i).Cells("星期").Value = Weekday(Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("日期")).ToString("yyyy/MM/dd"), vbMonday)
                Select Case Weekday(Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("日期")).ToString("yyyy/MM/dd"), vbMonday)
                    Case 1
                        DataGridView1.Rows(i).Cells("星期").Value = "一"
                    Case 2
                        DataGridView1.Rows(i).Cells("星期").Value = "二"
                    Case 3
                        DataGridView1.Rows(i).Cells("星期").Value = "三"
                    Case 4
                        DataGridView1.Rows(i).Cells("星期").Value = "四"
                    Case 5
                        DataGridView1.Rows(i).Cells("星期").Value = "五"
                    Case 6
                        DataGridView1.Rows(i).Cells("星期").Value = "六"
                    Case 7
                        DataGridView1.Rows(i).Cells("星期").Value = "日"
                End Select

                DataGridView1.Rows(i).Cells("班次名称").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次名称").ToString)
                DataGridView1.Rows(i).Cells("假勤名称").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("假勤名称").ToString)
                'DataGridView1.Rows(i).Cells("班次开始时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次开始时间").ToString).ToString("yyyy/MM/dd HH:mm")
                If IsDBNull(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次开始时间")) Then DataGridView1.Rows(i).Cells("班次开始时间").Value = "" Else DataGridView1.Rows(i).Cells("班次开始时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次开始时间")).ToString("yyyy/MM/dd HH:mm")
                'DataGridView1.Rows(i).Cells("班次结束时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次结束时间").ToString).ToString("yyyy/MM/dd HH:mm")
                If IsDBNull(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次结束时间")) Then DataGridView1.Rows(i).Cells("班次结束时间").Value = "" Else DataGridView1.Rows(i).Cells("班次结束时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次结束时间")).ToString("yyyy/MM/dd HH:mm")
                'DataGridView1.Rows(i).Cells("实际上班刷卡时间").Value = IIf(IsDBNull(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际上班刷卡时间")), "", Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际上班刷卡时间").ToString).ToString("yyyy/MM/dd HH:mm"))
                If IsDBNull(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际上班刷卡时间")) Then DataGridView1.Rows(i).Cells("实际上班刷卡时间").Value = "" Else DataGridView1.Rows(i).Cells("实际上班刷卡时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际上班刷卡时间")).ToString("yyyy/MM/dd HH:mm")
                'DataGridView1.Rows(i).Cells("实际下班刷卡时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际下班刷卡时间")).ToString("yyyy/MM/dd HH:mm")
                If IsDBNull(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际下班刷卡时间")) Then DataGridView1.Rows(i).Cells("实际下班刷卡时间").Value = "" Else DataGridView1.Rows(i).Cells("实际下班刷卡时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际下班刷卡时间")).ToString("yyyy/MM/dd HH:mm")
                DataGridView1.Rows(i).Cells("当天有效刷卡").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("当天有效刷卡").ToString)
                DataGridView1.Rows(i).Cells("当天所有刷卡").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("当天所有刷卡").ToString)

                '将 当天所有刷卡 拆开
                IPTemp = RTrim(DataGridView1.Rows(i).Cells("当天所有刷卡").Value).Split("|")
                For J As Integer = 0 To UBound(IPTemp)
                    If J = 12 Then Exit For
                    If RTrim(IPTemp(J)) <> "" Then
                        DataGridView1.Rows(i).Cells("第" & J + 1 & "次").Value = RTrim(IPTemp(J))
                    End If
                Next

                If UBound(IPTemp) Mod 2 = 0 Then
                    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.YellowGreen
                End If

                DataGridView1.Rows(i).Cells("公司别").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("公司别").ToString)
            Next

            DataGridViewSet.AutoMode(Me.DataGridView1)

            Count_Lab.Text = "笔数：" & DataGridView1.RowCount
        Else
            MsgBox("查无资料", , "查无资料")
        End If



    End Sub

    '-----汇出到EXECL-----
    Private Sub OutExecl_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutExecl_Cmd.Click

        If Me.DataGridView1.RowCount > 0 Then

            '-----（DataGridView1, 是否删除栏位名称）-----
            Dim UserFileTemp As String = ""
            OutExecl.OutExecl(DataGridView1, UserFileTemp, False)

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

    '苏州惠亚选项
    Private Sub SZ_Radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SZ_Radio.CheckedChanged

        If sender.Checked = True Then
            Dep_List.Items.Clear()
            AAA = " And Corporation.ShortName = '苏州惠亚' "

            Class_SQL.DepartmentLoad(AForm:=Me)

            Dim DSTablesName As String = "DepartmentLoad"

            If Class_SQL.DS1.Tables(DSTablesName).Rows.Count > 0 Then
                For i As Integer = 0 To Class_SQL.DS1.Tables(DSTablesName).Rows.Count - 1
                    Dep_List.Items.Add(RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("DepartmentCode").ToString) & "－" & RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("DepartmentName").ToString))
                Next
            End If
        End If

    End Sub

    '上海惠亚选项
    Private Sub SH_Radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SH_Radio.CheckedChanged
        If sender.Checked = True Then
            Dep_List.Items.Clear()
            AAA = " And Corporation.ShortName = '上海惠亚' "

            Class_SQL.DepartmentLoad(AForm:=Me)

            Dim DSTablesName As String = "DepartmentLoad"

            If Class_SQL.DS1.Tables(DSTablesName).Rows.Count > 0 Then
                For i As Integer = 0 To Class_SQL.DS1.Tables(DSTablesName).Rows.Count - 1
                    Dep_List.Items.Add(RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("DepartmentCode").ToString) & "－" & RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("DepartmentName").ToString))
                Next
            End If
        End If
    End Sub


End Class