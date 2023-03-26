using Microsoft.CSharp.RuntimeBinder;

namespace MailBodyPack
{
    public class ContentElement
    {
        public string Content { get; set; }
        public dynamic Attributes { get; set; }

        public delegate string GetValueDelegate();
        public bool IsProperty(GetValueDelegate getValueMethod)
        {
            try
            {
                //we're not interesting in the return value.
                //What we need to know is whether an exception occurred or not

                var v = getValueMethod();
                return (v == null) ? false : true;
            }
            catch (RuntimeBinderException)
            {
                return false;
            }
            catch
            {
                return true;
            }
        }
    }
}
