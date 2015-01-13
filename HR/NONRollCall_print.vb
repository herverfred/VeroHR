Public Class NONRollCall_print

    Private WithEvents PrintDocument1 As New Printing.PrintDocument
    Private WithEvents PageSetupDialog1 As New System.Windows.Forms.PageSetupDialog
    Private WithEvents FontDialog1 As New System.Windows.Forms.FontDialog
    Private WithEvents PrintPreviewDialog1 As New System.Windows.Forms.PrintPreviewDialog
    Private WithEvents PageDialog1 As New PrintDialog
    Private DGV1 As DataGridView
    Private strTitle As String
    Private strCompany As String
    Private MainStartHeigth As Single 'MainStartHeigth 为主体表格起始的高度
    Public PrintFont As System.Drawing.Font = New System.Drawing.Font("宋体", 10)
    Public PrintFont8 As System.Drawing.Font = New System.Drawing.Font("宋体", 8)
    '-----因为会重复执行，放在 Private Sub会一直归0，所以放在这------
    Public X As Integer = 0
    Public Y As Integer = 0
    Shared pNo As Integer = 1 'pNo 为页码
    Shared pNoTatalTemp As Integer = 0 'pNo 为总页码
    Public TotalA1 As Integer     '当月的最后一天是几号
    Public TotalA2 As String      '当月的1号~最后一号

    '-----每个采购发票第一笔暂存X，解决单头的单号问题-----
    Public firthXTemp As Integer
    '----每行高度HeightTemp----
    Dim HeightTemp As Integer = 21


    Sub New()
        InitializeComponent()
        AddHandler PrintDocument1.PrintPage, AddressOf Me.pd_PrintMain
    End Sub


    '打印主体
    Private Sub pd_PrintMain(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs)

        '-----用Bounds可自动取得横向或纵向的长宽，如用PageSize则还要判断横向或纵向

        Dim PageWidth As Single
        Dim PageHeight As Single

        '-----纸张直向-----
        If PrintDocument1.DefaultPageSettings.Landscape = False Then
            '----取得宽-50（边距）(A4总宽827 边距39,39 可用749)-----
            'Dim PageWidth As Single = Me.PrintDocument1.DefaultPageSettings.Bounds.Width - e.PageSettings.Margins.Left - e.PageSettings.Margins.Right
            PageWidth = Me.PageSetupDialog1.PageSettings.PaperSize.Width - Me.PageSetupDialog1.PageSettings.Margins.Left - Me.PageSetupDialog1.PageSettings.Margins.Right
            '----取得长-50（边距）(A4总长1091 边距39,39 可用749)-----
            'Dim PageHeight As Single = Me.PrintDocument1.DefaultPageSettings.Bounds.Height - e.PageSettings.Margins.Top - e.PageSettings.Margins.Bottom
            PageHeight = Me.PageSetupDialog1.PageSettings.PaperSize.Height - Me.PageSetupDialog1.PageSettings.Margins.Top - Me.PageSetupDialog1.PageSettings.Margins.Bottom
        Else
            PageHeight = Me.PageSetupDialog1.PageSettings.PaperSize.Width - Me.PageSetupDialog1.PageSettings.Margins.Left - Me.PageSetupDialog1.PageSettings.Margins.Right
            PageWidth = Me.PageSetupDialog1.PageSettings.PaperSize.Height - Me.PageSetupDialog1.PageSettings.Margins.Top - Me.PageSetupDialog1.PageSettings.Margins.Bottom
        End If

        '----记录每个Columns的宽-----
        Dim ColWidth(DGV1.Columns.Count - 1) As Single

        'Dim TotalRowHeigth As Single = 0
        '-----计算Columns总宽-----
        Dim TotalColWidth As Single = 0
        '-----记录用了多少长-----
        Dim RowsHeigth As Single = 0
        '-----记录用了多少宽-----
        Dim ColsWidth As Single = 0
        '----求出DATAGRIDVIEW1的总宽度-----
        For j As Integer = 3 To DGV1.Columns.Count - 1
            ColWidth(j) = DGV1.Columns(j).Width
            TotalColWidth += DGV1.Columns(j).Width
        Next
        '----按页面宽缩小Columns的宽----
        For j As Integer = 3 To DGV1.Columns.Count - 1
            ColWidth(j) = ColWidth(j) * (PageWidth / TotalColWidth)
        Next

        '-----定义矩形内文字的摆法-----
        Dim drawFormat As New StringFormat
        '-----水平（置中）----
        drawFormat.Alignment = StringAlignment.Center
        '-----垂直----
        drawFormat.LineAlignment = StringAlignment.Center
        '----折行时，字要不要切(Ellipsis多一个省略符号)-----
        drawFormat.Trimming = StringTrimming.None
        '----设定只要一行（不设的话，文字会自动折行布满矩形）-----
        drawFormat.FormatFlags = StringFormatFlags.FitBlackBox

        '-----定义矩形内文字的摆法-----
        Dim drawFormatA As New StringFormat
        '-----水平(靠左)----
        drawFormatA.Alignment = StringAlignment.Near
        '-----垂直----
        drawFormatA.LineAlignment = StringAlignment.Center
        '----折行时，字要不要切(Ellipsis多一个省略符号)-----
        drawFormatA.Trimming = StringTrimming.EllipsisWord
        '----设定只要一行（不设的话，文字会自动折行布满矩形）-----
        drawFormatA.FormatFlags = StringFormatFlags.NoWrap

        '-----定义矩形内文字的摆法-----
        Dim drawFormatB As New StringFormat
        '-----水平(靠右)----
        drawFormatB.Alignment = StringAlignment.Far
        '-----垂直----
        drawFormatB.LineAlignment = StringAlignment.Center
        '----折行时，字要不要切(Ellipsis多一个省略符号)-----
        drawFormatB.Trimming = StringTrimming.None
        '----设定只要一行（不设的话，文字会自动折行布满矩形）-----
        drawFormatB.FormatFlags = StringFormatFlags.NoWrap

        '-----定义矩形内文字的摆法-----
        Dim drawFormatC As New StringFormat
        '-----水平(靠左，切断)----
        drawFormatC.Alignment = StringAlignment.Near
        '-----垂直----
        drawFormatC.LineAlignment = StringAlignment.Center
        '----折行时，字要不要切(Ellipsis多一个省略符号)-----
        drawFormatC.Trimming = StringTrimming.Word
        '----设定只要一行（不设的话，文字会自动折行布满矩形）-----
        drawFormatC.FormatFlags = StringFormatFlags.NoWrap

        '-----定义矩形内文字的摆法(靠左 靠上 折行)-----
        Dim drawFormatE As New StringFormat
        '-----水平(靠左，切断)----
        drawFormatE.Alignment = StringAlignment.Near
        '-----垂直----
        drawFormatE.LineAlignment = StringAlignment.Near
        '----折行时，字要不要切(Ellipsis多一个省略符号)-----
        drawFormatE.Trimming = StringTrimming.EllipsisCharacter
        '----设定只要一行（不设的话，文字会自动折行布满矩形）-----
        drawFormatE.FormatFlags = StringFormatFlags.LineLimit

        '-----定义矩形内文字的摆法-----
        Dim drawFormatF As New StringFormat
        '-----水平（置中）----
        drawFormatF.Alignment = StringAlignment.Center
        '-----垂直----
        drawFormatF.LineAlignment = StringAlignment.Center
        '----折行时，字要不要切(Ellipsis多一个省略符号)-----
        drawFormatF.Trimming = StringTrimming.None
        '----设定只要一行（不设的话，文字会自动折行布满矩形）-----
        drawFormatF.FormatFlags = StringFormatFlags.LineLimit

        '-----定义矩形内文字的摆法-----
        Dim drawFormatG As New StringFormat
        '-----水平（置中）----
        drawFormatG.Alignment = StringAlignment.Center
        '-----垂直----
        drawFormatG.LineAlignment = StringAlignment.Center
        '----折行时，字要不要切(Ellipsis多一个省略符号)-----
        drawFormatG.Trimming = StringTrimming.None
        '----设定只要一行（不设的话，文字会自动折行布满矩形）-----
        drawFormatG.FormatFlags = StringFormatFlags.LineLimit

        '-----定义矩形内文字的摆法-----
        Dim drawFormatH As New StringFormat
        '-----水平（置中）----
        drawFormatH.Alignment = StringAlignment.Near
        '-----垂直----
        drawFormatH.LineAlignment = StringAlignment.Center
        '----折行时，字要不要切(Ellipsis多一个省略符号)-----
        drawFormatH.Trimming = StringTrimming.None
        '----设定只要一行（不设的话，文字会自动折行布满矩形）-----
        drawFormatH.FormatFlags = StringFormatFlags.FitBlackBox


        '-----写标题，计算标题的高-----
        Dim sizeFTitle As System.Drawing.SizeF
        sizeFTitle = e.Graphics.MeasureString(strCompany, New Font("宋体", 18, FontStyle.Bold))
        'e.Graphics.DrawString("惠亚科技（苏州）有限公司", New Font("宋体", 18, FontStyle.Bold), System.Drawing.Brushes.Black, PageWidth / 2 - sizeFTitle.Width / 2 + e.PageSettings.Margins.Left, e.PageSettings.Margins.Top)
        'e.Graphics.DrawString(strCompany, New Font("宋体", 18, FontStyle.Bold), System.Drawing.Brushes.Black, New RectangleF(e.PageSettings.Margins.Left, e.PageSettings.Margins.Top, PageWidth, sizeFTitle.Height), drawFormat)
        MainStartHeigth = sizeFTitle.Height
        RowsHeigth = e.PageSettings.Margins.Top + sizeFTitle.Height

        sizeFTitle = e.Graphics.MeasureString(strTitle, New System.Drawing.Font("宋体", 18, FontStyle.Bold))   ' Title
        e.Graphics.DrawString(strTitle, New Font("宋体", 18, FontStyle.Bold), System.Drawing.Brushes.Black, New RectangleF(e.PageSettings.Margins.Left, RowsHeigth, PageWidth, sizeFTitle.Height), drawFormat)
        MainStartHeigth += sizeFTitle.Height
        RowsHeigth += sizeFTitle.Height

        '-----定位第一个Columns的位置-----
        'ColsWidth = e.PageSettings.Margins.Left

        '-----记录日期行高，封右边是要扣除-----
        Dim RowsHeigthDate As Single = 0

        '-----记录是否跳页（笔数到得跳页）-----
        Dim PNoTemp As Boolean = False

        '-----计算笔数，用于计算总页数-----
        Dim TotalTemp As Integer = 0
        Dim IntTemp As Integer = 0   '用在X要-1或-0，判断或累加时是该列或上一列
        Dim TEMPA As Integer
        Dim Jia(0) As String  '记录请假的名称
        Dim JiaSun(0) As Decimal  '记录各请假的累加时数
        Dim Total1 As Decimal = 0   '平日加班
        Dim Total2 As Decimal = 0   '公休加班
        Dim Total3 As Decimal = 0   '国假加班
        Dim Total4 As Decimal = 0   '工作时数
        Dim Total5 As Integer = 0    '正常上班天数，暂用节假日判断
        Dim Total6 As Integer = 0    '实到上班天数，用实到工时判断
        Dim Total7 As Integer = 0    '实到上班时数，实到工时累加
        Dim Total8 As Integer = 0    '加班次数，平日加班+公休加班+国假加班不等于0就加1
        Dim Total9 As Integer = 0    '迟到、迟到累加
        Dim Total10 As Integer = 0   '早退累加
        Dim Total11 As Integer = 0   ' 津贴累加
        Dim Total12 As Integer = 0   '特别奖

        Dim NextPage As Boolean = False

        

            If X = 0 Then IntTemp = 0 Else IntTemp = 1

            '印标头
            If X = 0 Or DGV1.Rows(X).Cells("员工工号").Value <> DGV1.Rows(X - IntTemp).Cells("员工工号").Value Then

                'e.Graphics.DrawString("部门：" & DGV1.Rows(X).Cells("部门名称").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth * 0.4, DGV1.Rows(0).Height), drawFormatC)
                e.Graphics.DrawString("页次：" & pNo, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.8, RowsHeigth, PageWidth * 0.1, DGV1.Rows(0).Height), drawFormatC)

                'e.Graphics.DrawLine(Pens.Black, e.MarginBounds.Left, RowsHeigth, e.MarginBounds.Left, RowsHeigth + DGV1.Rows(0).Height)
                TEMPA = PageWidth * 0.1
                'e.Graphics.DrawLine(Pens.Black, e.MarginBounds.Left + TEMPA, RowsHeigth, e.MarginBounds.Left + TEMPA, RowsHeigth + DGV1.Rows(0).Height)


                RowsHeigth += DGV1.Rows(0).Height
                'e.Graphics.DrawString("员工：" & DGV1.Rows(X).Cells("员工工号").Value & " " & DGV1.Rows(X).Cells("员工姓名").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth * 0.3, DGV1.Rows(0).Height), drawFormatC)
                e.Graphics.DrawString("出勤日期：" & TotalA2, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.8, RowsHeigth, PageWidth * 0.4, DGV1.Rows(0).Height), drawFormatC)

                'e.Graphics.DrawLine(Pens.Black, e.MarginBounds.Left, RowsHeigth, e.MarginBounds.Left, RowsHeigth + DGV1.Rows(0).Height)
                TEMPA = PageWidth * 0.1
                'e.Graphics.DrawLine(Pens.Black, e.MarginBounds.Left + TEMPA, RowsHeigth, e.MarginBounds.Left + TEMPA, RowsHeigth + DGV1.Rows(0).Height)
                RowsHeigth += DGV1.Rows(0).Height * 0.7

                e.Graphics.DrawString("=============================================================================================================================", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth + PageWidth * 0.04, DGV1.Rows(0).Height), drawFormatC)
                RowsHeigth += DGV1.Rows(0).Height * 0.7

                e.Graphics.DrawString("工号", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.03, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
                'e.Graphics.DrawString("星" & vbCrLf & "期", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.06, RowsHeigth, PageWidth * 0.02, DGV1.Rows(0).Height * 1.5), drawFormat)
                'e.Graphics.DrawString("出勤", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.08, RowsHeigth, PageWidth * 0.065, DGV1.Rows(0).Height * 1.5), drawFormatC)
            e.Graphics.DrawString("姓名", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.13, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormatC)
            e.Graphics.DrawString("日期", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.22, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
            e.Graphics.DrawString("星期", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.31, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
            e.Graphics.DrawString("假勤名称", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.37, RowsHeigth, PageWidth * 0.12, DGV1.Rows(0).Height * 1.5), drawFormat)
            e.Graphics.DrawString("第1次", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.51, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
            e.Graphics.DrawString("第2次", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.59, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
            e.Graphics.DrawString("第3次", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.66, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
            e.Graphics.DrawString("第4次", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.73, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormatC)
            e.Graphics.DrawString("第5次", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.8, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
            e.Graphics.DrawString("第6次", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.87, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
                'e.Graphics.DrawString("公休" & vbCrLf & "加班", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.7, RowsHeigth, PageWidth * 0.05, DGV1.Rows(0).Height * 1.5), drawFormat)
                'e.Graphics.DrawString("国假" & vbCrLf & "加班", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.75, RowsHeigth, PageWidth * 0.05, DGV1.Rows(0).Height * 1.5), drawFormat)
                'e.Graphics.DrawString("工作" & vbCrLf & "时数", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.8, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
                'e.Graphics.DrawString("请假", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.92, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
                'e.Graphics.DrawString("时间", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.92, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
                RowsHeigth += DGV1.Rows(0).Height * 1.1

                e.Graphics.DrawString("=============================================================================================================================", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth + PageWidth * 0.04, DGV1.Rows(0).Height), drawFormatC)
            RowsHeigth += DGV1.Rows(0).Height * 0.5
            RowsHeigth += DGV1.Rows(0).Height * 0.5
        End If

        '-----内容-----
        '-----X笔数小于DataGridView的笔数 AND 总长度小于纸张长度-----
        While X < DGV1.Rows.Count And RowsHeigth < PageHeight

            e.Graphics.DrawString(DGV1.Rows(X).Cells("员工工号").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth * 0.12, DGV1.Rows(0).Height), drawFormat)
            e.Graphics.DrawString(DGV1.Rows(X).Cells("员工姓名").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.09, RowsHeigth, PageWidth * 0.12, DGV1.Rows(0).Height), drawFormat)
            e.Graphics.DrawString(DGV1.Rows(X).Cells("日期").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.2, RowsHeigth, PageWidth * 0.12, DGV1.Rows(0).Height), drawFormatC)
            e.Graphics.DrawString(DGV1.Rows(X).Cells("星期").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.33, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height), drawFormatC)
            e.Graphics.DrawString(DGV1.Rows(X).Cells("假勤名称").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.39, RowsHeigth, PageWidth * 0.18, DGV1.Rows(0).Height), drawFormatC)
            e.Graphics.DrawString(Trim(DGV1.Rows(X).Cells("第1次").Value), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.51, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height), drawFormat)
            e.Graphics.DrawString(Trim(DGV1.Rows(X).Cells("第2次").Value), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.59, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height), drawFormat)
            e.Graphics.DrawString(Trim(DGV1.Rows(X).Cells("第3次").Value), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.66, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height), drawFormat)
            e.Graphics.DrawString(Trim(DGV1.Rows(X).Cells("第4次").Value), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.73, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height), drawFormat)
            e.Graphics.DrawString(Trim(DGV1.Rows(X).Cells("第5次").Value), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.8, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height), drawFormat)
            e.Graphics.DrawString(Trim(DGV1.Rows(X).Cells("第6次").Value), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.87, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height), drawFormat)
            'e.Graphics.DrawString(Format(DGV1.Rows(X).Cells("实到工时").Value, "#,##0.0;-#,##0.0; "), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.6, RowsHeigth, PageWidth * 0.05, DGV1.Rows(0).Height), drawFormatB)
            'e.Graphics.DrawString(Format(DGV1.Rows(X).Cells("平日加班").Value, "#,##0.0;-#,##0.0; "), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.65, RowsHeigth, PageWidth * 0.05, DGV1.Rows(0).Height), drawFormatB)
            'e.Graphics.DrawString(Format(DGV1.Rows(X).Cells("公休加班").Value, "#,##0.0;-#,##0.0; "), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.7, RowsHeigth, PageWidth * 0.05, DGV1.Rows(0).Height), drawFormatB)
            'e.Graphics.DrawString(Format(DGV1.Rows(X).Cells("国假加班").Value, "#,##0.0;-#,##0.0; "), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.75, RowsHeigth, PageWidth * 0.05, DGV1.Rows(0).Height), drawFormatB)
            'e.Graphics.DrawString(Format(DGV1.Rows(X).Cells("工作时数").Value, "#,##0.00;-#,##0.00; "), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.8, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height), drawFormatB)
            'e.Graphics.DrawString(DGV1.Rows(X).Cells("请假").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.92, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height), drawFormatC)

            'If InStr(DGV1.Rows(X).Cells("请假").Value, "迟到") > 0 Or InStr(DGV1.Rows(X).Cells("请假").Value, "早退") > 0 Then
            '    e.Graphics.DrawString(Format(DGV1.Rows(X).Cells("迟到").Value, "#,##0;-#,##0; "), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.92, RowsHeigth, PageWidth * 0.05, DGV1.Rows(0).Height), drawFormatB)
            'Else
            '    e.Graphics.DrawString(Format(DGV1.Rows(X).Cells("时间").Value, "#,##0.0;-#,##0.0; "), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.92, RowsHeigth, PageWidth * 0.05, DGV1.Rows(0).Height), drawFormatB)
            'End If

            RowsHeigth += DGV1.Rows(0).Height * 0.9
            e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth + PageWidth * 0.04, DGV1.Rows(0).Height), drawFormatC)
            RowsHeigth += DGV1.Rows(0).Height * 0.9

            'Total11 += Val(DGV1.Rows(X).Cells("津贴").Value)       '津贴
            'Total1 += Val(DGV1.Rows(X).Cells("平日加班").Value)    '平日加班
            'Total2 += Val(DGV1.Rows(X).Cells("公休加班").Value)    '公休加班
            'Total3 += Val(DGV1.Rows(X).Cells("国假加班").Value)    '国假加班
            'Total4 += Val(DGV1.Rows(X).Cells("工作时数").Value)    '工作时数
            'If DGV1.Rows(X).Cells("节假日").Value = "工作日" Then Total5 += 1
            'If Val(DGV1.Rows(X).Cells("实到工时").Value) <> 0 Then Total6 += 1
            'Total7 += Val(DGV1.Rows(X).Cells("实到工时").Value)
            'If Val(DGV1.Rows(X).Cells("平日加班").Value) <> 0 Or Val(DGV1.Rows(X).Cells("公休加班").Value) <> 0 Or Val(DGV1.Rows(X).Cells("国假加班").Value) <> 0 Then Total8 += 1
            'If DGV1.Rows(X).Cells("请假").Value = "迟到" Or DGV1.Rows(X).Cells("请假").Value = "早退" Then Total9 += Val(DGV1.Rows(X).Cells("迟到").Value)

            'If DGV1.Rows(X).Cells("请假").Value <> "" Then

            '    If Array.IndexOf(Jia, DGV1.Rows(X).Cells("请假").Value) >= 0 Then
            '        JiaSun(Array.IndexOf(Jia, DGV1.Rows(X).Cells("请假").Value)) += Val(DGV1.Rows(X).Cells("时间").Value)
            '    Else
            '        ReDim Preserve Jia(Jia.Count)
            '        ReDim Preserve JiaSun(JiaSun.Count)
            '        Jia(Jia.Count - 1) = DGV1.Rows(X).Cells("请假").Value
            '        JiaSun(JiaSun.Count - 1) += Val(DGV1.Rows(X).Cells("时间").Value)
            '    End If

            'End If

            'If DGV1.Rows(X).Cells("特别奖").Value <> "" Then Total12 += 1

            'e.Graphics.DrawString(DGV1.Rows(X).Cells("TH013").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.03, RowsHeigth, PageWidth * 0.1, DGV1.Rows(0).Height), drawFormatG)

            X += 1

            NextPage = False

            If X = DGV1.Rows.Count Then
                NextPage = True
            Else
                If X <= DGV1.Rows.Count - 1 Then
                    If DGV1.Rows(X).Cells("员工工号").Value <> DGV1.Rows(X - IntTemp).Cells("员工工号").Value Then
                        'NextPage = True
                    End If
                End If
            End If

            'X在加1后（下一列），跟上列的员工编号不一样的话，就跳页
            If NextPage = True Then

                'RowsHeigth += DGV1.Rows(0).Height * 0.3
                'e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth + PageWidth * 0.04, DGV1.Rows(0).Height), drawFormatC)
                'RowsHeigth += DGV1.Rows(0).Height * 0.7

                'e.Graphics.DrawString("小计：", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.45, RowsHeigth, PageWidth * 0.1, DGV1.Rows(0).Height), drawFormat)
                'e.Graphics.DrawString(Format(Total11, "#,##0.0;-#,##0.0; "), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.565, RowsHeigth, PageWidth * 0.05, DGV1.Rows(0).Height), drawFormatB)
                'e.Graphics.DrawString(Format(Total1, "#,##0.0;-#,##0.0; "), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.65, RowsHeigth, PageWidth * 0.05, DGV1.Rows(0).Height), drawFormatB)
                'e.Graphics.DrawString(Format(Total2, "#,##0.0;-#,##0.0; "), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.7, RowsHeigth, PageWidth * 0.05, DGV1.Rows(0).Height), drawFormatB)
                'e.Graphics.DrawString(Format(Total3, "#,##0.0;-#,##0.0; "), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.75, RowsHeigth, PageWidth * 0.05, DGV1.Rows(0).Height), drawFormatB)
                'e.Graphics.DrawString(Format(Total4, "#,##0.0;-#,##0.0; "), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.8, RowsHeigth, PageWidth * 0.07, DGV1.Rows(0).Height), drawFormatB)
                'RowsHeigth += DGV1.Rows(0).Height * 0.7

                'e.Graphics.DrawString("=============================================================================================================================", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth + PageWidth * 0.04, DGV1.Rows(0).Height), drawFormatC)
                'RowsHeigth += DGV1.Rows(0).Height * 0.7

                '记录印各种假的开始位置
                'Dim RowsHeigthTemp As Single = RowsHeigth

                'e.Graphics.DrawString("应到天数：" & Total5, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth * 0.2, DGV1.Rows(0).Height), drawFormatC)
                'e.Graphics.DrawString("加班次数：" & Total8, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.3, RowsHeigth, PageWidth * 0.3, DGV1.Rows(0).Height), drawFormatC)
                'RowsHeigth += DGV1.Rows(0).Height * 0.9

                'e.Graphics.DrawString("应到时数：" & Total5 * 8, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth * 0.2, DGV1.Rows(0).Height), drawFormatC)
                'e.Graphics.DrawString("平日加班：" & Total1, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.3, RowsHeigth, PageWidth * 0.3, DGV1.Rows(0).Height), drawFormatC)
                'RowsHeigth += DGV1.Rows(0).Height * 0.9

                'e.Graphics.DrawString("实到天数：" & Total6, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth * 0.2, DGV1.Rows(0).Height), drawFormatC)
                'e.Graphics.DrawString("公休加班：" & Total2, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.3, RowsHeigth, PageWidth * 0.3, DGV1.Rows(0).Height), drawFormatC)
                'RowsHeigth += DGV1.Rows(0).Height * 0.9

                'e.Graphics.DrawString("实到时数：" & Total7, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth * 0.2, DGV1.Rows(0).Height), drawFormatC)
                'e.Graphics.DrawString("国假加班：" & Total3, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.3, RowsHeigth, PageWidth * 0.3, DGV1.Rows(0).Height), drawFormatC)
                'RowsHeigth += DGV1.Rows(0).Height * 0.9

                'e.Graphics.DrawString("特别奖：" & Total12, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth * 0.2, DGV1.Rows(0).Height), drawFormatC)
                'e.Graphics.DrawString("加班时数：" & Total1 + Total2 + Total3, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.3, RowsHeigth, PageWidth * 0.3, DGV1.Rows(0).Height), drawFormatC)

                'If Jia.Count > 0 Then
                '    For i As Integer = 1 To Jia.Count - 1
                '        e.Graphics.DrawString(Jia(i) & "：" & JiaSun(i), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.7, RowsHeigthTemp, PageWidth * 0.3, DGV1.Rows(0).Height), drawFormatC)
                '        RowsHeigthTemp += DGV1.Rows(0).Height * 0.9
                '    Next
                'End If

                RowsHeigth += PageHeight
            End If


        End While

        '-----------------


        'RowsHeigth += PageHeight

        '-----页次加1-----
        pNo += 1

        '-----判断页数要不要归零-----
        If PNoTemp = True Then
            pNo = 1
            PNoTemp = False
            'TotalA1 = 0
            'TotalA2 = 0
            'TotalA3 = 0
            'TotalB1 = 0
            'TotalB2 = 0
            'TotalB3 = 0
            pNoTatalTemp = 0
            firthXTemp = X
        End If

        If X < DGV1.Rows.Count Then  'And RowsHeigth > PageHeight
            PNoTemp = False
            e.HasMorePages = True
            'pNo += 1 '页码加1
            '-----定位第一个Columns的位置-----
            ColsWidth = e.PageSettings.Margins.Left
            RowsHeigth = e.PageSettings.Margins.Top + MainStartHeigth
            'firthXTemp = X

        Else
            e.HasMorePages = False
            'TotalA1 = 0
            'TotalA2 = 0
            'TotalA3 = 0
            'TotalB1 = 0
            'TotalB2 = 0
            'TotalB3 = 0
        End If

        '结尾标志
        If X >= DGV1.Rows.Count Then   'And e.HasMorePages.Equals(False) Then
            X = 0
            Y = 0
            pNo = 1
            'TotalA1 = 0
            'TotalA2 = 0
            'TotalA3 = 0
            'TotalB1 = 0
            'TotalB2 = 0
            'TotalB3 = 0
            Exit Sub
        End If

    End Sub

    '数据源,输入DataGridView1
    Public Property MyDataGridView1() As DataGridView
        Set(ByVal value As DataGridView)
            DGV1 = value
        End Set
        Get
            Return DGV1
        End Get
    End Property


    '公司名称
    Public Property Company() As String
        Set(ByVal value As String)
            strCompany = value
        End Set
        Get
            Return strCompany
        End Get
    End Property

    '报表标题
    Public Property Title() As String
        Set(ByVal value As String)
            strTitle = value
        End Set
        Get
            Return strTitle
        End Get
    End Property

    '页面设置
    Public Sub PageSetup()
        Me.PageSetupDialog1.Document = Me.PrintDocument1
        Me.PageSetupDialog1.PageSettings.Margins.Top = 100
        Me.PageSetupDialog1.PageSettings.Margins.Bottom = 100
        Me.PageSetupDialog1.PageSettings.Margins.Left = 70
        Me.PageSetupDialog1.PageSettings.Margins.Right = 130
        'Me.PageSetupDialog1.ShowDialog()
        '-----选择打印机画面-----
        'Me.PageDialog1.ShowDialog()

    End Sub

    '打印预览
    Public Sub PrintPreview()

        'If Microsoft.VisualBasic.Left(Title, 1) = "A" Then
        '-----纸张直向-----
        'PrintDocument1.DefaultPageSettings.Landscape = False
        'Else
        '-----纸张横向-----
        'PrintDocument1.DefaultPageSettings.Landscape = True
        'End If

        '-----选择印表机-----
        If Me.PageDialog1.ShowDialog() = DialogResult.Cancel Then
            Exit Sub
        End If

        '-----选择纸张-----
        If PageSetupDialog1.ShowDialog() = DialogResult.Cancel Then
            Exit Sub
        End If

        Me.PrintPreviewDialog1.Document = Me.PrintDocument1
        '-----有用PageSettings了，所以不用抓DefaultPageSettings-----
        Me.PrintPreviewDialog1.Document.DefaultPageSettings = Me.PageSetupDialog1.PageSettings
        Me.PrintPreviewDialog1.PrintPreviewControl.Zoom = 1
        '----印表机名称-----
        PrintDocument1.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName = PageDialog1.PrinterSettings.PrinterName  'PrintDocument1.PrinterSettings.PrinterName

        Me.PrintPreviewDialog1.ShowDialog()

        '----获取最后一页的页码-----
        'Me.PrintPreviewDialog1.Document.PrinterSettings.ToPage

    End Sub

    '设置字体
    Public Sub PrintPreviewFont()

        Me.FontDialog1.ShowDialog()
        PrintFont = Me.FontDialog1.Font

    End Sub

    '打印
    Public Sub Print()
        'Me.PrintDocument1.Print()
        Me.PageDialog1.ShowDialog()
        'Me.PageDialog1.ShowDialog()

        Dim re As DialogResult = Me.PageSetupDialog1.ShowDialog()

        PrintDocument1.PrinterSettings.Collate = True
        If re = Windows.Forms.DialogResult.OK Then
            'AddHandler PrintDocument1.PrintPage, AddressOf PageSetupDialog1_PrintPage
            PrintDocument1.PrinterSettings.DefaultPageSettings.PrinterSettings.PrinterName = PageDialog1.PrinterSettings.PrinterName  'PrintDocument1.PrinterSettings.PrinterName
            PrintDocument1.Print()
        End If
    End Sub

End Class