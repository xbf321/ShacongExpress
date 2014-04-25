using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;

namespace ShacongExpress.Common
{
    public class SMS
    {
        #region 发送校验码
        /// <summary>
        /// 发送手机短信验证码，返回发送的验证码，在前台控制调用频率
        /// </summary>
        /// <param name="PhoneNumber">要发送的手机号</param>
        /// <param name="Msg">要发送的内容</param>
        /// <returns></returns>
        //protected static bool SendMessage(string PhoneNumber, string Msg, out string ErrorMsg)
        //{
        //    try
        //    {
        //        string url = "http://utf8.sms.webchinese.cn/?Uid=shacong&Key={0}&smsMob={1}&smsText={2}";
        //        string KEY = "rLxpuwAg4eE2OJf/e2lPVw+IiLbvaYm718dvwWb4zlE=";
        //        PubFunction.Key = "winswaywcf";
        //        string key = PubFunction.Decryp(KEY);
        //        //string msg = GetRndStr(6, true, false, false, false, "");
        //        string sendmsg = Msg;

        //        url = string.Format(url, key, PhoneNumber, sendmsg);
        //        int ret = 1;

        //        HttpWebResponse response = CreateGetHttpResponse(url, "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.1)", null, null);
        //        Stream myResponseStream = response.GetResponseStream();
        //        StreamReader myStreamReader = new StreamReader(myResponseStream, Encoding.UTF8);

        //        string text = myStreamReader.ReadToEnd();
        //        ret = int.Parse(text);//int.Parse(GetHtmlFromUrl(url, out ErrorMsg));
        //        Dictionary<int, string> msgInfo = new Dictionary<int, string>();
        //        msgInfo.Add(-1, "没有该用户账户");
        //        msgInfo.Add(-2, "密钥不正确");
        //        msgInfo.Add(-3, "短信数量不足");
        //        msgInfo.Add(-11, "该用户被禁用");
        //        msgInfo.Add(-14, "短信内容出现非法字符");
        //        msgInfo.Add(-4, "手机号格式不正确");
        //        msgInfo.Add(-41, "手机号码为空");
        //        msgInfo.Add(-42, "短信内容为空");
        //        msgInfo.Add(-51, "短信签名格式不正确");

        //        if (ret > 0)
        //        {
        //            ErrorMsg = string.Empty;
        //            return true;
        //        }
        //        else if (msgInfo.ContainsKey(ret))
        //        {
        //            ErrorMsg = "发送短信错误，错误消息：" + msgInfo[ret];
        //            return false;
        //        }
        //        else
        //        {
        //            ErrorMsg = "发送短信错误。";
        //            return false;
        //        }
        //    }
        //    catch
        //    {
        //        ErrorMsg = "发送短信错误。";
        //        return false;
        //    }
        //}
        #endregion
    }
}