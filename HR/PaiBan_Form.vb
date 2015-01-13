Public Class PaiBan_Form

    Private Sub Load_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load_Cmd.Click

        Load_Cmd.Enabled = False
        '功能限制取消結束日期
        EndTime = StartTime

        '抓出排班清單vb
        Dim empyRank As DataTable = Class_SQL.PaiBanSearch2().Tables("rank") 'table is rank
        '抓出排班時間表hr
        Dim rankList As DataTable = Class_SQL.rankList().Tables("rl") 'table is rl
        '依據時間參數抓出刷卡紀律區段vb
        Dim kijiListO As DataTable = Class_SQL.ShJuCaiJiSearch("", StartTime.Text.Replace("/", ""), EndTime.Text.Replace("/", ""), True).Tables("ShJuCaiJi") ' table is ShJuCaiJi
        '過濾kijiListO重複資料
        Dim kijiList As DataTable = Class_SQL.ShJuCaiJiFilt(kijiListO)
        'DataGridView2.DataSource = kijiList
        '依據時間參數抓出行事曆hr
        Dim holiday As DataTable = Class_SQL.holiday(StartTime.Text.Replace("/", "-"), EndTime.Text.Replace("/", "-")).Tables("holiday")

        DataGridView1.Rows.Clear()
        DataGridView1.Columns.Clear()

        DataGridView1.Columns.Add("code", "工号")
        DataGridView1.Columns.Add("name", "姓名")
        DataGridView1.Columns.Add("mon", "月份")
        DataGridView1.Columns.Add("rank", "班次")
        DataGridView1.Columns.Add("holiday", "假日")
        DataGridView1.Columns.Add("sn", "序號")
        DataGridView1.Columns.Add("KiJi", "卡機")
        DataGridView1.Columns.Add("KiJiTime", "刷卡時間")
        DataGridView1.Columns.Add("GioingHao", "卡號")

        '第一層遍歷行事曆
        For index = 0 To holiday.Rows.Count - 1
            '第二層遍歷刷卡紀歷
            For index2 = 0 To kijiList.Rows.Count - 1

                '將刷卡時間轉為時間形態
                Dim dt, dt2, year, mon, day, h, m, s As String
                dt = kijiList.Rows(index2)("KiJiTime")
                year = dt.Substring(0, 4)
                mon = dt.Substring(4, 2)
                day = dt.Substring(6, 2)
                h = dt.Substring(8, 2)
                m = dt.Substring(10, 2)
                s = dt.Substring(12, 2)
                dt = CDate(year + "/" + mon + "/" + day)
                dt2 = CDate(h + ":" + m + ":" + s)

                '判斷行事曆與刷卡時間為同一天
                If holiday.Rows(index)("Date") = dt Then
                    Dim cord As String = kijiList.Rows(index2)("GioingHao")

                    'TEST CODE -- Tim
                    'If cord.Trim() = "0003708010" Then
                    '    Console.Write("Ture")
                    'End If

                    '************False狀態未處理******工號獲取****************
                    Dim goho As String = Class_SQL.findGoHo(cord)

                    'Class_SQL.findGoHo(cord) "72200239"

                    '遍歷員工排班清單
                    For index3 = 0 To empyRank.Rows.Count - 1
                        '查詢工號找出符合的員工排班資料
                        If goho = empyRank.Rows(index3)("code").ToString() Then

                            '將排班清單的編號轉換成上班開始時間準備後面的判斷*******

                            Dim list As String = Class_SQL.hoildayfilt(empyRank.Rows(index3)("rank").ToString, holiday.Rows(index)("Expr2"))
                            Dim worklist() As String

                            If list <> "" Then
                                worklist = list.Split("/")
                            Else
                                MessageBox.Show("工號:" + goho + " 未正確排班(需有正常班與休息日)")
                                list = empyRank.Rows(index3)("rank").ToString
                                worklist = list.Split("/")
                            End If



                            '排班時間參數用於判斷
                            Dim workrang As Integer = worklist.Length - 2 '陣列0 減一 "/"空白處 減一 ，陣列數量....
                            Dim worktimelist(workrang) As Date
                            For index4 = 0 To worktimelist.Length - 1
                                For index5 = 0 To rankList.Rows.Count - 1
                                    If rankList.Rows(index5)("Code") = worklist(index4) Then
                                        worktimelist(index4) = CDate(rankList.Rows(index5)("WorkBeginTime"))
                                        Exit For
                                    End If
                                Next
                            Next
                            '*********************************************************
                            '行事曆OK 單筆刷卡紀錄OK 單筆員工資料OK 員工排班時間清單OK 排班清單OK
                            '************轉班一天兩個班未處理**************
                            '程式邏輯 選出最秒數距離最小的班別時間，取出排班清單，匯入view並把相關資料一併匯入完成排班

                            '將刷卡紀錄與上班時間相差秒數存入陣列
                            Dim WorkTimeSec(workrang, 1) As String
                            For index5 = 0 To worktimelist.Length - 1
                                WorkTimeSec(index5, 0) = DateDiff("s", dt2, worktimelist(index5)).ToString()
                                WorkTimeSec(index5, 1) = worklist(index5)
                            Next

                            '冒泡排序找出許刷卡時間最接近的班別
                            Dim a(workrang, 1), b(workrang, 1) As String
                            Dim c, d As Integer
                            a = WorkTimeSec
                            For c = 1 To workrang
                                For d = 0 To workrang - c
                                    If Math.Abs(Val(a(d, 0))) > Math.Abs(Val(a(d + 1, 0))) Then
                                        b(d, 0) = a(d + 1, 0)
                                        b(d, 1) = a(d + 1, 1)
                                        a(d + 1, 0) = a(d, 0)
                                        a(d + 1, 1) = a(d, 1)
                                        a(d, 0) = b(d, 0)
                                        a(d, 1) = b(d, 1)
                                    End If
                                Next d
                            Next c

                            Dim line As Integer
                            line = DataGridView1.Rows.Add()
                            DataGridView1.Rows(line).Cells("code").Value = empyRank.Rows(index3)("code")
                            DataGridView1.Rows(line).Cells("name").Value = RTrim(empyRank.Rows(index3)("CnName"))
                            DataGridView1.Rows(line).Cells("mon").Value = dt
                            Dim dr As DataRow()
                            dr = rankList.Select("Code = " + a(0, 1))

                            '2014/11/新增转班判断函式 ----Tim
                            If twoworklist(worklist) Then
                                'dr = changework(a(0, 1))
                            End If

                            DataGridView1.Rows(line).Cells("rank").Value = dr(0)("Expr1").ToString()
                            DataGridView1.Rows(line).Cells("holiday").Value = holiday.Rows(index)("Expr2")
                            DataGridView1.Rows(line).Cells("sn").Value = kijiList.Rows(index2)("sn")
                            DataGridView1.Rows(line).Cells("KiJi").Value = kijiList.Rows(index2)("KiJi")
                            DataGridView1.Rows(line).Cells("KiJiTime").Value = kijiList.Rows(index2)("KiJiTime")
                            DataGridView1.Rows(line).Cells("GioingHao").Value = kijiList.Rows(index2)("GioingHao")

                            '2014/11/新增上班时间与最近刷卡时间还有30分钟以上差距则用红底警示 ----Tim
                            If a(0, 0) >= 1800 Then
                                DataGridView1.Rows(line).DefaultCellStyle.BackColor = Color.Red
                            End If

                            '刪除重複與中午刷卡數據
                            Dim dellist As New Collection
                            For index6 = 0 To DataGridView1.Rows.Count - 1
                                If DataGridView1.Rows(line).Cells("code").Value = DataGridView1.Rows(index6).Cells("code").Value Then
                                    If line <> index6 Then
                                        'DataGridView1.Rows(index6).DefaultCellStyle.BackColor = Color.Red
                                        Dim k1, k2 As String
                                        k1 = DataGridView1.Rows(line).Cells("KiJiTime").Value
                                        k2 = DataGridView1.Rows(index6).Cells("KiJiTime").Value
                                        If k1 > k2 Then
                                            dellist.Add(line)
                                        Else
                                            dellist.Add(index6)
                                        End If
                                    End If
                                End If
                            Next

                            For Each item As Integer In dellist
                                DataGridView1.Rows.RemoveAt(item)
                            Next

                        ElseIf goho = "false" Then
                            Dim line As Integer
                            line = DataGridView1.Rows.Add()
                            DataGridView1.Rows(line).Cells("code").Value = empyRank.Rows(index3)("code")
                            DataGridView1.Rows(line).DefaultCellStyle.BackColor = Color.Red
                        End If
                    Next
                End If
            Next
        Next
        Load_Cmd.Enabled = True
    End Sub

    '转班班别分析
    Private Function changework(ByVal a As String) As DataRow()
        Dim dr As DataRow()


        Return dr
    End Function

    '查找是否有转班班别～回传布林值
    Private Function twoworklist(ByVal worklist As String()) As Boolean
        Dim bl As Boolean
        bl = False
        Dim lista() As String
        Dim list As String = "0039/0040/0041/0042/0043"
        lista = List.Split("/")
        For Each item As String In worklist
            For Each item1 As String In lista
                If item1 = item Then
                    bl = True
                End If
            Next
        Next
        Return bl
    End Function


    Private Sub OutExecl_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutExecl_Cmd.Click
        Dim UserFileTemp As String = ""
        OutExecl.OutExecl(DataGridView1, UserFileTemp, False)
        If UserFileTemp <> "" Then
            System.Diagnostics.Process.Start(UserFileTemp)
        End If
    End Sub

    Private Sub Exit_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_Cmd.Click
        Me.Close()
    End Sub

    Dim first As Boolean = False
    Private Sub PaiBan_Form_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Resize

        If first Then
            DataGridView1.Height = Me.Height - 134
            DataGridView1.Width = Me.Width - 43
            Me.Refresh()
        End If
        first = True
       
    End Sub

    Private Sub PaiBan_Form_ResizeEnd(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ResizeEnd
       
    End Sub

End Class