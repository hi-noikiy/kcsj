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
	/// ePasslogin ��ժҪ˵����
	/// </summary>
	public partial class ePasslogin : BasePage
	{
        Epoint.Frame.Bizlogic.Frame_Config db_Fg = new Epoint.Frame.Bizlogic.Frame_Config();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
			if(!Page.IsPostBack)
			{
                this.Title = "";
                string systemName = ApplicationOperate.SystemName;
                if (systemName == "")
                {
                    this.Title = "Эͬ�칫ϵͳ";
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

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
		}
		#endregion
	}
}
