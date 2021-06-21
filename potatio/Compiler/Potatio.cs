using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

    public static class Extensions
    {
        /// <summary>
        /// Gets the specified string's line and character index from the current string.
        /// </summary>
        /// <param name="current">The current string.</param>
        /// <param name="text">The text to get the index.</param>
        /// <returns></returns>
        public static string GetLineIndex(this string current, string text)
        {
            foreach(string line in current.Split('\n'))
            {
                if(line.IndexOf(text) > -1)
                {
                    return "Line " + current.Split('\n').ToList().IndexOf(line) + " Character " + line.IndexOf(text);
                }
            }

            return "Line 0 Character 0";
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
