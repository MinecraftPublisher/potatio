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
		Function = 12,
		Loop = 13
	}
}
