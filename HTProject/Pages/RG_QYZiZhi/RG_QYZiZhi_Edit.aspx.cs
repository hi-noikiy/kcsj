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
using System.Text;
using System.Data.SqlClient;
using System.Collections.Specialized ;
using Epoint.Web.UI.WebControls2X;
using Epoint.Frame.Common;
using HTProject_Bizlogic;

namespace HTProject.Pages.RG_QYZiZhi
{
	
	public partial class RG_QYZiZhi_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
	{
	    public int TableID=2020;
	    Epoint.MisBizLogic2.Web.EditPage oEditPage;
        HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        HTProject_Bizlogic.DataBaseFunc DBF = new DataBaseFunc();
		protected void Page_Load(object sender, System.EventArgs e)
		{
			
			if (!Page.IsPostBack )
			{
                ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
				if (!oRow.R_HasFilled)
				{
					btnEdit.Visible = false;
				    this.AlertAjaxMessage ("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
					return;
				}
				
				
				
				Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
				//添加上传文件的大小和类型检查
                this.Add_FileUploadCheck_Script();
                RegionTreeView.Text = ZiZhiText_2020.Text;
                RegionTreeView.Value = ZiZhiTextCode_2020.Text;
                string strSql = "SELECT EnterpriseName FROM RG_OUInfo WHERE RowGuid='" + DWGuid_2020.Text + "'";
                lblDWName.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);

                ZZ_ZS_Z.ClientGuid = Request["RowGuid"] + "ZZ_ZS_Z";
                ZZ_ZS_Z.NodeCode = DWGuid_2020.Text;
                ZZ_ZS_Z.MisRowGuid = Request["RowGuid"];

                ZZ_ZS_F.ClientGuid = Request["RowGuid"] + "ZZ_ZS_F";
                ZZ_ZS_F.NodeCode = DWGuid_2020.Text;
                ZZ_ZS_F.MisRowGuid = Request["RowGuid"];

                if (oRow["Status"].ToString() == "90")//通过
                {
                    //btnEdit.Visible = false;
                }
                else if (oRow["Status"].ToString() == "80")//不通过
                {
                    //btnEdit.Visible = false;
                }
                else if (oRow["Status"].ToString() == "70")//待审核
                {
                    btnEdit.Visible = false;
                    btnSubmit.Visible = false;
                    ZZ_ZS_Z.ReadOnly = true;
                    ZZ_ZS_F.ReadOnly = true;
                }

                lblSHOpinion.Text = RG_DW.GetSHOpinion(Request["RowGuid"], "");
                
			}
            InitTree();
		}


        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage (TableID);
            base.OnInit(e);
        }
	

		protected void btnEdit_Click(object sender, System.EventArgs e)
		{
            //if (RG_DW.IsExistByZiZhi(ZiZhiCode_2020.Text.Trim(), Request["RowGuid"]))
            //{
            //    this.WriteAjaxMessage("alert('该资质编号已存在');");
            //    return;
            //}
            //看看状态，是编辑中，还是已通过
            if (Status_2020.SelectedValue == "90")//审核通过的，保存是变成变更状态
            {
                Status_2020.SelectedValue = "85";
            }
            ZiZhiText_2020.Text = RegionTreeView.Text;
            ZiZhiTextCode_2020.Text = RegionTreeView.Value;
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
			
            if (ApplicationOperate.GetConfigValueByName("IsHoldCurPage", "0") == "1")
                this.WriteAjaxMessage("refreshParentHoldCurPage();"); 
            else
                this.WriteAjaxMessage("refreshParent();"); 
			//this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')"); 
            this.WriteAjaxMessage("alert('保存成功，请及时提交审核');");
		}
        HTProject_Bizlogic.SMS HTSMS = new SMS();
        protected void btSubmit_Click(object sender, System.EventArgs e)
        {
            if (RG_DW.IsExistByZiZhi(ZiZhiCode_2020.Text.Trim(), Request["RowGuid"]))
            {
                this.WriteAjaxMessage("alert('该资质编号已存在');");
                return;
            }
            //先将原来的删除，防止重复
            new HTProject_Bizlogic.DB_Messages_Center().DeleteWH("审核企业资质", Request["RowGuid"]);
            ZiZhiText_2020.Text = RegionTreeView.Text;
            ZiZhiTextCode_2020.Text = RegionTreeView.Value;
            Status_2020.SelectedValue = "70";
            TJ_Date_2020.Text = DateTime.Now.ToString("yyyy-MM-dd");
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            //发送待审核事宜，根据角色来
            DataView dv = DBF.GetUserByRoleName("企业资质审核");

            for (int m = 0; m < dv.Count; m++)
            {
                string messageGuid = Guid.NewGuid().ToString();
                new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Insert(messageGuid,
                                    lblDWName.Text + "资质信息审核",
                                    "",
                                    dv[m]["UserGuid"].ToString(),
                                    dv[m]["DisplayName"].ToString(),
                                    "",
                                    "",
                                    "",
                                    @"HTProject/Pages/RG_QYZiZhi/RG_QYZiZhi_ADDetail.aspx?RowGuid=" + Request["RowGuid"],
                                    "",
                                    "",
                                    1,
                                    "",
                                    "",
                                    ""
                             );
                //更新标志位
                string strSql = "update messages_center set PType='审核企业资质',PGuid='" + Request["RowGuid"] + "' where MessageItemGuid='" + messageGuid + "'";
                Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);

                //添加短信
                string IsSendADSMS = ApplicationOperate.GetConfigValueByName("IsSendADSMS");
                if (IsSendADSMS == "1")
                {
                    if (dv[m]["Mobile"].ToString() != "")
                    {
                        HTSMS.SendSMS(this.DisplayName, dv[m]["DisplayName"], lblDWName.Text + "提交资质信息审核", dv[m]["Mobile"]);
                    }
                }

            }
            AlertAjaxMessage("提交成功");
            this.WriteAjaxMessage("refreshParent();window.close();");
        }

        #region "绑定"
        /// <summary>
        /// 初始化注册地区树结构
        /// </summary>
        private void InitTree()
        {
            RegionTreeView.Nodes.Clear();
            EpointTreeNode node = new EpointTreeNode();
            DataView dv = DataBaseFunc.Instace.GetTree("f7f84f2a-de8a-4bc2-b13d-e541f73b12a8","");
            DataView dvCopy = dv.Table.Copy().DefaultView;
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode(dv[i]["ItemText"].ToString(), dv[i]["ItemCode"].ToString());
                DataView dv2 = DataBaseFunc.Instace.GetTreeLevelTwo(dv[i]["ItemCode"].ToString(), "f7f84f2a-de8a-4bc2-b13d-e541f73b12a8", "");
                if (dv2.Count >= 1)
                {
                    node.PopulateOnDemand = true;
                    node.ShowInputCtrl = false;
                    node.ExpandOnCheckedChanged = false;
                    node.ShowImage = true;
                    node.SelectLeafForTextTreeView = false;
                }
                else
                {
                    node.PopulateOnDemand = false;
                    node.ShowInputCtrl = true;
                    node.ShowImage = true;
                }
                RegionTreeView.Nodes.Add(node);
            }
        }

        /// <summary>
        /// 注册地区树形结构展开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void RegionTreeView_TreeNodePopulate(object sender, EpointTreeNodeEventArgs e)
        {
            EpointTreeNode nodeArg = e.Node;
            EpointTreeNode nodeVar;
            DataView dv;
            int i = 0;

            dv = DataBaseFunc.Instace.GetTreeLevelTwo(nodeArg.Value, "f7f84f2a-de8a-4bc2-b13d-e541f73b12a8", "");
            for (i = 0; i < dv.Count; i++)
            {
                nodeVar = new EpointTreeNode(dv[i]["ItemText"].ToString(), dv[i]["ItemCode"].ToString());   //实例化一个节点
                DataView dv2 = DataBaseFunc.Instace.GetTreeLevelTwo(dv[i]["ItemCode"].ToString(), "f7f84f2a-de8a-4bc2-b13d-e541f73b12a8", "");
                if (dv2.Count > 0)
                {
                    nodeVar.ShowInputCtrl = false;
                    nodeVar.PopulateOnDemand = true;
                    nodeVar.ExpandOnCheckedChanged = false;
                    nodeVar.SelectLeafForTextTreeView = false;
                    nodeVar.ShowImage = false;
                }
                else
                {
                    nodeVar.ShowInputCtrl = true;
                    nodeVar.PopulateOnDemand = false;
                    nodeVar.ShowImage = false;
                    nodeVar.SelectLeafForTextTreeView = true;
                    nodeVar.CanSelectForTextTreeView = true;
                    nodeVar.ReturnFullPath = true;
                }
                nodeArg.ChildNodes.Add(nodeVar);
            }

        }
        #endregion

		
   }
}
