<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ForumTop.aspx.cs" Inherits="WebApplication1.Form.ForumTop" %>
<!--①掲示板Top画面-->
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>掲示板</title>
</head>
<body>
    <form id="form1" runat="server">
        <main>
            <!-- 横並びにして、左右に広げて、縦中央に揃える -->
            <div style="display:flex; justify-content: space-between; align-items: center; padding: 10px;">
                <h1>掲示板</h1>
                <div>
                    <asp:Button
                        ID="ForumTop_UserModifyInput"
                        runat="server"
                        Text="会員情報変更"
                        BackColor="Aqua"
                        ForeColor ="White"
                        OnClick="ForumTop_UserModifyInput_Click"
                        />

                    <asp:Button
                        ID="ForumTop_UserWithdrawalInput"
                        runat="server"
                        Text="会員退会"
                        BackColor="Aqua"
                        ForeColor ="White"
                        OnClick="ForumTop_UserWithdrawalInput_Click"
                        />

                     <asp:Button
                         ID="ForumTop_Logout"
                         runat="server"
                         Text="ログアウト"
                         BackColor="Aqua"
                         ForeColor="White"
                         OnClick="ForumTop_Logout_Click" 
                         />
                </div>
            </div>

            <div style="text-align:center;">
                  <h2>掲示板フォーム</h2>
                  <asp:Button
                      ID="ForumTop_Post"
                      runat="server"
                      Text="投稿"
                      BackColor="Aqua"
                      ForeColor="White"
                      OnClick="ForumTop_Post_Click" 
                      />
            </div>

            
            <div style="width:400px; margin:0 auto; transform: translateX(-40px);"> <!-- 中央から左に少し寄せる -->
                <p>
                    <asp:Label 
                        ID="lblUserName1" 
                        runat="server" 
                        Text="作成者："
                        style="display:inline-block; width:80px; text-align:right;" 
                        />
                    <asp:Label 
                        ID="lblUserName2" 
                        runat="server" 
                        Text="名前" 
                        />
                </p>

                <p>
                    <asp:Label 
                        ID="lblTitel" 
                        runat="server" 
                        Text="タイトル：" 
                        />
                    <asp:TextBox 
                        ID="TextTitel" 
                        runat="server" 
                        MaxLength="15" 
                        Width="300px" 
                        Placeholder="15字以内" 
                        />
                </p>

                <p>
                    <asp:Label 
                        ID="lblContents" 
                        runat="server" 
                        Text="本文：" 
                        style="display:inline-block; width:80px; text-align:right; vertical-align: top;" 
                        />
                    <asp:TextBox
                        ID="TextContents"
                        runat="server"
                        TextMode="MultiLine"
                        Rows="10"
                        MaxLength="50"
                        Width="300px"
                        Placeholder="50字以内" />
                </p>

            </div>

            <asp:Repeater ID="Repeater1" runat="server">
                 <ItemTemplate>
                      <div style="text-align:center;">
                            <p>
                                #<%# Eval("forum_id") %>
                                投稿者：<%# Eval("name") %>
                                投稿日：<%# Eval("date_created", "{0:yyyy-MM-dd HH:mm:ss}") %>
                            </p>

                            <p>
                                タイトル：<%# Eval("forum_title") %>
                            </p>

                            <p>
                                本文：<%# Eval("forum_text") %>
                            </p>

                            <asp:Button
                                ID="ForumTop_Reply"
                                runat="server"
                                Text="レス"
                                CommandArgument='<%# Eval("forum_id") %>'
                                OnClick="ForumTop_Reply_Click" 
                                />

                      </div>
                </ItemTemplate>
            
            </asp:Repeater>



            


        </main>
    </form>
</body>
</html>
