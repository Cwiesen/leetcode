string search = "abc";
string regex = ".*c";
bool answer = new Solution().IsMatch(search, regex);
Console.WriteLine($"Is match? {answer}");

public class Solution
{
    /*
    Loop through string
    Loop through regex
    if regex is char, check next char
    if next char *, check for multiple
    else check single
    */
    public bool IsMatch(string s, string p)
    {
        int i = 0;
        while (i < s.Length)
        {
            for (int j = 0; j < p.Length; j++)
            {
                if (i == s.Length)
                {
                    return false;
                }
                if (j < p.Length - 1 && p[j + 1] == '*')
                {
                    int numPass = passesMultiple(s, p[j], i);
                    if (numPass >= 0)
                    {
                        i += numPass;
                        //Skip over asterisk in regex
                        j++;
                    }
                }
                else
                {
                    if (p[j] == '.')
                    {
                        i++;
                    }
                    else if (p[j] == s[i])
                    {
                        i++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            if (i < s.Length)
            {
                return false;
            }
        }
        return true;
    }

    public int passesMultiple(string s, char c, int index)
    {
        int i = index;
        int count = 0;
        while (i < s.Length)
        {
            if (c == '.')
            {
                count++;
                i++;
            }
            else if (s[i] == c)
            {
                count++;
                i++;
            }
            else
            {
                break;
            }
        }
        return count;
    }
}
