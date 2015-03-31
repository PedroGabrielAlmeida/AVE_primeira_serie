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

        //public static List<IArrayOperation> Load(String assemblySimpleName)
        public static List<IArrayOperation> Load(params String[] assemblySimpleName)
        {
            Assembly assembly = Assembly.Load(assemblySimpleName[0]); //Hardcoded yet =s
            Type[] types = assembly.GetTypes();
            for(int i = 1; i < types.Length; i += 2)
            {
                Object obj = Activator.CreateInstance(types[i], null);
                if(typeof(IArrayOperation).IsSubclassOf(obj.GetType()))
                {
                    Instance._allOps.Add((IArrayOperation)obj);
                }
            }
            return Instance._allOps;
        }

        public List<IArrayOperation> LoadOperations()
        {
            return _allOps;
        }
    }
}
