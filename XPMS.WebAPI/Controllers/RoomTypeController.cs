using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XPMS.BLL.Hotel;
using XPMS.Model;

namespace XPMS.WebAPI.Controllers
{
    public class RoomTypeController : ApiController
    {
        static RoomType _bll = new RoomType();
        // GET: api/RoomType
        public string GetAll()
        {
            ServiceObject obj = new ServiceObject();
            try
            {
                var list = _bll.GetAll();
                obj.Obj = list;
            }
            catch(Exception ex)
            {
                obj.State = ServiceState.error;
                obj.Msg = ex.Message;
            }
            return JsonConvert.SerializeObject(obj);
        }

        // GET: api/RoomType/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RoomType
        public void Post([FromBody]T_RoomType room)
        {
            ServiceObject obj = new ServiceObject();
            try
            {
                if(!_bll.Insert(room))
                {
                    obj.State = ServiceState.error;
                    obj.Msg = "未能插入数据";
                }
            }
            catch (Exception ex)
            {
                obj.State = ServiceState.error;
                obj.Msg = ex.Message;
            }
        }

        // PUT: api/RoomType/5
        public void Put(int id, [FromBody]T_RoomType value)
        {

        }

        // DELETE: api/RoomType/5
        public void Delete(int id)
        {
        }
    }
}
