using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

		// ログインボタン
		protected void btu_Default_login_Click(object sender, EventArgs e)
		{
			// 入力値を変数に格納
			string loginId = InputUserId.Text;
			string password = InputUserPassword.Text;

			// 入力チェック：空欄
			if (string.IsNullOrEmpty(loginId) || string.IsNullOrEmpty(password))
			{
				Defalut_Error.Text = "ログインIDとパスワードを入力してください。";
				return;
			}

			using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ForumDB"].ConnectionString)) // データベース接続のためのSqlConnectionオブジェクトを作成
			{
				sqlConnection.Open(); // データベース接続
				var sql = @"
					SELECT user_id, name
					FROM [User]
					WHERE login_id = @login_id AND password = @password AND delete_flg = '0'
				";

				using (var cmd = new SqlCommand(sql, sqlConnection)) // SQL文と接続を指定してSqlCommandオブジェクトを作成
				{
					// 変数からユーザー情報を取得して、SQLパラメータに設定
					cmd.Parameters.AddWithValue("@login_id", loginId as string);
					cmd.Parameters.AddWithValue("@password", password as string);

					SqlDataReader reader = cmd.ExecuteReader();
					if (reader.Read()) // クエリの結果が存在する場合
					{
						// セッションへユーザー情報を格納
						Session["user_id"] = reader["user_id"];
						Session["user_name"] = reader["name"];
						Session["login_id"] = loginId;

						// フォーラムトップページへリダイレクト
						Response.Redirect("~/Form/Forum/ForumTop.aspx");
					}
					else // クエリの結果が存在しない場合（ログイン失敗）
					{
						Defalut_Error.Text = "ログインIDまたはパスワードが間違っています。";
						return;
					}
				}
			}
		}
    }
}