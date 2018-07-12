using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XPMS.Model;

namespace XPMS.BLL.Admin
{
    public class Admin
    {
        static DAL.Admin _admin = new DAL.Admin();

        public T_Admin Get(string Name,string Password,int IsLock,DateTime LockTime)
        {
            if (IsLock == 0)
            {
                //未被锁定
                return _admin.Get(Name, Password);
            }
            else if(IsLock == 1 && (DateTime.Now - LockTime).Minutes > 30)
            {
                //已被锁定，但锁定时间过期
                return _admin.Get(Name, Password);
            }
            else if(Name.Length <= 0 && Password.Length <= 0)
            {
                throw new Exception("用户名或密码不能空");
            }
            else
            {
                throw new Exception(string.Format("账号已被锁定，请等待{0}分钟再试", (DateTime.Now - LockTime).Minutes));
            }
        }
   
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Password"></param>
        /// <returns></returns>
        public bool Insert(string Name,string Password)
        {
            if(Name.Length <= 0)
            {
                throw new ArgumentException("用户名不能为空");
            }
            if(Password.Length <= 0)
            {
                throw new ArgumentException("密码不能为空");
            }
            var flag = _admin.Insert(Name, Password);
            if (flag)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
