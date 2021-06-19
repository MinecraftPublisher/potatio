using System;
using System.IO;
using System.Text;

namespace potatio
{
    class Program
    {
        static void Main(string[] args)
        {
            #region potatio-logo
            Console.WriteLine(
 "\n" +
 "      ######                      \n" +                
 "      #     #  ####  #####   ##   ##### #  ####  \n" +
 "      #     # #    #   #    #  #    #   # #    # \n" +
 "      ######  #    #   #   #    #   #   # #    # \n" +
 "      #       #    #   #   ######   #   # #    # \n" +
 "      #       #    #   #   #    #   #   # #    # \n" +
 "      #        ####    #   #    #   #   #  ####  \n");
            #endregion

            string version = "v0.1 BETA";
            Console.Title = "Potatio " + version;

            if(args.Length == 1)
            {
                Console.WriteLine("Reading input...");
                string inputDir = args[0];
                
                if(GetEncoding(inputDir) == null)
                {
                    Console.WriteLine("Given input is not in a vaild text encoding format.");
                    Environment.Exit(87);
                }
                else
                {
                    Console.WriteLine("Loading data into memory...");
                    string input = File.ReadAllText(inputDir);
                    Console.WriteLine("Lexing input...");
                    LexedOutput output = Lexer.Lex(input);
                    string outputString = JSON<LexedOutput>.Serialize(output);
                }
            }
            else
            {
                Console.WriteLine("Potatio is a programming language that does not compile/interpret on its own,\n" +
                    "But it can be transpiled to other programming languages.\n" +
                    "The goal of potatio is to let people share their projects with everyone.\n" +
                    "Write one project in potatio, and convert it into a webpage, an ios app, an android app, a windows app, a linux app, a macos app and many more.\n" +
                    "\n" +
                    "CONTRIBUTION GUIDE COMING SOON");
            }

            while(true)
            {

            }
        }

        /// <summary>
        /// Determines a text file's encoding by analyzing its byte order mark (BOM).
        /// Defaults to ASCII when detection of the text file's endianness fails.
        /// 
        /// ( Btw i picked up this code from idk where i think the good ol' stackoverflow )
        /// </summary>
        /// <param name="filename">The text file to analyze.</param>
        /// <returns>The detected encoding.</returns>
        public static Encoding GetEncoding(string filename)
        {
            // Read the BOM
            var bom = new byte[4];
            using (var file = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                file.Read(bom, 0, 4);
            }

            // Analyze the BOM
            if (bom[0] == 0x2b && bom[1] == 0x2f && bom[2] == 0x76) return Encoding.UTF7;
            if (bom[0] == 0xef && bom[1] == 0xbb && bom[2] == 0xbf) return Encoding.UTF8;
            if (bom[0] == 0xff && bom[1] == 0xfe && bom[2] == 0 && bom[3] == 0) return Encoding.UTF32; //UTF-32LE
            if (bom[0] == 0xff && bom[1] == 0xfe) return Encoding.Unicode; //UTF-16LE
            if (bom[0] == 0xfe && bom[1] == 0xff) return Encoding.BigEndianUnicode; //UTF-16BE
            if (bom[0] == 0 && bom[1] == 0 && bom[2] == 0xfe && bom[3] == 0xff) return new UTF32Encoding(true, true);  //UTF-32BE

            // We actually have no idea what the encoding is if we reach this point, so
            // you may wish to return null instead of defaulting to ASCII
            return null;
        }
    }

    /// <summary>
    /// Got this class from https://www.techiedelight.com/add-new-elements-array-csharp/ to add elements to arrays.
    /// </summary>
    public static class Extensions
    {
        public static T[] Append<T>(this T[] array, T item)
        {
            if (array == null)
            {
                return new T[] { item };
            }

            T[] result = new T[array.Length + 1];
            for (int i = 0; i < array.Length; i++)
            {
                result[i] = array[i];
            }

            result[array.Length] = item;
            return result;
        }
    }
}
