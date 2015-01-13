Public Class Main_Form

    Public DefFontTemp As String                     '记录字体大小
    Public HRIPTemp As String = "192.168.2.223"      '记录HR主机的IP
    Public HRCatalogTemp As String = "HRMDB"         '记录数据库名称
    Public StopBoolean As Boolean = False            'ESC中止
    Dim ClosedTemp As String                         '结束时要不要出现询问视窗
    '----保存视图用-----
    Public ColumnSet1(50, 100) As String     '"第二行"    ColumnSet1(y, x)   排列顺序
    Public ColumnSet2(50, 100) As String     '"第三行"    ColumnSet2(y, x)   栏位宽度
    Public ColumnSet3(50, 100) As String     '"第四行"    ColumnSet3(y, x)   栏位名称
    Public FormName(50) As String            '"第一行"    FormName(y)        表单名称
    'Public LastColumn As Integer             '储存的最后笔数
    'Public ColumnNo As Integer               '取得表单所在的位置

    '记录各表单权限用 50是流水号（等于Cmd的Name）  0表单编号  1表单名称 2代表查询 3代表新增 4代表修改 5代表删除 6代表打印 7代表保存视图 
    '全部选项
    '主画面Cmd的最大数
    Public FormTotal As Integer = 30
    '0 = CmdName 1 = Cmd名称
    Public ALLFormCmd(FormTotal, 1) As String
    '每一个选项里面的按钮
    '各画面里面Cmd的最大数
    Public CmdTotal As Integer = 20
    '0 = CmdName 1 = Cmd名称
    Public ALLCmdName(FormTotal, CmdTotal, 1) As String

    '权限表
    Public UserPermit As New DataGridView
    '记录主画面的Cmd + 各画面的Cmd，方便定位UserPermit表
    Public AllCmd() As String
    '记录主画面的Cmd ，方便定位UserPermit表
    Public FormCmd() As String

    Private Sub Main_Form_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        On Error Resume Next

        Dim UserFileTemp As String = Microsoft.VisualBasic.Environ("TMP") & "\VBTEMP"

        If My.Computer.FileSystem.DirectoryExists(UserFileTemp) Then
            Microsoft.VisualBasic.Kill(UserFileTemp & "\*")
            My.Computer.FileSystem.DeleteDirectory(UserFileTemp, Microsoft.VisualBasic.FileIO.DeleteDirectoryOption.DeleteAllContents)
        End If

    End Sub

    Private Sub Main_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        If ClosedTemp <> "A" Then
            If MessageBox.Show("是否离开程式", "离开程式", MessageBoxButtons.YesNo) = System.Windows.Forms.DialogResult.Yes Then
                e.Cancel = False
            Else
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub Main_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Class_SQL.conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=" & HRCatalogTemp & ";Server=" & HRIPTemp

        For i As Integer = 0 To Controls.Count - 1
            If Microsoft.VisualBasic.Right(Controls.Item(i).Name, 3) = "Cmd" Then
                Me.Controls.Item(i).Enabled = False
            End If
        Next

        Exit_Cmd.Enabled = True

        For i As Integer = 0 To FormTotal
            ALLFormCmd(i, 0) = ""
            ALLFormCmd(i, 1) = ""
            For j As Integer = 0 To CmdTotal
                ALLCmdName(i, j, 0) = ""
                ALLCmdName(i, j, 1) = ""
            Next
        Next

        '载入所有按钮资料
        LoadFormName()

        DefFontTemp = "9"

        '禁止添加行
        UserPermit.AllowUserToAddRows = False
        '禁止删除行
        UserPermit.AllowUserToDeleteRows = False
        '可以调整行大小
        UserPermit.AllowUserToResizeColumns = True
        '可以调整列大小
        UserPermit.AllowUserToResizeRows = False

        UserPermit.Columns.Add("XH_No", "序")
        UserPermit.Columns.Add("FormCmd", "按钮")
        UserPermit.Columns.Add("FormCmdName", "按钮名称")
        UserPermit.Columns.Add("FormCmdOpen", "操作")
        UserPermit.Columns.Add("AllCmd", "按钮")
        UserPermit.Columns.Add("AllCmdName", "按钮名称")
        UserPermit.Columns.Add("AllCmdOpen", "操作")
        UserPermit.Columns.Add("SZ", "苏州")
        UserPermit.Columns.Add("SZStaffYes", "行政人员")
        UserPermit.Columns.Add("SZStaffNo", "非行政人员")
        UserPermit.Columns.Add("SZSalary", "薪资")
        UserPermit.Columns.Add("SH", "上海")
        UserPermit.Columns.Add("SHStaffYes", "行政人员")
        UserPermit.Columns.Add("SHStaffNo", "非行政人员")
        UserPermit.Columns.Add("SHSalary", "薪资")

        Dim X As Integer = 0

        '先将所有按钮载入到PWDataView
        For i As Integer = 0 To FormTotal
            If ALLCmdName(i, 0, 0) = "" Then Exit For
            For j As Integer = 0 To CmdTotal
                If ALLCmdName(i, j, 0) = "" Then Exit For
                UserPermit.Rows.Add()

                UserPermit.Rows(X).Cells("XH_No").Value = X '序
                UserPermit.Rows(X).Cells("FormCmd").Value = ALLFormCmd(i, 0) '按钮
                UserPermit.Rows(X).Cells("FormCmdName").Value = ALLFormCmd(i, 1) '按钮名称
                UserPermit.Rows(X).Cells("FormCmdOpen").Value = "N" '操作
                UserPermit.Rows(X).Cells("AllCmd").Value = ALLCmdName(i, j, 0) '按钮
                UserPermit.Rows(X).Cells("AllCmdName").Value = ALLCmdName(i, j, 1) '按钮名称
                UserPermit.Rows(X).Cells("AllCmdOpen").Value = "N" '操作
                UserPermit.Rows(X).Cells("SZ").Value = "N" '行政人员
                UserPermit.Rows(X).Cells("SZStaffYes").Value = "N" '行政人员
                UserPermit.Rows(X).Cells("SZStaffNo").Value = "N" '非行政人员
                UserPermit.Rows(X).Cells("SZSalary").Value = "N" '薪资
                UserPermit.Rows(X).Cells("SH").Value = "N" '行政人员
                UserPermit.Rows(X).Cells("SHStaffYes").Value = "N" '行政人员
                UserPermit.Rows(X).Cells("SHStaffNo").Value = "N" '非行政人员
                UserPermit.Rows(X).Cells("SHSalary").Value = "N" '薪资

                X += 1
            Next
        Next

        ReDim AllCmd(UserPermit.RowCount - 1)
        ReDim FormCmd(UserPermit.RowCount - 1)

        For i As Integer = 0 To UserPermit.RowCount - 1
            AllCmd(i) = RTrim(UserPermit.Rows(i).Cells("FormCmd").Value) & RTrim(UserPermit.Rows(i).Cells("AllCmd").Value)
            FormCmd(i) = RTrim(UserPermit.Rows(i).Cells("FormCmd").Value)
        Next

        LogIN_Form.ShowDialog()

        If LogIN_Form.DialogResult = Windows.Forms.DialogResult.OK Then
            ClosedTemp = "B"
        Else
            ClosedTemp = "A"
            LogIN_Form.Dispose()
            Me.Close()
            Exit Sub
        End If


        For i As Integer = 0 To UserPermit.RowCount - 1
            If RTrim(UserPermit.Rows(i).Cells("FormCmdOpen").Value) = "Y" Then
                Controls.Item(RTrim(UserPermit.Rows(i).Cells("FormCmd").Value)).Enabled = True
            End If
        Next

        Font9_Radio.Checked = True

        If My.Computer.Network.IsAvailable Then
            If My.Computer.Network.Ping("192.168.2.223", 50) Then

            Else
                MsgBox("找不到苏州主机，请重新执行程序")
                Me.Close()
                Exit Sub
            End If
        Else
            MsgBox("未连接至网络，无法连线", , "网络不通")
            Me.Close()
            Exit Sub
        End If

        '禁止添加行
        DataGridView1.AllowUserToAddRows = False
        '禁止删除行
        DataGridView1.AllowUserToDeleteRows = False
        '可以调整行大小
        DataGridView1.AllowUserToResizeColumns = True
        '可以调整列大小
        DataGridView1.AllowUserToResizeRows = False

        For i As Integer = 0 To UserPermit.ColumnCount - 1
            DataGridView1.Columns.Add(UserPermit.Columns(i).Name, UserPermit.Columns(i).HeaderText)
        Next

        For i As Integer = 0 To UserPermit.RowCount - 1
            DataGridView1.Rows.Add()
            For j As Integer = 0 To UserPermit.ColumnCount - 1
                DataGridView1.Rows(i).Cells(j).Value = UserPermit.Rows(i).Cells(j).Value
            Next
        Next

        DataGridViewSet.AutoMode(Me.DataGridView1)

    End Sub

    Private Sub Font9_Radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Font9_Radio.CheckedChanged
        If Font9_Radio.Checked = True Then DefFontTemp = "9"
    End Sub

    Private Sub Font10_Radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Font10_Radio.CheckedChanged
        If Font10_Radio.Checked = True Then DefFontTemp = "10"
    End Sub

    Private Sub Font11_Radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Font11_Radio.CheckedChanged
        If Font11_Radio.Checked = True Then DefFontTemp = "11"
    End Sub

    Private Sub Font12_Radio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Font12_Radio.CheckedChanged
        If Font12_Radio.Checked = True Then DefFontTemp = "12"
    End Sub


    '权限设定
    Private Sub PW_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PW_Cmd.Click
        PW_Form.Show()
        PW_Form.Focus()
    End Sub

    '离开
    Private Sub Exit_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_Cmd.Click
        Me.Close()
    End Sub

    '卡钟软件用
    Private Sub KaoZhong_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KaoZhong_Cmd.Click
        KaoZhong_Form.Show()
        KaoZhong_Form.Focus()
    End Sub

    '人员信息
    Private Sub RenYuan_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenYuan_Cmd.Click
        RenYuan_Form.Show()
        RenYuan_Form.Focus()
    End Sub

    '人员排班
    Private Sub RenYuanPaiBan_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RenYuanPaiBan_Cmd.Click
        RenYuanPaiBan_Form.Show()
        RenYuanPaiBan_Form.Focus()
    End Sub

    '排班
    Private Sub PaiBan_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaiBan_Cmd.Click
        PaiBan_Form.Show()
        PaiBan_Form.Focus()
    End Sub

    '点名
    Private Sub RollCall_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RollCall_Cmd.Click
        RollCall_Form.Show()
        RollCall_Form.Focus()
    End Sub

    '点名-出勤统计表
    Private Sub RollCallReport_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RollCallReport_Cmd.Click
        RollCallReport_Form.Show()
        RollCallReport_Form.Focus()
    End Sub

    '数据采集
    Private Sub ShJuCaiJi_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ShJuCaiJi_Cmd.Click
        ShJuCaiJi_Form.Show()
        ShJuCaiJi_Form.Focus()
    End Sub

    '各按钮名称
    Private Sub LoadFormName()

        Dim X As Integer = 0
        Dim Y As Integer = 0


        ALLFormCmd(X, 0) = "PW_Cmd"
        ALLFormCmd(X, 1) = "权限设定"
        ALLCmdName(X, Y, 0) = "Load_Cmd"
        ALLCmdName(X, Y, 1) = "查询"
        Y += 1
        ALLCmdName(X, Y, 0) = "Modify_Cmd"
        ALLCmdName(X, Y, 1) = "修改"
        Y += 1
        ALLCmdName(X, Y, 0) = "New_Cmd"
        ALLCmdName(X, Y, 1) = "新增"
        Y += 1
        ALLCmdName(X, Y, 0) = "SAVE_Cmd"
        ALLCmdName(X, Y, 1) = "保存"
        Y += 1
        ALLCmdName(X, Y, 0) = "DEL_Cmd"
        ALLCmdName(X, Y, 1) = "删除"

        X += 1
        Y = 0
        ALLFormCmd(X, 0) = "KaoZhong_Cmd"
        ALLFormCmd(X, 1) = "卡钟软件用"
        ALLCmdName(X, Y, 0) = "Load_Cmd"
        ALLCmdName(X, Y, 1) = "查询员工"
        Y += 1
        ALLCmdName(X, Y, 0) = "OutExecl_Cmd"
        ALLCmdName(X, Y, 1) = "汇出EXCEL"

        X += 1
        Y = 0
        ALLFormCmd(X, 0) = "RenYuan_Cmd"
        ALLFormCmd(X, 1) = "人员信息"
        ALLCmdName(X, Y, 0) = "Load_Cmd"
        ALLCmdName(X, Y, 1) = "查询员工"
        Y += 1
        ALLCmdName(X, Y, 0) = "OutExecl_Cmd"
        ALLCmdName(X, Y, 1) = "汇出EXCEL"

        X += 1
        Y = 0
        ALLFormCmd(X, 0) = "PaiBan_Cmd"
        ALLFormCmd(X, 1) = "排班"
        ALLCmdName(X, Y, 0) = "Load_Cmd"
        ALLCmdName(X, Y, 1) = "查询员工"
       
        X += 1
        Y = 0
        ALLFormCmd(X, 0) = "RollCall_Cmd"
        ALLFormCmd(X, 1) = "点名"
        ALLCmdName(X, Y, 0) = "Load_Cmd"
        ALLCmdName(X, Y, 1) = "查询员工"
        Y += 1
        ALLCmdName(X, Y, 0) = "OutExecl_Cmd"
        ALLCmdName(X, Y, 1) = "汇出EXCEL"

        X += 1
        Y = 0
        ALLFormCmd(X, 0) = "RollCallReport_Cmd"
        ALLFormCmd(X, 1) = "个人出勤统计表"
        ALLCmdName(X, Y, 0) = "Load_Cmd"
        ALLCmdName(X, Y, 1) = "查询员工"
        Y += 1
        ALLCmdName(X, Y, 0) = "Print_Cmd"
        ALLCmdName(X, Y, 1) = "打印"
        Y += 1
        ALLCmdName(X, Y, 0) = "OutExecl_Cmd"
        ALLCmdName(X, Y, 1) = "汇出EXCEL"

        X += 1
        Y = 0
        ALLFormCmd(X, 0) = "RenYuanPaiBan_Cmd"
        ALLFormCmd(X, 1) = "人员排班挂载"
        ALLCmdName(X, Y, 0) = "Load_Cmd"
        ALLCmdName(X, Y, 1) = "查询员工"

        X += 1
        Y = 0
        ALLFormCmd(X, 0) = "ShJuCaiJi_Cmd"
        ALLFormCmd(X, 1) = "数据采集"
        ALLCmdName(X, Y, 0) = "Load_Cmd"
        ALLCmdName(X, Y, 1) = "查询员工"
        Y += 1
        ALLCmdName(X, Y, 0) = "UpLoadFile_Cmd"
        ALLCmdName(X, Y, 1) = "上传刷卡记录"

        X += 1
        Y = 0
        ALLFormCmd(X, 0) = "NonRollCallReport_cmd"
        ALLFormCmd(X, 1) = "无出勤统计表"
        ALLCmdName(X, Y, 0) = "Load_Cmd"
        ALLCmdName(X, Y, 1) = "查询员工"
        Y += 1
        ALLCmdName(X, Y, 0) = "Print_Cmd"
        ALLCmdName(X, Y, 1) = "打印"
        Y += 1
        ALLCmdName(X, Y, 0) = "OutExecl_Cmd"
        ALLCmdName(X, Y, 1) = "汇出EXCEL"

        X += 1
        Y = 0
        ALLFormCmd(X, 0) = "AllRollCall_cmd"
        ALLFormCmd(X, 1) = "出勤日报表"
        ALLCmdName(X, Y, 0) = "Load_Cmd"
        ALLCmdName(X, Y, 1) = "查询员工"
        Y += 1
        ALLCmdName(X, Y, 0) = "Print_Cmd"
        ALLCmdName(X, Y, 1) = "打印"
        Y += 1
        ALLCmdName(X, Y, 0) = "OutExecl_Cmd"
        ALLCmdName(X, Y, 1) = "汇出EXCEL"

    End Sub

    Private Sub NonRollCallReport_cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NonRollCallReport_cmd.Click
        NONRollCallReport_Form.Show()
        NONRollCallReport_Form.Focus()
    End Sub

   
    Private Sub AllRollCall_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllRollCall_Cmd.Click
        AllRollCall_Form.Show()
        AllRollCall_Form.Focus()
    End Sub
End Class
