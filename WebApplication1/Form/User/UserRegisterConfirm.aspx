<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegisterConfirm.aspx.cs" Inherits="WebApplication1.Form.User.UserRegisterConfirm" %>
<!-- ②会員情報入力確認画面 -->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>会員情報入力確認</title>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <h1 id="aspnetTitle">登録内容確認</h1>
            <p>ユーザー名：<asp:Label ID="ResponseRedirect_UserName" runat="server"></asp:Label></p>
            <p>ログインID：<asp:Label ID="ResponseRedirect_LoginId" runat="server"></asp:Label></p>
            <p>パスワード：<asp:Label ID="ResponseRedirect_Password" runat="server"></asp:Label></p>
             <asp:Button
             ID="ResponseRedirect_Confirm"
             runat="server"       
             Text="登録"
             BackColor="LightBlue"
             CssClass="btn btn-primary"
             OnClick="Btn_ResponseRedirect_Confirm_Click" />
              <asp:Button
             ID="ResponseRedirect_Back"
             runat="server"       
             Text="戻る"
             BackColor="LightBlue"
             CssClass="btn btn-primary"
             OnClick="Btn_ResponseRedirect_Back_Click"/>
        </main>
    </form>
</body>
</html>
