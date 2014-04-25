using System.Web.Mvc;

using ShacongExpress.Models;
using ShacongExpress.Service;

namespace ShacongExpress.Web.WX.Areas.Passport.Controllers
{
    public class ShipperController : Controller
    {
        #region == 注册用户基本信息 ==
        //
        // GET: /Passport/Shipper/Register
        //注册
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(FormCollection fc) {

            //TOTO
            //待加入验证功能

            var userName = fc["txtUserName"];
            var userPassword = fc["txtUserPassword"];
            var companyName = fc["txtCompanyName"];
            var mobile = fc["txtMobile"];

            if(UserService.ValidateUserName(userName)){
                ViewBag.Msg = "用户名已存在！";
                return View();
            }

            var userModel = new UserInfo() { 
                UserName = userName,
                UserPassword = userPassword,
                CompanyName = companyName,
                Mobile = mobile,
                UserType = UserType.Shipper
            }; 
            //插入
            int i = UserService.Create(userModel).Id;
            if(i > 0){
                //写入Cookie

                //跳转到注册成功页面
                return RedirectToAction("Register_Success");
            }
            return View();
        }
        #endregion

        /// <summary>
        /// 注册成功
        /// </summary>
        /// <returns></returns>
        public ActionResult Register_Success() {
            return View();
        }


        #region == 认证 ==
        /// <summary>
        /// 认证
        /// </summary>
        /// <returns></returns>
        public ActionResult Auth() {
            return View();
        }
        [HttpPost]
        public ActionResult Auth(FormCollection fc) {
            var companyAddress = fc["txtCompanyAddress"];
            var zip = fc["txtZip"];
            var model = new ShipperInfo() { 
                Id = 1,
                CompanyAddress = companyAddress,
                Zip = zip
            };
            if(UserService.AuthShipper(model)){
                //转向认证成功页
                return RedirectToAction("Auth_Success");
            }
            return View();
        }
        #endregion

        /// <summary>
        /// 认证成功
        /// </summary>
        public ActionResult Auth_Success() { 
            return View();
        }

    }
}
