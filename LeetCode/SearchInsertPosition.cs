﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LeetCodeSolutionsLib
{
    public class SearchInsertPosition :Solution
    {
        /** Problem: Search Insert Position
         *
         *  Given a sorted array and a target value, return the index if the target is found. If not, rerun the index where it would be if it were inserted in order.
         *
         *  Example:
         *  Input:      [1, 3, 5, 6]    Target = 5
         *  Output :    2
         *  Explanation: Target '5' is found in the array at the index position [2]
         */
        private int[] nums;
        private int target;

        public SearchInsertPosition(int[] nums, int target)
        {
            this.nums = nums;
            this.target = target;
        }

        private int SearchInsertBruteForce(int[] nums, int target)
        {
            //Brute Force:
            //Time Complexity:  O(2n) where n = number of elements in the array
            //Space Complexity: O(1)
            //Loop through each int in the array.
            //1)      If the number is found, return the index of the position in the array.
            //2)      Else, we need to return the index of where the number should be.
            
            //If the target is less than the first number in the array, then we need to return 0
            if (target < nums[0])
            {
                return 0;
            }
            //1)
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] == target)
                {
                    return i;
                }
            }
            //2) Number is not in the array, so we must find its correct intended position
            //I will loop through each number again, and find where [i-1] < target < [i+1]
            for (int i = 0; i < nums.Length; i++)
            {
                if (i > 0)
                {
                    if (nums[i - 1] < target && target < nums[i])
                    {
                        return i;
                    }
                }
            }
            return nums.Length;
        }

        private int SearchInsert(int[] nums, int target)
        {
            /*
             * Time Complexity:  O(n) where n = number of elements in the array
             * Space Complexity: O(1)
             * 1)    Check if the target is less than the first number in the array, Or string.Length == 0.
             * IE:   [1, 5, 7] , Target = -1       Output: 0
             * 
             * 2)    Check if target is greater than the last number in the array.
             * IE:   [1, 5, 7] , Target = 10       Output: nums.Length => 3
             * 
             * 3)    Otherwise the target number exists in the array or inbetween 2 numbers in the array.
             *       Loop through each number from i = 1 and check if the number is >= target.
             *       If true, then return i index
             * IE:   [1, 5, 7] , Target = 6       Output: 2
             * 4)    Otherwise, the target should be at the end of the array
             * */
            //1)
            if (target <= nums[0] || nums.Length == 0)
            {
                return 0;
            }
            //2)
            if (target > nums[nums.Length - 1])
            {
                return nums.Length;
            }
            //3)
            for (int i = 1; i < nums.Length; i++)
            {
                if (nums[i] >= target)
                {
                    return i;
                }
            }

            //Otherwise, the target should be at the end of the array
            return nums.Length;
        }
        public override void PrintExample()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            var results = SearchInsert(this.nums, this.target);
            watch.Stop();
            Console.WriteLine($"35. Search Insert Position \n" +
                              $"Input String = [1, 3, 5, 10] Target = [{target}]\n" +
                              $"Result: [{results}] \n" +
                              $"Execution Speed: {watch.ElapsedMilliseconds}ms \n");
        }
    }
}
