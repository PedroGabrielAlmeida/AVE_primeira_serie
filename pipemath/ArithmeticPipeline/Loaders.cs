using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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
            //for each type check if it implements the IArrayOperation interface..
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                if (typeof(IArrayOperation).IsAssignableFrom(type))
                {
                    //if so, create an instance in order to add the new operation to the list
                    Object obj = Activator.CreateInstance(type, null); 
                    _allOps.Add((IArrayOperation)obj);
                }
            }
        }
    }

    public class LoaderOfMethods : Loader
    {
        public LoaderOfMethods(String file)
        {
            throw new NotImplementedException();
        }

        public List<IArrayOperation> LoadOperations()
        {
            throw new NotImplementedException();
        }
    }

}
