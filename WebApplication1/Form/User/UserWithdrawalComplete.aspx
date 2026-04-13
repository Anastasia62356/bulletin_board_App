<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserWithdrawalComplete.aspx.cs" Inherits="WebApplication1.Form.User.UserWithdrawalComplete" %>
<!-- ④会員退会完了画面 -->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>会員退会完了</title>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <h2>アカウントの削除が完了しました</h2>
            <asp:Button
                ID="WithdrawalComplete_Top"
                runat="server"
                Text="トップへ"
                BackColor="Aqua"
                ForeColor="White"
                OnClick="UserWithdrawalComplete_Top"/>
        </main>
    </form>
</body>
</html>
