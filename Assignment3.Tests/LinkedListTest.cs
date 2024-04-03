using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using Assignment3;
using Assignment3.Utility;
using NUnit.Framework;

namespace Assignment3.Tests
{
	[TestFixture]
	public class LinkedListTest
	{
		// Empty List
		SLL emptySll;
		// Not Empty List
		SLL notEmptySll;

		User testUser1 = new User(111, "TestUserName1", "test@test.com", "TESTpassword");
		User testUser2 = new User(222, "TestUserName2", "test@test.com", "TESTpassword");
		// Test data for adding
		User testUser3 = new User(333, "TestUserName3", "test@test.com", "TESTpassword");

		[SetUp]
		public void SetUp()
		{
			// Empty List
			emptySll = new SLL();

			// Not Empty List
			notEmptySll = new SLL();

			Node node1 = new Node(testUser1);
			Node node2 = new Node(testUser2);
			node1.Next = node2;

			// Add to list
			notEmptySll.Head = node1;
			notEmptySll.Tail = node2;
		}

		// The linked list is empty.
		[Test]
		public void IsEmpty()
		{
			var result = emptySll.IsEmpty();
			Assert.IsTrue(result);
		}

		// An item is prepended. (Empty List)
		[Test]
		public void AnItemIsPrepended_ToEmptyList()
		{
			emptySll.AddFirst(testUser3);
			Assert.AreEqual(testUser3, emptySll.Head.Data);
			Assert.AreEqual(testUser3, emptySll.Tail.Data);
			Assert.AreEqual(emptySll.Count(), 1);
		}

		// An item is prepended. (Non Empty List)
		[Test]
		public void AnItemIsPrepended_ToNonEmptyList()
		{
			notEmptySll.AddFirst(testUser3);
			Assert.AreEqual(testUser3, notEmptySll.Head.Data);
			Assert.AreEqual(testUser1, notEmptySll.Head.Next.Data);
		}

		// An item is appended. (Empty List)
		[Test]
		public void AnItemIsApended_ToEmptyList()
		{
			emptySll.AddLast(testUser3);
			Assert.AreEqual(testUser3, emptySll.Head.Data);
			Assert.AreEqual(testUser3, emptySll.Tail.Data);
			Assert.AreEqual(emptySll.Count(), 1);
		}

		// An item is appended. (Non Empty List)
		[Test]
		public void AnItemIsApended_ToNonEmptyList()
		{
			notEmptySll.AddLast(testUser3);
			Assert.AreEqual(testUser3, notEmptySll.Tail.Data);
			Assert.AreNotEqual(testUser2, notEmptySll.Tail.Data);
		}

		// Add
		// An item is inserted at index. (Empty List)
		[Test]
		public void AnItemIsAdd_ToEmptyList()
		{
			emptySll.Add(testUser3, 0);
			Assert.AreEqual(testUser3, emptySll.Head.Data);
			Assert.AreEqual(emptySll.Count(), 1);
		}

		// An item is inserted at index. (Non Empty List)
		[Test]
		public void AnItemIsAdd_ToNonEmptyList()
		{
			notEmptySll.Add(testUser3, 0);
			Assert.AreEqual(testUser2, notEmptySll.Tail.Data);
			Assert.AreEqual(notEmptySll.Count(), 3);
		}

		// Exception Occur: An item is inserted at index. (Empty List & index < 0)
		[Test]
		public void AnItemIsAdd_ToEmptyList_ExceptionOccurForLess()
		{
			Assert.Throws<IndexOutOfRangeException>(() => emptySll.Add(testUser3, -3));
		}

		// Exception Occur: An item is inserted at index. (Empty List & index > range(3))
		[Test]
		public void AnItemIsAdd_ToEmptyList_ExceptionOccurForMore()
		{
			Assert.Throws<IndexOutOfRangeException>(() => emptySll.Add(testUser3, 3));
		}

		// Exception Occur: An item is inserted at index. (NonEmpty List & index < 0)
		[Test]
		public void AnItemIsAdd_ToNonEmptyList_ExceptionOccurForLess()
		{
			Assert.Throws<IndexOutOfRangeException>(() => notEmptySll.Add(testUser3, -3));
		}

		// Exception Occur: An item is inserted at index. (NonEmpty List & index > range(3))
		[Test]
		public void AnItemIsAdd_ToNonEmptyList_ExceptionOccurForMore()
		{
			Assert.Throws<IndexOutOfRangeException>(() => notEmptySll.Add(testUser3, 3));
		}

		// Replace
		// An data is replaced at index. (Empty List)
		[Test]
		public void AnItemIsReplace_ToEmptyList()
		{
			Assert.Throws<IndexOutOfRangeException>(() => emptySll.Replace(testUser3, 0));
		}

		// An data is replaced at index. (Non Empty List)
		[Test]
		public void AnItemIsReplace_ToNonEmptyList()
		{
			notEmptySll.Replace(testUser3, 0);
			Assert.AreEqual(notEmptySll.Count(), 2);
			Assert.AreEqual(testUser3, notEmptySll.Head.Data);
			Assert.AreEqual(testUser2, notEmptySll.Tail.Data);
		}

		// Exception Occur: An data is replaced at index. (index > Count())
		[Test]
		public void AnItemIsReplace_ToNonEmptyList_ExceptionOccurForMore()
		{
			Assert.Throws<IndexOutOfRangeException>(() => notEmptySll.Replace(testUser3, 10));
		}

		// Exception Occur: An item is inserted at index. (index < 0)
		[Test]
		public void AnItemIsReplace_ToNonEmptyList_ExceptionOccurForLess()
		{
			Assert.Throws<IndexOutOfRangeException>(() => notEmptySll.Replace(testUser3, -3));
		}

		// Count
		// Count a empty list
		[Test]
		public void Count_EmptyList()
		{
			Assert.AreEqual(emptySll.Count(), 0);
		}

		//Count a non-empty list
		[Test]
		public void Count_NonEmptyList()
		{
			Assert.AreEqual(notEmptySll.Count(), 2);
		}

		// RemoveFirst
		// RemoveFirst from empty list throw exception
		[Test]
		public void RemoveFirst_EmptyList_ExceptionOccur()
		{
			Assert.Throws<CannotRemoveException>(() => emptySll.RemoveFirst());
		}

		// RemoveFirst from non-empty list
		[Test]
		public void RemoveFirst_NonEmptyList()
		{
			notEmptySll.RemoveFirst();
			Assert.AreEqual(notEmptySll.Head.Data, testUser2);
			Assert.AreEqual(notEmptySll.Count(), 1);
		}

		// RemoveLast
		// RemoveLast from empty list throw exception
		[Test]
		public void RemoveLast_EmptyList_ExceptionOccur()
		{
			Assert.Throws<CannotRemoveException>(() => emptySll.RemoveLast());
		}

		// RemoveLast from non-empty list
		[Test]
		public void RemoveLast_NonEmptyList()
		{
			notEmptySll.RemoveLast();
			Assert.AreEqual(notEmptySll.Tail.Data, testUser1);
			Assert.AreEqual(notEmptySll.Count(), 1);
		}

		// Remove
		// Remove from empty list throw an exception
		[Test]
		public void Remove_EmptyList_ExceptionOccur()
		{
			Assert.Throws<CannotRemoveException>(() => emptySll.Remove(0));
		}

		// Remove from non-empty & index != Tail
		[Test]
		public void Remove_NonEmptyList_indexIsNotTail()
		{
			notEmptySll.Remove(0);
			Assert.AreEqual(notEmptySll.Head.Data, testUser2);
			Assert.AreEqual(notEmptySll.Count(), 1);
		}

		// Remove from non-empty & index == Tail
		[Test]
		public void Remove_NonEmptyList_indexIsTail()
		{
			notEmptySll.Remove(1);
			Assert.AreEqual(notEmptySll.Tail.Data, testUser1);
			Assert.AreEqual(notEmptySll.Count(), 1);
		}

		// GetValue
		// GetValue get the value of index
		[Test]
		public void GetValue_NonEmptyList()
		{
			Assert.AreEqual(notEmptySll.GetValue(0), testUser1);
			Assert.AreEqual(notEmptySll.GetValue(1), testUser2);
		}

		// GetValue throw excption with empty list
		[Test]
		public void GetValue_EmptyList_ExceptionOccur()
		{
			Assert.Throws<IndexOutOfRangeException>(() => emptySll.GetValue(0));
		}

		// GetValue throw excption with empty list
		[Test]
		public void GetValue_NonEmptyList_ExceptionOccur()
		{
			Assert.Throws<IndexOutOfRangeException>(() => notEmptySll.GetValue(3));
		}

		// IndexOf
		// Return index with not empty list
		[Test]
		public void IndexOf_NonEmptyList_withMatchingValue()
		{
			Assert.AreEqual(notEmptySll.IndexOf(testUser1), 0);
			Assert.AreEqual(notEmptySll.IndexOf(testUser2), 1);
		}

		// Return -1 if there is no value matching with not empry list
		[Test]
		public void IndexOf_NonEmptyList_withNotMatchingValue()
		{
			Assert.AreEqual(notEmptySll.IndexOf(testUser3), -1);
		}

		// Return -1 with empty list
		[Test]
		public void IndexOf_EmptyList()
		{
			Assert.AreEqual(emptySll.IndexOf(testUser1), -1);
		}

		// Contains
		// Return True, when a list contains a value
		[Test]
		public void Contains_NonEmptyList_withMatchingValue()
		{
			Assert.IsTrue(notEmptySll.Contains(testUser1));
		}

		// Return False, when a list does not contain a value
		[Test]
		public void Contains_NonEmptyList_withNotMatchingValue()
		{
			Assert.IsFalse(notEmptySll.Contains(testUser3));
		}

		// Return False, when a list is empty
		[Test]
		public void Contains_EmptyList()
		{
			Assert.IsFalse(emptySll.Contains(testUser1));
		}


		// 
		[Test]
		public void Reverse_NonEmptyList()
		{
			// prepare Linked List with 3 nodes
			// user1 > user2 > user3
			notEmptySll.AddLast(testUser3);
			Assert.AreEqual(notEmptySll.Count(), 3);
			Assert.AreEqual(notEmptySll.Head.Data, testUser1);
			Assert.AreEqual(notEmptySll.Tail.Data, testUser3);

			// user3 > user2 > user1
			notEmptySll.Reverse();
			Console.WriteLine(notEmptySll.Head.Data.Name);
			Console.WriteLine(notEmptySll.Tail.Data.Name);
			Assert.AreEqual(notEmptySll.Count(), 3);
			Assert.AreEqual(notEmptySll.Head.Data, testUser3);
			Assert.AreEqual(notEmptySll.Tail.Data, testUser1);

		}
	}
}
