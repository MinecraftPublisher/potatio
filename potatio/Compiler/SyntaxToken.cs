using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace potatio
{
	[Serializable]
    class Tokenizer
    {
        List<TokenDefinition> tokenDefinitions = new List<TokenDefinition>();

        public Tokenizer()
        {
            tokenDefinitions.Add(new TokenDefinition(TokenType.Char, "^'[^']*'"));
            tokenDefinitions.Add(new TokenDefinition(TokenType.String, "^\"[^\"]*\""));
            tokenDefinitions.Add(new TokenDefinition(TokenType.Double, "^\\d+"));
            tokenDefinitions.Add(new TokenDefinition(TokenType.Array, @"^\{[^\{\}]*\}"));
            tokenDefinitions.Add(new TokenDefinition(TokenType.Definition, @"^\w+\s+=\s+.+"));
            tokenDefinitions.Add(new TokenDefinition(TokenType.Class, @"^class \w+:(\n\s.+)+"));
            tokenDefinitions.Add(new TokenDefinition(TokenType.Function, @"^def \w+:(\n\s.+)+"));
            tokenDefinitions.Add(new TokenDefinition(TokenType.Condition, @"^if .+:(\n\s.+)+(\nelse .+:(\n\s.+)+)*"));
            tokenDefinitions.Add(new TokenDefinition(TokenType.Loop, @"^(while|for|foreach).+:(\n\s.+)+"));
            tokenDefinitions.Add(new TokenDefinition(TokenType.Call, @"^\w+\(.+\)"));
        }

        public List<Token> Tokenize(string input)
        {
            List<Token> tokens = new List<Token>();
            string remainingText = input;

            while(!string.IsNullOrWhiteSpace(remainingText))
            {
                TokenMatch match = FindMatch(remainingText);
                if(match.IsMatch)
                {
                    tokens.Add(new Token(match.type, match.value));
                    remainingText = match.remainingText;
                }
                else {
                    if (IsWhitespace(remainingText))
                    {
                        remainingText = remainingText.Substring(1);
                    }
                    else
                    {
                        TokenMatch invalidMatch = CreateInvalidTokenMatch(remainingText);
                        tokens.Add(new Token(invalidMatch.type, invalidMatch.value));
                        remainingText = invalidMatch.remainingText;
                    }
                }
            }

            tokens.Add(new Token(TokenType.End_Of_Sequence, string.Empty));

            return tokens;
        }

        private TokenMatch FindMatch(string input)
        {
            foreach(TokenDefinition def in tokenDefinitions)
            {
                TokenMatch mt = def.Match(input);
                if(mt.IsMatch)
                {
                    return mt;
                }
            }

            return new TokenMatch() { IsMatch = false };
        }

        private bool IsWhitespace(string lqlText)
        {
            return Regex.IsMatch(lqlText, "^\\s+");
        }

        private TokenMatch CreateInvalidTokenMatch(string input)
        {
            Match match = Regex.Match(input, "(^\\S+\\s)|^\\S+");

            if(match.Success)
            {
                return new TokenMatch() {
                    IsMatch = true,
                    remainingText = input.Substring(match.Length),
                    type = TokenType.Invalid,
                    value = match.Value.Trim()
                };
            }

            return new TokenMatch() { IsMatch = false, remainingText = "", type = TokenType.Null, value = "" };
        }
    }

    [Serializable]
    class TokenDefinition
    {
        private Regex regex;
        private readonly TokenType type;

        public TokenDefinition(TokenType type, string pattern)
        {
            this.type = type;
            this.regex = new Regex(pattern, RegexOptions.IgnoreCase);
        }

        public TokenMatch Match(string input)
        {
            Match match = regex.Match(input);
            if (match.Success)
            {
                string remaining = string.Empty;
                if (match.Length != input.Length)
                {
                    remaining = input.Substring(match.Length);
                }

                return new TokenMatch() { IsMatch = true, remainingText = remaining, type = this.type, value = match.Value };
            }
            else
            {
                return new TokenMatch() { IsMatch = false };
            }
        }
    }

    [Serializable]
    struct TokenMatch
    {
        public bool IsMatch;
        public TokenType type;
        public string value;
        public string remainingText;
    }

    [Serializable]
    class Token
    {
        public TokenType type;
        public string value;

        public Token(TokenType type)
        {
            this.type = type;
            this.value = string.Empty;
        }

        public Token(TokenType type, string value)
        {
            this.type = type;
            this.value = value;
        }

        public Token Clone()
        {
            return new Token(type, value);
        }
    }

    [Serializable]
	enum TokenType
	{
		Char = 1,
        String = 2,
		Double = 3,
		Array = 4,
        Definition = 5,
        Class = 6,
		Function = 7,
		Condition = 8,
		Loop = 9,
		Call = 10,
        Null = 11,
        Invalid = 12,
        End_Of_Sequence = 13
	}
}
