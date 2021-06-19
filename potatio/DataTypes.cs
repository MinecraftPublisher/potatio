using System;
using System.Collections.Generic;
using System.Text;

namespace potatio
{
    class LexedOutput
    {
        public int errors;
        public string errorList;
        public string[] arguments;
        public CodePiece[] pieces;

        public LexedOutput(int errors, string errorList, string[] arguments, CodePiece[] pieces)
        {
            this.errors = errors;
            this.errorList = errorList;
            this.arguments = arguments;
            this.pieces = pieces;
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
