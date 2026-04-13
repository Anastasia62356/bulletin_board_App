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
	public partial class UserRegisterInput : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		// 確認ボタン
		protected void btu_UserRegisterInput_Confirm_Click(object sender, EventArgs e)
		{
			// 入力値を変数に格納
			string userName = UserRegisterInput_NewUserName.Text;
			string loginID = UserRegisterInput_NewLoginId.Text;
			string password = UserRegisterInput_NewUserPassword.Text;

			// 入力チェック：空欄
			if (userName == "" || loginID == "" || password == "")
			{
				UserRegisterInput_Error.Text = "すべての項目を入力してください";
				return;
			}

			// ログインID長さチャック
			if (loginID.Length < 3 || loginID.Length > 15)
			{
				UserRegisterInput_Error.Text = "ログインIDは3文字以上15文字以下で入力してください";
				return;
			}

			// パスワード形式をチェック
			if (password.Length < 6 || password.Length > 15 || !IsHalfAlphanumeric(password))
			{
				UserRegisterInput_Error.Text = "パスワードは6～15文字の半角英数字で入力してください。";
				return;
			}

			// 重複チェック
			if (IsDuplicateLoginID(loginID))
			{
				UserRegisterInput_Error.Text = "すでに利用されているログインIDです。";
				return;
			}

			// セッションへ情報格納
			Session["Session_user_name"] = userName;
			Session["Session_login_id"] = loginID;
			Session["Session_password"] = password;
			Session["Session_mode"] = "new";

			// ユーザ登録確認画面へ遷移
			Response.Redirect("~/Form/User/UserRegisterConfirm.aspx");
		}


		protected void btu_UserRegisterInput_Back_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Default.aspx");
		}


		// ログインIDが重複しているか判定し真偽値で返す関数
		private bool IsDuplicateLoginID(string loginID)
		{
			using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ForumDB"].ConnectionString)) // データベース接続のためのSqlConnectionオブジェクトを作成
			{
				sqlConnection.Open(); // データベース接続
				var sql = "SELECT COUNT(*) FROM [User] WHERE login_id = @login_id"; // SQL文格納 @LoginIDはSQLインジェクション回避のためのパラメータ
				using (var cmd = new SqlCommand(sql, sqlConnection)) // SQL文と接続を指定してSqlCommandオブジェクトを作成
				{
					cmd.Parameters.AddWithValue("@login_id", loginID); // @login_idにloginIDを格納
					int count = (int)cmd.ExecuteScalar(); // SQL文を実行し、結果の最初の行の最初の列を整数型で取得し、countに格納
					return count > 0; // countが0より大きい場合は重複していると判断し、trueを返す。そうでない場合はfalseを返す。
				}
			}

		}

		// パスワードが半角英数字のみで構成されているかを判定し、真偽値で返す関数
		private bool IsHalfAlphanumeric(string input)
		{
			foreach (char c in input) // 入力文字列の各文字を末尾までループで処理
			{
				if (!char.IsLetterOrDigit(c) || char.IsWhiteSpace(c))
				{
					return false; // 半角英数字以外の文字が含まれている場合はfalseを返す
				}
			}
			return true; // すべての文字が半角英数字の場合はtrueを返す


		}


	}
}