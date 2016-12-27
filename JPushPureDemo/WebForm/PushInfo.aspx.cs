//using cn.jpush.api;
//using cn.jpush.api.common;
//using cn.jpush.api.common.resp;
//using cn.jpush.api.push.mode;
//using cn.jpush.api.push.notification;
using System;
//using System.Configuration;

namespace JPushPureDemo.WebForm
{
    public partial class PushInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btn_Push_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_alias.Text))
            {
                string temp = txt_alias.Text.Replace('，', ',');
                string[] audiences = txt_alias.Text.Split(',');
                string Message = string.IsNullOrEmpty(txt_message1.Text.Trim()) ? "普通推送内容。" : txt_message1.Text.Trim();
                Common.CommonPush.PushMessage(audiences, Message);
            }
        }

        protected void btn_Push2_Click(object sender, EventArgs e)
        {
            string temp = txt_alias2.Text.Replace('，', ',');
            string[] audiences = txt_alias2.Text.Split(',');
            string Message = string.IsNullOrEmpty(txt_message2.Text.Trim()) ? "定时推送内容。" : txt_message2.Text.Trim();
            Common.CommonPush.PushSchedule();
        }
    }
}