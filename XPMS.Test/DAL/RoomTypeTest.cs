using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using XPMS.DAL;
using XPMS.Model;

namespace XPMS.Test.DAL
{
    [TestClass]
    public class RoomTypeTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            RoomType room = new RoomType();
            var list = room.GetAll<T_RoomType>();
        }
    }
}
