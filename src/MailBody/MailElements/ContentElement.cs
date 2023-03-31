using System.Collections;

namespace MailBodyPack
{
    public class ContentElement
    {
        public string Content { get; set; }
        public dynamic Attributes { get; set; }

        public bool TryGetAttribute<T>(string attr, out T val)
        {
            val = default;

            if (Attributes == null || string.IsNullOrEmpty(attr))
                return false;

            var type = Attributes.GetType();
            var property = type.GetProperty(attr);

            if (property != null)
            {
                val = (T)property.GetValue(Attributes, null);
                return true;
            }

            var isDict = typeof(IDictionary).IsAssignableFrom(type);

            if (isDict)
            {
                var dictionary = (IDictionary)Attributes;
                
                if (dictionary.Contains(attr))
                {
                    val = (T)dictionary[attr];
                    return true;
                }
            }

            return false;
        }

        public bool HasAttribute(string attr) => TryGetAttribute(attr, out object T) && T is not null;
    }
}
