using Shared;

class Program
{
    static void Main(string[] args)
    {

    }

    public static int Reverse(int x)
    {
        if (x > -10 && x < 10) return x;

        int current = 0;
        while (x != 0)
        {
            if (current > int.MaxValue / 10 || current < int.MinValue / 10)
                return 0;
            current = current * 10 + x % 10;
            x /= 10;
        }
        return current;
    }

    public static int LengthOfLongestSubstring(string s)
    {
        //if (s.Length == 0)
        //    return 0;
        //List<string> uniques = new List<string>();
        //for (int i = 0; i < s.Length; i++)
        //{
        //    string longestSubstring = s[i].ToString();
        //    for (int j = i + 1; j < s.Length; j++)
        //    {
        //        if (s[i] == s[j] || longestSubstring.Contains(s[j]))
        //            break;
        //        else
        //            longestSubstring += $"{s[j].ToString()}";
        //    }
        //    if (longestSubstring.Length > 1)
        //        uniques.Add(longestSubstring);
        //}
        //return uniques.Count > 0 ? uniques.OrderByDescending(x => x.Length).First().Length : 1;

        if (s.Length == 0)
            return 0;
        HashSet<char> set = new HashSet<char>();
        int left = 0, maxLength = 0;
        for (int right = 0; right < s.Length; right++)
        {
            while (set.Contains(s[right]))
            {
                set.Remove(s[left]);
                left++;
            }
            set.Add(s[right]);
            maxLength = Math.Max(maxLength, right - left + 1);
        }
        return maxLength;
    }
    public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        ListNode dummyHead = new ListNode(0);
        ListNode current = dummyHead;
        int carry = 0;

        while (l1 != null || l2 != null || carry > 0)
        {
            int sum = carry;

            if (l1 != null)
            {
                sum += l1.val;
                l1 = l1.next;
            }

            if (l2 != null)
            {
                sum += l2.val;
                l2 = l2.next;
            }

            carry = sum / 10; // Get carry for the next iteration
            current.next = new ListNode(sum % 10); // Add new digit
            current = current.next;
        }

        return dummyHead.next; // Return the next node (ignoring dummy head)
    }

}