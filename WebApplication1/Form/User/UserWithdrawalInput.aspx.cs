using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Form.User
{
	public partial class UserWithdrawalInput : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// 未ログイン時の処理
			if (Session["user_id"] == null)
			{
				
				Response.Redirect("~/Default.aspx"); // デフォルトページへリダイレクト

			}
		}

		// キャンセルボタン
		protected void btu_WithdrawalInput_Cancel(object sender, EventArgs e)
		{
			Response.Redirect("~/Default.aspx"); // キャンセル後はデフォルトページへ遷移
		}

		// 削除ボタン
		protected void btu_WithdrawalInput_delete(object sender, EventArgs e)
		{
			

			using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ForumDB"].ConnectionString)) // データベース接続のためのSqlConnectionオブジェクトを作成
			{
				sqlConnection.Open(); // データベース接続

				var sql = @"
					UPDATE[User]
					SET delete_flg = '1',date_changed = GETDATE()
					WHERE user_id = @user_id
					"; // SQL文格納 @LoginIDはSQLインジェクション回避のためのパラメータ

				using (var cmd = new SqlCommand(sql, sqlConnection)) // SQL文と接続を指定してSqlCommandオブジェクトを作成
				{
					cmd.Parameters.AddWithValue("@user_id", Convert.ToInt32(Session["user_id"])); // セッションからユーザIDを取得して、SQLパラメータに設定
					cmd.ExecuteNonQuery(); // SQL文を実行
				}
			}

		}
	}
}