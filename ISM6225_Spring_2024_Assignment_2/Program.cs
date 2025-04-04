using System;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: Find Missing Numbers in Array
            Console.WriteLine("Question 1:");
            int[] nums1 = { 4, 3, 2, 7, 8, 2, 3, 1 };
            IList<int> missingNumbers = FindMissingNumbers(nums1);
            Console.WriteLine(string.Join(",", missingNumbers));

            // Question 2: Sort Array by Parity
            Console.WriteLine("Question 2:");
            int[] nums2 = { 3, 1, 2, 4 };
            int[] sortedArray = SortArrayByParity(nums2);
            Console.WriteLine(string.Join(",", sortedArray));

            // Question 3: Two Sum
            Console.WriteLine("Question 3:");
            int[] nums3 = { 2, 7, 11, 15 };
            int target = 9;
            int[] indices = TwoSum(nums3, target);
            Console.WriteLine(string.Join(",", indices));

            // Question 4: Find Maximum Product of Three Numbers
            Console.WriteLine("Question 4:");
            int[] nums4 = { 1, 2, 3, 4 };
            int maxProduct = MaximumProduct(nums4);
            Console.WriteLine(maxProduct);

            // Question 5: Decimal to Binary Conversion
            Console.WriteLine("Question 5:");
            int decimalNumber = 42;
            string binary = DecimalToBinary(decimalNumber);
            Console.WriteLine(binary);

            // Question 6: Find Minimum in Rotated Sorted Array
            Console.WriteLine("Question 6:");
            int[] nums5 = { 3, 4, 5, 1, 2 };
            int minElement = FindMin(nums5);
            Console.WriteLine(minElement);

            // Question 7: Palindrome Number
            Console.WriteLine("Question 7:");
            int palindromeNumber = 121;
            bool isPalindrome = IsPalindrome(palindromeNumber);
            Console.WriteLine(isPalindrome);

            // Question 8: Fibonacci Number
            Console.WriteLine("Question 8:");
            int n = 4;
            int fibonacciNumber = Fibonacci(n);
            Console.WriteLine(fibonacciNumber);
        }

        // Question 1: Find Missing Numbers in Array
        public static IList<int> FindMissingNumbers(int[] nums)
        {
            try
            {
                // Write your code here
                // Using HashSet to find missing numbers
                HashSet<int> numSet = new HashSet<int>(nums);

                // Find the range of numbers ( 1 to the max numbers in the array)
                int max = nums.Length;

                // Craeate a list to store missing numbers 
                List<int> missingNumbers = new List<int>();

                // Iterate through the range and check if each number is in the set
                for (int i = 1; i <= max; i++)
                {
                    if (!numSet.Contains(i))
                    {
                        missingNumbers.Add(i);
                    }
                }
                return missingNumbers;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 2: Sort Array by Parity
        public static int[] SortArrayByParity(int[] nums)
        {
            try
            {
                // Initialize two pointers: left at the beginning, right at the end.
                int left = 0, right = nums.Length - 1;
                // Loop until the two pointers meet.
                while (left < right)
                {
                    // If the left element is odd and the right element is even, swap them.
                    if (nums[left] % 2 != 0 && nums[right] % 2 == 0)
                    {
                        int temp = nums[left];
                        nums[left] = nums[right];
                        nums[right] = temp;
                    }
                    // If the element at left is even, move the left pointer to the right.
                    if (nums[left] % 2 == 0)
                    {
                        left++;
                    }
                    // If the element at right is odd, move the right pointer to the left.
                    if (nums[right] % 2 != 0)
                    {
                        right--;
                    }
                }
                // Return the array with evens at the front and odds at the back.
                return nums;
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 3: Two Sum
        public static int[] TwoSum(int[] nums, int target)
        {
            try
            {
                 // Create a dictionary to map numbers to their indices for fast lookup.
                Dictionary<int, int> map = new Dictionary<int, int>();
                // Loop over each element in the array.
                for (int i = 0; i < nums.Length; i++)
                {
                    // Calculate the complement needed to reach the target.
                    int complement = target - nums[i];
                    // If the complement exists in the dictionary, return its index and the current index.
                    if (map.ContainsKey(complement))
                    {
                        return new int[] { map[complement], i };
                    }
                    // Add the current number and its index to the dictionary.
                    map[nums[i]] = i;
                }
                // Return an empty array if no valid pair is found.
                return new int[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 4: Find Maximum Product of Three Numbers
        public static int MaximumProduct(int[] nums)
        {
            try
            {
                // Sort the array
                Array.Sort(nums);

                // Calculate the product of the three largest numbers
                int n = nums.Length;
                int product1 = nums[n - 1] * nums[n - 2] * nums[n - 3];

                // Calculate the product of the two smallest numbers and the largest number
                int product2 = nums[0] * nums[1] * nums[n - 1];

                // Return the maximum of the two products
                return Math.Max(product1, product2);
                
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 5: Decimal to Binary Conversion
        public static string DecimalToBinary(int decimalNumber)
        {
            try
            {
                // Use the built-in Convert.ToString method with base 2 to convert the decimal number to its binary representation.
                return Convert.ToString(decimalNumber, 2);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 6: Find Minimum in Rotated Sorted Array
        public static int FindMin(int[] nums)
        {
            try
            {
                // Initialize the left and right pointers.
                int left = 0, right = nums.Length - 1;

                // Loop until the left pointer is less than the right pointer.
                while (left < right)
                {
                    // Calculate the mid-point.
                    int mid = left + (right - left) / 2;

                    // If the middle element is greater than the rightmost element, the minimum is in the right half.
                    if (nums[mid] > nums[right])
                    {
                        left = mid + 1;
                    }
                    // Otherwise, the minimum is in the left half or could be the middle element.
                    else
                    {
                        right = mid;
                    }
                }
                // Return the minimum element found at the left pointer.
                return nums[left];
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 7: Palindrome Number
        public static bool IsPalindrome(int x)
        {
            try
            {
                // Negative numbers are not palindromes.
                if (x < 0) return false;

                // store the original number
                int original = x;
                int reversed = 0;

                // reverse the number
                while (x > 0)
                {
                    // Get the last digit
                    int digit = x % 10;
                    // Build the reversed number
                    reversed = reversed * 10 + digit;
                    // Remove the last digit from x
                    x /= 10;
                }
                // Check if the original number is equal to the reversed number
                return original == reversed;
        
            }
            catch (Exception)
            {
                throw;
            }
        }

        // Question 8: Fibonacci Number
        public static int Fibonacci(int n)
        {
            try
            {
                // Base cases
                if (n == 0) return 0;
                if (n == 1) return 1;

                // Initialize the first two Fibonacci numbers
                int prev1 = 0; //F(0)
                int prev2 = 1; //F(1)

                // variable to store the curernt Fibonacci number
                int current = 0;

                // compute Fibonacci numbers iteratively
                for (int i = 2; i <= n; i++)
                {
                    // Calculate the current Fibonacci number
                    current = prev1 + prev2;
                    // Update the previous two numbers for the next iteration
                    prev1 = prev2;
                    prev2 = current;
                }
                // Return the nth Fibonacci number
                return current;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
