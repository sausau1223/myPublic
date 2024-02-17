<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 覆寫 Dispose 以清除元件清單。
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

    '為 Windows Form 設計工具的必要項
    Private components As System.ComponentModel.IContainer

    '注意: 以下為 Windows Form 設計工具所需的程序
    '可以使用 Windows Form 設計工具進行修改。
    '請不要使用程式碼編輯器進行修改。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.RichTextBox2 = New System.Windows.Forms.RichTextBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.CheckBox_文字模式 = New System.Windows.Forms.CheckBox()
        Me.CheckBox_資料表模式 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.AutoScroll = True
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1434, 594)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.Control
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 612)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(66, 98)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(11, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "0"
        '
        'ComboBox1
        '
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"直排", "橫排"})
        Me.ComboBox1.Location = New System.Drawing.Point(6, 72)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(52, 20)
        Me.ComboBox1.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(6, 33)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(52, 33)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "試排"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(84, 645)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(263, 180)
        Me.RichTextBox1.TabIndex = 4
        Me.RichTextBox1.Text = "(1,1,3), (2,1,3), (3,1,3), (4,1,3)," & Global.Microsoft.VisualBasic.ChrW(10) & "(1,2,3), (2,2,3), (3,2,3), (4,2,3)," & Global.Microsoft.VisualBasic.ChrW(10) & "(1,3,3), " & _
    "(2,3,3), (3,3,3), (4,3,3)," & Global.Microsoft.VisualBasic.ChrW(10) & "(1,4,3), (2,4,3), (3,4,3), " & Global.Microsoft.VisualBasic.ChrW(10) & "(1,5,4)"
        '
        'RichTextBox2
        '
        Me.RichTextBox2.Location = New System.Drawing.Point(785, 630)
        Me.RichTextBox2.Name = "RichTextBox2"
        Me.RichTextBox2.Size = New System.Drawing.Size(439, 195)
        Me.RichTextBox2.TabIndex = 5
        Me.RichTextBox2.Text = ""
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Enabled = False
        Me.DataGridView1.Location = New System.Drawing.Point(386, 645)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.Size = New System.Drawing.Size(286, 180)
        Me.DataGridView1.TabIndex = 6
        '
        'CheckBox_文字模式
        '
        Me.CheckBox_文字模式.AutoSize = True
        Me.CheckBox_文字模式.Checked = True
        Me.CheckBox_文字模式.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox_文字模式.Location = New System.Drawing.Point(85, 625)
        Me.CheckBox_文字模式.Name = "CheckBox_文字模式"
        Me.CheckBox_文字模式.Size = New System.Drawing.Size(72, 16)
        Me.CheckBox_文字模式.TabIndex = 7
        Me.CheckBox_文字模式.Text = "文字模式"
        Me.CheckBox_文字模式.UseVisualStyleBackColor = True
        '
        'CheckBox_資料表模式
        '
        Me.CheckBox_資料表模式.AutoSize = True
        Me.CheckBox_資料表模式.Location = New System.Drawing.Point(386, 626)
        Me.CheckBox_資料表模式.Name = "CheckBox_資料表模式"
        Me.CheckBox_資料表模式.Size = New System.Drawing.Size(84, 16)
        Me.CheckBox_資料表模式.TabIndex = 8
        Me.CheckBox_資料表模式.Text = "資料表模式"
        Me.CheckBox_資料表模式.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1459, 843)
        Me.Controls.Add(Me.CheckBox_資料表模式)
        Me.Controls.Add(Me.CheckBox_文字模式)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.RichTextBox2)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents RichTextBox2 As System.Windows.Forms.RichTextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents CheckBox_文字模式 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox_資料表模式 As System.Windows.Forms.CheckBox

End Class
