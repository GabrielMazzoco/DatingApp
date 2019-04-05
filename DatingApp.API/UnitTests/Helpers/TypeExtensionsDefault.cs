using System;
using System.Collections.Generic;
using System.Linq;
using Castle.DynamicProxy.Internal;

namespace UnitTests.Helpers
{
    public static class TypeExtensionsDefault
    {
        public static void SetPropertiesToDefault<T>(T obj)
        {
            Type objectType = typeof(T);

            System.Reflection.PropertyInfo[] props = objectType.GetProperties();

            foreach (System.Reflection.PropertyInfo property in props)
            {
                if (property.CanWrite)
                {
                    Type propertyType = property.PropertyType;

                    if (propertyType.IsNullableType())
                    {
                        var generic = propertyType.GenericTypeArguments.FirstOrDefault();

                        object value = Activator.CreateInstance(generic);
                        property.SetValue(obj, value, null);
                    }
                    else if (propertyType.Name.Contains("Byte[]"))
                    {
                        object value = new byte[] { };
                        property.SetValue(obj, value, null);
                    }

                    else if (propertyType == typeof(string))
                    {
                        object value = string.Empty;
                        property.SetValue(obj, value, null);
                    }
                    else if (propertyType.Name.Contains("ICollection")
                             || propertyType.Name.Contains("IEnumerable")
                             || propertyType.Name.Contains("List"))
                    {
                        var type = propertyType.GenericTypeArguments.FirstOrDefault();
                        object value = InstanciarLista(type);
                        property.SetValue(obj, value, null);
                    }
                    else
                    {
                        object value = DefaultForType(propertyType);
                        property.SetValue(obj, value, null);
                    }

                }
            }
        }

        public static object DefaultForType(Type targetType)
        {
            return Activator.CreateInstance(targetType);
        }

        private static object InstanciarLista(Type tipoGenericoDaLista)
        {
            var tipoLista = typeof(List<>);
            var tipoListaGenerica = tipoLista.MakeGenericType(tipoGenericoDaLista);

            return Activator.CreateInstance(tipoListaGenerica);
        }
    }
}
