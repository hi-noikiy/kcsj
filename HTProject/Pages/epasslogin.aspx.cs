using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Epoint.Frame.Bizlogic;
using Epoint.Frame.Common;

namespace WuxiJSJMis
{
	/// <summary>
	/// ePasslogin 的摘要说明。
	/// </summary>
	public partial class ePasslogin : BasePage
	{
        Epoint.Frame.Bizlogic.Frame_Config db_Fg = new Epoint.Frame.Bizlogic.Frame_Config();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
			if(!Page.IsPostBack)
			{
                this.Title = "";
                string systemName = ApplicationOperate.SystemName;
                if (systemName == "")
                {
                    this.Title = "协同办公系统";
                }
                this.Title = systemName;
                lblSysName.Text = systemName;
				//here we  generate a random number
				Random randomGenerator = new Random(DateTime.Now.Millisecond);

				String RandData = "";
				for(int i=0; i<19; i++)
					RandData += Convert.ToChar(randomGenerator.Next(97,122));
				Session["Message"] = RandData;
				Session["Message1"] =(char)(34)+ RandData+(char)(34) ;
                ViewState["Title"] = db_Fg.GetDetail("SystemName").ConfigValue;
			}
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
		}
		#endregion
	}
}
