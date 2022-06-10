using System;
using System.Collections.Generic;

namespace FrameworkDesign
{
    /// <summary>
    /// 容器，本质为一个字典，为了获取字典的值--对象
    /// </summary>
    public class IOCContainer 
    {
        /// <summary>
        /// 实例
        /// </summary>
        Dictionary<Type, object> mInstance = new Dictionary<Type, object>();

        /// <summary>
        /// 注册
        /// </summary>
        public void Register<T>(T instance)
        {
            var key = typeof(T);
            if(mInstance.ContainsKey(key))
            {
                mInstance[key] = instance;
            }
            else
            {
                mInstance.Add(key,instance);
            }    
        }

        /// <summary>
        /// 获取
        /// </summary>
        public T Get<T>() where T:class
        {
            var key = typeof(T);

            if(mInstance.TryGetValue(key,out var retInstance))
            {
                return retInstance as T;
            }

            return null;
            
        }
    }

}
