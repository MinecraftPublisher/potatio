using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace potatio
{
    class Lexer
    {
        public static LexedOutput Lex(string code)
        {
            LexedOutput output = new LexedOutput();

            return output;
        }
    }

    class Transpiler
    {
        public Transpiler()
        {

        }
    }

    /// <summary>
    /// Once again, a picked up class.
    /// </summary>
    /// <typeparam name="TType"></typeparam>
    public static class JSON<TType> where TType : class
    {
        /// <summary>
        /// Serializes an object to JSON
        /// </summary>
        public static string Serialize(TType instance)
        {
            var serializer = new DataContractJsonSerializer(typeof(TType));
            using (var stream = new MemoryStream())
            {
                serializer.WriteObject(stream, instance);
                return Encoding.Default.GetString(stream.ToArray());
            }
        }

        /// <summary>
        /// DeSerializes an object from JSON
        /// </summary>
        public static TType Deserialize(string json)
        {
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(TType));
                return serializer.ReadObject(stream) as TType;
            }
        }
    }
}
