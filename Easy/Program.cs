using Shared;
using System.Collections;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
    }


    public static void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        for (int i = m; i < nums1.Length; i++)
        {
            nums1[i] = nums2[i - m];
        }

        bool swapped;
        do
        {
            swapped = false;
            for (int i = 0; i < nums1.Length - 1; i++)
            {
                if (nums1[i] > nums1[i + 1])
                {
                    int temp = nums1[i];
                    nums1[i] = nums1[i + 1];
                    nums1[i + 1] = temp;
                    swapped = true;
                }
            }
        } while (swapped);
    }
    public static ListNode DeleteDuplicates(ListNode head)
    {
        ListNode current = head;
        while (current != null)
        {
            // While next node exists and has the same value, skip it.
            while (current.next != null && current.val == current.next.val)
            {
                current.next = current.next.next;
            }
            // Move to the next distinct node.
            current = current.next;
        }
        return head;
    }
    public static int ClimbStairs(int n)
    {
        // For 0 or 1 step, there is 1 way (doing nothing or one step)
        if (n <= 1) return 1;

        // Initialize the base cases:
        // ways to reach step 0 and step 1 are both 1.
        int oneStepBefore = 1; // dp[i-1]
        int twoStepsBefore = 1; // dp[i-2]
        int current = 0;

        // Compute number of ways for each step from 2 to n.
        for (int i = 2; i <= n; i++)
        {
            current = oneStepBefore + twoStepsBefore; // dp[i] = dp[i-1] + dp[i-2]
            twoStepsBefore = oneStepBefore; // shift the window: dp[i-2] becomes dp[i-1] for next iteration
            oneStepBefore = current;        // dp[i-1] becomes current dp[i]
        }

        return current;
    }
    public static int MySqrt(int x)
    {
        if (x < 2) return x; // Base cases: sqrt(0) = 0, sqrt(1) = 1

        int left = 1, right = x / 2, result = 0;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // Avoid overflow
            long square = (long)mid * mid; // Prevent int overflow

            if (square == x) return mid;
            else if (square < x)
            {
                result = mid; // Store the floor value
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return result; // Floor of sqrt(x)

    }
    public static string AddBinary(string a, string b)
    {
        StringBuilder result = new StringBuilder();
        int i = a.Length - 1, j = b.Length - 1, carry = 0;
        while (i >= 0 || j >= 0 || carry > 0)
        {
            if (i >= 0) carry += a[i--] - '0';
            if (j >= 0) carry += b[j--] - '0';

            result.Append((char)('0' + (carry % 2)));
            carry /= 2;
        }
        return ReverseStringBuilder(result);
    }
    private static string ReverseStringBuilder(StringBuilder sb)
    {
        for (int left = 0, right = sb.Length - 1; left < right; left++, right--)
        {
            (sb[left], sb[right]) = (sb[right], sb[left]);
        }
        return sb.ToString();
    }
    public static int[] PlusOne(int[] digits)
    {
        int n = digits.Length;

        // Traverse from the last digit
        for (int i = n - 1; i >= 0; i--)
        {
            if (digits[i] < 9)
            {
                digits[i]++;
                return digits; // No carry, return early
            }
            digits[i] = 0; // Carry over
        }

        // If all digits were 9, we need a new array
        int[] newArr = new int[n + 1];
        newArr[0] = 1;
        return newArr;
    }
    public static int LengthOfLastWord(string s)
    {
        return s.Trim().Split(' ').Last().Length;
    }
    public static int SearchInsert(int[] nums, int target)
    {
        int i;
        for (i = 0; i < nums.Length; i++)
        {
            if (nums[i] == target)
                return i;
            else if (nums[i] > target)
                return i;

        }

        return i;
    }
    public static int StrStr(string haystack, string needle)
    {
        if (string.IsNullOrEmpty(needle)) return 0;
        int n = haystack.Length, m = needle.Length;
        if (n < m) return -1;

        int[] lps = new int[m];
        int j = 0;
        ComputeLPS(needle, m, lps);

        int i = 0;
        while (i < n)
        {
            if (haystack[i] == needle[j])
            {
                i++; j++;
            }
            if (j == m) return i - j;
            else if (i < n && haystack[i] != needle[j])
            {
                if (j != 0) j = lps[j - 1];
                else i++;
            }
        }
        return -1;
    }
    private static void ComputeLPS(string pattern, int m, int[] lps)
    {
        int length = 0, i = 1;
        while (i < m)
        {
            if (pattern[i] == pattern[length])
                lps[i++] = ++length;
            else if (length != 0)
                length = lps[length - 1];
            else
                lps[i++] = 0;
        }
    }
    public static int RemoveElement(int[] nums, int val)
    {
        //List<int> list = new List<int>();
        //list.AddRange(nums);
        //int k = 0;
        //list.RemoveAll(x =>
        //{
        //    if (x == val)
        //        k++;
        //    return x == val;
        //});

        //for (int i = 0; i < list.Count; i++)
        //{
        //    nums[i] = list[i];
        //}

        //Array.Resize(ref nums, list.Count);

        int k = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != val) // If the element is not the target value
            {
                nums[k] = nums[i]; // Move it to the front
                k++;
            }
        }

        return k; // k represents the new length of the array
    }
    public static int RemoveDuplicates(int[] nums)
    {
        HashSet<int> sortedSet = new HashSet<int>();
        foreach (var item in nums)
            sortedSet.Add(item);

        int counter = 0;

        foreach (var item in sortedSet)
        {
            nums[counter] = item;
            counter++;
        }
        return sortedSet.Count;
    }
    public static bool IsValid(string s)
    {
        if (s.Length % 2 != 0) return false;

        Stack<char> stack = new Stack<char>();
        foreach (char ch in s)
        {
            switch (ch)
            {
                case '(':
                case '{':
                case '[':
                    stack.Push(ch);
                    break;
                case ')':
                    if (stack.Count == 0 || stack.Pop() != '(') return false;
                    break;
                case '}':
                    if (stack.Count == 0 || stack.Pop() != '{') return false;
                    break;
                case ']':
                    if (stack.Count == 0 || stack.Pop() != '[') return false;
                    break;
                default:
                    return false;
            }
        }

        return stack.Count == 0;
    }
    public static string LongestCommonPrefix(string[] strs)
    {
        //["flower", "flow", "flight"]

        // should return fl
        if (strs == null || strs.Length == 0)
            return "";

        string prefix = strs[0];

        for (int i = 1; i < strs.Length; i++)
        {
            while (strs[i].IndexOf(prefix) != 0)
            {
                prefix = prefix.Substring(0, prefix.Length - 1);
                if (prefix == "")
                    return "";
            }
        }

        return prefix;
    }
    public static ListNode MergeTwoLists(ListNode list1, ListNode list2)
    {
        ArrayList list = new ArrayList();

        foreach (var item in list1)
            list.Add(item);

        foreach (var item in list2)
            list.Add(item);

        list.Sort();

        ListNode headNode = new ListNode((int)list[0]);
        ListNode currentNode = headNode;
        int counter = 1;
        while (counter < list.Count)
        {

            currentNode.next = new ListNode((int)list[counter]);
            currentNode = currentNode.next;
            counter++;
        }
        return headNode;
    }
    public static int RomanToInt(string s)
    {
        Dictionary<char, int> romanMap = new Dictionary<char, int>
        {
            {'I', 1},
            {'V', 5},
            {'X', 10},
            {'L', 50},
            {'C', 100},
            {'D', 500},
            {'M', 1000}
        };

        int total = 0;
        int prevValue = 0;

        for (int i = s.Length - 1; i >= 0; i--)
        {
            int currentValue = romanMap[s[i]];

            if (currentValue < prevValue)
                total -= currentValue;
            else
                total += currentValue;

            prevValue = currentValue;
        }

        return total;
    }
    public static int[] GetSum(int[] arr, int target)
    {
        Dictionary<int, int> number = new Dictionary<int, int>();


        for (int i = 0; i < arr.Length; i++)
        {
            int complement = target - arr[i];

            if (number.ContainsKey(arr[i]))
            {
                return new int[] { number[arr[i]], i };
            }


            number.Add(complement, i);
        }

        return new int[0];
    }
}