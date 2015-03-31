using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace PrimeiraSerieSolution
{
    class ArithmeticPipeline
    {
        private readonly List<IArrayOperation> _ops;

        public List<IArrayOperation> Operations
        {
            get { return _ops; }
        }

        public ArithmeticPipeline()
        {
            _ops = new List<IArrayOperation>();
        }

        public ArithmeticPipeline(List<IArrayOperation> list)
        {
            _ops = list;
        }

        public void Add(IArrayOperation op)
        {
             _ops.Add(op);
        }

        public void ExecuteAll(double[] startArray)
        {
            foreach (var op in _ops)
            {
                op.Execute(startArray);
            }
        }

        
        ///<summary> Retorna um novo ArithmeticPipeline com as operações obtidas a partir de loader.</summary>
        public static ArithmeticPipeline LoadPipeline(ILoader loader)
        {
            return new ArithmeticPipeline(loader.LoadOperations());
        }
    }
}
