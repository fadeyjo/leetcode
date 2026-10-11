// https://leetcode.com/problems/two-sum/description/

var sol = new Solution();

var nums = new[] {3, 3};
var target = 6;

var result = sol.TwoSum(nums, target);

Console.WriteLine($"{result[0]}, {result[1]}");

public class Solution {
    public int[] TwoSum(int[] nums, int target) {
        if (nums.Length < 2) throw new ArgumentException("Массив имеет меньше двух элементов");
        
        for (var i = 0; i < nums.Length - 1; i++)
        for (var j = i + 1; j < nums.Length; j++)
            if (nums[i] + nums[j] == target)
                return [i, j];

        throw new ArgumentException("Для данных аргументов отсутствует решение");
    }
}