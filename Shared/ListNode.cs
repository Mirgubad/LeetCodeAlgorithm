using System.Collections;

namespace Shared;

public class ListNode : IEnumerable
{
    public int val;
    public ListNode next;
    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;


    }

    public IEnumerator GetEnumerator()
    {
        ListNode current = this; // Assuming 'this' is the head of a linked list
        while (current != null)
        {
            yield return current.val; // Assuming 'val' is a property in the Node
            current = current.next; // Move to the next node
        }
    }
}
