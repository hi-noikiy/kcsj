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

    public partial class RG_QYUser_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 2019;
        Epoint.MisBizLogic2.Web.EditPage oEditPage;
        HTProject_Bizlogic.DataBaseFunc DBF = new DataBaseFunc();
        HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ViewState["TableName"] = oEditPage.TableDetail.TableName;
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
                if (!oRow.R_HasFilled)
                {
                    btnEdit.Visible = false;
                    this.AlertAjaxMessage("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }


                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
                //添加上传文件的大小和类型检查
                this.Add_FileUploadCheck_Script();

                RY_SFZ.ClientGuid = Request["RowGuid"] + "RY_SFZ";
                RY_SFZ.NodeCode = DWGuid_2019.Text;
                RY_SFZ.MisRowGuid = Request["RowGuid"];

                RY_BYZ.ClientGuid = Request["RowGuid"] + "RY_BYZ";
                RY_BYZ.NodeCode = DWGuid_2019.Text;
                RY_BYZ.MisRowGuid = Request["RowGuid"];

                RY_ZCZJ.ClientGuid = Request["RowGuid"] + "RY_ZCZJ";
                RY_ZCZJ.NodeCode = DWGuid_2019.Text;
                RY_ZCZJ.MisRowGuid = Request["RowGuid"];

                RY_ZhiCheng.ClientGuid = Request["RowGuid"] + "RY_ZhiCheng";
                RY_ZhiCheng.NodeCode = DWGuid_2019.Text;
                RY_ZhiCheng.MisRowGuid = Request["RowGuid"];

                RY_LDHT.ClientGuid = Request["RowGuid"] + "RY_LDHT";
                RY_LDHT.NodeCode = DWGuid_2019.Text;
                RY_LDHT.MisRowGuid = Request["RowGuid"];

                RY_GRQT.ClientGuid = Request["RowGuid"] + "RY_GRQT";
                RY_GRQT.NodeCode = DWGuid_2019.Text;
                RY_GRQT.MisRowGuid = Request["RowGuid"];

                RY_GRQM.ClientGuid = Request["RowGuid"] + "RY_GRQM";
                RY_GRQM.NodeCode = DWGuid_2019.Text;
                RY_GRQM.MisRowGuid = Request["RowGuid"];

                
                RegionTreeView.Text = ZhuanYeCS_2019.Text;
                RegionTreeView.Value = ZhuanYeCSCode_2019.Text;

                string strSql = "SELECT EnterpriseName FROM RG_OUInfo WHERE RowGuid='" + DWGuid_2019.Text + "'";
                lblDWName.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);

                if (oRow["Status"].ToString() == "90")//通过
                {
                    //btnEdit.Visible = false;
                }
                else if (oRow["Status"].ToString() == "80" || oRow["Status"].ToString() == "85")//不通过、变更中
                {
                    //btnEdit.Visible = false;
                }
                else if (oRow["Status"].ToString() == "70")//待审核
                {
                    btnEdit.Visible = false;
                    btnSubmit.Visible = false;
                    RY_SFZ.ReadOnly = true;
                    RY_BYZ.ReadOnly = true;
                    RY_ZCZJ.ReadOnly = true;
                    RY_ZhiCheng.ReadOnly = true;
                    RY_LDHT.ReadOnly = true;
                    RY_GRQT.ReadOnly = true;
                    RY_GRQM.ReadOnly = true;
                }
                lblSHOpinion.Text = RG_DW.GetSHOpinion(Request["RowGuid"], "");
            }
            InitTree();
        }

        protected string STATUS
        {
            get
            {
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
                return oRow["Status"].ToString();
            }
        }

        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            base.OnInit(e);
        }

        protected void btID_Click(object sender, System.EventArgs e)
        {
            string oName = "";
            if (RG_DW.IsExistByIDNO(IDNum_2019.Text.Trim(), out oName, Request["RowGuid"]))
            {
                IDNum_2019.Text = "";
                this.WriteAjaxMessage("alert('该身份证已经存在，姓名为：" + oName + "');");
                return;
            }
        }

        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            //判断下身份证s是否已经有了
            string oName = "";
            if (RG_DW.IsExistByIDNO(IDNum_2019.Text.Trim(), out oName, Request["RowGuid"]))
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
            //看看状态，是编辑中，还是已通过
            if (Status_2019.SelectedValue == "90")//审核通过的，保存是变成变更状态
            {
                Status_2019.SelectedValue = "85";
            }
            ZhuanYeCS_2019.Text = RegionTreeView.Text;
            ZhuanYeCSCode_2019.Text = RegionTreeView.Value;
            TJRGuid_2019.Text = this.UserGuid;
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);

            if (ApplicationOperate.GetConfigValueByName("IsHoldCurPage", "0") == "1")
                this.WriteAjaxMessage("refreshParentHoldCurPage();");
            else
                this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");
        }
        HTProject_Bizlogic.SMS HTSMS = new SMS();
        protected void btnSubmit_Click(object sender, System.EventArgs e)
        {
            //判断下身份证s是否已经有了
            string oName = "";
            if (RG_DW.IsExistByIDNO(IDNum_2019.Text.Trim(), out oName, Request["RowGuid"]))
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
            //看看有没有上传个人签名
            Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom StorgCom = new Epoint.Frame.Bizlogic.AttachStorageInfo.StorageCom();
            string CliGuid = Request["RowGuid"] + "RY_GRQM";
            DataView dvAttch = StorgCom.Select(CliGuid);
            if (dvAttch.Count == 0)
            {
                this.WriteAjaxMessage("alert('请上传个人签名');");
                return;
            }
            //先将原来的删除，防止重复
            new HTProject_Bizlogic.DB_Messages_Center().DeleteWH("人员信息审核", Request["RowGuid"]);
            ZhuanYeCS_2019.Text = RegionTreeView.Text;
            ZhuanYeCSCode_2019.Text = RegionTreeView.Value;
            TJRGuid_2019.Text = this.UserGuid;
            Status_2019.SelectedValue = "70";
            TJ_Date_2019.Text = DateTime.Now.ToString("yyyy-MM-dd");
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);

            //if (ApplicationOperate.GetConfigValueByName("IsHoldCurPage", "0") == "1")
            //    this.WriteAjaxMessage("refreshParentHoldCurPage();");
            //else
            //    this.WriteAjaxMessage("refreshParent();");
            //this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");
            //发送待审核事宜，根据角色来
            DataView dv = DBF.GetUserByRoleName("人员信息审核");

            for (int m = 0; m < dv.Count; m++)
            {
                string messageGuid = Guid.NewGuid().ToString();
                new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Insert(messageGuid,
                                    XM_2019.Text + "[" + lblDWName.Text + "]信息审核",
                                    "",
                                    dv[m]["UserGuid"].ToString(),
                                    dv[m]["DisplayName"].ToString(),
                                    "",
                                    "",
                                    "",
                                    @"HTProject/Pages/RG_QYUser/RG_QYUser_Detail.aspx?RowGuid=" + Request["RowGuid"],
                                    "",
                                    "",
                                    1,
                                    "",
                                    "",
                                    ""
                             );
                //更新标志位
                string strSql = "update messages_center set PType='人员信息审核',PGuid='" + Request["RowGuid"] + "' where MessageItemGuid='" + messageGuid + "'";
                Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);

                //添加短信
                string IsSendADSMS = ApplicationOperate.GetConfigValueByName("IsSendADSMS");
                if (IsSendADSMS == "1")
                {
                    if (dv[m]["Mobile"].ToString() != "")
                    {
                        HTSMS.SendSMS(this.DisplayName, dv[m]["DisplayName"], lblDWName.Text + "提交人员信息审核", dv[m]["Mobile"]);
                    }
                }
            }
            AlertAjaxMessage("提交成功");
        }

        protected void btnLiZhi_Click(object sender, System.EventArgs e)
        {
            TJRGuid_2019.Text = this.UserGuid;
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            
            //先将原来的删除，防止重复
            new HTProject_Bizlogic.DB_Messages_Center().DeleteWH("人员信息审核", Request["RowGuid"]);
            
            //发送待审核事宜，根据角色来
            DataView dv = DBF.GetUserByRoleName("人员信息审核");

            for (int m = 0; m < dv.Count; m++)
            {
                string messageGuid = Guid.NewGuid().ToString();
                new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Insert(messageGuid,
                                    oRow["XM"] + "[" + lblDWName.Text + "]离职申请审核",
                                    "",
                                    dv[m]["UserGuid"].ToString(),
                                    dv[m]["DisplayName"].ToString(),
                                    "",
                                    "",
                                    "",
                                    @"HTProject/Pages/RG_QYUser/RG_QYUser_LiZhi_Detail.aspx?RowGuid=" + Request["RowGuid"],
                                    "",
                                    "",
                                    1,
                                    "",
                                    "",
                                    ""
                             );
                //更新标志位
                string strSql = "update messages_center set PType='人员信息审核',PGuid='" + Request["RowGuid"] + "' where MessageItemGuid='" + messageGuid + "'";
                Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);

                //添加短信
                string IsSendADSMS = ApplicationOperate.GetConfigValueByName("IsSendADSMS");
                if (IsSendADSMS == "1")
                {
                    if (dv[m]["Mobile"].ToString() != "")
                    {
                        HTSMS.SendSMS(this.DisplayName, dv[m]["DisplayName"], lblDWName.Text + "提交人员离职申请", dv[m]["Mobile"]);
                    }
                }
            }
            AlertAjaxMessage("提交成功");
            WriteAjaxMessage("window.close();");
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
                if (dv2.Count > 0)
                {
                    node.PopulateOnDemand = true;
                    node.ShowInputCtrl = true;//有些没有注册专业，这样的话也让选择
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
