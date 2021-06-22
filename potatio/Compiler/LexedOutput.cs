using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace potatio
{
    [Serializable]
    class LexedOutput
    {
        public int errors;
        public string errorList;
        public SyntaxToken[] tokens;
        public Dictionary<string, SyntaxToken[]> functions;
        public Dictionary<string, string> variables;

        public LexedOutput()
        {
            this.errors = 0;
            this.errorList = "";
            this.tokens = new SyntaxToken[0];
            this.functions = new Dictionary<string, SyntaxToken[]>();
            this.variables = new Dictionary<string, string>();
        }
    }
}
