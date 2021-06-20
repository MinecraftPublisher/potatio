using System;
using System.IO;
using System.Linq;
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
                FileInfo inputDirInfo = new FileInfo(inputDir);
                string outputFile = Path.Combine(inputDirInfo.DirectoryName, inputDirInfo.Name.Substring(0, inputDirInfo.Name.IndexOf(inputDirInfo.Extension)));

                if (HasBinaryContent(inputDir) == true)
                {
                    Console.WriteLine("Given input contains binary.");
                    File.WriteAllText(outputFile + ".error.txt", "Given input contains binary.");
                }
                else
                {
                    Console.WriteLine("Loading data into memory...");
                    string input = File.ReadAllText(inputDirInfo.FullName);
                    Console.WriteLine("Lexing input...");
                    LexedOutput output = Lexer.Lex(input);
                    Console.WriteLine("Finished lexing.");
                    if(output.errors > 0)
                    {
                        Console.WriteLine("Lexer errors:\n");
                        Console.WriteLine(output.errorList);
                        File.WriteAllText(outputFile + ".error.txt",output.errorList);
                    }
                    else
                    {
                        string outputString = JSON.Serialize(output);
                        File.WriteAllText(outputFile + ".output.txt", outputString);
                        Console.WriteLine("Wrote the lexed data to the output file.");
                    }
                    Console.WriteLine("Press enter to exit");
                    Console.ReadLine();
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
        /// This one checks for binary content, pretty cool if you ask me.
        /// </summary>
        /// <param name="path">The input path.</param>
        /// <returns>True if the file has binary, False if the file contains only text.</returns>
        public static bool HasBinaryContent(string path)
        {
            return File.ReadAllText(path).Any(ch => char.IsControl(ch) && ch != '\r' && ch != '\n');
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
