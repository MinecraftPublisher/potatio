using System;
using System.Collections.Generic;
using System.Text;

namespace potatio
{
	[Serializable]
	struct SyntaxToken
    {
		public SyntaxTokenType type;
		public object data;

		public SyntaxToken(SyntaxTokenType type, object data)
        {
			this.type = type;
			this.data = data;
        }
    }

	[Serializable]
	enum SyntaxTokenType
	{
		/* Data types */

		Null = 1,
		NaN = 2,
		Undefined = 3,
		Empty = 4,
		Byte = 5,
		Char = 6,
		String = 7,
		Int = 8,
		Float = 9,
		Double = 10,
		Array = 11,

		/* Characters */

		Space = 12,
		Tab = 13,
		NewLine = 14,
		Quotation = 15,
		DoubleQuotation = 16,
		Plus = 17,
		Minus = 18,
		Multiple = 19,
		Divide = 20,
		Equals = 21,
		Dot = 22,
		Underline = 23,
		Exclamation = 24,
		Question = 25,

		/* OpenA = "("   CloseA = ")" */

	    OpenA = 26,
		CloseA = 27,

		/* OpenB = "["   CloseB = "]" */
		OpenB = 28,
		CloseB = 29,

		/* OpenC = "{"   CloseC = "}" */

		OpenC = 30,
		CloseC = 31
	}
}
