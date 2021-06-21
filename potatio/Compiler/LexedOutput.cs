using System;
using System.Collections.Generic;
using System.Text;

namespace potatio
{
    class LexedOutput
    {
        public int errors;
        public string errorList;
        public SyntaxToken[] tokens;

        public LexedOutput()
        {
            this.errors = 0;
            this.errorList = "";
            this.tokens = new SyntaxToken[0];
        }
    }
}
