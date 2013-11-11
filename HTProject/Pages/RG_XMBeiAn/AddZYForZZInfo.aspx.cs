using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Epoint.Web.UI.WebControls2X;
using HTProject_Bizlogic;
using System.Text;

namespace HTProject.Pages.RG_XMBeiAn
{
    public partial class AddZYForZZInfo : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        HTProject_Bizlogic.DB_RG_DW RG_DW = new DB_RG_DW();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string strSql = "select ItemText from Frame_Code_Item where MainGuid='" + Request["MainGuid"] + "' and ItemCode='" + Request["ZZCode"] + "'";
                lblZZText.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
                //初始化值
                DataView dv = RG_DW.GetZYbyZZ(Request["ZZCode"]);
                StringBuilder ZYText = new StringBuilder();
                StringBuilder ZYCode = new StringBuilder();
                for (int m = 0; m < dv.Count; m++)
                {
                    ZYText.Append(dv[m]["ZhuanYeText"]);
                    ZYText.Append(";");
                    ZYCode.Append(dv[m]["ZhuanYeCode"]);
                    ZYCode.Append(";");
                }
                RegionTreeView.Text = ZYText.ToString();
                RegionTreeView.Value = ZYCode.ToString();
                InitTree();
            }
        }

        #region "绑定"
        /// <summary>
        /// 初始化
        /// </summary>
        private void InitTree()
        {
            RegionTreeView.Nodes.Clear();
            EpointTreeNode node = new EpointTreeNode();
            //string strSql = "select * from Frame_Code_Item where MainGuid='29b7967e-8098-42d5-8b40-ec757b0865a5' and LEN(ItemCode)=4 order by OrderNumber desc,Row_ID asc";
            DataView dv = DataBaseFunc.Instace.GetTree("29b7967e-8098-42d5-8b40-ec757b0865a5", "");
            DataView dvCopy = dv.Table.Copy().DefaultView;
            //dv.RowFilter = "substring(CityCode,3,4)='0000'";
            for (int i = 0; i < dv.Count; i++)
            {
                node = new EpointTreeNode(dv[i]["ItemText"].ToString(), dv[i]["ItemCode"].ToString());
                //dvCopy.RowFilter = "substring(CityCode,1,2)='" + CommonFunc.Left(dv[i]["CityCode"].ToString(), 2) + "'";
                DataView dv2 = DataBaseFunc.Instace.GetTreeLevelTwo(node.Value, "29b7967e-8098-42d5-8b40-ec757b0865a5", "");
                if (dv2.Count > 0)
                {
                    node.PopulateOnDemand = true;
                    node.ShowInputCtrl = true;
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
                //判断下是否已经被选中
                if (RegionTreeView.Value.IndexOf(node.Value + ";") >= 0)
                {
                    node.Checked = true;
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

            dv = DataBaseFunc.Instace.GetTreeLevelTwo(nodeArg.Value, "29b7967e-8098-42d5-8b40-ec757b0865a5", "");
            for (i = 0; i < dv.Count; i++)
            {
                nodeVar = new EpointTreeNode(dv[i]["ItemText"].ToString(), dv[i]["ItemCode"].ToString());   //实例化一个节点
                //nodeVar.Checked = false;
                nodeVar.ShowInputCtrl = true;
                nodeVar.PopulateOnDemand = false;
                nodeVar.ReturnFullPath = true;
                nodeVar.ShowImage = false;
                //判断下是否已经被选中
                if (RegionTreeView.Value.IndexOf(nodeVar.Value+";") >= 0)
                {
                    nodeVar.Checked = true;
                }
                nodeArg.ChildNodes.Add(nodeVar);
            }
            
        }
        #endregion

        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            if (RegionTreeView.Value != "")
            {
                string[] ZYText = RegionTreeView.Text.Split(';');
                string[] ZYCode = RegionTreeView.Value.Split(';');
                for (int m = 0; m < ZYText.Length; m++)
                {
                    if (ZYText[m] != "")
                    {
                        //判断下是否已经存在了，如果存在了就不要再新增
                        if (!RG_DW.IsExistZZZYGX(Request["ZZCode"], ZYCode[m]))
                        {
                            RG_DW.InsertZZZYGX(lblZZText.Text, Request["ZZCode"], ZYText[m], ZYCode[m], ZYText.Length - m);
                        }
                    }
                }
            }
            this.WriteAjaxMessage("rtnValue('');");
        }
    }
}
