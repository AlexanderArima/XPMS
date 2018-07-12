using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCYN.Common;
using XPMS.Model;

namespace XPMS.BLL.Hotel
{
    public class RoomType
    {
        static DAL.RoomType _dal = new DAL.RoomType();

        public List<T_RoomType> GetAll()
        {
            var obj = CacheHelper.Get<List<T_RoomType>>("RoomType/GetAll");
            if (obj == null)
            {
                obj = _dal.GetAll();
            }
            return obj;

        }

        public bool Insert(T_RoomType obj)
        {
            if(_dal.Insert(obj))
            {
                this.GetAll();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
