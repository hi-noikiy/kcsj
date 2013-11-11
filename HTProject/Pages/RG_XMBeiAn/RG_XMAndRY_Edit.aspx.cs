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
                    this.AlertAjaxMessage("没有对应的数据记录！");
                    this.WriteAjaxMessage("window.close();");
                    return;
                }



                Epoint.MisBizLogic2.Web.CodeGenerator.InitiateControl_EditPage(oEditPage, tdContainer, oRow);
                //添加上传文件的大小和类型检查
                this.Add_FileUploadCheck_Script();
                //根据规模及专业，将一些不能使用的角色去掉
                //先根据职称，只有中级及以上，才能从事项目、专业负责人
                #region
                if (ZhiCheng_2024.SelectedValue == "1" || ZhiCheng_2024.SelectedValue == "7")
                {
                    DDRole_2024.Items.Remove(new ListItem("专业负责人", "90"));
                    DDRole_2024.Items.Remove(new ListItem("项目/专业负责人", "94"));
                    DDRole_2024.Items.Remove(new ListItem("项目负责人", "95"));
                }
                //string ZYCode = Request["ZYCode"].Substring(0,4);
                //int GM = int.Parse(Request["GMValue"]);
                //if (ZYCode == "0002" )//建筑的，中型以上，必须是一级注册，小型必须是二级
                //{
                //    if (GM >= 80)
                //    { }
                //}
                #endregion
                //ddlZY.Items.Add(new ListItem("请选择", ""));
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
            //加判断条件，项目负责人、专业负责人在本项目、本专业中要唯一
            if (DDRole_2024.SelectedValue == "95")//项目负责人
            {
                if (RG_DW.IsHaveRolsInXM(XMGuid_2024.Text, DDRole_2024.SelectedValue,RYGuid_2024.Text))
                {
                    //提示已经有了
                    AlertAjaxMessage("该项目已有项目负责人");
                    return;
                }
                if (RG_DW.IsHaveRolsInXM(XMGuid_2024.Text, "94", RYGuid_2024.Text))
                {
                    //提示已经有了
                    AlertAjaxMessage("该专业下已有项目/专业负责人");
                    return;
                }
                //还要求有中级以上职称
                if (ZhiCheng_2024.SelectedValue == "1" || ZhiCheng_2024.SelectedValue == "7")
                {
                    AlertAjaxMessage("项目负责人应至少有中级职称");
                    return;
                }
                //工作10年以上，省外企业要求全部，省内的要求2014年7月1日开始
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    if (Request["QYZCD"] == "32")
                    {
                        if (dtNow > dtPass)
                        {
                            AlertAjaxMessage("项目负责人应至少有10年工龄");
                            return;
                        }
                    }
                    else
                    {
                        AlertAjaxMessage("项目负责人应至少有10年工龄");
                        return;
                    }
                }
                //年龄在60岁以内
                if(dtBirth.AddYears(60)<DateTime.Now)
                {
                    AlertAjaxMessage("项目负责人年龄不能超过60岁");
                    return;
                }
                //岩土的项目，项目 负责人均必须是注册岩土师
                #region
                string ZiZhiDJ = Request["ZiZhiDJCode"].Substring(0, 8);
                if (ZiZhiDJ == "00040002" || ZiZhiDJ == "00040003" || ZiZhiDJ == "00040004" || ZiZhiDJ == "00040005" || ZiZhiDJ == "00040006")
                {
                    //看是不是岩土注册，如果不是，要提醒
                    if (ZYZCCode != "00670001")
                    {
                        AlertAjaxMessage("岩土项目的项目负责人应是注册人员");
                        return;
                    }
                }
                #endregion
                //针对专项
                if (ZiZhiDJCode2 == "0003")
                {
                    CheckZhuangXiang();
                }
                #region
                #endregion

            }
            else if (DDRole_2024.SelectedValue == "90")//专业负责人
            {
                if (RG_DW.IsHaveRolsInXM(XMGuid_2024.Text, ZhuanYeCode_2024.Text, DDRole_2024.SelectedValue))
                {
                    //提示已经有了
                    AlertAjaxMessage("该专业下已有专业负责人");
                    return;
                }
                if (RG_DW.IsHaveRolsInXM(XMGuid_2024.Text, ZhuanYeCode_2024.Text,"94"))
                {
                    //提示已经有了
                    AlertAjaxMessage("该专业下已有项目/专业负责人");
                    return;
                }
                //还要求有中级以上职称
                if (ZhiCheng_2024.SelectedValue == "1" || ZhiCheng_2024.SelectedValue == "7")
                {
                    AlertAjaxMessage("专业负责人应至少有中级职称");
                    return;
                }
                //工作10年以上
                
                //工作10年以上，省外企业要求全部，省内的要求2014年7月1日开始
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    if (Request["QYZCD"] == "32")
                    {
                        if (dtNow > dtPass)
                        {
                            AlertAjaxMessage("专业负责人应至少有10年工龄");
                            return;
                        }
                    }
                    else
                    {
                        AlertAjaxMessage("专业负责人应至少有10年工龄");
                        return;
                    }
                }
                //年龄在60岁以内
                if(dtBirth.AddYears(60)<DateTime.Now)
                {
                    AlertAjaxMessage("专业负责人年龄不能超过60岁");
                    return;
                }
                //如果是建筑、结构的，专业负责人要求：中大型的是注册一级，小型的是注册二级
                #region
                if (ZYCode == "0002")//建筑的，中型以上，必须是一级注册，小型必须是二级
                {
                    if (GM >= 80)//中大型
                    {
                        if (ZYZCCode != "00020001")//不是一级注册
                        {
                            AlertAjaxMessage("大中型项目的建筑专业专业负责人应至少是一级注册");
                            return;
                        }
                    }
                    else
                    {
                        if (ZYZCCode != "00020002")//不是二级注册
                        {
                            if (ZYZCCode == "00020001")
                            { }
                            else
                            {
                                AlertAjaxMessage("小型项目的建筑专业专业负责人应至少是二级注册");
                                return;
                            }
                        }
                    }
                }
                if (ZYCode == "0003")//结构的，中型以上，必须是一级注册，小型必须是二级
                {
                    if (GM >= 80)//中大型
                    {
                        if (ZYZCCode != "00030001")//不是一级注册
                        {
                            AlertAjaxMessage("大中型项目的结构专业专业负责人应至少是一级注册");
                            return;
                        }
                    }
                    else
                    {
                        if (ZYZCCode != "00030002")//不是二级注册
                        {
                            if (ZYZCCode == "00030001")
                            { }
                            else
                            {
                                AlertAjaxMessage("小型项目的结构专业专业负责人应至少是二级注册");
                                return;
                            }
                        }
                    }
                }
                #endregion

                //针对专项
                if (ZiZhiDJCode2 == "0003")
                {
                    CheckZhuangXiang();
                }
            }
            else if (DDRole_2024.SelectedValue == "94")//项目/专业负责人
            {
                if (RG_DW.IsHaveRolsInXM(XMGuid_2024.Text, ZhuanYeCode_2024.Text, DDRole_2024.SelectedValue))
                {
                    //提示已经有了
                    AlertAjaxMessage("该专业下已有项目/专业负责人");
                    return;
                }
                if (RG_DW.IsHaveRolsInXM(XMGuid_2024.Text, "95", RYGuid_2024.Text))
                {
                    //提示已经有了
                    AlertAjaxMessage("本项目已有项目负责人");
                    return;
                }
                if (RG_DW.IsHaveRolsInXM(XMGuid_2024.Text, ZhuanYeCode_2024.Text, "90"))
                {
                    //提示已经有了
                    AlertAjaxMessage("该专业下已有专业负责人");
                    return;
                }
                //还要求有中级以上职称
                if (ZhiCheng_2024.SelectedValue == "1" || ZhiCheng_2024.SelectedValue == "7")
                {
                    AlertAjaxMessage("项目/专业负责人应至少有中级职称");
                    return;
                }
                //工作10年以上，省外企业要求全部，省内的要求2014年7月1日开始
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    if (Request["QYZCD"] == "32")
                    {
                        if (dtNow > dtPass)
                        {
                            AlertAjaxMessage("项目/专业负责人应至少有10年工龄");
                            return;
                        }
                    }
                    else
                    {
                        AlertAjaxMessage("项目/专业负责人应至少有10年工龄");
                        return;
                    }
                }
                //年龄在60岁以内
                if(dtBirth.AddYears(60)<DateTime.Now)
                {
                    AlertAjaxMessage("项目/专业负责人年龄不能超过60岁");
                    return;
                }
                //如果是建筑、结构的，专业负责人要求：中大型的是注册一级，小型的是注册二级
                #region
                if (ZYCode == "0002")//建筑的，中型以上，必须是一级注册，小型必须是二级
                {
                    if (GM >= 80)//中大型
                    {
                        if (ZYZCCode != "00020001")//不是一级注册
                        {
                            AlertAjaxMessage("大中型项目的建筑专业专业负责人应至少是一级注册");
                            return;
                        }
                    }
                    else
                    {
                        if (ZYZCCode != "00020002")//不是二级注册
                        {
                            if (ZYZCCode == "00020001")
                            { }
                            else
                            {
                                AlertAjaxMessage("小型项目的建筑专业专业负责人应至少是二级注册");
                                return;
                            }
                        }
                    }
                }
                if (ZYCode == "0003")//结构的，中型以上，必须是一级注册，小型必须是二级
                {
                    if (GM >= 80)//中大型
                    {
                        if (ZYZCCode != "00030001")//不是一级注册
                        {
                            AlertAjaxMessage("大中型项目的结构专业专业负责人应至少是一级注册");
                            return;
                        }
                    }
                    else
                    {
                        if (ZYZCCode != "00030002")//不是二级注册
                        {
                            if (ZYZCCode == "00030001")
                            { }
                            else
                            {
                                AlertAjaxMessage("小型项目的结构专业专业负责人应至少是二级注册");
                                return;
                            }
                        }
                    }
                }
                #endregion

                //岩土的项目，项目 负责人均必须是注册岩土师
                #region
                string ZiZhiDJ = Request["ZiZhiDJCode"].Substring(0, 8);
                if (ZiZhiDJ == "00040002" || ZiZhiDJ == "00040003" || ZiZhiDJ == "00040004" || ZiZhiDJ == "00040005" || ZiZhiDJ == "00040006")
                {
                    //看是不是岩土注册，如果不是，要提醒
                    if (ZYZCCode != "00670001")
                    {
                        AlertAjaxMessage("岩土项目的项目负责人应是注册人员");
                        return;
                    }
                }
                #endregion

                //针对专项
                if (ZiZhiDJCode2 == "0003")
                {
                    CheckZhuangXiang();
                }
            }
            else//设计人员
            { }
            ZhuanYeCS_2024.Text = ddlZY.SelectedValue;
            oEditPage.SaveTableValues(Request["RowGuid"], tdContainer);

            this.WriteAjaxMessage("rtnValue('');");
        }

        //针对专项，还要加验证,专项均为0003
        protected void CheckZhuangXiang()
        {
            string ZiZhiDJCode = Request["ZiZhiDJCode"];
            string ZiZhiDJCode2 = ZiZhiDJCode.Substring(0, 8);
            #region 6-1建筑装饰工程
            if (ZiZhiDJCode == "000300010001")//建筑装饰工程甲级，8年
            {
                if (int.Parse(GongLing_2024.Text) < 8)
                {
                    AlertAjaxMessage("应至少有8年工龄");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300010002")//建筑装饰工程乙级，6年
            {
                if (int.Parse(GongLing_2024.Text) < 6)
                {
                    AlertAjaxMessage("应至少有6年工龄");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300010003")//建筑装饰工程丙级，3年
            {
                if (int.Parse(GongLing_2024.Text) < 3)
                {
                    AlertAjaxMessage("应至少有3年工龄");
                    return;
                }
            }
            #endregion
            #region 6-2建筑智能化
            else if (ZiZhiDJCode == "000300020001")//建筑智能化系统设计甲级，8年
            {
                if (int.Parse(GongLing_2024.Text) < 8)
                {
                    AlertAjaxMessage("应至少有8年工龄");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300020002")//建筑智能化系统设计乙级，5年
            {
                if (int.Parse(GongLing_2024.Text) < 5)
                {
                    AlertAjaxMessage("应至少有5年工龄");
                    return;
                }
            }
            //else if (ZiZhiDJCode == "000300010003")//建筑装饰工程丙级，3年
            //{
            //    if (int.Parse(GongLing_2024.Text) < 3)
            //    {
            //        AlertAjaxMessage("应至少有3年工龄");
            //        return;
            //    }
            //}
            #endregion
            #region 6-3建筑幕墙
            else if (ZiZhiDJCode == "000300030001")//建筑幕墙工程甲级，10年
            {
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    AlertAjaxMessage("应至少有10年工龄");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300030002")//建筑幕墙工程甲级，8年
            {
                if (int.Parse(GongLing_2024.Text) < 8)
                {
                    AlertAjaxMessage("应至少有8年工龄");
                    return;
                }
            }
            //else if (ZiZhiDJCode == "000300010003")//建筑装饰工程丙级，3年
            //{
            //    if (int.Parse(GongLing_2024.Text) < 3)
            //    {
            //        AlertAjaxMessage("应至少有3年工龄");
            //        return;
            //    }
            //}
            #endregion
            #region 6-4轻型房屋钢结构
            else if (ZiZhiDJCode == "000300040001")//轻型房屋钢结构工程甲级，10年
            {
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    AlertAjaxMessage("应至少有10年工龄");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300040002")//轻型房屋钢结构工程乙级，8年
            {
                if (int.Parse(GongLing_2024.Text) < 8)
                {
                    AlertAjaxMessage("应至少有8年工龄");
                    return;
                }
            }
            //else if (ZiZhiDJCode == "000300010003")//建筑装饰工程丙级，3年
            //{
            //    if (int.Parse(GongLing_2024.Text) < 3)
            //    {
            //        AlertAjaxMessage("应至少有3年工龄");
            //        return;
            //    }
            //}
            #endregion
            #region 6-5风景园林工程
            else if (ZiZhiDJCode == "000300050001")//风景园林工程甲级，10年
            {
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    AlertAjaxMessage("应至少有10年工龄");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300050002")//风景园林工程乙级，8年
            {
                if (int.Parse(GongLing_2024.Text) < 8)
                {
                    AlertAjaxMessage("应至少有8年工龄");
                    return;
                }
            }
            //else if (ZiZhiDJCode == "000300010003")//建筑装饰工程丙级，3年
            //{
            //    if (int.Parse(GongLing_2024.Text) < 3)
            //    {
            //        AlertAjaxMessage("应至少有3年工龄");
            //        return;
            //    }
            //}
            #endregion
            #region 6-6消防设施工程
            else if (ZiZhiDJCode == "000300060001")//消防设施工程甲级，10年
            {
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    AlertAjaxMessage("应至少有10年工龄");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300060002")//消防设施工程乙级，8年
            {
                if (int.Parse(GongLing_2024.Text) < 8)
                {
                    AlertAjaxMessage("应至少有8年工龄");
                    return;
                }
            }
            //else if (ZiZhiDJCode == "000300010003")//建筑装饰工程丙级，3年
            //{
            //    if (int.Parse(GongLing_2024.Text) < 3)
            //    {
            //        AlertAjaxMessage("应至少有3年工龄");
            //        return;
            //    }
            //}
            #endregion
            #region 6-7环境工程设计
            else if (ZiZhiDJCode2 == "00030007")//甲级\乙级，5年
            {
                if (int.Parse(GongLing_2024.Text) < 5)
                {
                    AlertAjaxMessage("应至少有5年工龄");
                    return;
                }
            }            
            #endregion
            #region 6-8照明工程
            else if (ZiZhiDJCode == "000300080001")//照明工程甲级，6年
            {
                if (int.Parse(GongLing_2024.Text) < 6)
                {
                    AlertAjaxMessage("应至少有6年工龄");
                    return;
                }
            }
            else if (ZiZhiDJCode == "000300080002")//照明工程乙级，5年
            {
                if (int.Parse(GongLing_2024.Text) < 5)
                {
                    AlertAjaxMessage("应至少有5年工龄");
                    return;
                }
            }
            else
            {
                //工作10年以上
                if (int.Parse(GongLing_2024.Text) < 10)
                {
                    AlertAjaxMessage("应至少有10年工龄");
                    return;
                }
            }
            #endregion
        }

        //绑定专业
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
