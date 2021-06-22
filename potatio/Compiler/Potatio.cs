using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;

namespace potatio
{
    class Lexer
    {
        public static LexedOutput Lex(string code)
        {
            LexedOutput output = new LexedOutput();

            string[] lines = code.Split('\n');
            int length = lines.Length;
            int index = 0;

            for (index = 0; index < length; index++)
            {
                string line = lines[index];
                string functionName = line.ReadTo('(');

                // Parsing area

                if (functionName.Length == 0)
                {
                    output.errors++;
                    output.errorList += "Incorrect syntax on " + code.GetLineIndex(line);
                }
                else
                {
                    string arguments = line.ReadTo(')');
                    
                    if (arguments.Length == 0)
                    {
                        output.errors++;
                        output.errorList += "Incorrect syntax on " + code.GetLineIndex(line);
                    }
                    else
                    {
                        // Here i need a gud data type to work with, and then i can write the parser.
                    }
                }
            }

            return output;
        }

        public static string executeFn(string name, string[] args)
        {
            Type functionType = Assembly.GetExecutingAssembly().GetType("potatio.Methods");
            object runtime = Activator.CreateInstance(functionType);
            MethodInfo responder = functionType.GetMethod(name);

            if (responder == null)
            {
                return "null";
            }
            else
            {
                return (string)responder.Invoke(null, args);
            }
        }

        public static string executeFn(string name)
        {
            Type functionType = Assembly.GetExecutingAssembly().GetType("potatio.Methods");
            object runtime = Activator.CreateInstance(functionType);
            MethodInfo responder = functionType.GetMethod(name);

            if (responder == null)
            {
                return "null";
            }
            else
            {
                return (string)responder.Invoke(null, null);
            }
        }
    }

    public class Methods
    {
        public static string smth;

        public static string test(string input)
        {
            return "Hi! \"" + smth + "\" \"" + input + "\"";
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
            foreach (string line in current.Split('\n'))
            {
                if (line.IndexOf(text) > -1)
                {
                    return "Line " + current.Split('\n').ToList().IndexOf(line) + " Character " + line.IndexOf(text);
                }
            }

            return "Line 0 Character 0";
        }

        /// <summary>
        /// Reads until finding a specific character.
        /// </summary>
        /// <param name="current">The current string.</param>
        /// <param name="character">The character to read to.</param>
        /// <returns></returns>
        public static string ReadTo(this string current, char character)
        {
            int i = 0;
            string output = "";

            while((current[i] != character) && ( i != current.Length - 1 ))
            {
                output += current[i];
                i++;
            }

            return output;
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