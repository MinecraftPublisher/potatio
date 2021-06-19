using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;

namespace potatio
{
    class Potatio
    {
        private Lexer lexer;
        private Transpiler transpiler;
        public readonly string version = "v0.1 BETA";

        public Potatio()
        {
            Console.WriteLine("Potatio " + version);
            Console.WriteLine("Loading interpreter...");
            lexer = new Lexer();
            Console.WriteLine("Loading transpiler...");
            transpiler = new Transpiler();
            Console.WriteLine("All assemblies loaded.");
            Console.WriteLine("");
        }

        public void RunCode(string code)
        {
            Console.WriteLine("Ran code!");
        }
    }

    class Lexer
    {
        public Lexer()
        {

        }

        public LexedOutput Lex(string code)
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
        public static TType DeSerialize(string json)
        {
            using (var stream = new MemoryStream(Encoding.Default.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(typeof(TType));
                return serializer.ReadObject(stream) as TType;
            }
        }
    }
}
