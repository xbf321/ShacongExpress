
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
            }
            else { 
                //Update
                UserManage.Update(model);
            }
            return model;
        }
    }
}
