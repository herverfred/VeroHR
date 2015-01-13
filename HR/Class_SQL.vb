Public Class Class_SQL

    '-----SQL语法----
    Public Shared conn As New SqlClient.SqlConnection
    Public Shared SqlDataAdapter As New System.Data.SqlClient.SqlDataAdapter
    Public Shared DS1 As New DataSet
    Public Shared OpenFill As String = ""
    Public Shared SQLSTR As String = ""


   '账号单头（查询）（登入用,不含密码）
    Public Shared Sub VBUserLoad()

        conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=" & Main_Form.HRIPTemp

        OpenFill = "VBUserLoad"

        Dim AAA_Temp As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(DS1.Tables(OpenFill)) Else DS1.Tables.Add(OpenFill)

        'If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA

        SQLSTR = "SELECT VBUserA.User_No, VBUserA.User_Name, VBUserA.User_Dep " &
                 "FROM VBUserA VBUserA " &
                 "WHERE VBUserA.User_No <> '' " & AAA_Temp

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

        Class_SQL.conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=" & Main_Form.HRCatalogTemp & ";Server=" & Main_Form.HRIPTemp

    End Sub

    '账号单头+单身（查询）（登入用,不含密码）
    Public Shared Sub VBUserABLoad(ByVal NameNo As String, ByVal NamePwd As String)

        conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=" & Main_Form.HRIPTemp

        OpenFill = "VBUserABLoad"

        Dim AAA_Temp As String = ""
        Dim PwdCodeing As String = ""
        SQLSTR = ""

        PwdCode(PwdCodeing, NamePwd)

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(DS1.Tables(OpenFill)) Else DS1.Tables.Add(OpenFill)

        'If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA

        SQLSTR = "SELECT VBUserA.User_No, VBUserA.User_Name, VBUserA.User_Dep, VBUserB.FormCmd, VBUserB.AllCmd, VBUserB.FormCmdOpen, VBUserB.AllCmdOpen, " &
                 "VBUserB.SZ, VBUserB.SZStaffYes, VBUserB.SZStaffNo, VBUserB.SZSalary,VBUserB.SH, VBUserB.SHStaffYes, VBUserB.SHStaffNo, VBUserB.SHSalary " &
                 "FROM VBUserA VBUserA LEFT JOIN VBUserB VBUserB ON VBUserA.User_No = VBUserB.User_No " &
                 "WHERE VBUserA.User_No = '" & NameNo & "' AND VBUserA.User_Pwd = '" & PwdCodeing & "'"

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

        Class_SQL.conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=" & Main_Form.HRCatalogTemp & ";Server=" & Main_Form.HRIPTemp

    End Sub

    '账号单头（查询）
    Public Shared Sub VBUserALoad(ByRef AForm)

        conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=" & Main_Form.HRIPTemp

        OpenFill = "VBUserALoad"

        Dim AAA_Temp As String = ""
        Dim PwdDecoding As String = ""
        Dim PwdDecodTemp As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(DS1.Tables(OpenFill)) Else DS1.Tables.Add(OpenFill)

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA

        SQLSTR = "SELECT VBUserA.User_No, VBUserA.User_Name, VBUserA.User_Dep, VBUserA.User_Pwd " &
                 "FROM VBUserA VBUserA " &
                 "WHERE VBUserA.User_No <> '' " & AAA_Temp

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

        If DS1.Tables(OpenFill).Rows.Count > 0 Then
            For i As Integer = 0 To DS1.Tables(OpenFill).Rows.Count - 1
                PwdDecoding = ""
                PwdDecodTemp = Microsoft.VisualBasic.RTrim(DS1.Tables(OpenFill).Rows(i).Item("User_Pwd").ToString)
                PwdDecod(PwdDecoding, PwdDecodTemp)
                DS1.Tables(OpenFill).Rows(i).Item("User_Pwd") = PwdDecoding
            Next
        End If


        Class_SQL.conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=" & Main_Form.HRCatalogTemp & ";Server=" & Main_Form.HRIPTemp

    End Sub

    '账号单头（新增+查询）
    Public Shared Sub VBUserANewSave(ByRef AForm)

        conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=" & Main_Form.HRIPTemp

        OpenFill = "VBUserANewSave"

        Dim AAA_Temp As String = ""
        Dim PwdCodeing As String = ""
        Dim PwdDecoding As String = ""
        Dim PwdDecodTemp As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(OpenFill) Else DS1.Tables.Add(OpenFill)

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA

        PwdCode(PwdCodeing, AForm.User_Pwd)

        '-----修过的-----
        SQLSTR = "INSERT INTO VBUserA (VBUserA.User_No, VBUserA.User_Name, VBUserA.User_Pwd, VBUserA.User_Dep ) " &
            "VALUES ('" & AForm.User_No & "', '" & AForm.User_Name & "', '" & PwdCodeing & "', '" & AForm.User_Dep & "') "

        conn.Open()
        Dim command As SqlClient.SqlCommand = New SqlClient.SqlCommand(SQLSTR, conn)
        command.ExecuteNonQuery()
        conn.Close()

        SQLSTR = "SELECT VBUserA.User_No, VBUserA.User_Name, VBUserA.User_Dep, VBUserA.User_Pwd " &
                 "FROM VBUserA VBUserA " &
                 "WHERE VBUserA.User_No = '" & AForm.User_No & "' "

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

        If DS1.Tables(OpenFill).Rows.Count > 0 Then
            For i As Integer = 0 To DS1.Tables(OpenFill).Rows.Count - 1
                PwdDecoding = ""
                PwdDecodTemp = Microsoft.VisualBasic.RTrim(DS1.Tables(OpenFill).Rows(i).Item("User_Pwd").ToString)
                PwdDecod(PwdDecoding, PwdDecodTemp)
                DS1.Tables(OpenFill).Rows(i).Item("User_Pwd") = PwdDecoding
            Next
        End If

        Class_SQL.conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=" & Main_Form.HRCatalogTemp & ";Server=" & Main_Form.HRIPTemp

    End Sub

    '账号单头（修改+查询）
    Public Shared Sub VBUserAModifySave(ByRef AForm)

        conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=" & Main_Form.HRIPTemp

        OpenFill = "VBUserAModifySave"

        Dim AAA_Temp As String = ""
        Dim PwdCodeing As String = ""
        Dim PwdDecoding As String = ""
        Dim PwdDecodTemp As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(OpenFill) Else DS1.Tables.Add(OpenFill)

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA

        PwdCode(PwdCodeing, AForm.User_Pwd)

        SQLSTR = "UPDATE VBUserA SET VBUserA.User_Name = '" & AForm.User_Name & "', VBUserA.User_Dep = '" & AForm.User_Dep & "', VBUserA.User_Pwd = '" & PwdCodeing & "' " &
                  "WHERE VBUserA.User_No = '" & AForm.User_No & "' "

        conn.Open()
        Dim command As SqlClient.SqlCommand = New SqlClient.SqlCommand(SQLSTR, conn)
        command.ExecuteNonQuery()
        conn.Close()


        SQLSTR = "SELECT VBUserA.User_No, VBUserA.User_Name, VBUserA.User_Dep, VBUserA.User_Pwd " &
                 "FROM VBUserA VBUserA " &
                 "WHERE VBUserA.User_No = '" & AForm.User_No & "' "

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

        If DS1.Tables(OpenFill).Rows.Count > 0 Then
            For i As Integer = 0 To DS1.Tables(OpenFill).Rows.Count - 1
                PwdDecoding = ""
                PwdDecodTemp = Microsoft.VisualBasic.RTrim(DS1.Tables(OpenFill).Rows(i).Item("User_Pwd").ToString)
                PwdDecod(PwdDecoding, PwdDecodTemp)
                DS1.Tables(OpenFill).Rows(i).Item("User_Pwd") = PwdDecoding
            Next
        End If

        Class_SQL.conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=" & Main_Form.HRCatalogTemp & ";Server=" & Main_Form.HRIPTemp

    End Sub

    '账号单头（删除+查询）
    Public Shared Sub VBUserADelete(ByRef AForm)

        conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=" & Main_Form.HRIPTemp

        OpenFill = "VBUserADelete"

        Dim AAA_Temp As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(OpenFill) Else DS1.Tables.Add(OpenFill)

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA

        '-----修过的-----
        SQLSTR = "DELETE FROM VBUserA " &
                 "WHERE " & AAA_Temp

        conn.Open()
        Dim command As SqlClient.SqlCommand = New SqlClient.SqlCommand(SQLSTR, conn)
        command.ExecuteNonQuery()
        conn.Close()


        SQLSTR = "SELECT VBUserA.User_No, VBUserA.User_Name, VBUserA.User_Dep, VBUserA.User_Pwd " &
                 "FROM VBUserA VBUserA " &
                 "WHERE VBUserA.User_No = '" & AForm.User_No & "' "

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

        Class_SQL.conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=" & Main_Form.HRCatalogTemp & ";Server=" & Main_Form.HRIPTemp

    End Sub

    '账号单身（查询）
    Public Shared Sub VBUserBLoad(ByRef AForm)

        conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=" & Main_Form.HRIPTemp

        OpenFill = "VBUserBLoad"

        Dim AAA_Temp As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(OpenFill) Else DS1.Tables.Add(OpenFill)

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA

        SQLSTR = "SELECT VBUserB.User_No, VBUserB.FormCmd, VBUserB.AllCmd, VBUserB.FormCmdOpen, VBUserB.AllCmdOpen, " &
                 "VBUserB.SZ, VBUserB.SZStaffYes, VBUserB.SZStaffNo, VBUserB.SZSalary,VBUserB.SH, VBUserB.SHStaffYes, VBUserB.SHStaffNo, VBUserB.SHSalary " &
                 "FROM VBUserB VBUserB " &
                 "WHERE VBUserB.User_No <> '' " & AAA_Temp

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

        Class_SQL.conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=" & Main_Form.HRCatalogTemp & ";Server=" & Main_Form.HRIPTemp

    End Sub

    '账号单身（新增+查询）
    Public Shared Sub VBUserBNewSave(ByRef AForm)

        conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=" & Main_Form.HRIPTemp

        OpenFill = "VBUserBNewSave"

        Dim AAA_Temp As String = ""
        Dim PwdCodeing As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(OpenFill) Else DS1.Tables.Add(OpenFill)

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA

        SQLSTR = "INSERT INTO VBUserB (VBUserB.User_No, VBUserB.FormCmd, VBUserB.AllCmd, VBUserB.FormCmdOpen, VBUserB.AllCmdOpen, " &
            "VBUserB.SZ, VBUserB.SZStaffYes, VBUserB.SZStaffNo, VBUserB.SZSalary,VBUserB.SH, VBUserB.SHStaffYes, VBUserB.SHStaffNo, VBUserB.SHSalary) " &
            "VALUES ('" & AForm.User_No & "', '" & AForm.FormCmd & "', '" & AForm.AllCmd & "', '" & AForm.FormCmdOpen & "', '" & AForm.AllCmdOpen & "', '" &
            AForm.SZ & "', '" & AForm.SZStaffYes & "', '" & AForm.SZStaffNo & "', '" & AForm.SZSalary & "', '" & AForm.SH & "', '" & AForm.SHStaffYes & "', '" & AForm.SHStaffNo & "', '" & AForm.SHSalary & "') "

        conn.Open()
        Dim command As SqlClient.SqlCommand = New SqlClient.SqlCommand(SQLSTR, conn)
        command.ExecuteNonQuery()
        conn.Close()


        SQLSTR = "SELECT VBUserB.User_No, VBUserB.FormCmd, VBUserB.AllCmd, VBUserB.FormCmdOpen, VBUserB.AllCmdOpen, " &
                 "VBUserB.SZ, VBUserB.SZStaffYes, VBUserB.SZStaffNo, VBUserB.SZSalary,VBUserB.SH, VBUserB.SHStaffYes, VBUserB.SHStaffNo, VBUserB.SHSalary " &
                 "FROM VBUserB VBUserB " &
                 "WHERE VBUserB.User_No = '" & AForm.User_No & "' AND VBUserB.FormCmd = '" & AForm.FormCmd & "' AND VBUserB.AllCmd = '" & AForm.AllCmd & "' "

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

        Class_SQL.conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=" & Main_Form.HRCatalogTemp & ";Server=" & Main_Form.HRIPTemp

    End Sub

    '账号单身（修改+查询）
    Public Shared Sub VBUserBModifySave(ByRef AForm)

        conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=" & Main_Form.HRIPTemp

        OpenFill = "VBUserBModifySave"

        Dim AAA_Temp As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(OpenFill) Else DS1.Tables.Add(OpenFill)

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA

        SQLSTR = "UPDATE VBUserB SET VBUserB.User_No = '" & AForm.User_No & "', VBUserB.FormCmd = '" & AForm.FormCmd & "', VBUserB.AllCmd = '" & AForm.AllCmd & "', VBUserB.FormCmdOpen = '" & AForm.FormCmdOpen &
                 "', VBUserB.AllCmdOpen = '" & AForm.AllCmdOpen & "', VBUserB.SZ = '" & AForm.SZ & "', VBUserB.SZStaffYes = '" & AForm.SZStaffYes & "', VBUserB.SZStaffNo = '" & AForm.SZStaffNo & "', VBUserB.SZSalary = '" & AForm.SZSalary & "', " &
                 "VBUserB.SH = '" & AForm.SH & "', VBUserB.SHStaffYes = '" & AForm.SHStaffYes & "', VBUserB.SHStaffNo = '" & AForm.SHStaffNo & "', VBUserB.SHSalary = '" & AForm.SHSalary & "' " &
                  "WHERE VBUserB.User_No = '" & AForm.User_No & "' AND VBUserB.FormCmd = '" & AForm.FormCmd & "' AND VBUserB.AllCmd = '" & AForm.AllCmd & "' "

        conn.Open()
        Dim command As SqlClient.SqlCommand = New SqlClient.SqlCommand(SQLSTR, conn)
        command.ExecuteNonQuery()
        conn.Close()


        SQLSTR = "SELECT VBUserB.User_No, VBUserB.FormCmd, VBUserB.AllCmd, VBUserB.FormCmdOpen, VBUserB.AllCmdOpen, " &
                 "VBUserB.SZ, VBUserB.SZStaffYes, VBUserB.SZStaffNo, VBUserB.SZSalary,VBUserB.SH, VBUserB.SHStaffYes, VBUserB.SHStaffNo, VBUserB.SHSalary " &
                 "FROM VBUserB VBUserB " &
                 "WHERE VBUserB.User_No = '" & AForm.User_No & "' AND VBUserB.FormCmd = '" & AForm.FormCmd & "' AND VBUserB.AllCmd = '" & AForm.AllCmd & "' "

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

        Class_SQL.conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=" & Main_Form.HRCatalogTemp & ";Server=" & Main_Form.HRIPTemp

    End Sub

    '账号单头（删除+查询）
    Public Shared Sub VBUserBDelete(ByRef AForm)

        conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=" & Main_Form.HRIPTemp

        OpenFill = "VBUserBDelete"

        Dim AAA_Temp As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(OpenFill) Else DS1.Tables.Add(OpenFill)

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA

        '-----修过的-----
        SQLSTR = "DELETE FROM VBUserB " &
                 "WHERE " & AAA_Temp

        conn.Open()
        Dim command As SqlClient.SqlCommand = New SqlClient.SqlCommand(SQLSTR, conn)
        command.ExecuteNonQuery()
        conn.Close()


        SQLSTR = "SELECT VBUserB.User_No, VBUserB.FormCmd, VBUserB.AllCmd, VBUserB.FormCmdOpen, VBUserB.AllCmdOpen, " &
                "VBUserB.SZ, VBUserB.SZStaffYes, VBUserB.SZStaffNo, VBUserB.SZSalary,VBUserB.SH, VBUserB.SHStaffYes, VBUserB.SHStaffNo, VBUserB.SHSalary " &
                "FROM VBUserB VBUserB " &
                "WHERE VBUserB.User_No = '" & AForm.User_No & "' "

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

        Class_SQL.conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=" & Main_Form.HRCatalogTemp & ";Server=" & Main_Form.HRIPTemp

    End Sub

    '-----密码编码-----
    Private Shared Sub PwdCode(ByRef PwdCodeing As String, ByVal PwdCodeTemp As String)

        Dim PwdMu As String = ""

        If PwdCodeTemp <> "" Then

            For i As Integer = 1 To PwdCodeTemp.Length
                PwdMu += Hex(Microsoft.VisualBasic.AscW(Microsoft.VisualBasic.Mid(PwdCodeTemp, i, 1))) & "a"
            Next

            For i As Integer = 1 To PwdMu.Length
                Select Case Microsoft.VisualBasic.Mid(PwdMu, i, 1)
                    Case "0"
                        PwdCodeing += "$"
                    Case "1"
                        PwdCodeing += "!"
                    Case "2"
                        PwdCodeing += "+"
                    Case "3"
                        PwdCodeing += "/"
                    Case "4"
                        PwdCodeing += "*"
                    Case "5"
                        PwdCodeing += ")"
                    Case "6"
                        PwdCodeing += "("
                    Case "7"
                        PwdCodeing += "="
                    Case "8"
                        PwdCodeing += "%"
                    Case "9"
                        PwdCodeing += "@"
                    Case "A"
                        PwdCodeing += ">"
                    Case "B"
                        PwdCodeing += "#"
                    Case "C"
                        PwdCodeing += "<"
                    Case "D"
                        PwdCodeing += "["
                    Case "E"
                        PwdCodeing += "\"
                    Case "F"
                        PwdCodeing += "}"
                    Case "a"
                        PwdCodeing += "."
                    Case Else

                End Select
            Next
        End If

    End Sub

    '-----密码解码-----
    Private Shared Sub PwdDecod(ByRef PwdDecoding As String, ByVal PwdDecodTemp As String)

        Dim abc() As String
        Dim mySplit As Char = "a"
        Dim PwdMu As String = ""

        For i As Integer = 1 To PwdDecodTemp.Length
            Select Case Microsoft.VisualBasic.Mid(PwdDecodTemp, i, 1)
                Case "$"
                    PwdMu += "0"
                Case "!"
                    PwdMu += "1"
                Case "+"
                    PwdMu += "2"
                Case "/"
                    PwdMu += "3"
                Case "*"
                    PwdMu += "4"
                Case ")"
                    PwdMu += "5"
                Case "("
                    PwdMu += "6"
                Case "="
                    PwdMu += "7"
                Case "%"
                    PwdMu += "8"
                Case "@"
                    PwdMu += "9"
                Case ">"
                    PwdMu += "A"
                Case "#"
                    PwdMu += "B"
                Case "<"
                    PwdMu += "C"
                Case "["
                    PwdMu += "D"
                Case "\"
                    PwdMu += "E"
                Case "}"
                    PwdMu += "F"
                Case "."
                    PwdMu += "a"
                Case Else

            End Select
        Next

        abc = PwdMu.Split(mySplit)

        For i As Integer = LBound(abc) To UBound(abc) - 1
            PwdDecoding += ChrW(CInt(String.Format("&h{0}", abc(i))))
        Next

    End Sub

    '卡钟软件查询 ＊＊＊＊＊考勤软件用＊＊＊＊＊
    Public Shared Sub KaoZhongLoad(ByRef AForm)

        OpenFill = "KaoZhongLoad"

        Dim AAA_Temp As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(OpenFill) Else DS1.Tables.Add(OpenFill)

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA
        If AForm.SDate <> "" Then AAA_Temp = AAA_Temp & " AND Employee.Date >= '" & AForm.SDate & "' " '起始入司日期
        If AForm.EDate <> "" Then AAA_Temp = AAA_Temp & " AND Employee.Date <= '" & AForm.EDate & "' " '截止入司日期
        If AForm.PEOName <> "" Then AAA_Temp = AAA_Temp & " AND Employee.CnName = '" & AForm.PEOName & "' " '员工姓名
        If AForm.CardNo <> "" Then AAA_Temp = AAA_Temp & " AND Card.CardNo = '" & AForm.CardNo & "' " '刷卡卡号
        If AForm.SPEONo <> "" Then AAA_Temp = AAA_Temp & " AND Employee.Code >= '" & AForm.SPEONo & "' " '起始员工编号
        If AForm.EPEONo <> "" Then AAA_Temp = AAA_Temp & " AND Employee.Code <= '" & AForm.EPEONo & "' " '截止员工编号
        If AForm.SDep <> "" Then AAA_Temp = AAA_Temp & " AND Department.Code >= '" & AForm.SDep & "' " '起始部门编号
        If AForm.EDep <> "" Then AAA_Temp = AAA_Temp & " AND Department.Code <= '" & AForm.EDep & "' " '截止部门编号


        SQLSTR = "SELECT Employee.Code As EmployeeCode, Employee.CnName As EmployeeCnName, Employee.Date As EmployeeDate, Card.CardNo As CardCardNo, Department.Code As DepartmentCode, Department.Name As DepartmentName, " &
                 "EmployeeState.Name As EmployeeStateName, Corporation.ShortName As CorporationShortName, Job.Name As JobName " &
                 "FROM Employee Left Join Corporation On Employee.CorporationID = Corporation.CorporationID " &
                 "Left Join Job On Employee.JobID = Job.JobID And Employee.CorporationId = Job.CorporationId " &
                 "Left Join Card On Employee.EmployeeId = Card.EmployeeId AND Employee.CorporationId = Card.CorporationId And Card.UseTypeId = 'UseType_001' " &
                 "Left Join Department On Employee.DepartmentId = Department.DepartmentId AND Employee.CorporationId = Department.CorporationId " &
                 "Left Join EmployeeState On Employee.EmployeeStateID = EmployeeState.EmployeeStateID " &
                 "Left Join CodeInfo As CodeInfoB On EmployeeState.EmployeeStateTypeId = CodeInfoB.CodeInfoId " &
                 "WHERE Employee.EmployeeId is not null " & AAA_Temp

        'UseTypeId 好像是区分“待发考勤卡员工”、“已发考勤卡员工”=UseType_001、“已发就餐卡员工”
        'EmployeeState里面的试用员工、正式员工，可以改不同的名字，但是连接到CodeInfo的 试用、正式、离职是不能改的
        '第一个CodeInfo 是为了员工属性，内招、蓝英、希望、润友
        '第二个CodeInfo 是为了员工状态，试用、正式、离职

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()


    End Sub

    '员工属性 ＊＊＊＊＊人员信息＊＊＊＊＊
    Public Shared Sub EmployTypeLoad(ByRef AForm)

        OpenFill = "EmployTypeLoad"

        Dim AAA_Temp As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(OpenFill) Else DS1.Tables.Add(OpenFill)

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA

        SQLSTR = "SELECT CodeInfo.ScName As CodeInfoScName, CodeInfo.CodeInfoId As CodeInfoCodeInfoId " &
                 "From CodeKind Left Join CodeInfo On CodeKind.CodeKindId = CodeInfo.KindCode " &
                 "Where CodeInfo.Enabled = '1' " & AAA_Temp

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

    End Sub

    '部门
    Public Shared Sub DepartmentLoad(ByRef AForm)

        OpenFill = "DepartmentLoad"

        Dim AAA_Temp As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(OpenFill) Else DS1.Tables.Add(OpenFill)

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA

        SQLSTR = "SELECT Department.Code As DepartmentCode, Department.Name As DepartmentName " &
                 "From Department Left Join Corporation On Department.CorporationID = Corporation.CorporationID " &
                 "Where Department.DepartmentId is not null " & AAA_Temp &
                 " Order By Department.Code "

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

    End Sub

    '员工信息
    Public Shared Sub EmployeeLoad(ByRef AForm)

        OpenFill = "EmployeeLoad"

        Dim AAA_Temp As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(OpenFill) Else DS1.Tables.Add(OpenFill)

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA
        If AForm.PEOName <> "" Then AAA_Temp = AAA_Temp & " AND Employee.CnName = '" & AForm.PEOName & "' " '员工姓名
        If AForm.SPEONo <> "" Then AAA_Temp = AAA_Temp & " AND Employee.Code >= '" & AForm.SPEONo & "' " '起始员工编号
        If AForm.EPEONo <> "" Then AAA_Temp = AAA_Temp & " AND Employee.Code <= '" & AForm.EPEONo & "' " '截止员工编号
        If AForm.SDep <> "" Then AAA_Temp = AAA_Temp & " AND Department.Code >= '" & AForm.SDep & "' " '起始部门编号
        If AForm.EDep <> "" Then AAA_Temp = AAA_Temp & " AND Department.Code <= '" & AForm.EDep & "' " '截止部门编号


        SQLSTR = "SELECT Employee.Code As '员工工号', Employee.CnName As '员工姓名', Job.Name As '职称', Employee.Date As '入司日期', Employee.LastWorkDate As '最后工作日', Department.Code As '部门编号', " &
                 "Department.Name As '部门名称', EmployeeState.Name As '员工状态', CodeInfo.ScName As '员工属性', Corporation.ShortName As '公司别' " &
                 "FROM Employee Left Join Corporation On Employee.CorporationID = Corporation.CorporationID " &
                 "Left Join Job On Employee.JobID = Job.JobID And Employee.CorporationId = Job.CorporationId " &
                 "Left Join Department On Employee.DepartmentId = Department.DepartmentId AND Employee.CorporationId = Department.CorporationId " &
                 "Left Join CodeInfo On Employee.EmployTypeId = CodeInfo.CodeInfoId " &
                 "Left Join EmployeeState On Employee.EmployeeStateID = EmployeeState.EmployeeStateID " &
                 "Left Join CodeInfo As CodeInfoB On EmployeeState.EmployeeStateTypeId = CodeInfoB.CodeInfoId " &
                 "WHERE Employee.EmployeeId is not null " & AAA_Temp

        'EmployeeState里面的试用员工、正式员工，可以改不同的名字，但是连接到CodeInfo的 试用、正式、离职是不能改的
        '第一个CodeInfo 是为了员工属性，内招、蓝英、希望、润友
        '第二个CodeInfo 是为了员工状态，试用、正式、离职

        'UseTypeId 好像是区分“待发考勤卡员工”、“已发考勤卡员工”=UseType_001、“已发就餐卡员工”

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

    End Sub

    '点名查询 ＊＊＊＊＊考勤信息＊＊＊＊＊
    Public Shared Sub RollCallLoad(ByRef AForm)

        OpenFill = "RollCallLoad"

        Dim AAA_Temp As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(OpenFill) Else DS1.Tables.Add(OpenFill)

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA
        If AForm.SDate <> "" Then AAA_Temp = AAA_Temp & " AND AttendanceRollcall.Date >= '" & AForm.SDate & "' " '起始入司日期
        If AForm.EDate <> "" Then AAA_Temp = AAA_Temp & " AND AttendanceRollcall.Date <= '" & AForm.EDate & "' " '截止入司日期
        If AForm.PEOName <> "" Then AAA_Temp = AAA_Temp & " AND Employee.CnName = '" & AForm.PEOName & "' " '员工姓名
        If AForm.SPEONo <> "" Then AAA_Temp = AAA_Temp & " AND Employee.Code >= '" & AForm.SPEONo & "' " '起始员工编号
        If AForm.EPEONo <> "" Then AAA_Temp = AAA_Temp & " AND Employee.Code <= '" & AForm.EPEONo & "' " '截止员工编号
        If AForm.SDep <> "" Then AAA_Temp = AAA_Temp & " AND Department.Code >= '" & AForm.SDep & "' " '起始部门编号
        If AForm.EDep <> "" Then AAA_Temp = AAA_Temp & " AND Department.Code <= '" & AForm.EDep & "' " '截止部门编号

        SQLSTR = "SELECT Employee.Code As '员工工号', Employee.CnName As '员工姓名', Job.Name As '职称', Department.Name As '部门名称', AttendanceRollcall.Date As '日期', " &
                 "AttendanceRank.code As '班次', AttendanceType.Name As '假勤名称', AttendanceRollcall.BeginTime As '班次开始时间', AttendanceRollcall.EndTime As '班次结束时间', " &
                 "AttendanceRollcall.CollectBegin As '实际上班刷卡时间', AttendanceRollcall.CollectEnd As '实际下班刷卡时间', " &
                 "AttendanceRollcall.EmpRankCards As '当天有效刷卡', AttendanceRollcall.DailyCards As '当天所有刷卡', Corporation.ShortName As '公司别' " &
                 "From AttendanceRollcall Left Join AttendanceType On AttendanceRollcall.AttendanceTypeId = AttendanceType.AttendanceTypeId " &
                 "Left Join AttendanceRank On AttendanceRollcall.AttendanceRankId = AttendanceRank.AttendanceRankId " &
                 "Left Join Employee On Employee.EmployeeId = AttendanceRollcall.EmployeeId " &
                 "Left Join Corporation On Employee.CorporationID = Corporation.CorporationID " &
                 "Left Join Job On Employee.JobID = Job.JobID And Employee.CorporationId = Job.CorporationId " &
                 "Left Join Department On Employee.DepartmentId = Department.DepartmentId AND Employee.CorporationId = Department.CorporationId " &
                 "Left Join EmployeeState On Employee.EmployeeStateID = EmployeeState.EmployeeStateID " &
                 "Left Join CodeInfo As CodeInfoB On EmployeeState.EmployeeStateTypeId = CodeInfoB.CodeInfoId " &
                 "Where AttendanceRollcall.AttendanceRollcallId is not null " & AAA_Temp

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

    End Sub

    '出勤统计表查询
    Public Shared Sub RollCallReport(ByRef AForm)

        OpenFill = "RollCallReport"

        Dim AAA_Temp As String = ""
        SQLSTR = ""

        If DS1.Tables.CanRemove(DS1.Tables(OpenFill)) = True Then DS1.Tables.Remove(OpenFill) Else DS1.Tables.Add(OpenFill)

        If AForm.AAA <> "" Then AAA_Temp = AAA_Temp & AForm.AAA
        If AForm.SDD <> "yes" Then
            If AForm.SDate <> "" Then AAA_Temp = AAA_Temp & " AND DatePart(yyyy,AttendanceRollcall.Date) = '" & Mid(AForm.SDate, 1, 4) & "' AND DatePart(mm,AttendanceRollcall.Date) = '" & Mid(AForm.SDate, 6, 2) & "' " '起始入司日期
        Else
            If AForm.SDate <> "" Then AAA_Temp = AAA_Temp & " AND DatePart(yyyy,AttendanceRollcall.Date) = '" & Mid(AForm.SDate, 1, 4) & "' AND DatePart(mm,AttendanceRollcall.Date) = '" & Mid(AForm.SDate, 6, 2) & "' AND DatePart(dd,AttendanceRollcall.Date) = '" & Mid(AForm.SDate, 9, 2) & "' " '起始入司日期
        End If
        If AForm.SEDD = "yes" Then
            If AForm.SDate <> "" Then AAA_Temp = AAA_Temp & "and AttendanceRollcall.Date between convert(datetime,'" + AForm.SDate + "',120) and convert(datetime,'" + AForm.EDate + "',120)"
        End If

        'If AForm.EDate <> "" Then AAA_Temp = AAA_Temp & " AND AttendanceRollcall.Date <= '" & AForm.EDate & "' " '截止入司日期
        If AForm.PEOName <> "" Then AAA_Temp = AAA_Temp & " AND Employee.CnName = '" & AForm.PEOName & "' " '员工姓名
        If AForm.SPEONo <> "" Then AAA_Temp = AAA_Temp & " AND Employee.Code >= '" & AForm.SPEONo & "' " '起始员工编号
        If AForm.EPEONo <> "" Then AAA_Temp = AAA_Temp & " AND Employee.Code <= '" & AForm.EPEONo & "' " '截止员工编号
        If AForm.SDep <> "" Then AAA_Temp = AAA_Temp & " AND Department.Code >= '" & AForm.SDep & "' " '起始部门编号
        If AForm.EDep <> "" Then AAA_Temp = AAA_Temp & " AND Department.Code <= '" & AForm.EDep & "' " '截止部门编号

        SQLSTR = "SELECT Employee.Code As '员工工号', Employee.CnName As '员工姓名', Job.Name As '职称', Department.Name As '部门名称', AttendanceRollcall.Date As '日期', " &
                 "(select AttendanceHolidayType.Name From AttendanceCalendar As AttendanceCalendarA Left Join AttendanceHolidayType On AttendanceCalendarA.AttendanceHolidayTypeId = AttendanceHolidayType.AttendanceHolidayTypeId Where AttendanceRollcall.Date = AttendanceCalendarA.Date And Employee.CorporationId = AttendanceCalendarA.CorporationId ) As '节假日', " &
                 "AttendanceRank.code As '班次', AttendanceType.Name As '假勤名称', AttendanceRollcall.BeginTime As '班次开始时间', AttendanceRollcall.EndTime As '班次结束时间', " &
                 "AttendanceRollcall.CollectBegin As '实际上班刷卡时间', AttendanceRollcall.CollectEnd As '实际下班刷卡时间', AttendanceRollcall.IsConfirm As '封存', AttendanceType.Code As '假勤CODE' ," &
                 "AttendanceRollcallDetail.RestCode As '班次班段', AttendanceRollcallDetail.RestName As '班次班段名称', " &
                 "(select AttendanceTypeA.ShortName From AttendanceType As AttendanceTypeA Where AttendanceRollcallDetail.AttendanceTypeId = AttendanceTypeA.AttendanceTypeId) As '班段假勤名称', " &
                 "AttendanceRollcallDetail.Hours As '核算量', AttendanceRollcallDetail.QuartersHours As '实际在岗', " &
                 "(select CodeInfoC.ScName From CodeInfo As CodeInfoC Where AttendanceRollcallDetail.QuartersHoursUnit = CodeInfoC.CodeInfoId) As '单位', " &
                 "AttendanceRollcall.EmpRankCards As '当天有效刷卡', AttendanceRollcall.DailyCards As '当天所有刷卡', Corporation.ShortName As '公司别' , " &
                 "(select AttendanceTypeB.Name From AttendanceType As AttendanceTypeB Left Join AttendanceAllownce On AttendanceTypeB.AttendanceTypeId = AttendanceAllownce.AttendanceTypeId  where AttendanceRollcall.EmployeeId=AttendanceAllownce.EmployeeId   AND AttendanceAllownce.Date = AttendanceRollcall.Date and AttendanceTypeB.Name like '%津贴午餐%') As '中餐', " &
                 "(select AttendanceTypeC.Name From AttendanceType As AttendanceTypeC Left Join AttendanceAllownce On AttendanceTypeC.AttendanceTypeId = AttendanceAllownce.AttendanceTypeId  where AttendanceRollcall.EmployeeId=AttendanceAllownce.EmployeeId   AND AttendanceAllownce.Date = AttendanceRollcall.Date and AttendanceTypeC.Name like '%津贴晚餐%') As '晚餐', " &
                 "(select AttendanceTypeD.Name From AttendanceType As AttendanceTypeD Left Join AttendanceAllownce On AttendanceTypeD.AttendanceTypeId = AttendanceAllownce.AttendanceTypeId  where AttendanceRollcall.EmployeeId=AttendanceAllownce.EmployeeId   AND AttendanceAllownce.Date = AttendanceRollcall.Date and AttendanceTypeD.Name like '%津贴夜宵%') As '夜餐'," &
                 "(select AttendanceTypeE.Name From AttendanceType As AttendanceTypeE Left Join AttendanceAllownce On AttendanceTypeE.AttendanceTypeId = AttendanceAllownce.AttendanceTypeId  where AttendanceRollcall.EmployeeId=AttendanceAllownce.EmployeeId   AND AttendanceAllownce.Date = AttendanceRollcall.Date and AttendanceTypeE.Name like '%特别奖%') As '特别奖'" &
                 "From AttendanceRollcall Left Join AttendanceType On AttendanceRollcall.AttendanceTypeId = AttendanceType.AttendanceTypeId " &
                 "Left Join AttendanceRank On AttendanceRollcall.AttendanceRankId = AttendanceRank.AttendanceRankId " &
                 "Left Join Employee On Employee.EmployeeId = AttendanceRollcall.EmployeeId " &
                 "Left Join Corporation On Employee.CorporationID = Corporation.CorporationID " &
                 "Left Join Job On Employee.JobID = Job.JobID And Employee.CorporationId = Job.CorporationId " &
                 "Left Join Department On Employee.DepartmentId = Department.DepartmentId AND Employee.CorporationId = Department.CorporationId " &
                 "Left Join EmployeeState On Employee.EmployeeStateID = EmployeeState.EmployeeStateID " &
                 "Left Join CodeInfo As CodeInfoB On EmployeeState.EmployeeStateTypeId = CodeInfoB.CodeInfoId " &
                 "Left Join AttendanceRollcallDetail On AttendanceRollcallDetail.AttendanceRollcallId = AttendanceRollcall.AttendanceRollcallId " &
                 "Where AttendanceRollcall.AttendanceRollcallId is not null " & AAA_Temp &
                 " Order By Employee.Code, AttendanceRollcall.Date, AttendanceRollcallDetail.RestCode "

        conn.Open()
        SqlDataAdapter = New SqlClient.SqlDataAdapter(SQLSTR, conn)
        SqlDataAdapter.Fill(DS1, OpenFill)
        conn.Close()

    End Sub

    '上传刷卡记录
    Public Shared Sub UpLoadShKi(ByVal filename As String)

        Dim sda As New SqlClient.SqlDataAdapter
        Dim sqlcomm As New SqlClient.SqlCommandBuilder
        Dim DS1 As New DataSet
        Dim sql As String = ""

        conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=" & Main_Form.HRIPTemp

        '**************************************************
        Dim sr As New IO.StreamReader(filename)
        Dim line As String = ""
        Dim output As String = ""
        Dim dr As DataRow

        '將資料存入dataset
        sql = "select * from ShJuCaiJi"
        sda = New SqlClient.SqlDataAdapter(sql, conn)
        DS1 = New DataSet("ShJuCaiJi")
        sda.Fill(DS1, "ShJuCaiJi")

        '讀取TXT檔並一行一行寫入dataset
        While sr.EndOfStream <> True
            line = sr.ReadLine()
            If line <> vbNullString Then
                output = line
                dr = DS1.Tables("ShJuCaiJi").NewRow
                dr("KiJi") = output.Substring(0, 1)
                dr("KiJiTime") = output.Substring(12, 14)
                dr("GioingHao") = output.Substring(32, 10)
                dr("time") = Date.Now
                DS1.Tables("ShJuCaiJi").Rows.Add(dr)
            End If
        End While
        sr.Close()
        '***************************************************
        '更新資料庫
        sqlcomm = New SqlClient.SqlCommandBuilder(sda)
        sda.Update(DS1.Tables("ShJuCaiJi"))
        DS1.AcceptChanges()
        '***************************************************
        MessageBox.Show("上傳完成")
    End Sub

    '数据采集查询(傳入參數 開始時間，結束時間，上班卡機查詢-布林)
    Public Shared Function ShJuCaiJiSearch(ByVal sn As String, ByVal starttime As String, ByVal endtime As String, Optional ByVal kiji As Boolean = False) As DataSet

        Dim sda As New SqlClient.SqlDataAdapter
        Dim sql As String
        Dim ds As New DataSet("ShJuCaiJi")

        conn.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=" & Main_Form.HRIPTemp

        If sn = "" Then
            sn = " is not null "
        Else
            sn = " = " + sn
        End If

        If starttime <> endtime Then
            endtime = Val(endtime) + 1
            sql = "select * from ShJuCaiJi where GioingHao" + sn + "and KiJiTime between '" + starttime + "%' and '" + endtime.ToString() + "%'"
        Else
            sql = "select * from ShJuCaiJi where GioingHao" + sn + "and KiJiTime like '" + starttime + "%'"
        End If

        Dim a1, a2 As String
        If kiji = True Then
            a1 = "1"
            a2 = "5"
            sql += " and (KiJi = '" + a1 + "' OR KiJi = '" + a2 + "')"
        End If

        sda = New SqlClient.SqlDataAdapter(sql, conn)

        sda.Fill(ds, "ShJuCaiJi")

        conn.Close()
        Return ds
    End Function

    Public Shared Function ShJuCaiJiFilt(ByVal dt As DataTable)

        Dim dt2 As DataTable = New DataTable("ShJuCaiJi")
        dt2.Columns.Add("sn")
        dt2.Columns.Add("KiJi")
        dt2.Columns.Add("KiJiTime")
        dt2.Columns.Add("GioingHao")
        dt2.Columns.Add("time")

        Dim bl As Boolean = True
        For index = 0 To dt.Rows.Count - 1

            For index2 = 0 To dt2.Rows.Count - 1

                'TEST CODE --Tim
                'Dim a = dt.Rows(index)("GioingHao").ToString()
                'If a.Trim() = "0003708010" Then
                '    Console.Write("O YA")
                'End If

                If dt.Rows(index)("GioingHao") = dt2.Rows(index2)("GioingHao") Then
                    If dt.Rows(index)("KiJiTime") = dt2.Rows(index2)("KiJiTime") Then
                        bl = False
                        Exit For
                    End If
                End If

            Next

            If bl Then
                dt2.Rows.Add(dt.Rows(index).ItemArray)
            End If

            bl = True
        Next
        Return dt2
    End Function

    '排班挂载
    '員工資料
    Public Shared Function PaiBanSearch1(ByVal Number As String, ByVal name As String) As DataSet

        Dim c1 As New SqlClient.SqlConnection
        Dim sql As String
        Dim sda As New SqlClient.SqlDataAdapter
        Dim dss1 As DataSet

        c1.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=HRMDB;Server=192.168.2.223"

        If Number = "" Then
            Number = "%"
        End If

        If name = "" Then
            name = "%"
        End If

        sql = "SELECT Employee.Number, Employee.Code, Employee.CnName, Employee_Job_JobId.Name AS Expr9, Employee_EmployeeState_EmployeeStateId.Name AS Expr26, EmployeeDimission.SalaryOver as SalaryOver FROM Employee LEFT OUTER JOIN Job AS Employee_Job_JobId ON Employee.JobId = Employee_Job_JobId.JobId LEFT OUTER JOIN EmployeeState AS Employee_EmployeeState_EmployeeStateId ON Employee.EmployeeStateId = Employee_EmployeeState_EmployeeStateId.EmployeeStateId LEFT OUTER JOIN EmployeeDimission ON Employee.EmployeeId = EmployeeDimission.EmployeeId where Employee_EmployeeState_EmployeeStateId.Name <> '离职员工' OR EmployeeDimission.SalaryOver = 0 AND Employee.Code LIKE '" + Number + "' AND Employee.CnName LIKE '" + name + "'"

        sda = New SqlClient.SqlDataAdapter(sql, c1)
        dss1 = New DataSet("employee")
        sda.Fill(dss1, "employee")

        '傳出dataset
        Return dss1
    End Function

    '排班掛載資料
    Public Shared Function PaiBanSearch2() As DataSet

        Dim c2 As New SqlClient.SqlConnection
        Dim sql2 As String
        Dim sda2 As New SqlClient.SqlDataAdapter
        Dim dss2 As DataSet

        c2.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=192.168.2.223"

        sql2 = "SELECT Number,Code,CnName,JobName,State,Rank FROM PaiBan"

        sda2 = New SqlClient.SqlDataAdapter(sql2, c2)
        dss2 = New DataSet("rank")
        sda2.Fill(dss2, "rank")

        '傳出dataset  
        Return dss2
    End Function

    '排班掛載雙擊事件載入後帶出班次列表與選定的班次
    Public Shared Sub doubleclk(ByVal dgv1 As DataGridView, ByVal dgv2 As DataGridView)

        Dim c1, c2 As New SqlClient.SqlConnection
        Dim sql, sql2 As String
        Dim sda, sda2 As SqlClient.SqlDataAdapter
        Dim ds, ds2 As DataSet

        c1.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=HRMDB;Server=192.168.2.223"
        c2.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=192.168.2.223"
        sql = "SELECT AttendanceRank_Corporation_CorporationId.Name, AttendanceRank.Code, AttendanceRank.Name AS Expr1, AttendanceRank.ShortName,AttendanceRank.WorkBeginTime,AttendanceRank.WorkEndTime FROM AttendanceRank AS AttendanceRank LEFT OUTER JOIN Corporation AS AttendanceRank_Corporation_CorporationId ON AttendanceRank.CorporationId = AttendanceRank_Corporation_CorporationId.CorporationId WHERE AttendanceRank_Corporation_CorporationId.Name <> '集团公司'"
        sql2 = "SELECT Number,Code,CnName,JobName,State,Rank FROM PaiBan"
        dgv2.Rows.Clear()
        dgv2.Columns.Clear()

        sda = New SqlClient.SqlDataAdapter(sql, c1)
        ds = New DataSet("pan")
        ds.Clear()
        sda.Fill(ds, "pan")

        sda2 = New SqlClient.SqlDataAdapter(sql2, c2)
        ds2 = New DataSet("rank")
        ds2.Clear()
        sda2.Fill(ds2, "rank")

        dgv2.RowHeadersVisible = False
        dgv2.Columns.Add("Code", "Code")
        dgv2.Columns("Code").Visible = True
        dgv2.Columns("Code").SortMode = DataGridViewColumnSortMode.Automatic
        dgv2.Columns.Add("Expr1", "班别")
        dgv2.Columns("Expr1").Width = 180
        dgv2.Columns("Expr1").ReadOnly = True
        dgv2.Columns.Add("ShortName", "时间")
        dgv2.Columns("ShortName").Width = 110
        dgv2.Columns("ShortName").ReadOnly = True
        dgv2.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Dim Column1 As System.Windows.Forms.DataGridViewCheckBoxColumn
        Column1 = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Column1.HeaderText = "选取"
        Column1.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        Column1.Name = "ck"
        Column1.ReadOnly = False

        dgv2.Columns.Add(Column1)

        Dim dst As New DataTable()
        dst = ds.Tables("pan")
        '創建欄位
        Dim line As Integer
        For index = 0 To dst.Rows.Count - 1
            line = dgv2.Rows.Add()
            dgv2.Rows(line).Cells("Code").Value = dst.Rows(index)("Code").ToString()
            dgv2.Rows(line).Cells("Expr1").Value = dst.Rows(index)("Expr1").ToString()
            dgv2.Rows(line).Cells("ShortName").Value = dst.Rows(index)("ShortName").ToString()
        Next

        '抓取資料庫資料分割字串勾選checkbox
        If dgv1.SelectedRows(0).DefaultCellStyle.BackColor <> Color.Red Then

            Dim ck() As String
            Dim cka As String = ""

            For index = 0 To ds2.Tables("rank").Rows.Count - 1
                If dgv1.SelectedRows(0).Cells("Number").Value = ds2.Tables("rank").Rows(index)("Number") Then
                    cka = ds2.Tables("rank").Rows(index)("Rank")
                End If
            Next

            '這會包括/右邊空白的一份需要-2
            ck = cka.Split("/")

            For index = 0 To ck.Length - 2
                For index2 = 0 To dgv2.Rows.Count - 1
                    If ck(index) = dgv2.Rows(index2).Cells("Code").Value Then
                        dgv2.Rows(index2).Cells("ck").Value = True
                    End If
                Next
            Next


        End If

    End Sub

    '排班掛載人員排班新增與更新
    Public Shared Sub rankadd(ByVal paiban As Dictionary(Of String, String), ByVal channel As String)
        Dim sql, sql2 As String
        Dim c1 As New SqlClient.SqlConnection
        Dim command As New SqlClient.SqlCommand

        c1.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=VB_DB;Server=192.168.2.223"


        If channel = "insert" Then
            Dim check As String = paiban("Code")
            Dim ds As New DataSet
            Dim sda As New SqlClient.SqlDataAdapter

            sql = "SELECT Code FROM PaiBan"

            sda = New SqlClient.SqlDataAdapter(sql, c1)
            ds = New DataSet("rl")
            ds.Clear()
            sda.Fill(ds, "rl")

            Dim co As Integer = ds.Tables("rl").Select("Code = " + check).Count

            If co >= 1 Then
                channel = "update"
            End If

        End If


        Select Case channel
            Case "insert"
                sql = "insert into paiban values('" + paiban("Number") + "','" + paiban("Code") + "','" + paiban("CnName") + "','" + paiban("jobName") + "','" + paiban("state") + "','" + paiban("Rank") + "')"
                c1.Open()
                command = New SqlClient.SqlCommand(sql, c1)
                command.ExecuteNonQuery()
                c1.Close()
                MessageBox.Show("新增完成")

            Case "update"
                sql2 = "update paiban set rank = '" + paiban("Rank") + "', code = '" + paiban("Code") + "',cnname = '" + paiban("CnName") + "' where Number = '" + paiban("Number") + "'"
                c1.Open()
                command = New SqlClient.SqlCommand(sql2, c1)
                command.ExecuteNonQuery()
                c1.Close()
                MessageBox.Show("修改完成")

        End Select

    End Sub

    '班表種類
    Public Shared Function rankList() As DataSet
        Dim ds As New DataSet
        Dim sql As String = ""
        Dim sda As New SqlClient.SqlDataAdapter
        Dim c1 As New SqlClient.SqlConnection

        c1.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=HRMDB;Server=192.168.2.223"
        sql = "SELECT AttendanceRank_Corporation_CorporationId.Name, AttendanceRank.Code, AttendanceRank.Name AS Expr1, AttendanceRank.ShortName,AttendanceRank.WorkBeginTime,AttendanceRank.WorkEndTime FROM AttendanceRank AS AttendanceRank LEFT OUTER JOIN Corporation AS AttendanceRank_Corporation_CorporationId ON AttendanceRank.CorporationId = AttendanceRank_Corporation_CorporationId.CorporationId WHERE AttendanceRank_Corporation_CorporationId.Name <> '集团公司'"

        sda = New SqlClient.SqlDataAdapter(sql, c1)
        ds = New DataSet("rl")
        ds.Clear()
        sda.Fill(ds, "rl")

        Return ds
    End Function

    '查詢HR行事曆
    Public Shared Function holiday(ByVal starttime As String, ByVal endtime As String) As DataSet
        Dim ds As New DataSet
        Dim sql As String = ""
        Dim sda As New SqlClient.SqlDataAdapter
        Dim c1 As New SqlClient.SqlConnection

        c1.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=HRMDB;Server=192.168.2.223"

        sql = "SELECT AttendanceCalendar.Date , AttendanceCalendar_CodeInfo_YearId.ScName , AttendanceCalendar_AttendanceHolidayType_AttendanceHolidayTypeId.Name AS Expr2 " &
              "FROM AttendanceCalendar AS AttendanceCalendar LEFT OUTER JOIN Corporation AS AttendanceCalendar_Corporation_CorporationId ON AttendanceCalendar.CorporationId = AttendanceCalendar_Corporation_CorporationId.CorporationId LEFT OUTER JOIN CodeInfo AS AttendanceCalendar_CodeInfo_YearId ON AttendanceCalendar.YearId = AttendanceCalendar_CodeInfo_YearId.CodeInfoId LEFT OUTER JOIN CodeInfo AS AttendanceCalendar_CodeInfo_MonthId ON AttendanceCalendar.MonthId = AttendanceCalendar_CodeInfo_MonthId.CodeInfoId LEFT OUTER JOIN AttendanceHolidayType AS AttendanceCalendar_AttendanceHolidayType_AttendanceHolidayTypeId ON AttendanceCalendar.AttendanceHolidayTypeId = AttendanceCalendar_AttendanceHolidayType_AttendanceHolidayTypeId.AttendanceHolidayTypeId " &
              "WHERE AttendanceCalendar_Corporation_CorporationId.Name <> '集团公司' " &
              "and Date between '" + CDate(starttime) + "' and '" + CDate(endtime) + "'"

        sda = New SqlClient.SqlDataAdapter(sql, c1)
        ds = New DataSet("holiday")
        ds.Clear()
        sda.Fill(ds, "holiday")

        Return ds
    End Function

    '依照行事曆篩選休息日
    Public Shared Function hoildayfilt(ByVal list As String, ByVal holiday As String) As String

        Dim work() As String = list.Split("/")
        Dim day As String = holiday
        Dim rank As DataTable = rankList().Tables("rl")
        Dim result As String

        For Each item As String In work
            For index = 0 To rank.Rows.Count - 1
                If item = rank.Rows(index)("Code") Then
                    Dim day2 As String = rank.Rows(index)("Expr1")
                    If day = "工作日" Then
                        If InStr(day2, "休息日") Then

                        Else
                            result += item + "/"
                        End If
                    Else
                        If InStr(day2, "休息日") Then
                            result += item + "/"
                        End If
                    End If
                End If
            Next
        Next

        Return result
    End Function

    '依照卡號搜尋員工工號
    Public Shared Function findGoHo(ByVal sn As String) As String
        Dim goho As String = ""
        Dim ds As New DataSet
        Dim sql As String = ""
        Dim sda As New SqlClient.SqlDataAdapter
        Dim c1 As New SqlClient.SqlConnection

        c1.ConnectionString = "Persist Security Info=False;UID=vb;Password=#szvero#;Initial Catalog=HRMDB;Server=192.168.2.223"

        sql = "SELECT Card_Employee_EmployeeId.Code, Card_Employee_EmployeeId.CnName, Card_Employee_EmployeeId_Department_DepartmentId.Name, " &
              "Card_Employee_EmployeeId_Job_JobId.Name AS Expr1, Card.CardNo, Card.BeginDate, Card.SendDate, Card_Employee_SendEmployeeId.CnName AS Expr2, " &
              "Card.Remark, Card.CardId, Card_User_CreateBy.UserName, Card.CreateDate, Card_User_LastModifiedBy.UserName AS Expr3, Card.LastModifiedDate " &
              "FROM Card AS Card LEFT OUTER JOIN " &
              "Employee AS Card_Employee_EmployeeId ON Card.EmployeeId = Card_Employee_EmployeeId.EmployeeId LEFT OUTER JOIN " &
              "Department AS Card_Employee_EmployeeId_Department_DepartmentId ON " &
              "Card_Employee_EmployeeId.DepartmentId = Card_Employee_EmployeeId_Department_DepartmentId.DepartmentId LEFT OUTER JOIN " &
              "Job AS Card_Employee_EmployeeId_Job_JobId ON Card_Employee_EmployeeId.JobId = Card_Employee_EmployeeId_Job_JobId.JobId LEFT OUTER JOIN " &
              "Employee AS Card_Employee_SendEmployeeId ON Card.SendEmployeeId = Card_Employee_SendEmployeeId.EmployeeId LEFT OUTER JOIN " &
              "[User] AS Card_User_CreateBy ON Card.CreateBy = Card_User_CreateBy.UserId LEFT OUTER JOIN " &
              "[User] AS Card_User_LastModifiedBy ON Card.LastModifiedBy = Card_User_LastModifiedBy.UserId " &
              "WHERE Card.CardNo = '" + sn + "' " &
              "ORDER BY [Card].BeginDate desc"

        sda = New SqlClient.SqlDataAdapter(sql, c1)
        ds = New DataSet("goho")
        ds.Clear()
        sda.Fill(ds, "goho")

        If ds.Tables("goho").Rows.Count <> 0 Then
            goho = ds.Tables("goho").Rows(0)("Code")
        Else
            goho = "False"
        End If

        Return goho
    End Function
End Class

