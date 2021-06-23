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
        public Token[] tokens;
        public Dictionary<string, Token[]> functions;
        public Dictionary<string, Token> variables;

        public LexedOutput()
        {
            this.errors = 0;
            this.errorList = "";
            this.tokens = new Token[0];
            this.functions = new Dictionary<string, Token[]>();
            this.variables = new Dictionary<string, Token>();
        }
    }
}
