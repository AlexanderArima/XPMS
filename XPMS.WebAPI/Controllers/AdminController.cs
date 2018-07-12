using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XPMS.BLL.Admin;
using XPMS.Model;

namespace XPMS.WebAPI.Controllers
{
    public class AdminController : ApiController
    {
        static Admin _admin = new Admin();
        // GET: api/Admin
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        
        /// <summary>
        /// 管理员登录
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Password"></param>
        /// <param name="IsLock"></param>
        /// <param name="LockTime"></param>
        /// <returns></returns>
        public string Get(string Name,string Password,int IsLock = 0,DateTime LockTime = new DateTime())
        {
            ServiceObject obj = new ServiceObject();
            try
            {
                var admin = _admin.Get(Name, Password, IsLock, LockTime);
                obj.Obj = admin;
            }
            catch(Exception ex)
            {
                obj.State = ServiceState.error;
                obj.Msg = ex.Message;
            }
            return JsonConvert.SerializeObject(obj);
        }

        /// <summary>
        /// 注册一个管理员
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Password"></param>
        public string Post(string Name, string Password)
        {
            ServiceObject obj = new ServiceObject();
            try
            {
                if(_admin.Insert(Name, Password))
                {
                    obj.State = ServiceState.success;
                }
                else
                {
                    obj.State = ServiceState.error;
                    obj.Msg = "";
                }
            }
            catch(Exception ex)
            {
                obj.State = ServiceState.error;
                obj.Msg = ex.Message;
            }
            return JsonConvert.SerializeObject(obj);
        }

        // PUT: api/Admin/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Admin/5
        public void Delete(int id)
        {
        }
    }
}
