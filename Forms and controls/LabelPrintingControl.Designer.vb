<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LabelPrintingControl
  Inherits Twinvision.Glue.ControlBase

    'UserControl overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LabelPrintingControl))
    Me.geIncoming = New Janus.Windows.GridEX.GridEX()
    Me.cbMain = New Janus.Windows.UI.CommandBars.UICommandBar()
    Me.cmdRefresh1 = New Janus.Windows.UI.CommandBars.UICommand("Refresh")
    Me.Separator1 = New Janus.Windows.UI.CommandBars.UICommand("Separator")
    Me.PrintLabel1 = New Janus.Windows.UI.CommandBars.UICommand("PrintLabel")
    Me.cmdRefresh = New Janus.Windows.UI.CommandBars.UICommand("Refresh")
    Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
    Me.geIncomingLine = New Janus.Windows.GridEX.GridEX()
    Me.PrintLabel = New Janus.Windows.UI.CommandBars.UICommand("PrintLabel")
    Me.DesignReport = New Janus.Windows.UI.CommandBars.UICommand("DesignReport")
    Me.cbMenu = New Janus.Windows.UI.CommandBars.UICommandBar()
    Me.SubMenu1 = New Janus.Windows.UI.CommandBars.UICommand("SubMenu")
    Me.SubMenu = New Janus.Windows.UI.CommandBars.UICommand("SubMenu")
    Me.DesignReport1 = New Janus.Windows.UI.CommandBars.UICommand("DesignReport")
    CType(Me.CommandManager, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.geIncoming, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cbMain, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SplitContainer1.Panel1.SuspendLayout()
    Me.SplitContainer1.Panel2.SuspendLayout()
    Me.SplitContainer1.SuspendLayout()
    CType(Me.geIncomingLine, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.cbMenu, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'CommandManager
    '
    Me.CommandManager.CommandBars.AddRange(New Janus.Windows.UI.CommandBars.UICommandBar() {Me.cbMain, Me.cbMenu})
    Me.CommandManager.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.cmdRefresh, Me.PrintLabel, Me.DesignReport, Me.SubMenu})
    '
    '
    '
    Me.CommandManager.EditContextMenu.Key = ""
    Me.CommandManager.ShowAddRemoveButton = Janus.Windows.UI.InheritableBoolean.[False]
    Me.CommandManager.ShowCustomizeButton = Janus.Windows.UI.InheritableBoolean.[False]
    Me.CommandManager.VisualStyle = Janus.Windows.UI.VisualStyle.Office2010
    '
    'geIncoming
    '
    Me.geIncoming.AllowEdit = Janus.Windows.GridEX.InheritableBoolean.[False]
    Me.geIncoming.Dock = System.Windows.Forms.DockStyle.Fill
    Me.geIncoming.FilterMode = Janus.Windows.GridEX.FilterMode.Automatic
    Me.geIncoming.FilterRowButtonStyle = Janus.Windows.GridEX.FilterRowButtonStyle.ConditionOperatorDropDown
    Me.geIncoming.FilterRowUpdateMode = Janus.Windows.GridEX.FilterRowUpdateMode.WhenValueChanges
    Me.geIncoming.GroupByBoxVisible = False
    Me.geIncoming.Location = New System.Drawing.Point(0, 0)
    Me.geIncoming.Name = "geIncoming"
    Me.geIncoming.Size = New System.Drawing.Size(646, 213)
    Me.geIncoming.TabIndex = 4
    Me.geIncoming.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010
    Me.geIncoming.WatermarkImage.WashMode = Janus.Windows.GridEX.WashMode.UseWashColor
    '
    'cbMain
    '
    Me.cbMain.CommandManager = Me.CommandManager
    Me.cbMain.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.cmdRefresh1, Me.Separator1, Me.PrintLabel1})
    Me.cbMain.Key = "Default"
    Me.cbMain.Location = New System.Drawing.Point(0, 22)
    Me.cbMain.Name = "cbMain"
    Me.cbMain.RowIndex = 1
    Me.cbMain.Size = New System.Drawing.Size(272, 28)
    Me.cbMain.Text = "Main"
    '
    'cmdRefresh1
    '
    Me.cmdRefresh1.Key = "Refresh"
    Me.cmdRefresh1.Name = "cmdRefresh1"
    '
    'Separator1
    '
    Me.Separator1.CommandType = Janus.Windows.UI.CommandBars.CommandType.Separator
    Me.Separator1.Key = "Separator"
    Me.Separator1.Name = "Separator1"
    '
    'PrintLabel1
    '
    Me.PrintLabel1.Key = "PrintLabel"
    Me.PrintLabel1.Name = "PrintLabel1"
    '
    'cmdRefresh
    '
    Me.cmdRefresh.Icon = CType(resources.GetObject("cmdRefresh.Icon"), System.Drawing.Icon)
    Me.cmdRefresh.Key = "Refresh"
    Me.cmdRefresh.Name = "cmdRefresh"
    Me.cmdRefresh.Text = "Gegevens vernieuwen"
    '
    'SplitContainer1
    '
    Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
    Me.SplitContainer1.Location = New System.Drawing.Point(0, 50)
    Me.SplitContainer1.Name = "SplitContainer1"
    Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
    '
    'SplitContainer1.Panel1
    '
    Me.SplitContainer1.Panel1.Controls.Add(Me.geIncoming)
    '
    'SplitContainer1.Panel2
    '
    Me.SplitContainer1.Panel2.Controls.Add(Me.geIncomingLine)
    Me.SplitContainer1.Size = New System.Drawing.Size(646, 395)
    Me.SplitContainer1.SplitterDistance = 213
    Me.SplitContainer1.TabIndex = 5
    '
    'geIncomingLine
    '
    Me.geIncomingLine.Dock = System.Windows.Forms.DockStyle.Fill
    Me.geIncomingLine.GroupByBoxVisible = False
    Me.geIncomingLine.Location = New System.Drawing.Point(0, 0)
    Me.geIncomingLine.Name = "geIncomingLine"
    Me.geIncomingLine.Size = New System.Drawing.Size(646, 178)
    Me.geIncomingLine.TabIndex = 5
    Me.geIncomingLine.VisualStyle = Janus.Windows.GridEX.VisualStyle.Office2010
    Me.geIncomingLine.WatermarkImage.Image = CType(resources.GetObject("geIncomingLine.WatermarkImage.Image"), System.Drawing.Image)
    Me.geIncomingLine.WatermarkImage.WashMode = Janus.Windows.GridEX.WashMode.UseWashColor
    '
    'PrintLabel
    '
    Me.PrintLabel.Icon = CType(resources.GetObject("PrintLabel.Icon"), System.Drawing.Icon)
    Me.PrintLabel.Key = "PrintLabel"
    Me.PrintLabel.Name = "PrintLabel"
    Me.PrintLabel.Text = "Labels afdrukken"
    '
    'DesignReport
    '
    Me.DesignReport.Icon = CType(resources.GetObject("DesignReport.Icon"), System.Drawing.Icon)
    Me.DesignReport.Key = "DesignReport"
    Me.DesignReport.Name = "DesignReport"
    Me.DesignReport.Text = "Label aanpassen"
    '
    'cbMenu
    '
    Me.cbMenu.CommandBarType = Janus.Windows.UI.CommandBars.CommandBarType.Menu
    Me.cbMenu.CommandManager = Me.CommandManager
    Me.cbMenu.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.SubMenu1})
    Me.cbMenu.Key = "Menu"
    Me.cbMenu.Location = New System.Drawing.Point(0, 0)
    Me.cbMenu.Name = "cbMenu"
    Me.cbMenu.RowIndex = 0
    Me.cbMenu.Size = New System.Drawing.Size(646, 22)
    Me.cbMenu.Text = "Menu"
    '
    'SubMenu1
    '
    Me.SubMenu1.Key = "SubMenu"
    Me.SubMenu1.Name = "SubMenu1"
    '
    'SubMenu
    '
    Me.SubMenu.Commands.AddRange(New Janus.Windows.UI.CommandBars.UICommand() {Me.DesignReport1})
    Me.SubMenu.Key = "SubMenu"
    Me.SubMenu.Name = "SubMenu"
    Me.SubMenu.Text = "Instellingen"
    '
    'DesignReport1
    '
    Me.DesignReport1.Key = "DesignReport"
    Me.DesignReport1.Name = "DesignReport1"
    '
    'LabelPrintingControl
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.Controls.Add(Me.SplitContainer1)
    Me.Name = "LabelPrintingControl"
    Me.Size = New System.Drawing.Size(646, 445)
    Me.Controls.SetChildIndex(Me.SplitContainer1, 0)
    CType(Me.CommandManager, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.geIncoming, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cbMain, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer1.Panel1.ResumeLayout(False)
    Me.SplitContainer1.Panel2.ResumeLayout(False)
    CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.SplitContainer1.ResumeLayout(False)
    CType(Me.geIncomingLine, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.cbMenu, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)

  End Sub
  Friend WithEvents geIncoming As Janus.Windows.GridEX.GridEX
  Friend cbMain As Janus.Windows.UI.CommandBars.UICommandBar
  Friend cmdRefresh1 As Janus.Windows.UI.CommandBars.UICommand
  Friend cmdRefresh As Janus.Windows.UI.CommandBars.UICommand
  Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
  Friend WithEvents geIncomingLine As Janus.Windows.GridEX.GridEX
  Friend WithEvents Separator1 As Janus.Windows.UI.CommandBars.UICommand
  Friend WithEvents PrintLabel1 As Janus.Windows.UI.CommandBars.UICommand
  Friend WithEvents PrintLabel As Janus.Windows.UI.CommandBars.UICommand
  Friend WithEvents DesignReport As Janus.Windows.UI.CommandBars.UICommand
  Friend WithEvents cbMenu As Janus.Windows.UI.CommandBars.UICommandBar
  Friend WithEvents SubMenu1 As Janus.Windows.UI.CommandBars.UICommand
  Friend WithEvents SubMenu As Janus.Windows.UI.CommandBars.UICommand
  Friend WithEvents DesignReport1 As Janus.Windows.UI.CommandBars.UICommand

End Class
