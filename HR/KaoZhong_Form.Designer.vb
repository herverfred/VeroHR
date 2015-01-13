<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class KaoZhong_Form
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
        Me.Load_Cmd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.EDate_Lab = New System.Windows.Forms.Label()
        Me.SDate_Lab = New System.Windows.Forms.Label()
        Me.EDep_Lab = New System.Windows.Forms.Label()
        Me.SDep_Lab = New System.Windows.Forms.Label()
        Me.SPEONo_Text = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.EPEONo_Text = New System.Windows.Forms.TextBox()
        Me.SDate_Text = New System.Windows.Forms.TextBox()
        Me.EDate_Text = New System.Windows.Forms.TextBox()
        Me.PEOName_Text = New System.Windows.Forms.TextBox()
        Me.CardNo_Text = New System.Windows.Forms.TextBox()
        Me.EDep_Text = New System.Windows.Forms.TextBox()
        Me.SDep_Text = New System.Windows.Forms.TextBox()
        Me.Status_GB = New System.Windows.Forms.GroupBox()
        Me.Quit_Radio = New System.Windows.Forms.RadioButton()
        Me.Serving_Radio = New System.Windows.Forms.RadioButton()
        Me.Company_GB = New System.Windows.Forms.GroupBox()
        Me.SH_Radio = New System.Windows.Forms.RadioButton()
        Me.SZ_Radio = New System.Windows.Forms.RadioButton()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Power_Lab = New System.Windows.Forms.Label()
        Me.OutExecl_Cmd = New System.Windows.Forms.Button()
        Me.Exit_Cmd = New System.Windows.Forms.Button()
        Me.Status_GB.SuspendLayout()
        Me.Company_GB.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Load_Cmd
        '
        Me.Load_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Load_Cmd.Location = New System.Drawing.Point(470, 70)
        Me.Load_Cmd.Name = "Load_Cmd"
        Me.Load_Cmd.Size = New System.Drawing.Size(104, 41)
        Me.Load_Cmd.TabIndex = 100
        Me.Load_Cmd.Text = "查询员工"
        Me.Load_Cmd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(382, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 16)
        Me.Label1.TabIndex = 54
        Me.Label1.Text = "起始员工工号"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(382, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 16)
        Me.Label2.TabIndex = 55
        Me.Label2.Text = "截止员工工号"
        '
        'EDate_Lab
        '
        Me.EDate_Lab.AutoSize = True
        Me.EDate_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EDate_Lab.Location = New System.Drawing.Point(5, 41)
        Me.EDate_Lab.Name = "EDate_Lab"
        Me.EDate_Lab.Size = New System.Drawing.Size(104, 16)
        Me.EDate_Lab.TabIndex = 51
        Me.EDate_Lab.Text = "截止入司日期"
        '
        'SDate_Lab
        '
        Me.SDate_Lab.AutoSize = True
        Me.SDate_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SDate_Lab.Location = New System.Drawing.Point(5, 9)
        Me.SDate_Lab.Name = "SDate_Lab"
        Me.SDate_Lab.Size = New System.Drawing.Size(104, 16)
        Me.SDate_Lab.TabIndex = 50
        Me.SDate_Lab.Text = "起始入司日期"
        '
        'EDep_Lab
        '
        Me.EDep_Lab.AutoSize = True
        Me.EDep_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EDep_Lab.Location = New System.Drawing.Point(571, 41)
        Me.EDep_Lab.Name = "EDep_Lab"
        Me.EDep_Lab.Size = New System.Drawing.Size(72, 16)
        Me.EDep_Lab.TabIndex = 57
        Me.EDep_Lab.Text = "截止部门"
        '
        'SDep_Lab
        '
        Me.SDep_Lab.AutoSize = True
        Me.SDep_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SDep_Lab.Location = New System.Drawing.Point(571, 9)
        Me.SDep_Lab.Name = "SDep_Lab"
        Me.SDep_Lab.Size = New System.Drawing.Size(72, 16)
        Me.SDep_Lab.TabIndex = 56
        Me.SDep_Lab.Text = "起始部门"
        '
        'SPEONo_Text
        '
        Me.SPEONo_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SPEONo_Text.Location = New System.Drawing.Point(487, 6)
        Me.SPEONo_Text.Name = "SPEONo_Text"
        Me.SPEONo_Text.Size = New System.Drawing.Size(78, 26)
        Me.SPEONo_Text.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(206, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 52
        Me.Label7.Text = "员工姓名"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label8.Location = New System.Drawing.Point(206, 41)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 53
        Me.Label8.Text = "员工卡号"
        '
        'EPEONo_Text
        '
        Me.EPEONo_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EPEONo_Text.Location = New System.Drawing.Point(487, 38)
        Me.EPEONo_Text.Name = "EPEONo_Text"
        Me.EPEONo_Text.Size = New System.Drawing.Size(78, 26)
        Me.EPEONo_Text.TabIndex = 5
        '
        'SDate_Text
        '
        Me.SDate_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SDate_Text.Location = New System.Drawing.Point(110, 6)
        Me.SDate_Text.Name = "SDate_Text"
        Me.SDate_Text.Size = New System.Drawing.Size(90, 26)
        Me.SDate_Text.TabIndex = 0
        '
        'EDate_Text
        '
        Me.EDate_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EDate_Text.Location = New System.Drawing.Point(110, 38)
        Me.EDate_Text.Name = "EDate_Text"
        Me.EDate_Text.Size = New System.Drawing.Size(90, 26)
        Me.EDate_Text.TabIndex = 1
        '
        'PEOName_Text
        '
        Me.PEOName_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PEOName_Text.Location = New System.Drawing.Point(280, 6)
        Me.PEOName_Text.Name = "PEOName_Text"
        Me.PEOName_Text.Size = New System.Drawing.Size(96, 26)
        Me.PEOName_Text.TabIndex = 2
        '
        'CardNo_Text
        '
        Me.CardNo_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.CardNo_Text.Location = New System.Drawing.Point(280, 38)
        Me.CardNo_Text.Name = "CardNo_Text"
        Me.CardNo_Text.Size = New System.Drawing.Size(96, 26)
        Me.CardNo_Text.TabIndex = 3
        '
        'EDep_Text
        '
        Me.EDep_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.EDep_Text.Location = New System.Drawing.Point(645, 38)
        Me.EDep_Text.Name = "EDep_Text"
        Me.EDep_Text.Size = New System.Drawing.Size(78, 26)
        Me.EDep_Text.TabIndex = 7
        '
        'SDep_Text
        '
        Me.SDep_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SDep_Text.Location = New System.Drawing.Point(645, 6)
        Me.SDep_Text.Name = "SDep_Text"
        Me.SDep_Text.Size = New System.Drawing.Size(78, 26)
        Me.SDep_Text.TabIndex = 6
        '
        'Status_GB
        '
        Me.Status_GB.Controls.Add(Me.Quit_Radio)
        Me.Status_GB.Controls.Add(Me.Serving_Radio)
        Me.Status_GB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Status_GB.Location = New System.Drawing.Point(12, 70)
        Me.Status_GB.Name = "Status_GB"
        Me.Status_GB.Size = New System.Drawing.Size(248, 43)
        Me.Status_GB.TabIndex = 58
        Me.Status_GB.TabStop = False
        Me.Status_GB.Text = "员工状态"
        '
        'Quit_Radio
        '
        Me.Quit_Radio.AutoSize = True
        Me.Quit_Radio.Location = New System.Drawing.Point(150, 17)
        Me.Quit_Radio.Name = "Quit_Radio"
        Me.Quit_Radio.Size = New System.Drawing.Size(90, 20)
        Me.Quit_Radio.TabIndex = 60
        Me.Quit_Radio.TabStop = True
        Me.Quit_Radio.Text = "离职员工"
        Me.Quit_Radio.UseVisualStyleBackColor = True
        '
        'Serving_Radio
        '
        Me.Serving_Radio.AutoSize = True
        Me.Serving_Radio.Location = New System.Drawing.Point(6, 17)
        Me.Serving_Radio.Name = "Serving_Radio"
        Me.Serving_Radio.Size = New System.Drawing.Size(138, 20)
        Me.Serving_Radio.TabIndex = 59
        Me.Serving_Radio.TabStop = True
        Me.Serving_Radio.Text = "试用、正式员工"
        Me.Serving_Radio.UseVisualStyleBackColor = True
        '
        'Company_GB
        '
        Me.Company_GB.Controls.Add(Me.SH_Radio)
        Me.Company_GB.Controls.Add(Me.SZ_Radio)
        Me.Company_GB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Company_GB.Location = New System.Drawing.Point(266, 70)
        Me.Company_GB.Name = "Company_GB"
        Me.Company_GB.Size = New System.Drawing.Size(198, 43)
        Me.Company_GB.TabIndex = 61
        Me.Company_GB.TabStop = False
        Me.Company_GB.Text = "公司别"
        '
        'SH_Radio
        '
        Me.SH_Radio.AutoSize = True
        Me.SH_Radio.Location = New System.Drawing.Point(102, 17)
        Me.SH_Radio.Name = "SH_Radio"
        Me.SH_Radio.Size = New System.Drawing.Size(90, 20)
        Me.SH_Radio.TabIndex = 63
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
        Me.SZ_Radio.TabIndex = 62
        Me.SZ_Radio.TabStop = True
        Me.SZ_Radio.Text = "苏州惠亚"
        Me.SZ_Radio.UseVisualStyleBackColor = True
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
        Me.DataGridView1.Size = New System.Drawing.Size(772, 425)
        Me.DataGridView1.TabIndex = 101
        '
        'Power_Lab
        '
        Me.Power_Lab.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Power_Lab.AutoSize = True
        Me.Power_Lab.Location = New System.Drawing.Point(9, 548)
        Me.Power_Lab.Name = "Power_Lab"
        Me.Power_Lab.Size = New System.Drawing.Size(29, 12)
        Me.Power_Lab.TabIndex = 102
        Me.Power_Lab.Text = "权限"
        '
        'OutExecl_Cmd
        '
        Me.OutExecl_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OutExecl_Cmd.Location = New System.Drawing.Point(580, 70)
        Me.OutExecl_Cmd.Name = "OutExecl_Cmd"
        Me.OutExecl_Cmd.Size = New System.Drawing.Size(104, 41)
        Me.OutExecl_Cmd.TabIndex = 101
        Me.OutExecl_Cmd.Text = "汇出EXCEL"
        Me.OutExecl_Cmd.UseVisualStyleBackColor = True
        '
        'Exit_Cmd
        '
        Me.Exit_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Exit_Cmd.Location = New System.Drawing.Point(690, 70)
        Me.Exit_Cmd.Name = "Exit_Cmd"
        Me.Exit_Cmd.Size = New System.Drawing.Size(82, 41)
        Me.Exit_Cmd.TabIndex = 103
        Me.Exit_Cmd.Text = "离开"
        Me.Exit_Cmd.UseVisualStyleBackColor = True
        '
        'KaoZhong_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.Exit_Cmd)
        Me.Controls.Add(Me.OutExecl_Cmd)
        Me.Controls.Add(Me.Power_Lab)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Company_GB)
        Me.Controls.Add(Me.Status_GB)
        Me.Controls.Add(Me.EDep_Text)
        Me.Controls.Add(Me.SDep_Text)
        Me.Controls.Add(Me.CardNo_Text)
        Me.Controls.Add(Me.PEOName_Text)
        Me.Controls.Add(Me.EDate_Text)
        Me.Controls.Add(Me.SDate_Text)
        Me.Controls.Add(Me.EPEONo_Text)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.SPEONo_Text)
        Me.Controls.Add(Me.EDep_Lab)
        Me.Controls.Add(Me.SDep_Lab)
        Me.Controls.Add(Me.EDate_Lab)
        Me.Controls.Add(Me.SDate_Lab)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Load_Cmd)
        Me.Name = "KaoZhong_Form"
        Me.Text = "考勤软件用"
        Me.Status_GB.ResumeLayout(False)
        Me.Status_GB.PerformLayout()
        Me.Company_GB.ResumeLayout(False)
        Me.Company_GB.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Load_Cmd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents EDate_Lab As System.Windows.Forms.Label
    Friend WithEvents SDate_Lab As System.Windows.Forms.Label
    Friend WithEvents EDep_Lab As System.Windows.Forms.Label
    Friend WithEvents SDep_Lab As System.Windows.Forms.Label
    Friend WithEvents SPEONo_Text As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents EPEONo_Text As System.Windows.Forms.TextBox
    Friend WithEvents SDate_Text As System.Windows.Forms.TextBox
    Friend WithEvents EDate_Text As System.Windows.Forms.TextBox
    Friend WithEvents PEOName_Text As System.Windows.Forms.TextBox
    Friend WithEvents CardNo_Text As System.Windows.Forms.TextBox
    Friend WithEvents EDep_Text As System.Windows.Forms.TextBox
    Friend WithEvents SDep_Text As System.Windows.Forms.TextBox
    Friend WithEvents Status_GB As System.Windows.Forms.GroupBox
    Friend WithEvents Quit_Radio As System.Windows.Forms.RadioButton
    Friend WithEvents Serving_Radio As System.Windows.Forms.RadioButton
    Friend WithEvents Company_GB As System.Windows.Forms.GroupBox
    Friend WithEvents SH_Radio As System.Windows.Forms.RadioButton
    Friend WithEvents SZ_Radio As System.Windows.Forms.RadioButton
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Power_Lab As System.Windows.Forms.Label
    Friend WithEvents OutExecl_Cmd As System.Windows.Forms.Button
    Friend WithEvents Exit_Cmd As System.Windows.Forms.Button
End Class
