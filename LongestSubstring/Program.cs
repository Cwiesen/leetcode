LongestSubstringSolution sln = new LongestSubstringSolution();
string input = "aaaaaaaffdddddddddddddd";
int answer = sln.LengthOfLongestSubstring(input);
Console.WriteLine("Finished with " + answer);

public class LongestSubstringSolution
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0)
        {
            return 0;
        }
        int longestSubstring = 0;
        for (int start = 0; start < s.Length; start++)
        {
            List<char> charList = [s[start]];
            //Need to check substring if it occurs at end of string
            bool isUnique = true;
            for (int end = start + 1; end < s.Length; end++)
            {
                if (charList.Contains(s[end]))
                {
                    isUnique = false;
                    int subLen = end - start;
                    if (longestSubstring < subLen)
                    {
                        longestSubstring = subLen;
                    }
                    break;
                }
                charList.Add(s[end]);
            }
            if (isUnique)
            {
                int subLen = s.Length - start;
                if (longestSubstring < subLen)
                {
                    longestSubstring = subLen;
                }
            }
        }
        return longestSubstring;
    }
}


public class SolutionFirstRun
{
    public int LengthOfLongestSubstring(string s)
    {
        if (s.Length == 0)
        {
            return 0;
        }
        List<string> strList = generateSubStrings(s);
        int longestSubstring = 1;
        foreach (string substr in strList)
        {
            Console.WriteLine("Current string: " + substr);
            List<char> charList = [];
            bool isUnique = true;
            for (int i = 0; i < substr.Length; i++)
            {
                if (charList.Contains(substr[i]))
                {
                    Console.WriteLine("invalid");
                    isUnique = false;
                    break;
                }
                charList.Add(substr[i]);
            }
            if (isUnique)
            {
                int subLen = substr.Length;
                if (longestSubstring < subLen)
                {
                    longestSubstring = subLen;
                }
            }

        }
        Console.WriteLine("Longest string: " + longestSubstring);
        return longestSubstring;
    }

    private List<string> generateSubStrings(string s)
    {
        List<string> substrings = [];
        for (int i = 0; i < s.Length; i++)
        {
            // We start at j = 2 because we don't care about single character strings 
            for (int j = 2; j < s.Length - i + 1; j++)
            {
                string substring = s.Substring(i, j);
                substrings.Add(substring);
            }
        }
        return substrings;
    }
}
