Public Class RenYuan_Form

    Public AAA, BBB As String
    Public PEOName, SPEONo, EPEONo, SDep, EDep As String

    Private Sub RenYuan_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '所有按钮 Enabled = False
        Cmd.CmdFalse(AForm:=Me)
        '各按钮依权限开启 Enabled = True
        Cmd.CmdTrue(AForm:=Me)

        Exit_Cmd.Enabled = True

        PEOName_Text.Text = ""
        SPEONo_Text.Text = ""
        EPEONo_Text.Text = ""
        SDep_Text.Text = ""
        EDep_Text.Text = ""
        PEOName_Text.MaxLength = 10
        SPEONo_Text.MaxLength = 10
        EPEONo_Text.MaxLength = 10
        SDep_Text.MaxLength = 10
        EDep_Text.MaxLength = 10

        AAA = " And CodeKind.ScName = '员工属性' "
        Class_SQL.EmployTypeLoad(AForm:=Me)

        '员工属性
        EmployType_CB.Items.Clear()
        EmployType_CB.Items.Add("全部")

        Dim DSTablesName As String = "EmployTypeLoad"

        If Class_SQL.DS1.Tables(DSTablesName).Rows.Count > 0 Then
            For i As Integer = 0 To Class_SQL.DS1.Tables(DSTablesName).Rows.Count - 1
                EmployType_CB.Items.Add(RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("CodeInfoScName").ToString) & "＊" & RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("CodeInfoCodeInfoId").ToString))
            Next
        End If

        EmployType_CB.SelectedIndex = 0

        '-----下拉选单不可新增，修改-----
        EmployType_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList


        '部门List 跟着公司别选项，自动更新
       
        '禁止添加行
        DataGridView1.AllowUserToAddRows = False
        '禁止删除行
        DataGridView1.AllowUserToDeleteRows = False
        '可以调整行大小
        DataGridView1.AllowUserToResizeColumns = True
        '可以调整列大小
        DataGridView1.AllowUserToResizeRows = False


        SZ_Radio.Checked = True
        Company_GB.Enabled = False

        PEOName_Text.Focus()

        '含子部门 的SQL 语法； 不要 + '%' 就是单一部门
        'where  Alias Like (select ABX.Alias FROM [HRMDB].[dbo].[Department] AS ABX where ABX.Name = '生管部') + '%'

    End Sub

    '部门List 双击
    Private Sub Dep_List_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Dep_List.DoubleClick

        SDep_Text.Text = Mid(sender.SelectedItem, 1, 6)
        EDep_Text.Text = Mid(sender.SelectedItem, 1, 6)

    End Sub

    Private Sub SPEONo_Text_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles SPEONo_Text.KeyPress, EPEONo_Text.KeyPress, SDep_Text.KeyPress, EDep_Text.KeyPress, PEOName_Text.KeyPress, EmployType_CB.KeyPress, Serving_CB.KeyPress, Dep_List.KeyPress
        If e.KeyChar = Chr(13) Then SendKeys.Send("{Tab}")
    End Sub

    Private Sub SPEONo_Text_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SPEONo_Text.LostFocus
        If RTrim(sender.text) <> "" Then EPEONo_Text.Text = RTrim(sender.text)
    End Sub

    Private Sub SDep_Text_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles SDep_Text.LostFocus
        If RTrim(sender.text) <> "" Then EDep_Text.Text = RTrim(sender.text)
    End Sub

    '查询
    Private Sub Load_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Load_Cmd.Click

        DataGridViewSet.ClearDataBase(DataGridView1)

        DataGridView1.Columns.Add("XH_No", "序")
        DataGridView1.Columns.Add("员工工号", "员工工号")
        DataGridView1.Columns.Add("员工姓名", "员工姓名")
        DataGridView1.Columns.Add("部门编号", "部门编号")
        DataGridView1.Columns.Add("部门名称", "部门名称")
        DataGridView1.Columns.Add("职称", "职称")
        DataGridView1.Columns.Add("入司日期", "入司日期")
        DataGridView1.Columns.Add("最后工作日", "最后工作日")
        DataGridView1.Columns.Add("员工状态", "员工状态")
        DataGridView1.Columns.Add("员工属性", "员工属性")
        DataGridView1.Columns.Add("公司别", "公司别")

        PEOName = RTrim(PEOName_Text.Text)
        SPEONo = RTrim(SPEONo_Text.Text)
        EPEONo = RTrim(EPEONo_Text.Text)
        SDep = RTrim(SDep_Text.Text)
        EDep = RTrim(EDep_Text.Text)

        If PEOName = "" And SPEONo = "" And EPEONo = "" And SDep = "" And EDep = "" And EmployType_CB.SelectedIndex = 0 Then
            MsgBox("最少要输入一个条件", , "条件")
            SPEONo_Text.Focus()
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

        '员工属性
        Select Case EmployType_CB.SelectedIndex
            Case 0

            Case Else
                AAA = AAA & " And Employee.EmployTypeId = '" & Mid(EmployType_CB.SelectedItem, InStr(EmployType_CB.SelectedItem, "＊") + 1) & "' "

        End Select

        Class_SQL.EmployeeLoad(AForm:=Me)

        Dim DSTablesName As String = "EmployeeLoad"

        If Class_SQL.DS1.Tables(DSTablesName).Rows.Count > 0 Then
            For i As Integer = 0 To Class_SQL.DS1.Tables(DSTablesName).Rows.Count - 1
                DataGridView1.Rows.Add()
              
                DataGridView1.Rows(i).Cells("XH_No").Value = i + 1
                DataGridView1.Rows(i).Cells("员工工号").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("员工工号").ToString)
                DataGridView1.Rows(i).Cells("员工姓名").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("员工姓名").ToString)
                DataGridView1.Rows(i).Cells("职称").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("职称").ToString)
                DataGridView1.Rows(i).Cells("入司日期").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("入司日期")).ToString("yyyy/MM/dd")
                DataGridView1.Rows(i).Cells("最后工作日").Value = Date.Parse(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("最后工作日")).ToString("yyyy/MM/dd")
                DataGridView1.Rows(i).Cells("部门编号").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("部门编号").ToString)
                DataGridView1.Rows(i).Cells("部门名称").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("部门名称").ToString)
                DataGridView1.Rows(i).Cells("员工状态").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("员工状态").ToString)
                DataGridView1.Rows(i).Cells("员工属性").Value = RTrim(Class_SQL.DS1.Tables(DSTablesName).Rows(i).Item("员工属性").ToString)
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