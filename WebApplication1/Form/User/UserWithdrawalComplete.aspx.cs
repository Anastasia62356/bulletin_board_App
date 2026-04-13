using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Form.User
{
	public partial class UserWithdrawalComplete : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			// 未ログイン時の処理
			if (Session["user_id"] == null)
			{

				Response.Redirect("~/Default.aspx"); // デフォルトページへリダイレクト

			}
		}
		protected void UserWithdrawalComplete_Top(object sender, EventArgs e)
		{
			Session.Abandon(); // セッションを破棄してログアウト状態にする
			Response.Redirect("~/Default.aspx"); // デフォルトページへリダイレクト
		}
	}
}