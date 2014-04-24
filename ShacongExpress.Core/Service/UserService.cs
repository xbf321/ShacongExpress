
using ShacongExpress.Data;
using ShacongExpress.Models;

namespace ShacongExpress.Service
{
    /// <summary>
    /// 对外统一接口
    /// </summary>
    public static class UserService
    {
        public static UserInfo Create(UserInfo model) {
            if (model.Id == 0)
            {
                //Insert
                model.Id = UserManage.Insert(model);
                if(model.UserType == UserType.Shipper){
                    UserManage.InitShipper(model.Id);
                }
            }
            else { 
                //Update
                UserManage.Update(model);
            }
            return model;
        }
        /// <summary>
        /// 货主认证
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static bool AuthShipper(ShipperInfo model) {
            return UserManage.UpdateShipper(model);
        }
    }
}
