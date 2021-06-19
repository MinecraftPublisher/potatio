using System;
using System.Collections.Generic;
using System.Text;

namespace potatio
{
    struct LexedOutput
    {
        public string[] arguments;
        public CodePiece[] pieces;
    }

    struct CodePiece
    {
        public string functionName;
        public string[] arguments;
        public CodePiece[] inner;
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
