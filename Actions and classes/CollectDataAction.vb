Imports System.Runtime.Serialization
Imports System.Reflection

<FriendlyName("Gegevens ophalen"), Description("Gegevens ophalen uit Multivers Extended")>
Public Class CollectData
    Inherits ActionBase(Of CollectDataConfiguration)

    Public Overloads Overrides Function Run(collectDataConfiguration As CollectDataConfiguration) As CollectDataConfiguration
        Const totalProgressCount As Integer = 7

        Dim con As Odbc.OdbcConnection, cmd As Odbc.OdbcCommand, da As Odbc.OdbcDataAdapter
        Dim dt As DataTable, startDate As Date

        If collectDataConfiguration.UNIT4ExtendedConnectionString IsNot Nothing AndAlso collectDataConfiguration.UNIT4ExtendedConnectionString.ToString <> "" Then
            'Connect 2 Multivers Extended
            Try
                OnProgress(Me, New ProgressEventArgs(ProgressType.Start, My.Resources.messageConnecting, , New ProgressIndicator(My.Resources.messageConnecting, 1, 2)))
                con = New Odbc.OdbcConnection(collectDataConfiguration.UNIT4ExtendedConnectionString)
                con.Open()
                OnProgress(Me, New ProgressEventArgs(ProgressType.Success, My.Resources.messageConnecting, , New ProgressIndicator(My.Resources.messageConnected, 2, 2)))

                Try
                    collectDataConfiguration.dsCollectDataConfiguration = New DataSet
                    startDate = DateAdd(DateInterval.Month, -4, Date.Today)

                    'Select packlists
                    OnProgress(Me, New ProgressEventArgs(ProgressType.Start, My.Resources.messageSelectData, , New ProgressIndicator("Pakbonnen...", 1, totalProgressCount)))
                    cmd = New Odbc.OdbcCommand(String.Format(My.Resources.SQLSelectPackList, collectDataConfiguration.UNIT4ExtendedAdministrationNumber, "{" + String.Format("d '{0}'", startDate.ToString("yyyy-MM-dd")) + "}"), con)
                    da = New Odbc.OdbcDataAdapter(cmd)
                    dt = New DataTable
                    da.Fill(dt)
                    dt.TableName = "Packlist"
                    collectDataConfiguration.dsCollectDataConfiguration.Tables.Add(dt)

                    'Select packlist lines
                    OnProgress(Me, New ProgressEventArgs(ProgressType.Start, My.Resources.messageSelectData, , New ProgressIndicator("Pakbonregels...", 2, totalProgressCount)))
                    cmd = New Odbc.OdbcCommand(String.Format(My.Resources.SQLSelectPackListLine, collectDataConfiguration.UNIT4ExtendedAdministrationNumber, "{" + String.Format("d '{0}'", startDate.ToString("yyyy-MM-dd")) + "}"), con)
                    da = New Odbc.OdbcDataAdapter(cmd)
                    dt = New DataTable
                    da.Fill(dt)
                    dt.TableName = "PacklistLine"
                    collectDataConfiguration.dsCollectDataConfiguration.Tables.Add(dt)

                    'Select product description
                    OnProgress(Me, New ProgressEventArgs(ProgressType.Start, My.Resources.messageSelectData, , New ProgressIndicator("Producten...", 3, totalProgressCount)))
                    cmd = New Odbc.OdbcCommand(My.Resources.SQLSelectProductDescription, con)
                    da = New Odbc.OdbcDataAdapter(cmd)
                    dt = New DataTable
                    da.Fill(dt)
                    dt.TableName = "ProductDescription"
                    collectDataConfiguration.dsCollectDataConfiguration.Tables.Add(dt)

                    'Fill product description
                    OnProgress(Me, New ProgressEventArgs(ProgressType.Start, My.Resources.messageSelectData, , New ProgressIndicator("Buitenlandse omschrijvingen...", 4, totalProgressCount)))
                    Dim view As DataView = New DataView(collectDataConfiguration.dsCollectDataConfiguration.Tables("ProductDescription"))
                    Dim rows As DataRowView()

                    view.Sort = "PRODUCTNUMMER, TAALCODE"
                    For Each row As DataRow In collectDataConfiguration.dsCollectDataConfiguration.Tables("PackListLine").Rows
                        rows = view.FindRows(New String() {row("PRODUCTNUMMER").ToString, row("TAALCODE").ToString})
                        If rows.Count > 0 Then
                            row.BeginEdit()
                            row("PRODUCTNAAM") = rows(0)("PRODUCTNAAM")
                            row.EndEdit()
                        End If
                    Next

                    'Select product number customer
                    OnProgress(Me, New ProgressEventArgs(ProgressType.Start, My.Resources.messageSelectData, , New ProgressIndicator("Klanten...", 5, totalProgressCount)))
                    cmd = New Odbc.OdbcCommand(My.Resources.SQLSelectProductNumberCustomer, con)
                    da = New Odbc.OdbcDataAdapter(cmd)
                    dt = New DataTable
                    da.Fill(dt)
                    dt.TableName = "ProductNumberCustomer"
                    collectDataConfiguration.dsCollectDataConfiguration.Tables.Add(dt)

                    'Fill product numbers customers
                    OnProgress(Me, New ProgressEventArgs(ProgressType.Start, My.Resources.messageSelectData, , New ProgressIndicator("Artikelnummers klanten...", 6, totalProgressCount)))
                    view = New DataView(collectDataConfiguration.dsCollectDataConfiguration.Tables("ProductNumberCustomer"))

                    view.Sort = "PRODUCTNUMMER, EENHEID, DEBITEURNUMMER"
                    For Each row As DataRow In collectDataConfiguration.dsCollectDataConfiguration.Tables("PackListLine").Rows
                        rows = view.FindRows(New String() {row("PRODUCTNUMMER").ToString, row("EENHEID").ToString, row("DEBITEURNUMMER").ToString})
                        If rows.Count > 0 Then
                            row.BeginEdit()
                            row("PRODUCTNUMMERDEBITEUR") = rows(0)("PRODUCTNUMMERDEBITEUR")
                            row.EndEdit()
                        End If
                    Next

                    OnProgress(Me, New ProgressEventArgs(ProgressType.Success, My.Resources.messageSelectData, , New ProgressIndicator(My.Resources.messageDataSelected, totalProgressCount, totalProgressCount)))
                Catch exSelectIncoming As Exception
                    OnProgress(Me, New ProgressEventArgs(ProgressType.Message, My.Resources.messageUnableToSelectData, New LogEntry))
                    OnProgress(Me, New ProgressEventArgs(ProgressType.Failure, exSelectIncoming.Message, New LogEntry))
                End Try
            Catch exConnect As Exception
                OnProgress(Me, New ProgressEventArgs(ProgressType.Message, My.Resources.messageUnableToConnect, New LogEntry))
                OnProgress(Me, New ProgressEventArgs(ProgressType.Failure, exConnect.Message, New LogEntry))
            End Try
        Else
            OnProgress(Me, New ProgressEventArgs(ProgressType.Warning, My.Resources.messageConfigurationMissing, New LogEntry))
        End If
        Return collectDataConfiguration
    End Function
End Class

<DataContract()>
Public Class CollectDataConfiguration
  Implements IExtensibleDataObject

  <FriendlyName("Multivers Extended connectiestring"), DataMember(), ConfigurationEditor(ConfigurationEditorType.OLEDBConnectionPicker)>
  Public Property UNIT4ExtendedConnectionString As String
  <FriendlyName("Multivers Extended administratienummer"), DataMember()>
  Public Property UNIT4ExtendedAdministrationNumber As String
  <FriendlyName("Labelprinter"), DataMember(), ConfigurationEditor(ConfigurationEditorType.ComboBox, "Twinvision.Glue.FillPrinterCombo")>
  Public Property LabelPrinterName As String
  <ConfigurationOutput()>
  Public Property dsCollectDataConfiguration As DataSet

  Public Property ExtensionData As ExtensionDataObject Implements IExtensibleDataObject.ExtensionData

End Class

Public Class FillPrinterCombo
  Implements IConfigurationEditorComboBox

  Public Property Application As GlueApplication Implements IConfigurationEditorComboBox.Application

  Public ReadOnly Property Data As System.Collections.Generic.Dictionary(Of Object, String) Implements IConfigurationEditorComboBox.Data
    Get
      Dim dic As New Dictionary(Of Object, String)

      For Each s As String In Drawing.Printing.PrinterSettings.InstalledPrinters
        dic.Add(s, s)
      Next
      Return dic
    End Get
  End Property

End Class
