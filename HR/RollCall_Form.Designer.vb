<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RollCall_Form
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
        Me.OutExecl_Cmd = New System.Windows.Forms.Button()
        Me.Serving_CB = New System.Windows.Forms.CheckBox()
        Me.Exit_Cmd = New System.Windows.Forms.Button()
        Me.Load_Cmd = New System.Windows.Forms.Button()
        Me.Company_GB = New System.Windows.Forms.GroupBox()
        Me.SH_Radio = New System.Windows.Forms.RadioButton()
        Me.SZ_Radio = New System.Windows.Forms.RadioButton()
        Me.PEOName_Text = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.EDep_Text = New System.Windows.Forms.TextBox()
        Me.SDep_Text = New System.Windows.Forms.TextBox()
        Me.EPEONo_Text = New System.Windows.Forms.TextBox()
        Me.SPEONo_Text = New System.Windows.Forms.TextBox()
        Me.EDep_Lab = New System.Windows.Forms.Label()
        Me.SDep_Lab = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Dep_List = New System.Windows.Forms.ListBox()
        Me.Count_Lab = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Power_Lab = New System.Windows.Forms.Label()
        Me.EDate_Text = New System.Windows.Forms.TextBox()
        Me.SDate_Text = New System.Windows.Forms.TextBox()
        Me.EDate_Lab = New System.Windows.Forms.Label()
        Me.SDate_Lab = New System.Windows.Forms.Label()
        Me.Company_GB.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OutExecl_Cmd
        '
        Me.OutExecl_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OutExecl_Cmd.Location = New System.Drawing.Point(288, 75)
        Me.OutExecl_Cmd.Name = "OutExecl_Cmd"
        Me.OutExecl_Cmd.Size = New System.Drawing.Size(91, 33)
        Me.OutExecl_Cmd.TabIndex = 101
        Me.OutExecl_Cmd.Text = "汇出EXCEL"
        Me.OutExecl_Cmd.UseVisualStyleBackColor = True
        '
        'Serving_CB
        '
        Me.Serving_CB.AutoSize = True
        Me.Serving_CB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Serving_CB.Location = New System.Drawing.Point(518, 44)
        Me.Serving_CB.Name = "Serving_CB"
        Me.Serving_CB.Size = New System.Drawing.Size(107, 20)
        Me.Serving_CB.TabIndex = 7
        Me.Serving_CB.Text = "含离职员工"
        Me.Serving_CB.UseVisualStyleBackColor = True
        '
        'Exit_Cmd
        '
        Me.Exit_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Exit_Cmd.Location = New System.Drawing.Point(385, 75)
        Me.Exit_Cmd.Name = "Exit_Cmd"
        Me.Exit_Cmd.Size = New System.Drawing.Size(74, 33)
        Me.Exit_Cmd.TabIndex = 102
        Me.Exit_Cmd.Text = "离开"
        Me.Exit_Cmd.UseVisualStyleBackColor = True
        '
        'Load_Cmd
        '
        Me.Load_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Load_Cmd.Location = New System.Drawing.Point(208, 75)
        Me.Load_Cmd.Name = "Load_Cmd"
        Me.Load_Cmd.Size = New System.Drawing.Size(74, 33)
        Me.Load_Cmd.TabIndex = 100
        Me.Load_Cmd.Text = "查询"
        Me.Load_Cmd.UseVisualStyleBackColor = True
        '
        'Company_GB
        '
        Me.Company_GB.Controls.Add(Me.SH_Radio)
        Me.Company_GB.Controls.Add(Me.SZ_Radio)
        Me.Company_GB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Company_GB.Location = New System.Drawing.Point(4, 71)
        Me.Company_GB.Name = "Company_GB"
        Me.Company_GB.Size = New System.Drawing.Size(198, 43)
        Me.Company_GB.TabIndex = 20
        Me.Company_GB.TabStop = False
        Me.Company_GB.Text = "公司别"
        '
        'SH_Radio
        '
        Me.SH_Radio.AutoSize = True
        Me.SH_Radio.Location = New System.Drawing.Point(102, 17)
        Me.SH_Radio.Name = "SH_Radio"
        Me.SH_Radio.Size = New System.Drawing.Size(90, 20)
        Me.SH_Radio.TabIndex = 22
        Me.SH_Radio.TabStop = True
        Me.SH_Radio.Text = "上海惠亚"
        Me.SH_Radio.UseVisualStyleBackColor = True
        '
        'SZ_Radio
        '
        Me.SZ_Radio.AutoSize = True
        Me.SZ_Radio.Location = New System.Drawing.Point(6, 17)
        Me.SZ_Radio.Name = "SZ_Radio"
        Me.SZ_Radio.Size = New System.Drawing.Size(90, 20)
        Me.SZ_Radio.TabIndex = 21
        Me.SZ_Radio.TabStop = True
        Me.SZ_Radio.Text = "苏州惠亚"
        Me.SZ_Radio.UseVisualStyleBackColor = True
        '
        'PEOName_Text
        '
        Me.PEOName_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PEOName_Text.Location = New System.Drawing.Point(590, 6)
        Me.PEOName_Text.Name = "PEOName_Text"
        Me.PEOName_Text.Size = New System.Drawing.Size(96, 26)
        Me.PEOName_Text.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(518, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 307
        Me.Label7.Text = "员工姓名"
        '
        'EDep_Text
        '
        Me.EDep_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EDep_Text.Location = New System.Drawing.Point(434, 38)
        Me.EDep_Text.Name = "EDep_Text"
        Me.EDep_Text.Size = New System.Drawing.Size(78, 26)
        Me.EDep_Text.TabIndex = 5
        '
        'SDep_Text
        '
        Me.SDep_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SDep_Text.Location = New System.Drawing.Point(434, 6)
        Me.SDep_Text.Name = "SDep_Text"
        Me.SDep_Text.Size = New System.Drawing.Size(78, 26)
        Me.SDep_Text.TabIndex = 4
        '
        'EPEONo_Text
        '
        Me.EPEONo_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EPEONo_Text.Location = New System.Drawing.Point(276, 38)
        Me.EPEONo_Text.Name = "EPEONo_Text"
        Me.EPEONo_Text.Size = New System.Drawing.Size(78, 26)
        Me.EPEONo_Text.TabIndex = 3
        '
        'SPEONo_Text
        '
        Me.SPEONo_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SPEONo_Text.Location = New System.Drawing.Point(276, 6)
        Me.SPEONo_Text.Name = "SPEONo_Text"
        Me.SPEONo_Text.Size = New System.Drawing.Size(78, 26)
        Me.SPEONo_Text.TabIndex = 2
        '
        'EDep_Lab
        '
        Me.EDep_Lab.AutoSize = True
        Me.EDep_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EDep_Lab.Location = New System.Drawing.Point(360, 41)
        Me.EDep_Lab.Name = "EDep_Lab"
        Me.EDep_Lab.Size = New System.Drawing.Size(72, 16)
        Me.EDep_Lab.TabIndex = 306
        Me.EDep_Lab.Text = "截止部门"
        '
        'SDep_Lab
        '
        Me.SDep_Lab.AutoSize = True
        Me.SDep_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SDep_Lab.Location = New System.Drawing.Point(360, 9)
        Me.SDep_Lab.Name = "SDep_Lab"
        Me.SDep_Lab.Size = New System.Drawing.Size(72, 16)
        Me.SDep_Lab.TabIndex = 305
        Me.SDep_Lab.Text = "起始部门"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(171, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 304
        Me.Label2.Text = "截止员工工号"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(171, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 303
        Me.Label1.Text = "起始员工工号"
        '
        'Dep_List
        '
        Me.Dep_List.Font = New System.Drawing.Font("宋体", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Dep_List.FormattingEnabled = True
        Me.Dep_List.ItemHeight = 15
        Me.Dep_List.Location = New System.Drawing.Point(622, 34)
        Me.Dep_List.Name = "Dep_List"
        Me.Dep_List.Size = New System.Drawing.Size(156, 79)
        Me.Dep_List.TabIndex = 8
        '
        'Count_Lab
        '
        Me.Count_Lab.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Count_Lab.AutoSize = True
        Me.Count_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Count_Lab.Location = New System.Drawing.Point(8, 542)
        Me.Count_Lab.Name = "Count_Lab"
        Me.Count_Lab.Size = New System.Drawing.Size(56, 16)
        Me.Count_Lab.TabIndex = 400
        Me.Count_Lab.Text = "笔数："
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 119)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(773, 419)
        Me.DataGridView1.TabIndex = 300
        '
        'Power_Lab
        '
        Me.Power_Lab.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Power_Lab.AutoSize = True
        Me.Power_Lab.Location = New System.Drawing.Point(327, 545)
        Me.Power_Lab.Name = "Power_Lab"
        Me.Power_Lab.Size = New System.Drawing.Size(29, 12)
        Me.Power_Lab.TabIndex = 401
        Me.Power_Lab.Text = "权限"
        '
        'EDate_Text
        '
        Me.EDate_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EDate_Text.Location = New System.Drawing.Point(75, 38)
        Me.EDate_Text.Name = "EDate_Text"
        Me.EDate_Text.Size = New System.Drawing.Size(90, 26)
        Me.EDate_Text.TabIndex = 1
        '
        'SDate_Text
        '
        Me.SDate_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SDate_Text.Location = New System.Drawing.Point(75, 6)
        Me.SDate_Text.Name = "SDate_Text"
        Me.SDate_Text.Size = New System.Drawing.Size(90, 26)
        Me.SDate_Text.TabIndex = 0
        '
        'EDate_Lab
        '
        Me.EDate_Lab.AutoSize = True
        Me.EDate_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EDate_Lab.Location = New System.Drawing.Point(3, 41)
        Me.EDate_Lab.Name = "EDate_Lab"
        Me.EDate_Lab.Size = New System.Drawing.Size(72, 16)
        Me.EDate_Lab.TabIndex = 302
        Me.EDate_Lab.Text = "截止日期"
        '
        'SDate_Lab
        '
        Me.SDate_Lab.AutoSize = True
        Me.SDate_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SDate_Lab.Location = New System.Drawing.Point(3, 9)
        Me.SDate_Lab.Name = "SDate_Lab"
        Me.SDate_Lab.Size = New System.Drawing.Size(72, 16)
        Me.SDate_Lab.TabIndex = 301
        Me.SDate_Lab.Text = "起始日期"
        '
        'RollCall_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.EDate_Text)
        Me.Controls.Add(Me.SDate_Text)
        Me.Controls.Add(Me.EDate_Lab)
        Me.Controls.Add(Me.SDate_Lab)
        Me.Controls.Add(Me.Count_Lab)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Power_Lab)
        Me.Controls.Add(Me.Dep_List)
        Me.Controls.Add(Me.OutExecl_Cmd)
        Me.Controls.Add(Me.Serving_CB)
        Me.Controls.Add(Me.Exit_Cmd)
        Me.Controls.Add(Me.Load_Cmd)
        Me.Controls.Add(Me.Company_GB)
        Me.Controls.Add(Me.PEOName_Text)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.EDep_Text)
        Me.Controls.Add(Me.SDep_Text)
        Me.Controls.Add(Me.EPEONo_Text)
        Me.Controls.Add(Me.SPEONo_Text)
        Me.Controls.Add(Me.EDep_Lab)
        Me.Controls.Add(Me.SDep_Lab)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "RollCall_Form"
        Me.Text = "点名"
        Me.Company_GB.ResumeLayout(False)
        Me.Company_GB.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OutExecl_Cmd As System.Windows.Forms.Button
    Friend WithEvents Serving_CB As System.Windows.Forms.CheckBox
    Friend WithEvents Exit_Cmd As System.Windows.Forms.Button
    Friend WithEvents Load_Cmd As System.Windows.Forms.Button
    Friend WithEvents Company_GB As System.Windows.Forms.GroupBox
    Friend WithEvents SH_Radio As System.Windows.Forms.RadioButton
    Friend WithEvents SZ_Radio As System.Windows.Forms.RadioButton
    Friend WithEvents PEOName_Text As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents EDep_Text As System.Windows.Forms.TextBox
    Friend WithEvents SDep_Text As System.Windows.Forms.TextBox
    Friend WithEvents EPEONo_Text As System.Windows.Forms.TextBox
    Friend WithEvents SPEONo_Text As System.Windows.Forms.TextBox
    Friend WithEvents EDep_Lab As System.Windows.Forms.Label
    Friend WithEvents SDep_Lab As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Dep_List As System.Windows.Forms.ListBox
    Friend WithEvents Count_Lab As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Power_Lab As System.Windows.Forms.Label
    Friend WithEvents EDate_Text As System.Windows.Forms.TextBox
    Friend WithEvents SDate_Text As System.Windows.Forms.TextBox
    Friend WithEvents EDate_Lab As System.Windows.Forms.Label
    Friend WithEvents SDate_Lab As System.Windows.Forms.Label
End Class
