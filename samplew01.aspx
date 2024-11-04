<%@ Page Language="C#" AutoEventWireup="true" CodeFile="samplew01.aspx.cs" Inherits="samplew01" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            sample web 01
        </div>

         <br /><br />
         <asp:GridView ID="GridView1" runat="server"></asp:GridView>

         <br /><br />
         <asp:Button ID="Button1" runat="server" Text="Print" OnClick="btnPrint_Click"   />
    </form>
</body>
</html>
