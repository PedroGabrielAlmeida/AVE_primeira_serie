using System;
using System.Collections.Generic;
using PipeMath;

namespace PipeMath
{
    public sealed class ArithmeticPipeline
    {
        private readonly List<IArrayOperation> _ops;
        
        public ArithmeticPipeline()
        {
            _ops = new List<IArrayOperation>();
        }

        public ArithmeticPipeline(List<IArrayOperation> list)
        {
            _ops = list;
        }

        public List<IArrayOperation> Operations
        {
            get { return _ops; }
        }

        public void ExecuteAll(double[] startArray) 
        {
            foreach (var op in _ops) op.Execute(startArray);
        }

        ///<summary> Retorna um novo ArithmeticPipeline com as operações obtidas a partir de loader.</summary>
        public static ArithmeticPipeline LoadPipeline(Loader loader)
        {

            return new ArithmeticPipeline(loader.LoadOperations());
        }

        public int Count
        {
            get { return _ops.Count; }
        }
    }

}
