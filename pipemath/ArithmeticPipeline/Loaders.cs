using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PipeMath
{

    public interface Loader
    {
        List<IArrayOperation> LoadOperations();
    }

    public class LoaderOfTypes : Loader
    {
        private readonly List<IArrayOperation> _allOps;

        public List<IArrayOperation> LoadOperations()
        {
            return _allOps;
        }

        public LoaderOfTypes(String file)
        {
            _allOps = new List<IArrayOperation>();
            Assembly assembly = Assembly.Load(file);
            
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (typeof(IArrayOperation).IsAssignableFrom(type))
                {
                    Object obj = Activator.CreateInstance(type, null); 
                    _allOps.Add((IArrayOperation)obj);
                }
            }
        }
    }

    public class LoaderOfMethods : Loader
    {
        private readonly List<IArrayOperation> _allOps;

        public LoaderOfMethods(String file)
        {
            _allOps = new List<IArrayOperation>();
            Assembly assembly = Assembly.Load(file);
            
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                MethodInfo[] methodInfos = type.GetMethods(BindingFlags.Public | BindingFlags.Static);
                foreach (var methodInfo in methodInfos)
                {
                    //...
                }
            }
        }

        public List<IArrayOperation> LoadOperations()
        {
            return _allOps;
        }
    }

}
