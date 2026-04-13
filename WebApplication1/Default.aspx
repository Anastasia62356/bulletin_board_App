<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!-- ①TOP（ログイン）画面 -->
    <main>
        
        <h1 id="aspnetTitle">掲示板</h1>
        <br />
        <asp:TextBox
        ID="InputUserId"
        runat="server"
        MaxLength="15"
        MinLength="3"
        Placeholder="ログインID" />
        <br />

        <asp:TextBox
        ID="InputUserPassword"
        runat="server"
        MaxLength="15"
        MinLength="6"
        TextMode="Password"
        Placeholder="パスワード" />
        <br />
            
        <asp:Label ID="Defalut_Error" ForeColor="Red" runat="server" ></asp:Label>
        <br />
       <asp:Button
           ID="ButtonLogin"
           runat="server"       
           Text="ログイン"
           BackColor="LightBlue"
           OnClick="btu_Default_login_Click"/>
        
        <p>アカウントを持ってない方は
        <a href="Form/User/UserRegisterInput">アカウントを作成する</a>
        </p>

    </main>

</asp:Content>
