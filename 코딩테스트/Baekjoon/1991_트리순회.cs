using System;
using System.Collections.Generic;
using System.Linq;

namespace TestProject.backjoon
{
    public class Node
    {
        public Node L_ChildNode;
        public Node R_ChildNode;
        public string Value;

        public Node() { }
        public Node(string value)
        { 
            Value = value;
        }

        public bool InsertSearch(string parent, string left, string right)
        {
            if(Value == null || Value == parent)
            {
                Value = parent;
                if(left != null) L_ChildNode = new Node(left);
                if(right != null) R_ChildNode = new Node(right);
                return true;
            }
            else
            {
                if (L_ChildNode != null)
                {
                    if (L_ChildNode.InsertSearch(parent, left, right)) return true ;
                }

                if (R_ChildNode != null)
                {
                    if (R_ChildNode.InsertSearch(parent, left, right)) return true;
                }
            }

            return false;
        }

        public void PreorderTraversal()
        {
            Console.Write(Value);

            if(L_ChildNode != null) L_ChildNode.PreorderTraversal();
            if(R_ChildNode != null) R_ChildNode.PreorderTraversal();
        }

        public void InorderTraversal()
        {
            if (L_ChildNode == null && R_ChildNode == null)
            {
                Console.Write(Value);
                return;
            }
            
            if (L_ChildNode != null)
            {
                L_ChildNode.InorderTraversal();
                Console.Write(Value);
            }
            else
            {
                Console.Write(Value);
            }


            if (R_ChildNode != null)
            {
                R_ChildNode.InorderTraversal();
            }

            return;
        }

        public void PostrderTraversal()
        {
            if (L_ChildNode != null)
            {
                L_ChildNode.PostrderTraversal();
            }

            if (R_ChildNode != null)
            {
                R_ChildNode.PostrderTraversal();
            }

            Console.Write(Value);
            return;
        }
    }

    public class _1991_트리순회
    {
        public void solution() 
        {
            int n = Convert.ToInt32(Console.ReadLine());

            Node rootNode = new Node();

            // 삽입
            for(int index = 0; index < n;index++)
            {
                string[] args = Console.ReadLine().Split(" ");
                string left = args[1] == "." ? null : args[1];
                string right = args[2] == "." ? null : args[2];

                // 값 찾아 삽입
                rootNode.InsertSearch(args[0], left, right);
            }

            // 전위 순회
            rootNode.PreorderTraversal();
            Console.WriteLine();

            // 중위 순회
            rootNode.InorderTraversal();
            Console.WriteLine();

            // 후위 순회
            rootNode.PostrderTraversal();
            Console.WriteLine();

        }
    }
}
