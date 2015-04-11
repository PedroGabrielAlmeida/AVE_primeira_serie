using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace PipeMath
{
    class MethodExecuter : IArrayOperation
    {
        private readonly MethodInfo _methodInfo; 
        private readonly Type _methodType;

        public MethodExecuter(MethodInfo methodMethodInfo)
        {
            _methodInfo = methodMethodInfo;
            _methodType = null;
        }

        public MethodExecuter(MethodInfo methodMethodInfo, Type methodType)
        {
            _methodInfo=methodMethodInfo;
            _methodType=methodType;
        }

        public void Execute(double[] values)
        {
            _methodInfo.Invoke(Activator.CreateInstance(_methodType), new object[]{values});
        }

    }
}
