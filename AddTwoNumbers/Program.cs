// https://leetcode.com/problems/add-two-numbers/description/

var example1LinkedList1 = new ListNode(2, new ListNode(4, new ListNode(3)));
var example1LinkedList2 = new ListNode(5, new ListNode(6, new ListNode(4)));
// [7, 0, 8]
var result1 = AddTwoNumbers(example1LinkedList1, example1LinkedList2);

var example2LinkedList1 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9)))))));
var example2LinkedList2 = new ListNode(9, new ListNode(9, new ListNode(9, new ListNode(9))));
// [8, 9, 9, 9, 0, 0, 0, 1]
var result2 = AddTwoNumbers(example2LinkedList1, example2LinkedList2);

Console.ReadKey();

ListNode AddTwoNumbers(ListNode l1, ListNode l2)
{
    return RecursiveAddTwoNumbers(l1, l2, 0)!;
}

ListNode? RecursiveAddTwoNumbers(ListNode? l1, ListNode? l2, int carry)
{
    if (l1 is null && l2 is null)
    {
        return carry == 1 ? new ListNode(1) : null;
    }
    else if (l1 is null)
    {
        return RecursiveAddOneNumber(l2, carry);
    }
    else if (l2 is null)
    {
        return RecursiveAddOneNumber(l1, carry);
    }
    else
    {
        return new ListNode((l1.val + l2.val + carry) % 10, RecursiveAddTwoNumbers(l1.next, l2.next, (l1.val + l2.val + carry) / 10));
    }
}

ListNode? RecursiveAddOneNumber(ListNode? l, int carry)
{
    if (l is null)
    {
        return carry == 1 ? new ListNode(1) : null;
    }
    else
    {
        return new ListNode((l.val + carry) % 10, RecursiveAddOneNumber(l.next, (l.val + carry) / 10));
    }
}

class ListNode(int val = 0, ListNode? next = null)
{
    public int val = val;
    public ListNode? next = next;
}