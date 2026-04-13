using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Form.User
{
	public partial class UserRegisterComplete : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}

		protected void Btn_UserRegisterComplete_ToLogin_Click(object sender, EventArgs e)
		{
			Response.Redirect("~/Default.aspx");
		}
	}
}