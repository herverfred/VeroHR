<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PaiBan_Form
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
        Me.PEOName_Text = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.User_No_Text = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.EndTime = New System.Windows.Forms.DateTimePicker()
        Me.StartTime = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.OutExecl_Cmd = New System.Windows.Forms.Button()
        Me.Load_Cmd = New System.Windows.Forms.Button()
        Me.Exit_Cmd = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PEOName_Text
        '
        Me.PEOName_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.PEOName_Text.Location = New System.Drawing.Point(277, 6)
        Me.PEOName_Text.Name = "PEOName_Text"
        Me.PEOName_Text.Size = New System.Drawing.Size(96, 26)
        Me.PEOName_Text.TabIndex = 212
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label7.Location = New System.Drawing.Point(203, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 211
        Me.Label7.Text = "员工姓名"
        '
        'User_No_Text
        '
        Me.User_No_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.User_No_Text.Location = New System.Drawing.Point(86, 6)
        Me.User_No_Text.Name = "User_No_Text"
        Me.User_No_Text.Size = New System.Drawing.Size(96, 26)
        Me.User_No_Text.TabIndex = 210
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 209
        Me.Label1.Text = "员工编号"
        '
        'EndTime
        '
        Me.EndTime.CustomFormat = "yyyy/MM/dd"
        Me.EndTime.Enabled = False
        Me.EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.EndTime.Location = New System.Drawing.Point(665, 9)
        Me.EndTime.Name = "EndTime"
        Me.EndTime.Size = New System.Drawing.Size(105, 21)
        Me.EndTime.TabIndex = 218
        Me.EndTime.Value = New Date(2014, 7, 30, 0, 0, 0, 0)
        '
        'StartTime
        '
        Me.StartTime.CustomFormat = "yyyy/MM/dd"
        Me.StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.StartTime.Location = New System.Drawing.Point(452, 9)
        Me.StartTime.Name = "StartTime"
        Me.StartTime.Size = New System.Drawing.Size(105, 21)
        Me.StartTime.TabIndex = 217
        Me.StartTime.Value = New Date(2014, 7, 30, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(591, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 216
        Me.Label3.Text = "结束日期"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(379, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 215
        Me.Label2.Text = "开始日期"
        '
        'OutExecl_Cmd
        '
        Me.OutExecl_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.OutExecl_Cmd.Location = New System.Drawing.Point(95, 44)
        Me.OutExecl_Cmd.Name = "OutExecl_Cmd"
        Me.OutExecl_Cmd.Size = New System.Drawing.Size(91, 33)
        Me.OutExecl_Cmd.TabIndex = 414
        Me.OutExecl_Cmd.Text = "汇出EXCEL"
        Me.OutExecl_Cmd.UseVisualStyleBackColor = True
        '
        'Load_Cmd
        '
        Me.Load_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Load_Cmd.Location = New System.Drawing.Point(15, 44)
        Me.Load_Cmd.Name = "Load_Cmd"
        Me.Load_Cmd.Size = New System.Drawing.Size(74, 33)
        Me.Load_Cmd.TabIndex = 415
        Me.Load_Cmd.Text = "排班"
        Me.Load_Cmd.UseVisualStyleBackColor = True
        '
        'Exit_Cmd
        '
        Me.Exit_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Exit_Cmd.Location = New System.Drawing.Point(192, 45)
        Me.Exit_Cmd.Name = "Exit_Cmd"
        Me.Exit_Cmd.Size = New System.Drawing.Size(74, 33)
        Me.Exit_Cmd.TabIndex = 416
        Me.Exit_Cmd.Text = "离开"
        Me.Exit_Cmd.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(15, 84)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(757, 466)
        Me.DataGridView1.TabIndex = 417
        '
        'PaiBan_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Exit_Cmd)
        Me.Controls.Add(Me.Load_Cmd)
        Me.Controls.Add(Me.OutExecl_Cmd)
        Me.Controls.Add(Me.EndTime)
        Me.Controls.Add(Me.StartTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.PEOName_Text)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.User_No_Text)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PaiBan_Form"
        Me.Text = "排班"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PEOName_Text As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents User_No_Text As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents EndTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents StartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents OutExecl_Cmd As System.Windows.Forms.Button
    Friend WithEvents Load_Cmd As System.Windows.Forms.Button
    Friend WithEvents Exit_Cmd As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
End Class
