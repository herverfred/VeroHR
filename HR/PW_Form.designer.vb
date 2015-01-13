<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PW_Form
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.User_No_Text = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.User_Name_Text = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.User_Dep_Text = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.User_Pwd_Text = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DoUser_Pwd_Text = New System.Windows.Forms.TextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.Exit_Cmd = New System.Windows.Forms.Button()
        Me.Load_Cmd = New System.Windows.Forms.Button()
        Me.Modify_Cmd = New System.Windows.Forms.Button()
        Me.New_Cmd = New System.Windows.Forms.Button()
        Me.SAVE_Cmd = New System.Windows.Forms.Button()
        Me.Discard_Cmd = New System.Windows.Forms.Button()
        Me.DEL_Cmd = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.DataGridView3 = New System.Windows.Forms.DataGridView()
        Me.FormCmdOpen_CB = New System.Windows.Forms.CheckBox()
        Me.AllCmdOpen_CB = New System.Windows.Forms.CheckBox()
        Me.SZStaffYes_CB = New System.Windows.Forms.CheckBox()
        Me.SZStaffNo_CB = New System.Windows.Forms.CheckBox()
        Me.SZSalary_CB = New System.Windows.Forms.CheckBox()
        Me.SZ_CB = New System.Windows.Forms.CheckBox()
        Me.SH_CB = New System.Windows.Forms.CheckBox()
        Me.SHSalary_CB = New System.Windows.Forms.CheckBox()
        Me.SHStaffNo_CB = New System.Windows.Forms.CheckBox()
        Me.SHStaffYes_CB = New System.Windows.Forms.CheckBox()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'User_No_Text
        '
        Me.User_No_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.User_No_Text.Location = New System.Drawing.Point(79, 6)
        Me.User_No_Text.Name = "User_No_Text"
        Me.User_No_Text.Size = New System.Drawing.Size(88, 26)
        Me.User_No_Text.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 100
        Me.Label1.Text = "员工编号"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(173, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 101
        Me.Label2.Text = "员工姓名"
        '
        'User_Name_Text
        '
        Me.User_Name_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.User_Name_Text.Location = New System.Drawing.Point(244, 6)
        Me.User_Name_Text.Name = "User_Name_Text"
        Me.User_Name_Text.Size = New System.Drawing.Size(88, 26)
        Me.User_Name_Text.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(338, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 16)
        Me.Label3.TabIndex = 102
        Me.Label3.Text = "部门"
        '
        'User_Dep_Text
        '
        Me.User_Dep_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.User_Dep_Text.Location = New System.Drawing.Point(378, 6)
        Me.User_Dep_Text.Name = "User_Dep_Text"
        Me.User_Dep_Text.Size = New System.Drawing.Size(88, 26)
        Me.User_Dep_Text.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label4.Location = New System.Drawing.Point(472, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 103
        Me.Label4.Text = "密码"
        '
        'User_Pwd_Text
        '
        Me.User_Pwd_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.User_Pwd_Text.Location = New System.Drawing.Point(513, 6)
        Me.User_Pwd_Text.Name = "User_Pwd_Text"
        Me.User_Pwd_Text.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.User_Pwd_Text.Size = New System.Drawing.Size(88, 26)
        Me.User_Pwd_Text.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label5.Location = New System.Drawing.Point(607, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 16)
        Me.Label5.TabIndex = 104
        Me.Label5.Text = "确认密码"
        '
        'DoUser_Pwd_Text
        '
        Me.DoUser_Pwd_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DoUser_Pwd_Text.Location = New System.Drawing.Point(681, 6)
        Me.DoUser_Pwd_Text.Name = "DoUser_Pwd_Text"
        Me.DoUser_Pwd_Text.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.DoUser_Pwd_Text.Size = New System.Drawing.Size(88, 26)
        Me.DoUser_Pwd_Text.TabIndex = 4
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(315, 413)
        Me.DataGridView1.TabIndex = 23
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.ReadOnly = True
        Me.DataGridView2.RowTemplate.Height = 23
        Me.DataGridView2.Size = New System.Drawing.Size(439, 413)
        Me.DataGridView2.TabIndex = 45
        '
        'Exit_Cmd
        '
        Me.Exit_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Exit_Cmd.Location = New System.Drawing.Point(162, 74)
        Me.Exit_Cmd.Name = "Exit_Cmd"
        Me.Exit_Cmd.Size = New System.Drawing.Size(69, 30)
        Me.Exit_Cmd.TabIndex = 56
        Me.Exit_Cmd.Text = "离开"
        Me.Exit_Cmd.UseVisualStyleBackColor = True
        '
        'Load_Cmd
        '
        Me.Load_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Load_Cmd.Location = New System.Drawing.Point(12, 38)
        Me.Load_Cmd.Name = "Load_Cmd"
        Me.Load_Cmd.Size = New System.Drawing.Size(69, 30)
        Me.Load_Cmd.TabIndex = 50
        Me.Load_Cmd.Text = "查询"
        Me.Load_Cmd.UseVisualStyleBackColor = True
        '
        'Modify_Cmd
        '
        Me.Modify_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Modify_Cmd.Location = New System.Drawing.Point(87, 38)
        Me.Modify_Cmd.Name = "Modify_Cmd"
        Me.Modify_Cmd.Size = New System.Drawing.Size(69, 30)
        Me.Modify_Cmd.TabIndex = 51
        Me.Modify_Cmd.Text = "修改"
        Me.Modify_Cmd.UseVisualStyleBackColor = True
        '
        'New_Cmd
        '
        Me.New_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.New_Cmd.Location = New System.Drawing.Point(162, 38)
        Me.New_Cmd.Name = "New_Cmd"
        Me.New_Cmd.Size = New System.Drawing.Size(69, 30)
        Me.New_Cmd.TabIndex = 52
        Me.New_Cmd.Text = "新增"
        Me.New_Cmd.UseVisualStyleBackColor = True
        '
        'SAVE_Cmd
        '
        Me.SAVE_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SAVE_Cmd.Location = New System.Drawing.Point(237, 38)
        Me.SAVE_Cmd.Name = "SAVE_Cmd"
        Me.SAVE_Cmd.Size = New System.Drawing.Size(69, 30)
        Me.SAVE_Cmd.TabIndex = 53
        Me.SAVE_Cmd.Text = "保存"
        Me.SAVE_Cmd.UseVisualStyleBackColor = True
        '
        'Discard_Cmd
        '
        Me.Discard_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Discard_Cmd.Location = New System.Drawing.Point(12, 74)
        Me.Discard_Cmd.Name = "Discard_Cmd"
        Me.Discard_Cmd.Size = New System.Drawing.Size(69, 30)
        Me.Discard_Cmd.TabIndex = 54
        Me.Discard_Cmd.Text = "放弃"
        Me.Discard_Cmd.UseVisualStyleBackColor = True
        '
        'DEL_Cmd
        '
        Me.DEL_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DEL_Cmd.Location = New System.Drawing.Point(87, 74)
        Me.DEL_Cmd.Name = "DEL_Cmd"
        Me.DEL_Cmd.Size = New System.Drawing.Size(69, 30)
        Me.DEL_Cmd.TabIndex = 55
        Me.DEL_Cmd.Text = "删除"
        Me.DEL_Cmd.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DataGridView1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.DataGridView2)
        Me.SplitContainer1.Size = New System.Drawing.Size(770, 419)
        Me.SplitContainer1.SplitterDistance = 321
        Me.SplitContainer1.TabIndex = 111
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(4, 110)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(778, 449)
        Me.TabControl1.TabIndex = 300
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.SplitContainer1)
        Me.TabPage1.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 26)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(770, 419)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "权限设定"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.DataGridView3)
        Me.TabPage2.Font = New System.Drawing.Font("宋体", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.TabPage2.Location = New System.Drawing.Point(4, 26)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(770, 419)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "资料浏览"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'DataGridView3
        '
        Me.DataGridView3.AllowUserToAddRows = False
        Me.DataGridView3.AllowUserToDeleteRows = False
        Me.DataGridView3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView3.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView3.Name = "DataGridView3"
        Me.DataGridView3.ReadOnly = True
        Me.DataGridView3.RowTemplate.Height = 23
        Me.DataGridView3.Size = New System.Drawing.Size(770, 433)
        Me.DataGridView3.TabIndex = 0
        '
        'FormCmdOpen_CB
        '
        Me.FormCmdOpen_CB.AutoSize = True
        Me.FormCmdOpen_CB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.FormCmdOpen_CB.Location = New System.Drawing.Point(267, 85)
        Me.FormCmdOpen_CB.Name = "FormCmdOpen_CB"
        Me.FormCmdOpen_CB.Size = New System.Drawing.Size(59, 20)
        Me.FormCmdOpen_CB.TabIndex = 301
        Me.FormCmdOpen_CB.Text = "操作"
        Me.FormCmdOpen_CB.UseVisualStyleBackColor = True
        '
        'AllCmdOpen_CB
        '
        Me.AllCmdOpen_CB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AllCmdOpen_CB.AutoSize = True
        Me.AllCmdOpen_CB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.AllCmdOpen_CB.Location = New System.Drawing.Point(392, 60)
        Me.AllCmdOpen_CB.Name = "AllCmdOpen_CB"
        Me.AllCmdOpen_CB.Size = New System.Drawing.Size(59, 20)
        Me.AllCmdOpen_CB.TabIndex = 302
        Me.AllCmdOpen_CB.Text = "操作"
        Me.AllCmdOpen_CB.UseVisualStyleBackColor = True
        '
        'SZStaffYes_CB
        '
        Me.SZStaffYes_CB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SZStaffYes_CB.AutoSize = True
        Me.SZStaffYes_CB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SZStaffYes_CB.Location = New System.Drawing.Point(513, 60)
        Me.SZStaffYes_CB.Name = "SZStaffYes_CB"
        Me.SZStaffYes_CB.Size = New System.Drawing.Size(91, 20)
        Me.SZStaffYes_CB.TabIndex = 304
        Me.SZStaffYes_CB.Text = "行政人员"
        Me.SZStaffYes_CB.UseVisualStyleBackColor = True
        '
        'SZStaffNo_CB
        '
        Me.SZStaffNo_CB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SZStaffNo_CB.AutoSize = True
        Me.SZStaffNo_CB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SZStaffNo_CB.Location = New System.Drawing.Point(610, 60)
        Me.SZStaffNo_CB.Name = "SZStaffNo_CB"
        Me.SZStaffNo_CB.Size = New System.Drawing.Size(107, 20)
        Me.SZStaffNo_CB.TabIndex = 305
        Me.SZStaffNo_CB.Text = "非行政人员"
        Me.SZStaffNo_CB.UseVisualStyleBackColor = True
        '
        'SZSalary_CB
        '
        Me.SZSalary_CB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SZSalary_CB.AutoSize = True
        Me.SZSalary_CB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SZSalary_CB.Location = New System.Drawing.Point(723, 60)
        Me.SZSalary_CB.Name = "SZSalary_CB"
        Me.SZSalary_CB.Size = New System.Drawing.Size(59, 20)
        Me.SZSalary_CB.TabIndex = 306
        Me.SZSalary_CB.Text = "薪资"
        Me.SZSalary_CB.UseVisualStyleBackColor = True
        '
        'SZ_CB
        '
        Me.SZ_CB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SZ_CB.AutoSize = True
        Me.SZ_CB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SZ_CB.Location = New System.Drawing.Point(448, 60)
        Me.SZ_CB.Name = "SZ_CB"
        Me.SZ_CB.Size = New System.Drawing.Size(59, 20)
        Me.SZ_CB.TabIndex = 303
        Me.SZ_CB.Text = "苏州"
        Me.SZ_CB.UseVisualStyleBackColor = True
        '
        'SH_CB
        '
        Me.SH_CB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SH_CB.AutoSize = True
        Me.SH_CB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SH_CB.Location = New System.Drawing.Point(448, 85)
        Me.SH_CB.Name = "SH_CB"
        Me.SH_CB.Size = New System.Drawing.Size(59, 20)
        Me.SH_CB.TabIndex = 307
        Me.SH_CB.Text = "上海"
        Me.SH_CB.UseVisualStyleBackColor = True
        '
        'SHSalary_CB
        '
        Me.SHSalary_CB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SHSalary_CB.AutoSize = True
        Me.SHSalary_CB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SHSalary_CB.Location = New System.Drawing.Point(723, 85)
        Me.SHSalary_CB.Name = "SHSalary_CB"
        Me.SHSalary_CB.Size = New System.Drawing.Size(59, 20)
        Me.SHSalary_CB.TabIndex = 310
        Me.SHSalary_CB.Text = "薪资"
        Me.SHSalary_CB.UseVisualStyleBackColor = True
        '
        'SHStaffNo_CB
        '
        Me.SHStaffNo_CB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SHStaffNo_CB.AutoSize = True
        Me.SHStaffNo_CB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SHStaffNo_CB.Location = New System.Drawing.Point(610, 85)
        Me.SHStaffNo_CB.Name = "SHStaffNo_CB"
        Me.SHStaffNo_CB.Size = New System.Drawing.Size(107, 20)
        Me.SHStaffNo_CB.TabIndex = 309
        Me.SHStaffNo_CB.Text = "非行政人员"
        Me.SHStaffNo_CB.UseVisualStyleBackColor = True
        '
        'SHStaffYes_CB
        '
        Me.SHStaffYes_CB.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SHStaffYes_CB.AutoSize = True
        Me.SHStaffYes_CB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SHStaffYes_CB.Location = New System.Drawing.Point(513, 85)
        Me.SHStaffYes_CB.Name = "SHStaffYes_CB"
        Me.SHStaffYes_CB.Size = New System.Drawing.Size(91, 20)
        Me.SHStaffYes_CB.TabIndex = 308
        Me.SHStaffYes_CB.Text = "行政人员"
        Me.SHStaffYes_CB.UseVisualStyleBackColor = True
        '
        'PW_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.SHSalary_CB)
        Me.Controls.Add(Me.SHStaffNo_CB)
        Me.Controls.Add(Me.SHStaffYes_CB)
        Me.Controls.Add(Me.SH_CB)
        Me.Controls.Add(Me.SZ_CB)
        Me.Controls.Add(Me.SZSalary_CB)
        Me.Controls.Add(Me.SZStaffNo_CB)
        Me.Controls.Add(Me.SZStaffYes_CB)
        Me.Controls.Add(Me.AllCmdOpen_CB)
        Me.Controls.Add(Me.FormCmdOpen_CB)
        Me.Controls.Add(Me.DEL_Cmd)
        Me.Controls.Add(Me.Discard_Cmd)
        Me.Controls.Add(Me.SAVE_Cmd)
        Me.Controls.Add(Me.New_Cmd)
        Me.Controls.Add(Me.Modify_Cmd)
        Me.Controls.Add(Me.Load_Cmd)
        Me.Controls.Add(Me.Exit_Cmd)
        Me.Controls.Add(Me.DoUser_Pwd_Text)
        Me.Controls.Add(Me.User_Pwd_Text)
        Me.Controls.Add(Me.User_Dep_Text)
        Me.Controls.Add(Me.User_Name_Text)
        Me.Controls.Add(Me.User_No_Text)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TabControl1)
        Me.Name = "PW_Form"
        Me.Text = "权限设定"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        Me.SplitContainer1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.DataGridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents User_No_Text As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents User_Name_Text As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents User_Dep_Text As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents User_Pwd_Text As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DoUser_Pwd_Text As System.Windows.Forms.TextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Exit_Cmd As System.Windows.Forms.Button
    Friend WithEvents Load_Cmd As System.Windows.Forms.Button
    Friend WithEvents Modify_Cmd As System.Windows.Forms.Button
    Friend WithEvents New_Cmd As System.Windows.Forms.Button
    Friend WithEvents SAVE_Cmd As System.Windows.Forms.Button
    Friend WithEvents Discard_Cmd As System.Windows.Forms.Button
    Friend WithEvents DEL_Cmd As System.Windows.Forms.Button
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents DataGridView3 As System.Windows.Forms.DataGridView
    Friend WithEvents FormCmdOpen_CB As System.Windows.Forms.CheckBox
    Friend WithEvents AllCmdOpen_CB As System.Windows.Forms.CheckBox
    Friend WithEvents SZStaffYes_CB As System.Windows.Forms.CheckBox
    Friend WithEvents SZStaffNo_CB As System.Windows.Forms.CheckBox
    Friend WithEvents SZSalary_CB As System.Windows.Forms.CheckBox
    Friend WithEvents SZ_CB As System.Windows.Forms.CheckBox
    Friend WithEvents SH_CB As System.Windows.Forms.CheckBox
    Friend WithEvents SHSalary_CB As System.Windows.Forms.CheckBox
    Friend WithEvents SHStaffNo_CB As System.Windows.Forms.CheckBox
    Friend WithEvents SHStaffYes_CB As System.Windows.Forms.CheckBox
End Class
