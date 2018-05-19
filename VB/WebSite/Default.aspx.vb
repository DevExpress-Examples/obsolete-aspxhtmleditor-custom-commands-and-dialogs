Imports Microsoft.VisualBasic
Imports System
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxClasses
Imports DevExpress.Web.ASPxCallbackPanel
Imports DevExpress.Web.ASPxPopupControl
Imports DevExpress.Web.ASPxEditors

Partial Public Class HtmlEditor_CustomCommandAndDialog_CustomCommandAndDialog
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

	End Sub
	Protected Sub OnCallback(ByVal source As Object, ByVal e As CallbackEventArgsBase)
		If e.Parameter = "TestCommand" Then
			Dim callbackPanel As ASPxCallbackPanel = CType(source, ASPxCallbackPanel)
			callbackPanel.Controls.Clear()
			callbackPanel.Controls.Add(New MyUserControl(ASPxHtmlEditor1.ClientInstanceName))
		Else
			Throw New NotSupportedException()
		End If
	End Sub
End Class

Public Class MyUserControl
	Inherits UserControl
	Private Const PopupClientInstanceName As String = "CustomDialog"

	Public Sub New(ByVal htmlEditorClientInstanceName As String)
		Dim popup As New ASPxPopupControl()
		Controls.Add(popup)
		popup.HeaderText = "Custom Dialog"
		popup.CloseAction = CloseAction.None
		popup.ClientInstanceName = PopupClientInstanceName
		popup.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter
		popup.PopupVerticalAlign = PopupVerticalAlign.WindowCenter
		popup.AllowDragging = True
		popup.BorderColor = System.Drawing.Color.FromArgb(&H6F, &HB4, &HE5)
		popup.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(&HD9, &HF2, &HFC)
		popup.ShowCloseButton = False

		Dim table As New Table()
		table.Width = Unit.Percentage(100)
		popup.Controls.Add(table)
		Dim row As New TableRow()
		table.Rows.Add(row)
		Dim leftCell As New TableCell()
		row.Controls.Add(leftCell)
		Dim rightCell As New TableCell()
		row.Controls.Add(rightCell)

		Dim testButton As New ASPxButton()
		leftCell.Controls.Add(testButton)
		testButton.Text = "Test"
		testButton.Width = Unit.Percentage(100)
		testButton.AutoPostBack = False
		testButton.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.SetHtml('Test Html'); }}", htmlEditorClientInstanceName)

		Dim closeButton As New ASPxButton()
		rightCell.Controls.Add(closeButton)
		closeButton.Text = "Close"
		closeButton.Width = Unit.Percentage(100)
		closeButton.AutoPostBack = False
		closeButton.ClientSideEvents.Click = String.Format("function(s, e) {{ {0}.Hide(); }}", PopupClientInstanceName)
	End Sub
End Class