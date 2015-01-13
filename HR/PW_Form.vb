Public Class PW_Form

    Dim PWDataView As New DataGridView
    Dim PWDataViewTemp As New DataGridView
    Dim PWAllCmdName() As String
    Dim DataGridViewLocation As Integer = -1

    Public AAA, BBB As String
    Public User_No, User_Name, User_Dep, User_Pwd As String
    Public User_NoTemp, User_NameTemp, User_DepTemp, User_PwdTemp As String

    Public FormCmd, FormCmdOpen, AllCmd, AllCmdOpen, SZ, SZStaffYes, SZStaffNo, SZSalary, SH, SHStaffYes, SHStaffNo, SHSalary As String
    Public FormCmdTemp, FormCmdOpenTemp, AllCmdTemp, AllCmdOpenTemp, SZTemp, SZStaffYesTemp, SZStaffNoTemp, SZSalaryTemp, SHTemp, SHStaffYesTemp, SHStaffNoTemp, SHSalaryTemp As String
    Public RunCmd1(3) As String

    '-----1代表新增，2代表修改，3代表无意义-----
    Public ModifySave As String = "3"

    Private Sub PW_Form_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If ModifySave = "3" Then
            e.Cancel = False
        Else
            Select Case MessageBox.Show("是否放弃编辑资料", "离开画面", System.Windows.Forms.MessageBoxButtons.YesNo)
                Case 6
                    e.Cancel = False
                Case 7
                    e.Cancel = True
            End Select
        End If
    End Sub

   
    Private Sub PW_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Cmd.CmdFalse(AForm:=Me)
        Cmd.CmdTrue(AForm:=Me)

        User_No_Text.MaxLength = 20
        User_Name_Text.MaxLength = 10
        User_Dep_Text.MaxLength = 10
        User_Pwd_Text.MaxLength = 15
        DoUser_Pwd_Text.MaxLength = 15

        '禁止添加行
        DataGridView1.AllowUserToAddRows = False
        DataGridView2.AllowUserToAddRows = False
        DataGridView3.AllowUserToAddRows = False
        PWDataView.AllowUserToAddRows = False
        PWDataViewTemp.AllowUserToAddRows = False
        '禁止删除行
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView2.AllowUserToDeleteRows = False
        DataGridView3.AllowUserToDeleteRows = False
        PWDataView.AllowUserToDeleteRows = False
        PWDataViewTemp.AllowUserToDeleteRows = False
        '可以调整行大小
        DataGridView1.AllowUserToResizeColumns = True
        DataGridView2.AllowUserToResizeColumns = True
        DataGridView3.AllowUserToResizeColumns = True
        PWDataView.AllowUserToResizeColumns = True
        PWDataViewTemp.AllowUserToResizeColumns = True
        '可以调整列大小
        DataGridView1.AllowUserToResizeRows = False
        DataGridView2.AllowUserToResizeRows = False
        DataGridView3.AllowUserToResizeRows = False
        PWDataView.AllowUserToResizeRows = False
        PWDataViewTemp.AllowUserToResizeRows = False

        DataGridView1.Columns.Add("XH_No", "序")
        DataGridView1.Columns.Add("FormCmd", "按钮")
        DataGridView1.Columns.Add("FormCmdName", "按钮名称")
        'DataGridView1.Columns.Add("FormCmdOpen", "操作")
        '-----勾选框-----
        Dim dc As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        dc.Name = "FormCmdOpen"
        dc.HeaderText = "操作"
        DataGridView1.Columns.Add(dc)

        DataGridView2.Columns.Add("XH_No", "序")
        DataGridView2.Columns.Add("AllCmd", "按钮")
        DataGridView2.Columns.Add("AllCmdName", "按钮名称")
        'DataGridView2.Columns.Add("AllCmdOpen", "操作")
        dc = New DataGridViewCheckBoxColumn()
        dc.Name = "AllCmdOpen"
        dc.HeaderText = "操作"
        dc.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView1.DefaultCellStyle.Font.FontFamily, "14")
        DataGridView2.Columns.Add(dc)

        'DataGridView2.Columns.Add("SZ", "苏州")
        dc = New DataGridViewCheckBoxColumn()
        dc.Name = "SZ"
        dc.HeaderText = "苏州"
        dc.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView1.DefaultCellStyle.Font.FontFamily, "14")
        DataGridView2.Columns.Add(dc)

        'DataGridView2.Columns.Add("StaffYes", "行政人员")StaffYes, StaffNo, Salary
        dc = New DataGridViewCheckBoxColumn()
        dc.Name = "SZStaffYes"
        dc.HeaderText = "行政人员"
        dc.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView1.DefaultCellStyle.Font.FontFamily, "14")
        DataGridView2.Columns.Add(dc)

        'DataGridView2.Columns.Add("StaffNo", "非行政人员")
        dc = New DataGridViewCheckBoxColumn()
        dc.Name = "SZStaffNo"
        dc.HeaderText = "非行政人员"
        dc.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView1.DefaultCellStyle.Font.FontFamily, "14")
        DataGridView2.Columns.Add(dc)

        'DataGridView2.Columns.Add("Salary", "薪资")
        dc = New DataGridViewCheckBoxColumn()
        dc.Name = "SZSalary"
        dc.HeaderText = "薪资"
        dc.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView1.DefaultCellStyle.Font.FontFamily, "14")
        DataGridView2.Columns.Add(dc)

        'DataGridView2.Columns.Add("SH", "上海")
        dc = New DataGridViewCheckBoxColumn()
        dc.Name = "SH"
        dc.HeaderText = "上海"
        dc.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView1.DefaultCellStyle.Font.FontFamily, "14")
        DataGridView2.Columns.Add(dc)

        'DataGridView2.Columns.Add("StaffYes", "行政人员")StaffYes, StaffNo, Salary
        dc = New DataGridViewCheckBoxColumn()
        dc.Name = "SHStaffYes"
        dc.HeaderText = "行政人员"
        dc.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView1.DefaultCellStyle.Font.FontFamily, "14")
        DataGridView2.Columns.Add(dc)

        'DataGridView2.Columns.Add("StaffNo", "非行政人员")
        dc = New DataGridViewCheckBoxColumn()
        dc.Name = "SHStaffNo"
        dc.HeaderText = "非行政人员"
        dc.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView1.DefaultCellStyle.Font.FontFamily, "14")
        DataGridView2.Columns.Add(dc)

        'DataGridView2.Columns.Add("Salary", "薪资")
        dc = New DataGridViewCheckBoxColumn()
        dc.Name = "SHSalary"
        dc.HeaderText = "薪资"
        dc.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView1.DefaultCellStyle.Font.FontFamily, "14")
        DataGridView2.Columns.Add(dc)

        DataGridView1.Columns("XH_No").Width = 40
        DataGridView1.Columns("FormCmd").Width = 80
        DataGridView1.Columns("FormCmdName").Width = 100
        DataGridView1.Columns("FormCmdOpen").Width = 50
        DataGridView2.Columns("XH_No").Width = 40
        DataGridView2.Columns("AllCmd").Width = 80
        DataGridView2.Columns("AllCmdName").Width = 100
        DataGridView2.Columns("AllCmdOpen").Width = 50
        DataGridView2.Columns("SZ").Width = 50
        DataGridView2.Columns("SZStaffYes").Width = 50
        DataGridView2.Columns("SZStaffNo").Width = 50
        DataGridView2.Columns("SZSalary").Width = 50
        DataGridView2.Columns("SH").Width = 50
        DataGridView2.Columns("SHStaffYes").Width = 50
        DataGridView2.Columns("SHStaffNo").Width = 50
        DataGridView2.Columns("SHSalary").Width = 50

        Me.DataGridView1.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView1.DefaultCellStyle.Font.FontFamily, "12")
        Me.DataGridView2.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView2.DefaultCellStyle.Font.FontFamily, "12")

        PWDataView.Columns.Add("XH_No", "序")
        PWDataView.Columns.Add("FormCmd", "按钮")
        PWDataView.Columns.Add("FormCmdName", "按钮名称")
        PWDataView.Columns.Add("FormCmdOpen", "操作")
        PWDataView.Columns.Add("AllCmd", "按钮")
        PWDataView.Columns.Add("AllCmdName", "按钮名称")
        PWDataView.Columns.Add("AllCmdOpen", "操作")
        PWDataView.Columns.Add("SZ", "苏州")
        PWDataView.Columns.Add("SZStaffYes", "行政人员")
        PWDataView.Columns.Add("SZStaffNo", "非行政人员")
        PWDataView.Columns.Add("SZSalary", "薪资")
        PWDataView.Columns.Add("SH", "苏州")
        PWDataView.Columns.Add("SHStaffYes", "行政人员")
        PWDataView.Columns.Add("SHStaffNo", "非行政人员")
        PWDataView.Columns.Add("SHSalary", "薪资")
        PWDataView.Columns.Add("NewOld", "新旧资料")

        Dim X As Integer = 0

        '先将所有按钮载入到PWDataView
        For i As Integer = 0 To Main_Form.FormTotal
            If Main_Form.ALLCmdName(i, 0, 0) = "" Then Exit For
            For j As Integer = 0 To Main_Form.CmdTotal
                If Main_Form.ALLCmdName(i, j, 0) = "" Then Exit For
                PWDataView.Rows.Add()

                PWDataView.Rows(X).Cells("XH_No").Value = X '序
                PWDataView.Rows(X).Cells("FormCmd").Value = Main_Form.ALLFormCmd(i, 0) '按钮
                PWDataView.Rows(X).Cells("FormCmdName").Value = Main_Form.ALLFormCmd(i, 1) '按钮名称
                PWDataView.Rows(X).Cells("FormCmdOpen").Value = False '操作
                PWDataView.Rows(X).Cells("AllCmd").Value = Main_Form.ALLCmdName(i, j, 0) '按钮
                PWDataView.Rows(X).Cells("AllCmdName").Value = Main_Form.ALLCmdName(i, j, 1) '按钮名称
                PWDataView.Rows(X).Cells("AllCmdOpen").Value = "False" '操作
                PWDataView.Rows(X).Cells("SZ").Value = "False" '苏州
                PWDataView.Rows(X).Cells("SZStaffYes").Value = "False" '行政人员
                PWDataView.Rows(X).Cells("SZStaffNo").Value = "False" '非行政人员
                PWDataView.Rows(X).Cells("SZSalary").Value = "False" '薪资
                PWDataView.Rows(X).Cells("SH").Value = "False" '上海
                PWDataView.Rows(X).Cells("SHStaffYes").Value = "False" '行政人员
                PWDataView.Rows(X).Cells("SHStaffNo").Value = "False" '非行政人员
                PWDataView.Rows(X).Cells("SHSalary").Value = "False" '薪资
                PWDataView.Rows(X).Cells("NewOld").Value = "N" '新旧资料
                X += 1
            Next
        Next

        '暂存所有主画面的按钮，方便查询
        ReDim PWAllCmdName(PWDataView.RowCount - 1)
        For i As Integer = 0 To PWDataView.RowCount - 1
            PWAllCmdName(i) = PWDataView.Rows(i).Cells("FormCmd").Value
        Next

        DataGridView3.Columns.Add("User_No", "员工编号")
        DataGridView3.Columns.Add("User_Name", "员工姓名")
        DataGridView3.Columns.Add("User_Pwd", "密码")
        DataGridView3.Columns.Add("User_Dep", "部门")
        DataGridView3.Columns("User_Pwd").Visible = False
        DataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Load_Cmd.Enabled = True
        Modify_Cmd.Enabled = False
        New_Cmd.Enabled = True
        SAVE_Cmd.Enabled = False
        Discard_Cmd.Enabled = False
        DEL_Cmd.Enabled = False
        Exit_Cmd.Enabled = True

        User_No_Text.Enabled = False
        User_Name_Text.Enabled = False
        User_Dep_Text.Enabled = False
        User_Pwd_Text.Enabled = False
        DoUser_Pwd_Text.Enabled = False

        FormCmdOpen_CB.Enabled = False
        AllCmdOpen_CB.Enabled = False
        SZ_CB.Enabled = False
        SZStaffYes_CB.Enabled = False
        SZStaffNo_CB.Enabled = False
        SZSalary_CB.Enabled = False
        SH_CB.Enabled = False
        SHStaffYes_CB.Enabled = False
        SHStaffNo_CB.Enabled = False
        SHSalary_CB.Enabled = False

        'DataGridView1.Enabled = False
        'DataGridView2.Enabled = False

        '-----先隐藏TabPage2（资料浏览）-----
        TabControl1.TabPages.Remove(TabPage2)



    End Sub


    Private Sub User_No_Text_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles User_No_Text.KeyPress, User_Name_Text.KeyPress, User_Dep_Text.KeyPress, User_Pwd_Text.KeyPress, DoUser_Pwd_Text.KeyPress
        If e.KeyChar = Chr(13) Then SendKeys.Send("{Tab}")
    End Sub

    Private Sub DoUser_Pwd_Text_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles DoUser_Pwd_Text.LostFocus

        If DoUser_Pwd_Text.Text = "" Then
            MsgBox("确认密码不可空白")
        Else
            If DoUser_Pwd_Text.Text <> "" Then
                If DoUser_Pwd_Text.Text <> User_Pwd_Text.Text Then
                    MsgBox("确认密码和密码不符，请重新输入")
                End If
            End If
        End If

    End Sub

    '查询
    Private Sub Load_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load_Cmd.Click

        ModifySave = "3"

        TabControl1.TabPages.Remove(TabPage2)

        '-----显示TabPage2（资料浏览）-----
        TabControl1.TabPages.Add(TabPage2)

        User_No_Text.Text = ""     '员工编号     'UserTA.User_No
        User_Name_Text.Text = ""   '员工姓名     'UserTA.User_Name
        User_Pwd_Text.Text = ""    '密码     'UserTA.User_Pwd
        DoUser_Pwd_Text.Text = ""
        User_Dep_Text.Text = ""    '部门    'UserTA.User_Dep

        AAA = ""
        BBB = ""

        Class_SQL.VBUserALoad(AForm:=Me)

        DataGridViewSet.ClearRows(DataGridView3)

        Me.DataGridView3.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView3.DefaultCellStyle.Font.FontFamily, "11")

        Dim DSTablesName As String = "VBUserALoad"

        If Class_SQL.DS1.Tables(DSTablesName).Rows.Count > 0 Then

            For i As Integer = 0 To Class_SQL.DS1.Tables(DSTablesName).Rows.Count - 1
                '-----新增一行-----
                DataGridView3.Rows().Add()

                DataGridView3.Rows(i).Cells("User_No").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("User_No").ToString)
                DataGridView3.Rows(i).Cells("User_Name").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("User_Name").ToString)
                DataGridView3.Rows(i).Cells("User_Pwd").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("User_Pwd").ToString)
                DataGridView3.Rows(i).Cells("User_Dep").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("User_Dep").ToString)

            Next

            DataGridViewSet.AutoMode(Me.DataGridView3)

        End If

        TabControl1.TabPages.Item(1).Select()

        TabControl1.SelectedTab = TabPage2

        If DataGridView3.RowCount > 0 Then
            Load_Cmd.Enabled = True
            New_Cmd.Enabled = True
            Modify_Cmd.Enabled = True
            SAVE_Cmd.Enabled = False
            Discard_Cmd.Enabled = False
            DEL_Cmd.Enabled = True
            Exit_Cmd.Enabled = True

            DataGridView3.ClearSelection()
            'Me.DataGridView1.Rows(0).Selected = True
            DataGridViewLocation = -1
            DataGridView3.CurrentCell = DataGridView3.Rows(0).Cells(1)

        Else
            Load_Cmd.Enabled = True
            New_Cmd.Enabled = True
            Modify_Cmd.Enabled = False
            SAVE_Cmd.Enabled = False
            Discard_Cmd.Enabled = False
            DEL_Cmd.Enabled = False
            Exit_Cmd.Enabled = True
        End If


    End Sub

    '修改
    Private Sub Modify_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Modify_Cmd.Click

        ModifySave = "2"

        User_NoTemp = RTrim(User_No_Text.Text)     '员工编号     'UserTA.User_No
        User_NameTemp = RTrim(User_Name_Text.Text)   '员工姓名     'UserTA.User_Name
        User_PwdTemp = RTrim(User_Pwd_Text.Text)    '密码     'UserTA.User_Pwd
        User_DepTemp = RTrim(User_Dep_Text.Text)    '部门    'UserTA.User_Dep

        User_No_Text.Enabled = False
        User_Name_Text.Enabled = True
        User_Dep_Text.Enabled = True
        User_Pwd_Text.Enabled = True
        DoUser_Pwd_Text.Enabled = True

        FormCmdOpen_CB.Enabled = True
        AllCmdOpen_CB.Enabled = True
        SZ_CB.Enabled = True
        SZStaffYes_CB.Enabled = True
        SZStaffNo_CB.Enabled = True
        SZSalary_CB.Enabled = True
        SH_CB.Enabled = True
        SHStaffYes_CB.Enabled = True
        SHStaffNo_CB.Enabled = True
        SHSalary_CB.Enabled = True

        '-----先隐藏TabPage2（资料浏览）-----
        TabControl1.TabPages.Remove(TabPage2)

        TabControl1.TabPages.Item(0).Select()

        TabControl1.SelectedTab = TabPage1

        '暂存权限，保存时比对是否有修改
        PWDataViewTemp = New DataGridView

        PWDataViewTemp.AllowUserToAddRows = False

        For i As Integer = 0 To PWDataView.ColumnCount - 1
            PWDataViewTemp.Columns.Add(PWDataView.Columns(i).Name, PWDataView.Columns(i).HeaderText)
        Next

        For i As Integer = 0 To PWDataView.RowCount - 1
            PWDataViewTemp.Rows.Add()
            For j As Integer = 0 To PWDataView.ColumnCount - 1
                PWDataViewTemp.Rows(i).Cells(j).Value = PWDataView.Rows(i).Cells(j).Value
            Next
        Next

        User_Name_Text.Focus()
        User_Name_Text.SelectionStart = 0
        User_Name_Text.SelectionLength = 0

        Load_Cmd.Enabled = False
        New_Cmd.Enabled = False
        Modify_Cmd.Enabled = False
        SAVE_Cmd.Enabled = True
        Discard_Cmd.Enabled = True
        DEL_Cmd.Enabled = False
        Exit_Cmd.Enabled = False

    End Sub

    '新增
    Private Sub New_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles New_Cmd.Click

        '-----先隐藏TabPage2（资料浏览）-----
        TabControl1.TabPages.Remove(TabPage2)

        DataGridViewSet.ClearRows(DataGridView1)
        DataGridViewSet.ClearRows(DataGridView2)

        Me.DataGridView1.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView1.DefaultCellStyle.Font.FontFamily, "12")
        Me.DataGridView2.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView2.DefaultCellStyle.Font.FontFamily, "14")

        '将主画面按钮载入到 DataGridView1
        '其余按钮在'DataGridView1单元格焦点变更时再载入


        For i As Integer = 0 To PWDataView.RowCount - 1

            '按钮名称不动，其余写上False
            PWDataView.Rows(i).Cells("FormCmdOpen").Value = "False" '操作
            PWDataView.Rows(i).Cells("AllCmdOpen").Value = "False" '操作
            PWDataView.Rows(i).Cells("SZ").Value = "False" '苏州
            PWDataView.Rows(i).Cells("SZStaffYes").Value = "False" '行政人员
            PWDataView.Rows(i).Cells("SZStaffNo").Value = "False" '非行政人员
            PWDataView.Rows(i).Cells("SZSalary").Value = "False" '薪资
            PWDataView.Rows(i).Cells("SH").Value = "False" '上海
            PWDataView.Rows(i).Cells("SHStaffYes").Value = "False" '行政人员
            PWDataView.Rows(i).Cells("SHStaffNo").Value = "False" '非行政人员
            PWDataView.Rows(i).Cells("SHSalary").Value = "False" '薪资
            PWDataView.Rows(i).Cells("NewOld").Value = "N" 'N新Y旧资料

            If i = 0 Or PWDataView.Rows(i).Cells("FormCmd").Value <> PWDataView.Rows(IIf(i = 0, i, i - 1)).Cells("FormCmd").Value Then
                DataGridView1.Rows.Add()
                DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("XH_No").Value = PWDataView.Rows(i).Cells("XH_No").Value
                DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("FormCmd").Value = PWDataView.Rows(i).Cells("FormCmd").Value
                DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("FormCmdName").Value = PWDataView.Rows(i).Cells("FormCmdName").Value
                DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("FormCmdOpen").Value = PWDataView.Rows(i).Cells("FormCmdOpen").Value

            End If
        Next

        'DataGridViewSet.AutoMode(Me.DataGridView1)

        'DataGridView1.Enabled = True
        'DataGridView2.Enabled = True

        Load_Cmd.Enabled = False
        Modify_Cmd.Enabled = False
        New_Cmd.Enabled = False
        SAVE_Cmd.Enabled = True
        Discard_Cmd.Enabled = True
        DEL_Cmd.Enabled = False
        Exit_Cmd.Enabled = False

        User_No_Text.Enabled = True
        User_Name_Text.Enabled = True
        User_Dep_Text.Enabled = True
        User_Pwd_Text.Enabled = True
        DoUser_Pwd_Text.Enabled = True

        FormCmdOpen_CB.Enabled = True
        AllCmdOpen_CB.Enabled = True
        SZ_CB.Enabled = True
        SZStaffYes_CB.Enabled = True
        SZStaffNo_CB.Enabled = True
        SZSalary_CB.Enabled = True
        SH_CB.Enabled = True
        SHStaffYes_CB.Enabled = True
        SHStaffNo_CB.Enabled = True
        SHSalary_CB.Enabled = True

        ModifySave = "1"

        DataGridView1.ClearSelection()
        'Me.DataGridView1.Rows(0).Selected = True
        DataGridViewLocation = -1
        DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(1)

        User_No_Text.Text = ""     '员工编号     'UserTA.User_No
        User_Name_Text.Text = ""   '员工姓名     'UserTA.User_Name
        User_Pwd_Text.Text = ""    '密码     'UserTA.User_Pwd
        DoUser_Pwd_Text.Text = ""    '密码     'UserTA.User_Pwd
        User_Dep_Text.Text = ""    '部门    'UserTA.User_Dep

        User_No_Text.Focus()
        User_No_Text.SelectionStart = 0
        User_No_Text.SelectionLength = 0

    End Sub

    '保存
    Private Sub SAVE_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SAVE_Cmd.Click

        If RTrim(User_No_Text.Text) = "" Or RTrim(User_Name_Text.Text) = "" Or RTrim(User_Dep_Text.Text) = "" Or RTrim(User_Pwd_Text.Text) = "" Or RTrim(DoUser_Pwd_Text.Text) = "" Then
            MsgBox("所有栏位都必须填写，不可空白", , "资料空白")
            Select Case ModifySave
                Case "1"
                    User_No_Text.Focus()
                    User_No_Text.SelectionStart = 0
                    User_No_Text.SelectionLength = 0
                Case "2"
                    User_Name_Text.Focus()
                    User_Name_Text.SelectionStart = 0
                    User_Name_Text.SelectionLength = 0
            End Select
            Exit Sub
        End If

        User_No = RTrim(User_No_Text.Text)     '员工编号     'UserTA.User_No
        User_Name = RTrim(User_Name_Text.Text)   '员工姓名     'UserTA.User_Name
        User_Pwd = RTrim(User_Pwd_Text.Text)    '密码     'UserTA.User_Pwd
        User_Dep = RTrim(User_Dep_Text.Text)    '部门    'UserTA.User_Dep

        Dim PwdDecoding As String = ""

        AAA = ""
        BBB = ""

        '-----1代表新增，2代表修改，3代表无意义-----
        Select Case ModifySave
            Case "1"
                '----新增-----
                '-----先查 资料 有没有重复-----
                AAA = " AND VBUserA.User_No = '" & User_No & "' "
                Class_SQL.VBUserALoad(AForm:=Me)

                If Class_SQL.DS1.Tables("VBUserALoad").Rows.Count > 0 Then
                    MsgBox("员工编号：" & User_No & " 已存在，无法存档")
                    User_No_Text.Focus()
                    User_No_Text.SelectionStart = 0
                    User_No_Text.SelectionLength = 0
                    Exit Sub
                End If

                '------存入SQL-----
                Class_SQL.VBUserANewSave(AForm:=Me)

                If Class_SQL.DS1.Tables("VBUserANewSave").Rows.Count > 0 Then

                    '写入资料浏览
                    '-----显示TabPage2（资料浏览）-----
                    TabControl1.TabPages.Add(TabPage2)

                    Dim DSTablesName As String = "VBUserANewSave"

                    DataGridView3.Rows.Add()

                    DataGridView3.Rows(DataGridView3.RowCount - 1).Cells("User_No").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(0).Item("User_No").ToString)
                    DataGridView3.Rows(DataGridView3.RowCount - 1).Cells("User_Name").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(0).Item("User_Name").ToString)
                    DataGridView3.Rows(DataGridView3.RowCount - 1).Cells("User_Dep").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(0).Item("User_Dep").ToString)
                    DataGridView3.Rows(DataGridView3.RowCount - 1).Cells("User_Pwd").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(0).Item("User_Pwd").ToString)

                    For i As Integer = 0 To PWDataView.RowCount - 1

                        'User_No = RTrim(User_No_Text.Text)
                        FormCmd = RTrim(PWDataView.Rows(i).Cells("FormCmd").Value) '按钮
                        'FormCmdName = PWDataView.Rows(i).Cells("FormCmdName").Value = '按钮名称
                        FormCmdOpen = IIf(PWDataView.Rows(i).Cells("FormCmdOpen").Value = "True", "Y", "N")  '操作
                        AllCmd = RTrim(PWDataView.Rows(i).Cells("AllCmd").Value)  '按钮
                        'AllCmdName = PWDataView.Rows(i).Cells("AllCmdName").Value  '按钮名称
                        AllCmdOpen = IIf(PWDataView.Rows(i).Cells("AllCmdOpen").Value = "True", "Y", "N") '操作
                        SZ = IIf(PWDataView.Rows(i).Cells("SZ").Value = "True", "Y", "N")  '苏州
                        SZStaffYes = IIf(PWDataView.Rows(i).Cells("SZStaffYes").Value = "True", "Y", "N")  '行政人员
                        SZStaffNo = IIf(PWDataView.Rows(i).Cells("SZStaffNo").Value = "True", "Y", "N")  '非行政人员
                        SZSalary = IIf(PWDataView.Rows(i).Cells("SZSalary").Value = "True", "Y", "N")    '薪资
                        SH = IIf(PWDataView.Rows(i).Cells("SH").Value = "True", "Y", "N")  '上海
                        SHStaffYes = IIf(PWDataView.Rows(i).Cells("SHStaffYes").Value = "True", "Y", "N")  '行政人员
                        SHStaffNo = IIf(PWDataView.Rows(i).Cells("SHStaffNo").Value = "True", "Y", "N")  '非行政人员
                        SHSalary = IIf(PWDataView.Rows(i).Cells("SHSalary").Value = "True", "Y", "N")    '薪资

                        Select Case PWDataView.Rows(i).Cells("NewOld").Value
                            Case "N"  '新资料
                                Class_SQL.VBUserBNewSave(AForm:=Me)

                                If Class_SQL.DS1.Tables("VBUserBNewSave").Rows.Count > 0 Then

                                Else
                                    MsgBox("单身第" & i & "资料新增有错", , "单身储存时有错N")
                                    Exit Sub
                                End If

                            Case "Y" '旧资料
                                Class_SQL.VBUserBModifySave(AForm:=Me)
                                If Class_SQL.DS1.Tables("VBUserBModifySave").Rows.Count > 0 Then

                                Else
                                    MsgBox("单身第" & i & "资料更新有错", , "单身储存时有错Y")
                                    Exit Sub
                                End If

                        End Select

                    Next

                Else
                    MsgBox("单头资料新增有错", , "单头储存有错")
                    Exit Sub
                End If


                DataGridView3.ClearSelection()
                Me.DataGridView3.Rows(DataGridView3.RowCount - 1).Selected = True
                DataGridViewLocation = -1

                MsgBox("员工编号：" & User_No & " 资料已新增")


            Case "2"

                '-----先判断资料是否有修改，没修改的话，就跳出-----
                Dim UserAModify As Boolean = False
                Dim UserBModify As Boolean = False

                If User_No = User_NoTemp And User_Name = User_NameTemp And User_Pwd = User_PwdTemp And User_Dep = User_DepTemp Then
                    UserAModify = False
                Else
                    UserAModify = True
                End If

                For i As Integer = 0 To PWDataView.RowCount - 1
                    'N新Y旧资料
                    If PWDataView.Rows(i).Cells("NewOld").Value = "N" Then
                        UserBModify = True
                        Exit For
                    End If

                    For j As Integer = 0 To PWDataView.ColumnCount - 1
                        If PWDataView.Rows(i).Cells(j).Value <> PWDataViewTemp.Rows(i).Cells(j).Value Then
                            UserBModify = True
                            Exit For
                        End If
                    Next
                    If UserBModify = True Then Exit For
                Next

                If UserAModify = False And UserBModify = False Then
                    MsgBox("员工编号：" & User_No & " 内容没修改")
                    User_Name_Text.Focus()
                    User_Name_Text.SelectionStart = 0
                    User_Name_Text.SelectionLength = 0
                    Exit Sub
                End If

                '单头有修改
                If UserAModify = True Then

                    '-----修改SQL资料------
                    Class_SQL.VBUserAModifySave(AForm:=Me)

                    If Class_SQL.DS1.Tables("VBUserAModifySave").Rows.Count > 0 Then

                        Dim DSTablesName As String = "VBUserAModifySave"

                        DataGridView3.Rows(DataGridView3.CurrentCell.RowIndex).Cells("User_No").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(0).Item("User_No").ToString)
                        DataGridView3.Rows(DataGridView3.CurrentCell.RowIndex).Cells("User_Name").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(0).Item("User_Name").ToString)
                        DataGridView3.Rows(DataGridView3.CurrentCell.RowIndex).Cells("User_Pwd").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(0).Item("User_Pwd").ToString)
                        DataGridView3.Rows(DataGridView3.CurrentCell.RowIndex).Cells("User_Dep").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(0).Item("User_Dep").ToString)

                    Else
                        MsgBox("单头资料更新有错", , "单头更新储存时有错")
                        Exit Sub
                    End If

                End If

                '单身有修改
                If UserBModify = True Then
                    For i As Integer = 0 To PWDataView.RowCount - 1

                        'User_No = RTrim(User_No_Text.Text)
                        FormCmd = RTrim(PWDataView.Rows(i).Cells("FormCmd").Value) '按钮
                        'FormCmdName = PWDataView.Rows(i).Cells("FormCmdName").Value = '按钮名称
                        FormCmdOpen = IIf(PWDataView.Rows(i).Cells("FormCmdOpen").Value = "True", "Y", "N")  '操作
                        AllCmd = RTrim(PWDataView.Rows(i).Cells("AllCmd").Value)  '按钮
                        'AllCmdName = PWDataView.Rows(i).Cells("AllCmdName").Value  '按钮名称
                        AllCmdOpen = IIf(PWDataView.Rows(i).Cells("AllCmdOpen").Value = "True", "Y", "N") '操作
                        SZ = IIf(PWDataView.Rows(i).Cells("SZ").Value = "True", "Y", "N")  '苏州
                        SZStaffYes = IIf(PWDataView.Rows(i).Cells("SZStaffYes").Value = "True", "Y", "N")  '行政人员
                        SZStaffNo = IIf(PWDataView.Rows(i).Cells("SZStaffNo").Value = "True", "Y", "N")  '非行政人员
                        SZSalary = IIf(PWDataView.Rows(i).Cells("SZSalary").Value = "True", "Y", "N")    '薪资
                        SH = IIf(PWDataView.Rows(i).Cells("SH").Value = "True", "Y", "N")  '上海
                        SHStaffYes = IIf(PWDataView.Rows(i).Cells("SHStaffYes").Value = "True", "Y", "N")  '行政人员
                        SHStaffNo = IIf(PWDataView.Rows(i).Cells("SHStaffNo").Value = "True", "Y", "N")  '非行政人员
                        SHSalary = IIf(PWDataView.Rows(i).Cells("SHSalary").Value = "True", "Y", "N")    '薪资

                        'NewOld = PWDataView.Rows(i).Cells("NewOld").Value  '新旧资料

                        'N新Y旧资料(按钮有新增时用的)
                        If PWDataView.Rows(i).Cells("NewOld").Value = "N" Then
                            Class_SQL.VBUserBNewSave(AForm:=Me)

                            If Class_SQL.DS1.Tables("VBUserBNewSave").Rows.Count > 0 Then

                            Else
                                MsgBox("单身第" & i & "资料新增有错", , "单身储存时有错")
                                Exit Sub
                            End If
                        End If

                        'Y旧资料（SQL抓的资料）StaffYes, StaffNo, Salary
                        If PWDataView.Rows(i).Cells("NewOld").Value = "Y" Then

                            If PWDataViewTemp.Rows(i).Cells("FormCmdOpen").Value <> FormCmdOpen _
                                Or PWDataViewTemp.Rows(i).Cells("AllCmdOpen").Value <> AllCmdOpen _
                                Or PWDataViewTemp.Rows(i).Cells("SZ").Value <> SZ _
                                Or PWDataViewTemp.Rows(i).Cells("SZStaffYes").Value <> SZStaffYes _
                                Or PWDataViewTemp.Rows(i).Cells("SZStaffNo").Value <> SZStaffNo _
                                Or PWDataViewTemp.Rows(i).Cells("SZSalary").Value <> SZSalary _
                                Or PWDataViewTemp.Rows(i).Cells("SH").Value <> SH _
                                Or PWDataViewTemp.Rows(i).Cells("SHStaffYes").Value <> SHStaffYes _
                                Or PWDataViewTemp.Rows(i).Cells("SHStaffNo").Value <> SHStaffNo _
                                Or PWDataViewTemp.Rows(i).Cells("SHSalary").Value <> SHSalary Then

                                Class_SQL.VBUserBModifySave(AForm:=Me)

                                If Class_SQL.DS1.Tables("VBUserBModifySave").Rows.Count > 0 Then

                                Else
                                    MsgBox("单身第" & i & "资料更新有错", , "单身储存时有错")
                                    Exit Sub
                                End If

                            End If

                        End If
                    Next

                End If

                MsgBox("员工编号：" & User_No & " 资料已修改")

                Dim IntTemp As Integer = DataGridView3.CurrentRow.Index
                DataGridView3.ClearSelection()
                Me.DataGridView3.Rows(IntTemp).Selected = True
                DataGridViewLocation = -1
                'DataGridView3.CurrentCell = DataGridView3.Rows(0).Cells(1)

            Case Else


        End Select


        User_No = ""     '员工编号     'UserTA.User_No
        User_Name = ""   '员工姓名     'UserTA.User_Name
        User_Pwd = ""    '密码     'UserTA.User_Pwd
        User_Dep = ""    '部门    'UserTA.User_Dep

        FormCmd = "" '按钮
        FormCmdOpen = ""  '操作
        AllCmd = ""  '按钮
        AllCmdOpen = "" '操作
        SZ = "" '苏州
        SZStaffYes = "" '行政人员
        SZStaffNo = ""  '非行政人员
        SZSalary = ""   '薪资
        SH = "" '上海
        SHStaffYes = "" '行政人员
        SHStaffNo = ""  '非行政人员
        SHSalary = ""   '薪资

        User_NoTemp = ""     '员工编号     'UserTA.User_No
        User_NameTemp = ""   '员工姓名     'UserTA.User_Name
        User_PwdTemp = ""    '密码     'UserTA.User_Pwd
        User_DepTemp = ""    '部门    'UserTA.User_Dep

        FormCmdTemp = "" '按钮
        FormCmdOpenTemp = ""  '操作
        AllCmdTemp = ""  '按钮
        AllCmdOpenTemp = "" '操作
        SZTemp = "" '苏州
        SZStaffYesTemp = "" '行政人员
        SZStaffNoTemp = ""  '非行政人员
        SZSalaryTemp = ""   '薪资
        SHTemp = "" '上海
        SHStaffYesTemp = "" '行政人员
        SHStaffNoTemp = ""  '非行政人员
        SHSalaryTemp = ""   '薪资

        Load_Cmd.Enabled = True
        New_Cmd.Enabled = True
        Modify_Cmd.Enabled = True
        SAVE_Cmd.Enabled = False
        Discard_Cmd.Enabled = False
        DEL_Cmd.Enabled = True
        Exit_Cmd.Enabled = True

        User_No_Text.Enabled = False
        User_Name_Text.Enabled = False
        User_Dep_Text.Enabled = False
        User_Pwd_Text.Enabled = False
        DoUser_Pwd_Text.Enabled = False

        FormCmdOpen_CB.Enabled = False
        AllCmdOpen_CB.Enabled = False
        SZ_CB.Enabled = False
        SZStaffYes_CB.Enabled = False
        SZStaffNo_CB.Enabled = False
        SZSalary_CB.Enabled = False
        SH_CB.Enabled = False
        SHStaffYes_CB.Enabled = False
        SHStaffNo_CB.Enabled = False
        SHSalary_CB.Enabled = False

        PWDataViewTemp = New DataGridView

        ModifySave = "3"

        TabControl1.TabPages.Remove(TabPage2)
        '-----显示TabPage2（资料浏览）-----
        TabControl1.TabPages.Add(TabPage2)


    End Sub

    '放弃
    Private Sub Discard_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Discard_Cmd.Click

        Select Case MessageBox.Show("是否放弃编辑的资料", "放弃", System.Windows.Forms.MessageBoxButtons.YesNo)

            Case 6    '按YES

                ModifySave = "3"

                User_No_Text.Text = User_NoTemp    '员工编号     'UserTA.User_No
                User_Name_Text.Text = User_NameTemp  '员工姓名     'UserTA.User_Name
                User_Pwd_Text.Text = User_PwdTemp     '密码     'UserTA.User_Pwd
                User_Dep_Text.Text = User_DepTemp     '部门    'UserTA.User_Dep

                DataGridViewSet.ClearRows(DataGridView1)
                DataGridViewSet.ClearRows(DataGridView2)
                Me.DataGridView1.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView1.DefaultCellStyle.Font.FontFamily, "12")
                Me.DataGridView2.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView2.DefaultCellStyle.Font.FontFamily, "14")

                If Me.DataGridView3.RowCount > 0 Then
                    Load_Cmd.Enabled = True
                    New_Cmd.Enabled = True
                    Modify_Cmd.Enabled = True
                    SAVE_Cmd.Enabled = False
                    Discard_Cmd.Enabled = False
                    DEL_Cmd.Enabled = True
                    Exit_Cmd.Enabled = True

                    TabControl1.TabPages.Remove(TabPage2)

                    '-----显示TabPage2（资料浏览）-----
                    TabControl1.TabPages.Add(TabPage2)

                    'TabControl1.TabPages.Item(1).Select()

                    'TabControl1.SelectedTab = TabPage2

                    Dim IntTemp As Integer = IIf(DataGridView3.CurrentRow.Index >= 0, DataGridView3.CurrentRow.Index, 0)
                    DataGridView3.ClearSelection()
                    Me.DataGridView3.Rows(IntTemp).Selected = True
                    DataGridViewLocation = -1
                    'DataGridView3.CurrentCell = DataGridView3.Rows(0).Cells(1)

                Else
                    Load_Cmd.Enabled = True
                    New_Cmd.Enabled = True
                    Modify_Cmd.Enabled = False
                    SAVE_Cmd.Enabled = False
                    Discard_Cmd.Enabled = False
                    DEL_Cmd.Enabled = False
                    Exit_Cmd.Enabled = True
                End If

                User_No = ""     '员工编号     'UserTA.User_No
                User_Name = ""   '员工姓名     'UserTA.User_Name
                User_Pwd = ""    '密码     'UserTA.User_Pwd
                User_Dep = ""    '部门    'UserTA.User_Dep

                FormCmd = "" '按钮
                FormCmdOpen = ""  '操作
                AllCmd = ""  '按钮
                AllCmdOpen = "" '操作
                SZ = "" '苏州
                SZStaffYes = "" '行政人员
                SZStaffNo = ""  '非行政人员
                SZSalary = ""   '薪资
                SH = "" '上海
                SHStaffYes = "" '行政人员
                SHStaffNo = ""  '非行政人员
                SHSalary = ""   '薪资

                User_NoTemp = ""     '员工编号     'UserTA.User_No
                User_NameTemp = ""   '员工姓名     'UserTA.User_Name
                User_PwdTemp = ""    '密码     'UserTA.User_Pwd
                User_DepTemp = ""    '部门    'UserTA.User_Dep

                FormCmdTemp = "" '按钮
                FormCmdOpenTemp = ""  '操作
                AllCmdTemp = ""  '按钮
                AllCmdOpenTemp = "" '操作
                SZTemp = "" '苏州
                SZStaffYesTemp = "" '行政人员
                SZStaffNoTemp = ""  '非行政人员
                SZSalaryTemp = ""   '薪资
                SHTemp = "" '上海
                SHStaffYesTemp = "" '行政人员
                SHStaffNoTemp = ""  '非行政人员
                SHSalaryTemp = ""   '薪资

                Load_Cmd.Enabled = True
                New_Cmd.Enabled = True
                Modify_Cmd.Enabled = True
                SAVE_Cmd.Enabled = False
                Discard_Cmd.Enabled = False
                DEL_Cmd.Enabled = True
                Exit_Cmd.Enabled = True

                User_No_Text.Enabled = False
                User_Name_Text.Enabled = False
                User_Dep_Text.Enabled = False
                User_Pwd_Text.Enabled = False
                DoUser_Pwd_Text.Enabled = False

                FormCmdOpen_CB.Enabled = False
                AllCmdOpen_CB.Enabled = False
                SZ_CB.Enabled = False
                SZStaffYes_CB.Enabled = False
                SZStaffNo_CB.Enabled = False
                SZSalary_CB.Enabled = False
                SH_CB.Enabled = False
                SHStaffYes_CB.Enabled = False
                SHStaffNo_CB.Enabled = False
                SHSalary_CB.Enabled = False

                PWDataViewTemp = New DataGridView


            Case 7   '按NO


        End Select



    End Sub

    '删除
    Private Sub DEL_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DEL_Cmd.Click


        Select Case MessageBox.Show("是否删除 员工编号：" & RTrim(User_No_Text.Text) & " 员工姓名：" & RTrim(User_Name_Text.Text), "删除", System.Windows.Forms.MessageBoxButtons.YesNo)
            Case 6    '按YES

                User_No = RTrim(User_No_Text.Text)     '员工编号     'UserTA.User_No
                User_Name = RTrim(User_Name_Text.Text)   '员工姓名     'UserTA.User_Name
                User_Pwd = RTrim(User_Pwd_Text.Text)    '密码     'UserTA.User_Pwd
                User_Dep = RTrim(User_Dep_Text.Text)    '部门    'UserTA.User_Dep

                AAA = " VBUserA.User_No = '" & RTrim(User_No_Text.Text) & "' "
                Class_SQL.VBUserADelete(AForm:=Me)
                AAA = ""

                AAA = " VBUserB.User_No = '" & RTrim(User_No_Text.Text) & "' "
                Class_SQL.VBUserBDelete(AForm:=Me)
                AAA = ""

                If Class_SQL.DS1.Tables("VBUserADelete").Rows.Count > 0 Or Class_SQL.DS1.Tables("VBUserBDelete").Rows.Count > 0 Then
                    MsgBox("单头资料删除有错", , "单头资料删除时有错")
                    Exit Sub
                Else

                    MsgBox("员工编号：" & RTrim(User_No_Text.Text) & " 员工姓名：" & RTrim(User_Name_Text.Text) & " 已删除", , "删除")

                End If

                Me.DataGridView3.Rows.RemoveAt(Me.DataGridView3.CurrentRow.Index)
                DataGridViewSet.ClearRows(DataGridView1)
                DataGridViewSet.ClearRows(DataGridView2)
                Me.DataGridView1.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView1.DefaultCellStyle.Font.FontFamily, "12")
                Me.DataGridView2.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView2.DefaultCellStyle.Font.FontFamily, "14")

                User_No_Text.Text = ""     '员工编号     'UserTA.User_No
                User_Name_Text.Text = ""   '员工姓名     'UserTA.User_Name
                User_Pwd_Text.Text = ""    '密码     'UserTA.User_Pwd
                DoUser_Pwd_Text.Text = ""    '密码     'UserTA.User_Pwd
                User_Dep_Text.Text = ""    '部门    'UserTA.User_Dep

                User_No = ""     '员工编号     'UserTA.User_No
                User_Name = ""   '员工姓名     'UserTA.User_Name
                User_Pwd = ""    '密码     'UserTA.User_Pwd
                User_Dep = ""    '部门    'UserTA.User_Dep

                FormCmd = "" '按钮
                FormCmdOpen = ""  '操作
                AllCmd = ""  '按钮
                AllCmdOpen = "" '操作
                SZ = "" '苏州
                SZStaffYes = "" '行政人员
                SZStaffNo = ""  '非行政人员
                SZSalary = ""   '薪资
                SH = "" '上海
                SHStaffYes = "" '行政人员
                SHStaffNo = ""  '非行政人员
                SHSalary = ""   '薪资

                If Me.DataGridView3.RowCount > 0 Then
                    Load_Cmd.Enabled = True
                    New_Cmd.Enabled = True
                    Modify_Cmd.Enabled = True
                    SAVE_Cmd.Enabled = False
                    Discard_Cmd.Enabled = False
                    DEL_Cmd.Enabled = True
                    Exit_Cmd.Enabled = True

                    DataGridView3.ClearSelection()
                    Me.DataGridView3.Rows(0).Selected = True
                    DataGridViewLocation = -1
                    'DataGridView3.CurrentCell = DataGridView3.Rows(0).Cells(1)

                Else
                    Load_Cmd.Enabled = True
                    New_Cmd.Enabled = True
                    Modify_Cmd.Enabled = False
                    SAVE_Cmd.Enabled = False
                    Discard_Cmd.Enabled = False
                    DEL_Cmd.Enabled = False
                    Exit_Cmd.Enabled = True
                End If




            Case 7   '按NO


        End Select



    End Sub

    Private Sub Exit_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_Cmd.Click
        Me.Close()
    End Sub

    'DataGridView1单元格焦点变更
    Private Sub DataGridView1_CellStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellStateChangedEventArgs) Handles DataGridView1.CellStateChanged

        If e.Cell.Selected = True And PWDataView.RowCount > 0 Then   'And ModifySave <> "3"
            If DataGridViewLocation <> e.Cell.RowIndex Then   'And ModifySave <> "3"

                If Array.IndexOf(PWAllCmdName, DataGridView1.Rows(e.Cell.RowIndex).Cells("FormCmd").Value) >= 0 Then

                    DataGridViewSet.ClearRows(DataGridView2)
                    Me.DataGridView2.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView2.DefaultCellStyle.Font.FontFamily, "14")

                    For i As Integer = Array.IndexOf(PWAllCmdName, DataGridView1.Rows(e.Cell.RowIndex).Cells("FormCmd").Value) To Array.LastIndexOf(PWAllCmdName, DataGridView1.Rows(e.Cell.RowIndex).Cells("FormCmd").Value)
                        DataGridView2.Rows.Add()
                        DataGridView2.Rows(DataGridView2.RowCount - 1).Height = 30
                        DataGridView2.Rows(DataGridView2.RowCount - 1).Cells("XH_No").Value = PWDataView.Rows(i).Cells("XH_No").Value '序
                        DataGridView2.Rows(DataGridView2.RowCount - 1).Cells("AllCmd").Value = PWDataView.Rows(i).Cells("AllCmd").Value  '按钮
                        DataGridView2.Rows(DataGridView2.RowCount - 1).Cells("AllCmdName").Value = PWDataView.Rows(i).Cells("AllCmdName").Value '按钮名称
                        DataGridView2.Rows(DataGridView2.RowCount - 1).Cells("AllCmdOpen").Value = PWDataView.Rows(i).Cells("AllCmdOpen").Value '操作
                        DataGridView2.Rows(DataGridView2.RowCount - 1).Cells("SZ").Value = PWDataView.Rows(i).Cells("SZ").Value '苏州
                        DataGridView2.Rows(DataGridView2.RowCount - 1).Cells("SZStaffYes").Value = PWDataView.Rows(i).Cells("SZStaffYes").Value '行政人员
                        DataGridView2.Rows(DataGridView2.RowCount - 1).Cells("SZStaffNo").Value = PWDataView.Rows(i).Cells("SZStaffNo").Value  '非行政人员
                        DataGridView2.Rows(DataGridView2.RowCount - 1).Cells("SZSalary").Value = PWDataView.Rows(i).Cells("SZSalary").Value  '薪资
                        DataGridView2.Rows(DataGridView2.RowCount - 1).Cells("SH").Value = PWDataView.Rows(i).Cells("SH").Value '上海
                        DataGridView2.Rows(DataGridView2.RowCount - 1).Cells("SHStaffYes").Value = PWDataView.Rows(i).Cells("SHStaffYes").Value '行政人员
                        DataGridView2.Rows(DataGridView2.RowCount - 1).Cells("SHStaffNo").Value = PWDataView.Rows(i).Cells("SHStaffNo").Value  '非行政人员
                        DataGridView2.Rows(DataGridView2.RowCount - 1).Cells("SHSalary").Value = PWDataView.Rows(i).Cells("SHSalary").Value  '薪资
                    Next
                End If
                DataGridViewSet.AutoMode(Me.DataGridView2)
                DataGridViewLocation = e.Cell.RowIndex
            End If
        End If

    End Sub

    'DataGridView1行变更时
    Private Sub DataGridView1_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DataGridView1.RowStateChanged

        If e.Row.Selected = True Then


        End If

    End Sub

    'DataGridView1的勾选框
    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

        If ModifySave <> "3" Then
            Select Case e.ColumnIndex
                Case 3
                    If DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "False" Or DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "" Then
                        DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "True"
                    Else
                        DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "False"
                    End If

            End Select
        End If

    End Sub

    Private Sub DataGridView1_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged

        If ModifySave <> "3" Then
            Select Case e.ColumnIndex
                Case 3
                    If Array.IndexOf(PWAllCmdName, DataGridView1.Rows(e.RowIndex).Cells("FormCmd").Value) >= 0 Then
                        For i As Integer = Array.IndexOf(PWAllCmdName, DataGridView1.Rows(e.RowIndex).Cells("FormCmd").Value) To Array.LastIndexOf(PWAllCmdName, DataGridView1.Rows(e.RowIndex).Cells("FormCmd").Value)
                            PWDataView.Rows(i).Cells(DataGridView1.Columns(e.ColumnIndex).Name).Value = DataGridView1.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
                        Next
                    End If
            End Select
        End If


    End Sub

    'DataGridView2的勾选框
    Private Sub DataGridView2_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

        If ModifySave <> "3" Then
            Select Case e.ColumnIndex
                Case 3, 4, 5, 6, 7, 8, 9, 10, 11
                    If DataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "False" Or DataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "" Then
                        DataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "True"
                    Else
                        DataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = "False"
                    End If
            End Select

        End If

    End Sub

    Private Sub DataGridView2_CellValueChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellValueChanged

        If ModifySave <> "3" Then
            Select Case e.ColumnIndex
                Case 3, 4, 5, 6, 7, 8, 9, 10, 11
                    PWDataView.Rows(Val(DataGridView2.Rows(e.RowIndex).Cells("XH_No").Value)).Cells(DataGridView2.Columns(e.ColumnIndex).Name).Value = DataGridView2.Rows(e.RowIndex).Cells(e.ColumnIndex).Value

            End Select
        End If

    End Sub

    'DataGridView3行变更时
    Private Sub DataGridView3_RowStateChanged(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowStateChangedEventArgs) Handles DataGridView3.RowStateChanged

        If e.Row.Selected = True Then

            User_No_Text.Text = RTrim(DataGridView3.Rows(e.Row.Index).Cells("User_No").Value)        '员工编号     'UserTA.User_No
            User_Name_Text.Text = RTrim(DataGridView3.Rows(e.Row.Index).Cells("User_Name").Value)     '员工姓名     'UserTA.User_Name
            User_Pwd_Text.Text = RTrim(DataGridView3.Rows(e.Row.Index).Cells("User_Pwd").Value)      '密码     'UserTA.User_Pwd
            DoUser_Pwd_Text.Text = RTrim(DataGridView3.Rows(e.Row.Index).Cells("User_Pwd").Value)
            User_Dep_Text.Text = RTrim(DataGridView3.Rows(e.Row.Index).Cells("User_Dep").Value)     '部门    'UserTA.User_Dep

            Dim FormCmdAllCmd() As String

            ReDim FormCmdAllCmd(PWDataView.RowCount - 1)

            For i As Integer = 0 To PWDataView.RowCount - 1
                FormCmdAllCmd(i) = RTrim(PWDataView.Rows(i).Cells("FormCmd").Value) & RTrim(PWDataView.Rows(i).Cells("AllCmd").Value)
                '按钮名称不动，其余写上False
                PWDataView.Rows(i).Cells("FormCmdOpen").Value = "False" '操作
                PWDataView.Rows(i).Cells("AllCmdOpen").Value = "False" '操作
                PWDataView.Rows(i).Cells("SZ").Value = "False" '苏州
                PWDataView.Rows(i).Cells("SZStaffYes").Value = "False" '行政人员
                PWDataView.Rows(i).Cells("SZStaffNo").Value = "False" '非行政人员
                PWDataView.Rows(i).Cells("SZSalary").Value = "False" '薪资
                PWDataView.Rows(i).Cells("SH").Value = "False" '上海
                PWDataView.Rows(i).Cells("SHStaffYes").Value = "False" '行政人员
                PWDataView.Rows(i).Cells("SHStaffNo").Value = "False" '非行政人员
                PWDataView.Rows(i).Cells("SHSalary").Value = "False" '薪资
                PWDataView.Rows(i).Cells("NewOld").Value = "N" 'N新Y旧资料
            Next


            AAA = " AND VBUserB.User_No = '" & RTrim(DataGridView3.Rows(e.Row.Index).Cells("User_No").Value) & "' "

            Class_SQL.VBUserBLoad(AForm:=Me)

            Dim DSTablesName As String = "VBUserBLoad"
            Dim IntTemp As Integer = 0

            If Class_SQL.DS1.Tables(DSTablesName).Rows.Count > 0 Then

                For i As Integer = 0 To Class_SQL.DS1.Tables(DSTablesName).Rows.Count - 1

                    If Array.IndexOf(FormCmdAllCmd, RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("FormCmd").ToString) & RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("AllCmd").ToString)) >= 0 Then

                        IntTemp = Array.IndexOf(FormCmdAllCmd, RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("FormCmd").ToString) & RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("AllCmd").ToString))

                        PWDataView.Rows(IntTemp).Cells("FormCmdOpen").Value = IIf(RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("FormCmdOpen").ToString) = "Y", "True", "False") '操作
                        PWDataView.Rows(IntTemp).Cells("AllCmdOpen").Value = IIf(RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("AllCmdOpen").ToString) = "Y", "True", "False") '操作
                        PWDataView.Rows(IntTemp).Cells("SZ").Value = IIf(RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("SZ").ToString) = "Y", "True", "False") '苏州
                        PWDataView.Rows(IntTemp).Cells("SZStaffYes").Value = IIf(RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("SZStaffYes").ToString) = "Y", "True", "False") '行政人员
                        PWDataView.Rows(IntTemp).Cells("SZStaffNo").Value = IIf(RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("SZStaffNo").ToString) = "Y", "True", "False") '非行政人员
                        PWDataView.Rows(IntTemp).Cells("SZSalary").Value = IIf(RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("SZSalary").ToString) = "Y", "True", "False") '薪资
                        PWDataView.Rows(IntTemp).Cells("SH").Value = IIf(RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("SH").ToString) = "Y", "True", "False") '上海
                        PWDataView.Rows(IntTemp).Cells("SHStaffYes").Value = IIf(RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("SHStaffYes").ToString) = "Y", "True", "False") '行政人员
                        PWDataView.Rows(IntTemp).Cells("SHStaffNo").Value = IIf(RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("SHStaffNo").ToString) = "Y", "True", "False") '非行政人员
                        PWDataView.Rows(IntTemp).Cells("SHSalary").Value = IIf(RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("SHSalary").ToString) = "Y", "True", "False") '薪资
                        PWDataView.Rows(IntTemp).Cells("NewOld").Value = "Y" 'N新Y旧资料
                    End If
                Next

                DataGridViewSet.ClearRows(DataGridView1)
                Me.DataGridView1.DefaultCellStyle.Font = New System.Drawing.Font(Me.DataGridView1.DefaultCellStyle.Font.FontFamily, "12")

                '其余按钮在'DataGridView1单元格焦点变更时再载入
                For i As Integer = 0 To PWDataView.RowCount - 1

                    If i = 0 Or PWDataView.Rows(i).Cells("FormCmd").Value <> PWDataView.Rows(IIf(i = 0, i, i - 1)).Cells("FormCmd").Value Then
                        DataGridView1.Rows.Add()
                        DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("XH_No").Value = PWDataView.Rows(i).Cells("XH_No").Value
                        DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("FormCmd").Value = PWDataView.Rows(i).Cells("FormCmd").Value
                        DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("FormCmdName").Value = PWDataView.Rows(i).Cells("FormCmdName").Value
                        DataGridView1.Rows(DataGridView1.RowCount - 1).Cells("FormCmdOpen").Value = PWDataView.Rows(i).Cells("FormCmdOpen").Value

                    End If
                Next

                'DataGridViewSet.AutoMode(Me.DataGridView1)

                DataGridView1.ClearSelection()
                'Me.DataGridView1.Rows(0).Selected = True
                DataGridViewLocation = -1
                DataGridView1.CurrentCell = DataGridView1.Rows(0).Cells(1)

            End If

        End If

    End Sub


    Private Sub FormCmdOpen_CB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormCmdOpen_CB.CheckedChanged
        If ModifySave <> "3" And DataGridView1.RowCount > 0 Then
            For i As Integer = 0 To DataGridView1.RowCount - 1
                DataGridView1.Rows(i).Cells("FormCmdOpen").Value = FormCmdOpen_CB.Checked.ToString
            Next
        End If
    End Sub

    Private Sub AllCmdOpen_CB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AllCmdOpen_CB.CheckedChanged
        If ModifySave <> "3" And DataGridView2.RowCount > 0 Then
            For i As Integer = 0 To DataGridView2.RowCount - 1
                DataGridView2.Rows(i).Cells("AllCmdOpen").Value = AllCmdOpen_CB.Checked.ToString
            Next
        End If
    End Sub

    Private Sub SZ_CB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SZ_CB.CheckedChanged
        If ModifySave <> "3" And DataGridView2.RowCount > 0 Then
            For i As Integer = 0 To DataGridView2.RowCount - 1
                DataGridView2.Rows(i).Cells("SZ").Value = sender.Checked.ToString
            Next
        End If
    End Sub

    Private Sub SZStaffYes_CB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SZStaffYes_CB.CheckedChanged
        If ModifySave <> "3" And DataGridView2.RowCount > 0 Then
            For i As Integer = 0 To DataGridView2.RowCount - 1
                DataGridView2.Rows(i).Cells("SZStaffYes").Value = sender.Checked.ToString
            Next
        End If
    End Sub

    Private Sub SZStaffNo_CB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SZStaffNo_CB.CheckedChanged
        If ModifySave <> "3" And DataGridView2.RowCount > 0 Then
            For i As Integer = 0 To DataGridView2.RowCount - 1
                DataGridView2.Rows(i).Cells("SZStaffNo").Value = sender.Checked.ToString
            Next
        End If
    End Sub

    Private Sub SZSalary_CB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SZSalary_CB.CheckedChanged
        If ModifySave <> "3" And DataGridView2.RowCount > 0 Then
            For i As Integer = 0 To DataGridView2.RowCount - 1
                DataGridView2.Rows(i).Cells("SZSalary").Value = sender.Checked.ToString
            Next
        End If
    End Sub

    Private Sub SH_CB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SH_CB.CheckedChanged
        If ModifySave <> "3" And DataGridView2.RowCount > 0 Then
            For i As Integer = 0 To DataGridView2.RowCount - 1
                DataGridView2.Rows(i).Cells("SH").Value = sender.Checked.ToString
            Next
        End If
    End Sub

    Private Sub SHStaffYes_CB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SHStaffYes_CB.CheckedChanged
        If ModifySave <> "3" And DataGridView2.RowCount > 0 Then
            For i As Integer = 0 To DataGridView2.RowCount - 1
                DataGridView2.Rows(i).Cells("SHStaffYes").Value = sender.Checked.ToString
            Next
        End If
    End Sub

    Private Sub SHStaffNo_CB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SHStaffNo_CB.CheckedChanged
        If ModifySave <> "3" And DataGridView2.RowCount > 0 Then
            For i As Integer = 0 To DataGridView2.RowCount - 1
                DataGridView2.Rows(i).Cells("SHStaffNo").Value = sender.Checked.ToString
            Next
        End If
    End Sub

    Private Sub SHSalary_CB_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SHSalary_CB.CheckedChanged
        If ModifySave <> "3" And DataGridView2.RowCount > 0 Then
            For i As Integer = 0 To DataGridView2.RowCount - 1
                DataGridView2.Rows(i).Cells("SHSalary").Value = sender.Checked.ToString
            Next
        End If
    End Sub


End Class