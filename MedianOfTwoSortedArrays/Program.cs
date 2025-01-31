using System.ComponentModel.DataAnnotations;

int[] nums1 = [1, 3];
int[] nums2 = [2];
double answer = Solution.FindMedianSortedArrays(nums1, nums2);
Console.WriteLine(answer);

public class Solution
{
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        int[] mergedArray = mergeSort(nums1, nums2);
        double medianIndex = mergedArray.Length / 2.0;
        if (Double.IsInteger(medianIndex))
        {
            int med1 = mergedArray[(int)medianIndex - 1];
            int med2 = mergedArray[(int)medianIndex];
            return (med1 + med2) / 2.0;

        }
        else
        {
            return mergedArray[(int)Double.Floor(medianIndex)];
        }
    }

    private static int[] mergeSort(int[] nums1, int[] nums2)
    {
        int[] merged = new int[nums1.Length + nums2.Length];
        int num1Index = 0;
        int num2Index = 0;
        while (num1Index < nums1.Length && num2Index < nums2.Length)
        {
            int currentNum1 = nums1[num1Index];
            int currentNum2 = nums2[num2Index];
            if (currentNum1 < currentNum2)
            {
                merged[num1Index + num2Index] = currentNum1;
                num1Index++;
            }
            else
            {
                merged[num1Index + num2Index] = currentNum2;
                num2Index++;
            }
        }
        if (num1Index == nums1.Length)
        {
            int length = nums2.Length - num2Index;
            Array.Copy(nums2, num2Index, merged, num1Index + num2Index, length);
        }
        else
        {
            int length = nums1.Length - num1Index;
            Array.Copy(nums1, num1Index, merged, num1Index + num2Index, length);
        }
        return merged;
    }
}
