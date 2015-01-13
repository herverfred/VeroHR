Public Class AllRollCall_print

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
    Public rptime As DateTime
    Public rpendtime As DateTime

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

        Dim NextPage As Boolean = False

        ''-----内容-----
        ''-----X笔数小于DataGridView的笔数 AND 总长度小于纸张长度-----
        'While X < DGV1.Rows.Count And RowsHeigth < PageHeight

        If X = 0 Then IntTemp = 0 Else IntTemp = 1

        '印标头
        e.Graphics.DrawString("页次：" & pNo, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.9, RowsHeigth, PageWidth * 0.1, DGV1.Rows(0).Height), drawFormatC)
        e.Graphics.DrawString("出勤日期：" & Format(rptime, "yyyy/MM/dd"), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth * 0.4, DGV1.Rows(0).Height), drawFormatC)

        TEMPA = PageWidth * 0.1

        RowsHeigth += DGV1.Rows(0).Height
        TEMPA = PageWidth * 0.1

        e.Graphics.DrawString("=============================================================================================================================", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth + PageWidth * 0.04, DGV1.Rows(0).Height), drawFormatC)
        RowsHeigth += DGV1.Rows(0).Height * 0.7

        e.Graphics.DrawString("部门", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth * 0.1, DGV1.Rows(0).Height * 1.5), drawFormat)
        e.Graphics.DrawString("工号", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.115, RowsHeigth, PageWidth * 0.065, DGV1.Rows(0).Height * 1.5), drawFormatC)
        e.Graphics.DrawString("姓名", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.185, RowsHeigth, PageWidth * 0.065, DGV1.Rows(0).Height * 1.5), drawFormatC)
        e.Graphics.DrawString("节假日", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.235, RowsHeigth, PageWidth * 0.12, DGV1.Rows(0).Height * 1.5), drawFormat)
        e.Graphics.DrawString("工作时数", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.32, RowsHeigth, PageWidth * 0.12, DGV1.Rows(0).Height * 1.5), drawFormat)
        e.Graphics.DrawString("请假", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.46, RowsHeigth, PageWidth * 0.05, DGV1.Rows(0).Height * 1.5), drawFormat)
        e.Graphics.DrawString("第1次", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.6, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
        e.Graphics.DrawString("第2次", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.67, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
        e.Graphics.DrawString("第3次", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.74, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
        e.Graphics.DrawString("第4次", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.81, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
        e.Graphics.DrawString("第5次", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.88, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
        e.Graphics.DrawString("第6次", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.95, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height * 1.5), drawFormat)
        
        RowsHeigth += DGV1.Rows(0).Height * 1.1

        e.Graphics.DrawString("-----------------------------------------------------------------------------------------------------------------------------", PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth + PageWidth * 0.04, DGV1.Rows(0).Height), drawFormatC)
        RowsHeigth += DGV1.Rows(0).Height * 0.5

        '-----内容-----
        '-----X笔数小于DataGridView的笔数 AND 总长度小于纸张长度-----
        While rptime <= rpendtime And RowsHeigth < PageHeight
            While X < DGV1.Rows.Count And RowsHeigth < PageHeight

                If rptime = CDate(DGV1.Rows(X).Cells("日期").Value) Then

                    e.Graphics.DrawString(DGV1.Rows(X).Cells("部门名称").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left, RowsHeigth, PageWidth * 0.1, DGV1.Rows(0).Height), drawFormat)
                    e.Graphics.DrawString(DGV1.Rows(X).Cells("员工工号").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.105, RowsHeigth, PageWidth * 0.065, DGV1.Rows(0).Height), drawFormatC)
                    e.Graphics.DrawString(DGV1.Rows(X).Cells("员工姓名").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.185, RowsHeigth, PageWidth * 0.065, DGV1.Rows(0).Height), drawFormatC)
                    e.Graphics.DrawString(DGV1.Rows(X).Cells("节假日").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.235, RowsHeigth, PageWidth * 0.125, DGV1.Rows(0).Height), drawFormat)
                    e.Graphics.DrawString(Format(DGV1.Rows(X).Cells("工作时数").Value, "#,##0.00;-#,##0.00; "), PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.35, RowsHeigth, PageWidth * 0.06, DGV1.Rows(0).Height), drawFormatB)
                    e.Graphics.DrawString(DGV1.Rows(X).Cells("请假").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.44, RowsHeigth, PageWidth * 0.16, DGV1.Rows(0).Height), drawFormatC)
                    e.Graphics.DrawString(DGV1.Rows(X).Cells("第1次").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.59, RowsHeigth, PageWidth * 0.065, DGV1.Rows(0).Height), drawFormat)
                    e.Graphics.DrawString(DGV1.Rows(X).Cells("第2次").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.66, RowsHeigth, PageWidth * 0.065, DGV1.Rows(0).Height), drawFormat)
                    e.Graphics.DrawString(DGV1.Rows(X).Cells("第3次").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.73, RowsHeigth, PageWidth * 0.065, DGV1.Rows(0).Height), drawFormat)
                    e.Graphics.DrawString(DGV1.Rows(X).Cells("第4次").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.8, RowsHeigth, PageWidth * 0.065, DGV1.Rows(0).Height), drawFormat)
                    e.Graphics.DrawString(DGV1.Rows(X).Cells("第5次").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.87, RowsHeigth, PageWidth * 0.065, DGV1.Rows(0).Height), drawFormatC)
                    e.Graphics.DrawString(DGV1.Rows(X).Cells("第6次").Value, PrintFont, System.Drawing.Brushes.Black, New RectangleF(e.MarginBounds.Left + PageWidth * 0.94, RowsHeigth, PageWidth * 0.065, DGV1.Rows(0).Height), drawFormatC)
                    RowsHeigth += DGV1.Rows(0).Height * 0.9
                End If

                X += 1

                NextPage = False

                If X = DGV1.Rows.Count Then
                    NextPage = True
                End If

                'X在加1后（下一列），跟上列的员工编号不一样的话，就跳页
                If NextPage = True Then
                    RowsHeigth += PageHeight
                    rptime = rptime.Add(TimeSpan.FromDays(1))
                End If

            End While
        End While

        '-----------------

        'RowsHeigth += PageHeight

        '-----页次加1-----
        pNo += 1

        '-----判断页数要不要归零-----
        If PNoTemp = True Then
            pNo = 1
            PNoTemp = False
            pNoTatalTemp = 0
            firthXTemp = X
        End If

        If rptime <= rpendtime Then
            If RowsHeigth > PageHeight Then  'And RowsHeigth > PageHeight
                If X = DGV1.Rows.Count Then
                    X = 0
                End If
                PNoTemp = False
                e.HasMorePages = True
                'pNo += 1 '页码加1
                '-----定位第一个Columns的位置-----
                ColsWidth = e.PageSettings.Margins.Left
                RowsHeigth = e.PageSettings.Margins.Top + MainStartHeigth
            End If
        Else
            e.HasMorePages = False
        End If

        '结尾标志
        If X >= DGV1.Rows.Count And rptime >= rpendtime Then   'And e.HasMorePages.Equals(False) Then
            X = 0
            Y = 0
            pNo = 1
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



    Private Sub RollCallReport_Print_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

End Class