using System;
using System.Collections.Generic;
using System.Text;

namespace potatio
{
    [Serializable]
    struct LexedOutput
    {
        public int errors;
        public string errorList;
        public string[] arguments;
        public CodePiece[] pieces;

        /// <summary>
        /// Creates a lexed output with the given parameters.
        /// </summary>
        /// <param name="errors"></param>
        /// <param name="errorList"></param>
        /// <param name="arguments"></param>
        /// <param name="pieces"></param>
        public LexedOutput(int errors, string errorList, string[] arguments, CodePiece[] pieces)
        {
            this.errors = errors;
            this.errorList = errorList;
            this.arguments = arguments;
            this.pieces = pieces;
        }

        /// <summary>
        /// Creates a new empty LexedOutput.
        /// </summary>
        /// <param name="init"></param>
        public LexedOutput(string init = "empty")
        {
            this.errors = 0;
            this.errorList = "";
            this.arguments = new string[0];
            this.pieces = new CodePiece[0];
        }
    }

    struct CodePiece
    {
        public string functionName;
        public string[] arguments;
        public CodePiece[] inner;

        public CodePiece(string functionName, string[] arguments, CodePiece[] inner)
        {
            this.functionName = functionName;
            this.arguments = arguments;
            this.inner = inner;
        }
    }

    struct TranspilerLanguage
    {
        public string name;
        public string creator;
        public string version;
        public TranspilerCodePiece[] pieces;
    }

    struct TranspilerCodePiece
    {
        public CodePiece input;
        public string output;
    }
}
