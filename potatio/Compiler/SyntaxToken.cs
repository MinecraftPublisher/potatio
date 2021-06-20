using System;
using System.Collections.Generic;
using System.Text;

namespace potatio.Compiler
{
	[Serializable]
	struct SyntaxToken
	{
		SyntaxTokenType type;
	}

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
		Semicolon = 15,
		Quotation = 16,
		DoubleQuotation = 17,
		Plus = 18,
		Minus = 19,
		Multiple = 20,
		Divide = 21,
		Equals = 22,
		Dot = 23,
		Underline = 24,
		Exclamation = 25,
		Question = 26,

		/* OpenA = "("   CloseA = ")" */

	    OpenA = 27,
		CloseA = 28,

		/* OpenB = "["   CloseB = "]" */
		OpenB = 29,
		CloseB = 30,

		/* OpenC = "{"   CloseC = "}" */

		OpenC = 31,
		CloseC = 32
	}
}
