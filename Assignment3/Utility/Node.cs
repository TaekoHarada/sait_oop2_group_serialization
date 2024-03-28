using System.Runtime.Serialization;

namespace Assignment3.Utility
{
	[DataContract]
	public class Node
	{
		public Node() { }
		public Node(User data)
		{
			Data = data;
		}

		[DataMember]
		public User Data { get; set; }

		[DataMember]
		public Node Next { get; set; }
	}
}
