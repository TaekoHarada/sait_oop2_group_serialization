using System;
using System.Runtime.Serialization;

namespace Assignment3.Utility
{
	[DataContract]
	public class SLL : ILinkedListADT
	{
		[DataMember]
		public Node Head { get; set; }
		[DataMember]
		public Node Tail { get; set; }
		public SLL()
		{
			Head = null;
			Tail = null;
		}

		/// <summary>
		/// Checks if the list is empty.
		/// </summary>
		/// <returns>True if it is empty.</returns>
		public bool IsEmpty()
		{
			if (Head == null) { return true; }
			else { return false; }
		}

		/// <summary>
		/// Clears the list.
		/// </summary>
		public void Clear()
		{
			Head = null;
			Tail = null;
		}

		/// <summary>
		/// Adds to the end of the list.
		/// </summary>
		/// <param name="value">Value to append.</param>
		public void AddLast(User value)
		{
			Node newNode = new Node(value);
			if (IsEmpty())
			{
				Head = newNode;
				Tail = newNode;
			}
			else
			{
				Tail.Next = newNode;
				Tail = newNode;
			}
		}

		/// <summary>
		/// Prepends (adds to beginning) value to the list.
		/// </summary>
		/// <param name="value">Value to store inside element.</param>
		public void AddFirst(User value)
		{
			Node newNode = new Node(value);
			if (IsEmpty())
			{
				Head = newNode;
				Tail = newNode;
			}
			else
			{
				newNode.Next = Head;
				Head = newNode;
			}
		}

		/// <summary>
		/// Adds a new element at a specific position.
		/// </summary>
		/// <param name="value">Value that element is to contain.</param>
		/// <param name="index">Index to add new element at.</param>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or past the size of the list.</exception>
		public void Add(User value, int index)
		{
			Node newNode = new Node(value);
			Node tmp;

			if (IsEmpty())
			{
				if (index != 0) { throw new IndexOutOfRangeException(index.ToString()); }
				Head = newNode;
				Tail = newNode;
			}
			else
			{
				// in the case of 'sll is empty' and 'index=0', "index + 1 > Count()" does not work
				if (index < 0 || index + 1 > Count()) { throw new IndexOutOfRangeException(index.ToString()); }

				tmp = Head;
				for (int i = 0; index - 1 > i; i++)
				{
					tmp = tmp.Next;
				}
				newNode.Next = tmp.Next;
				tmp.Next = newNode;
			}

		}


		/// <summary>
		/// Replaces the value  at index.
		/// </summary>
		/// <param name="value">Value to replace.</param>
		/// <param name="index">Index of element to replace.</param>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
		/// 
		public void Replace(User value, int index)
		{
			Node tmp=Head;

			if (IsEmpty() || index < 0 || index > Count()-1)
			{
				 throw new IndexOutOfRangeException(index.ToString()); 
			}
			else
			{
				for (int i = 0; i<index; i++)
				{
					tmp = tmp.Next;
				}
				tmp.Data = value;
			}
		}

		/// <summary>
		/// Gets the number of elements in the list.
		/// </summary>
		/// <returns>Size of list (0 meaning empty)</returns>
		public int Count()
		{
			int count = 0;
			Node tmp = Head;
			while (tmp != null)
			{
				count++;
				tmp = tmp.Next;
			}
			return count;
		}

		/// <summary>
		/// Removes first element from list
		/// </summary>
		/// <exception cref="CannotRemoveException">Thrown if list is empty.</exception>
		public void RemoveFirst()
		{
			if (IsEmpty()) { throw new CannotRemoveException(); }
			Head = Head.Next;
		}

		/// <summary>
		/// Removes last element from list
		/// </summary>
		/// <exception cref="CannotRemoveException">Thrown if list is empty.</exception>
		public void RemoveLast()
		{
			// 0 Node
			if (IsEmpty()) { throw new CannotRemoveException(); }
			// 1 Node
			if (Head == Tail)
			{
				Head = null;
				Tail = null;
			}
			// many Node
			else
			{
				Node tmp = Head;
				while (tmp.Next != Tail)
				{
					tmp = tmp.Next;
				}
				tmp.Next = null;
				Tail = tmp;
			}
		}

		/// <summary>
		/// Removes element at index from list, reducing the size.
		/// </summary>
		/// <param name="index">Index of element to remove.</param>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
		public void Remove(int index)
		{
			// 0 Node
			if (IsEmpty())
			{
				throw new CannotRemoveException();
			}

			if (index < 0 || index > Count())
			{
				throw new IndexOutOfRangeException(index.ToString());
			}

			// 1 Node
			if (Head == Tail)
			{
				Head = null;
				Tail = null;
			}

			// many node
			Node tmp = Head;

			if (index == 0)
			{
				Head = Head.Next;
			}
			else
			{
				for (int i = 0; i < index - 1; i++)
				{
					tmp = tmp.Next;
				}

				// index is not Tail
				if (tmp.Next.Next != null)
				{
					tmp.Next = tmp.Next.Next;
				}
				else
				{
					Tail = tmp;
					tmp.Next = null;
				}
			}


		}

		/// <summary>
		/// Gets the value at the specified index.
		/// </summary>
		/// <param name="index">Index of element to get.</param>
		/// <returns>Value of node at index</returns>
		/// <exception cref="IndexOutOfRangeException">Thrown if index is negative or larger than size - 1 of list.</exception>
		public User GetValue(int index)
		{
			// 0 Node OR Idex is out of range
			if (index < 0 || index > Count() || IsEmpty())
			{
				throw new IndexOutOfRangeException(index.ToString());
			}

			Node tmp = Head;
			for (int i = 0; i < index; i++)
			{
				tmp = tmp.Next;
			}
			return tmp.Data;
		}

		/// <summary>
		/// Gets the first index of element containing value.
		/// </summary>
		/// <param name="value">Value to find index of.</param>
		/// <returns>First of index of node with matching value or -1 if not found.</returns>
		public int IndexOf(User value)
		{
			if (IsEmpty())
			{
				return -1;
			}

			Node tmp = Head;

			for (int i = 0; i < Count(); i++)
			{
				if (tmp.Data.Equals(value)) { return i; }
				tmp = tmp.Next;
			}
			return -1;
		}

		/// <summary>
		/// Go through nodes and check if one has value.
		/// </summary>
		/// <param name="value">Value to find index of.</param>
		/// <returns>True if element exists with value.</returns>
		public bool Contains(User value)
		{
			if (IndexOf(value) == -1) { return false; }
			else { return true; }
		}

		/// Additional method
		/// <summary>
		/// Reverse the order of the nodes in the liked list
		/// </summary>
		public void Reverse()
		{
			if (Count() == 1 || IsEmpty()) { return; }


			for (int i = 0; i < Count() / 2; i++)
			{
				// Store the data of index i
				User tmpData = GetValue(i);

				// Set the value: index of 'count-i' to index of 'i'
				Replace(GetValue(Count() - 1 - i), i);

				// Set the value: index of 'i' to index of 'count-i'
				Replace(tmpData, Count() - 1 - i);
			}
		}

	}
}