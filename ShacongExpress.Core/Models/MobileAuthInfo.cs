using System;

namespace ShacongExpress.Models
{
    /// <summary>
    /// 手机验证
    /// </summary>
    public class MobileAuthInfo
    {
        public int Id { get; set; }
        public string Mobile { get; set; }
        /// <summary>
        /// 验证码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 验证码发送时间
        /// </summary>
        public DateTime SendDateTime { get; set; }
        /// <summary>
        /// 验证时间
        /// </summary>
        public DateTime AuthDateTime { get; set; }
        /// <summary>
        /// 是否验证通过
        /// </summary>
        public bool Status { get; set; }
    }
}
