Imports Microsoft.Office.Interop

Public Class Class_ALL

End Class

'------有关DataGridView设定 清除 数量合并-----
Public Class DataGridViewSet

    '-----依资料调整栏宽  依名称调整栏宽 列顺序的调整(可手动)------
    Public Shared Sub AutoMode(ByRef MeDataGridView1 As DataGridView)  '自定义一个查询函数

        '-----依栏位名称大小自动调整栏宽(但是手动调整栏宽被锁)-----
        'DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader
        '-----先自动依ROWS资料调整栏宽-----
        MeDataGridView1.AutoResizeColumns()
        '-----再设定自动依栏位名称调整栏宽-----
        MeDataGridView1.AutoResizeColumnHeadersHeight()
        '-----列顺序的调整(可手动)-----
        MeDataGridView1.AllowUserToOrderColumns = True
        '可以调整行大小
        'DataGridView1.AllowUserToResizeColumns = True

        '-----单列排序-----
        'Dim direction As System.ComponentModel.ListSortDirection = System.ComponentModel.ListSortDirection.Ascending     'Descending
        'MeDataGridView1.Sort(MeDataGridView1.Columns(ColumnName), direction)

    End Sub

    '-----清除DataSet.Table和DataGridView-----
    Public Shared Sub ClearDataBase(ByRef MeDataGridView1 As DataGridView)

        MeDataGridView1.Rows.Clear()
        MeDataGridView1.Columns.Clear()

        '-----设定DataGridView1的字体大小(NEW FONT会跟判断成EXECL的FONT，所以要用成System.Drawing.Font，这样才会抓成系统的FONT）-----
        MeDataGridView1.DefaultCellStyle.Font = New System.Drawing.Font(MeDataGridView1.DefaultCellStyle.Font.FontFamily, Main_Form.DefFontTemp)

    End Sub

    '-----清除DataGridView的ROWS-----
    Public Shared Sub ClearRows(ByRef MeDataGridView1 As DataGridView)

        MeDataGridView1.Rows.Clear()

        '-----设定DataGridView1的字体大小(NEW FONT会跟判断成EXECL的FONT，所以要用成System.Drawing.Font，这样才会抓成系统的FONT）-----
        MeDataGridView1.DefaultCellStyle.Font = New System.Drawing.Font(MeDataGridView1.DefaultCellStyle.Font.FontFamily, Main_Form.DefFontTemp)

    End Sub

    '-----清除DataGridView的Columns-----
    Public Shared Sub ClearColumns(ByRef MeDataGridView1 As DataGridView)

        MeDataGridView1.Columns.Clear()

        '-----设定DataGridView1的字体大小(NEW FONT会跟判断成EXECL的FONT，所以要用成System.Drawing.Font，这样才会抓成系统的FONT）-----
        MeDataGridView1.DefaultCellStyle.Font = New System.Drawing.Font(MeDataGridView1.DefaultCellStyle.Font.FontFamily, Main_Form.DefFontTemp)

    End Sub

    '-----数量合并-----
    Public Shared Sub Quantity_Merger(ByVal Item As String, _
                                      ByVal Quantity As String, _
                                      ByRef MeDataGridView1 As DataGridView, _
                                      Optional ByVal MergerA As String = "", _
                                      Optional ByVal MergerB As String = "", _
                                      Optional ByVal MergerC As String = "", _
                                      Optional ByVal MergerD As String = "", _
                                      Optional ByVal MergerE As String = "", _
                                      Optional ByVal MergerF As String = "", _
                                      Optional ByVal MergerG As String = "", _
                                      Optional ByVal MergerH As String = "", _
                                      Optional ByVal MergerI As String = "", _
                                      Optional ByVal MergerJ As String = "")
        '-----Item要依那一栏合并， Quantity那一栏的数字被合并-----

        '-----品号栏位名称，数量栏位名称，DataGridView，单价是否可看, MergerA其他需要合并的栏位-----

        '-----单列排序-----
        Dim direction As System.ComponentModel.ListSortDirection = System.ComponentModel.ListSortDirection.Ascending     'Descending
        MeDataGridView1.Sort(MeDataGridView1.Columns(Item), direction)

        Dim X As Integer = 1

        Do
            If MeDataGridView1.Rows(X).Cells(Item).Value = MeDataGridView1.Rows(X - 1).Cells(Item).Value Then

                MeDataGridView1.Rows(X - 1).Cells(Quantity).Value += MeDataGridView1.Rows(X).Cells(Quantity).Value

                If MergerA <> "" And MeDataGridView1.Columns.Contains(MergerA) = True Then
                    MeDataGridView1.Rows(X - 1).Cells(MergerA).Value += MeDataGridView1.Rows(X).Cells(MergerA).Value
                End If
                If MergerB <> "" And MeDataGridView1.Columns.Contains(MergerB) = True Then
                    MeDataGridView1.Rows(X - 1).Cells(MergerB).Value += MeDataGridView1.Rows(X).Cells(MergerB).Value
                End If
                If MergerC <> "" And MeDataGridView1.Columns.Contains(MergerC) = True Then
                    MeDataGridView1.Rows(X - 1).Cells(MergerC).Value += MeDataGridView1.Rows(X).Cells(MergerC).Value
                End If
                If MergerD <> "" And MeDataGridView1.Columns.Contains(MergerD) = True Then
                    MeDataGridView1.Rows(X - 1).Cells(MergerD).Value += MeDataGridView1.Rows(X).Cells(MergerD).Value
                End If
                If MergerE <> "" And MeDataGridView1.Columns.Contains(MergerE) = True Then
                    MeDataGridView1.Rows(X - 1).Cells(MergerE).Value += MeDataGridView1.Rows(X).Cells(MergerE).Value
                End If
                If MergerF <> "" And MeDataGridView1.Columns.Contains(MergerF) = True Then
                    MeDataGridView1.Rows(X - 1).Cells(MergerF).Value += MeDataGridView1.Rows(X).Cells(MergerF).Value
                End If
                If MergerG <> "" And MeDataGridView1.Columns.Contains(MergerG) = True Then
                    MeDataGridView1.Rows(X - 1).Cells(MergerG).Value += MeDataGridView1.Rows(X).Cells(MergerG).Value
                End If
                If MergerH <> "" And MeDataGridView1.Columns.Contains(MergerH) = True Then
                    MeDataGridView1.Rows(X - 1).Cells(MergerH).Value += MeDataGridView1.Rows(X).Cells(MergerH).Value
                End If
                If MergerI <> "" And MeDataGridView1.Columns.Contains(MergerI) = True Then
                    MeDataGridView1.Rows(X - 1).Cells(MergerI).Value += MeDataGridView1.Rows(X).Cells(MergerI).Value
                End If
                If MergerJ <> "" And MeDataGridView1.Columns.Contains(MergerJ) = True Then
                    MeDataGridView1.Rows(X - 1).Cells(MergerJ).Value += MeDataGridView1.Rows(X).Cells(MergerJ).Value
                End If

                MeDataGridView1.Rows.RemoveAt(X)
                X -= 1
            End If

            X += 1

        Loop Until X > MeDataGridView1.RowCount - 1

    End Sub

End Class

'各画面按钮依权限设定 Enabled 的值
Public Class Cmd

    '各画面进入时，先将所有的Cmd的 Enabled = False
    Public Shared Sub CmdFalse(ByRef AForm)

        For i As Integer = 0 To AForm.Controls.Count - 1
            If Microsoft.VisualBasic.Right(AForm.Controls.Item(i).Name, 3) = "Cmd" Then
                AForm.Controls.Item(i).Enabled = False
            End If
        Next
    End Sub

    '各画面进入时，先将所有的Cmd的 Enabled = False 再依权限开启 Enabled = True
    Public Shared Sub CmdTrue(ByRef AForm)

        If Array.IndexOf(Main_Form.FormCmd, Replace(AForm.Name, "_Form", "_Cmd")) >= 0 And Array.LastIndexOf(Main_Form.FormCmd, Replace(AForm.Name, "_Form", "_Cmd")) >= 0 Then
            For i As Integer = Array.IndexOf(Main_Form.FormCmd, Replace(AForm.Name, "_Form", "_Cmd")) _
                               To _
                 Array.LastIndexOf(Main_Form.FormCmd, Replace(AForm.Name, "_Form", "_Cmd"))

                If RTrim(Main_Form.UserPermit.Rows(i).Cells("AllCmdOpen").Value) = "Y" Then
                    AForm.Controls.Item(RTrim(Main_Form.UserPermit.Rows(i).Cells("AllCmd").Value)).Enabled = True
                End If
            Next
        End If

    End Sub

End Class

'共用的条件的SQL语法
Public Class ShareSQL

    '公司别条件的SQL语法（含行政跟非行政）
    Public Shared Function CorporationSQL(ByVal SZ_Radio As Boolean, ByVal SH_Radio As Boolean, ByVal CmdLocationNo As Integer)

        '权限表苏州
        Dim ShareSZ As String = RTrim(Main_Form.UserPermit.Rows(CmdLocationNo).Cells("SZ").Value)
        '权限表苏州行政人员
        Dim ShareSZStaffYes As String = RTrim(Main_Form.UserPermit.Rows(CmdLocationNo).Cells("SZStaffYes").Value)
        '权限表苏州非行政人员
        Dim ShareSZStaffNo As String = RTrim(Main_Form.UserPermit.Rows(CmdLocationNo).Cells("SZStaffNo").Value)
        '权限表上海
        Dim ShareSH As String = RTrim(Main_Form.UserPermit.Rows(CmdLocationNo).Cells("SH").Value)
        '权限表上海行政人员
        Dim ShareSHStaffYes As String = RTrim(Main_Form.UserPermit.Rows(CmdLocationNo).Cells("SHStaffYes").Value)
        '权限表上海非行政人员
        Dim ShareSHStaffNo As String = RTrim(Main_Form.UserPermit.Rows(CmdLocationNo).Cells("SHStaffNo").Value)

        '假如权限表的SZ和SH 其中一个是Y
        If ShareSZ = "Y" Or ShareSH = "Y" Then
            '原画面 SZ_Radio & 权限表的SZ & 原画面 SH_Radio & 权限表的SH
            Select Case SZ_Radio.ToString & ShareSZ & SH_Radio.ToString & ShareSH


                '假如 原画面有勾选 SZ_Radio & 权限表的SZ是Y & 原画面没有勾SH_Radio & 权限表的SH不管是Y或N
                Case "TrueYFalseN", "TrueYFalseY"
                    '权限表的SZStaffYes & SZStaffNo （行政 & 非行政）
                    Select Case ShareSZStaffYes & ShareSZStaffNo
                        '行政 跟 非行政 都有权限
                        Case "YY"
                            Return " And Corporation.ShortName = '苏州惠亚' And (Job.Name Like '%行政%' or Job.Name Not Like '%行政%') "
                            '行政 有权限；非行政 没有权限
                        Case "YN"
                            Return " And Corporation.ShortName = '苏州惠亚' And Job.Name Like '%行政%' "
                            '行政 没有权限；非行政 有权限
                        Case "NY"
                            Return " And Corporation.ShortName = '苏州惠亚' And Job.Name Not Like '%行政%' "
                    End Select

                    Return " And Corporation.ShortName = '苏州惠亚' And Job.Name = '不抓' "


                    '假如 原画面没有勾选 SZ_Radio & 权限表的SZ不管是Y或N & 原画面有勾SH_Radio & 权限表的SH是Y
                Case "FalseNTrueY", "FalseYTrueY"
                    '权限表的SHStaffYes & SHStaffNo （行政 & 非行政）
                    Select Case ShareSHStaffYes & ShareSHStaffNo
                        '行政 跟 非行政 都有权限
                        Case "YY"
                            Return " And Corporation.ShortName = '上海惠亚' And (Job.Name Like '%行政%' or Job.Name Not Like '%行政%') "
                            '行政 有权限；非行政 没有权限
                        Case "YN"
                            Return " And Corporation.ShortName = '上海惠亚' And Job.Name Like '%行政%' "
                            '行政 没有权限；非行政 有权限
                        Case "NY"
                            Return " And Corporation.ShortName = '上海惠亚' And Job.Name Not Like '%行政%' "
                    End Select

                    Return " And Corporation.ShortName = '上海惠亚' And Job.Name = '不抓' "

                Case Else

                    Return " And Corporation.ShortName = '不抓' "

            End Select

        Else
            Return " And Corporation.ShortName = '不抓' "
        End If

    End Function

    Public Shared Function PowerLab(ByVal CmdLocationNo As Integer)

        Dim PowerList As String = ""

        '权限表苏州
        PowerList = IIf(RTrim(Main_Form.UserPermit.Rows(CmdLocationNo).Cells("SZ").Value) = "Y", "苏州 ", "")
        '权限表苏州行政人员
        PowerList = PowerList & IIf(RTrim(Main_Form.UserPermit.Rows(CmdLocationNo).Cells("SZStaffYes").Value) = "Y", "苏州行政人员 ", "")
        '权限表苏州非行政人员
        PowerList = PowerList & IIf(RTrim(Main_Form.UserPermit.Rows(CmdLocationNo).Cells("SZStaffNo").Value) = "Y", "苏州非行政人员 ", "")
        '权限表上海
        PowerList = PowerList & IIf(RTrim(Main_Form.UserPermit.Rows(CmdLocationNo).Cells("SH").Value) = "Y", "     上海 ", "")
        '权限表上海行政人员
        PowerList = PowerList & IIf(RTrim(Main_Form.UserPermit.Rows(CmdLocationNo).Cells("SHStaffYes").Value) = "Y", "上海行政人员 ", "")
        '权限表上海非行政人员
        PowerList = PowerList & IIf(RTrim(Main_Form.UserPermit.Rows(CmdLocationNo).Cells("SHStaffNo").Value) = "Y", "上海非行政人员 ", "")

        Return PowerList

    End Function

End Class

'-----汇出EXEC-----
Public Class OutExecl


    '-----汇出EXEC（DataGridView1, 是否删除栏位名称）-----
    Public Shared Sub OutExecl(ByVal MEDataGridView As DataGridView, ByRef UserFileTemp As String, Optional ByVal HeaderText As Boolean = False)

        '现在资源管理器的SZVERO右键 选“添加引用”
        '将Microsoft.Office.Interop.Excel加入
        '在表头下Imports Microsoft.Office.Interop.Excel
        '----------------------------------------------
        '或是在资源管理器的SZVERO右键 选 “属性”
        '在下面 “导入的命名空间”将 "Microsoft.Office.Interop.Excel" 打勾
        '----------------------------------------------------------------
        '先從儲存格(1,1)開始, 寫入欄位名稱

        If MEDataGridView.Rows.Count > 0 Then
            Dim SheetNum As Integer = 1
            Dim SheetName As String = "第" & SheetNum & "页"

            'app為excel程式
            'Dim xlApp As Application = New Application
            'wb為活頁簿
            'Dim xlWorkBook As Workbook = xlApp.Workbooks.Add()
            ' ws為工作表
            'Dim xlWorkSheet As Worksheet = xlWorkBook.Worksheets.Add

            Dim xlApp As New Microsoft.Office.Interop.Excel.Application
            Dim xlWorkBooks As Microsoft.Office.Interop.Excel.Workbooks = xlApp.Workbooks
            Dim xlWorkBook As Microsoft.Office.Interop.Excel.Workbook '= xlWorkBooks.Add()
            Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet '= xlWorkBook.ActiveSheet   'Worksheets.Add()

            '-----开档-----
            xlWorkBook = xlWorkBooks.Add()

            '-----新增活页-----放下面
            'xlWorkSheet = xlWorkBook.Sheets.Add()
            '-----命名-----放下面
            'xlWorkBook.Sheets.Item(SheetNum).name = SheetName
            'xlWorkSheet.Name = SheetName

            Dim i, j, k, l As Integer
            Dim m As Integer = 0       '记录处理的笔数
            Dim n As Integer = 0       '记录是否有底色
            Dim EXECL_TOTAL_Count As Integer = 60000

            '为解决EXECL不能自动关闭
            '从xlWorkBook = xlApp.Workbooks.Add()
            '改为如下
            'xlWorkBooks = xlApp.Workbooks = xlApp.Workbooks
            'xlWorkBook = xlWorkBooks.add()
            'xlWorkSheet = xlApp.ActiveSheet

            Waiting_Form.Show()
            Waiting_Form.Label1.Text = "资料汇出中....."
            Waiting_Form.Refresh()
            'xlApp.Visible = True

            Dim Row_Count As Integer = MEDataGridView.Rows.Count - 1
            Dim ABA As Integer = Row_Count / EXECL_TOTAL_Count

            For k = 0 To ABA

                MEDataGridView.ClearSelection()

                xlWorkSheet = xlWorkBook.Sheets.Add
                xlWorkSheet.Name = SheetName
                SheetNum = SheetNum + 1
                SheetName = "第" & SheetNum & "页"

                For j = 0 To MEDataGridView.Columns.Count - 1
                    If MEDataGridView.Columns(j).Visible = True Then
                        If MEDataGridView.Columns(j).DefaultCellStyle.Format.ToString = "" Then
                            xlWorkSheet.Columns(j + 1).NumberFormatLocal = "@"
                        Else
                            xlWorkSheet.Columns(MEDataGridView.Columns(j).DisplayIndex + 1).NumberFormatLocal = MEDataGridView.Columns(j).DefaultCellStyle.Format.ToString
                        End If
                        '.HorizontalAlignment = xlRight  MiddleRight NotSet
                        'xlWorkSheet.Cells(1, j + 1) = MEDataGridView.Columns(j).HeaderText
                        xlWorkSheet.Columns(MEDataGridView.Columns(j).DisplayIndex + 1).ColumnWidth = Val(MEDataGridView.Columns(j).Width.ToString) / 8
                        xlWorkSheet.Columns(MEDataGridView.Columns(j).DisplayIndex + 1).Font.Size = Main_Form.DefFontTemp

                        Select Case MEDataGridView.Columns(j).DefaultCellStyle.Alignment.ToString
                            Case "NotSet", "MiddleLeft"
                                xlWorkSheet.Columns(MEDataGridView.Columns(j).DisplayIndex + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                            Case "MiddleRight"
                                xlWorkSheet.Columns(MEDataGridView.Columns(j).DisplayIndex + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignRight
                            Case "MiddleCenter"
                                xlWorkSheet.Columns(MEDataGridView.Columns(j).DisplayIndex + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
                            Case Else
                                xlWorkSheet.Columns(MEDataGridView.Columns(j).DisplayIndex + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft
                        End Select

                    End If
                Next

                xlWorkSheet.Rows(1).Font.Size = Main_Form.DefFontTemp

                '*****旧做法一个一个COPY*****
                '-----一个一个COPY-----
                'For j = 0 To DataGridView1.Columns.Count - 1
                'For i = 0 To (Row_Count - 65530 * k)
                'If RGB(DataGridView1.Rows(i + (65530 * k)).Cells(j).InheritedStyle.BackColor.R, DataGridView1.Rows(i + (65530 * k)).Cells(j).InheritedStyle.BackColor.G, DataGridView1.Rows(i + (65530 * k)).Cells(j).InheritedStyle.BackColor.B).ToString <> 16777215 Then
                '-----一格一格上色-----
                'xlWorkSheet.Cells(i + 2, j + 1).interior.color = RGB(DataGridView1.Rows(i + (65530 * k)).Cells(j).InheritedStyle.BackColor.R, DataGridView1.Rows(i + (65530 * k)).Cells(j).InheritedStyle.BackColor.G, DataGridView1.Rows(i + (65530 * k)).Cells(j).InheritedStyle.BackColor.B)
                '-----一行一行上色-----
                'xlWorkSheet.Rows(i + 2).interior.color = RGB(DataGridView1.Rows(i + (65530 * k)).Cells(j).InheritedStyle.BackColor.R, DataGridView1.Rows(i + (65530 * k)).Cells(j).InheritedStyle.BackColor.G, DataGridView1.Rows(i + (65530 * k)).Cells(j).InheritedStyle.BackColor.B)
                'End If
                'xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1.Rows(i + (65530 * k)).Cells(j).Value
                'xlWorkSheet.Cells(i + 2, j + 1) = DataGridView1.Item(j, i + (65530 * k)).Value
                '＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
                '更改Excel标题栏()
                'xlApp.Caption = "VFP应用程序调用Microsoft Excel"
                '在第18行之前插入分页符()
                'xlWorkSheet.Rows(18).PageBreak = 1
                '在第4列之前删除分页符()
                'xlWorkSheet.Columns(4).PageBreak = 0
                '指定边框线宽度(Borders参数如下)
                'xlWorkSheet.Range("b3:d3").Borders(2).Weight = 3
                '设置四个边框线条的类型()
                'xlWorkSheet.Range("b3:d3").Borders(2).LineStyle = 1
                '(其中Borders参数：1－左、2－右、3－顶、4－底、5－斜、6－斜/；LineStyle值：1与7－细实、2－细虚、4－点虚、9－双细实线)
                '设置页眉()
                'xlWorkSheet.PageSetup.CenterHeader = "报表1"
                '设置页脚()
                'xlWorkSheet.PageSetup.CenterFooter = "第＆P页"
                '设置页眉到顶端边距为2厘米()
                'xlWorkSheet.PageSetup.HeaderMargin = 2 / 0.035
                '设置页脚到底边距为3厘米()
                'xlWorkSheet.ActiveSheet.PageSetup.FooterMargin = 3 / 0.035
                '设置顶边距为2厘米()
                'xlWorkSheet.PageSetup.TopMargin = 2 / 0.035
                '设置底边距为4厘米()
                'xlWorkSheet.PageSetup.BottomMargin = 4 / 0.035
                '设置左边距为2厘米()
                'xlWorkSheet.PageSetup.LeftMargin = 2 / 0.035
                '设置右边距为2厘米()
                'xlWorkSheet.PageSetup.RightMargin = 2 / 0.035
                '设置页面水平居中()
                'xlWorkSheet.PageSetup.CenterHorizontally = True
                '设置页面垂直居中()
                'xlWorkSheet.PageSetup.CenterVertically = True
                '设置页面纸张大小(1－窄行8 5 11 39－宽行14 11)
                'xlWorkSheet.ActiveSheet.PageSetup.PaperSize = 1
                '设置字体()
                'xlWorkSheet.ActiveSheet.Cells(2, 1).Font.Name = "黑体"
                '设置字体大小()
                'xlWorkSheet.ActiveSheet.Cells(1, 1).Font.Size = 25
                '设置字体为斜体()
                'xlWorkSheet.ActiveSheet.Cells(1, 1).Font.Italic = True
                '设置整列字体为粗体()
                'xlWorkSheet.ActiveSheet.Columns(1).Font.Bold = True
                '清除单元格公式()
                'xlWorkSheet.ActiveSheet.Cells(1, 4).ClearContents()
                '打印预览工作表()
                'xlWorkSheet.ActiveSheet.PrintPreview()
                '打印输出工作表()
                'xlWorkSheet.ActiveSheet.PrintOut()
                '工作表另为()
                'xlWorkSheet.ActiveWorkbook.SaveAs("c:\temp\22.xls")
                '放弃存盘()
                'xlWorkSheet.ActiveWorkbook.saved = True
                '设置新增工作薄的工作表数：
                'xlApp.SheetsInNewWorkbook = 1 '&&新建工作表数量定为1个
                '新增EXCEL工作薄：
                'xlApp.Workbooks.Add()
                '当前工作薄工作表总数：
                'A = xlApp.Worksheets.Count     ' &&如：lnSheetCnt=oExcel.WorkSheets.count
                '新增EXCEL工作表：
                'xlApp.Sheets.Add()      ' &&不带参数为增加至当前工作表之前
                '在指定工作表后新建工作表：
                'xlApp.Sheets.Add(, xlApp.Sheets(lnSheet), 1, -4167)     '&&lnSheet为指定表号
                '在最后工作表后新建工作表：
                'xlApp.Sheets.Add(, lnSheetsCnt, 1, -4167)    ' &&lnSheetCnt为工作表总数   
                '＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊＊
                'Next
                'Next
                '******************************

                '+++++新做法整个COPY+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++
                '设置复制模式为:连同行头和表头一起复制
                MEDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText
                'MEDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText
                '如果不需要复制行头, 就把它隐藏掉
                MEDataGridView.RowHeadersVisible = False
                'Me.DataGridView1.ColumnHeadersVisible = False

                l = EXECL_TOTAL_Count - 1

                If l + EXECL_TOTAL_Count * k > Row_Count Then l = Row_Count Else l = l + EXECL_TOTAL_Count * k

                If Row_Count <= EXECL_TOTAL_Count Then
                    MEDataGridView.SelectAll()
                Else

                    For i = (0 + EXECL_TOTAL_Count * k) To l
                        '/////复制贴上////////////////////////////////
                        MEDataGridView.Rows(i).Selected = True

                        If MEDataGridView.Rows(i).DefaultCellStyle.BackColor <> Color.Empty Then
                            n += 1
                        End If
                        '*****一格一格COPY*********************************
                        'For j = 0 To MEDataGridView.Columns.Count - 1
                        'xlWorkSheet.Cells(i - EXECL_TOTAL_Count * k + 2, j + 1) = MEDataGridView.Rows(i + (l * k)).Cells(j).Value
                        'Next
                        '**************************************************
                    Next

                End If

                '/////复制贴上////////////////////////////////
                '判断DataGridView1中是否有选中单元格(与上面好像有点矛盾,自行处理)
                'If Me.DataGridView1.GetCellCount(DataGridViewElementStates.Selected) > 0 Then
                Clipboard.SetDataObject(MEDataGridView.GetClipboardContent())
                'End If

                '為防止亂碼。使用選擇性粘貼
                '下面這一行，相當于在Excel中點擊右鍵->選擇性粘貼->文本    '＊＊＊繁体要用“文字”  简体要用“文本”
                '-----取得语系-----
                If Microsoft.VisualBasic.InStr(My.Application.UICulture.Name.ToString, "CN") <> 0 Then
                    xlWorkSheet.PasteSpecial(Format:="Unicode 文本", Link:=False, DisplayAsIcon:=False)
                ElseIf Microsoft.VisualBasic.InStr(My.Application.UICulture.Name.ToString, "TW") <> 0 Then
                    xlWorkSheet.PasteSpecial(Format:="Unicode 文字", Link:=False, DisplayAsIcon:=False)
                Else
                    xlWorkSheet.PasteSpecial(Format:="Unicode 文本", Link:=False, DisplayAsIcon:=False)
                End If

                MEDataGridView.ClearSelection()
                MEDataGridView.Item(0, 0).Selected = True
                MEDataGridView.RowHeadersVisible = True
                '////////////////////////////////////////////////////////

                l = EXECL_TOTAL_Count - 1


                If l + EXECL_TOTAL_Count * k > Row_Count Then l = Row_Count Else l = l + EXECL_TOTAL_Count * k

                If n <> 0 Then
                    For i = (0 + EXECL_TOTAL_Count * k) To l

                        xlWorkSheet.Rows(i + 2).RowHeight = Val(MEDataGridView.Rows(i).Height.ToString) * 0.61
                        'xlWorkSheet.Rows(i + 2).Font.Size = Menu_Form.Font_Lab.Text

                        If MEDataGridView.Rows(i).DefaultCellStyle.BackColor <> Color.Empty Then
                            '-----一行一行上色-----
                            xlWorkSheet.Rows(i - EXECL_TOTAL_Count * k + 2).interior.color = RGB(MEDataGridView.Rows(i).Cells(1).InheritedStyle.BackColor.R, MEDataGridView.Rows(i).Cells(1).InheritedStyle.BackColor.G, MEDataGridView.Rows(i).Cells(1).InheritedStyle.BackColor.B)
                        End If

                        Waiting_Form.Label1.Text = "资料汇出中  " & m & "／" & MEDataGridView.RowCount
                        Waiting_Form.Refresh()

                        m += 1
                    Next
                End If

                If HeaderText = True Then
                    xlWorkSheet.Rows(1).Delete()
                End If

            Next

            '++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

            Waiting_Form.Close()

            xlWorkBook.Sheets.Item("Sheet1").Delete()
            '-----开启EXECL-----
            'xlApp.Visible = True

            '-----取得要COPY之后的路径和档名（Documents and Settings\user\temp\DocID（存档名称）+FileName（文件名称）的副档名）------
            UserFileTemp = Microsoft.VisualBasic.Environ("TMP") & "\VBTEMP\" & Date.Now.ToString("yyyyMMddHHmmss") & ".XLS"
            If My.Computer.FileSystem.DirectoryExists(Microsoft.VisualBasic.Environ("TMP") & "\VBTEMP\") Then
            Else
                My.Computer.FileSystem.CreateDirectory(Microsoft.VisualBasic.Environ("TMP") & "\VBTEMP\")
            End If

            '-----EXECL存档-----
            'xlWorkSheet.SaveAs(UserFileTemp)
            xlWorkBook.SaveAs(UserFileTemp)
            'xlApp.SaveWorkspace(UserFileTemp)
            'xlApp.Visible = False

            'xlApp.Visible = False

            xlWorkBook.Close()
            xlWorkBooks.Close()
            xlApp.Quit()

            xlWorkSheet = Nothing
            xlWorkBook = Nothing
            xlWorkBooks = Nothing
            xlApp = Nothing

            'xlApp.Windows.Application.Quit()

            GC.Collect()

            'Date.Now.ToString("yyyyMMddHHmmss")
            'NAR(xlWorkSheet)
            'NAR(xlWorkBook)
            'NAR(xlWorkBooks)
            'NAR(xlApp)
            'Dim process As New Process
            'process.StartInfo.FileName = "c:\xml2excel.xls"
            'process.Start("c:\xml2excel.xls")
        Else
            MessageBox.Show("提示：没有记录不能导出数据")

        End If


    End Sub


    '-----解决EXECL不关闭的问题-----
    'Private Sub NAR(ByVal o As Object)
    'Try
    'System.Runtime.InteropServices.Marshal.ReleaseComObject(o)
    'Catch
    'Finally
    'o = Nothing
    'End Try
    'End Sub

End Class
