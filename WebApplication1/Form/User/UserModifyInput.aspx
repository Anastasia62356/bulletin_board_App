<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserModifyInput.aspx.cs" Inherits="WebApplication1.Form.User.UserModifyInput" %>
<!-- ④会員編集画面 -->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>会員編集</title>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <h2>会員情報変更</h2>
            <p>変更したい情報を入力してください</p>

            <p>
                新しいユーザー名
                <br />
                <asp:TextBox
                    ID="Modify_UserName"
                    runat="server"
                    MaxLength="50"
                    Placeholder="50文字以内" />
            </p>

            <p>
                新しいログインID
                <br />
                <asp:TextBox
                    ID="Modify_LoginId"
                    runat="server"
                    MaxLength="15"
                    Placeholder="15文字以内" />
            </p>

            <p>
                新しいパスワード
                <br />
                <asp:TextBox
                    ID="Modify_Password"
                    runat="server"
                    MaxLength="15"
                    TextMode="Password"
                    Placeholder="15文字以内" />
            </p>

            <asp:Label ID="Modify_Error" runat="server" ></asp:Label>
            <p>
                <asp:Button
                    ID="Modify_Check"
                    runat="server"
                    Text="確認する"
                    BackColor="Aqua"
                    ForeColor="White"
                    OnClick="btu_Modify_Check"
                    />

                <asp:Button
                    ID="Modify_Back"
                    runat="server"
                    Text="戻る"
                    BackColor="Aqua"
                    ForeColor="White"
                    OnClick="btu_Modify_Back_Click"
                    />
            </p>
        </main>
    </form>
</body>
</html>
