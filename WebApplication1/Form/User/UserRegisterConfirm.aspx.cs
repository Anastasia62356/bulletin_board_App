using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Form.User
{
	public partial class UserRegisterConfirm : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				string mode = Session["Session_mode"]?.ToString();

				if (mode == "edit")
				{
					ResponseRedirect_UserName.Text = Session["edit_user_name"]?.ToString();
					ResponseRedirect_LoginId.Text = Session["edit_login_id"]?.ToString();
					ResponseRedirect_Password.Text = Session["edit_password"]?.ToString();


				}
				else if (mode == "new")
				{
					ResponseRedirect_UserName.Text = Session["Session_user_name"]?.ToString();
					ResponseRedirect_LoginId.Text = Session["Session_login_id"]?.ToString();
					ResponseRedirect_Password.Text = Session["Session_password"]?.ToString();
				}
				else
				{
					Response.Redirect("~/Form/User/UserRegisterInput.aspx");
				}


			}
		}

		// 登録ボタン
		protected void Btn_ResponseRedirect_Confirm_Click(object sender, EventArgs e)
		{
			using (var sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["ForumDB"].ConnectionString)) // データベース接続のためのSqlConnectionオブジェクトを作成
			{
				string mode = Session["Session_mode"]?.ToString();
				if (mode == "edit")
				{
					sqlConnection.Open(); // データベース接続
					var sql = @"
					UPDATE [User]
					SET name = @name,
					login_id = @login_id,
					password = @password,
					date_changed = GETDATE()
					WHERE user_id = @user_id
					";
					using (var cmd = new SqlCommand(sql, sqlConnection)) // SQL文と接続を指定してSqlCommandオブジェクトを作成
					{
						//Sessionからユーザー情報を取得して、SQLパラメータに設定
						cmd.Parameters.AddWithValue("@login_id", Session["edit_login_id"] as string);
						cmd.Parameters.AddWithValue("@password", Session["edit_password"] as string);
						cmd.Parameters.AddWithValue("@name", Session["edit_user_name"] as string);
						cmd.Parameters.AddWithValue("@user_id", Convert.ToInt32(Session["user_id"]));

						cmd.ExecuteNonQuery(); // SQL文を実行
					}


				}
				else
				{

					sqlConnection.Open(); // データベース接続
					var sql = @"
					INSERT INTO[User]
					(login_id, password, name)
					VALUES
					(@login_id, @password, @name)
					";
					using (var cmd = new SqlCommand(sql, sqlConnection)) // SQL文と接続を指定してSqlCommandオブジェクトを作成
					{
						//Sessionからユーザー情報を取得して、SQLパラメータに設定
						cmd.Parameters.AddWithValue("@login_id", Session["Session_login_id"] as string);
						cmd.Parameters.AddWithValue("@password", Session["Session_password"] as string);
						cmd.Parameters.AddWithValue("@name", Session["Session_user_name"] as string);

						cmd.ExecuteNonQuery(); // SQL文を実行
					}
				}
			}


			Response.Redirect("~/Form/User/UserRegisterComplete.aspx");
		}

		// 戻るボタン
		protected void Btn_ResponseRedirect_Back_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Form/User/UserRegisterInput.aspx");
		}
	}
}