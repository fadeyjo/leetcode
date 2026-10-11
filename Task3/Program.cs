// https://leetcode.com/problems/longest-substring-without-repeating-characters/

var sol = new Solution();

var s = "pwwkew";

var result = sol.LengthOfLongestSubstring(s);

Console.WriteLine(result);

public class Solution {
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0) return 0;
        
        var left = 0;
        var right = 0;

        var max = 1;
        var set = new HashSet<char>();

        while (true)
        {
            var subString = s.Substring(left, right - left + 1);
            set.Add(s[right]);

            if (set.Count == subString.Length)
            {
                if (right == s.Length - 1)
                    return Math.Max(max, subString.Length);

                max = Math.Max(max, subString.Length);
                right++;
                continue;
            }

            if (left < right)
            {
                set.Remove(s[left]);
                left += 1;
                continue;
            }

            return max;
        }
    }
}