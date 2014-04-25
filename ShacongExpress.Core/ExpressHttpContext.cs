using System;
using System.Web;

using ShacongExpress.Models;
using ShacongExpress.Common;

namespace ShacongExpress
{
    /// <summary>
    /// 上下文
    /// </summary>
    public sealed class ExpressHttpContext
    {
        static ExpressHttpContext instance = new ExpressHttpContext();

        static ExpressHttpContext() { }

        ExpressHttpContext()
        {
            //初始化
            this.CookieName = System.Configuration.ConfigurationManager.AppSettings["LoginCookieName"];
            this.CookieExpires = Utils.StrToInt
(System.Configuration.ConfigurationManager.AppSettings["LoginCookieExpires"], 60);
            this.CookieDomain = System.Configuration.ConfigurationManager.AppSettings["LoginCookieDomain"];
            this.DESKey = System.Configuration.ConfigurationManager.AppSettings["DESKey"];
        }

        public static ExpressHttpContext Current { get { return instance; } }


        #region == Cookie 配置信息 ==
        public string CookieName { get; private set; }
        public string CookieDomain { get; private set; }
        public int CookieExpires { get; private set; }
        public string DESKey { get; private set; }

        #endregion

        #region == 用户相关 ==

        /// <summary>
        /// 前台是否登录
        /// </summary>
        public bool IsLogin
        {
            get
            {
                var cookieArray = _GetCookie(this.CookieName);
                if (cookieArray.Length == 4)
                {
                    int userId = TypeConverter.StrToInt(cookieArray[0]);
                    if (userId > 0)
                    {
                        return true;
                    }
                }
                return false;
            }
        }
        /// <summary>
        /// 前台用户登录信息
        /// </summary>
        public UserInfo LoginUserInfo
        {
            get
            {
                UserInfo userInfo = new UserInfo();
                var cookieArray = _GetCookie(this.CookieName);
                if (cookieArray.Length == 4)
                {
                    int userId = TypeConverter.StrToInt(cookieArray[0]);
                    if (userId > 0)
                    {

                        userInfo.UserName = cookieArray[1];
                        userInfo.Id = userId;
                    }
                }
                return userInfo;
            }
        }

        #endregion

        #region == Logout ==
        /// <summary>
        /// 用户登录
        /// </summary>
        public void Logout()
        {
            _Logout(this.CookieName);
        }
        private void _Logout(string cookieName)
        {
            System.Web.HttpContext.Current.Response.Cookies.Add(new HttpCookie(cookieName) { Expires = DateTime.Now.AddYears(-1), Domain = this.CookieDomain });
        }
        #endregion

        #region == 写Cookie信息 ==
        /// <summary>
        /// 写Cookie信息，后台和前台通用
        /// </summary>
        /// <param name="cookieName"></param>
        /// <param name="userInfo"></param>
        public void LoginEvent(string cookieName, UserInfo userInfo)
        {
            //登陆
            //正确，开始写Cookie                            
            //Cookie格式Id|UserName|Password|DateTime.Now
            string cookieValue = string.Format("{0}|{1}|{2}|{3}",
                userInfo.Id,
                userInfo.UserName,
                userInfo.UserPassword,
                DateTime.Now);

            //添加到浏览器中
            //Cookie加密
            string cv = Goodspeed.Library.Security.DESCryptography.Encrypt(cookieValue, DESKey);
            System.Web.HttpContext.Current.Response.Cookies.Add(new HttpCookie(cookieName, cv) { Expires = DateTime.Now.AddMinutes(this.CookieExpires), Domain = CookieDomain });
        }
        #endregion

        #region == 获取Cookie信息 ==
        private string[] _GetCookie(string cookieName)
        {
            string[] s = { };
            string cookieKey = cookieName;
            string desKey = this.DESKey;
            if (System.Web.HttpContext.Current.Request.Cookies[cookieKey] != null)
            {
                HttpCookie aCookie = System.Web.HttpContext.Current.Request.Cookies[cookieKey];
                if (!string.IsNullOrEmpty(aCookie.Value))
                {
                    try
                    {
                        string cookieValue = Goodspeed.Library.Security.DESCryptography.Decrypt(aCookie.Value, desKey);
                        return cookieValue.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                    }
                    catch
                    {
                        return s;
                    }
                }
            }
            return s;
        }
        #endregion
    }
}
