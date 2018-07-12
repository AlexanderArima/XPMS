using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XPMS.Model
{
    public class ServiceObject
    {
        public ServiceObject()
        {
            this.Obj = null;
            this.State = ServiceState.success;
            this.Msg = "";
        }

        public object Obj { get; set; }
        public ServiceState State { get; set; }
        public string Msg { get; set; }
    }

    public enum ServiceState
    {
        error = 0,
        success = 1
    }
}
