<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ShJuCaiJi_Form
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
        Me.UpLoadFile_Cmd = New System.Windows.Forms.Button()
        Me.Load_Cmd = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.User_No_Text = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.StartTime = New System.Windows.Forms.DateTimePicker()
        Me.EndTime = New System.Windows.Forms.DateTimePicker()
        Me.Exit_Cmd = New System.Windows.Forms.Button()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Count_Lab = New System.Windows.Forms.Label()
        Me.Power_Lab = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UpLoadFile_Cmd
        '
        Me.UpLoadFile_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.UpLoadFile_Cmd.Location = New System.Drawing.Point(138, 64)
        Me.UpLoadFile_Cmd.Name = "UpLoadFile_Cmd"
        Me.UpLoadFile_Cmd.Size = New System.Drawing.Size(114, 45)
        Me.UpLoadFile_Cmd.TabIndex = 14
        Me.UpLoadFile_Cmd.Text = "上传刷卡记录"
        Me.UpLoadFile_Cmd.UseVisualStyleBackColor = True
        '
        'Load_Cmd
        '
        Me.Load_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Load_Cmd.Location = New System.Drawing.Point(12, 64)
        Me.Load_Cmd.Name = "Load_Cmd"
        Me.Load_Cmd.Size = New System.Drawing.Size(114, 45)
        Me.Load_Cmd.TabIndex = 15
        Me.Load_Cmd.Text = "查询"
        Me.Load_Cmd.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(41, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "卡号"
        '
        'User_No_Text
        '
        Me.User_No_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.User_No_Text.Location = New System.Drawing.Point(84, 19)
        Me.User_No_Text.Name = "User_No_Text"
        Me.User_No_Text.Size = New System.Drawing.Size(206, 26)
        Me.User_No_Text.TabIndex = 102
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label2.Location = New System.Drawing.Point(345, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "开始日期"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(557, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "结束日期"
        '
        'StartTime
        '
        Me.StartTime.CustomFormat = "yyyy/MM/dd"
        Me.StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.StartTime.Location = New System.Drawing.Point(418, 22)
        Me.StartTime.Name = "StartTime"
        Me.StartTime.Size = New System.Drawing.Size(105, 21)
        Me.StartTime.TabIndex = 106
        Me.StartTime.Value = New Date(2014, 7, 30, 9, 15, 57, 0)
        '
        'EndTime
        '
        Me.EndTime.CustomFormat = "yyyy/MM/dd"
        Me.EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.EndTime.Location = New System.Drawing.Point(631, 22)
        Me.EndTime.Name = "EndTime"
        Me.EndTime.Size = New System.Drawing.Size(105, 21)
        Me.EndTime.TabIndex = 107
        Me.EndTime.Value = New Date(2014, 7, 30, 0, 0, 0, 0)
        '
        'Exit_Cmd
        '
        Me.Exit_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Exit_Cmd.Location = New System.Drawing.Point(269, 64)
        Me.Exit_Cmd.Name = "Exit_Cmd"
        Me.Exit_Cmd.Size = New System.Drawing.Size(114, 45)
        Me.Exit_Cmd.TabIndex = 108
        Me.Exit_Cmd.Text = "离开"
        Me.Exit_Cmd.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(15, 130)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 23
        Me.DataGridView1.Size = New System.Drawing.Size(757, 404)
        Me.DataGridView1.TabIndex = 109
        '
        'Count_Lab
        '
        Me.Count_Lab.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Count_Lab.AutoSize = True
        Me.Count_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Count_Lab.Location = New System.Drawing.Point(12, 537)
        Me.Count_Lab.Name = "Count_Lab"
        Me.Count_Lab.Size = New System.Drawing.Size(56, 16)
        Me.Count_Lab.TabIndex = 401
        Me.Count_Lab.Text = "笔数："
        '
        'Power_Lab
        '
        Me.Power_Lab.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Power_Lab.AutoSize = True
        Me.Power_Lab.Location = New System.Drawing.Point(309, 541)
        Me.Power_Lab.Name = "Power_Lab"
        Me.Power_Lab.Size = New System.Drawing.Size(29, 12)
        Me.Power_Lab.TabIndex = 402
        Me.Power_Lab.Text = "权限"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.Filter = "文本文件(*.txt)|*.txt|所有文件(*.*)|*.*"
        '
        'ShJuCaiJi_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 562)
        Me.Controls.Add(Me.Power_Lab)
        Me.Controls.Add(Me.Count_Lab)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.Exit_Cmd)
        Me.Controls.Add(Me.EndTime)
        Me.Controls.Add(Me.StartTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.User_No_Text)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Load_Cmd)
        Me.Controls.Add(Me.UpLoadFile_Cmd)
        Me.Name = "ShJuCaiJi_Form"
        Me.Text = "数据采集"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents UpLoadFile_Cmd As System.Windows.Forms.Button
    Friend WithEvents Load_Cmd As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents User_No_Text As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents StartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents EndTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Exit_Cmd As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Count_Lab As System.Windows.Forms.Label
    Friend WithEvents Power_Lab As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
End Class
