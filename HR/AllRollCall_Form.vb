Imports System.ComponentModel

Public Class AllRollCall_Form

    Public AAA, BBB As String
    Public PEOName, SPEONo, EPEONo, SDep, EDep As String
    Public SDate, SDD, EDate, SEDD As String

    '**************************************************
    Public ds11t As DataGridView
    '**************************************************

    Private Sub AllRollCall_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

        SZ_Radio.Checked = True
        Company_GB.Enabled = False

        'DateTimePicker1.Text = Date.Now.Add(TimeSpan.FromDays(-1))

    End Sub

    Private Sub Load_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load_Cmd.Click

        DataGridViewSet.ClearDataBase(DataGridView1)

        DataGridView1.Columns.Add("XH_No", "序")
        DataGridView1.Columns.Add("员工工号", "员工工号")
        DataGridView1.Columns.Add("员工姓名", "员工姓名")
        'DataGridView1.Columns.Add("职称", "职称")
        DataGridView1.Columns.Add("部门名称", "部门名称")
        DataGridView1.Columns.Add("日期", "日期")
        'DataGridView1.Columns.Add("星期", "星期")
        DataGridView1.Columns.Add("节假日", "节假日")
        'DataGridView1.Columns.Add("班次", "班次")
        DataGridView1.Columns.Add("假勤名称", "假勤名称")
        'DataGridView1.Columns.Add("班次开始时间", "班次开始时间")
        'DataGridView1.Columns.Add("班次结束时间", "班次结束时间")
        'DataGridView1.Columns.Add("实际上班刷卡时间", "实际上班刷卡时间")
        'DataGridView1.Columns.Add("实际下班刷卡时间", "实际下班刷卡时间")
        DataGridView1.Columns.Add("封存", "封存")
        'DataGridView1.Columns.Add("班次班段", "班次班段")
        DataGridView1.Columns.Add("班次班段名称", "班次班段名称")
        DataGridView1.Columns.Add("班段假勤名称", "班段假勤名称")
        DataGridView1.Columns.Add("核算量", "核算量")
        'DataGridView1.Columns.Add("实际在岗", "实际在岗")
        DataGridView1.Columns.Add("单位", "单位")
        'DataGridView1.Columns.Add("当天有效刷卡", "当天有效刷卡")
        DataGridView1.Columns.Add("当天所有刷卡", "当天所有刷卡")
        DataGridView1.Columns.Add("第1次", "第1次")
        DataGridView1.Columns.Add("第2次", "第2次")
        DataGridView1.Columns.Add("第3次", "第3次")
        DataGridView1.Columns.Add("第4次", "第4次")
        DataGridView1.Columns.Add("第5次", "第5次")
        DataGridView1.Columns.Add("第6次", "第6次")
        'DataGridView1.Columns.Add("第7次", "第7次")
        'DataGridView1.Columns.Add("第8次", "第8次")
        'DataGridView1.Columns.Add("第9次", "第9次")
        'DataGridView1.Columns.Add("第10次", "第10次")
        'DataGridView1.Columns.Add("第11次", "第11次")
        'DataGridView1.Columns.Add("第12次", "第12次")
        'DataGridView1.Columns.Add("公司别", "公司别")
        'DataGridView1.Columns.Add("津贴", "津贴")
        DataGridView1.Columns.Add("实到工时", "实到工时")
        DataGridView1.Columns.Add("平日加班", "平日加班")
        DataGridView1.Columns.Add("公休加班", "公休加班")
        DataGridView1.Columns.Add("国假加班", "国假加班")
        DataGridView1.Columns.Add("工作时数", "工作时数")
        DataGridView1.Columns.Add("请假", "请假")
        DataGridView1.Columns.Add("时间", "时间")
        DataGridView1.Columns.Add("迟到", "迟到")

        SEDD = "yes"
        SDate = DateTimePicker1.Text
        EDate = DateTimePicker2.Text

        Class_SQL.RollCallReport(AForm:=Me)

        Dim DSTablesName As String = "RollCallReport"
        Dim IPTemp() As String
        Dim Allowance As Integer = 0  '用于存放每日合计餐费

        If Class_SQL.DS1.Tables(DSTablesName).Rows.Count <= 0 Then
            MsgBox("查无资料", , "查无资料")
            Exit Sub
        End If

        For i As Integer = 0 To Class_SQL.DS1.Tables(DSTablesName).Rows.Count - 1
            DataGridView1.Rows.Add()

            DataGridView1.Rows(i).Cells("XH_No").Value = i + 1
            DataGridView1.Rows(i).Cells("员工工号").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("员工工号").ToString)
            DataGridView1.Rows(i).Cells("员工姓名").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("员工姓名").ToString)
            'DataGridView1.Rows(i).Cells("职称").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("职称").ToString)
            DataGridView1.Rows(i).Cells("部门名称").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("部门名称").ToString)
            DataGridView1.Rows(i).Cells("日期").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("日期")).ToString("yyyy/MM/dd")
            DataGridView1.Rows(i).Cells("节假日").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("节假日").ToString)
            'DataGridView1.Rows(i).Cells("星期").Value = Weekday(Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("日期")).ToString("yyyy/MM/dd"), vbMonday)
            'Select Case Weekday(Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("日期")).ToString("yyyy/MM/dd"), vbMonday)
            '    Case 1
            '        DataGridView1.Rows(i).Cells("星期").Value = "一"
            '    Case 2
            '        DataGridView1.Rows(i).Cells("星期").Value = "二"
            '    Case 3
            '        DataGridView1.Rows(i).Cells("星期").Value = "三"
            '    Case 4
            '        DataGridView1.Rows(i).Cells("星期").Value = "四"
            '    Case 5
            '        DataGridView1.Rows(i).Cells("星期").Value = "五"
            '    Case 6
            '        DataGridView1.Rows(i).Cells("星期").Value = "六"
            '    Case 7
            '        DataGridView1.Rows(i).Cells("星期").Value = "日"
            'End Select


            'DataGridView1.Rows(i).Cells("班次").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次").ToString)
            DataGridView1.Rows(i).Cells("假勤名称").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("假勤名称").ToString)
            'DataGridView1.Rows(i).Cells("班次开始时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次开始时间").ToString).ToString("yyyy/MM/dd HH:mm")
            'If IsDBNull(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次开始时间")) Then DataGridView1.Rows(i).Cells("班次开始时间").Value = "" Else DataGridView1.Rows(i).Cells("班次开始时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次开始时间")).ToString("yyyy/MM/dd HH:mm")
            'DataGridView1.Rows(i).Cells("班次结束时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次结束时间").ToString).ToString("yyyy/MM/dd HH:mm")
            'If IsDBNull(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次结束时间")) Then DataGridView1.Rows(i).Cells("班次结束时间").Value = "" Else DataGridView1.Rows(i).Cells("班次结束时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次结束时间")).ToString("yyyy/MM/dd HH:mm")
            'DataGridView1.Rows(i).Cells("实际上班刷卡时间").Value = IIf(IsDBNull(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际上班刷卡时间")), "", Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际上班刷卡时间").ToString).ToString("yyyy/MM/dd HH:mm"))
            'If IsDBNull(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际上班刷卡时间")) Then DataGridView1.Rows(i).Cells("实际上班刷卡时间").Value = "" Else DataGridView1.Rows(i).Cells("实际上班刷卡时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际上班刷卡时间")).ToString("yyyy/MM/dd HH:mm")
            'DataGridView1.Rows(i).Cells("实际下班刷卡时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际下班刷卡时间")).ToString("yyyy/MM/dd HH:mm")
            'If IsDBNull(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际下班刷卡时间")) Then DataGridView1.Rows(i).Cells("实际下班刷卡时间").Value = "" Else DataGridView1.Rows(i).Cells("实际下班刷卡时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际下班刷卡时间")).ToString("yyyy/MM/dd HH:mm")
            'DataGridView1.Rows(i).Cells("当天有效刷卡").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("当天有效刷卡").ToString)
            DataGridView1.Rows(i).Cells("当天所有刷卡").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("当天所有刷卡").ToString)

            DataGridView1.Rows(i).Cells("封存").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("封存").ToString)

            'DataGridView1.Rows(i).Cells("班次班段").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次班段").ToString)
            DataGridView1.Rows(i).Cells("班次班段名称").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班次班段名称").ToString)
            DataGridView1.Rows(i).Cells("班段假勤名称").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("班段假勤名称").ToString)
            DataGridView1.Rows(i).Cells("核算量").Value = Val(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("核算量").ToString)
            'DataGridView1.Rows(i).Cells("实际在岗").Value = Val(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("实际在岗").ToString)
            DataGridView1.Rows(i).Cells("单位").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("单位").ToString)

            'Allowance = 0
            'If Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("中餐").ToString <> "" Then Allowance = 6
            'If Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("晚餐").ToString <> "" Then Allowance += 6
            'If Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("夜餐").ToString <> "" Then Allowance = 12
            'DataGridView1.Rows(i).Cells("津贴").Value = RTrim(Allowance)

            DataGridView1.Rows(i).Cells("实到工时").Value = 0
            DataGridView1.Rows(i).Cells("平日加班").Value = 0
            DataGridView1.Rows(i).Cells("公休加班").Value = 0
            DataGridView1.Rows(i).Cells("国假加班").Value = 0
            DataGridView1.Rows(i).Cells("工作时数").Value = 0
            DataGridView1.Rows(i).Cells("请假").Value = ""
            DataGridView1.Rows(i).Cells("时间").Value = 0
            DataGridView1.Rows(i).Cells("迟到").Value = 0

            '将 当天所有刷卡 拆开
            IPTemp = RTrim(DataGridView1.Rows(i).Cells("当天所有刷卡").Value).Split("|")
            For J As Integer = 0 To UBound(IPTemp)
                If J = 6 Then Exit For
                If RTrim(IPTemp(J)) <> "" Then
                    DataGridView1.Rows(i).Cells("第" & J + 1 & "次").Value = RTrim(IPTemp(J))
                End If
            Next

            'If UBound(IPTemp) Mod 2 = 0 Then
            '    DataGridView1.Rows(i).DefaultCellStyle.BackColor = Color.YellowGreen
            'End If

            'DataGridView1.Rows(i).Cells("公司别").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("公司别").ToString)
        Next

        Dim X As Integer = 0

        DataGridView1.Columns("实到工时").DefaultCellStyle.Format = "#,##0.00;-#,##0.00;0"
        DataGridView1.Columns("平日加班").DefaultCellStyle.Format = "#,##0.00;-#,##0.00;0"
        DataGridView1.Columns("公休加班").DefaultCellStyle.Format = "#,##0.00;-#,##0.00;0"
        DataGridView1.Columns("国假加班").DefaultCellStyle.Format = "#,##0.00;-#,##0.00;0"
        DataGridView1.Columns("工作时数").DefaultCellStyle.Format = "#,##0.00;-#,##0.00;0"
        DataGridView1.Columns("时间").DefaultCellStyle.Format = "#,##0.00;-#,##0.00;0"
        DataGridView1.Columns("迟到").DefaultCellStyle.Format = "#,##0;-#,##0;0"

        DataGridView1.Columns("实到工时").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns("平日加班").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns("公休加班").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns("国假加班").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns("工作时数").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns("时间").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DataGridView1.Columns("迟到").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight

        X = 0
        Dim IntTemp As Integer = 0   '用在X要-1或-0，判断或累加时是该列或上一列
        Dim TodayTemp As Integer = 0  '用在累加时是加在同一列，或上一列（同员工编号、每个日期的第一笔资料就加在同一列）
        Dim TempA As Integer = 0      '用在判断”班次班段名称“，再决定执行那一段程式

        Do
            '封存是空白代表是异常数据（包含旷工、请假），相关资料明细里面都有
            If DataGridView1.Rows(X).Cells("封存").Value = "False" Then

                If X = 0 Then IntTemp = 0 Else IntTemp = 1

                ''跟上一列的员工编号不一样就跳过
                'If DataGridView1.Rows(X).Cells("员工工号").Value = DataGridView1.Rows(X - IntTemp).Cells("员工工号").Value Then
                '    '同一员工编号、同一天，不同天就跳过
                '    If DataGridView1.Rows(X).Cells("日期").Value = DataGridView1.Rows(X - IntTemp).Cells("日期").Value Then

                '判断跟上一列是不是同一天；同一天的话，数据加在上一列；不同天，加在同一列
                If DataGridView1.Rows(X).Cells("日期").Value = DataGridView1.Rows(X - IntTemp).Cells("日期").Value And _
                    DataGridView1.Rows(X).Cells("员工工号").Value = DataGridView1.Rows(X - IntTemp).Cells("员工工号").Value Then

                    If X <> 0 Then
                        TodayTemp = 1
                    Else
                        TodayTemp = 0
                    End If
                Else
                    TodayTemp = 0
                End If


                '班次班段名称 要是包含 "就餐" 就剔除
                If InStr(DataGridView1.Rows(X).Cells("班次班段名称").Value, "就餐") <= 0 Then

                    TempA = 0

                    '正常状态，同一天各班段，班段假勤名称里面含有”正常“
                    If InStr(DataGridView1.Rows(X).Cells("班段假勤名称").Value, "正常") > 0 Then
                        TempA = 1
                    End If
                    '各种加班，班段假勤名称里面含有”加班“
                    If InStr(DataGridView1.Rows(X).Cells("班段假勤名称").Value, "加班") > 0 Then
                        TempA = 2
                    End If
                    '各种假别，班段假勤名称里面含有”假“ 且 不含有 ”加班“
                    If InStr(DataGridView1.Rows(X).Cells("班段假勤名称").Value, "假") > 0 And InStr(DataGridView1.Rows(X).Cells("班段假勤名称").Value, "加班") <= 0 Then
                        TempA = 3
                    End If
                    '各种迟到，班段假勤名称里面含有”迟到“
                    If InStr(DataGridView1.Rows(X).Cells("班段假勤名称").Value, "迟到") > 0 Then
                        TempA = 4
                    End If
                    '各种早退，班段假勤名称里面含有”早退“
                    If InStr(DataGridView1.Rows(X).Cells("班段假勤名称").Value, "早退") > 0 Then
                        TempA = 5
                    End If
                    '各种旷工，班段假勤名称里面含有”旷工“
                    If InStr(DataGridView1.Rows(X).Cells("班段假勤名称").Value, "旷工") > 0 And DataGridView1.Rows(X).Cells("节假日").Value = "工作日" Then
                        TempA = 6
                    End If

                    '各种未刷卡，班段假勤名称里面含有”未刷卡“
                    If InStr(DataGridView1.Rows(X).Cells("班段假勤名称").Value, "未刷卡") > 0 Then
                        TempA = 7
                    End If
                    '各种假别，班段假勤名称里面含有”年休“ 且 不含有 ”加班“
                    If InStr(DataGridView1.Rows(X).Cells("班段假勤名称").Value, "年休") > 0 And InStr(DataGridView1.Rows(X).Cells("班段假勤名称").Value, "加班") <= 0 Then
                        TempA = 8
                    End If



                    Select Case TempA
                        '同员工编号、每个日期的第一笔资料，要加到实到工时、平日加班、公休加班、国假加班、工作时数、请假、时间
                        '正常状态，同一天各班段，班段假勤名称里面含有”正常“
                        Case 1
                            Select Case DataGridView1.Rows(X).Cells("单位").Value
                                Case "分钟"
                                    DataGridView1.Rows(X - TodayTemp).Cells("实到工时").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("实到工时").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value) / 60
                                    DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value) / 60
                                Case "小时"
                                    DataGridView1.Rows(X - TodayTemp).Cells("实到工时").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("实到工时").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value)
                                    DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value)
                            End Select

                            '跟上一列同一天
                            If DataGridView1.Rows(X).Cells("日期").Value = DataGridView1.Rows(X - IntTemp).Cells("日期").Value Then
                                DataGridView1.Rows.RemoveAt(X)
                                X -= 1
                            End If

                        Case 2
                            '各种加班，班段假勤名称里面含有”加班“
                            Select Case DataGridView1.Rows(X).Cells("班段假勤名称").Value
                                Case "平日加班"
                                    Select Case DataGridView1.Rows(X).Cells("单位").Value
                                        Case "分钟"
                                            DataGridView1.Rows(X - TodayTemp).Cells("平日加班").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("平日加班").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value) / 60
                                            DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value) / 60
                                        Case "小时"
                                            DataGridView1.Rows(X - TodayTemp).Cells("平日加班").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("平日加班").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value)
                                            DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value)
                                    End Select
                                Case "假日加班"
                                    Select Case DataGridView1.Rows(X).Cells("单位").Value
                                        Case "分钟"
                                            DataGridView1.Rows(X - TodayTemp).Cells("公休加班").Value += Val(DataGridView1.Rows(X).Cells("核算量").Value) / 60
                                            DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value += Val(DataGridView1.Rows(X).Cells("核算量").Value) / 60
                                        Case "小时"
                                            DataGridView1.Rows(X - TodayTemp).Cells("公休加班").Value += Val(DataGridView1.Rows(X).Cells("核算量").Value)
                                            DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value += Val(DataGridView1.Rows(X).Cells("核算量").Value)
                                    End Select
                                Case "节日加班"
                                    Select Case DataGridView1.Rows(X).Cells("单位").Value
                                        Case "分钟"
                                            DataGridView1.Rows(X - TodayTemp).Cells("国假加班").Value += Val(DataGridView1.Rows(X).Cells("核算量").Value) / 60
                                            DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value += Val(DataGridView1.Rows(X).Cells("核算量").Value) / 60
                                        Case "小时"
                                            DataGridView1.Rows(X - TodayTemp).Cells("国假加班").Value += Val(DataGridView1.Rows(X).Cells("核算量").Value)
                                            DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value += Val(DataGridView1.Rows(X).Cells("核算量").Value)
                                    End Select
                            End Select
                            '跟上一列同一天
                            If DataGridView1.Rows(X).Cells("日期").Value = DataGridView1.Rows(X - IntTemp).Cells("日期").Value Then
                                DataGridView1.Rows.RemoveAt(X)
                                X -= 1
                            End If

                        Case 3
                            '各种假别，班段假勤名称里面含有”假“ 且 不含有 ”加班“
                            DataGridView1.Rows(X - TodayTemp).Cells("请假").Value = DataGridView1.Rows(X).Cells("班段假勤名称").Value
                            Select Case DataGridView1.Rows(X).Cells("单位").Value
                                Case "分钟"
                                    DataGridView1.Rows(X - TodayTemp).Cells("时间").Value += Val(DataGridView1.Rows(X).Cells("核算量").Value) / 60
                                Case "小时"
                                    DataGridView1.Rows(X - TodayTemp).Cells("时间").Value += Val(DataGridView1.Rows(X).Cells("核算量").Value)
                            End Select
                            '跟上一列同一天
                            If DataGridView1.Rows(X).Cells("日期").Value = DataGridView1.Rows(X - IntTemp).Cells("日期").Value Then
                                DataGridView1.Rows.RemoveAt(X)
                                X -= 1
                            End If

                        Case 4
                            '各种迟到，班段假勤名称里面含有”迟到“
                            DataGridView1.Rows(X - TodayTemp).Cells("请假").Value = DataGridView1.Rows(X).Cells("班段假勤名称").Value
                            Select Case DataGridView1.Rows(X).Cells("单位").Value
                                Case "分钟"
                                    DataGridView1.Rows(X - TodayTemp).Cells("迟到").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("迟到").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value)
                                    DataGridView1.Rows(X - TodayTemp).Cells("实到工时").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("实到工时").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value) / 60
                                    DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value) / 60
                                Case "小时"
                                    DataGridView1.Rows(X - TodayTemp).Cells("迟到").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("迟到").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value) * 60
                                    DataGridView1.Rows(X - TodayTemp).Cells("实到工时").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("实到工时").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value)
                                    DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value)
                            End Select

                            '跟上一列同一天
                            If DataGridView1.Rows(X).Cells("日期").Value = DataGridView1.Rows(X - IntTemp).Cells("日期").Value Then
                                DataGridView1.Rows.RemoveAt(X)
                                X -= 1
                            End If

                        Case 5
                            '各种早退，班段假勤名称里面含有”早退“
                            DataGridView1.Rows(X - TodayTemp).Cells("请假").Value = DataGridView1.Rows(X).Cells("班段假勤名称").Value
                            Select Case DataGridView1.Rows(X).Cells("单位").Value
                                Case "分钟"
                                    DataGridView1.Rows(X - TodayTemp).Cells("迟到").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("迟到").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value)
                                    DataGridView1.Rows(X - TodayTemp).Cells("实到工时").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("实到工时").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value) / 60
                                    DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value) / 60
                                Case "小时"
                                    DataGridView1.Rows(X - TodayTemp).Cells("迟到").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("迟到").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value) * 60
                                    DataGridView1.Rows(X - TodayTemp).Cells("实到工时").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("实到工时").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value)
                                    DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value = Val(DataGridView1.Rows(X - TodayTemp).Cells("工作时数").Value) + Val(DataGridView1.Rows(X).Cells("核算量").Value)
                            End Select

                            '跟上一列同一天
                            If DataGridView1.Rows(X).Cells("日期").Value = DataGridView1.Rows(X - IntTemp).Cells("日期").Value Then
                                DataGridView1.Rows.RemoveAt(X)
                                X -= 1
                            End If

                        Case 6
                            '各种旷工，班段假勤名称里面含有”旷工“
                            DataGridView1.Rows(X - TodayTemp).Cells("请假").Value = DataGridView1.Rows(X).Cells("班段假勤名称").Value
                            Select Case DataGridView1.Rows(X).Cells("单位").Value
                                Case "分钟"
                                    DataGridView1.Rows(X - TodayTemp).Cells("时间").Value += Val(DataGridView1.Rows(X).Cells("核算量").Value) / 60
                                Case "小时"
                                    DataGridView1.Rows(X - TodayTemp).Cells("时间").Value += Val(DataGridView1.Rows(X).Cells("核算量").Value)
                            End Select
                            '跟上一列同一天
                            If DataGridView1.Rows(X).Cells("日期").Value = DataGridView1.Rows(X - IntTemp).Cells("日期").Value Then
                                DataGridView1.Rows.RemoveAt(X)
                                X -= 1
                            End If

                        Case 7
                            '各种未刷卡，班段假勤名称里面含有”未刷卡“
                            DataGridView1.Rows(X - TodayTemp).Cells("请假").Value = DataGridView1.Rows(X).Cells("班段假勤名称").Value

                            '跟上一列同一天
                            If DataGridView1.Rows(X).Cells("日期").Value = DataGridView1.Rows(X - IntTemp).Cells("日期").Value Then
                                DataGridView1.Rows.RemoveAt(X)
                                X -= 1
                            End If

                        Case 8
                            '班段假勤名称里面含有”年休“ 且 不含有 ”加班“
                            DataGridView1.Rows(X - TodayTemp).Cells("请假").Value = DataGridView1.Rows(X).Cells("班段假勤名称").Value

                            DataGridView1.Rows(X - TodayTemp).Cells("时间").Value += Val(DataGridView1.Rows(X).Cells("核算量").Value) / 480

                            '跟上一列同一天
                            If DataGridView1.Rows(X).Cells("日期").Value = DataGridView1.Rows(X - IntTemp).Cells("日期").Value Then
                                DataGridView1.Rows.RemoveAt(X)
                                X -= 1
                            End If



                    End Select

                Else
                    '剔除就餐段
                    DataGridView1.Rows.RemoveAt(X)
                    X -= 1
                End If

                'End If
                'DataGridView1.Rows.RemoveAt(X)
                'X -= 1
                'End If

            Else
                '封存是空白（HR里面代表点名异常的资料）
                DataGridView1.Rows.RemoveAt(X)
                X -= 1
            End If

            X += 1
        Loop Until X > DataGridView1.RowCount - 1

        X = 0

        ''取得当月最后一天
        'Dim MonTemp As Integer = Mid(DateAdd("d", -1, DateAdd("m", 1, SDate & "/01")).ToString("yyyy/MM/dd"), 9, 2)
        ''用在1~当月最后一天的廻圈
        'Dim XTemp As Integer = 1

        'DataGridView1.Rows.RemoveAt(DataGridView1.RowCount - 1)
        'DataGridView1.Rows.RemoveAt(DataGridView1.RowCount-1)

        '填补空的日期（离职或没排版 ）
        'Do
        '    If Val(Mid(DataGridView1.Rows(X).Cells("日期").Value, 9, 2)) <> XTemp Then
        '        '补日期
        '        If DataGridView1.Rows(X).Cells("员工工号").Value <> "" Then
        '            DataGridView1.Rows.InsertCopy(X, X)
        '        End If


        '        DataGridView1.Rows(X).Cells("员工工号").Value = DataGridView1.Rows(IIf(XTemp = 1, X + 1, X - 1)).Cells("员工工号").Value
        '        DataGridView1.Rows(X).Cells("员工姓名").Value = RTrim(DataGridView1.Rows(IIf(XTemp = 1, X + 1, X - 1)).Cells("员工姓名").Value)
        '        DataGridView1.Rows(X).Cells("职称").Value = RTrim(DataGridView1.Rows(IIf(XTemp = 1, X + 1, X - 1)).Cells("职称").Value)
        '        DataGridView1.Rows(X).Cells("部门名称").Value = RTrim(DataGridView1.Rows(IIf(XTemp = 1, X + 1, X - 1)).Cells("部门名称").Value)
        '        DataGridView1.Rows(X).Cells("日期").Value = Date.Parse(SDate & "/" & XTemp).ToString("yyyy/MM/dd")
        '        'DataGridView1.Rows(X).Cells("节假日").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("节假日").ToString)
        '        'DataGridView1.Rows(X).Cells("星期").Value = Weekday(Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("日期")).ToString("yyyy/MM/dd"), vbMonday)
        '        Select Case Weekday(Date.Parse(Date.Parse(SDate & "/" & XTemp).ToString("yyyy/MM/dd")), vbMonday)
        '            Case 1
        '                DataGridView1.Rows(X).Cells("星期").Value = "一"
        '            Case 2
        '                DataGridView1.Rows(X).Cells("星期").Value = "二"
        '            Case 3
        '                DataGridView1.Rows(X).Cells("星期").Value = "三"
        '            Case 4
        '                DataGridView1.Rows(X).Cells("星期").Value = "四"
        '            Case 5
        '                DataGridView1.Rows(X).Cells("星期").Value = "五"
        '            Case 6
        '                DataGridView1.Rows(X).Cells("星期").Value = "六"
        '            Case 7
        '                DataGridView1.Rows(X).Cells("星期").Value = "日"
        '        End Select

        '        DataGridView1.Rows(X).Cells("班次").Value = "未排版、未打卡"
        '        DataGridView1.Rows(X).Cells("假勤名称").Value = "未排版、未打卡"
        '        'If IsDBNull(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("班次开始时间")) Then DataGridView1.Rows(X).Cells("班次开始时间").Value = "" Else DataGridView1.Rows(X).Cells("班次开始时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("班次开始时间")).ToString("yyyy/MM/dd HH:mm")
        '        'If IsDBNull(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("班次结束时间")) Then DataGridView1.Rows(X).Cells("班次结束时间").Value = "" Else DataGridView1.Rows(X).Cells("班次结束时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("班次结束时间")).ToString("yyyy/MM/dd HH:mm")
        '        'If IsDBNull(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("实际上班刷卡时间")) Then DataGridView1.Rows(X).Cells("实际上班刷卡时间").Value = "" Else DataGridView1.Rows(X).Cells("实际上班刷卡时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("实际上班刷卡时间")).ToString("yyyy/MM/dd HH:mm")
        '        'If IsDBNull(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("实际下班刷卡时间")) Then DataGridView1.Rows(X).Cells("实际下班刷卡时间").Value = "" Else DataGridView1.Rows(X).Cells("实际下班刷卡时间").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("实际下班刷卡时间")).ToString("yyyy/MM/dd HH:mm")
        '        'DataGridView1.Rows(X).Cells("当天有效刷卡").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("当天有效刷卡").ToString)
        '        'DataGridView1.Rows(X).Cells("当天所有刷卡").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("当天所有刷卡").ToString)

        '        'DataGridView1.Rows(X).Cells("封存").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("封存").ToString)

        '        'DataGridView1.Rows(X).Cells("班次班段").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("班次班段").ToString)
        '        'DataGridView1.Rows(X).Cells("班次班段名称").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("班次班段名称").ToString)
        '        'DataGridView1.Rows(X).Cells("班段假勤名称").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("班段假勤名称").ToString)
        '        'DataGridView1.Rows(X).Cells("核算量").Value = Val(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("核算量").ToString)
        '        'DataGridView1.Rows(X).Cells("实际在岗").Value = Val(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("实际在岗").ToString)
        '        'DataGridView1.Rows(X).Cells("单位").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(X).Item("单位").ToString)

        '        DataGridView1.Rows(X).Cells("津贴").Value = 0
        '        DataGridView1.Rows(X).Cells("实到工时").Value = 0
        '        DataGridView1.Rows(X).Cells("平日加班").Value = 0
        '        DataGridView1.Rows(X).Cells("公休加班").Value = 0
        '        DataGridView1.Rows(X).Cells("国假加班").Value = 0
        '        DataGridView1.Rows(X).Cells("工作时数").Value = 0
        '        DataGridView1.Rows(X).Cells("请假").Value = ""
        '        DataGridView1.Rows(X).Cells("时间").Value = 0

        '        'X += 1
        '    End If

        '    If XTemp = MonTemp Then XTemp = 1 Else XTemp += 1

        '    If XTemp > 1 And XTemp <= MonTemp And X = DataGridView1.RowCount - 1 Then
        '        DataGridView1.Rows.Add()
        '        DataGridView1.Rows(X + 1).Cells("日期").Value = ""
        '    End If

        '    X += 1
        'Loop Until X > DataGridView1.RowCount - 1

        '-----不排序-----
        For i As Integer = 0 To Me.DataGridView1.ColumnCount - 1
            Me.DataGridView1.Columns(i).SortMode = DataGridViewColumnSortMode.NotSortable
        Next

        'Me.DataGridView1.Sort(DataGridView1.Columns("部门名称"), ListSortDirection.Ascending)
        'Me.DataGridView1.Sort(DataGridView1.Columns("日期"), ListSortDirection.Ascending)



        DataGridViewSet.AutoMode(Me.DataGridView1)

        ds11t = Me.DataGridView1

        Count_Lab.Text = "笔数：" & DataGridView1.RowCount

    End Sub

    Private Sub Print_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Print_Cmd.Click
        'AllRollCallPrint.Show()
        'AllRollCallPrint.Focus()

        AllRollCall_print.PageSetup()
        AllRollCall_print.MyDataGridView1 = Me.DataGridView1
        AllRollCall_print.Title = "出勤日报表"
        AllRollCall_print.Company = ""
        AllRollCall_print.rptime = CDate(DateTimePicker1.Text)
        AllRollCall_print.rpendtime = CDate(DateTimePicker2.Text)

        AllRollCall_print.X = 0
        AllRollCall_print.Y = 0
        'RollCallReport_Print.TotalA1 = Mid(DataGridView1.Rows(0).Cells("日期").Value, 9, 2)
        'RollCallReport_Print.TotalA2 = DataGridView1.Rows(0).Cells("日期").Value & "至" & DateAdd("d", -1, DateAdd("m", 1, SDate & "/01")).ToString("yyyy/MM/dd")
        AllRollCall_print.TotalA2 = DataGridView1.Rows(0).Cells("日期").Value

        'PrintView.PrintPreviewFont()
        AllRollCall_print.PrintPreview()

        AllRollCall_print.Dispose()
        GC.Collect()

    End Sub

    Private Sub OutExecl_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutExecl_Cmd.Click

    End Sub

    Private Sub Exit_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_Cmd.Click
        Me.Close()
    End Sub

    '苏州惠亚选项
    Private Sub SZ_Radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SZ_Radio.CheckedChanged

        If sender.Checked = True Then

            AAA = " And Corporation.ShortName = '苏州惠亚' "

            Class_SQL.DepartmentLoad(AForm:=Me)

            Dim DSTablesName As String = "DepartmentLoad"


        End If

    End Sub

    '上海惠亚选项
    Private Sub SH_Radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SH_Radio.CheckedChanged
        If sender.Checked = True Then

            AAA = " And Corporation.ShortName = '上海惠亚' "

            Class_SQL.DepartmentLoad(AForm:=Me)

            Dim DSTablesName As String = "DepartmentLoad"


        End If
    End Sub


End Class