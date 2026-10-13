// https://leetcode.com/problems/number-of-islands/description/

namespace Task200;

class Program
{
    public class Solution {
        
        public static void CheckNeighbours(char[][] grid, int i, int j)
        {
            if (i > 0 && grid[i - 1][j] == '1')
            {
                grid[i - 1][j] = '0';
                CheckNeighbours(grid, i - 1, j);
            }
            
            if (i < grid.Length - 1 && grid[i + 1][j] == '1')
            {
                grid[i + 1][j] = '0';
                CheckNeighbours(grid, i + 1, j);
            }
            
            if (j > 0 && grid[i][j - 1] == '1')
            {
                grid[i][j - 1] = '0';
                CheckNeighbours(grid, i, j - 1);
            }

            if (j >= grid[i].Length - 1 || grid[i][j + 1] != '1') return;
            
            grid[i][j + 1] = '0';
            CheckNeighbours(grid, i, j + 1);
        }
        
        public int NumIslands(char[][] grid)
        {
            var count = 0;
            
            for (var i = 0; i < grid.Length; i++)
            for (var j = 0; j < grid[i].Length; j++)
            {
                if (grid[i][j] == '0') continue;

                count += 1;

                grid[i][j] = '0';
                
                CheckNeighbours(grid, i, j);
            }

            return count;
        }
    }
    
    static void Main(string[] args)
    {
        var sol = new Solution();

        var result = sol.NumIslands(
            new char[][]
            {
                ['1','1','0','0','0'],
                ['1','1','0','0','0'],
                ['0','0','1','0','0'],
                ['0','0','0','1','1']
            });
        
        Console.WriteLine(result);
    }
}