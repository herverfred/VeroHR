Public Class LogIN_Form

    Public AAA As String
    Dim LocalIP As String = ""

    Dim LogInAcc() As String
    Dim LogInName() As String

    Private Sub LogIN_Form_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        '取得本机IP
        Dim address() As System.Net.IPAddress
        Dim IPTemp() As String

        address = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList

        For i As Integer = 0 To UBound(address)
            If InStr(address(i).ToString, ".") > 0 Then
                IPTemp = address(i).ToString.Split(".")
                If IPTemp(2) = "0" Or IPTemp(2) = "1" Or IPTemp(2) = "2" Then
                    LocalIP = address(i).ToString
                    Exit For
                End If
            End If
        Next

        If LocalIP = "" Then
            MsgBox("非认可的网段，不能登入", , "网段错误")
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
            Exit Sub
        End If

        If My.Computer.Network.IsAvailable Then
            IPTemp = LocalIP.ToString.Split(".")
            Select Case IPTemp(2)
                Case "0"
                    If My.Computer.Network.Ping("192.168.0.174", 50) Then
                        Me.Label3.Text = "登入上海"
                        Label1.Text = "所在地区：上海   IP：" & LocalIP
                        Main_Form.Local_Lab.Text = "上海"
                        Main_Form.LocalIP_Lab.Text = LocalIP
                        'Main_Form.IP_Lab.Text = "192.168.0.174"
                        Main_Form.Catalog_Lab.Text = "HRMDB"
                    Else
                        MsgBox("找不到上海主机，请重新执行程序")
                        Me.DialogResult = Windows.Forms.DialogResult.Cancel
                        Me.Close()
                        Exit Sub
                    End If
                Case "1"
                    If My.Computer.Network.Ping("192.168.0.174", 50) Then
                        Me.Label3.Text = "登入上海"
                        Label1.Text = "所在地区：台北   IP：" & LocalIP
                        Main_Form.Local_Lab.Text = "台北"
                        Main_Form.LocalIP_Lab.Text = LocalIP
                    Else
                        MsgBox("找不到上海主机，请重新执行程序")
                        Me.DialogResult = Windows.Forms.DialogResult.Cancel
                        Me.Close()
                        Exit Sub
                    End If

                Case "2"
                    If My.Computer.Network.Ping("192.168.2.223", 50) Then
                        Me.Label3.Text = "登入苏州"
                        Label1.Text = "所在地区：苏州   IP：" & LocalIP
                        Main_Form.Local_Lab.Text = "苏州"
                        Main_Form.LocalIP_Lab.Text = LocalIP
                        'Main_Form.IP_Lab.Text = "192.168.2.223"
                        Main_Form.Catalog_Lab.Text = "HRMDB"
                    Else
                        MsgBox("找不到苏州主机，请重新执行程序")
                        Me.DialogResult = Windows.Forms.DialogResult.Cancel
                        Me.Close()
                        Exit Sub
                    End If
            End Select

        Else
            MsgBox("未连接至网络，无法连线", , "网络不通")
            Me.DialogResult = Windows.Forms.DialogResult.Cancel
            Me.Close()
            Exit Sub
        End If


        If Environ("USERNAME") = "82023" Or Environ("USERNAME") = "82020" Then
            If Environ("USERNAME") = "82023" Then
                Main_Form.UserNo_Lab.Text = "82023"
                Main_Form.UserName_Lab.Text = "郭文贤"
            Else
                Main_Form.UserNo_Lab.Text = "82020"
                Main_Form.UserName_Lab.Text = "潘钟镒"
            End If

            Main_Form.UserDep_Lab.Text = "资讯"

            For i As Integer = 0 To Main_Form.UserPermit.RowCount - 1
                Main_Form.UserPermit.Rows(i).Cells("FormCmdOpen").Value = "Y" '操作
                Main_Form.UserPermit.Rows(i).Cells("AllCmdOpen").Value = "Y" '操作
                Main_Form.UserPermit.Rows(i).Cells("SZ").Value = "Y" '苏州
                Main_Form.UserPermit.Rows(i).Cells("SZStaffYes").Value = "Y" '行政人员
                Main_Form.UserPermit.Rows(i).Cells("SZStaffNo").Value = "Y" '非行政人员
                Main_Form.UserPermit.Rows(i).Cells("SZSalary").Value = "Y" '薪资
                Main_Form.UserPermit.Rows(i).Cells("SH").Value = "Y" '上海
                Main_Form.UserPermit.Rows(i).Cells("SHStaffYes").Value = "Y" '行政人员
                Main_Form.UserPermit.Rows(i).Cells("SHStaffNo").Value = "Y" '非行政人员
                Main_Form.UserPermit.Rows(i).Cells("SHSalary").Value = "Y" '薪资
            Next

            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
            Exit Sub
        End If

        UserLoad()


    End Sub

    Private Sub LogName_Text_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LogName_Text.KeyPress
        If e.KeyChar = Chr(13) Then SendKeys.Send("{Tab}")
    End Sub

    Private Sub LogPwd_Text_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles LogPwd_Text.KeyPress
        If e.KeyChar = Chr(13) Then SendKeys.Send("{Tab}")
    End Sub

    Private Sub Confirm_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Confirm_Cmd.Click

        Dim MenuCmdInt As Integer = 0

        If LogName_Text.Text = "" Or LogPwd_Text.Text = "" Then
            MessageBox.Show("账号、密码不可空白")
            LogName_Text.Text = ""
            LogPwd_Text.Text = ""
            LogName_Text.Focus()
            Exit Sub
        End If

        If Array.IndexOf(LogInAcc, RTrim(LogName_Text.Text)) >= 0 Then

            Class_SQL.VBUserABLoad(LogName_Text.Text, LogPwd_Text.Text)

            If Class_SQL.DS1.Tables("VBUserABLoad").Rows.Count > 0 Then

                For i As Integer = 0 To Class_SQL.DS1.Tables("VBUserABLoad").Rows.Count - 1

                    If Array.IndexOf(Main_Form.AllCmd, RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(i).Item("FormCmd").ToString) & RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(i).Item("AllCmd").ToString)) >= 0 Then

                        MenuCmdInt = Array.IndexOf(Main_Form.AllCmd, RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(i).Item("FormCmd").ToString) & RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(i).Item("AllCmd").ToString))

                        Main_Form.UserPermit.Rows(MenuCmdInt).Cells("FormCmdOpen").Value = RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(i).Item("FormCmdOpen").ToString) '操作
                        Main_Form.UserPermit.Rows(MenuCmdInt).Cells("AllCmdOpen").Value = RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(i).Item("AllCmdOpen").ToString) '操作
                        Main_Form.UserPermit.Rows(MenuCmdInt).Cells("SZ").Value = RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(i).Item("SZ").ToString) '苏州
                        Main_Form.UserPermit.Rows(MenuCmdInt).Cells("SZStaffYes").Value = RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(i).Item("SZStaffYes").ToString) '行政人员
                        Main_Form.UserPermit.Rows(MenuCmdInt).Cells("SZStaffNo").Value = RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(i).Item("SZStaffNo").ToString) '非行政人员
                        Main_Form.UserPermit.Rows(MenuCmdInt).Cells("SZSalary").Value = RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(i).Item("SZSalary").ToString) '薪资
                        Main_Form.UserPermit.Rows(MenuCmdInt).Cells("SH").Value = RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(i).Item("SH").ToString) '苏州
                        Main_Form.UserPermit.Rows(MenuCmdInt).Cells("SHStaffYes").Value = RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(i).Item("SHStaffYes").ToString) '行政人员
                        Main_Form.UserPermit.Rows(MenuCmdInt).Cells("SHStaffNo").Value = RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(i).Item("SHStaffNo").ToString) '非行政人员
                        Main_Form.UserPermit.Rows(MenuCmdInt).Cells("SHSalary").Value = RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(i).Item("SHSalary").ToString) '薪资
                    End If

                Next

                Main_Form.UserNo_Lab.Text = RTrim(LogName_Text.Text)
                Main_Form.UserName_Lab.Text = RTrim(Name_Lab.Text)
                Main_Form.UserDep_Lab.Text = RTrim(Class_SQL.DS1.Tables("VBUserABLoad").Rows(0).Item("User_Dep").ToString)

                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()

            Else
                MessageBox.Show("密码错误")
                LogPwd_Text.Text = ""
                LogPwd_Text.Focus()
                Exit Sub
            End If

        Else
            MessageBox.Show("查无此账号")
            LogName_Text.Text = ""
            LogPwd_Text.Text = ""
            LogName_Text.Focus()
            Exit Sub
        End If

    End Sub

    Private Sub Exit_Cmd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Exit_Cmd.Click

        '-----获取对话框的结果（按取消则回传Cancel）-----
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()

    End Sub


    Private Sub LogName_Text_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogName_Text.TextChanged

        Dim X As Integer = 0

        Do
            If RTrim(LogName_Text.Text) = Microsoft.VisualBasic.RTrim(Class_SQL.DS1.Tables("VBUserLoad").Rows(X).Item("User_No").ToString()) Then
                Name_Lab.Text = Microsoft.VisualBasic.RTrim(Class_SQL.DS1.Tables("VBUserLoad").Rows(X).Item("User_Name").ToString())
                Exit Do
            Else
                Name_Lab.Text = ""
            End If
            X += 1
        Loop Until X > Class_SQL.DS1.Tables("VBUserLoad").Rows.Count - 1

    End Sub

    Private Sub UserLoad()

        Class_SQL.VBUserLoad()

        ReDim LogInAcc(Class_SQL.DS1.Tables("VBUserLoad").Rows.Count - 1)
        ReDim LogInName(Class_SQL.DS1.Tables("VBUserLoad").Rows.Count - 1)

        For i As Integer = 0 To Class_SQL.DS1.Tables("VBUserLoad").Rows.Count - 1
            LogInAcc(i) = RTrim(Class_SQL.DS1.Tables("VBUserLoad").Rows(i).Item("User_No").ToString)
            LogInName(i) = RTrim(Class_SQL.DS1.Tables("VBUserLoad").Rows(i).Item("User_Name").ToString)
        Next
    End Sub


End Class