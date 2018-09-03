using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOP2
{ 
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Interface|AttributeTargets.Method, Inherited = true)]
    public class AopLogAttribute : Attribute
    {
        /// <summary>
        /// 超时时间
        /// </summary> 
        public int Timeout { get; set; }
        
        public AopLogAttribute()
        {
            Timeout = 60;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.Method, Inherited = true)]
    public class SafeExecAttribute : Attribute
    {
        /// <summary>
        /// 超时时间
        /// </summary> 
        public int Timeout { get; set; } 

        public SafeExecAttribute()
        {
            Timeout = 60;
        }
    }


}
