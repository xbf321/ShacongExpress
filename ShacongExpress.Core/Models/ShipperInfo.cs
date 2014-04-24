
namespace ShacongExpress.Models
{
    public class ShipperInfo : UserInfo
    {
        /// <summary>
        /// 企业地址
        /// </summary>
        public string CompanyAddress { get; set; }
        /// <summary>
        /// 邮编
        /// </summary>
        public string Zip { get; set; }
        /// <summary>
        /// 营业执照住所地
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// 营业执照注册号
        /// </summary>
        public string RegisteredNumber { get; set; }
        /// <summary>
        /// 注册资本
        /// </summary>
        public string RegisteredCapital { get; set; }
        /// <summary>
        /// 经营范围
        /// </summary>
        public string Scope { get; set; }
        /// <summary>
        /// 组织机构代码
        /// </summary>
        public string Code { get; set; }
        /// <summary>
        /// 法定代表人姓名
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// 运营负责人姓名
        /// </summary>
        public string OperatingRealName { get; set; }
        /// <summary>
        /// 运营负责人职务
        /// </summary>
        public string OperatingPosition { get; set; }
        /// <summary>
        /// 运营者身份证号码
        /// </summary>
        public string OperatingIDNumber { get; set; }

    }
}
