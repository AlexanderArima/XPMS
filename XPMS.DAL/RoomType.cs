using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPMS.Model;

namespace XPMS.DAL
{
    public class RoomType
    {
        /// <summary>
        /// 取出所有的房间类型
        /// </summary>
        /// <returns></returns>
        public List<T_RoomType> GetAll()
        {
            using (XPMSEntities db = new XPMSEntities())
            {
                var query = from a in db.T_RoomType
                            where a.IsDelete == true
                            select a;
                var type = query.ToList().GetType();
                return query.ToList();
            }
        }
        
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Insert(T_RoomType obj)
        {
            using (XPMSEntities db = new XPMSEntities())
            {
                var query = from a in db.T_RoomType
                            where a.Name.Equals(obj.Name)
                            select a;
                if(query.Count() > 0)
                {
                    throw new Exception("该名称已存在");
                }
                var model = db.T_RoomType.Add(obj);
                if(model == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        
    }
}
