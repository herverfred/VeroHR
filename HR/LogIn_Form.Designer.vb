<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LogIN_Form
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
        Me.LogName_Lab = New System.Windows.Forms.Label()
        Me.LogPwd_Lab = New System.Windows.Forms.Label()
        Me.LogName_Text = New System.Windows.Forms.TextBox()
        Me.LogPwd_Text = New System.Windows.Forms.TextBox()
        Me.Confirm_Cmd = New System.Windows.Forms.Button()
        Me.Exit_Cmd = New System.Windows.Forms.Button()
        Me.Name_Lab = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'LogName_Lab
        '
        Me.LogName_Lab.AutoSize = True
        Me.LogName_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LogName_Lab.Location = New System.Drawing.Point(12, 61)
        Me.LogName_Lab.Name = "LogName_Lab"
        Me.LogName_Lab.Size = New System.Drawing.Size(72, 16)
        Me.LogName_Lab.TabIndex = 0
        Me.LogName_Lab.Text = "登入账号"
        '
        'LogPwd_Lab
        '
        Me.LogPwd_Lab.AutoSize = True
        Me.LogPwd_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LogPwd_Lab.Location = New System.Drawing.Point(12, 101)
        Me.LogPwd_Lab.Name = "LogPwd_Lab"
        Me.LogPwd_Lab.Size = New System.Drawing.Size(72, 16)
        Me.LogPwd_Lab.TabIndex = 1
        Me.LogPwd_Lab.Text = "登入密码"
        '
        'LogName_Text
        '
        Me.LogName_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LogName_Text.Location = New System.Drawing.Point(90, 58)
        Me.LogName_Text.Name = "LogName_Text"
        Me.LogName_Text.Size = New System.Drawing.Size(115, 26)
        Me.LogName_Text.TabIndex = 0
        '
        'LogPwd_Text
        '
        Me.LogPwd_Text.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.LogPwd_Text.Location = New System.Drawing.Point(90, 98)
        Me.LogPwd_Text.Name = "LogPwd_Text"
        Me.LogPwd_Text.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.LogPwd_Text.Size = New System.Drawing.Size(115, 26)
        Me.LogPwd_Text.TabIndex = 1
        '
        'Confirm_Cmd
        '
        Me.Confirm_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Confirm_Cmd.Location = New System.Drawing.Point(30, 130)
        Me.Confirm_Cmd.Name = "Confirm_Cmd"
        Me.Confirm_Cmd.Size = New System.Drawing.Size(73, 30)
        Me.Confirm_Cmd.TabIndex = 100
        Me.Confirm_Cmd.Text = "确定"
        Me.Confirm_Cmd.UseVisualStyleBackColor = True
        '
        'Exit_Cmd
        '
        Me.Exit_Cmd.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Exit_Cmd.Location = New System.Drawing.Point(137, 130)
        Me.Exit_Cmd.Name = "Exit_Cmd"
        Me.Exit_Cmd.Size = New System.Drawing.Size(73, 30)
        Me.Exit_Cmd.TabIndex = 101
        Me.Exit_Cmd.Text = "离开"
        Me.Exit_Cmd.UseVisualStyleBackColor = True
        '
        'Name_Lab
        '
        Me.Name_Lab.AutoSize = True
        Me.Name_Lab.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Name_Lab.Location = New System.Drawing.Point(211, 61)
        Me.Name_Lab.Name = "Name_Lab"
        Me.Name_Lab.Size = New System.Drawing.Size(0, 16)
        Me.Name_Lab.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("宋体", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 21)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "登入到"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("宋体", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(134, Byte))
        Me.Label1.Location = New System.Drawing.Point(24, 37)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "地区IP"
        '
        'LogIN_Form
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(320, 166)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Name_Lab)
        Me.Controls.Add(Me.Exit_Cmd)
        Me.Controls.Add(Me.Confirm_Cmd)
        Me.Controls.Add(Me.LogPwd_Text)
        Me.Controls.Add(Me.LogName_Text)
        Me.Controls.Add(Me.LogPwd_Lab)
        Me.Controls.Add(Me.LogName_Lab)
        Me.Name = "LogIN_Form"
        Me.Text = "登入"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LogName_Lab As System.Windows.Forms.Label
    Friend WithEvents LogPwd_Lab As System.Windows.Forms.Label
    Friend WithEvents LogName_Text As System.Windows.Forms.TextBox
    Friend WithEvents LogPwd_Text As System.Windows.Forms.TextBox
    Friend WithEvents Confirm_Cmd As System.Windows.Forms.Button
    Friend WithEvents Exit_Cmd As System.Windows.Forms.Button
    Friend WithEvents Name_Lab As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
