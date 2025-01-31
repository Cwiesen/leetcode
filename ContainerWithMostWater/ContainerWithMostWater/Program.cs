int[] heights = new int[] { 1, 8, 6, 2, 5, 4, 8, 3, 7 };
int answer = new Solution().MaxArea(heights);
Console.WriteLine(answer);

public class Solution
{
    // Start with 2 pointers, 1 at each end of array
    // Check both directions, move pointer that results in smaller box
    // 
    public int MaxArea(int[] height)
    {
        int left = 0;
        int right = height.Length - 1;
        int currentMaxArea = 0;
        while (left < right)
        {
            int newArea = calculateArea(height, left, right);
            if (currentMaxArea < newArea)
            {
                currentMaxArea = newArea;
            }
            if (height[left] < height[right])
            {
                left++;
            }
            else
            {
                right--;
            }
        }
        return currentMaxArea;
    }

    public int calculateArea(int[] height, int left, int right)
    {
        int x = right - left;
        int y = height[left] > height[right] ? height[right] : height[left];
        return x * y;
    }
}
