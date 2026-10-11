var sol = new Solution();

var l1 = GetListNode([9,9,9,9,9,9,9]);

var l2 = GetListNode([9,9]);

var result = sol.AddTwoNumbers(l1, l2);

PrintListNode(result);
return;


void PrintListNode(ListNode? node)
{
    if (node is null) return;
    
    Console.Write(node.Val);
    PrintListNode(node.Next);
}

ListNode GetListNode(int[] nodes)
{
    if (nodes.Length == 0) throw new ArgumentException("Список пустой");

    var root = new ListNode(nodes[0]);
    var tail = root;

    for (var i = 1; i < nodes.Length; i++)
    {
        tail.Next = new ListNode(nodes[i]);
        tail = tail.Next;
    }

    return root;
}

public class ListNode(int val = 0, ListNode? next = null)
{
    public readonly int Val = val;
    public ListNode? Next = next;
}

public class Solution {
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var d1 = l1;
        var d2 = l2;

        var num1 = d1.Val;
        var num2 = d2.Val;

        var sum = num1 + num2;

        var root = new ListNode(sum % 10);
        var tail = root;
        
        var extra = sum / 10;

        d1 = d1.Next;
        d2 = d2.Next;
        
        while (d1 is not null || d2 is not null)
        {
            num1 = d1?.Val ?? 0;
            num2 = d2?.Val ?? 0;

            sum = num1 + num2 + extra;

            tail.Next = new ListNode(sum % 10);
            tail = tail.Next;

            extra = sum / 10;
            
            d1 = d1?.Next;
            d2 = d2?.Next;
        }

        if (extra != 0)
            tail.Next = new ListNode(extra % 10);

        return root;
    }
}