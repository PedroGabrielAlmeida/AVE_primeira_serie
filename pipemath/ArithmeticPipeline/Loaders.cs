using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using PipeMath;

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
            LoadMethods(assembly.GetExportedTypes());

        }

        private void LoadMethods(Type[] exportedTypes)
        {
            //Execute's info
            MethodInfo executeMethodInfo = typeof (IArrayOperation).GetMethod("Execute");
            ParameterInfo[] executeParameters = executeMethodInfo.GetParameters();
            foreach (Type type in exportedTypes)
            {
                MethodInfo[] methodInfos = type.GetMethods();
                foreach (var methodInfo in methodInfos)
                {
                    if (IsMethodInfoValid(executeMethodInfo, methodInfo))
                    {
                        _allOps.Add(methodInfo.IsStatic
                            ? new MethodExecuter(methodInfo)
                            : new MethodExecuter(methodInfo, type));
                    }
                }
            }
        }

        private bool IsMethodInfoValid(MethodInfo executeInfo, MethodInfo methodInfo)
        {
            //tipo de retorno
            if (executeInfo.ReturnType != methodInfo.ReturnType) return false;
 
            //tipos de parametro
            ParameterInfo[] methodsParams = methodInfo.GetParameters(),
                            executesParams = executeInfo.GetParameters();
            if (methodsParams.Length != executesParams.Length) return false;
            for (int i = 0; i < methodsParams.Length; i++)
            {
                //reference equality
                if (!(methodsParams[i].ParameterType == executesParams[i].ParameterType)) return false;
            }
            return true;
        }

        public List<IArrayOperation> LoadOperations()
        {
            return _allOps;
        }
    }

}
