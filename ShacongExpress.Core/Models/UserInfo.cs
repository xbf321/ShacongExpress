using System;

namespace ShacongExpress.Models
{
    public class UserInfo
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public string CompanyName { get; set; }
        public string Mobile { get; set; }
        public UserType UserType { get; set; }
        public string OpenId { get; set; }
        public string AuthCode { get; set; }
        public bool Status { get; set; }
        public DateTime AuthDateTime { get; set; }
        public DateTime CreateDateTime { get; set; }
    }
}
