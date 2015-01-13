<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main_Form
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
        Me.PW_Cmd = New System.Windows.Forms.Button()
        Me.Exit_Cmd = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Font12_Radio = New System.Windows.Forms.RadioButton()
        Me.Font11_Radio = New System.Windows.Forms.RadioButton()
        Me.Font10_Radio = New System.Windows.Forms.RadioButton()
        Me.Font9_Radio = New System.Windows.Forms.RadioButton()
        Me.Local_Lab = New System.Windows.Forms.Label()
        Me.LocalIP_Lab = New System.Windows.Forms.Label()
        Me.IP1_Lab = New System.Windows.Forms.Label()
        Me.Catalog_Lab = New System.Windows.Forms.Label()
        Me.UserNo_Lab = New System.Windows.Forms.Label()
        Me.UserName_Lab = New System.Windows.Forms.Label()
        Me.UserDep_Lab = New System.Windows.Forms.Label()
        Me.KaoZhong_Cmd = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.RenYuan_Cmd = New System.Windows.Forms.Button()
        Me.PaiBan_Cmd = New System.Windows.Forms.Button()
        Me.RollCall_Cmd = New System.Windows.Forms.Button()
        Me.RollCallReport_Cmd = New System.Windows.Forms.Button()
        Me.NonRollCallReport_cmd = New System.Windows.Forms.Button()
        Me.RenYuanPaiBan_Cmd = New System.Windows.Forms.Button()
        Me.ShJuCaiJi_Cmd = New System.Windows.Forms.Button()
        Me.AllRollCall_Cmd = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PW_Cmd
        '
        Me.PW_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PW_Cmd.Location = New System.Drawing.Point(301, 502)
        Me.PW_Cmd.Name = "PW_Cmd"
        Me.PW_Cmd.Size = New System.Drawing.Size(87, 35)
        Me.PW_Cmd.TabIndex = 0
        Me.PW_Cmd.Text = "权限设定"
        Me.PW_Cmd.UseVisualStyleBackColor = True
        '
        'Exit_Cmd
        '
        Me.Exit_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Exit_Cmd.Location = New System.Drawing.Point(394, 502)
        Me.Exit_Cmd.Name = "Exit_Cmd"
        Me.Exit_Cmd.Size = New System.Drawing.Size(87, 35)
        Me.Exit_Cmd.TabIndex = 1
        Me.Exit_Cmd.Text = "离开"
        Me.Exit_Cmd.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Font12_Radio)
        Me.GroupBox1.Controls.Add(Me.Font11_Radio)
        Me.GroupBox1.Controls.Add(Me.Font10_Radio)
        Me.GroupBox1.Controls.Add(Me.Font9_Radio)
        Me.GroupBox1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(12, 466)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(105, 87)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "字体大小"
        '
        'Font12_Radio
        '
        Me.Font12_Radio.AutoSize = True
        Me.Font12_Radio.Location = New System.Drawing.Point(54, 51)
        Me.Font12_Radio.Name = "Font12_Radio"
        Me.Font12_Radio.Size = New System.Drawing.Size(42, 20)
        Me.Font12_Radio.TabIndex = 3
        Me.Font12_Radio.TabStop = True
        Me.Font12_Radio.Text = "12"
        Me.Font12_Radio.UseVisualStyleBackColor = True
        '
        'Font11_Radio
        '
        Me.Font11_Radio.AutoSize = True
        Me.Font11_Radio.Location = New System.Drawing.Point(54, 25)
        Me.Font11_Radio.Name = "Font11_Radio"
        Me.Font11_Radio.Size = New System.Drawing.Size(42, 20)
        Me.Font11_Radio.TabIndex = 2
        Me.Font11_Radio.TabStop = True
        Me.Font11_Radio.Text = "11"
        Me.Font11_Radio.UseVisualStyleBackColor = True
        '
        'Font10_Radio
        '
        Me.Font10_Radio.AutoSize = True
        Me.Font10_Radio.Location = New System.Drawing.Point(6, 51)
        Me.Font10_Radio.Name = "Font10_Radio"
        Me.Font10_Radio.Size = New System.Drawing.Size(42, 20)
        Me.Font10_Radio.TabIndex = 1
        Me.Font10_Radio.TabStop = True
        Me.Font10_Radio.Text = "10"
        Me.Font10_Radio.UseVisualStyleBackColor = True
        '
        'Font9_Radio
        '
        Me.Font9_Radio.AutoSize = True
        Me.Font9_Radio.Location = New System.Drawing.Point(6, 25)
        Me.Font9_Radio.Name = "Font9_Radio"
        Me.Font9_Radio.Size = New System.Drawing.Size(34, 20)
        Me.Font9_Radio.TabIndex = 0
        Me.Font9_Radio.TabStop = True
        Me.Font9_Radio.Text = "9"
        Me.Font9_Radio.UseVisualStyleBackColor = True
        '
        'Local_Lab
        '
        Me.Local_Lab.AutoSize = True
        Me.Local_Lab.Location = New System.Drawing.Point(123, 521)
        Me.Local_Lab.Name = "Local_Lab"
        Me.Local_Lab.Size = New System.Drawing.Size(35, 12)
        Me.Local_Lab.TabIndex = 3
        Me.Local_Lab.Text = "Local"
        '
        'LocalIP_Lab
        '
        Me.LocalIP_Lab.AutoSize = True
        Me.LocalIP_Lab.Location = New System.Drawing.Point(123, 536)
        Me.LocalIP_Lab.Name = "LocalIP_Lab"
        Me.LocalIP_Lab.Size = New System.Drawing.Size(47, 12)
        Me.LocalIP_Lab.TabIndex = 4
        Me.LocalIP_Lab.Text = "LocalIP"
        '
        'IP1_Lab
        '
        Me.IP1_Lab.AutoSize = True
        Me.IP1_Lab.Location = New System.Drawing.Point(210, 476)
        Me.IP1_Lab.Name = "IP1_Lab"
        Me.IP1_Lab.Size = New System.Drawing.Size(53, 12)
        Me.IP1_Lab.TabIndex = 5
        Me.IP1_Lab.Text = "ServerIP"
        Me.IP1_Lab.Visible = False
        '
        'Catalog_Lab
        '
        Me.Catalog_Lab.AutoSize = True
        Me.Catalog_Lab.Location = New System.Drawing.Point(210, 491)
        Me.Catalog_Lab.Name = "Catalog_Lab"
        Me.Catalog_Lab.Size = New System.Drawing.Size(47, 12)
        Me.Catalog_Lab.TabIndex = 6
        Me.Catalog_Lab.Text = "Catalog"
        Me.Catalog_Lab.Visible = False
        '
        'UserNo_Lab
        '
        Me.UserNo_Lab.AutoSize = True
        Me.UserNo_Lab.Location = New System.Drawing.Point(123, 476)
        Me.UserNo_Lab.Name = "UserNo_Lab"
        Me.UserNo_Lab.Size = New System.Drawing.Size(41, 12)
        Me.UserNo_Lab.TabIndex = 7
        Me.UserNo_Lab.Text = "UserNo"
        '
        'UserName_Lab
        '
        Me.UserName_Lab.AutoSize = True
        Me.UserName_Lab.Location = New System.Drawing.Point(123, 491)
        Me.UserName_Lab.Name = "UserName_Lab"
        Me.UserName_Lab.Size = New System.Drawing.Size(53, 12)
        Me.UserName_Lab.TabIndex = 8
        Me.UserName_Lab.Text = "UserName"
        '
        'UserDep_Lab
        '
        Me.UserDep_Lab.AutoSize = True
        Me.UserDep_Lab.Location = New System.Drawing.Point(123, 506)
        Me.UserDep_Lab.Name = "UserDep_Lab"
        Me.UserDep_Lab.Size = New System.Drawing.Size(47, 12)
        Me.UserDep_Lab.TabIndex = 9
        Me.UserDep_Lab.Text = "UserDep"
        '
        'KaoZhong_Cmd
        '
        Me.KaoZhong_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.KaoZhong_Cmd.Location = New System.Drawing.Point(658, 63)
        Me.KaoZhong_Cmd.Name = "KaoZhong_Cmd"
        Me.KaoZhong_Cmd.Size = New System.Drawing.Size(114, 45)
        Me.KaoZhong_Cmd.TabIndex = 10
        Me.KaoZhong_Cmd.Text = "卡钟软件用"
        Me.KaoZhong_Cmd.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(498, 393)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(274, 166)
        Me.DataGridView1.TabIndex = 11
        Me.DataGridView1.Visible = False
        '
        'RenYuan_Cmd
        '
        Me.RenYuan_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RenYuan_Cmd.Location = New System.Drawing.Point(658, 12)
        Me.RenYuan_Cmd.Name = "RenYuan_Cmd"
        Me.RenYuan_Cmd.Size = New System.Drawing.Size(114, 45)
        Me.RenYuan_Cmd.TabIndex = 12
        Me.RenYuan_Cmd.Text = "人员信息"
        Me.RenYuan_Cmd.UseVisualStyleBackColor = True
        '
        'PaiBan_Cmd
        '
        Me.PaiBan_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PaiBan_Cmd.Location = New System.Drawing.Point(252, 12)
        Me.PaiBan_Cmd.Name = "PaiBan_Cmd"
        Me.PaiBan_Cmd.Size = New System.Drawing.Size(114, 45)
        Me.PaiBan_Cmd.TabIndex = 13
        Me.PaiBan_Cmd.Text = "排班"
        Me.PaiBan_Cmd.UseVisualStyleBackColor = True
        '
        'RollCall_Cmd
        '
        Me.RollCall_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RollCall_Cmd.Location = New System.Drawing.Point(658, 114)
        Me.RollCall_Cmd.Name = "RollCall_Cmd"
        Me.RollCall_Cmd.Size = New System.Drawing.Size(114, 45)
        Me.RollCall_Cmd.TabIndex = 14
        Me.RollCall_Cmd.Text = "点名"
        Me.RollCall_Cmd.UseVisualStyleBackColor = True
        '
        'RollCallReport_Cmd
        '
        Me.RollCallReport_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RollCallReport_Cmd.Location = New System.Drawing.Point(12, 63)
        Me.RollCallReport_Cmd.Name = "RollCallReport_Cmd"
        Me.RollCallReport_Cmd.Size = New System.Drawing.Size(114, 45)
        Me.RollCallReport_Cmd.TabIndex = 15
        Me.RollCallReport_Cmd.Text = " 个人出勤   统计表"
        Me.RollCallReport_Cmd.UseVisualStyleBackColor = True
        '
        'NonRollCallReport_cmd
        '
        Me.NonRollCallReport_cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.NonRollCallReport_cmd.Location = New System.Drawing.Point(132, 63)
        Me.NonRollCallReport_cmd.Name = "NonRollCallReport_cmd"
        Me.NonRollCallReport_cmd.Size = New System.Drawing.Size(114, 45)
        Me.NonRollCallReport_cmd.TabIndex = 16
        Me.NonRollCallReport_cmd.Text = "无出勤统计表"
        Me.NonRollCallReport_cmd.UseVisualStyleBackColor = True
        '
        'RenYuanPaiBan_Cmd
        '
        Me.RenYuanPaiBan_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.RenYuanPaiBan_Cmd.Location = New System.Drawing.Point(132, 12)
        Me.RenYuanPaiBan_Cmd.Name = "RenYuanPaiBan_Cmd"
        Me.RenYuanPaiBan_Cmd.Size = New System.Drawing.Size(114, 45)
        Me.RenYuanPaiBan_Cmd.TabIndex = 17
        Me.RenYuanPaiBan_Cmd.Text = "人员排班挂载"
        Me.RenYuanPaiBan_Cmd.UseVisualStyleBackColor = True
        '
        'ShJuCaiJi_Cmd
        '
        Me.ShJuCaiJi_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.ShJuCaiJi_Cmd.Location = New System.Drawing.Point(12, 12)
        Me.ShJuCaiJi_Cmd.Name = "ShJuCaiJi_Cmd"
        Me.ShJuCaiJi_Cmd.Size = New System.Drawing.Size(114, 45)
        Me.ShJuCaiJi_Cmd.TabIndex = 18
        Me.ShJuCaiJi_Cmd.Text = "数据采集"
        Me.ShJuCaiJi_Cmd.UseVisualStyleBackColor = True
        '
        'AllRollCall_Cmd
        '
        Me.AllRollCall_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.AllRollCall_Cmd.Location = New System.Drawing.Point(252, 63)
        Me.AllRollCall_Cmd.Name = "AllRollCall_Cmd"
        Me.AllRollCall_Cmd.Size = New System.Drawing.Size(114, 45)
        Me.AllRollCall_Cmd.TabIndex = 19
        Me.AllRollCall_Cmd.Text = "出勤日报表"
        Me.AllRollCall_Cmd.UseVisualStyleBackColor = True
        '
        'Main_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.AllRollCall_Cmd)
        Me.Controls.Add(Me.ShJuCaiJi_Cmd)
        Me.Controls.Add(Me.RenYuanPaiBan_Cmd)
        Me.Controls.Add(Me.NonRollCallReport_cmd)
        Me.Controls.Add(Me.RollCallReport_Cmd)
        Me.Controls.Add(Me.RollCall_Cmd)
        Me.Controls.Add(Me.PaiBan_Cmd)
        Me.Controls.Add(Me.RenYuan_Cmd)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.KaoZhong_Cmd)
        Me.Controls.Add(Me.UserDep_Lab)
        Me.Controls.Add(Me.UserName_Lab)
        Me.Controls.Add(Me.UserNo_Lab)
        Me.Controls.Add(Me.Catalog_Lab)
        Me.Controls.Add(Me.IP1_Lab)
        Me.Controls.Add(Me.LocalIP_Lab)
        Me.Controls.Add(Me.Local_Lab)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Exit_Cmd)
        Me.Controls.Add(Me.PW_Cmd)
        Me.Name = "Main_Form"
        Me.Text = "鼎捷人事薪资系统外挂"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PW_Cmd As System.Windows.Forms.Button
    Friend WithEvents Exit_Cmd As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Font12_Radio As System.Windows.Forms.RadioButton
    Friend WithEvents Font11_Radio As System.Windows.Forms.RadioButton
    Friend WithEvents Font10_Radio As System.Windows.Forms.RadioButton
    Friend WithEvents Font9_Radio As System.Windows.Forms.RadioButton
    Friend WithEvents Local_Lab As System.Windows.Forms.Label
    Friend WithEvents LocalIP_Lab As System.Windows.Forms.Label
    Friend WithEvents IP1_Lab As System.Windows.Forms.Label
    Friend WithEvents Catalog_Lab As System.Windows.Forms.Label
    Friend WithEvents UserNo_Lab As System.Windows.Forms.Label
    Friend WithEvents UserName_Lab As System.Windows.Forms.Label
    Friend WithEvents UserDep_Lab As System.Windows.Forms.Label
    Friend WithEvents KaoZhong_Cmd As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents RenYuan_Cmd As System.Windows.Forms.Button
    Friend WithEvents PaiBan_Cmd As System.Windows.Forms.Button
    Friend WithEvents RollCall_Cmd As System.Windows.Forms.Button
    Friend WithEvents RollCallReport_Cmd As System.Windows.Forms.Button
    Friend WithEvents NonRollCallReport_cmd As System.Windows.Forms.Button
    Friend WithEvents RenYuanPaiBan_Cmd As System.Windows.Forms.Button
    Friend WithEvents ShJuCaiJi_Cmd As System.Windows.Forms.Button
    Friend WithEvents AllRollCall_Cmd As System.Windows.Forms.Button

End Class
