/*
 * 编辑中、审核退回
 * 该页面功能暂停使用
 */
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
using Epoint.Frame.Bizlogic;

namespace HTProject.Pages.RG_OU
{

    public partial class RG_OU_Edit2 : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 2017;
        Epoint.MisBizLogic2.Web.EditPage oEditPage;
        HTProject_Bizlogic.DataBaseFunc DBF = new DataBaseFunc();
        public int TableZZID = 2020;
        Epoint.MisBizLogic2.Web.ListPage oZZListPage;
        public int TableRYID = 2019;
        Epoint.MisBizLogic2.Web.ListPage oRYListPage;
        protected HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        HTProject_Bizlogic.DB_Messages_Center DB_MC = new HTProject_Bizlogic.DB_Messages_Center();
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

               
                RegionTreeView.Text = RegistAddress_2017.Text;
                RegionTreeView.Value = RegistAddressCode_2017.Text;

                QY_GSZZ_Z.ClientGuid = Request["RowGuid"] + "QY_GSZZ_Z";
                QY_GSZZ_Z.ClientTag = "工商营业执照(正本)";
                QY_GSZZ_Z.NodeCode = Request["RowGuid"];
                QY_GSZZ_Z.MisRowGuid = Request["RowGuid"];

                QY_GSZZ_F.ClientGuid = Request["RowGuid"] + "QY_GSZZ_F";
                QY_GSZZ_F.ClientTag = "工商营业执照(副本)";
                QY_GSZZ_F.NodeCode = Request["RowGuid"];
                QY_GSZZ_Z.MisRowGuid = Request["RowGuid"];

                QY_ZZJGDMZ.ClientGuid = Request["RowGuid"] + "QY_ZZJGDMZ";
                QY_ZZJGDMZ.ClientTag = "组织机构代码证";
                QY_ZZJGDMZ.NodeCode = Request["RowGuid"];
                QY_ZZJGDMZ.MisRowGuid = Request["RowGuid"];

                QY_FRSFZ.ClientGuid = Request["RowGuid"] + "QY_FRSFZ";
                QY_FRSFZ.ClientTag = "法定代表人身份证";
                QY_FRSFZ.NodeCode = Request["RowGuid"];
                QY_FRSFZ.MisRowGuid = Request["RowGuid"];


                QY_FRQM.ClientGuid = Request["RowGuid"] + "QY_FRQM";
                QY_FRQM.ClientTag = "法定代表人签名";
                QY_FRQM.NodeCode = Request["RowGuid"];
                QY_FRQM.MisRowGuid = Request["RowGuid"];


                QY_SBZM.ClientGuid = Request["RowGuid"] + "QY_SBZM";
                QY_SBZM.ClientTag = "社会保险证明材料(近6个月)";
                QY_SBZM.NodeCode = Request["RowGuid"];
                QY_SBZM.MisRowGuid = Request["RowGuid"];

                QY_QYQT.ClientGuid = Request["RowGuid"] + "QY_QYQT";
                QY_QYQT.ClientTag = "企业其它文件";
                QY_QYQT.NodeCode = Request["RowGuid"];
                QY_QYQT.MisRowGuid = Request["RowGuid"];

                //if (Status_2017.Text == "90")
                //{
                //    btSubmit.Visible = false;
                //}
                RefreshZZGrid();
                RefreshRYGrid();
            }
            InitCityTree();
        }


        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            oZZListPage = new Epoint.MisBizLogic2.Web.ListPage(TableZZID, DGZZ, null, PagerZZ, null);//如果没有导出Excel的Grid，就设置为null
            oZZListPage.OtherCondition = "  and DelStatus='0' and DWGuid='" + Request["RowGuid"] + "' ";
            oZZListPage.SortExpression = " ORDER BY ROW_ID DESC ";
            oZZListPage.CustomMode = true;

            oRYListPage = new Epoint.MisBizLogic2.Web.ListPage(TableRYID, DGRY, null, PagerRY, null);//如果没有导出Excel的Grid，就设置为null
            oRYListPage.OtherCondition = " and DelStatus='0' and DWGuid='" + Request["RowGuid"] + "' ";
            oZZListPage.SortExpression = " ORDER BY ROW_ID DESC ";
            oRYListPage.CustomMode = true;
            base.OnInit(e);
        }

        private void RefreshZZGrid()
        {
            oZZListPage.GenerateSearchResult();
        }
        private void RefreshRYGrid()
        {
            oRYListPage.GenerateSearchResult();
        }
        protected void PagerZZ_PageChanged(object src, Wuqi.Webdiyer.PageChangedEventArgs e)
        {
            PagerZZ.CurrentPageIndex = e.NewPageIndex;
            this.RefreshZZGrid();
        }
        protected void DGZZ_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            oZZListPage.GenerateSerialNumColumn(e.Item);
        }

        protected void PagerRY_PageChanged(object src, Wuqi.Webdiyer.PageChangedEventArgs e)
        {
            PagerRY.CurrentPageIndex = e.NewPageIndex;
            this.RefreshRYGrid();
        }
        protected void DGRY_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            oRYListPage.GenerateSerialNumColumn(e.Item);
        }

        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            RegistAddress_2017.Text = RegionTreeView.Text;
            RegistAddressCode_2017.Text = RegionTreeView.Value;
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);

            if (ApplicationOperate.GetConfigValueByName("IsHoldCurPage", "0") == "1")
                this.WriteAjaxMessage("refreshParentHoldCurPage();");
            else
                this.WriteAjaxMessage("refreshParent();");
            this.WriteAjaxMessage("EP_ShowMessageDiv(" + tdContainer.ClientID + ",'数据保存成功')");
        }

        HTProject_Bizlogic.SMS HTSMS = new SMS();
        protected void btSubmit_Click(object sender, System.EventArgs e)
        {
            //先将原来的删除，防止重复
            DB_MC.DeleteWH("审核企业", Request["RowGuid"]);
            RegistAddress_2017.Text = RegionTreeView.Text;
            RegistAddressCode_2017.Text = RegionTreeView.Value;
            TJRGuid_2017.Text = this.UserGuid;
            //Status_2017.Text = "70";
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow(oEditPage.TableDetail.SQL_TableName, Request["RowGuid"]);
            oRow["Status"] = "70";
            oRow["UpdateUserName"] = this.DisplayName;
            oRow["UpdateUserGuid"] = this.UserGuid;
            oRow["UpdateTime"] = DateTime.Now.ToString();
            oRow.Update();
            //将人员、资质中处于编辑状态和审核退回状态的，都修改为待审核状态
            string strSql = "";
            //资质
            strSql = "SELECT * FROM RG_QiYeZiZhi WHERE Status IN ('60','80','85') AND DWGuid='" + Request["RowGuid"] + "'";
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            for (int m = 0; m < dv.Count; m++)
            {
                strSql = "UPDATE RG_QiYeZiZhi SET Status='70' WHERE ROWGUID='" + dv[m]["RowGuid"] + "' ";
                Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);
                //将该单位其他资质的审核待办删除
                DB_MC.DeleteWH("审核企业资质", dv[m]["RowGuid"].ToString());
            }
            //人员
            strSql = "SELECT * FROM RG_QYUser WHERE Status IN ('60','80','85') AND DWGuid='" + Request["RowGuid"] + "'";
            dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            for (int m = 0; m < dv.Count; m++)
            {
                strSql = "UPDATE RG_QYUser SET Status='70' WHERE ROWGUID='" + dv[m]["RowGuid"] + "' ";
                Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);
                //将该单位其他资质的审核待办删除
                DB_MC.DeleteWH("人员信息审核", dv[m]["RowGuid"].ToString());
            }
            //strSql = "UPDATE RG_QYUser SET Status='70' WHERE Status IN ('60','80','85') AND DWGuid='" + Request["RowGuid"] + "'";
            //Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);
            //发送待审核事宜，根据角色来
            dv = DBF.GetUserByRoleName("企业信息审核");

            for (int m = 0; m < dv.Count; m++)
            {
                string messageGuid = Guid.NewGuid().ToString();
                new HTProject_Bizlogic.DB_Messages_Center().WaitHandle_Insert(messageGuid,
                                    EnterpriseName_2017.Text + "信息审核",
                                    "",
                                    dv[m]["UserGuid"].ToString(),
                                    dv[m]["DisplayName"].ToString(),
                                    "",
                                    "",
                                    "",
                                    @"HTProject/Pages/RG_OU/RG_OU_All_Detail.aspx?type=shenhe&RowGuid=" + Request["RowGuid"],
                                    "",
                                    "",
                                    1,
                                    "",
                                    "",
                                    ""
                             );
                //更新标志位
                strSql = "update messages_center set PType='审核企业',PGuid='"+ Request["RowGuid"] +"' where MessageItemGuid='" + messageGuid + "'";
                Epoint.MisBizLogic2.DB.ExecuteNonQuery(strSql);
                //添加短信
                string IsSendADSMS = ApplicationOperate.GetConfigValueByName("IsSendADSMS");
                if (IsSendADSMS == "1")
                {
                    if (dv[m]["Mobile"].ToString() != "")
                    {
                        HTSMS.SendSMS(this.DisplayName, dv[m]["DisplayName"], EnterpriseName_2017.Text + "提交企业信息审核", dv[m]["Mobile"]);
                    }
                }
                
            }
            AlertAjaxMessage("提交成功");
            this.WriteAjaxMessage("refreshParent();window.close();");
        }


        #region "有关处理注册地区的相关方法"
        /// <summary>
        /// 初始化注册地区树结构
        /// </summary>
        private void InitCityTree()
        {
            RegionTreeView.Nodes.Clear();
            EpointTreeNode node = new EpointTreeNode();
            DataView dv = DataBaseFunc.Instace.GetCity();
            DataView dvCopy = dv.Table.Copy().DefaultView;
            dv.RowFilter = "substring(CityCode,3,4)='0000'";
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode(dv[i]["CityName"].ToString(), dv[i]["CityCode"].ToString());
                dvCopy.RowFilter = "substring(CityCode,1,2)='" + CommonFunc.Left(dv[i]["CityCode"].ToString(), 2) + "'";
                if (dvCopy.Count > 1)
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
                    node.ShowImage = false;
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
            string strLeft = "";
            DataView dv;
            int i = 0;
            if (CommonFunc.Right(nodeArg.Value, 4) == "0000")    //第一级加载第二级
            {
                strLeft = CommonFunc.Left(nodeArg.Value, 2);
                dv = DataBaseFunc.Instace.GetCityLevelTwo(strLeft, nodeArg.Value);
                for (i = 0; i < dv.Count; i++)
                {
                    nodeVar = new EpointTreeNode(dv[i]["CityName"].ToString(), dv[i]["CityCode"].ToString());   //实例化一个节点
                    nodeVar.ExpandOnCheckedChanged = true;
                    nodeVar.Checked = false;
                    nodeVar.ShowInputCtrl = false;
                    nodeVar.RunClickEvtOnInit = true;
                    nodeVar.PopulateOnDemand = true;
                    nodeVar.ReturnFullPath = true;
                    nodeVar.ShowImage = true;
                    nodeVar.SelectLeafForTextTreeView = false;
                    nodeArg.ChildNodes.Add(nodeVar);
                }
            }
            if (CommonFunc.Right(nodeArg.Value, 2) == "00")  //第二级加载第三级
            {
                strLeft = CommonFunc.Left(nodeArg.Value, 4);
                dv = DataBaseFunc.Instace.GetCityLevelThree(strLeft);
                for (i = 0; i < dv.Count; i++)
                {
                    nodeVar = new EpointTreeNode(dv[i]["CityName"].ToString(), dv[i]["CityCode"].ToString());   //实例化一个节点
                    nodeVar.ExpandOnCheckedChanged = true;
                    nodeVar.ShowInputCtrl = true;
                    if (nodeVar.Value == RegionTreeView.Value)
                    {
                        nodeVar.Checked = true;
                    }
                    else
                    {
                        nodeVar.Checked = false;
                    }
                    nodeVar.RunClickEvtOnInit = true;
                    nodeVar.PopulateOnDemand = false;
                    nodeVar.ReturnFullPath = true;
                    nodeVar.ShowImage = false;
                    nodeArg.ChildNodes.Add(nodeVar);
                }
            }
        }
        #endregion

    }
}
