<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegisterInput.aspx.cs" Inherits="WebApplication1.Form.User.UserRegisterInput" %>
<!-- ①会員登録情報入力画面 -->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ユーザー登録</title>
   
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <h1 id="aspnetTitle">アカウント作成</h1>
            <asp:TextBox
            ID="UserRegisterInput_NewUserName"
            runat="server"
            MaxLength="50"
            Placeholder="ユーザー名(50字以内)" />
            <br />
            <asp:TextBox
            ID="UserRegisterInput_NewLoginId"
            runat="server"
            MaxLength="15"
            MinLength="3"
            Placeholder="ログインID(15字以内)" />
            <br />
            <asp:TextBox
            ID="UserRegisterInput_NewUserPassword"
            runat="server"
            MaxLength="15"
            MinLength="6"
            TextMode="Password"
            Placeholder="パスワード(15字以内)" />
            <br />
            <asp:Label ID="UserRegisterInput_Error" runat="server" ></asp:Label>
            <asp:Button
            ID="UserRegisterInput_Confirm"
            runat="server"       
            Text="確認"
            BackColor="LightBlue"
            CssClass="btn btn-primary"
            OnClick="btu_UserRegisterInput_Confirm_Click" />
            <asp:Button
            ID="UserRegisterInput_Back"
            runat="server"       
            Text="戻る"
            BackColor="LightBlue"
            CssClass="btn btn-primary"
            OnClick="btu_UserRegisterInput_Back_Click" />
        </main>
    </form>
</body>
</html>
