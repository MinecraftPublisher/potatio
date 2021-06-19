using System;

namespace potatio
{
    class Program
    {
        static Potatio potatio;

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

            potatio = new Potatio();

            Console.Title = "Potatio Compiler-Interpreter-Transpiler";

            if(args.Length == 1)
            {
                Console.WriteLine("Reading input...");
                string input = args[0];
            }
            else
            {
                Console.WriteLine("Potatio is a programming language that does not compile/interpret on its own, but it can be transpiled to other programming languages.\n" +
                    "The goal of potatio is to let people share their projects with everyone.\n" +
                    "Write one project in potatio, and convert it into a webpage, an ios app, an android app, a windows app, a linux app, a macos app and many more.\n" +
                    "\n" +
                    "CONTRIBUTION GUIDE COMING SOON");
            }

            while(true)
            {

            }
        }
    }
}
