// See https://aka.ms/new-console-template for more information
using CodePractice;

Console.WriteLine("Power of 3, 27");
Console.WriteLine($"output is {Solutions.IsPowerOfThree(27)}");
int[] arr = [1, 3, 0, 0, 2, 0, 0, 4];
Console.WriteLine($"ZeroFilledSubarray Test 1 [1,3,0,0,2,0,0,4], output = {Solutions.ZeroFilledSubarray(arr)}");

arr = [2, 7, 11, 15];
var output = Solutions.TwoSum(arr, 9);
Console.WriteLine($"TwoSum Test 1 [2, 7, 11, 15], output = {output}");


int[,] G = { {0, 0, 1 }, {1, 0,1 } };
Console.WriteLine($"Hit Probability ={Solutions.getHitProbability(2, 3, G)}");

long[] arr1 = [2, 6];
Console.WriteLine($"Avaialble Spots= {Solutions.getMaxAdditionalDinersCount1(10, 1, 2, arr1)}");

arr1 = [11, 6, 14];
Console.WriteLine($"Avaialble Spots= {Solutions.getMaxAdditionalDinersCount1(15, 2, 3, arr1)}");

Console.WriteLine($"LengthOfLongestSubstringWithoutDuplicateCharacters= " +
    $"{Solutions.LengthOfLongestSubstringWithoutDuplicateCharacters("abcabcbb")}");
Console.WriteLine($"LengthOfLongestSubstringWithoutDuplicateCharacters= " +
    $"{Solutions.LengthOfLongestSubstringWithoutDuplicateCharacters("pwwkew")}");//aaab
Console.WriteLine($"LengthOfLongestSubstringWithoutDuplicateCharacters= " +
    $"{Solutions.LengthOfLongestSubstringWithoutDuplicateCharacters("dvdf")}");

var l1 = new ListNode(2, new(4, new(3, null)));
var l2 = new ListNode(5, new(6, new(4, null)));

Console.WriteLine("Linded List Add Two numbers l1=2,4,3 l2=5,6,4 and Output=" + $"{Solutions.AddTwoNumbersLinkedList(l1, l2)}");

l1 = new ListNode(0, null); l2 = new ListNode(0, null);

Console.WriteLine("Linded List Add Two numbers l1=0 l2=0 and Output=" + $"{Solutions.AddTwoNumbersLinkedList(l1, l2)}");
l1 = new ListNode(9, new(9, new(9, new(9, new (9, new(9, new (9, null)))))));
l2 = new ListNode(9, new(9, new(9, new(9, null))));

Console.WriteLine("Linded List Add Two numbers l1=[9,9,9,9,9,9,9], l2 = [9,9,9,9] and Output=" + $"{Solutions.AddTwoNumbersLinkedList(l1, l2)}");
