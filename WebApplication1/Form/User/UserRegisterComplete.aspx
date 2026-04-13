<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegisterComplete.aspx.cs" Inherits="WebApplication1.Form.User.UserRegisterComplete" %>
<!-- ③会員登録完了画面 -->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>登録完了しました</title>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <h1 id="aspnetTitle">登録完了しました</h1>
            <asp:Button
         ID="UserRegisterComplete_Top"
         runat="server"       
         Text="ログインページへ"
         BackColor="LightBlue"
         OnClick="Btn_UserRegisterComplete_ToLogin_Click" />
        </main>
    </form>
</body>
</html>
