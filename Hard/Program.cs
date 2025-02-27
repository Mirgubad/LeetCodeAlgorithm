﻿class Program
{
    public static void Main(string[] args)
    {

    }

    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
            return FindMedianSortedArrays(nums2, nums1); // Ensure nums1 is the smaller array

        int x = nums1.Length, y = nums2.Length;
        int low = 0, high = x;

        while (low <= high)
        {
            int partitionX = (low + high) / 2;
            int partitionY = (x + y + 1) / 2 - partitionX;

            int maxLeftX = (partitionX == 0) ? int.MinValue : nums1[partitionX - 1];
            int minRightX = (partitionX == x) ? int.MaxValue : nums1[partitionX];

            int maxLeftY = (partitionY == 0) ? int.MinValue : nums2[partitionY - 1];
            int minRightY = (partitionY == y) ? int.MaxValue : nums2[partitionY];

            if (maxLeftX <= minRightY && maxLeftY <= minRightX)
            {
                if ((x + y) % 2 == 0)
                    return (Math.Max(maxLeftX, maxLeftY) + Math.Min(minRightX, minRightY)) / 2.0;
                else
                    return Math.Max(maxLeftX, maxLeftY);
            }
            else if (maxLeftX > minRightY)
            {
                high = partitionX - 1; // Move towards left in nums1
            }
            else
            {
                low = partitionX + 1; // Move towards right in nums1
            }
        }

        throw new InvalidOperationException("Arrays are not sorted properly");
    }

}