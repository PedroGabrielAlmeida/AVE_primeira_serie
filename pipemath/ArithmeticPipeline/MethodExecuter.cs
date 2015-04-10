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
        private MethodInfo info; 
        private Type type;

        public MethodExecuter(MethodInfo info, Type type)
        {
            this.info=info;
            this.type=type;
        }

        public void Execute(double[] values)
        {
          //  info.Invoke(Activator.CreateInstance(type),v);
        }

    }
}
