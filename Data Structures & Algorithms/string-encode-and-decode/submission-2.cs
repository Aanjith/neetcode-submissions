public class Solution {

    private const int Step = 3;

    public string Encode(IList<string> strs) 
    {
        List<int> separator = new List<int>();
        for(int i = 0; i < strs.Count; i++)//var value in strs)
        {
            separator.Add(strs[i].Length);
            strs[i] = Stepper(strs[i], Step);
        }

        string encodedString ="(";

        for(int i = 0; i < separator.Count; i++)
        {
            encodedString += separator[i].ToString();
            if(i == separator.Count -1)
            {
                encodedString += "";
            }
            else
            {
                encodedString += ",";
            }
        }
        encodedString += ")";

        foreach(var value in strs)
        {
            encodedString+=value;
        }
        
        return encodedString;
    }

    public List<string> Decode(string s) 
    {
        var answerList = new List<string>();
        var indexString = "";
        var stringStart = 0;

        for(int i = 0; i<s.Length; i++)//var ch in s)
        {
            if(s[i] == '(') continue;
            else if(s[i] == ')') 
            {
                stringStart = i+1;
                break;
            }

            else indexString+= s[i].ToString();
        }

        List<int> numbers = indexString.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                         .Where(s => int.TryParse(s, out _))
                         .Select(int.Parse)
                         .ToList();

        for(int i = 0; i < numbers.Count; i++)
        {
            if(numbers[i] == 0)
            {
                answerList.Add("");
            }
            else
            {
            var word = s.Substring(stringStart,numbers[i]);
            stringStart+=numbers[i];
            answerList.Add(Stepper(word,-Step));
            }
        }

        return answerList;
        

    }

   public string Stepper(string rawString, int step)
   {
        List<char> newStringArray = new List<char>();
        foreach(char ch in rawString)
        {
            var ch1 = (char)((int)ch + step);
            newStringArray.Add(ch1);
        }

        return string.Join("", newStringArray);
   }
}
