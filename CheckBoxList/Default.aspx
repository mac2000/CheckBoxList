<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="CheckBoxList.Default" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Custom CheckBoxList Example</title>
    <link rel="stylesheet" href="http://netdna.bootstrapcdn.com/bootstrap/latest/css/bootstrap.min.css">
</head>
<body>
    <form class="container-fluid" id="form1" runat="server">
        <acme:CheckBoxList ID="cbl" runat="server">
            <asp:ListItem Value="1" Text="Action"/>
            <asp:ListItem Value="2" Text="Drama"/>
            <asp:ListItem Value="3" Text="Detective"/>
        </acme:CheckBoxList>
        
        <p>
            <asp:Button ID="btn" runat="server" Text="Submit" OnClick="btn_Click" CssClass="btn btn-primary" />
        </p>
        
        <asp:Panel ID="pnlSelected" runat="server" CssClass="panel panel-success" Visible="false">
            <div class="panel-heading">Selected</div>
            <div class="panel-body"><asp:Literal ID="lblSelected" runat="server" /></div>
        </asp:Panel>

        <asp:Panel ID="pnlNotSelected" runat="server" CssClass="panel panel-danger" Visible="false">
            <div class="panel-heading">Not selected</div>
            <div class="panel-body"><asp:Literal ID="lblNotSelected" runat="server" /></div>
        </asp:Panel>
    </form>
</body>
</html>
