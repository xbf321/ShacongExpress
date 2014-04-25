
namespace ShacongExpress.Models
{
    public class SearchSetting
    {
       
        /// <summary>
        /// 必填
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 必填，默认10
        /// </summary>
        public int PageSize { get; set; }      

        public SearchSetting()
        {
            PageIndex = 1;
            PageSize = 10;
        } 
    }
    public class UserSearchSetting : SearchSetting {
    }
}
