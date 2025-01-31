Solution sln = new Solution();
string answer = sln.Convert("PAYPALISHIRING", 3);
Console.WriteLine(answer);

public class Solution
{
    // numRows - 2 zag rows (eg 1 zag for 3 rows, 2 zag for 4 rows, etc)
    public string Convert(string s, int numRows)
    {
        // How many row types there are
        int numCases = numRows * 2 - 2;
        string[] zzArray = new string[numRows];
        if (numCases == 0)
        {
            return s;
        }
        for (int i = 0; i < s.Length; i++)
        {
            int check = i % numCases;
            if (check < numRows)
            {
                zzArray[check] += s[i];
            }
            else
            {
                zzArray[numCases - check] += s[i];
            }
        }
        string zzString = "";
        foreach (string zz in zzArray)
        {
            zzString += zz;
        }
        return zzString;
    }
}

