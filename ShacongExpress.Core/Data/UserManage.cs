using System;
using System.Data;
using System.Data.SqlClient;


using ShacongExpress.Models;

namespace ShacongExpress.Data
{
    public static class UserManage
    {
        #region == 插入 ==
        public static int Insert(UserInfo model) {
            string strSQL = "INSERT INTO [User](UserName,UserPwd,CompanyName,UserType,MobileTelephone,Auditing,CreateDate,WeiXinID) VALUES(@UserName,@UserPwd,@CompanyName,@UserType,@MobileTelephone,@Auditing,GETDATE(),@WeiXinID);SELECT @@IDENTITY;";
            SqlParameter[] parms = { 
                                    new SqlParameter("Id",SqlDbType.Int),
                                    new SqlParameter("UserName",SqlDbType.NVarChar),
                                    new SqlParameter("UserPwd",SqlDbType.NVarChar),
                                    new SqlParameter("CompanyName",SqlDbType.NVarChar),
                                    new SqlParameter("UserType",SqlDbType.Int),
                                    new SqlParameter("MobileTelephone",SqlDbType.NVarChar),
                                    new SqlParameter("Auditing",SqlDbType.NVarChar),
                                    new SqlParameter("WeixinID",SqlDbType.NVarChar)
                                   };
            parms[0].Value = model.Id;
            //未完待续...
            return Convert.ToInt32(Goodspeed.Library.Data.SQLPlus.ExecuteScalar(CommandType.Text, strSQL, parms));
        }
        #endregion

        #region == 更新 ==
        public static int Update(UserInfo model) {
            string strSQL = "UPDATE [User] SET CompanyName = @CompanyName WHERE Id = @ID";
            SqlParameter[] parms = { 
                                    new SqlParameter("Id",SqlDbType.Int),
                                    new SqlParameter("CompanyName",SqlDbType.NVarChar),
                                   };
            return Goodspeed.Library.Data.SQLPlus.ExecuteNonQuery(CommandType.Text,strSQL,parms);
        }
        #endregion
    }
}
