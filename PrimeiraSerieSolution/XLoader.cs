using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PrimeiraSerieSolution
{
    class XLoader : ILoader
    {
        private static XLoader _theLoadingOne;
        private readonly List<IArrayOperation> _allOps; 

        public static XLoader Instance
        {
           get { return _theLoadingOne ?? (_theLoadingOne = new XLoader()); }
        }

        private XLoader()
        {
            _allOps = new List<IArrayOperation>();
        }

        public static List<IArrayOperation> Load(String assemblySimpleName)
        {
            Assembly assembly = Assembly.Load(assemblySimpleName);
            foreach (Type eachType in assembly.GetTypes())
            {
                //verificacao pode ser feita de outra forma..
                /*if (eachType)
                //if (obj is IArrayOperation)
                {
                    var obj = Activator.CreateInstance(eachType, null);
                    Instance._allOps.Add((IArrayOperation) obj);
                }*/
            }
            return Instance._allOps;
        }

        public List<IArrayOperation> LoadOperations()
        {
            return _allOps;
        }
    }
}
