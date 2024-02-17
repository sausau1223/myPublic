Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim tempdt As New DataTable
        tempdt = 整理DataGridView()

        ComboBox1.SelectedIndex = 1
        '自動產生直排架位()
        '自動產生橫排架位()
        自動產生直橫排架位()
        '自動產生CheckBox()
    End Sub


    ''' <summary>
    ''' 自動產生直排架位
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 自動產生直排架位()

        Dim 架位數 As Integer = 1
        Dim 欄數 As Integer = 4
        Dim 列數 As Integer = 5
        Dim 按鍵數量 As Integer = 欄數 * 列數
        Dim 不顯示的位置 As New List(Of Integer)

        '不顯示的位置.Add("3")
        '不顯示的位置.Add("4")
        'Dim CheckBox自訂() As CheckBox


        Dim GroupBox自訂() As GroupBox
        Dim Label自訂() As Label
        Dim Button自訂() As Button
        Dim ComboBox自訂() As ComboBox
        Dim SplitContainer自訂() As SplitContainer
        Dim Label架位() As Label


        'Dim ComboBox自訂_1 = New ComboBox

        ReDim GroupBox自訂(按鍵數量)
        ReDim Label自訂(按鍵數量)
        ReDim Button自訂(按鍵數量)
        ReDim ComboBox自訂(按鍵數量)
        ReDim SplitContainer自訂(架位數)

        Dim 電子標籤序號 As Integer = 0
        Dim 垂直位置 As Integer = 0
        Dim 水平位置 As Integer = 0
        Dim 換行點 = 欄數
        Dim 水平間距 = 70
        Dim 垂直間距 = 100
        Dim 按鈕間距 = 100

        Dim 架位垂直位置 As Integer = 0
        Dim 架位水平位置 As Integer = 0
        Dim 架位寬度 = 0
        Dim 架位高度 = 0
        Dim 架位垂直間距 = 101
        Dim 架位水平間距 = 100


        Dim 所有架位資料表 As New DataSet


        Dim 架位資料表 As New DataTable("架位資料表")
        架位資料表.Columns.Add("架位")
        架位資料表.Columns.Add("列數")
        架位資料表.Columns.Add("燈號個數")

        架位資料表.Columns("架位").DataType = GetType(Integer)
        架位資料表.Columns("列數").DataType = GetType(Integer)
        架位資料表.Columns("燈號個數").DataType = GetType(Integer)


        Dim 暫存資料表 As New DataTable("暫存資料表")


        Dim 取得架位設定資料 As String = RichTextBox1.Text


        取得架位設定資料 = 取得架位設定資料.Replace(" ", "").Replace(Environment.NewLine, "").Replace(vbLf, "").Replace(vbCrLf, "").Replace(vbCr, "")

        For i As Integer = 0 To 取得架位設定資料.Split("),(").Length - 1

            If 取得架位設定資料.Split("),(")(i).Replace("(", "").Length > 0 Then
                架位資料表.Rows.Add(取得架位設定資料.Split("),(")(i).Replace(",(", "").Replace("(", "").Split(","))
            End If
        Next



        '計算按鍵數量
        'Dim result As Object
        按鍵數量 = 架位資料表.Compute("SUM(燈號個數)", "")

        架位資料表.DefaultView.Sort = "架位 Desc"
        暫存資料表 = 架位資料表.DefaultView.ToTable()
        架位數 = 暫存資料表.Rows(0)(0).ToString()

        ReDim GroupBox自訂(按鍵數量)
        ReDim Label自訂(按鍵數量)
        ReDim Button自訂(按鍵數量)
        ReDim ComboBox自訂(按鍵數量)
        ReDim SplitContainer自訂(架位數)
        ReDim Label架位(架位數)



        For i As Integer = 1 To 架位數
            Dim 查詢條件 As String = ""
            查詢條件 = "架位=" & i
            暫存資料表 = 架位資料表.Select(查詢條件, "列數 ASC").CopyToDataTable
            所有架位資料表.Tables.Add(暫存資料表)
            所有架位資料表.Tables(i - 1).TableName = i
        Next


        Dim 累積燈號個數 As Integer = 0

        For x As Integer = 0 To 所有架位資料表.Tables.Count - 1
            'For x As Integer = 0 To 0

            '取得最大個數(寬)
            Dim 最大燈號個數 As Integer = 0
            所有架位資料表.Tables(x).DefaultView.Sort = "燈號個數 Desc"
            暫存資料表 = 所有架位資料表.Tables(x).DefaultView.ToTable()
            最大燈號個數 = 暫存資料表.Rows(0)("燈號個數").ToString()
            '最大燈號個數 = 所有架位資料表.Tables(x).Rows.Count

            '取得最大列數(高)
            Dim 最大列數 As Integer = 0
            所有架位資料表.Tables(x).DefaultView.Sort = "列數 Desc"
            暫存資料表 = 所有架位資料表.Tables(x).DefaultView.ToTable()
            最大列數 = 暫存資料表.Rows(0)("列數").ToString()


            累積燈號個數 = 累積燈號個數 + 最大燈號個數
            架位垂直位置 = 0
            架位水平位置 = (累積燈號個數 - 最大燈號個數) * 水平間距
            '架位水平位置 = 架位水平位置 + (x * 水平間距 * 最大燈號個數 + 3)

            架位寬度 = 水平間距 * 最大燈號個數 + 3

            '架位高度 = 第一段固定佔掉位52架位顯示 + (架位垂直間距) * 最大列數
            架位高度 = 52 + (架位垂直間距) * 最大列數

            '畫架位框線(容器)
            SplitContainer自訂(x) = New SplitContainer()
            SplitContainer自訂(x).Name = "SplitContainer自訂_" & (x + 1).ToString()
            SplitContainer自訂(x).Text = (x + 1).ToString()
            SplitContainer自訂(x).Left = 架位水平位置
            SplitContainer自訂(x).Top = 垂直位置
            SplitContainer自訂(x).Width = 架位寬度
            SplitContainer自訂(x).Height = 架位高度

            SplitContainer自訂(x).IsSplitterFixed = True
            SplitContainer自訂(x).SplitterDistance = 52
            SplitContainer自訂(x).BorderStyle = BorderStyle.FixedSingle
            SplitContainer自訂(x).Orientation = Orientation.Horizontal

            'SplitContainer自訂(x).Dock = DockStyle.Right

            'SplitContainer自訂(x).AutoSize = True
            'SplitContainer自訂(x).Panel1.AutoSize = False
            'SplitContainer自訂(x).Panel2.AutoSize = True






            Label架位(x) = New Label()
            Label架位(x).Name = "Label架位_" & (x + 1).ToString()
            Label架位(x).Text = (x + 1).ToString()
            'Label架位(x).Left = 92
            'Label架位(x).Top = 12
            'Label架位(x).Width = 22
            'Label架位(x).Height = 24

            Label架位(x).AutoSize = False
            Label架位(x).Font = New Font("新細明體", 18, FontStyle.Bold)
            Label架位(x).TextAlign = ContentAlignment.MiddleCenter
            Label架位(x).Dock = DockStyle.Fill



            '測試
            Panel1.Controls.Add(SplitContainer自訂(x))
            SplitContainer自訂(x).Panel1.Controls.Add(Label架位(x))


            'Return
        Next

        '直排模式
        '畫架位：X座標 欄
        For x As Integer = 0 To 所有架位資料表.Tables.Count - 1
            'For x As Integer = 0 To 0
            垂直位置 = 0

            '畫架位：Y座標 
            For y As Integer = 0 To 所有架位資料表.Tables(x).Rows.Count - 1




                '畫個數：Z座標
                For z As Integer = 0 To 所有架位資料表.Tables(x).Rows(y)("燈號個數") - 1

                    垂直位置 = y * 垂直間距 + 3
                    水平位置 = z * 水平間距 + 3


                    RichTextBox2.Text = RichTextBox2.Text & "(" & 水平位置 & "," & 垂直位置 & ")"


                    GroupBox自訂(電子標籤序號) = New GroupBox()
                    GroupBox自訂(電子標籤序號).Name = "GroupBox自訂_" & (電子標籤序號 + 1).ToString()
                    GroupBox自訂(電子標籤序號).Text = (電子標籤序號 + 1).ToString()
                    GroupBox自訂(電子標籤序號).Left = 水平位置
                    GroupBox自訂(電子標籤序號).Top = 垂直位置
                    GroupBox自訂(電子標籤序號).Width = 66
                    GroupBox自訂(電子標籤序號).Height = 98

                    Label自訂(電子標籤序號) = New Label()
                    Label自訂(電子標籤序號).Name = "Label自訂_" & (電子標籤序號 + 1).ToString()
                    Label自訂(電子標籤序號).Text = (電子標籤序號 + 1).ToString()
                    Label自訂(電子標籤序號).Left = 27
                    Label自訂(電子標籤序號).Top = 18
                    Label自訂(電子標籤序號).Width = 30
                    Label自訂(電子標籤序號).Height = 12


                    Button自訂(電子標籤序號) = New Button()
                    Button自訂(電子標籤序號).Name = "Button自訂_" & (電子標籤序號 + 1).ToString()
                    Button自訂(電子標籤序號).Text = "學代" & Environment.NewLine & "科代"
                    Button自訂(電子標籤序號).Left = 6
                    Button自訂(電子標籤序號).Top = 33
                    Button自訂(電子標籤序號).Width = 52
                    Button自訂(電子標籤序號).Height = 33
                    'Button自訂(電子標籤序號).Size = New Size(70, 20)
                    'Button自訂(電子標籤序號).BackColor = Color.LawnGreen
                    'Button自訂(電子標籤序號).BackColor = Color.Yellow
                    'Button自訂(電子標籤序號).BackColor = Color.Red


                    ComboBox自訂(電子標籤序號) = New ComboBox()
                    ComboBox自訂(電子標籤序號).Name = "ComboBox自訂_" & (電子標籤序號 + 1).ToString()
                    'Button自訂(電子標籤序號).Text = "學代" & Environment.NewLine & "科代"
                    ComboBox自訂(電子標籤序號).Left = 6
                    ComboBox自訂(電子標籤序號).Top = 72
                    ComboBox自訂(電子標籤序號).Width = 52
                    ComboBox自訂(電子標籤序號).Height = 20



                    'If 不顯示的位置.Contains(i.ToString()) Then
                    '    GroupBox自訂(電子標籤序號).Visible = False

                    'End If



                    '事件註冊
                    'AddHandler CheckBox自訂(電子標籤序號).CheckedChanged, AddressOf CheckBox自訂_CheckedChanged
                    'AddHandler Button自訂(電子標籤序號).Click, AddressOf Button自訂_Click



                    'Panel1.Controls.Add(GroupBox自訂(電子標籤序號))

                    SplitContainer自訂(x).Panel2.Controls.Add(GroupBox自訂(電子標籤序號))

                    GroupBox自訂(電子標籤序號).Controls.Add(Label自訂(電子標籤序號))
                    GroupBox自訂(電子標籤序號).Controls.Add(Button自訂(電子標籤序號))
                    GroupBox自訂(電子標籤序號).Controls.Add(ComboBox自訂(電子標籤序號))

                    電子標籤序號 = 電子標籤序號 + 1
                Next




            Next
        Next

        Dim g As Graphics
        g = Panel1.CreateGraphics()


    End Sub



    ''' <summary>
    ''' 自動產生橫排架位
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 自動產生橫排架位()

        Dim 架位數 As Integer = 0
        Dim 總列數 As Integer = 0
        Dim 欄數 As Integer = 0
        Dim 列數 As Integer = 0
        Dim 按鍵數量 As Integer = 欄數 * 列數
        Dim 不顯示的位置 As New List(Of Integer)

        '不顯示的位置.Add("3")
        '不顯示的位置.Add("4")
        'Dim CheckBox自訂() As CheckBox


        Dim GroupBox自訂() As GroupBox
        Dim Label自訂() As Label
        Dim Button自訂() As Button
        Dim ComboBox自訂() As ComboBox
        Dim SplitContainer自訂() As SplitContainer
        Dim Label架位() As Label


        'Dim ComboBox自訂_1 = New ComboBox

        'ReDim GroupBox自訂(按鍵數量)
        'ReDim Label自訂(按鍵數量)
        'ReDim Button自訂(按鍵數量)
        'ReDim ComboBox自訂(按鍵數量)
        'ReDim SplitContainer自訂(架位數)

        Dim 電子標籤序號 As Integer = 0
        Dim 垂直位置 As Integer = 0
        Dim 水平位置 As Integer = 0
        Dim 換行點 = 欄數
        Dim 水平間距 = 70
        Dim 垂直間距 = 100
        Dim 按鈕間距 = 100

        Dim 架位垂直位置 As Integer = 0
        Dim 架位水平位置 As Integer = 0
        Dim 架位寬度 = 0
        Dim 架位高度 = 0
        Dim 架位垂直間距 = 101
        Dim 架位水平間距 = 100


        Dim 所有架位資料表 As New DataSet


        Dim 架位資料表 As New DataTable("架位資料表")
        架位資料表.Columns.Add("架位")
        架位資料表.Columns.Add("列數")
        架位資料表.Columns.Add("燈號個數")

        架位資料表.Columns("架位").DataType = GetType(Integer)
        架位資料表.Columns("列數").DataType = GetType(Integer)
        架位資料表.Columns("燈號個數").DataType = GetType(Integer)


        Dim 暫存資料表 As New DataTable("暫存資料表")


        Dim 取得架位設定資料 As String = RichTextBox1.Text


        取得架位設定資料 = 取得架位設定資料.Replace(" ", "").Replace(Environment.NewLine, "").Replace(vbLf, "").Replace(vbCrLf, "").Replace(vbCr, "")

        For i As Integer = 0 To 取得架位設定資料.Split("),(").Length - 1

            If 取得架位設定資料.Split("),(")(i).Replace("(", "").Length > 0 Then
                架位資料表.Rows.Add(取得架位設定資料.Split("),(")(i).Replace(",(", "").Replace("(", "").Split(","))
            End If
        Next





        '計算按鍵數量
        'Dim result As Object
        按鍵數量 = 架位資料表.Compute("SUM(燈號個數)", "")

        架位資料表.DefaultView.Sort = "架位 Desc"
        暫存資料表 = 架位資料表.DefaultView.ToTable()
        架位數 = 暫存資料表.Rows(0)("架位").ToString()

        '多重排序測試
        架位資料表.DefaultView.Sort = "列數 Desc"
        暫存資料表 = 架位資料表.DefaultView.ToTable()
        總列數 = 暫存資料表.Rows(0)("列數").ToString()

        ReDim GroupBox自訂(按鍵數量)
        ReDim Label自訂(按鍵數量)
        ReDim Button自訂(按鍵數量)
        ReDim ComboBox自訂(按鍵數量)
        ReDim SplitContainer自訂(架位數)
        ReDim Label架位(架位數)


        '直排
        For i As Integer = 1 To 架位數
            Dim 查詢條件 As String = ""
            查詢條件 = "架位=" & i
            暫存資料表 = 架位資料表.Select(查詢條件, "列數 ASC").CopyToDataTable
            所有架位資料表.Tables.Add(暫存資料表)
            所有架位資料表.Tables(i - 1).TableName = i
        Next


        '製作架位容器
        Dim 累積燈號個數 As Integer = 0
        For x As Integer = 0 To 所有架位資料表.Tables.Count - 1
            'For x As Integer = 0 To 0

            '取得最大個數(寬)
            Dim 最大燈號個數 As Integer = 0
            所有架位資料表.Tables(x).DefaultView.Sort = "燈號個數 Desc"
            暫存資料表 = 所有架位資料表.Tables(x).DefaultView.ToTable()
            最大燈號個數 = 暫存資料表.Rows(0)("燈號個數").ToString()
            '最大燈號個數 = 所有架位資料表.Tables(x).Rows.Count

            '取得最大列數(高)
            Dim 最大列數 As Integer = 0
            所有架位資料表.Tables(x).DefaultView.Sort = "列數 Desc"
            暫存資料表 = 所有架位資料表.Tables(x).DefaultView.ToTable()
            最大列數 = 暫存資料表.Rows(0)("列數").ToString()


            累積燈號個數 = 累積燈號個數 + 最大燈號個數
            架位垂直位置 = 0
            架位水平位置 = (累積燈號個數 - 最大燈號個數) * 水平間距
            '架位水平位置 = 架位水平位置 + (x * 水平間距 * 最大燈號個數 + 3)

            架位寬度 = 水平間距 * 最大燈號個數 + 3

            '架位高度 = 第一段固定佔掉位52架位顯示 + (架位垂直間距) * 最大列數
            架位高度 = 52 + (架位垂直間距) * 最大列數

            '畫架位框線(容器)
            SplitContainer自訂(x) = New SplitContainer()
            SplitContainer自訂(x).Name = "SplitContainer自訂_" & (x + 1).ToString()
            SplitContainer自訂(x).Text = (x + 1).ToString()
            SplitContainer自訂(x).Left = 架位水平位置
            SplitContainer自訂(x).Top = 垂直位置
            SplitContainer自訂(x).Width = 架位寬度
            SplitContainer自訂(x).Height = 架位高度

            SplitContainer自訂(x).IsSplitterFixed = True
            SplitContainer自訂(x).SplitterDistance = 52
            SplitContainer自訂(x).BorderStyle = BorderStyle.FixedSingle
            SplitContainer自訂(x).Orientation = Orientation.Horizontal




            Label架位(x) = New Label()
            Label架位(x).Name = "Label架位_" & (x + 1).ToString()
            Label架位(x).Text = (x + 1).ToString()

            Label架位(x).AutoSize = False
            Label架位(x).Font = New Font("新細明體", 18, FontStyle.Bold)
            Label架位(x).TextAlign = ContentAlignment.MiddleCenter
            Label架位(x).Dock = DockStyle.Fill



            '測試
            Panel1.Controls.Add(SplitContainer自訂(x))
            SplitContainer自訂(x).Panel1.Controls.Add(Label架位(x))


            'Return
        Next


        所有架位資料表.Tables.Clear()

        '橫排
        For i As Integer = 1 To 總列數
            Dim 查詢條件 As String = ""
            查詢條件 = "列數=" & i
            暫存資料表 = 架位資料表.Select(查詢條件, "架位 ASC").CopyToDataTable
            所有架位資料表.Tables.Add(暫存資料表)
            所有架位資料表.Tables(i - 1).TableName = i
        Next



        '直排模式
        '畫架位：X座標 欄
        For x As Integer = 0 To 所有架位資料表.Tables.Count - 1
            'For x As Integer = 0 To 0
            垂直位置 = 0

            '畫架位：Y座標 
            For y As Integer = 0 To 所有架位資料表.Tables(x).Rows.Count - 1




                '畫個數：Z座標
                For z As Integer = 0 To 所有架位資料表.Tables(x).Rows(y)("燈號個數") - 1

                    垂直位置 = x * 垂直間距 + 3
                    水平位置 = z * 水平間距 + 3


                    RichTextBox2.Text = RichTextBox2.Text & "(" & 水平位置 & "," & 垂直位置 & ")"


                    GroupBox自訂(電子標籤序號) = New GroupBox()
                    GroupBox自訂(電子標籤序號).Name = "GroupBox自訂_" & (電子標籤序號 + 1).ToString()
                    GroupBox自訂(電子標籤序號).Text = (電子標籤序號 + 1).ToString()
                    GroupBox自訂(電子標籤序號).Left = 水平位置
                    GroupBox自訂(電子標籤序號).Top = 垂直位置
                    GroupBox自訂(電子標籤序號).Width = 66
                    GroupBox自訂(電子標籤序號).Height = 98

                    Label自訂(電子標籤序號) = New Label()
                    Label自訂(電子標籤序號).Name = "Label自訂_" & (電子標籤序號 + 1).ToString()
                    Label自訂(電子標籤序號).Text = (電子標籤序號 + 1).ToString()
                    Label自訂(電子標籤序號).Left = 27
                    Label自訂(電子標籤序號).Top = 18
                    Label自訂(電子標籤序號).Width = 30
                    Label自訂(電子標籤序號).Height = 12


                    Button自訂(電子標籤序號) = New Button()
                    Button自訂(電子標籤序號).Name = "Button自訂_" & (電子標籤序號 + 1).ToString()
                    Button自訂(電子標籤序號).Text = "學代" & Environment.NewLine & "科代"
                    Button自訂(電子標籤序號).Left = 6
                    Button自訂(電子標籤序號).Top = 33
                    Button自訂(電子標籤序號).Width = 52
                    Button自訂(電子標籤序號).Height = 33
                    'Button自訂(電子標籤序號).Size = New Size(70, 20)
                    'Button自訂(電子標籤序號).BackColor = Color.LawnGreen
                    'Button自訂(電子標籤序號).BackColor = Color.Yellow
                    'Button自訂(電子標籤序號).BackColor = Color.Red


                    ComboBox自訂(電子標籤序號) = New ComboBox()
                    ComboBox自訂(電子標籤序號).Name = "ComboBox自訂_" & (電子標籤序號 + 1).ToString()
                    'Button自訂(電子標籤序號).Text = "學代" & Environment.NewLine & "科代"
                    ComboBox自訂(電子標籤序號).Left = 6
                    ComboBox自訂(電子標籤序號).Top = 72
                    ComboBox自訂(電子標籤序號).Width = 52
                    ComboBox自訂(電子標籤序號).Height = 20



                    'If 不顯示的位置.Contains(i.ToString()) Then
                    '    GroupBox自訂(電子標籤序號).Visible = False

                    'End If



                    '事件註冊
                    'AddHandler CheckBox自訂(電子標籤序號).CheckedChanged, AddressOf CheckBox自訂_CheckedChanged
                    'AddHandler Button自訂(電子標籤序號).Click, AddressOf Button自訂_Click



                    'Panel1.Controls.Add(GroupBox自訂(電子標籤序號))

                    SplitContainer自訂(y).Panel2.Controls.Add(GroupBox自訂(電子標籤序號))

                    GroupBox自訂(電子標籤序號).Controls.Add(Label自訂(電子標籤序號))
                    GroupBox自訂(電子標籤序號).Controls.Add(Button自訂(電子標籤序號))
                    GroupBox自訂(電子標籤序號).Controls.Add(ComboBox自訂(電子標籤序號))

                    電子標籤序號 = 電子標籤序號 + 1
                Next




            Next
        Next

        Dim g As Graphics
        g = Panel1.CreateGraphics()


    End Sub



    ''' <summary>
    ''' 自動產生橫排架位
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 自動產生直橫排架位()

        Panel1.Controls.Clear()


        Dim 架位數 As Integer = 0
        Dim 總列數 As Integer = 0
        Dim 欄數 As Integer = 0
        Dim 列數 As Integer = 0
        Dim 按鍵數量 As Integer = 欄數 * 列數
        Dim 不顯示的位置 As New List(Of Integer)
        Dim 方向 As String = "直排"
        方向 = ComboBox1.Text


        Dim GroupBox自訂() As GroupBox
        Dim Label自訂() As Label
        Dim Button自訂() As Button
        Dim ComboBox自訂() As ComboBox
        Dim SplitContainer自訂() As SplitContainer
        Dim Label架位() As Label


        'Dim ComboBox自訂_1 = New ComboBox

        'ReDim GroupBox自訂(按鍵數量)
        'ReDim Label自訂(按鍵數量)
        'ReDim Button自訂(按鍵數量)
        'ReDim ComboBox自訂(按鍵數量)
        'ReDim SplitContainer自訂(架位數)

        Dim 電子標籤序號 As Integer = 0
        Dim 垂直位置 As Integer = 0
        Dim 水平位置 As Integer = 0
        Dim 換行點 = 欄數
        Dim 水平間距 = 70
        Dim 垂直間距 = 100
        Dim 按鈕間距 = 100

        Dim 架位垂直位置 As Integer = 0
        Dim 架位水平位置 As Integer = 0
        Dim 架位寬度 = 0
        Dim 架位高度 = 0
        Dim 架位垂直間距 = 101
        Dim 架位水平間距 = 100


        Dim 所有架位資料表 As New DataSet


        Dim 架位資料表 As New DataTable("架位資料表")
        架位資料表.Columns.Add("架位")
        架位資料表.Columns.Add("列數")
        架位資料表.Columns.Add("燈號個數")

        架位資料表.Columns("架位").DataType = GetType(Integer)
        架位資料表.Columns("列數").DataType = GetType(Integer)
        架位資料表.Columns("燈號個數").DataType = GetType(Integer)


        Dim 暫存資料表 As New DataTable("暫存資料表")




        If CheckBox_資料表模式.Checked = True Then
            架位資料表 = 整理DataGridView()
        Else
            Dim 取得架位設定資料 As String = RichTextBox1.Text
            取得架位設定資料 = 取得架位設定資料.Replace(" ", "").Replace(Environment.NewLine, "").Replace(vbLf, "").Replace(vbCrLf, "").Replace(vbCr, "")

            For i As Integer = 0 To 取得架位設定資料.Split("),(").Length - 1

                If 取得架位設定資料.Split("),(")(i).Replace("(", "").Length > 0 Then
                    架位資料表.Rows.Add(取得架位設定資料.Split("),(")(i).Replace(",(", "").Replace("(", "").Split(","))
                End If
            Next
        End If



        '計算按鍵數量
        'Dim result As Object
        按鍵數量 = 架位資料表.Compute("SUM(燈號個數)", "")

        架位資料表.DefaultView.Sort = "架位 Desc"
        暫存資料表 = 架位資料表.DefaultView.ToTable()
        架位數 = 暫存資料表.Rows(0)("架位").ToString()

        '多重排序測試
        架位資料表.DefaultView.Sort = "列數 Desc"
        暫存資料表 = 架位資料表.DefaultView.ToTable()
        總列數 = 暫存資料表.Rows(0)("列數").ToString()

        ReDim GroupBox自訂(按鍵數量)
        ReDim Label自訂(按鍵數量)
        ReDim Button自訂(按鍵數量)
        ReDim ComboBox自訂(按鍵數量)
        ReDim SplitContainer自訂(架位數)
        ReDim Label架位(架位數)


        '直排
        For i As Integer = 1 To 架位數
            Dim 查詢條件 As String = ""
            查詢條件 = "架位=" & i
            暫存資料表 = 架位資料表.Select(查詢條件, "列數 ASC").CopyToDataTable
            所有架位資料表.Tables.Add(暫存資料表)
            所有架位資料表.Tables(i - 1).TableName = i
        Next


        '製作架位容器
        Dim 累積燈號個數 As Integer = 0
        For x As Integer = 0 To 所有架位資料表.Tables.Count - 1
            'For x As Integer = 0 To 0

            '取得最大個數(寬)
            Dim 最大燈號個數 As Integer = 0
            所有架位資料表.Tables(x).DefaultView.Sort = "燈號個數 Desc"
            暫存資料表 = 所有架位資料表.Tables(x).DefaultView.ToTable()
            最大燈號個數 = 暫存資料表.Rows(0)("燈號個數").ToString()
            '最大燈號個數 = 所有架位資料表.Tables(x).Rows.Count

            '取得最大列數(高)
            Dim 最大列數 As Integer = 0
            所有架位資料表.Tables(x).DefaultView.Sort = "列數 Desc"
            暫存資料表 = 所有架位資料表.Tables(x).DefaultView.ToTable()
            最大列數 = 暫存資料表.Rows(0)("列數").ToString()


            累積燈號個數 = 累積燈號個數 + 最大燈號個數
            架位垂直位置 = 0
            架位水平位置 = (累積燈號個數 - 最大燈號個數) * 水平間距
            '架位水平位置 = 架位水平位置 + (x * 水平間距 * 最大燈號個數 + 3)

            架位寬度 = 水平間距 * 最大燈號個數 + 3

            '架位高度 = 第一段固定佔掉位52架位顯示 + (架位垂直間距) * 最大列數
            架位高度 = 52 + (架位垂直間距) * 最大列數

            '畫架位框線(容器)
            SplitContainer自訂(x) = New SplitContainer()
            SplitContainer自訂(x).Name = "SplitContainer自訂_" & (x + 1).ToString()
            SplitContainer自訂(x).Text = (x + 1).ToString()
            SplitContainer自訂(x).Left = 架位水平位置
            SplitContainer自訂(x).Top = 垂直位置
            SplitContainer自訂(x).Width = 架位寬度
            SplitContainer自訂(x).Height = 架位高度

            SplitContainer自訂(x).IsSplitterFixed = True
            SplitContainer自訂(x).SplitterDistance = 52
            SplitContainer自訂(x).BorderStyle = BorderStyle.FixedSingle
            SplitContainer自訂(x).Orientation = Orientation.Horizontal




            Label架位(x) = New Label()
            Label架位(x).Name = "Label架位_" & (x + 1).ToString()
            Label架位(x).Text = (x + 1).ToString()

            Label架位(x).AutoSize = False
            Label架位(x).Font = New Font("新細明體", 18, FontStyle.Bold)
            Label架位(x).TextAlign = ContentAlignment.MiddleCenter
            Label架位(x).Dock = DockStyle.Fill



            '測試
            Panel1.Controls.Add(SplitContainer自訂(x))
            SplitContainer自訂(x).Panel1.Controls.Add(Label架位(x))


            'Return
        Next

        If 方向 = "直排" Then

        ElseIf 方向 = "橫排" Then

            '橫排
            所有架位資料表.Tables.Clear()
            For i As Integer = 1 To 總列數
                Dim 查詢條件 As String = ""
                查詢條件 = "列數=" & i
                暫存資料表 = 架位資料表.Select(查詢條件, "架位 ASC").CopyToDataTable
                所有架位資料表.Tables.Add(暫存資料表)
                所有架位資料表.Tables(i - 1).TableName = i
            Next

        End If






        '直排模式=畫架位：X座標 欄
        '橫排模式=畫列數：X座標 列
        For x As Integer = 0 To 所有架位資料表.Tables.Count - 1
            'For x As Integer = 0 To 0
            垂直位置 = 0

            '直排模式：Y座標 列
            '橫排模式：Y座標 待處理架位數量(無法代表架位座標)
            For y As Integer = 0 To 所有架位資料表.Tables(x).Rows.Count - 1




                '畫個數：Z座標
                For z As Integer = 0 To 所有架位資料表.Tables(x).Rows(y)("燈號個數") - 1


                    If 方向 = "直排" Then
                        '直排
                        垂直位置 = y * 垂直間距 + 3
                    ElseIf 方向 = "橫排" Then
                        '橫排
                        垂直位置 = x * 垂直間距 + 3
                    End If

                    水平位置 = z * 水平間距 + 3


                    RichTextBox2.Text = RichTextBox2.Text & "(" & 水平位置 & "," & 垂直位置 & ")"


                    GroupBox自訂(電子標籤序號) = New GroupBox()
                    GroupBox自訂(電子標籤序號).Name = "GroupBox自訂_" & (電子標籤序號 + 1).ToString()
                    'GroupBox自訂(電子標籤序號).Text = (電子標籤序號 + 1).ToString()
                    GroupBox自訂(電子標籤序號).Left = 水平位置
                    GroupBox自訂(電子標籤序號).Top = 垂直位置
                    GroupBox自訂(電子標籤序號).Width = 66
                    GroupBox自訂(電子標籤序號).Height = 98

                    Label自訂(電子標籤序號) = New Label()
                    Label自訂(電子標籤序號).Name = "Label自訂_" & (電子標籤序號 + 1).ToString()
                    Label自訂(電子標籤序號).Text = (電子標籤序號 + 1).ToString()
                    Label自訂(電子標籤序號).Left = 27
                    Label自訂(電子標籤序號).Top = 18
                    Label自訂(電子標籤序號).Width = 30
                    Label自訂(電子標籤序號).Height = 12


                    Button自訂(電子標籤序號) = New Button()
                    Button自訂(電子標籤序號).Name = "Button自訂_" & (電子標籤序號 + 1).ToString()
                    Button自訂(電子標籤序號).Text = "學代" & Environment.NewLine & "科代"
                    Button自訂(電子標籤序號).Left = 6
                    Button自訂(電子標籤序號).Top = 33
                    Button自訂(電子標籤序號).Width = 52
                    Button自訂(電子標籤序號).Height = 33
                    'Button自訂(電子標籤序號).Size = New Size(70, 20)
                    'Button自訂(電子標籤序號).BackColor = Color.LawnGreen
                    'Button自訂(電子標籤序號).BackColor = Color.Yellow
                    'Button自訂(電子標籤序號).BackColor = Color.Red


                    ComboBox自訂(電子標籤序號) = New ComboBox()
                    ComboBox自訂(電子標籤序號).Name = "ComboBox自訂_" & (電子標籤序號 + 1).ToString()
                    'Button自訂(電子標籤序號).Text = "學代" & Environment.NewLine & "科代"
                    ComboBox自訂(電子標籤序號).Left = 6
                    ComboBox自訂(電子標籤序號).Top = 72
                    ComboBox自訂(電子標籤序號).Width = 52
                    ComboBox自訂(電子標籤序號).Height = 20



                    'If 不顯示的位置.Contains(i.ToString()) Then
                    '    GroupBox自訂(電子標籤序號).Visible = False

                    'End If



                    '事件註冊
                    'AddHandler CheckBox自訂(電子標籤序號).CheckedChanged, AddressOf CheckBox自訂_CheckedChanged
                    'AddHandler Button自訂(電子標籤序號).Click, AddressOf Button自訂_Click



                    'Panel1.Controls.Add(GroupBox自訂(電子標籤序號))



                    If 方向 = "直排" Then
                        '直排
                        SplitContainer自訂(x).Panel2.Controls.Add(GroupBox自訂(電子標籤序號))
                    ElseIf 方向 = "橫排" Then
                        '橫排
                        '取得架位資料
                        Dim 架位 As Integer = 0
                        架位 = 所有架位資料表.Tables(x).Rows(y)("架位") - 1
                        SplitContainer自訂(架位).Panel2.Controls.Add(GroupBox自訂(電子標籤序號))

                        'SplitContainer自訂(y).Panel2.Controls.Add(GroupBox自訂(電子標籤序號))
                    End If

                    GroupBox自訂(電子標籤序號).Controls.Add(Label自訂(電子標籤序號))
                    GroupBox自訂(電子標籤序號).Controls.Add(Button自訂(電子標籤序號))
                    GroupBox自訂(電子標籤序號).Controls.Add(ComboBox自訂(電子標籤序號))

                    電子標籤序號 = 電子標籤序號 + 1
                Next




            Next
        Next

        Dim g As Graphics
        g = Panel1.CreateGraphics()


    End Sub



    ''' <summary>
    ''' 自動產生CheckBox和Button
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub 自動產生CheckBox()

        Dim 架位數 As Integer = 1
        Dim 欄數 As Integer = 4
        Dim 列數 As Integer = 5
        Dim 按鍵數量 As Integer = 欄數 * 列數
        Dim 不顯示的位置 As New List(Of Integer)

        '不顯示的位置.Add("3")
        '不顯示的位置.Add("4")
        'Dim CheckBox自訂() As CheckBox


        Dim GroupBox自訂() As GroupBox
        Dim Label自訂() As Label
        Dim Button自訂() As Button
        Dim ComboBox自訂() As ComboBox
        Dim SplitContainer自訂() As SplitContainer


        'Dim ComboBox自訂_1 = New ComboBox

        ReDim GroupBox自訂(按鍵數量)
        ReDim Label自訂(按鍵數量)
        ReDim Button自訂(按鍵數量)
        ReDim ComboBox自訂(按鍵數量)
        ReDim SplitContainer自訂(架位數)


        Dim 高 As Integer = 0
        Dim 換行點 = 欄數
        Dim 水平間距 = 70
        Dim 垂直間距 = 100
        Dim 按鈕間距 = 100


        '畫架位
        For j As Integer = 0 To 架位數 - 1

            '畫電子標籤
            For i As Integer = 0 To 按鍵數量 - 1
                'Dim 樓層 As String = i.ToString() & "F"

                If (i Mod 換行點) = 0 And i <> 0 Then
                    高 += 垂直間距
                End If




                GroupBox自訂(i) = New GroupBox()
                GroupBox自訂(i).Name = "GroupBox自訂_" & (i + 1).ToString()
                GroupBox自訂(i).Text = (i + 1).ToString()
                GroupBox自訂(i).Left = CType((i Mod 換行點) * 水平間距, Integer) + 16
                GroupBox自訂(i).Top = 高
                GroupBox自訂(i).Width = 66
                GroupBox自訂(i).Height = 98

                Label自訂(i) = New Label()
                Label自訂(i).Name = "Label自訂_" & (i + 1).ToString()
                Label自訂(i).Text = (i + 1).ToString()
                Label自訂(i).Left = 27
                Label自訂(i).Top = 18
                Label自訂(i).Width = 30
                Label自訂(i).Height = 12


                Button自訂(i) = New Button()
                Button自訂(i).Name = "Button自訂_" & (i + 1).ToString()
                Button自訂(i).Text = "學代" & Environment.NewLine & "科代"
                Button自訂(i).Left = 6
                Button自訂(i).Top = 33
                Button自訂(i).Width = 52
                Button自訂(i).Height = 33
                'Button自訂(i).Size = New Size(70, 20)
                'Button自訂(i).BackColor = Color.LawnGreen
                'Button自訂(i).BackColor = Color.Yellow
                'Button自訂(i).BackColor = Color.Red


                ComboBox自訂(i) = New ComboBox()
                ComboBox自訂(i).Name = "ComboBox自訂_" & (i + 1).ToString()
                'Button自訂(i).Text = "學代" & Environment.NewLine & "科代"
                ComboBox自訂(i).Left = 6
                ComboBox自訂(i).Top = 72
                ComboBox自訂(i).Width = 52
                ComboBox自訂(i).Height = 20



                If 不顯示的位置.Contains(i.ToString()) Then
                    GroupBox自訂(i).Visible = False

                End If



                '事件註冊
                'AddHandler CheckBox自訂(i).CheckedChanged, AddressOf CheckBox自訂_CheckedChanged
                'AddHandler Button自訂(i).Click, AddressOf Button自訂_Click


                'Panel1.Controls.Add(CheckBox自訂(i))
                'Panel1.Controls.Add(Button自訂(i))
                Panel1.Controls.Add(GroupBox自訂(i))
                GroupBox自訂(i).Controls.Add(Label自訂(i))
                GroupBox自訂(i).Controls.Add(Button自訂(i))
                GroupBox自訂(i).Controls.Add(ComboBox自訂(i))

                'If i = 0 Then
                '    Exit For
                'End If
            Next
        Next

        Dim g As Graphics
        g = Panel1.CreateGraphics()


    End Sub



    Private Sub CheckBox自訂_CheckedChanged(sender As Object, e As EventArgs)
        Throw New NotImplementedException
    End Sub

    Private Sub Button自訂_Click(sender As Object, e As EventArgs)
        Throw New NotImplementedException
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'MessageBox.Show(Label1.Left.ToString())


        自動產生直橫排架位()
    End Sub

    
    Private Function 整理DataGridView() As DataTable

        'Dim 轉換成資料表 As New DataTable("轉換成資料表")
        Dim 架位資料表 As New DataTable("架位資料表")

        If DataGridView1.Rows.Count = 0 And DataGridView1.ColumnCount = 0 Then
            For i As Integer = 0 To 20
                If i = 0 Then
                    DataGridView1.Columns.Add(i.ToString(), "編號")
                Else
                    DataGridView1.Columns.Add(i.ToString(), i.ToString())
                End If

            Next
            For i As Integer = 0 To 20
                DataGridView1.Rows.Add()
                DataGridView1.Rows(i).Cells(0).Value = i + 1
            Next


            DataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells


        Else


            架位資料表.Columns.Add("架位")
            架位資料表.Columns.Add("列數")
            架位資料表.Columns.Add("燈號個數")

            架位資料表.Columns("架位").DataType = GetType(Integer)
            架位資料表.Columns("列數").DataType = GetType(Integer)
            架位資料表.Columns("燈號個數").DataType = GetType(Integer)

            Dim 最大欄位 As Integer = 0

            '寫入資料
            For i As Integer = 0 To DataGridView1.Rows.Count - 1

                Dim 檢查列值 As Integer = 0
                For j As Integer = 0 To DataGridView1.ColumnCount - 1
                    Dim 燈號個數 As Integer = 0

                    '找出最大欄數
                    If i = 0 Then
                        If DataGridView1.Rows(i).Cells((j + 1).ToString).Value Is Nothing Then
                            最大欄位 = j
                            Exit For
                        End If

                    Else

                        If 最大欄位 = j Then
                            Exit For
                        End If
                    End If



                    燈號個數 = DataGridView1.Rows(i).Cells((j + 1).ToString).Value
                    If 燈號個數 > 0 Then
                        架位資料表.Rows.Add(j + 1, i + 1, 燈號個數)
                    End If
                    檢查列值 = 檢查列值 + 燈號個數
                Next

                '若整行都沒資料就離開
                If 檢查列值 = 0 Then
                    Exit For
                End If
            Next

        End If




        Return 架位資料表
    End Function


    Private Sub CheckBox_資料表模式_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_資料表模式.CheckedChanged
        If CheckBox_資料表模式.Checked = True Then
            CheckBox_文字模式.Checked = False
            DataGridView1.Enabled = True
            RichTextBox1.Enabled = False
        End If
    End Sub

    Private Sub CheckBox_文字模式_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox_文字模式.CheckedChanged
        If CheckBox_文字模式.Checked = True Then
            CheckBox_資料表模式.Checked = False
            DataGridView1.Enabled = False
            RichTextBox1.Enabled = True
        End If
    End Sub
End Class
