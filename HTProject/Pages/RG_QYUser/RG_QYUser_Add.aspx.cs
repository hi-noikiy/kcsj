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
using System.Collections.Specialized;
using Epoint.Web.UI.WebControls2X;
using Epoint.Frame.Common;
using HTProject_Bizlogic;
namespace HTProject.Pages.RG_QYUser
{

    public partial class RG_QYUser_Add : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 2019;
        HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        Epoint.MisBizLogic2.Web.AddPage oAddPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ViewState["TableName"] = oAddPage.TableDetail.TableName;
                #region 判断是否是辅表，如果是辅表，并且没有父表的RowID，自动转到相应的主表
                string ParentRowGuid = Request.QueryString["ParentRowGuid"];
                if (oAddPage.TableDetail.TableType == 2)
                {
                    if (ParentRowGuid == null || ParentRowGuid == "")
                    {
                        this.AlertAjaxMessage("禁止直接对子表添加记录！");
                        return;
                    }
                }
                #endregion
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
                //添加上传文件的大小和类型检查
                this.Add_FileUploadCheck_Script();

                InitTree();
            }
        }


        override protected void OnInit(EventArgs e)
        {
            oAddPage = new Epoint.MisBizLogic2.Web.AddPage(TableID);
            base.OnInit(e);
        }


        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            string RowGuid = Guid.NewGuid().ToString();
            //判断下身份证s是否已经有了
            string oName = "";
            if(RG_DW.IsExistByIDNO(IDNum_2019.Text.Trim(),out oName))
            {
                this.WriteAjaxMessage("alert('该身份证已经存在，姓名为：" + oName + "');");
                return;
            }
            //看注册章
            if (YinZhangNo_2019.Text.Trim() != "")
            {
                if (ZCZ_YXQ_2019.Text == "")
                {
                    //ZCZ_YXQ_2019.Text = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
                    this.WriteAjaxMessage("alert('请填写注册章1有效期');");
                    return;
                }
            }
            else
            {
                ZCZ_YXQ_2019.Text = "";
            }
            if (YinZhangNo1_2019.Text.Trim() != "")
            {
                if (ZCZ_YXQ1_2019.Text == "")
                {
                    //ZCZ_YXQ_2019.Text = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
                    this.WriteAjaxMessage("alert('请填写注册章2有效期');");
                    return;
                }
            }
            else
            {
                ZCZ_YXQ1_2019.Text = "";
            }
            if (YinZhangNo2_2019.Text.Trim() != "")
            {
                if (ZCZ_YXQ2_2019.Text == "")
                {
                    //ZCZ_YXQ_2019.Text = DateTime.Now.AddMonths(1).ToString("yyyy-MM-dd");
                    this.WriteAjaxMessage("alert('请填写注册章3有效期');");
                    return;
                }
            }
            else
            {
                ZCZ_YXQ2_2019.Text = "";
            }
            ZhuanYeCS_2019.Text = RegionTreeView.Text;
            ZhuanYeCSCode_2019.Text = RegionTreeView.Value;
            DWGuid_2019.Text = Request["DWGuid"];
            DelStatus_2019.SelectedValue = "0";
            Status_2019.Text = "60";
            string strSql = "select ZuZhiJGDM from RG_OUInfo where RowGuid='" + Request["DWGuid"] + "'";
            ZuZhiJGDM_2019.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            if (oAddPage.SaveTableValues_CheckExist(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]))
            {
                this.WriteAjaxMessage("window.location.href='RG_QYUser_Edit.aspx?RowGuid=" + RowGuid + "';alert('保存成功');refreshParent();");
            }
        }

        protected void btID_Click(object sender, System.EventArgs e)
        {
            string oName = "";
            if (RG_DW.IsExistByIDNO(IDNum_2019.Text.Trim(), out oName))
            {
                IDNum_2019.Text = "";
                this.WriteAjaxMessage("alert('该身份证已经存在，姓名为：" + oName + "');");
                return;
            }
        }


        #region "绑定"
        /// <summary>
        /// 初始化注册地区树结构
        /// </summary>
        private void InitTree()
        {
            RegionTreeView.Nodes.Clear();
            EpointTreeNode node = new EpointTreeNode();
            DataView dv = DataBaseFunc.Instace.GetTree("29b7967e-8098-42d5-8b40-ec757b0865a5", "");
            DataView dvCopy = dv.Table.Copy().DefaultView;
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode(dv[i]["ItemText"].ToString(), dv[i]["ItemCode"].ToString());
                DataView dv2 = DataBaseFunc.Instace.GetTreeLevelTwo(dv[i]["ItemCode"].ToString(), "29b7967e-8098-42d5-8b40-ec757b0865a5", "");
                if (dv2.Count >= 1)
                {
                    node.PopulateOnDemand = true;
                    //node.ShowInputCtrl = false;
                    node.ExpandOnCheckedChanged = false;
                    //node.ShowImage = true;
                    node.SelectLeafForTextTreeView = false;
                }
                else
                {
                    node.PopulateOnDemand = false;
                    
                }
                node.ShowInputCtrl = true;
                node.ShowImage = true;
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

            dv = DataBaseFunc.Instace.GetTreeLevelTwo(nodeArg.Value, "29b7967e-8098-42d5-8b40-ec757b0865a5", "");
            for (i = 0; i < dv.Count; i++)
            {
                nodeVar = new EpointTreeNode(dv[i]["ItemText"].ToString(), dv[i]["ItemCode"].ToString());   //实例化一个节点
                DataView dv2 = DataBaseFunc.Instace.GetTreeLevelTwo(dv[i]["ItemCode"].ToString(), "29b7967e-8098-42d5-8b40-ec757b0865a5", "");
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


