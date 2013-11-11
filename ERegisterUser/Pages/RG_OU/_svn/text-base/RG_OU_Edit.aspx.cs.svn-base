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
using Epoint.RegisterUser.DataSyn.Bizlogic;
using System.Collections.Generic;
using EpointRegisterUser_Bizlogic;
using Epoint.Web.UI.WebControls2X.TreeViewControls;

namespace EpointRegisterUser.Pages.RG_OU
{
    public partial class RG_OU_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 2017;
        Epoint.MisBizLogic2.Web.EditPage oEditPage;
        public int GGTableID = 2023;
        Epoint.MisBizLogic2.Web.ListPage oListPage2;
        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string RowGuid = Request["RowGuid"];
                string DWGuid = Request["DWGuid"];
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

                tvZCD.Text = ZhuCeDi_2017.Text;
                tvZCD.Value = ZhuCeDiCode_2017.Text;
                tvYYD1.Text = YunYingDi1_2017.Text;
                tvYYD1.Value = YunYingDi1Code_2017.Text;
                tvYYD2.Text = YunYingDi2_2017.Text;
                tvYYD2.Value = YunYingDi2Code_2017.Text;
                tvYYD3.Text = YunYingDi3_2017.Text;
                tvYYD3.Value = YunYingDi3Code_2017.Text;

                #region 附件
                CL_SB.MisRowGuid = DWGuid;
                CL_SB.MisTableID = TableID;
                CL_SB.ProjectGuid = "";
                CL_SB.Comment = DWGuid;
                CL_SB.d_TiJiaoSJ = DateTime.Now.ToString();
                //CL_SB.s

                CL_Logo.MisRowGuid = DWGuid;
                CL_Logo.MisTableID = TableID;
                CL_Logo.ProjectGuid = "";
                CL_Logo.Comment = DWGuid;
                CL_Logo.d_TiJiaoSJ = DateTime.Now.ToString();

                CL_GSJS.MisRowGuid = DWGuid;
                CL_GSJS.MisTableID = TableID;
                CL_GSJS.ProjectGuid = "";
                CL_GSJS.Comment = DWGuid;
                CL_GSJS.d_TiJiaoSJ = DateTime.Now.ToString();

                CL_ZS.MisRowGuid = DWGuid;
                CL_ZS.MisTableID = TableID;
                CL_ZS.ProjectGuid = "";
                CL_ZS.Comment = DWGuid;
                CL_ZS.d_TiJiaoSJ = DateTime.Now.ToString();
                #endregion

                InitZCDTree();
                InitYYD1Tree();
                InitYYD2Tree();
                InitYYD3Tree();

                RefreshGrid2();
            }
        }

        #region "有关处理注册地区的相关方法"
        /// <summary>
        /// 初始化注册地区树结构
        /// </summary>
        private void InitZCDTree()
        {
            tvZCD.Nodes.Clear();
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
                tvZCD.Nodes.Add(node);
            }
        }

        private void InitYYD1Tree()
        {
            tvYYD1.Nodes.Clear();
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
                tvYYD1.Nodes.Add(node);
            }
        }

        private void InitYYD2Tree()
        {
            tvYYD2.Nodes.Clear();
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
                tvYYD2.Nodes.Add(node);
            }
        }

        private void InitYYD3Tree()
        {
            tvYYD3.Nodes.Clear();
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
                tvYYD3.Nodes.Add(node);
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
            TextTreeView ttv = (TextTreeView)sender;
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
                    if (nodeVar.Value == ttv.Value)
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

        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            oListPage2 = new Epoint.MisBizLogic2.Web.ListPage(GGTableID, Datagrid2, null, Pager2, null);//如果没有导出Excel的Grid，就设置为null
            oListPage2.CustomMode = true;
            base.OnInit(e);
        }

        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            string RowGuid = Request["RowGuid"];
            string DWGuid = Request["DWGuid"];
            UpdateUserName_2017.Text = this.DisplayName;
            UpdateUserGuid_2017.Text = this.UserGuid;
            IsHistory_2017.Text = "0";
            UpdateTime_2017.Text = DateTime.Now.ToString();
            Status_2017.Text = OUStatus.通过; //"2";//0:编辑   1：待审核   2：通过
            DelFlag_2017.Text = "0";
            //DWGuid_2017.Text = DWGuid;
            #region 地区的保存
            ZhuCeDi_2017.Text = tvZCD.Text;
            ZhuCeDiCode_2017.Text = tvZCD.Value;
            YunYingDi1_2017.Text = tvYYD1.Text;
            YunYingDi1Code_2017.Text = tvYYD1.Value;
            YunYingDi2_2017.Text = tvYYD2.Text;
            YunYingDi2Code_2017.Text = tvYYD2.Value;
            YunYingDi3_2017.Text = tvYYD3.Text;
            YunYingDi3Code_2017.Text = tvYYD3.Value;
            #endregion

            oEditPage.SaveTableValues(RowGuid, tdContainer);

            #region 保存附件
            CL_SB.MisRowGuid = DWGuid;
            CL_SB.MisTableID = TableID;
            CL_SB.ProjectGuid = "";
            CL_SB.Comment = DWGuid;
            CL_SB.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_SB.Save();

            CL_Logo.MisRowGuid = DWGuid;
            CL_Logo.MisTableID = TableID;
            CL_Logo.ProjectGuid = "";
            CL_Logo.Comment = DWGuid;
            CL_Logo.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_Logo.Save();

            CL_GSJS.MisRowGuid = DWGuid;
            CL_GSJS.MisTableID = TableID;
            CL_GSJS.ProjectGuid = "";
            CL_GSJS.Comment = DWGuid;
            CL_GSJS.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_GSJS.Save();

            CL_ZS.MisRowGuid = DWGuid;
            CL_ZS.MisTableID = TableID;
            CL_ZS.ProjectGuid = "";
            CL_ZS.Comment = DWGuid;
            CL_ZS.d_TiJiaoSJ = DateTime.Now.ToString();
            CL_ZS.Save();
            #endregion

            this.WriteAjaxMessage("refreshParent();alert('保存成功');");
        }

        #region 高管信息
        private void RefreshGrid2()
        {
            oListPage2.OtherCondition = " and DWGuid='" + Request["DWGuid"] + "' ";//and PGuid='" + Request["RowGuid"] + "' ";
            oListPage2.GenerateSearchResult();
        }


        protected void btnDel_Click(object sender, System.EventArgs e)
        {
            CheckBox chk;
            for (int i = 0; i < Datagrid2.Items.Count; i++)
            {
                chk = (CheckBox)Datagrid2.Items[i].FindControl("chkAdd");
                if (chk.Checked)
                {
                    Epoint.MisBizLogic2.Data.CommonDataTable.DeleteRecord_FromSqlTable(
                       oListPage2.TableID,
                       oListPage2.TableDetail.SQL_TableName,
                       Convert.ToString(Datagrid2.DataKeys[i])
                       );
                }
            }
            this.RefreshGrid2();
        }



        protected void Datagrid2_SortCommand(object source, DataGridSortCommandEventArgs e)
        {
            oListPage2.PrepareForSortCommand(e.SortExpression);
            this.RefreshGrid2();
        }

        protected void Datagrid2_ItemCreated(object sender, DataGridItemEventArgs e)
        {
            oListPage2.GenerateSerialNumColumn(e.Item);
        }
        #endregion
    }
}
