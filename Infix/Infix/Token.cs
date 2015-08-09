using System;

namespace Infix
{
	public class Token
	{
		public string Value { get; set;}
		public TOKENTYPE Type { get; set;}
		public PRECEDENCE Precedence { get; set;}
	}
}

