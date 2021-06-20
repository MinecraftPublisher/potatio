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
            LexedOutput output = new LexedOutput("");
            output.pieces.Append(new CodePiece());

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
    public static class JSON
    {
        /// <summary>
        /// Deserialize an from json string
        /// </summary>
        public static T Deserialize<T>(string body)
        {
            using (var stream = new MemoryStream())
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(body);
                writer.Flush();
                stream.Position = 0;
                return (T)new DataContractJsonSerializer(typeof(T)).ReadObject(stream);
            }
        }

        /// <summary>
        /// Serialize an object to json
        /// </summary>
        public static string Serialize<T>(T item)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                new DataContractJsonSerializer(typeof(T)).WriteObject(ms, item);
                return Encoding.Default.GetString(ms.ToArray());
            }
        }
    }
}
