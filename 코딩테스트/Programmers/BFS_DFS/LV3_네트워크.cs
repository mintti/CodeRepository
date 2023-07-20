using System;
using System.Linq;
using System.Collections.Generic;

public class Node
{
    public int Index;
    public List<Node> ConnectedNodeList = new List<Node>();
    public bool IsCheck = false;
}

public class Solution {
    public int solution(int n, int[,] computers) {
        int answer = 0;

        List<Node> NodeList = new List<Node>();
        for(int index = 0 ; index < n; index ++)
        {
            NodeList.Add(new Node());
        }

        for(int index = 0 ; index < computers.GetLength(0); index ++)
        {
            NodeList[index].Index = index;
            for(int target =  0; target < computers.GetLength(1); target ++)
            {
                if(index == target) continue;

                if (computers[index, target] == 1)
                {
                    NodeList[index].ConnectedNodeList.Add(NodeList[target]);
                }
            }
        }

        NodeList.ForEach( node => node.ConnectedNodeList.RemoveAll( cnode => !cnode.ConnectedNodeList.Contains(node)));

        answer = CheckNetwork(NodeList, null);

        return answer;
    }

    public int CheckNetwork(List<Node> list, Node beforeNode)
    {
        int answer = 0;
        for(int index = 0; index < list.Count; index++)
        {
            Node node = list[index];
            if(beforeNode != null) node.ConnectedNodeList.Remove(beforeNode);
            if(node.IsCheck) continue;
            node.IsCheck = true;

            if(node.ConnectedNodeList.Count > 0)
            {
                CheckNetwork(node.ConnectedNodeList, node);
            }
            answer++;
        }


        return answer;
    }
}