<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserWithdrawalInput.aspx.cs" Inherits="WebApplication1.Form.User.UserWithdrawalInput" %>
<!-- ⑤会員退会画面 -->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>アカウント削除</title>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <h2>アカウントを削除しますか</h2>
            <p>このアカウントを削除しますか</p>

            <asp:Button
            ID="WithdrawalInput_Cancel"
            runat="server"
            Text="キャンセル"
            BackColor="Aqua"
            ForeColor="White"
            OnClick="btu_WithdrawalInput_Cancel"
            />
            <asp:Button
            ID="WithdrawalInput_cdelite"
            runat="server"
            Text="削除"
            BackColor="Aqua"
            ForeColor="White"
            OnClick="btu_WithdrawalInput_delete"
            />

        </main>
    </form>
</body>
</html>
