#Region "ABOUT"
' / --------------------------------------------------------------------------------
' / Developer : Mr.Surapon Yodsanga (Thongkorn Tubtimkrob)
' / eMail : thongkorn@hotmail.com
' / URL: http://www.g2gnet.com (Khon Kaen - Thailand)
' / Facebook: https://www.facebook.com/g2gnet (For Thailand)
' / Facebook: https://www.facebook.com/commonindy (Worldwide)
' / More Info: http://www.g2gsoft.com
' / 
' / Purpose: Create ListView & ImageList Control dynamically.
' / Microsoft Visual Basic .NET (2010)
' / --------------------------------------------------------------------------------
' / Orginal Source: ListView.LargeImageList Property.
' / https://msdn.microsoft.com/en-us/library/system.windows.forms.listview.largeimagelist.aspx
#End Region

Public Class frmListViewImage

    '// Create a new ListView control dynamically.
    Private listView1 As New ListView()

    Private Sub frmListViewImage_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Call CreateMyListView()
    End Sub

    Private Sub CreateMyListView()
        listView1.Bounds = New Rectangle(New Point(10, 10), New Size(370, 500))

        '// Set the view to show details.
        With listView1
            '// Set ListView view mode to show Large Icons.
            .View = View.LargeIcon
            .Cursor = Cursors.Hand
            '// Adjust to the size of the form.
            .Anchor = AnchorStyles.Bottom + AnchorStyles.Left + AnchorStyles.Right + AnchorStyles.Top
        End With

        ' / --------------------------------------------------------------------------------
        ' / SAMPLE BASIC ... Static ListView control
        ' / Create items and sets of subitems for each item.
        'Dim item1 As New ListViewItem("Table 1", 0)
        'Dim item2 As New ListViewItem("Table 2", 1)
        'Dim item3 As New ListViewItem("Table 3", 0)
        'Dim item4 As New ListViewItem("Table 4", 0)
        'Dim item5 As New ListViewItem("Table 5", 1)
        'Dim item6 As New ListViewItem("Table 6", 1)
        'Dim item7 As New ListViewItem("Table 7", 0)
        'Add the items to the ListView.
        'listView1.Items.AddRange(New ListViewItem() {item1, item2, item3, item4, item5, item6, item7})
        ' / --------------------------------------------------------------------------------

        listView1.Columns.Add("Column 1", -2, HorizontalAlignment.Left)
        listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left)
        ' / --------------------------------------------------------------------------------
        ' / @Run Time or Dynamically.
        Dim Items As New List(Of ListViewItem)
        Dim RancomClass As New Random()
        For i As Integer = 0 To 16
            '// Text and Images index
            Dim item As New ListViewItem("Table " & i + 1, RancomClass.Next(0, 10) Mod 2)
            Items.Add(item)
        Next
        listView1.Items.AddRange(Items.ToArray)

        '// Create ImageList objects.
        Dim imgList As New ImageList()
        imgList.ImageSize = New Size(128, 128)
        Dim strPath As String = MyPath(Application.StartupPath)
        '// Initialize the ImageList objects with bitmaps.
        imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-green.png"))
        imgList.Images.Add(Bitmap.FromFile(strPath & "png\table-icon-red.png"))

        '// Assign the ImageList objects to the ListView.
        listView1.LargeImageList = imgList

        '// Add the ListView to the control collection.
        Me.Controls.Add(listView1)
        '// start event handling at any time during program execution.
        AddHandler listView1.Click, AddressOf listView1_Click

    End Sub 'CreateMyListView

    '// Event Handler.
    Private Sub listView1_Click(sender As System.Object, e As EventArgs)
        MsgBox(listView1.SelectedItems.Item(0).Text)
    End Sub

    ' / --------------------------------------------------------------------------------
    ' / Get my project path
    ' / AppPath = C:\My Project\bin\debug
    ' / Replace "\bin\debug" with "\"
    ' / Return : C:\My Project\
    Function MyPath(AppPath As String) As String
        '/ Return Value
        MyPath = AppPath.ToLower.Replace("\bin\debug", "\").Replace("\bin\release", "\").Replace("\bin\x86\debug", "\")
        '// Put the BackSlash "\" or ASCII Code = 92 at the end.
        If Microsoft.VisualBasic.Right(MyPath, 1) <> Chr(92) Then MyPath = MyPath & Chr(92)
    End Function

End Class
