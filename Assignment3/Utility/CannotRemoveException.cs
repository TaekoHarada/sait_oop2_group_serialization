using System;

namespace Assignment3.Utility
{
	public class CannotRemoveException:Exception
	{
		public CannotRemoveException()
		{
		}

		public CannotRemoveException(string message)
			: base(message)
		{
		}

		public CannotRemoveException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
