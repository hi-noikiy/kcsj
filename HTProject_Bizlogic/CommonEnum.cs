using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

namespace HTProject_Bizlogic
{
    /// <summary>
    /// 存放所有的枚举类型数据
    /// </summary>
    public class CommonEnum
    {
        public class MyEnumBase
        {
            public virtual Hashtable GetTextValue()
            {
                return new Hashtable();
            }

            public string GetTextByValue(string _Value)
            {
                Hashtable ht = GetTextValue();
                return ht[_Value].ToString();
            }
            /// <summary>
            /// 绑定控件的ListItem项
            /// </summary>
            /// <param name="LIC"></param>
            /// <param name="IsFistNull"></param>
            public void InitListItems(ListItemCollection LIC, bool IsFistNull)
            {
                if (LIC.Count > 0)
                {
                    LIC.Clear();
                }
                Hashtable ht = GetTextValue();
                foreach (DictionaryEntry de in ht)
                {
                    LIC.Add(new ListItem(de.Value.ToString(), de.Key.ToString()));
                }
                if (IsFistNull)
                {
                    LIC.Insert(0, "");
                }
            }
        }

            
        /// <summary>
        /// 水印位置
        /// </summary>
        public enum WaterMarkPosition
        {
            /// <summary>
            /// 左上
            /// </summary>
            TOP_LEFT = 0x00,
            /// <summary>
            /// 右上
            /// </summary>
            TOP_RIGHT = 0x01,
            /// <summary>
            /// 左下
            /// </summary>
            BOTTOM_LEFT = 0x02,
            /// <summary>
            /// 右下
            /// </summary>
            BOTTOM_RIGHT = 0x03
        }

       
    }
}
