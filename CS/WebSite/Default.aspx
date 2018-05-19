<%-- BeginRegion Page setup --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="HtmlEditor_CustomCommandAndDialog_CustomCommandAndDialog" %>
<%@ Register Assembly="DevExpress.Web.v8.1" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v8.1" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>  
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v8.1" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dxhe" %>

<%-- EndRegion --%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Implementing custom commands and dialogs</title>
    <script type="text/javascript">
        function OnCustomCommand(s, e) {
    if(e.commandName == "TestCommand") {
        // Handle command
        callbackPanel.PerformCallback(e.commandName);
    }
}
function OnEndCallback(s, e) {
    // Dialog received ('CustomDialog' name is predefined in the code-behind file)
    CustomDialog.Show(); 
}
        </script>
</head>
<body>
    <form id="form1" runat="server">
            
        <div>
            <%-- HtmlEditor --%>
            <dxhe:ASPxHtmlEditor ID="ASPxHtmlEditor1" runat="server" ClientInstanceName="htmlEditor">
                <ClientSideEvents CustomCommand="OnCustomCommand" />
                <Toolbars>
                    <dxhe:CustomToolbar Name="CustomToolbar1">
                        <Items>
                            <dxhe:CustomToolbarButton CommandName="TestCommand" Text="Test" ToolTip="Perform Custom Action">
                            </dxhe:CustomToolbarButton>
                        </Items>
                    </dxhe:CustomToolbar>
                </Toolbars>
            </dxhe:ASPxHtmlEditor>
        </div>
        <div>
            <%-- CallbackPanel - custom dialog receiver --%>
            <dxcp:ASPxCallbackPanel ID="cpDialogReceiver" runat="server" RenderMode="Div" OnCallback="OnCallback" ClientInstanceName="callbackPanel" ShowLoadingPanel="False">
                <ClientSideEvents EndCallback="OnEndCallback" />
            </dxcp:ASPxCallbackPanel>
        </div>
    </form>
</body>
</html>
