using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Form
{
	public partial class ForumTop : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// 未ログイン時の処理
			if (Session["user_id"] == null)
			{

				Response.Redirect("~/Default.aspx"); // デフォルトページへリダイレクト

			}

			if (!IsPostBack)
			{
				BindRepeater();
				if (Session["user_name"] != null && Session["user_id"] != null)
				{
					lblUserName2.Text = Session["user_name"].ToString();
					// レス作成者予定
					// LoadPosts(); 
				}
			}

		}

		// ユーザ情報変更ボタン
		protected void ForumTop_UserModifyInput_Click(object sender, EventArgs e)
		{

			Response.Redirect("~/Form/User/UserModifyInput.aspx"); // ユーザ情報変更画面へ遷移
		}

		// 退会ボタン
		protected void ForumTop_UserWithdrawalInput_Click(object sender, EventArgs e)
		{

			Response.Redirect("~/Form/User/UserWithdrawalInput.aspx"); // 会員退会完了画面へ遷移
		}

		// ログアウトボタン
		protected void ForumTop_Logout_Click(object sender, EventArgs e)
		{
			
			Session.Abandon(); // セッションを破棄してログアウト
			Response.Redirect("~/Default.aspx"); // ログアウト後はデフォルトページへ遷移
		}

		// フォーラムの返信ボタン
		protected void ForumTop_Reply_Click(object sender, EventArgs e)
		{
			
			Button btn = (Button)sender;
			string forumId = btn.CommandArgument;

			TextContents.Text = ""; // 返信入力欄をクリア

			// 返信内容にフォーラムIDを追加して返信入力欄に表示
			TextContents.Text = ">>" + forumId + "\r\n" + TextContents.Text;
			
		}

		// フォーラムの投稿ボタン
		protected void ForumTop_Post_Click(object sender, EventArgs e)
		{
			// 入力値を変数に格納
			string title = TextTitel.Text.Trim();
			string text = TextContents.Text.Trim();

			// 入力チェック
			if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(text))
			{
				return;
			}

			// ログイン中ユーザーIDを取得
			// ここは実際のログイン処理に合わせて変える
			int userId = Convert.ToInt32(Session["user_id"]);

			using (var sqlConnection = new SqlConnection(
				ConfigurationManager.ConnectionStrings["ForumDB"].ConnectionString))
			{
				sqlConnection.Open();

				var sql = @"
				INSERT INTO Forum
					(user_id, forum_title, forum_text, delete_flg, date_created, date_changed)
				VALUES
					(@user_id, @forum_title, @forum_text, 0, GETDATE(), GETDATE())";

				using (var cmd = new SqlCommand(sql, sqlConnection))
				{
					cmd.Parameters.AddWithValue("@user_id", userId);
					cmd.Parameters.AddWithValue("@forum_title", title);
					cmd.Parameters.AddWithValue("@forum_text", text);

					cmd.ExecuteNonQuery();
				}
			}

			// 入力欄クリア
			TextTitel.Text = "";
			TextContents.Text = "";

			// 一覧を再表示
			BindRepeater();
		}

		// 投稿内容表示
		private void BindRepeater()
		{
			using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ForumDB"].ConnectionString)) // データベース接続のためのSqlConnectionオブジェクトを作成
			{
				sqlConnection.Open(); // データベース接続

				// フォーラムの投稿内容を取得するSQLクエリ
				var sql = @"
                    SELECT
                        f.forum_id,
                        u.name,
                        f.forum_title,
                        f.forum_text,
                        f.date_created
                    FROM Forum f
                    INNER JOIN [User] u
                        ON f.user_id = u.user_id
                    WHERE f.delete_flg = 0
                    ORDER BY f.forum_id DESC";

				using (var cmd = new SqlCommand(sql, sqlConnection)) // SQL文と接続を指定してSqlCommandオブジェクトを作成
				{
					using (SqlDataAdapter da = new SqlDataAdapter(cmd)) // SQLクエリを実行してデータを取得するためのSqlDataAdapterオブジェクトを作成
					{
						DataTable dt = new DataTable();
						da.Fill(dt); // データベースから取得したデータをdtに格納

						Repeater1.DataSource = dt;
						Repeater1.DataBind();
					}
				}
			}
		}
	}

}
