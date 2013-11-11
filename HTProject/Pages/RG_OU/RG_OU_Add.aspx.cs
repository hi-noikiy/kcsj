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

    public partial class RG_OU_Add : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {

        public int TableID = 2017;
        private DB_RG_DW dbDW = new DB_RG_DW();
        private DB_RG_User dbUSER = new DB_RG_User();
        Epoint.MisBizLogic2.Web.AddPage oAddPage;
        protected void Page_Load(object sender, System.EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                ViewState["TableName"] = oAddPage.TableDetail.TableName;
                #region �ж��Ƿ��Ǹ�������Ǹ�������û�и����RowID���Զ�ת����Ӧ������
                string ParentRowGuid = Request.QueryString["ParentRowGuid"];
                if (oAddPage.TableDetail.TableType == 2)
                {
                    if (ParentRowGuid == null || ParentRowGuid == "")
                    {
                        this.AlertAjaxMessage("��ֱֹ�Ӷ��ӱ���Ӽ�¼��");
                        return;
                    }
                }
                #endregion
                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_AddPage(oAddPage, tdContainer);
                //����ϴ��ļ��Ĵ�С�����ͼ��
                this.Add_FileUploadCheck_Script();

                InitCityTree();
            }
        }


        override protected void OnInit(EventArgs e)
        {
            oAddPage = new Epoint.MisBizLogic2.Web.AddPage(TableID);
            base.OnInit(e);
        }


        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            //��֤��λ�Ƿ��Ѵ���
            DataView dvDW = dbDW.CheckCodeForRowGuid("ZuZhiJGDM", ZuZhiJGDM_2017.Text.Trim());
            if (dvDW.Count > 0)
            {
                this.AlertAjaxMessage("�Ѵ�����ͬ��֯��������ĵ�λ��" + dvDW[0]["EnterpriseName"].ToString());
                return;
            }
            dvDW = dbDW.CheckCodeForRowGuid("YingYeZZ", YingYeZZ_2017.Text.Trim());
            if (dvDW.Count > 0)
            {
                this.AlertAjaxMessage("�Ѵ�����ͬӪҵִ�պ���ĵ�λ��" + dvDW[0]["EnterpriseName"].ToString());
                return;
            }
            string RowGuid = Guid.NewGuid().ToString();
            Status_2017.Text = "60";
            SMJZSJ_2017.Text = DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00";
            if (oAddPage.SaveTableValues_CheckExist(RowGuid, tdContainer, Request.QueryString["ParentRowGuid"]))
            {
                //������ҵ���û�
                if (!dbUSER.CheckUserExist(ZuZhiJGDM_2017.Text.Trim()))
                {
                    InsertUser(ZuZhiJGDM_2017.Text.Trim(), RowGuid, LianXiRen_2017.Text.Trim());
                }
                this.WriteAjaxMessage("refreshParent();");
                this.AlertAjaxMessage("���ݱ���ɹ�����ҵ�û������ɹ�����¼���������Ϊ��֯�ṹ����֤��");
                this.WriteAjaxMessage("window.close();");
                //������״̬Ϊ�༭�� 
                Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("rg_ouinfo", RowGuid);
                oRow["Status"] = "60";
                oRow["DelStatus"] = "0";
                oRow["IsNDBA"] = "0";
                oRow.Update();
            }
        }

        protected void InsertUser(string LoginID, string DanWeiGuid,string LXR)
        {
            string strSql = "select ZuZhiJGDM from RG_OUInfo where RowGuid='" + DanWeiGuid + "'";
            //ZuZhiJGDM_2020.Text = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            Epoint.MisBizLogic2.Data.MisGuidRow oRow = new Epoint.MisBizLogic2.Data.MisGuidRow("RG_User");
            oRow["OperateDate"] = DateTime.Now.ToString();//System.DateTime
            oRow["RowGuid"] = Guid.NewGuid().ToString();//System.String
            oRow["DispName"] = LXR;//System.String
            oRow["LoginID"] = LoginID;//System.String
            oRow["Password"] = common.authPassword(LoginID);//System.String
            oRow["EnableSMS"] = "0";//System.String
            oRow["IsValid"] = "1";//System.String
            oRow["DanWeiGuid"] = DanWeiGuid;
            oRow["UserStatus"] = "002";//System.Stringg
            oRow["DelFlag"] = "0";//System.Int32
            oRow["ZuZhiJGDM"] = Epoint.MisBizLogic2.DB.ExecuteToString(strSql);
            oRow.Insert();
        }


        #region "�йش���ע���������ط���"
        /// <summary>
        /// ��ʼ��ע��������ṹ
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
        /// ע��������νṹչ��
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
            if (CommonFunc.Right(nodeArg.Value, 4) == "0000")    //��һ�����صڶ���
            {
                strLeft = CommonFunc.Left(nodeArg.Value, 2);
                dv = DataBaseFunc.Instace.GetCityLevelTwo(strLeft, nodeArg.Value);
                for (i = 0; i < dv.Count; i++)
                {
                    nodeVar = new EpointTreeNode(dv[i]["CityName"].ToString(), dv[i]["CityCode"].ToString());   //ʵ����һ���ڵ�
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
            if (CommonFunc.Right(nodeArg.Value, 2) == "00")  //�ڶ������ص�����
            {
                strLeft = CommonFunc.Left(nodeArg.Value, 4);
                dv = DataBaseFunc.Instace.GetCityLevelThree(strLeft);
                for (i = 0; i < dv.Count; i++)
                {
                    nodeVar = new EpointTreeNode(dv[i]["CityName"].ToString(), dv[i]["CityCode"].ToString());   //ʵ����һ���ڵ�
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


