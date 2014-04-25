using System;
using System.Data;
using System.Data.SqlClient;


using ShacongExpress.Models;
using ShacongExpress.Common;
using System.Collections.Generic;

namespace ShacongExpress.Data
{
    public static class UserManage
    {
        #region == 插入通用用户 ==
        public static int Insert(UserInfo model) {
            string strSQL = "INSERT INTO [Users](UserName,UserPassword,CompanyName,UserType,Mobile) VALUES(@UserName,@UserPassword,@CompanyName,@UserType,@Mobile);SELECT @@IDENTITY;";
            SqlParameter[] parms = { 
                                    new SqlParameter("Id",SqlDbType.Int),
                                    new SqlParameter("UserName",SqlDbType.NVarChar),
                                    new SqlParameter("UserPassword",SqlDbType.NVarChar),
                                    new SqlParameter("CompanyName",SqlDbType.NVarChar),
                                    new SqlParameter("UserType",SqlDbType.Int),
                                    new SqlParameter("Mobile",SqlDbType.NVarChar)
                                   };
            parms[0].Value = model.Id;
            parms[1].Value = model.UserName;
            parms[2].Value = model.UserPassword;
            parms[3].Value = model.CompanyName;
            parms[4].Value = (int)model.UserType;
            parms[5].Value = model.Mobile;

            return Convert.ToInt32(Goodspeed.Library.Data.SQLPlus.ExecuteScalar(CommandType.Text, strSQL, parms));
        }
        #endregion

        #region == 
        public static bool ValidateUserName(string userName) {
            string strSQL = "SELECT COUNT(*) FROM Users WITH(NOLOCK) WHERE UserName = @UserName";
            SqlParameter parm = new SqlParameter("UserName",userName);
            return Convert.ToInt32(Goodspeed.Library.Data.SQLPlus.ExecuteScalar(CommandType.Text,strSQL,parm)) > 0;
        }
        #endregion

        #region == 更新通用用户 ==
        public static int Update(UserInfo model) {
            string strSQL = "UPDATE [User] SET CompanyName = @CompanyName WHERE Id = @ID";
            SqlParameter[] parms = { 
                                    new SqlParameter("Id",SqlDbType.Int),
                                    new SqlParameter("CompanyName",SqlDbType.NVarChar),
                                   };
            return Goodspeed.Library.Data.SQLPlus.ExecuteNonQuery(CommandType.Text,strSQL,parms);
        }
        #endregion

        #region == 初始化货主信息 ==
        public static void InitShipper(int userId) {
            string strSQL = "INSERT INTO Shipper(UserId) VALUES(@UserId)";
            SqlParameter parm = new SqlParameter("@UserId",userId);
            Goodspeed.Library.Data.SQLPlus.ExecuteNonQuery(CommandType.Text,strSQL,parm);
        }
        #endregion

        #region == 更新货主信息 ==
        public static bool UpdateShipper(ShipperInfo model) {
            string strSQL = "UPDATE Shipper SET CompanyAddress = @CompanyAddress,Zip = @Zip,[Address] = @Address,RegisteredNumber = @RegisteredNumber,RegisteredCapital = @RegisteredCapital,Scope = @Scope,Code = @Code,RealName = @RealName,OperatingRealName = @OperatingRealName,OperatingPosition = OperatingPosition,OperatingIDNumber = @OperatingIDNumber WHERE UserId = @UserId";
            SqlParameter[] parms = { 
                                    new SqlParameter("UserId",SqlDbType.Int),
                                    new SqlParameter("CompanyAddress",SqlDbType.NVarChar),
                                    new SqlParameter("Zip",SqlDbType.NVarChar),
                                    new SqlParameter("Address",SqlDbType.NVarChar),
                                    new SqlParameter("RegisteredNumber",SqlDbType.NVarChar),
                                    new SqlParameter("RegisteredCapital",SqlDbType.NVarChar),
                                    new SqlParameter("Scope",SqlDbType.NVarChar),
                                    new SqlParameter("RealName",SqlDbType.NVarChar),
                                    new SqlParameter("OperatingRealName",SqlDbType.NVarChar),
                                    new SqlParameter("OperatingPosition",SqlDbType.NVarChar),
                                    new SqlParameter("OperatingIDNumber",SqlDbType.NVarChar),
                                    new SqlParameter("Code",SqlDbType.NVarChar),
                                   };
            parms[0].Value = model.Id;
            parms[1].Value = model.CompanyAddress ?? string.Empty;
            parms[2].Value = model.Zip ?? string.Empty;
            parms[3].Value = model.Address ?? string.Empty;
            parms[4].Value = model.RegisteredNumber ?? string.Empty;
            parms[5].Value = model.RegisteredCapital ?? string.Empty;
            parms[6].Value = model.Scope ?? string.Empty;
            parms[7].Value = model.RealName ?? string.Empty;
            parms[8].Value = model.OperatingRealName ?? string.Empty;
            parms[9].Value = model.OperatingPosition ?? string.Empty;
            parms[10].Value = model.OperatingIDNumber ?? string.Empty;
            parms[11].Value = model.Code ?? string.Empty;

            return Convert.ToInt32(Goodspeed.Library.Data.SQLPlus.ExecuteNonQuery(CommandType.Text,strSQL,parms)) > 0 ;
        }
        #endregion

        #region
        /// <summary>
        /// 用户基本列表
        /// </summary>
        /// <param name="setting"></param>
        /// <returns></returns>
        public static IPageOfList<UserInfo> BaseInfoList(SearchSetting setting)
        {
            FastPaging fp = new FastPaging();
            fp.PageIndex = setting.PageIndex;
            fp.PageSize = setting.PageSize;
            fp.Ascending = false;
            fp.TableName = "Users";
            fp.TableReName = "p";
            fp.PrimaryKey = "ID";
            fp.QueryFields = "p.*";
            fp.OverOrderBy = " CreateDateTime DESC";
            fp.WithOptions = " WITH(NOLOCK)";

            IList<UserInfo> list = new List<UserInfo>();
            DataTable dt = Goodspeed.Library.Data.SQLPlus.ExecuteDataTable(CommandType.Text, fp.Build2005());
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    list.Add(GetByRow(dr));
                }
            }

            int count = Convert.ToInt32(Goodspeed.Library.Data.SQLPlus.ExecuteScalar(CommandType.Text, fp.BuildCountSQL())); ;
            return new PageOfList<UserInfo>(list, setting.PageIndex, setting.PageSize, count);
        }
        #endregion

        /// <summary>
        /// 填充用户详细信息
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        private static UserInfo GetByRow(DataRow dr)
        {
            if (dr == null) { return new UserInfo(); }
            return new UserInfo()
            {
                Id = dr.Field<int>("Id"),
                UserName = dr.Field<string>("UserName"),
                UserPassword = dr.Field<string>("UserPassword"),
                CreateDateTime = dr.Field<DateTime>("CreateDateTime"),
                Mobile = dr.Field<string>("Mobile"),
                CompanyName = dr.Field<string>("CompanyName"),
                OpenId = dr.Field<string>("OpenId"),
                UserType = (UserType)Enum.Parse(typeof(UserType),dr.Field<Int16>("UserType").ToString()),
                Status = dr.Field<bool>("Status")
            };
        }
    }
}
