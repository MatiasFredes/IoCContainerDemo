using System;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace IoCContainer.Container
{
    public class Resolver
    {
        private IDictionary<Type, Type> dependencyMap = new Dictionary<Type, Type>();

        public Resolver()
        {

        }

        public T Resolve<T>()
        {
            return (T)Resolve(typeof(T));
        }

        private object Resolve(Type type)
        {
            Type resolvedType = null;
            try
            {
                resolvedType = dependencyMap[type];
                ConstructorInfo constructor = resolvedType.GetConstructors()[0];
                ParameterInfo[] parametersOfConstructor = constructor.GetParameters();
                if (parametersOfConstructor.Length == 0)
                    return Activator.CreateInstance(resolvedType);

                IList<object> parameters = new List<object>();

                foreach (ParameterInfo parameter in parametersOfConstructor)
                {
                    parameters.Add(Resolve(parameter.ParameterType));
                }
                return constructor.Invoke(parameters.ToArray());
            }
            catch
            {
                throw new Exception(string.Format("the type {0} can not be solved", resolvedType.FullName));
            }
        }

        public void Register<T1, T2>()
        {
            this.dependencyMap.Add(typeof(T1), typeof(T2));

        }
    }
}