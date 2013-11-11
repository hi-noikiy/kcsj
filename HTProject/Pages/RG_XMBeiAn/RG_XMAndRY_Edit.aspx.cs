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

namespace HTProject.Pages.RG_XMBeiAn
{

    public partial class RG_XMAndRY_Edit : Epoint.Frame.Bizlogic.BaseContentPage_UsingMaster
    {
        public int TableID = 2024;
        Epoint.MisBizLogic2.Web.EditPage oEditPage;
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
                    this.AlertAjaxMessage("û�ж�Ӧ�����ݼ�¼��");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }



                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
                //����ϴ��ļ��Ĵ�С�����ͼ��
                this.Add_FileUploadCheck_Script();
                //���ݹ�ģ��רҵ����һЩ����ʹ�õĽ�ɫȥ��
                //�ȸ���ְ�ƣ�ֻ���м������ϣ����ܴ�����Ŀ��רҵ������
                #region
                if (ZhiCheng_2024.SelectedValue == "1" || ZhiCheng_2024.SelectedValue == "7")
                {
                    DDRole_2024.Items.Remove(new ListItem("רҵ������", "90"));
                    DDRole_2024.Items.Remove(new ListItem("��Ŀ/רҵ������", "94"));
                    DDRole_2024.Items.Remove(new ListItem("��Ŀ������", "95"));
                }
                //string ZYCode = Request["ZYCode"].Substring(0,4);
                //int GM = int.Parse(Request["GMValue"]);
                //if (ZYCode == "0002" )//�����ģ��������ϣ�������һ��ע�ᣬС�ͱ����Ƕ���
                //{
                //    if (GM >= 80)
                //    { }
                //}
                #endregion
                //ddlZY.Items.Add(new ListItem("��ѡ��", ""));
                BindZY(ZhuanYeCSCode_2024.Text);
                ddlZY.SelectedValue = ZhuanYeCS_2024.Text;
            }
        }


        override protected void OnInit(EventArgs e)
        {
            oEditPage = new Epoint.MisBizLogic2.Web.EditPage(TableID);
            base.OnInit(e);
        }


        protected void btnEdit_Click(object sender, System.EventArgs e)
        {
            string ZYCode = Request["ZYCode"].Substring(0, 4);
            string ZYZCCode = Request["ZYCode"];
            int GM = int.Parse(Request["GMValue"]);
            DateTime dtBirth = DateTime.Now;
            string strSql = " select csrq from RG_QYUser where RowGuid='" + RYGuid_2024.Text + "' ";
            dtBirth = DateTime.Parse(Epoint.MisBizLogic2.DB.ExecuteToString(strSql));
            string ZiZhiDJCode = Request["ZiZhiDJCode"];
            string ZiZhiDJCode2 = ZiZhiDJCode.Substring(0, 4);
            DateTime dtNow = DateTime.Now;
            DateTime dtPass = new DateTime(2014,7,1);
            //���ж���������Ŀ�����ˡ�רҵ�������ڱ���Ŀ����רҵ��ҪΨһ
            if (DDRole_2024.SelectedValue == "95")//��Ŀ������
            {
                if (RG_DW.IsHaveRolsInXM(XMGuid_2024.Text, DDRole_2024.SelectedValue,RYGuid_2024.Text))
                {
                    //��ʾ�Ѿ�����
                    AlertAjaxMessage("����Ŀ������Ŀ������");
                    return;
                }
                if (RG_DW.IsHaveRolsInXM(XMGuid_2024.Text, "94", RYGuid_2024.Text))
                {
                    //��ʾ�Ѿ�����
                    AlertAjaxMessage("��רҵ��������Ŀ/רҵ������");
                    return;
                }
                //��Ҫ�����м�����ְ��
                if (ZhiCheng_2024.SelectedValue == "1" || ZhiCheng_2024.SelectedValue == "7")
                {
                    AlertAjaxMessage("��Ŀ������Ӧ�������м�ְ��");
                    return;
                }
                //����10�����ϣ�ʡ����ҵҪ��ȫ����ʡ�ڵ�Ҫ��2014��7��1�տ�ʼ
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    if (Request["QYZCD"] == "32")
                    {
                        if (dtNow > dtPass)
                        {
                            AlertAjaxMessage("��Ŀ������Ӧ������10�깤��");
                            return;
                        }
                    }
                    else
                    {
                        AlertAjaxMessage("��Ŀ������Ӧ������10�깤��");
                        return;
                    }
                }
                //������60������
                if(dtBirth.AddYears(60)<DateTime.Now)
                {
                    AlertAjaxMessage("��Ŀ���������䲻�ܳ���60��");
                    return;
                }
                //��������Ŀ����Ŀ �����˾�������ע������ʦ
                #region
                string ZiZhiDJ = Request["ZiZhiDJCode"].Substring(0, 8);
                if (ZiZhiDJ == "00040002" || ZiZhiDJ == "00040003" || ZiZhiDJ == "00040004" || ZiZhiDJ == "00040005" || ZiZhiDJ == "00040006")
                {
                    //���ǲ�������ע�ᣬ������ǣ�Ҫ����
                    if (ZYZCCode != "00670001")
                    {
                        AlertAjaxMessage("������Ŀ����Ŀ������Ӧ��ע����Ա");
                        return;
                    }
                }
                #endregion
                //���ר��
                if (ZiZhiDJCode2 == "0003")
                {
                    CheckZhuangXiang();
                }
                #region
                #endregion

            }
            else if (DDRole_2024.SelectedValue == "90")//רҵ������
            {
                if (RG_DW.IsHaveRolsInXM(XMGuid_2024.Text, ZhuanYeCode_2024.Text, DDRole_2024.SelectedValue))
                {
                    //��ʾ�Ѿ�����
                    AlertAjaxMessage("��רҵ������רҵ������");
                    return;
                }
                if (RG_DW.IsHaveRolsInXM(XMGuid_2024.Text, ZhuanYeCode_2024.Text,"94"))
                {
                    //��ʾ�Ѿ�����
                    AlertAjaxMessage("��רҵ��������Ŀ/רҵ������");
                    return;
                }
                //��Ҫ�����м�����ְ��
                if (ZhiCheng_2024.SelectedValue == "1" || ZhiCheng_2024.SelectedValue == "7")
                {
                    AlertAjaxMessage("רҵ������Ӧ�������м�ְ��");
                    return;
                }
                //����10������
                
                //����10�����ϣ�ʡ����ҵҪ��ȫ����ʡ�ڵ�Ҫ��2014��7��1�տ�ʼ
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    if (Request["QYZCD"] == "32")
                    {
                        if (dtNow > dtPass)
                        {
                            AlertAjaxMessage("רҵ������Ӧ������10�깤��");
                            return;
                        }
                    }
                    else
                    {
                        AlertAjaxMessage("רҵ������Ӧ������10�깤��");
                        return;
                    }
                }
                //������60������
                if(dtBirth.AddYears(60)<DateTime.Now)
                {
                    AlertAjaxMessage("רҵ���������䲻�ܳ���60��");
                    return;
                }
                //����ǽ������ṹ�ģ�רҵ������Ҫ���д��͵���ע��һ����С�͵���ע�����
                #region
                if (ZYCode == "0002")//�����ģ��������ϣ�������һ��ע�ᣬС�ͱ����Ƕ���
                {
                    if (GM >= 80)//�д���
                    {
                        if (ZYZCCode != "00020001")//����һ��ע��
                        {
                            AlertAjaxMessage("��������Ŀ�Ľ���רҵרҵ������Ӧ������һ��ע��");
                            return;
                        }
                    }
                    else
                    {
                        if (ZYZCCode != "00020002")//���Ƕ���ע��
                        {
                            if (ZYZCCode == "00020001")
                            { }
                            else
                            {
                                AlertAjaxMessage("С����Ŀ�Ľ���רҵרҵ������Ӧ�����Ƕ���ע��");
                                return;
                            }
                        }
                    }
                }
                if (ZYCode == "0003")//�ṹ�ģ��������ϣ�������һ��ע�ᣬС�ͱ����Ƕ���
                {
                    if (GM >= 80)//�д���
                    {
                        if (ZYZCCode != "00030001")//����һ��ע��
                        {
                            AlertAjaxMessage("��������Ŀ�Ľṹרҵרҵ������Ӧ������һ��ע��");
                            return;
                        }
                    }
                    else
                    {
                        if (ZYZCCode != "00030002")//���Ƕ���ע��
                        {
                            if (ZYZCCode == "00030001")
                            { }
                            else
                            {
                                AlertAjaxMessage("С����Ŀ�Ľṹרҵרҵ������Ӧ�����Ƕ���ע��");
                                return;
                            }
                        }
                    }
                }
                #endregion

                //���ר��
                if (ZiZhiDJCode2 == "0003")
                {
                    CheckZhuangXiang();
                }
            }
            else if (DDRole_2024.SelectedValue == "94")//��Ŀ/רҵ������
            {
                if (RG_DW.IsHaveRolsInXM(XMGuid_2024.Text, ZhuanYeCode_2024.Text, DDRole_2024.SelectedValue))
                {
                    //��ʾ�Ѿ�����
                    AlertAjaxMessage("��רҵ��������Ŀ/רҵ������");
                    return;
                }
                if (RG_DW.IsHaveRolsInXM(XMGuid_2024.Text, "95", RYGuid_2024.Text))
                {
                    //��ʾ�Ѿ�����
                    AlertAjaxMessage("����Ŀ������Ŀ������");
                    return;
                }
                if (RG_DW.IsHaveRolsInXM(XMGuid_2024.Text, ZhuanYeCode_2024.Text, "90"))
                {
                    //��ʾ�Ѿ�����
                    AlertAjaxMessage("��רҵ������רҵ������");
                    return;
                }
                //��Ҫ�����м�����ְ��
                if (ZhiCheng_2024.SelectedValue == "1" || ZhiCheng_2024.SelectedValue == "7")
                {
                    AlertAjaxMessage("��Ŀ/רҵ������Ӧ�������м�ְ��");
                    return;
                }
                //����10�����ϣ�ʡ����ҵҪ��ȫ����ʡ�ڵ�Ҫ��2014��7��1�տ�ʼ
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    if (Request["QYZCD"] == "32")
                    {
                        if (dtNow > dtPass)
                        {
                            AlertAjaxMessage("��Ŀ/רҵ������Ӧ������10�깤��");
                            return;
                        }
                    }
                    else
                    {
                        AlertAjaxMessage("��Ŀ/רҵ������Ӧ������10�깤��");
                        return;
                    }
                }
                //������60������
                if(dtBirth.AddYears(60)<DateTime.Now)
                {
                    AlertAjaxMessage("��Ŀ/רҵ���������䲻�ܳ���60��");
                    return;
                }
                //����ǽ������ṹ�ģ�רҵ������Ҫ���д��͵���ע��һ����С�͵���ע�����
                #region
                if (ZYCode == "0002")//�����ģ��������ϣ�������һ��ע�ᣬС�ͱ����Ƕ���
                {
                    if (GM >= 80)//�д���
                    {
                        if (ZYZCCode != "00020001")//����һ��ע��
                        {
                            AlertAjaxMessage("��������Ŀ�Ľ���רҵרҵ������Ӧ������һ��ע��");
                            return;
                        }
                    }
                    else
                    {
                        if (ZYZCCode != "00020002")//���Ƕ���ע��
                        {
                            if (ZYZCCode == "00020001")
                            { }
                            else
                            {
                                AlertAjaxMessage("С����Ŀ�Ľ���רҵרҵ������Ӧ�����Ƕ���ע��");
                                return;
                            }
                        }
                    }
                }
                if (ZYCode == "0003")//�ṹ�ģ��������ϣ�������һ��ע�ᣬС�ͱ����Ƕ���
                {
                    if (GM >= 80)//�д���
                    {
                        if (ZYZCCode != "00030001")//����һ��ע��
                        {
                            AlertAjaxMessage("��������Ŀ�Ľṹרҵרҵ������Ӧ������һ��ע��");
                            return;
                        }
                    }
                    else
                    {
                        if (ZYZCCode != "00030002")//���Ƕ���ע��
                        {
                            if (ZYZCCode == "00030001")
                            { }
                            else
                            {
                                AlertAjaxMessage("С����Ŀ�Ľṹרҵרҵ������Ӧ�����Ƕ���ע��");
                                return;
                            }
                        }
                    }
                }
                #endregion

                //��������Ŀ����Ŀ �����˾�������ע������ʦ
                #region
                string ZiZhiDJ = Request["ZiZhiDJCode"].Substring(0, 8);
                if (ZiZhiDJ == "00040002" || ZiZhiDJ == "00040003" || ZiZhiDJ == "00040004" || ZiZhiDJ == "00040005" || ZiZhiDJ == "00040006")
                {
                    //���ǲ�������ע�ᣬ������ǣ�Ҫ����
                    if (ZYZCCode != "00670001")
                    {
                        AlertAjaxMessage("������Ŀ����Ŀ������Ӧ��ע����Ա");
                        return;
                    }
                }
                #endregion

                //���ר��
                if (ZiZhiDJCode2 == "0003")
                {
                    CheckZhuangXiang();
                }
            }
            else//�����Ա
            { }
            ZhuanYeCS_2024.Text = ddlZY.SelectedValue;
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);

            this.WriteAjaxMessage("rtnValue('');");
        }

        //���ר���Ҫ����֤,ר���Ϊ0003
        protected void CheckZhuangXiang()
        {
            string ZiZhiDJCode = Request["ZiZhiDJCode"];
            string ZiZhiDJCode2 = ZiZhiDJCode.Substring(0, 8);
            #region 6-1����װ�ι���
            if (ZiZhiDJCode == "000300010001")//����װ�ι��̼׼���8��
            {
                if (int.Parse(GongLing_2024.Text) < 8)
                {
                    AlertAjaxMessage("Ӧ������8�깤��");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300010002")//����װ�ι����Ҽ���6��
            {
                if (int.Parse(GongLing_2024.Text) < 6)
                {
                    AlertAjaxMessage("Ӧ������6�깤��");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300010003")//����װ�ι��̱�����3��
            {
                if (int.Parse(GongLing_2024.Text) < 3)
                {
                    AlertAjaxMessage("Ӧ������3�깤��");
                    return;
                }
            }
            #endregion
            #region 6-2�������ܻ�
            else if (ZiZhiDJCode == "000300020001")//�������ܻ�ϵͳ��Ƽ׼���8��
            {
                if (int.Parse(GongLing_2024.Text) < 8)
                {
                    AlertAjaxMessage("Ӧ������8�깤��");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300020002")//�������ܻ�ϵͳ����Ҽ���5��
            {
                if (int.Parse(GongLing_2024.Text) < 5)
                {
                    AlertAjaxMessage("Ӧ������5�깤��");
                    return;
                }
            }
            //else if (ZiZhiDJCode == "000300010003")//����װ�ι��̱�����3��
            //{
            //    if (int.Parse(GongLing_2024.Text) < 3)
            //    {
            //        AlertAjaxMessage("Ӧ������3�깤��");
            //        return;
            //    }
            //}
            #endregion
            #region 6-3����Ļǽ
            else if (ZiZhiDJCode == "000300030001")//����Ļǽ���̼׼���10��
            {
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    AlertAjaxMessage("Ӧ������10�깤��");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300030002")//����Ļǽ���̼׼���8��
            {
                if (int.Parse(GongLing_2024.Text) < 8)
                {
                    AlertAjaxMessage("Ӧ������8�깤��");
                    return;
                }
            }
            //else if (ZiZhiDJCode == "000300010003")//����װ�ι��̱�����3��
            //{
            //    if (int.Parse(GongLing_2024.Text) < 3)
            //    {
            //        AlertAjaxMessage("Ӧ������3�깤��");
            //        return;
            //    }
            //}
            #endregion
            #region 6-4���ͷ��ݸֽṹ
            else if (ZiZhiDJCode == "000300040001")//���ͷ��ݸֽṹ���̼׼���10��
            {
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    AlertAjaxMessage("Ӧ������10�깤��");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300040002")//���ͷ��ݸֽṹ�����Ҽ���8��
            {
                if (int.Parse(GongLing_2024.Text) < 8)
                {
                    AlertAjaxMessage("Ӧ������8�깤��");
                    return;
                }
            }
            //else if (ZiZhiDJCode == "000300010003")//����װ�ι��̱�����3��
            //{
            //    if (int.Parse(GongLing_2024.Text) < 3)
            //    {
            //        AlertAjaxMessage("Ӧ������3�깤��");
            //        return;
            //    }
            //}
            #endregion
            #region 6-5�羰԰�ֹ���
            else if (ZiZhiDJCode == "000300050001")//�羰԰�ֹ��̼׼���10��
            {
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    AlertAjaxMessage("Ӧ������10�깤��");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300050002")//�羰԰�ֹ����Ҽ���8��
            {
                if (int.Parse(GongLing_2024.Text) < 8)
                {
                    AlertAjaxMessage("Ӧ������8�깤��");
                    return;
                }
            }
            //else if (ZiZhiDJCode == "000300010003")//����װ�ι��̱�����3��
            //{
            //    if (int.Parse(GongLing_2024.Text) < 3)
            //    {
            //        AlertAjaxMessage("Ӧ������3�깤��");
            //        return;
            //    }
            //}
            #endregion
            #region 6-6������ʩ����
            else if (ZiZhiDJCode == "000300060001")//������ʩ���̼׼���10��
            {
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    AlertAjaxMessage("Ӧ������10�깤��");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300060002")//������ʩ�����Ҽ���8��
            {
                if (int.Parse(GongLing_2024.Text) < 8)
                {
                    AlertAjaxMessage("Ӧ������8�깤��");
                    return;
                }
            }
            //else if (ZiZhiDJCode == "000300010003")//����װ�ι��̱�����3��
            //{
            //    if (int.Parse(GongLing_2024.Text) < 3)
            //    {
            //        AlertAjaxMessage("Ӧ������3�깤��");
            //        return;
            //    }
            //}
            #endregion
            #region 6-7�����������
            else if (ZiZhiDJCode2 == "00030007")//�׼�\�Ҽ���5��
            {
                if (int.Parse(GongLing_2024.Text) < 5)
                {
                    AlertAjaxMessage("Ӧ������5�깤��");
                    return;
                }
            }            
            #endregion
            #region 6-8��������
            else if (ZiZhiDJCode == "000300080001")//�������̼׼���6��
            {
                if (int.Parse(GongLing_2024.Text) < 6)
                {
                    AlertAjaxMessage("Ӧ������6�깤��");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300080002")//���������Ҽ���5��
            {
                if (int.Parse(GongLing_2024.Text) < 5)
                {
                    AlertAjaxMessage("Ӧ������5�깤��");
                    return;
                }
            }
            else
            {
                //����10������
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    AlertAjaxMessage("Ӧ������10�깤��");
                    return;
                }
            }
            #endregion
        }

        //��רҵ
        protected void BindZY(object ZYCode)
        {
            string MainGuid = "29b7967e-8098-42d5-8b40-ec757b0865a5";
            string[] ZY = ZYCode.ToString().Split(';');
            for (int m = 0; m < ZY.Length; m++)
            {
                if (ZY.Length == 4)
                {
                    ddlZY.Items.Add(new ListItem(RG_DW.GetItemText(ZY[m], MainGuid), RG_DW.GetItemText(ZY[m], MainGuid)));
                }
                else if (ZY.Length > 0)
                {
                    ddlZY.Items.Add(new ListItem(RG_DW.GetItemTextByLen(MainGuid, ZY[m], 4), RG_DW.GetItemTextByLen(MainGuid, ZY[m], 4)));
                }
            }
        }

    }
}
