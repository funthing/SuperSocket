using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperSocket.CustomerException
{
    /// <summary>
    /// Socket初始化异常
    /// </summary>
    [Serializable]
    public class InitializationException:ApplicationException
    {
        /// <summary>
        /// 默认构造函数
        /// </summary>
        public InitializationException() { }

        //base：在子类中调用父类相同参数的构造函数（不能直接调用，所以用base修饰）
        public InitializationException(string message) : base(message) { }

        public InitializationException(string message, Exception inner) : base(message, inner) { }

        public InitializationException(System.Runtime.Serialization.SerializationInfo info,System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
