using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XCYN.Common;
using XPMS.Common;
using XPMS.Model;

namespace XPMS.DAL
{
    public class Admin
    {

        /// <summary>
        /// 管理员登录
        /// </summary>
        public Model.T_Admin Get(string Name,string Password)
        {
            using (XPMSEntities db = new XPMSEntities())
            {
                var query = from a in db.T_Admin
                            where a.Name.Equals(Name)
                            select a;
                if(query.Count() > 0)
                {
                    var salt = query.FirstOrDefault().Salt;
                    Password = DESEncrypt.Encrypt(Password, salt);
                    var query2 = from a in db.T_Admin
                                 where a.Name.Equals(Name) && a.Password.Equals(Password)
                                 select a;
                    if(query2.Count() > 0)
                    {
                        return query2.FirstOrDefault();
                    }
                    else
                    {
                        throw new Exception("密码错误");
                    }
                }
                throw new Exception("该用户名不存在");
            }
        }

        /// <summary>
        /// 管理员注册
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="Password"></param>
        public bool Insert(string Name,string Password)
        {
            using (XPMSEntities db = new XPMSEntities())
            {
                var query = from a in db.T_Admin
                            where a.Name.Equals(Name)
                            select a;
                if(query.Count() > 0)
                {
                    //1.判断唯一性
                    throw new Exception("用户名已存在");
                }
                else
                {
                    //2.插入数据
                    var salt = Utils.Number(4);
                    T_Admin obj = new T_Admin()
                    {
                        Name = Name,
                        Password = DESEncrypt.Encrypt(Password, salt),
                        Salt = salt,
                        IsDelete = false,
                        IsLock = false
                    };
                    db.T_Admin.Add(obj);
                    return true;
                }
            }
        }
    }
}
