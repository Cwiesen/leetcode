string input = "a";
Solution sln = new Solution();
string answer = sln.LongestPalindrome(input);
Console.WriteLine($"Answer: {answer}");

public class Solution
{
    public string LongestPalindrome(string s)
    {
        for (int start = 0; start < s.Length; start++)
        {
            for (int length = s.Length - start; length > 1; length--)
            {
                if (checkPal(s, start, length + start))
                {
                    return s.Substring(start, length);
                }
            }
        }
        return "";
    }

    bool checkPal(string s, int start, int end)
    {
        int left = start;
        int right = end - 1;
        while (left < right)
        {
            if (s[left] != s[right])
            {
                return false;
            }
            left++;
            right--;
        }
        return true;
    }
}

public class FirstSolution
{
    public string LongestPalindrome(string s)
    {
        if (s.Length == 0)
        {
            return "";
        }
        string palindrome = s[0].ToString();
        int mid = 1;
        while (mid < s.Length)
        {
            int left = mid - 1, right = mid + 1;
            string currentPal = getPalindrome(s, s[mid].ToString(), left, right);
            if (currentPal.Length > palindrome.Length)
            {
                palindrome = currentPal;
            }
            mid++;
        }
        return palindrome;
    }

    string getPalindrome(string fullString, string currentPal, int left, int right)
    {
        string updatedPal = currentPal;
        char leftChar = left < 0 ? char.MinValue : fullString[left], rightChar = right == fullString.Length ? char.MaxValue : fullString[right];
        if (leftChar == rightChar)
        {
            {
                updatedPal = $"{leftChar}{updatedPal}{rightChar}";
                left--;
                right++;
                return getPalindrome(fullString, updatedPal, left, right);
            }
        }
        else if (right < fullString.Length)
        {
            //check for even char palindrome to right
            char currentMidChar = currentPal[(int)Math.Floor(currentPal.Length / 2.0)];
            if (currentMidChar == rightChar)
            {
                updatedPal = $"{currentPal}{rightChar}";
                right++;
                return getPalindrome(fullString, updatedPal, left, right);
            }
        }
        else if (left >= 0)
        {
            //check for even char palindrome to left
            char currentMidChar = currentPal[(int)Math.Floor(currentPal.Length / 2.0)];
            if (currentMidChar == leftChar)
            {
                updatedPal = $"{leftChar}{currentPal}";
                left--;
                return getPalindrome(fullString, updatedPal, left, right);
            }
        }
        return updatedPal;
    }
}
