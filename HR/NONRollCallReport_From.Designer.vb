<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class NONRollCallReport_Form
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
        Me.SDate_Lab = New System.Windows.Forms.Label()
        Me.Load_Cmd = New System.Windows.Forms.Button()
        Me.Print_Cmd = New System.Windows.Forms.Button()
        Me.OutExecl_Cmd = New System.Windows.Forms.Button()
        Me.Exit_Cmd = New System.Windows.Forms.Button()
        Me.SH_Radio = New System.Windows.Forms.RadioButton()
        Me.SZ_Radio = New System.Windows.Forms.RadioButton()
        Me.Company_GB = New System.Windows.Forms.GroupBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Count_Lab = New System.Windows.Forms.Label()
        Me.Power_Lab = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Company_GB.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SDate_Lab
        '
        Me.SDate_Lab.AutoSize = True
        Me.SDate_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.SDate_Lab.Location = New System.Drawing.Point(12, 9)
        Me.SDate_Lab.Name = "SDate_Lab"
        Me.SDate_Lab.Size = New System.Drawing.Size(56, 16)
        Me.SDate_Lab.TabIndex = 417
        Me.SDate_Lab.Text = "年月日"
        '
        'Load_Cmd
        '
        Me.Load_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Load_Cmd.Location = New System.Drawing.Point(231, 69)
        Me.Load_Cmd.Name = "Load_Cmd"
        Me.Load_Cmd.Size = New System.Drawing.Size(74, 33)
        Me.Load_Cmd.TabIndex = 419
        Me.Load_Cmd.Text = "查询"
        Me.Load_Cmd.UseVisualStyleBackColor = True
        '
        'Print_Cmd
        '
        Me.Print_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Print_Cmd.Location = New System.Drawing.Point(332, 70)
        Me.Print_Cmd.Name = "Print_Cmd"
        Me.Print_Cmd.Size = New System.Drawing.Size(74, 33)
        Me.Print_Cmd.TabIndex = 426
        Me.Print_Cmd.Text = "打印"
        Me.Print_Cmd.UseVisualStyleBackColor = True
        '
        'OutExecl_Cmd
        '
        Me.OutExecl_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OutExecl_Cmd.Location = New System.Drawing.Point(429, 70)
        Me.OutExecl_Cmd.Name = "OutExecl_Cmd"
        Me.OutExecl_Cmd.Size = New System.Drawing.Size(91, 33)
        Me.OutExecl_Cmd.TabIndex = 427
        Me.OutExecl_Cmd.Text = "汇出EXCEL"
        Me.OutExecl_Cmd.UseVisualStyleBackColor = True
        '
        'Exit_Cmd
        '
        Me.Exit_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Exit_Cmd.Location = New System.Drawing.Point(539, 70)
        Me.Exit_Cmd.Name = "Exit_Cmd"
        Me.Exit_Cmd.Size = New System.Drawing.Size(74, 33)
        Me.Exit_Cmd.TabIndex = 428
        Me.Exit_Cmd.Text = "离开"
        Me.Exit_Cmd.UseVisualStyleBackColor = True
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
        'Company_GB
        '
        Me.Company_GB.Controls.Add(Me.SH_Radio)
        Me.Company_GB.Controls.Add(Me.SZ_Radio)
        Me.Company_GB.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Company_GB.Location = New System.Drawing.Point(12, 59)
        Me.Company_GB.Name = "Company_GB"
        Me.Company_GB.Size = New System.Drawing.Size(198, 43)
        Me.Company_GB.TabIndex = 429
        Me.Company_GB.TabStop = False
        Me.Company_GB.Text = "公司别"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(6, 111)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(773, 419)
        Me.DataGridView1.TabIndex = 430
        '
        'Count_Lab
        '
        Me.Count_Lab.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Count_Lab.AutoSize = True
        Me.Count_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Count_Lab.Location = New System.Drawing.Point(15, 540)
        Me.Count_Lab.Name = "Count_Lab"
        Me.Count_Lab.Size = New System.Drawing.Size(56, 16)
        Me.Count_Lab.TabIndex = 431
        Me.Count_Lab.Text = "笔数："
        '
        'Power_Lab
        '
        Me.Power_Lab.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Power_Lab.AutoSize = True
        Me.Power_Lab.Location = New System.Drawing.Point(334, 543)
        Me.Power_Lab.Name = "Power_Lab"
        Me.Power_Lab.Size = New System.Drawing.Size(29, 12)
        Me.Power_Lab.TabIndex = 432
        Me.Power_Lab.Text = "权限"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "yyyy/MM/dd"
        Me.DateTimePicker1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(66, 5)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(107, 26)
        Me.DateTimePicker1.TabIndex = 433
        Me.DateTimePicker1.Value = New Date(2014, 5, 4, 0, 0, 0, 0)
        '
        'NONRollCallReport_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.Count_Lab)
        Me.Controls.Add(Me.Power_Lab)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Company_GB)
        Me.Controls.Add(Me.Exit_Cmd)
        Me.Controls.Add(Me.OutExecl_Cmd)
        Me.Controls.Add(Me.Print_Cmd)
        Me.Controls.Add(Me.Load_Cmd)
        Me.Controls.Add(Me.SDate_Lab)
        Me.Name = "NONRollCallReport_Form"
        Me.Text = "无出勤统计表"
        Me.Company_GB.ResumeLayout(False)
        Me.Company_GB.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SDate_Lab As System.Windows.Forms.Label
    Friend WithEvents Load_Cmd As System.Windows.Forms.Button
    Friend WithEvents Print_Cmd As System.Windows.Forms.Button
    Friend WithEvents OutExecl_Cmd As System.Windows.Forms.Button
    Friend WithEvents Exit_Cmd As System.Windows.Forms.Button
    Friend WithEvents SH_Radio As System.Windows.Forms.RadioButton
    Friend WithEvents SZ_Radio As System.Windows.Forms.RadioButton
    Friend WithEvents Company_GB As System.Windows.Forms.GroupBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Count_Lab As System.Windows.Forms.Label
    Friend WithEvents Power_Lab As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
End Class
