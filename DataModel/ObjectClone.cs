using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public static class ObjectClone
    {
        public static T Clone<T>(this T source)
        {
            if (!typeof(T).IsSerializable)
            {
                throw new ArgumentException("The object must be serializable", "source");
            }
            if (Object.ReferenceEquals(source, null))
            {
                return default(T);
            }
            else
            {
                IFormatter formatter = new BinaryFormatter();
                using (Stream s = new MemoryStream())
                {
                    formatter.Serialize(s, source);
                    s.Position = 0;
                    return (T)formatter.Deserialize(s);
                }
            }
        }
    }
}
