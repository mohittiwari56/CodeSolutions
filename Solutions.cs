using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CodePractice
{
    internal class Solutions
    {
        public static bool IsPowerOfThree(int n)
        {
            //find the remainder and keep dividing untill it is = 1 means it is a pwner of 3
            while (n % 3 == 0) n /= 3;
            return n == 1;
        }

        /// <summary>
        /// https://leetcode.com/problems/number-of-zero-filled-subarrays/?envType=daily-question&envId=2025-08-19
        /// Example 1: Input: nums = [1,3,0,0,2,0,0,4] Output: 6
        ///Explanation: 
        ///There are 4 occurrences of[0] as a subarray.
        ///There are 2 occurrences of [0,0] as a subarray.
        ///There is no occurrence of a subarray with a size more than 2 filled with 0. Therefore, we return 6.
        ///Example 2: Input: nums = [0, 0, 0, 2, 0, 0] Output: 9
        ///Explanation:
        ///There are 5 occurrences of [0] as a subarray.
        ///There are 3 occurrences of [0,0] as a subarray.
        ///There is 1 occurrence of [0,0,0] as a subarray.
        ///There is no occurrence of a subarray with a size more than 3 filled with 0. Therefore, we return 9.
        ///Example 3: Input: nums = [2, 10, 2019] Output: 0
        ///Explanation: There is no subarray filled with 0. Therefore, we return 0.
        /// </summary>
        /// <param name="nums">int array</param>
        /// <returns></returns>
        public static long ZeroFilledSubarray(int[] nums)
        {
            long zeroCounter = 0;

            for (long num = 0; num <= nums.Length - 1; num++)
            {
                if (nums[num] == 0)
                {
                    zeroCounter++;
                    for (long subNum = num + 1; subNum < nums.Length - 1; subNum++)
                    {
                        if (nums[subNum] == 0) zeroCounter++;
                        else break;
                    }
                }
            }

            return zeroCounter;
        }

        /// <summary>
        /// Given an array of integers nums and an integer target, return indices of the two numbers such that they add up to target.
        ///You may assume that each input would have exactly one solution, and you may not use the same element twice.
        ///You can return the answer in any order.
        ///Example 1: Input: nums = [2, 7, 11, 15], target = 9 Output: [0,1]
        ///Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].
        /// </summary>
        /// <param name="nums"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public static int[] TwoSum(int[] nums, int target)
        {
            int[] ans = new int[nums.Length - 1];
            for (int i = 0; i <= nums.Length - 1; i++)
            {
                for (int j = i + 1; j <= nums.Length - 1; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        ans = [i, j];
                    }
                }
            }
            return ans;
        }

        public string getWrongAnswers(int N, string C)
        {
            var ans = string.Empty;
            for (int i = 0; i < N; i++)
            {
                if (C[i] == 'A') ans += "B";
                else ans += "A";
            }
            return ans;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="l1"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static double getHitProbability(int R, int C, int[,] G)
        {
            var shipCount = 0;
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (G[i, j] == 1) shipCount++;
                }
            }

            if (shipCount == 0) return 0.0;
            return (double)shipCount / (R * C);
        }


        public static long getMaxAdditionalDinersCount(long N, long K, int M, long[] S)
        {
            Array.Sort(S);
            long availableSpots = 0;
            bool isEligible = false;
            long[] arrAvailableSeats;
            long i = 1;
            //for (long i = 1; i <= N; i++)
            while (i <= N)
            {
                for (long j = 0; j < M; j++)
                {
                    if (i == S[j] || i + K == S[j] || i - K == S[j])
                    {
                        isEligible = false;
                        break;
                    }
                    else
                    {
                        isEligible = true;
                    }
                }

                if (isEligible)
                {
                    availableSpots++;
                    i = i + K * 2;
                }
                else i++;
            }
            return availableSpots;
        }

        public static long getMaxAdditionalDinersCount1(long N, long K, int M, long[] S)
        {
            Array.Sort(S);
            long availableSpots = 0;
            bool isEligible = false;
            long startValue = 1;

            for (long i = 0; i < M; i++)
            {
                //calculate available slots between initial value and first value of S

                if (startValue == 1 && startValue + K < S[i] - K)
                {
                    availableSpots++;
                }
                if ((S[i] - startValue - K * 2 - 1) > 0)
                {
                    availableSpots += S[i] - startValue - (K * 2) - 1;
                }

                startValue = S[i];
            }
            if (startValue < N)
            {
                if (N - startValue - (K * 2) - 1 > 0)
                {
                    availableSpots += N - startValue - (K * 2) - 1;
                }
                if (N - K > startValue + K)
                {
                    availableSpots++;
                }
            }

            return availableSpots;
        }
        //public static int LengthOfLongestSubstringWithoutDuplicateCharacters(string s)
        //{
        //    brute force
        //    //s="abcabcbb"; //3
        //    //s = "bbbbb"; //1
        //    //s = "pwwkew"; //3
        //    //s = "dvdf"; //3 vdf
        //    string subStr = string.Empty;
        //    var subStrs = new List<string>();
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        char c = s[i];
        //        if (!subStr.Contains(c))
        //        {
        //            subStr += c;
        //            if (i == s.Length -1)
        //            {
        //                subStrs.Add(subStr);
        //            }
        //        }
        //        else
        //        {
        //            if (!subStrs.Any(x => x == subStr))
        //            {
        //                subStrs.Add(subStr);
        //            }
        //            subStr = c.ToString();
        //        }
        //    }
        //    return subStrs.Count>0 ? subStrs.Max(x => x.Length): 0;
        //}

        public static int LengthOfLongestSubstringWithoutDuplicateCharacters(string s)
        {
            //sliding window
            if (string.IsNullOrEmpty(s)) return 0;
            int maxLength = 0;
            int start = 0;
            var seen = new Dictionary<char, int>();

            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                if (seen.ContainsKey(c) && seen[c] >= start)
                {
                    start = seen[c] + 1;
                }
                seen[c] = i;
                maxLength = Math.Max(maxLength, i - start + 1);
            }
            return maxLength;

        }

        public static string AddTwoNumbersLinkedList(ListNode? l1, ListNode? l2)
        {
            int nodeSum = l1.val + l2.val;
            int carryOver = 0;
            if (l1.next == null && l2.next == null)
            {   
                return nodeSum.ToString();
            }

            if(nodeSum > 9)
            {   
                carryOver = 1;
                nodeSum -= 10;
            }

            ListNode resultNode = new(nodeSum, null); //first result node
            var firstResultNode = resultNode;
            while (l1.next != null) // || l2 == null || l2.next != null)
            {
                nodeSum = 0;
                l1 = l1 != null && l1.next != null ? l1.next : null;

                l2 = l2 != null && l2.next != null ? l2.next : null;

                if (l1 != null) { nodeSum += l1.val;}

                if (l2 != null) { nodeSum += l2.val; }

                nodeSum += carryOver;
                carryOver = 0;
                if (nodeSum > 9)
                {
                    nodeSum = nodeSum - 10;
                    carryOver = 1;
                }

                var newNode = new ListNode(nodeSum, null);

                resultNode.next = newNode;

                resultNode = newNode;
            }
            if (carryOver == 1)
            {
                resultNode.next = new(carryOver, null);
            }

            string result = $"{firstResultNode.val}";
            while (firstResultNode.next != null) {
                firstResultNode = firstResultNode.next;
                result = string.Concat(result, $",{firstResultNode.val}"); 
            }

            return result;
        }
    }
}
