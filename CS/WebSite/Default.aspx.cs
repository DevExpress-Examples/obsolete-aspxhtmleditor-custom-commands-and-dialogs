using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxClasses;
using DevExpress.Web.ASPxCallbackPanel;
using DevExpress.Web.ASPxPopupControl;
using DevExpress.Web.ASPxEditors;

public partial class HtmlEditor_CustomCommandAndDialog_CustomCommandAndDialog : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {

    }
    protected void OnCallback(object source, CallbackEventArgsBase e) {
        if(e.Parameter == "TestCommand") {
            ASPxCallbackPanel callbackPanel = (ASPxCallbackPanel)source;
            callbackPanel.Controls.Clear();
            callbackPanel.Controls.Add(new MyUserControl(ASPxHtmlEditor1.ClientInstanceName));
        } else
            throw new NotSupportedException();
    }
}

public class MyUserControl : UserControl {
    private const string PopupClientInstanceName = "CustomDialog";

    public MyUserControl(string htmlEditorClientInstanceName) {
        ASPxPopupControl popup = new ASPxPopupControl();
        Controls.Add(popup);
        popup.HeaderText = "Custom Dialog";
        popup.CloseAction = CloseAction.None;
        popup.ClientInstanceName = PopupClientInstanceName;
        popup.PopupHorizontalAlign = PopupHorizontalAlign.WindowCenter;
        popup.PopupVerticalAlign = PopupVerticalAlign.WindowCenter;
        popup.AllowDragging = true;
        popup.BorderColor = System.Drawing.Color.FromArgb(0x6F, 0xB4, 0xE5);
        popup.HeaderStyle.BackColor = System.Drawing.Color.FromArgb(0xD9, 0xF2, 0xFC);
        popup.ShowCloseButton = false;

        Table table = new Table();
        table.Width = Unit.Percentage(100);
        popup.Controls.Add(table);
        TableRow row = new TableRow();
        table.Rows.Add(row);
        TableCell leftCell = new TableCell();
        row.Controls.Add(leftCell);
        TableCell rightCell = new TableCell();
        row.Controls.Add(rightCell);

        ASPxButton testButton = new ASPxButton();
        leftCell.Controls.Add(testButton);
        testButton.Text = "Test";
        testButton.Width = Unit.Percentage(100);
        testButton.AutoPostBack = false;
        testButton.ClientSideEvents.Click = string.Format("function(s, e) {{ {0}.SetHtml('Test Html'); }}", htmlEditorClientInstanceName);

        ASPxButton closeButton = new ASPxButton();
        rightCell.Controls.Add(closeButton);
        closeButton.Text = "Close";
        closeButton.Width = Unit.Percentage(100);
        closeButton.AutoPostBack = false;
        closeButton.ClientSideEvents.Click = string.Format("function(s, e) {{ {0}.Hide(); }}", PopupClientInstanceName);
    }
}