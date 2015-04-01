using System;
using System.Collections.Generic;
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
            foreach (string assemblyName in assemblySimpleName)
            {
                //Load the assembly
                Assembly assembly = Assembly.Load(assemblyName);
                //for each type check if it implements the IArrayOperation interface..
                Type[] types = assembly.GetTypes();
                foreach (Type type in types)
                {
                    if (typeof (IArrayOperation).IsAssignableFrom(type))
                    {
                        //if so, create an instance in order to add the new operation to the list
                        Object obj = Activator.CreateInstance(type, null); //TODO  !!!! este ctor não vai funcionar para todos os assemblies
                        Instance._allOps.Add((IArrayOperation)obj);
                    }
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
