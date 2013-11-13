using System;
using System.Collections.Generic;
using System.Text;
using Epoint.Web.UI.WebControls2X.TreeViewControls;
using System.Data;
using Epoint.Web.UI.WebControls2X.TextBoxControls;
using System.Web.UI.WebControls;
using System.Web.UI;
using Epoint.MisBizLogic2.Table;
using Epoint.MisBizLogic2.Data;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.Common;
using System.Web.UI.HtmlControls;
using Epoint.MisBizLogic2.Web;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace HTProject_Bizlogic
{
    public class CommonFunc
    {
        static CommonFunc instace = null;
        public static CommonFunc Instace { get { if (instace == null) instace = new CommonFunc(); return instace; } }

        public static string GetStatusPic(object Status, object TJDate, object Path)
        {
            if (Status.ToString() == "70")
            {
                if (TJDate.ToString() != "")
                {
                    DateTime dtNow = DateTime.Now;
                    DateTime dtTJ = DateTime.Parse(TJDate.ToString());
                    //看时间，超过2天，黄灯，超过3天红灯
                    TimeSpan tsNow = new TimeSpan(dtNow.Ticks); 
                    TimeSpan tsTJ = new TimeSpan(dtTJ.Ticks); 
                    TimeSpan ts = tsNow.Subtract(tsTJ).Duration();
                    if (ts.Days >= 3)
                    {
                        return "<img src='"+ Path + "/Images/redLight.gif' />";
                    }
                    else if (ts.Days >= 2)
                    {
                        return "<img src='" + Path + "/Images/yellowLight.gif' />";
                    }
                    return "";
                }
                return "";
            }
            return "";
        }

        /// <summary>
        /// 从字符串左边截取子字符串
        /// </summary>
        /// <param name="strOrg">要处理的字符串</param>
        /// <param name="num">要返回的位数</param>
        /// <returns></returns>
        public static string Left(string strOrg, int num)
        {
            if (strOrg == null)
            {
                return "";
            }
            else if (num <= 0)
            {
                return strOrg;
            }
            else if (strOrg.Length <= 0)
            {
                return strOrg;
            }
            else if (num >= strOrg.Length)
            {
                return strOrg;
            }
            else
            {
                return strOrg.Substring(0, num);
            }
        }

        /// <summary>
        /// 从字符串右边截取子字符串
        /// </summary>
        /// <param name="strOrg">要处理的字符串</param>
        /// <param name="num">要返回的位数</param>
        /// <returns></returns>
        public static string Right(string strOrg, int num)
        {
            if (strOrg == null)
            {
                return "";
            }
            else if (num < 0)
            {
                return strOrg;
            }
            else if (strOrg.Length <= 0)
            {
                return strOrg;
            }
            else if (num >= strOrg.Length)
            {
                return strOrg;
            }
            else
            {
                return strOrg.Substring(strOrg.Length - num, num);
            }
        }

        public static bool IsRadioButtonListSelected(ListItemCollection LIC)
        {
            bool bSel = false;
            for (int i = 0; i < LIC.Count; i++)
            {
                if (LIC[i].Selected)
                {
                    bSel = true;
                    break;
                }
            }
            return bSel;
        }

        public static void BindListItem(ListItemCollection LIC, DataView DataSource, string TextField, string ValueField)
        {
            LIC.Clear();
            for (int i = 0; i < DataSource.Count; i++)
            {
                LIC.Add(new ListItem(DataSource[i][TextField].ToString(), DataSource[i][ValueField].ToString()));
            }
        }


        /// <summary>
        /// 生成按钮的html内容
        /// </summary>
        /// <param name="ButtonName"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetButtonHtml(string ButtonID, string ButtonName, string url)
        {
            string strButtonHtml = "<input id=\"" + ButtonID + "\" type=\"button\" value=\"" + ButtonName + "\"";
            strButtonHtml += "class=\"Btnbg\" onclick=\"OpenMaxWindow('" + url + "')\" />";

            return strButtonHtml;
        }

        /// <summary>
        /// 判断传入的DataGrid中的选择列是否有被选中的
        /// </summary>
        /// <param name="dg">需要判断的DataGrid</param>
        /// <param name="SelControlName">在DataGrid中的选择控件的ID</param>
        /// <returns>true：有被选中的项；false：一个选中项都没有</returns>
        public static bool HasSelected(DataGrid dg, string SelControlName)
        {
            bool bReturn = false;
            for (int i = 0; i < dg.Items.Count; i++)
            {
                if (((CheckBox)dg.Items[i].FindControl(SelControlName)).Checked == true)
                {
                    bReturn = true;
                    break;
                }
            }
            return bReturn;
        }

        /// <summary>
        /// 设置成只读
        /// </summary>
        /// <param name="MainContainer"></param>
        public void Set_Read_Controls(Control MainContainer)
        {
            //当控件没有子控件时   
            if (!MainContainer.HasControls())
            {
                switch (MainContainer.GetType().ToString())
                {
                    case "Epoint.Web.UI.WebControls2X.TextBox":
                        ((TextBox)MainContainer).Enabled = false;
                        break;
                    case "Epoint.Web.UI.WebControls2X.TextBoxControls.NumericTextBox":
                        ((Epoint.Web.UI.WebControls2X.TextBoxControls.NumericTextBox)MainContainer).Enabled = false;
                        break;
                    case "Epoint.Web.UI.WebControls2X.DateTextBox":
                        ((Epoint.Web.UI.WebControls2X.DateTextBox)MainContainer).Enabled = false;
                        break;
                    case "System.Web.UI.WebControls.DropDownList":
                        ((DropDownList)MainContainer).Enabled = false;
                        break;
                    case "System.Web.UI.WebControls.CheckBoxList":
                        ((CheckBoxList)MainContainer).Enabled = false;
                        break;
                    case "System.Web.UI.WebControls.RadioButtonList":
                        ((RadioButtonList)MainContainer).Enabled = false;
                        break;
                }
            }
            else   //当控件有子控件时   
            {

                int i = 0;
                while (i < MainContainer.Controls.Count)
                {
                    Set_Read_Controls(MainContainer.Controls[i]);
                    i++;
                }
            }
        }



        /// <summary>
        /// 得到IP计算的数值
        /// </summary>
        /// <param name="strIP"></param>
        /// <returns></returns>
        public long GetIPValue(object strIP)
        {
            string[] strIPSec = strIP.ToString().Split('.');
            long lRet = Convert.ToInt64(strIPSec[0]) * 256 * 256 * 256 + Convert.ToInt64(strIPSec[1]) * 256 * 256 * 256
                + Convert.ToInt64(strIPSec[2]) * 256 + Convert.ToInt64(strIPSec[3]);
            return lRet;
        }
        public DataView IP_Office_SelectAll()
        {
            Database db = DatabaseFactory.CreateDatabase("EpointMis_ConnectionString");
            string strSql = "select * from IP_Office";

            DbCommand cmd = db.GetSqlStringCommand(strSql);

            return db.ExecuteDataView(cmd);
        }
        /// <summary>
        /// 检查是否是合法的内部IP
        /// </summary>
        /// <param name="strIP"></param>
        /// <returns></returns>
        public bool Check_IsOfficeIP(string strIP)
        {
            if (strIP == "127.0.0.1")
                return true;
            if (strIP == "::1")
                return false;

            bool blnRet = false;
            DataView dv = IP_Office_SelectAll();
            for (int i = 0; i < dv.Count; i++)
            {
                if (GetIPValue(strIP) > GetIPValue(dv[i]["startIP"]) && GetIPValue(strIP) < GetIPValue(dv[i]["EndIP"]))
                {
                    blnRet = true;
                    break;
                }
            }
            return blnRet;

        }


        /// <summary>
        /// 获取客户端IP地址
        /// </summary>	
        /// <returns></returns>
        public string GetClientIP()
        {
            string strClientip = System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]; //'如果客户端用了代理服务器，则用Request.ServerVariables("REMOTE_ADDR")方法只能得到空值,则应该用ServerVariables("HTTP_X_FORWARDED_FOR")方法
            if (strClientip == "" || strClientip == null)
            {
                strClientip = System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];//'如果客户端没用代理，则Request.ServerVariables("HTTP_X_FORWARDED_FOR")得到是空值，应该用Request.ServerVariables("REMOTE_ADDR")方法
            }

            return strClientip;
        }

        /// <summary>
        /// 动态生成当前表字段对应的所有Web控件，并添加到页面中的一个控件容器：controlPlaceHolder中。
        /// <list type="table">
        ///	<listheader>
        ///	<description>使用说明</description>
        ///	</listheader>
        ///		<item><description>
        ///			 <para>（1）此方法主要用在通用数据添加页面中，所有控件都会动态添加。</para>
        ///          <para>（2）平台生成的个性化页面不需要使用此方法</para>
        ///       </description>   
        ///     </item> 
        /// </list>
        /// </summary>
        /// <param name="controlPlaceHolder">放置动态创建控件的容器</param>
        public void RenderNewTable_WebControl(Control controlPlaceHolder, DataView DvFields, int TableID)
        {
            string str_ControlID_Prefix = controlPlaceHolder.ClientID.Remove(controlPlaceHolder.ClientID.LastIndexOf('_'));

            HtmlTable tbReport = new HtmlTable();
            tbReport.Width = "100%";
            tbReport.ID = "Table_Add";
            tbReport.CellSpacing = 1;

            Epoint.MisBizLogic2.Code.DB_CodeItem codes = new Epoint.MisBizLogic2.Code.DB_CodeItem();
            Epoint.MisBizLogic2.Code.DB_CodeMain main = new Epoint.MisBizLogic2.Code.DB_CodeMain();
            //DvFields.Sort = "OrderNumInGrid desc";
            HtmlTableRow trNew = new HtmlTableRow();
            HtmlTableCell cell = new HtmlTableCell();

            TextBox txtInCell = new TextBox();
            Epoint.Web.UI.WebControls2X.TextBox txtInCellMulText = new Epoint.Web.UI.WebControls2X.TextBox();
            Button btnInCell = new Button();
            LiteralControl ltcInCell = new LiteralControl();
            System.Web.UI.HtmlControls.HtmlInputFile fileUpload = new HtmlInputFile();


            CompareValidator comp;
            RequiredFieldValidator req;
            RegularExpressionValidator reg;
            Epoint.Web.UI.WebControls2X.TreeViewControls.TextTreeView tvcIncell;
            ListItem item;
            string strFieldName = "";

            int j = 0;
            string strValueUrl = "";


            //Add By XGC 2009-12-1 筛选不需要显示的字段
            DvFields.RowFilter = "DispInAdd=1";
            for (int i = 0; i < DvFields.Count; i++)
            {

                //字段中文名称单元格
                cell = new HtmlTableCell();
                //add by liq 为了实现字段的隐藏，需要标识单元格   2008-10-18
                cell.ID = "FieldDesc_" + DvFields[i]["fieldName"].ToString() + "_" + TableID.ToString();

                if (Convert.ToString(DvFields[i]["IsAllNull"]) == "1")
                    cell.InnerHtml = DvFields[i]["fieldChineseName"].ToString() + "<font color=red>(*)</font>";
                else
                    cell.InnerText = DvFields[i]["fieldChineseName"].ToString();

                cell.Attributes.Add("class", "TableSpecial1");
                cell.Width = "15%";

                trNew.Cells.Add(cell);

                strFieldName = DvFields[i]["fieldName"].ToString();

                //字段控件单元格
                cell = new HtmlTableCell();
                cell.Attributes.Add("Class", "TableSpecial");
                cell.Height = "26";
                cell.Width = "85%";

                //add by liq 为了实现字段的隐藏，需要标识单元格   2008-10-18
                cell.ID = "FieldInput_" + DvFields[i]["fieldName"].ToString() + "_" + TableID.ToString();

                #region 根据字段类型写入控件
                //外键字段不需要填写

                switch (DvFields[i]["fieldDisplayType"].ToString().ToLower())
                {
                    case "textbox":
                        #region TextBox类型
                        //strValueUrl = GetValueUrlProperty(DvFields[i]["ValueUrl"]);
                        txtInCell = new Epoint.Web.UI.WebControls2X.TextBox();// TextBox();
                        txtInCell.ID = strFieldName + "_" + TableID;
                        if (strValueUrl == "")
                        {
                            txtInCell.Width = Unit.Percentage(80);
                        }
                        txtInCell.BackColor = System.Drawing.Color.FromName("white");
                        txtInCell.BorderStyle = BorderStyle.Inset;
                        txtInCell.Font.Size = FontUnit.Point(9);
                        txtInCell.EnableViewState = true;
                        ////这是初始化取值
                        //txtInCell.Text = OtherFunction.getDefaultText(DvFields[i]["DefaultValue"]);
                        //if (txtInCell.Text == "")
                        //{
                        //    //这是默认值
                        //    txtInCell.Text = OtherFunction.getFieldDefaultValue(DvFields[i]["fieldDefaultValue"]);
                        //}

                        txtInCell.Attributes.Add("datatype", DvFields[i]["fieldType"].ToString());
                        txtInCell.Attributes.Add("maxsize", DvFields[i]["fieldLength"].ToString());
                        txtInCell.Attributes.Add("chname", DvFields[i]["fieldChineseName"].ToString());

                        #region 2006-6-25  李强添加  根据SQL脚本初始化字段
                        //if (!Convert.IsDBNull(DvFields[i]["InitGetValueSQL"]) && Convert.ToString(DvFields[i]["InitGetValueSQL"]) != "")
                        //{
                        //    txtInCell.Text = GetValue_ExecuteSQL(Convert.ToString(DvFields[i]["InitGetValueSQL"]));
                        //}
                        #endregion
                        cell.Controls.Add(txtInCell);

                        if (strValueUrl != "")
                        {
                            cell.Controls.Add(new LiteralControl("<input type=\"button\" value=\"...\" onclick=\"java" + "script:SelectUrl(" + str_ControlID_Prefix + "_" + txtInCell.ID + ",'" + HttpContext.Current.Request.ApplicationPath + "/EpointMis/Pages/BackEnd/iFrame.aspx?PageUrl=" + strValueUrl + "')\">"));
                        }


                        //对于数值型的控件，右对齐

                        if (DvFields[i]["FieldType"].ToString().ToLower() == "numeric"
                            || DvFields[i]["FieldType"].ToString().ToLower() == "money"
                            || DvFields[i]["FieldType"].ToString().ToLower() == "int")
                        {
                            txtInCell.Style.Add("TEXT-ALIGN", "right");
                            txtInCell.Style.Add("padding-right", "2px");
                        }

                        #region 添加数字验证控件

                        string strDataType1 = DvFields[i]["fieldType"].ToString();
                        if (strDataType1.ToLower().IndexOf("int") > -1) //整数字段
                        {
                            comp = new CompareValidator();
                            comp.ID = "comp_" + strFieldName + "_" + TableID;
                            comp.ControlToValidate = txtInCell.ID;
                            comp.Operator = ValidationCompareOperator.DataTypeCheck;
                            comp.Type = ValidationDataType.Integer;
                            comp.EnableClientScript = true;
                            comp.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "：必须填写整数类型数据！";
                            comp.Display = ValidatorDisplay.None;
                            comp.ForeColor = System.Drawing.Color.Red;
                            comp.Visible = true;
                            cell.Controls.Add(comp);
                        }

                        if (strDataType1.ToLower().IndexOf("numeric") > -1) //浮点数字段
                        {
                            comp = new CompareValidator();
                            comp.ID = "comp_" + strFieldName + "_" + TableID;
                            comp.ControlToValidate = txtInCell.ID;
                            comp.Operator = ValidationCompareOperator.DataTypeCheck;
                            comp.Type = ValidationDataType.Double;
                            comp.EnableClientScript = true;
                            comp.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "：不是合法的数字！";
                            comp.Display = ValidatorDisplay.None;
                            comp.ForeColor = System.Drawing.Color.Red;
                            comp.Visible = true;
                            cell.Controls.Add(comp);
                        }

                        if (strDataType1.ToLower().IndexOf("datetime") > -1) //浮点数字段
                        {
                            comp = new CompareValidator();
                            comp.ID = "comp_" + strFieldName + "_" + TableID;
                            comp.ControlToValidate = txtInCell.ID;
                            comp.Operator = ValidationCompareOperator.DataTypeCheck;
                            comp.Type = ValidationDataType.Date;
                            comp.EnableClientScript = true;
                            comp.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "：不是合法的日期！";
                            comp.Display = ValidatorDisplay.None;
                            comp.ForeColor = System.Drawing.Color.Red;
                            comp.Visible = true;
                            cell.Controls.Add(comp);
                        }
                        #endregion

                        #region 必填校验和正则表达式校验

                        if (Convert.ToString(DvFields[i]["IsAllNull"]) == "1")
                        {
                            req = new RequiredFieldValidator();
                            req.ID = "req_" + strFieldName + "_" + TableID;
                            req.ControlToValidate = txtInCell.ID;
                            req.Display = ValidatorDisplay.None;
                            req.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "必填";
                            cell.Controls.Add(req);
                        }

                        if (Convert.ToString(DvFields[i]["validCheckFormula"]) != "")
                        {
                            reg = new RegularExpressionValidator();
                            reg.ID = "reg_" + strFieldName + "_" + TableID;
                            reg.ValidationExpression = Convert.ToString(DvFields[i]["validCheckFormula"]);
                            reg.ControlToValidate = txtInCell.ID;
                            reg.Display = ValidatorDisplay.None;
                            reg.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "：不符合格式要求";
                            cell.Controls.Add(reg);
                        }
                        #endregion
                        break;
                        #endregion
                    case "datetimepick":
                    case "datepick"://add by liq 2008-6-30
                        #region 日期类型
                        Epoint.Web.UI.WebControls2X.DateTextBox dtb = new Epoint.Web.UI.WebControls2X.DateTextBox();
                        dtb.ID = strFieldName + "_" + TableID;
                        dtb.Character = Epoint.Web.UI.WebControls2X.DateCharacter.HX;
                        if (Convert.ToString(DvFields[i]["IsAllNull"]) == "1")
                        {
                            dtb.AllowNull = false;
                            dtb.RelationName = DvFields[i]["fieldChineseName"].ToString();
                        }
                        if (DvFields[i]["fieldDisplayType"].ToString().ToLower() == "datetimepick")
                        {
                            dtb.DateControlType = Epoint.Web.UI.WebControls2X.eDateTextBox.DateTime;
                        }
                        else
                        {
                            dtb.DateControlType = Epoint.Web.UI.WebControls2X.eDateTextBox.Date;
                        }
                        dtb.InputDateType = Epoint.Web.UI.WebControls2X.eInputDateType.Select;


                        cell.Controls.Add(dtb);
                        break;
                        #endregion
                    case "html":
                        //2009-7-3 liq
                        //if (!Config.EnableFckEditor)
                        //{
                        //    Epoint.Web.UI.WebControls2X.HtmlEditor htmlInCell = new Epoint.Web.UI.WebControls2X.HtmlEditor();
                        //    htmlInCell.ID = strFieldName + "_" + TableID;
                        //    htmlInCell.Text = OtherFunction.getDefaultText(DvFields[i]["DefaultValue"]);
                        //    if (htmlInCell.Text == "")
                        //    {
                        //        //这是默认值
                        //        htmlInCell.Text = OtherFunction.getFieldDefaultValue(DvFields[i]["fieldDefaultValue"]);
                        //    }
                        //    cell.Controls.Add(htmlInCell);
                        //}
                        //else
                        //{
                        //    FredCK.FCKeditorV2.FCKeditor htmlInCell = new FredCK.FCKeditorV2.FCKeditor();
                        //    htmlInCell.ID = strFieldName + "_" + TableID;
                        //    htmlInCell.Text = OtherFunction.getDefaultText(DvFields[i]["DefaultValue"]);
                        //    if (htmlInCell.Text == "")
                        //    {
                        //        //这是默认值
                        //        htmlInCell.Text = OtherFunction.getFieldDefaultValue(DvFields[i]["fieldDefaultValue"]);
                        //    }
                        //    cell.Controls.Add(htmlInCell);
                        //}

                        break;
                    case "dropdownlist":
                        #region 下拉框类型
                        DropDownList jpdIncell = new DropDownList();
                        jpdIncell.ID = strFieldName + "_" + TableID;
                        jpdIncell.Width = Unit.Percentage(80);
                        jpdIncell.Height = Unit.Percentage(100);
                        jpdIncell.BackColor = System.Drawing.Color.FromName("white");
                        jpdIncell.BorderStyle = BorderStyle.Inset;
                        jpdIncell.Font.Size = FontUnit.Point(9);
                        jpdIncell.EnableViewState = true;

                        jpdIncell.DataSource = codes.Get_Items_By_CodeName(DvFields[i]["DataSource_CodeName"].ToString());
                        jpdIncell.DataTextField = "ItemText";
                        jpdIncell.DataValueField = "ItemValue";
                        jpdIncell.DataBind();

                        //if (DvFields[i]["fieldDefaultValue"].ToString() != "")
                        //    jpdIncell.SelectedValue = OtherFunction.getFieldDefaultValue(DvFields[i]["fieldDefaultValue"].ToString());
                        cell.Controls.Add(jpdIncell);
                        if (Convert.ToString(DvFields[i]["IsAllNull"]) == "1")
                        {
                            System.Web.UI.WebControls.RequiredFieldValidator RFV = new RequiredFieldValidator();
                            RFV.ID = "RFV" + strFieldName;
                            RFV.ControlToValidate = jpdIncell.ID;
                            RFV.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "必填";
                            cell.Controls.Add(RFV);
                        }
                        break;
                        #endregion
                    case "textarea":
                        #region 多行文本框
                        //strValueUrl = GetValueUrlProperty(DvFields[i]["ValueUrl"]);
                        txtInCellMulText = new Epoint.Web.UI.WebControls2X.TextBox();
                        txtInCellMulText.ID = strFieldName + "_" + TableID;
                        txtInCellMulText.Width = Unit.Percentage(97);
                        txtInCellMulText.Height = Unit.Pixel(100);
                        txtInCellMulText.TextMode = TextBoxMode.MultiLine;
                        if (strValueUrl == "")
                        {
                            txtInCellMulText.Width = Unit.Percentage(100);
                        }
                        txtInCellMulText.BackColor = System.Drawing.Color.FromName("white");
                        txtInCellMulText.BorderStyle = BorderStyle.Inset;
                        txtInCellMulText.Font.Size = FontUnit.Point(9);
                        txtInCellMulText.EnableViewState = true;

                        //txtInCellMulText.Text = OtherFunction.getDefaultText(DvFields[i]["DefaultValue"]);
                        if (txtInCellMulText.Text == "")
                        {
                            //这是默认值
                            //txtInCellMulText.Text = OtherFunction.getFieldDefaultValue(DvFields[i]["fieldDefaultValue"]);
                        }
                        cell.Controls.Add(txtInCellMulText);
                        if (strValueUrl != "")
                        {
                            cell.Controls.Add(new LiteralControl("<input type=\"button\" value=\"...\" onclick=\"java" + "script:SelectUrl(" + txtInCell.ID + ",'" + HttpContext.Current.Request.ApplicationPath + "/EpointMis/BackEnd/iFrame.aspx?PageUrl=" + strValueUrl + "')\">"));
                        }
                        if (Convert.ToString(DvFields[i]["IsAllNull"]) == "1")
                        {
                            req = new RequiredFieldValidator();
                            req.ID = "req_" + strFieldName + "_" + TableID;
                            req.ControlToValidate = txtInCellMulText.ID;
                            req.Display = ValidatorDisplay.None;
                            req.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "必填";
                            cell.Controls.Add(req);
                        }
                        break;
                        #endregion
                    case "radio":
                        #region 单选框
                        RadioButtonList rdoInCell = new RadioButtonList();
                        rdoInCell.RepeatDirection = RepeatDirection.Horizontal;
                        rdoInCell.ID = strFieldName + "_" + TableID;
                        rdoInCell.DataSource = codes.Get_Items_By_CodeName(DvFields[i]["DataSource_CodeName"].ToString());
                        rdoInCell.DataTextField = "ItemText";
                        rdoInCell.DataValueField = "ItemValue";
                        rdoInCell.DataBind();

                        if (rdoInCell.Items.Count > 0)
                        {
                            rdoInCell.SelectedIndex = 0;
                            //if (DvFields[i]["fieldDefaultValue"].ToString() != "")
                            //{
                            //    item = rdoInCell.Items.FindByValue(OtherFunction.getFieldDefaultValue(DvFields[i]["fieldDefaultValue"].ToString()));
                            //    if (item != null)
                            //    {
                            //        rdoInCell.SelectedIndex = rdoInCell.Items.IndexOf(item);
                            //    }
                            //}
                        }

                        cell.Controls.Add(rdoInCell);

                        //徐国春2009-12-1注释，此处不需要必填判断，radio，肯定有值，除非未绑定。
                        //if (Convert.ToString(DvFields[i]["IsAllNull"]) == "1")
                        //{
                        //    req = new RequiredFieldValidator();
                        //    req.ID = "req_" + strFieldName + "_" + TableID;
                        //    req.ControlToValidate = rdoInCell.ID;
                        //    req.Display = ValidatorDisplay.None;
                        //    req.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "必填";
                        //    cell.Controls.Add(req);
                        //}
                        break;
                        #endregion
                    case "checkbox":
                        #region 多选框
                        CheckBoxList chkInCell = new CheckBoxList();
                        chkInCell.RepeatDirection = RepeatDirection.Horizontal;
                        chkInCell.ID = strFieldName + "_" + TableID;
                        chkInCell.DataSource = codes.Get_Items_By_CodeName(DvFields[i]["DataSource_CodeName"].ToString());
                        chkInCell.DataTextField = "ItemText";
                        chkInCell.DataValueField = "ItemValue";
                        chkInCell.DataBind();

                        //if (chkInCell.Items.Count > 0)
                        //{
                        //    if (DvFields[i]["fieldDefaultValue"].ToString() != "")
                        //    {
                        //        string[] aValue = DvFields[i]["fieldDefaultValue"].ToString().Split(';');
                        //        for (int mm = 0; mm < aValue.Length; mm++)
                        //        {
                        //            if (aValue[mm] != "")
                        //            {
                        //                item = chkInCell.Items.FindByValue(aValue[mm]);
                        //                if (item != null)
                        //                    item.Selected = true;
                        //            }
                        //        }
                        //    }
                        //}
                        cell.Controls.Add(chkInCell);
                        break;
                        #endregion
                    case "calculate":
                        #region 计算
                        txtInCell = new TextBox();
                        txtInCell.ID = strFieldName + "_" + TableID;
                        txtInCell.Width = Unit.Percentage(97);
                        txtInCell.Height = Unit.Percentage(100);
                        txtInCell.BackColor = System.Drawing.Color.FromName("white");
                        txtInCell.BorderStyle = BorderStyle.Inset;
                        txtInCell.Font.Size = FontUnit.Point(9);
                        txtInCell.EnableViewState = true;
                        txtInCell.Enabled = false;
                        txtInCell.ToolTip = "本输入框是计算格,不需用户输入!";
                        txtInCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FAEBD7");

                        if (DvFields[i]["FieldType"].ToString().ToLower() == "numeric"
                            || DvFields[i]["FieldType"].ToString().ToLower() == "money"
                            || DvFields[i]["FieldType"].ToString().ToLower() == "int")
                        {
                            txtInCell.Style.Add("TEXT-ALIGN", "right");
                            txtInCell.Style.Add("padding-right", "2px");
                        }

                        cell.Controls.Add(txtInCell);
                        break;
                        #endregion
                    case "image":
                        fileUpload = new HtmlInputFile();
                        fileUpload.ID = strFieldName + "_" + TableID;
                        cell.Controls.Add(fileUpload);
                        break;
                    case "texttreeview"://添加一种类型TextTreeView,使用树选择方式来显示。
                        #region 树选择方式
                        //tvcIncell = new Epoint.Web.UI.WebControls2X.TreeViewControls.TextTreeView();
                        //tvcIncell.ID = strFieldName + "_" + TableID; ;
                        //tvcIncell.ImgFolds = HttpContext.Current.Request.ApplicationPath + "/Images/TreeImages";
                        //tvcIncell.RootNodeText = DvFields[i]["DataSource_CodeName"].ToString();
                        //tvcIncell.MultiSelect = false;

                        //tvcIncell.TreeNodePopulate += TreeNodePopulate;
                        //cell.Controls.Add(tvcIncell);
                        //codes.InitTextTreeView(tvcIncell, main.GetDetail(DvFields[i]["DataSource_CodeName"].ToString()).CodeID, false);


                        ////这是默认值
                        //tvcIncell.Value = OtherFunction.getFieldDefaultValue(DvFields[i]["fieldDefaultValue"]);
                        //if (tvcIncell.Value != "")
                        //{
                        //    tvcIncell.Text = main.GetCodeText_FromHash(DvFields[i]["DataSource_CodeName"].ToString(), tvcIncell.Value);
                        //}

                        //#region 必填校验和正则表达式校验

                        //if (Convert.ToString(DvFields[i]["IsAllNull"]) == "1")
                        //{
                        //    tvcIncell.AllowNull = false;
                        //}

                        //if (Convert.ToString(DvFields[i]["validCheckFormula"]) != "")
                        //{
                        //    reg = new RegularExpressionValidator();
                        //    reg.ID = "reg_" + strFieldName + "_" + TableID;
                        //    reg.ValidationExpression = Convert.ToString(DvFields[i]["validCheckFormula"]);
                        //    reg.ControlToValidate = txtInCell.ID;
                        //    reg.Display = ValidatorDisplay.None;
                        //    reg.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "：不符合格式要求";
                        //    cell.Controls.Add(reg);
                        //}
                        //#endregion
                        //break;

                        #endregion
                        break;
                    case "multitexttreeview":
                        #region 树选择方式
                        //tvcIncell = new Epoint.Web.UI.WebControls2X.TreeViewControls.TextTreeView();
                        //tvcIncell.ID = strFieldName + "_" + TableID; ;
                        //tvcIncell.ImgFolds = HttpContext.Current.Request.ApplicationPath + "/Images/TreeImages";
                        //tvcIncell.RootNodeText = DvFields[i]["DataSource_CodeName"].ToString();
                        //tvcIncell.InputType = Epoint.Web.UI.WebControls2X.eInputType.CheckBox;
                        //tvcIncell.MultiSelect = true;

                        //tvcIncell.TreeNodePopulate += MultiTreeNodePopulate;
                        //cell.Controls.Add(tvcIncell);
                        //codes.InitTextTreeView(tvcIncell, main.GetDetail(DvFields[i]["DataSource_CodeName"].ToString()).CodeID, true);

                        ////这是默认值
                        //tvcIncell.Value = OtherFunction.getFieldDefaultValue(DvFields[i]["fieldDefaultValue"]);
                        //if (tvcIncell.Value != "")
                        //{
                        //    tvcIncell.Text = main.GetCodeText_For_TextTreeView(DvFields[i]["DataSource_CodeName"].ToString(), tvcIncell.Value);
                        //}


                        //#region 必填校验和正则表达式校验

                        //if (Convert.ToString(DvFields[i]["IsAllNull"]) == "1")
                        //{
                        //    tvcIncell.AllowNull = false;
                        //}

                        //if (Convert.ToString(DvFields[i]["validCheckFormula"]) != "")
                        //{
                        //    reg = new RegularExpressionValidator();
                        //    reg.ID = "reg_" + strFieldName + "_" + TableID;
                        //    reg.ValidationExpression = Convert.ToString(DvFields[i]["validCheckFormula"]);
                        //    reg.ControlToValidate = txtInCell.ID;
                        //    reg.Display = ValidatorDisplay.None;
                        //    reg.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "：不符合格式要求";
                        //    cell.Controls.Add(reg);
                        //}
                        //#endregion
                        //break;

                        #endregion
                        break;
                    case "checkboxlst":
                        #region MyRegion
                        //DataView dvChkLst = OtherFunction.GetViewCheckBoxLst(DvFields[i]["DataSource_CodeName"].ToString());

                        //for (int n = 0; n < dvChkLst.Count; n++)
                        //{
                        //    CheckBox chkLstInCell = new CheckBox();
                        //    chkLstInCell.ID = strFieldName + "_" + TableID + "_" + dvChkLst[n]["ItemValue"].ToString();
                        //    chkLstInCell.Text = dvChkLst[n]["ItemText"].ToString();
                        //    cell.Controls.Add(chkLstInCell);

                        //    if (n != 0 && n % 5 == 0)
                        //        cell.Controls.Add(new LiteralControl("<br>"));
                        //}
                        break;
                        #endregion
                    case "radiolst":
                        #region MyRegion
                        //DataView dvRdoLst = OtherFunction.GetViewCheckBoxLst(DvFields[i]["DataSource_CodeName"].ToString());

                        //for (int n = 0; n < dvRdoLst.Count; n++)
                        //{
                        //    RadioButton radioInCell = new RadioButton();
                        //    radioInCell.ID = strFieldName + "_" + TableID + "_" + dvRdoLst[n]["ItemValue"].ToString();
                        //    radioInCell.Text = dvRdoLst[n]["ItemText"].ToString();
                        //    radioInCell.GroupName = strFieldName + "_" + TableID;
                        //    cell.Controls.Add(radioInCell);

                        //    if (n != 0 && n % 5 == 0)
                        //        cell.Controls.Add(new LiteralControl("<br>"));
                        //}
                        break;
                        #endregion


                }
                #endregion

                #region 加入了是否显示字段说明的功能
                //2006-6-26  liqiang
                //if (!Convert.IsDBNull(DvFields[i]["DispFieldDesc"]) && Convert.ToBoolean(DvFields[i]["DispFieldDesc"]))
                //{
                //    LiteralControl lit = new LiteralControl();
                //    lit.Text = "<font color=blue>注：" + Convert.ToString(DvFields[i]["FieldDesc"]) + "</font>";
                //    cell.Controls.Add(lit);
                //}
                #endregion

                int nNextControlWidth = (i < DvFields.Count - 1) ? Convert.ToInt32(DvFields[i + 1]["ControlWidth"]) : 1;

                cell.Width = "85%";
                if (DvFields[i]["fieldDisplayType"].ToString().ToLower() == "dropdownlist")
                {

                }

                trNew.Cells.Add(cell);

                tbReport.Rows.Add(trNew);
                trNew = new HtmlTableRow();

            }//循环结尾
            if (trNew.Controls.Count != 0)
            {
                tbReport.Rows.Add(trNew);
            }
            controlPlaceHolder.Controls.Add(tbReport);
        }

        public void RenderNewTable_WebControl2(Control controlPlaceHolder, DataView DvFields, int TableID)
        {
            string str_ControlID_Prefix = controlPlaceHolder.ClientID.Remove(controlPlaceHolder.ClientID.LastIndexOf('_'));

            HtmlTable tbReport = new HtmlTable();
            tbReport.Width = "100%";
            tbReport.ID = "Table_Add";
            tbReport.CellSpacing = 1;

            Epoint.MisBizLogic2.Code.DB_CodeItem codes = new Epoint.MisBizLogic2.Code.DB_CodeItem();
            Epoint.MisBizLogic2.Code.DB_CodeMain main = new Epoint.MisBizLogic2.Code.DB_CodeMain();
            //DvFields.Sort = "OrderNumInGrid desc";
            HtmlTableRow trNew = new HtmlTableRow();
            HtmlTableCell cell = new HtmlTableCell();

            TextBox txtInCell = new TextBox();
            Epoint.Web.UI.WebControls2X.TextBox txtInCellMulText = new Epoint.Web.UI.WebControls2X.TextBox();
            Button btnInCell = new Button();
            LiteralControl ltcInCell = new LiteralControl();
            System.Web.UI.HtmlControls.HtmlInputFile fileUpload = new HtmlInputFile();


            CompareValidator comp;
            RequiredFieldValidator req;
            RegularExpressionValidator reg;
            Epoint.Web.UI.WebControls2X.TreeViewControls.TextTreeView tvcIncell;
            ListItem item;
            string strFieldName = "";

            int j = 0;
            string strValueUrl = "";


            //Add By XGC 2009-12-1 筛选不需要显示的字段
            DvFields.RowFilter = "DispInAdd=1";
            for (int i = 0; i < DvFields.Count; i++)
            {

                //字段中文名称单元格
                cell = new HtmlTableCell();
                //add by liq 为了实现字段的隐藏，需要标识单元格   2008-10-18
                cell.ID = "FieldDesc_" + DvFields[i]["fieldName"].ToString() + "_" + TableID.ToString();

                if (Convert.ToString(DvFields[i]["IsAllNull"]) == "1")
                    cell.InnerHtml = DvFields[i]["fieldChineseName"].ToString() + "<font color=red>(*)</font>";
                else
                    cell.InnerText = DvFields[i]["fieldChineseName"].ToString();

                cell.Attributes.Add("class", "TableSpecial1");
                cell.Width = "15%";

                trNew.Cells.Add(cell);

                strFieldName = DvFields[i]["fieldName"].ToString();

                //字段控件单元格
                cell = new HtmlTableCell();
                cell.Attributes.Add("Class", "TableSpecial");
                cell.Height = "26";
                cell.Width = "85%";

                //add by liq 为了实现字段的隐藏，需要标识单元格   2008-10-18
                cell.ID = "FieldInput_" + DvFields[i]["fieldName"].ToString() + "_" + TableID.ToString();

                #region 根据字段类型写入控件
                //外键字段不需要填写

                switch (DvFields[i]["fieldDisplayType"].ToString().ToLower())
                {
                    case "textbox":
                        #region TextBox类型
                        //strValueUrl = GetValueUrlProperty(DvFields[i]["ValueUrl"]);
                        txtInCell = new Epoint.Web.UI.WebControls2X.TextBox();// TextBox();
                        txtInCell.ID = strFieldName + "_" + TableID;
                        if (strValueUrl == "")
                        {
                            txtInCell.Width = Unit.Percentage(80);
                        }
                        txtInCell.BackColor = System.Drawing.Color.FromName("white");
                        txtInCell.BorderStyle = BorderStyle.Inset;
                        txtInCell.Font.Size = FontUnit.Point(9);
                        txtInCell.EnableViewState = true;


                        txtInCell.Attributes.Add("datatype", DvFields[i]["fieldType"].ToString());
                        txtInCell.Attributes.Add("maxsize", DvFields[i]["fieldLength"].ToString());
                        txtInCell.Attributes.Add("chname", DvFields[i]["fieldChineseName"].ToString());

                        cell.Controls.Add(txtInCell);

                        if (strValueUrl != "")
                        {
                            cell.Controls.Add(new LiteralControl("<input type=\"button\" value=\"...\" onclick=\"java" + "script:SelectUrl(" + str_ControlID_Prefix + "_" + txtInCell.ID + ",'" + HttpContext.Current.Request.ApplicationPath + "/EpointMis/Pages/BackEnd/iFrame.aspx?PageUrl=" + strValueUrl + "')\">"));
                        }


                        //对于数值型的控件，右对齐

                        if (DvFields[i]["FieldType"].ToString().ToLower() == "numeric"
                            || DvFields[i]["FieldType"].ToString().ToLower() == "money"
                            || DvFields[i]["FieldType"].ToString().ToLower() == "int")
                        {
                            txtInCell.Style.Add("TEXT-ALIGN", "right");
                            txtInCell.Style.Add("padding-right", "2px");
                        }

                        #region 添加数字验证控件

                        string strDataType1 = DvFields[i]["fieldType"].ToString();
                        if (strDataType1.ToLower().IndexOf("int") > -1) //整数字段
                        {
                            comp = new CompareValidator();
                            comp.ID = "comp_" + strFieldName + "_" + TableID;
                            comp.ControlToValidate = txtInCell.ID;
                            comp.Operator = ValidationCompareOperator.DataTypeCheck;
                            comp.Type = ValidationDataType.Integer;
                            comp.EnableClientScript = true;
                            comp.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "：必须填写整数类型数据！";
                            comp.Display = ValidatorDisplay.None;
                            comp.ForeColor = System.Drawing.Color.Red;
                            comp.Visible = true;
                            cell.Controls.Add(comp);
                        }

                        if (strDataType1.ToLower().IndexOf("numeric") > -1) //浮点数字段
                        {
                            comp = new CompareValidator();
                            comp.ID = "comp_" + strFieldName + "_" + TableID;
                            comp.ControlToValidate = txtInCell.ID;
                            comp.Operator = ValidationCompareOperator.DataTypeCheck;
                            comp.Type = ValidationDataType.Double;
                            comp.EnableClientScript = true;
                            comp.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "：不是合法的数字！";
                            comp.Display = ValidatorDisplay.None;
                            comp.ForeColor = System.Drawing.Color.Red;
                            comp.Visible = true;
                            cell.Controls.Add(comp);
                        }

                        if (strDataType1.ToLower().IndexOf("datetime") > -1) //浮点数字段
                        {
                            comp = new CompareValidator();
                            comp.ID = "comp_" + strFieldName + "_" + TableID;
                            comp.ControlToValidate = txtInCell.ID;
                            comp.Operator = ValidationCompareOperator.DataTypeCheck;
                            comp.Type = ValidationDataType.Date;
                            comp.EnableClientScript = true;
                            comp.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "：不是合法的日期！";
                            comp.Display = ValidatorDisplay.None;
                            comp.ForeColor = System.Drawing.Color.Red;
                            comp.Visible = true;
                            cell.Controls.Add(comp);
                        }
                        #endregion

                        #region 必填校验和正则表达式校验

                        if (Convert.ToString(DvFields[i]["IsAllNull"]) == "1")
                        {
                            req = new RequiredFieldValidator();
                            req.ID = "req_" + strFieldName + "_" + TableID;
                            req.ControlToValidate = txtInCell.ID;
                            req.Display = ValidatorDisplay.None;
                            req.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "必填";
                            cell.Controls.Add(req);
                        }

                        if (Convert.ToString(DvFields[i]["validCheckFormula"]) != "")
                        {
                            reg = new RegularExpressionValidator();
                            reg.ID = "reg_" + strFieldName + "_" + TableID;
                            reg.ValidationExpression = Convert.ToString(DvFields[i]["validCheckFormula"]);
                            reg.ControlToValidate = txtInCell.ID;
                            reg.Display = ValidatorDisplay.None;
                            reg.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "：不符合格式要求";
                            cell.Controls.Add(reg);
                        }
                        #endregion
                        break;
                        #endregion
                    case "datetimepick":
                    case "datepick"://add by liq 2008-6-30
                        #region 日期类型
                        Epoint.Web.UI.WebControls2X.DateTextBox dtb = new Epoint.Web.UI.WebControls2X.DateTextBox();
                        dtb.ID = strFieldName + "_" + TableID;
                        dtb.Character = Epoint.Web.UI.WebControls2X.DateCharacter.HX;
                        if (Convert.ToString(DvFields[i]["IsAllNull"]) == "1")
                        {
                            dtb.AllowNull = false;
                            dtb.RelationName = DvFields[i]["fieldChineseName"].ToString();
                        }
                        if (DvFields[i]["fieldDisplayType"].ToString().ToLower() == "datetimepick")
                        {
                            dtb.DateControlType = Epoint.Web.UI.WebControls2X.eDateTextBox.DateTime;
                        }
                        else
                        {
                            dtb.DateControlType = Epoint.Web.UI.WebControls2X.eDateTextBox.Date;
                        }
                        dtb.InputDateType = Epoint.Web.UI.WebControls2X.eInputDateType.Select;


                        cell.Controls.Add(dtb);
                        break;
                        #endregion
                    case "html":

                        break;
                    case "dropdownlist":
                        #region 下拉框类型
                        DropDownList jpdIncell = new DropDownList();
                        jpdIncell.ID = strFieldName + "_" + TableID;
                        jpdIncell.Width = Unit.Percentage(80);
                        jpdIncell.Height = Unit.Percentage(100);
                        jpdIncell.BackColor = System.Drawing.Color.FromName("white");
                        jpdIncell.BorderStyle = BorderStyle.Inset;
                        jpdIncell.Font.Size = FontUnit.Point(9);
                        jpdIncell.EnableViewState = true;

                        //jpdIncell.DataSource = codes.Get_Items_By_CodeName(DvFields[i]["DataSource_CodeName"].ToString());
                        //jpdIncell.DataTextField = "ItemText";
                        //jpdIncell.DataValueField = "ItemValue";
                        //jpdIncell.DataBind();

                        //if (DvFields[i]["fieldDefaultValue"].ToString() != "")
                        //    jpdIncell.SelectedValue = OtherFunction.getFieldDefaultValue(DvFields[i]["fieldDefaultValue"].ToString());
                        cell.Controls.Add(jpdIncell);
                        if (Convert.ToString(DvFields[i]["IsAllNull"]) == "1")
                        {
                            System.Web.UI.WebControls.RequiredFieldValidator RFV = new RequiredFieldValidator();
                            RFV.ID = "RFV" + strFieldName;
                            RFV.ControlToValidate = jpdIncell.ID;
                            RFV.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "必填";
                            cell.Controls.Add(RFV);
                        }
                        break;
                        #endregion
                    case "textarea":
                        #region 多行文本框
                        //strValueUrl = GetValueUrlProperty(DvFields[i]["ValueUrl"]);
                        txtInCellMulText = new Epoint.Web.UI.WebControls2X.TextBox();
                        txtInCellMulText.ID = strFieldName + "_" + TableID;
                        txtInCellMulText.Width = Unit.Percentage(97);
                        txtInCellMulText.Height = Unit.Pixel(100);
                        txtInCellMulText.TextMode = TextBoxMode.MultiLine;
                        if (strValueUrl == "")
                        {
                            txtInCellMulText.Width = Unit.Percentage(100);
                        }
                        txtInCellMulText.BackColor = System.Drawing.Color.FromName("white");
                        txtInCellMulText.BorderStyle = BorderStyle.Inset;
                        txtInCellMulText.Font.Size = FontUnit.Point(9);
                        txtInCellMulText.EnableViewState = true;

                        //txtInCellMulText.Text = OtherFunction.getDefaultText(DvFields[i]["DefaultValue"]);
                        if (txtInCellMulText.Text == "")
                        {
                            //这是默认值
                            //txtInCellMulText.Text = OtherFunction.getFieldDefaultValue(DvFields[i]["fieldDefaultValue"]);
                        }
                        cell.Controls.Add(txtInCellMulText);
                        if (strValueUrl != "")
                        {
                            cell.Controls.Add(new LiteralControl("<input type=\"button\" value=\"...\" onclick=\"java" + "script:SelectUrl(" + txtInCell.ID + ",'" + HttpContext.Current.Request.ApplicationPath + "/EpointMis/BackEnd/iFrame.aspx?PageUrl=" + strValueUrl + "')\">"));
                        }
                        if (Convert.ToString(DvFields[i]["IsAllNull"]) == "1")
                        {
                            req = new RequiredFieldValidator();
                            req.ID = "req_" + strFieldName + "_" + TableID;
                            req.ControlToValidate = txtInCellMulText.ID;
                            req.Display = ValidatorDisplay.None;
                            req.ErrorMessage = DvFields[i]["fieldChineseName"].ToString() + "必填";
                            cell.Controls.Add(req);
                        }
                        break;
                        #endregion
                    case "radio":
                        #region 单选框
                        RadioButtonList rdoInCell = new RadioButtonList();
                        rdoInCell.RepeatDirection = RepeatDirection.Horizontal;
                        rdoInCell.ID = strFieldName + "_" + TableID;
                        rdoInCell.DataSource = codes.Get_Items_By_CodeName(DvFields[i]["DataSource_CodeName"].ToString());
                        rdoInCell.DataTextField = "ItemText";
                        rdoInCell.DataValueField = "ItemValue";
                        rdoInCell.DataBind();

                        if (rdoInCell.Items.Count > 0)
                        {
                            rdoInCell.SelectedIndex = 0;
                            //if (DvFields[i]["fieldDefaultValue"].ToString() != "")
                            //{
                            //    item = rdoInCell.Items.FindByValue(OtherFunction.getFieldDefaultValue(DvFields[i]["fieldDefaultValue"].ToString()));
                            //    if (item != null)
                            //    {
                            //        rdoInCell.SelectedIndex = rdoInCell.Items.IndexOf(item);
                            //    }
                            //}
                        }

                        cell.Controls.Add(rdoInCell);

                        break;
                        #endregion
                    case "checkbox":
                        #region 多选框
                        CheckBoxList chkInCell = new CheckBoxList();
                        chkInCell.RepeatDirection = RepeatDirection.Horizontal;
                        chkInCell.ID = strFieldName + "_" + TableID;
                        chkInCell.DataSource = codes.Get_Items_By_CodeName(DvFields[i]["DataSource_CodeName"].ToString());
                        chkInCell.DataTextField = "ItemText";
                        chkInCell.DataValueField = "ItemValue";
                        chkInCell.DataBind();

                        cell.Controls.Add(chkInCell);
                        break;
                        #endregion
                    case "calculate":
                        #region 计算
                        txtInCell = new TextBox();
                        txtInCell.ID = strFieldName + "_" + TableID;
                        txtInCell.Width = Unit.Percentage(97);
                        txtInCell.Height = Unit.Percentage(100);
                        txtInCell.BackColor = System.Drawing.Color.FromName("white");
                        txtInCell.BorderStyle = BorderStyle.Inset;
                        txtInCell.Font.Size = FontUnit.Point(9);
                        txtInCell.EnableViewState = true;
                        txtInCell.Enabled = false;
                        txtInCell.ToolTip = "本输入框是计算格,不需用户输入!";
                        txtInCell.BackColor = System.Drawing.ColorTranslator.FromHtml("#FAEBD7");

                        if (DvFields[i]["FieldType"].ToString().ToLower() == "numeric"
                            || DvFields[i]["FieldType"].ToString().ToLower() == "money"
                            || DvFields[i]["FieldType"].ToString().ToLower() == "int")
                        {
                            txtInCell.Style.Add("TEXT-ALIGN", "right");
                            txtInCell.Style.Add("padding-right", "2px");
                        }

                        cell.Controls.Add(txtInCell);
                        break;
                        #endregion
                    case "image":
                        fileUpload = new HtmlInputFile();
                        fileUpload.ID = strFieldName + "_" + TableID;
                        cell.Controls.Add(fileUpload);
                        break;
                    case "texttreeview"://添加一种类型TextTreeView,使用树选择方式来显示。
                        #region 树选择方式

                        #endregion
                        break;
                    case "multitexttreeview":
                        #region 树选择方式

                        #endregion
                        break;
                    case "checkboxlst":
                        #region MyRegion

                        break;
                        #endregion
                    case "radiolst":
                        #region MyRegion

                        break;
                        #endregion


                }
                #endregion



                int nNextControlWidth = (i < DvFields.Count - 1) ? Convert.ToInt32(DvFields[i + 1]["ControlWidth"]) : 1;

                cell.Width = "85%";
                if (DvFields[i]["fieldDisplayType"].ToString().ToLower() == "dropdownlist")
                {

                }

                trNew.Cells.Add(cell);

                tbReport.Rows.Add(trNew);
                trNew = new HtmlTableRow();

            }//循环结尾
            if (trNew.Controls.Count != 0)
            {
                tbReport.Rows.Add(trNew);
            }
            controlPlaceHolder.Controls.Add(tbReport);
        }

        public void BindDropDownList(DropDownList DDL, string strSql, string FieldName, string FieldValue)
        {
            DataView dv = Epoint.MisBizLogic2.DB.ExecuteDataView(strSql);
            for (int m = 0; m < dv.Count; m++)
            {
                DDL.Items.Add(new ListItem(dv[m][FieldName].ToString(), dv[m][FieldValue].ToString()));
            }
        }
    }

    public class SMS
    {


        protected bool SqlEvent(string Sql)//数据库添加删除更新处理
        {
            bool returns = true;
            Database db = DatabaseFactory.CreateDatabase("SMS_ConnectionString");
            try
            {
                DbCommand cmd = db.GetSqlStringCommand(Sql);
                db.ExecuteNonQuery(cmd);
            }
            catch (Exception ex)
            {
                ex.ToString();
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('" + ex.ToString() + "')</script>");
                returns = false;
            }
            return returns;
        }


        public void SendSMS(object sendUserName, object receiveUserName, object smsContent, object receiveMobilePhone)
        {
            string rowid = "kcsj" + Guid.NewGuid().ToString();
            string messagesql = "insert into T_SendTask(DestNumber,Content,SendFlag)values('"
                + receiveMobilePhone.ToString().Trim() + "','" + smsContent + "',0)";
            if (SqlEvent(messagesql))
            {//写入短信发送
                string addsql = "insert into smsMessage (sendUserName,receiveUserName,smscontent,receiveMobilePhone,issend,row_id,senddate,messagetarget)values('"
                    + sendUserName + "','" + receiveUserName + "','" + smsContent + "','" + receiveMobilePhone.ToString().Trim() + "', 0 ,'" + rowid + "','"
                    + DateTime.Now.ToString().Trim() + "','YES')";  //本地数据库

                Epoint.MisBizLogic2.DB.ExecuteNonQuery(addsql);
            }

        }
    }
}
