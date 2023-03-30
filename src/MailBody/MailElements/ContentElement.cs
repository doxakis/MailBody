using System.Reflection;
using System;
using System.Collections;

namespace MailBodyPack
{
    public class ContentElement
    {
        public string Content { get; set; }
        public dynamic Attributes { get; set; }

        public bool TryGetAttribute<T>(string attr, out T val)
        {
            val = default(T);
            try
            {
                if (Attributes == null || string.IsNullOrEmpty(attr))
                {
                    return false;
                }

                Type type = (Attributes as object).GetType();

                PropertyInfo property = null;

#if NETSTANDARD14
                property = type.GetTypeInfo().GetDeclaredProperty(attr);
#elif NETSTANDARD16
                property = type.GetTypeInfo().GetProperty(attr);
#else
                property = type.GetProperty(attr);
#endif

                if (property != null)
                {
                    val = (T)property.GetValue(Attributes, null);
                    return true;
                }

                bool isDict = false;

#if NETSTANDARD14
                isDict = typeof(IDictionary).GetTypeInfo().IsAssignableFrom(type.GetTypeInfo());
#elif NETSTANDARD16
                isDict = typeof(IDictionary).GetTypeInfo().IsAssignableFrom(type);
#else
                isDict = typeof(IDictionary).IsAssignableFrom(type);
#endif

                if (isDict)
                {
                    IDictionary dictionary = (IDictionary)Attributes;
                    
                    if (dictionary.Contains(attr))
                    {
                        val = (T)dictionary[attr];
                        return true;
                    }
                }

                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool HasAttribute(string attr)
        {
            object T = null;
            return TryGetAttribute(attr, out T) && T != null;
        }
    }
}
