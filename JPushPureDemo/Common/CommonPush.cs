using cn.jpush.api;
using cn.jpush.api.common;
using cn.jpush.api.common.resp;
using cn.jpush.api.push.mode;
using cn.jpush.api.push.notification;
using cn.jpush.api.schedule;
using System;
using System.Configuration;

namespace JPushPureDemo.Common
{

    public static class CommonPush
    {
        static string app_key = ConfigurationManager.AppSettings["JPush_app_key"];
        static string master_secret = ConfigurationManager.AppSettings["JPush_master_secret"];

        /// <summary>
        /// 执行普通的推送方法
        /// </summary>
        /// <param name="audiences">推送对象的集合</param>
        /// <param name="message">推送消息内容</param>
        public static void PushMessage(string[] audiences, string message)
        {
            JPushClient client = new JPushClient(app_key, master_secret);
            PushPayload payload;
            payload = PushObject_All_All_Alert_Tag(audiences, message);
            try
            {
                var result = client.SendPush(payload);
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine(result);
            }
            catch (APIRequestException e)
            {
                Console.WriteLine("Error response from JPush server. Should review and fix it. ");
                Console.WriteLine("HTTP Status: " + e.Status);
                Console.WriteLine("Error Code: " + e.ErrorCode);
                Console.WriteLine("Error Message: " + e.ErrorCode);
            }
            catch (APIConnectionException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// 普通推送的平台设置
        /// </summary>
        /// <param name="audiences"></param>
        /// <param name="strALERT"></param>
        /// <returns></returns>
        private static PushPayload PushObject_All_All_Alert_Tag(string[] audiences, string strALERT)
        {
            PushPayload pushPayload = new PushPayload();
            pushPayload.platform = Platform.all();       //所有平台
          //  pushPayload.platform = Platform.android_ios();      //安卓IOS平台

            pushPayload.audience = Audience.s_alias(audiences);  //推送给指定的别名用户

            //pushPayload.audience = Audience.all();         //推送所有用户

            var notification = new Notification().setAlert(strALERT);   //通知内容。
            notification.IosNotification = new IosNotification().setSound("default");
            pushPayload.notification = notification;
            return pushPayload;
        }
        /// <summary>
        /// 定时推送的功能
        /// </summary>
        public static void PushSchedule()
        {
            string START = "2016-12-21 12:30:00";
            string END = "2016-12-24 12:30:00";
            string TIME_UNIT = "WEEK";             //时间单位
            string TIME_PERIODICAL = "17:00:00";   //推送的时间点
            int FREQUENCY = 1;
            string NAME = "Test";                  //推送的内容
            bool ENABLED = true;
            string[] POINT = new String[] { "WED", "FRI" };

            //init a pushpayload
            PushPayload pushPayload = new PushPayload();
            pushPayload.platform = Platform.all();
            pushPayload.audience = Audience.all();
            pushPayload.notification = new Notification().setAlert(NAME);

            ScheduleClient scheduleclient = new ScheduleClient(app_key, master_secret);

            //init a TriggerPayload
            TriggerPayload triggerConstructor = new TriggerPayload(START, END, TIME_PERIODICAL, TIME_UNIT, FREQUENCY, POINT);
            //init a SchedulePayload
            SchedulePayload schedulepayloadperiodical = new SchedulePayload(NAME, ENABLED, triggerConstructor, pushPayload);

            try
            {
                var result = scheduleclient.sendSchedule(schedulepayloadperiodical);
                Console.WriteLine(result);
            }
            catch (APIRequestException e)
            {
                Console.WriteLine("Error response from JPush server. Should review and fix it. ");
                Console.WriteLine("HTTP Status: " + e.Status);
                Console.WriteLine("Error Code: " + e.ErrorCode);
                Console.WriteLine("Error Message: " + e.ErrorMessage);
            }
            catch (APIConnectionException e)
            {
                Console.WriteLine();
            }
        }
    }
}