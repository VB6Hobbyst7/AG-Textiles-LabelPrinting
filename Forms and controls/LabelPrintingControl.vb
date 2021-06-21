Imports System.Reflection
Imports System.Data

<FriendlyName("Labels printen"), Selected(), SortOrder(-1)>
Public Class LabelPrintingControl
    Inherits Twinvision.Glue.ControlBase

    Private config As CollectDataConfiguration, dtPackListLine As DataTable, dtLabelData As New DataTable

    ' Friend WithEvents cmdMain As Janus.Windows.UI.CommandBars.UICommand

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.geIncoming.DefaultFilterRowComparison = Janus.Windows.GridEX.FilterConditionOperator.Contains
    End Sub

    Public Overrides Sub Activated()
        MyBase.Activated()

        RefreshData()
    End Sub

    Private Sub GetLabelData()
        Dim drLabel As DataRow, rows As DataRowView()
        Dim view As DataView = New DataView(config.dsCollectDataConfiguration.Tables("PacklistLine"))

        Try
            Me.geIncomingLine.Validate()
            dtLabelData = config.dsCollectDataConfiguration.Tables("PacklistLine").Clone()
            view.Sort = "PAKBONNUMMER"
            For Each geRow As Janus.Windows.GridEX.GridEXRow In Me.geIncoming.GetCheckedRows
                rows = view.FindRows(geRow.Cells("PAKBONNUMMER").Value.ToString)
                For Each row As DataRowView In rows
                    drLabel = dtLabelData.NewRow
                    drLabel.ItemArray = row.Row.ItemArray
                    dtLabelData.Rows.Add(drLabel)
                Next
            Next
        Catch ex As Exception
            Throw New Exception("De labeldata kan niet worden opgehaald: " + ex.Message)
        End Try
    End Sub

    Private Sub RefreshData()
        config = App.RunAction("CollectData")
        If config IsNot Nothing AndAlso config.dsCollectDataConfiguration IsNot Nothing AndAlso config.dsCollectDataConfiguration.Tables.Count > 0 Then
            Me.geIncoming.SetDataBinding(config.dsCollectDataConfiguration.Tables("Packlist"), "Table")
            Me.geIncoming.RetrieveStructure()
            Me.geIncoming.RootTable.Columns.Insert(0, New Janus.Windows.GridEX.GridEXColumn("Select", Janus.Windows.GridEX.ColumnType.CheckBox))
            Me.geIncoming.RootTable.Columns("Select").ActAsSelector = True
            Me.geIncoming.RootTable.Columns("Select").Width = 50
            Me.geIncoming.RootTable.Columns("DEBITEURNAAM").Width = 300
            If Me.geIncoming.RootTable.SortKeys.Count = 0 Then
                Me.geIncoming.RootTable.SortKeys.Add("PAKBONNUMMER", Janus.Windows.GridEX.SortOrder.Descending)
            End If
            If Me.geIncomingLine.RootTable IsNot Nothing AndAlso Me.geIncomingLine.RootTable.SortKeys.Count = 0 Then
                Me.geIncomingLine.RootTable.SortKeys.Add("Partijnummer")
            End If
        End If
        Try
            Me.geIncoming.Row = 0
        Catch ex As Exception
            Try
                Me.geIncoming.Row = 1
            Catch exAgain As Exception
            End Try
        End Try
    End Sub

    Private Sub CommandManager_CommandClick(sender As Object, e As Janus.Windows.UI.CommandBars.CommandEventArgs) Handles CommandManager.CommandClick
        Dim uri As Uri

        Select Case e.Command.Key
            Case "Refresh"
                RefreshData()
            Case "PrintLabel"
                Dim stiRep As New Stimulsoft.Report.StiReport, prtSettings As New Drawing.Printing.PrinterSettings

                Try
                    If Me.geIncoming.GetCheckedRows.Count > 0 Then
                        GetLabelData()
                        stiRep.RegData("Data", dtLabelData)
                        uri = New Uri(IO.Path.Combine(IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.CodeBase), "Reports\Label.mrt"))
                        stiRep.Load(uri.LocalPath)
                        If config.LabelPrinterName <> "" Then
                            prtSettings.PrinterName = config.LabelPrinterName
                            ' stiRep.Print(False, prtSettings)
                            stiRep.Show(True)
                        Else
                            MsgBox(My.Resources.messageNoLabelPrinter, MsgBoxStyle.Exclamation)
                        End If
                    Else
                        MsgBox(My.Resources.messageNoSelection, MsgBoxStyle.Exclamation)
                    End If
                Catch ex As Exception
                    MsgBox(My.Resources.messageLabelPrintError + vbCrLf + vbCrLf + ex.Message, MsgBoxStyle.Exclamation)
                End Try
            Case "DesignReport"
                Dim stiRep As New Stimulsoft.Report.StiReport

                Try
                    If Me.geIncoming.GetCheckedRows.Count > 0 Then
                        GetLabelData()
                        stiRep.RegData("Data", dtLabelData)
                        uri = New Uri(IO.Path.Combine(IO.Path.GetDirectoryName(Reflection.Assembly.GetExecutingAssembly.CodeBase), "Reports\Label.mrt"))
                        stiRep.Load(uri.LocalPath)
                        stiRep.Design(True)
                    Else
                        MsgBox(My.Resources.messageNoSelection, MsgBoxStyle.Exclamation)
                    End If
                Catch ex As Exception
                    MsgBox(My.Resources.messageLabelDesignError + vbCrLf + vbCrLf + ex.Message, MsgBoxStyle.Exclamation)
                End Try
        End Select
    End Sub

    Private Sub geIncoming_SelectionChanged(sender As Object, e As EventArgs) Handles geIncoming.SelectionChanged
        Dim rows As DataRowView(), view As DataView, dr As DataRow

        If Me.geIncoming.SelectedItems.Count > 0 AndAlso Me.geIncoming.SelectedItems(0).RowType = Janus.Windows.GridEX.RowType.Record Then
            view = New DataView(config.dsCollectDataConfiguration.Tables("PacklistLine"))
            view.Sort = "PAKBONNUMMER"
            rows = view.FindRows(Me.geIncoming.GetValue("PAKBONNUMMER").ToString)
            dtPackListLine = config.dsCollectDataConfiguration.Tables("PacklistLine").Clone
            For Each row As DataRowView In rows
                dr = dtPackListLine.NewRow
                dr.ItemArray = row.Row.ItemArray
                dtPackListLine.Rows.Add(dr)
            Next
            Me.geIncomingLine.SetDataBinding(dtPackListLine, "Table")
            Me.geIncomingLine.RetrieveStructure()
            For Each col As Janus.Windows.GridEX.GridEXColumn In Me.geIncomingLine.RootTable.Columns
                col.Selectable = False
                Select Case col.Key
                    Case "PARTIJOMSCHRIJVING", "PRODUCTNAAM"
                        col.Width = 300
                    Case "EENHEID", "TAALCODE", "DEBITEURNUMMER"
                        col.Visible = False
                End Select
            Next
        Else
            dtPackListLine.Clear()
        End If
    End Sub

End Class
