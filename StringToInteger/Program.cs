string input = "-+12";
int answer = new Solution().MyAtoi(input);
Console.WriteLine(answer);

public class Solution
{
    public int MyAtoi(string s)
    {
        string workingString = s.TrimStart();
        if (workingString.Length < 1)
        {
            return 0;
        }
        int index = 0;
        string charString = "";
        bool isPositive = true;
        if (workingString[index] == '-')
        {
            isPositive = false;
            index++;
        }
        else if (workingString[index] == '+')
        {
            index++;
        }
        int startIndex = index;

        while (index < workingString.Length)
        {
            if (Char.IsDigit(workingString[index]))
            {
                charString += workingString[index];
            }
            else
            {
                break;
            }
            index++;
        }
        if (charString.Length < 1)
        {
            return 0;
        }
        int parsedString;
        if (int.TryParse(charString, out parsedString))
        {
            return isPositive ? parsedString : parsedString * -1;
        }
        return isPositive ? int.MaxValue : int.MinValue;
    }
}
