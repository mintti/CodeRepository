﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
	/*
	 * 더블 링크드 리스트의 순서를 뒤바꾸기
	 *    - Reverse 함수를 구현하시면 됩니다.
	 *    - 노드의 prev, next 값이 올바르게 설정되어야 합니다.
	 */

	class Node
	{
		public int value;
		public Node prev;
		public Node next;
	}

	class Program
	{
		static void Main(string[] args)
		{
			Node head = CreateTestNodes(5);

			Print(head);

			Node reversed = Reverse(head);

			Print(reversed);
		}

#region Stub
		static Node CreateTestNodes(int count)
		{
			var nodes = new Node[count];
			for( int i = 0; i < count; i++ )
				nodes[i] = new Node() { value = i + 1 };

			for( int i = 1; i < count; i++ )
				nodes[i].prev = nodes[i - 1];

			for( int i = 0; i < count - 1; i++ )
				nodes[i].next = nodes[i + 1];

			return nodes[0];
		}

		static void Print(Node head)
		{
			var node = head;
			while( node != null )
			{
				Console.Write(node.value + " ");
				node = node.next;
			}

			Console.WriteLine();
		}
#endregion

		static Node Reverse(Node head)
		{
			// 링크드 리스트의 순서를 뒤바꾸도록 구현해 주세요.
			var temp = head.prev;
			head.prev = head.next;
			head.next = temp;

			if (head.prev != null)
			{
				return Reverse(head.prev);
			}
			else return head;
		}
	}
}
