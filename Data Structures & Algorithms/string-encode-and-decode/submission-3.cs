public class Solution {

    private const int Step = 3;

    public string Encode(IList<string> strs) 
    {
        List<int> chunkLength = new List<int>();
        string encodedString2 = "";
        for(int i = 0; i < strs.Count; i++)//var value in strs)
        {
            chunkLength.Add(strs[i].Length);
            strs[i] = Encoder(strs[i], Step);
            encodedString2 += strs[i];
            
        }

        string encodedString ="(";

        for(int i = 0; i < chunkLength.Count; i++)
        {
            encodedString += chunkLength[i].ToString();
            if(i == chunkLength.Count -1)
            {
                encodedString += "";
            }
            else
            {
                encodedString += ",";
            }
        }
        encodedString = encodedString + ")" + encodedString2;
        
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
            answerList.Add(Encoder(word,-Step));
            }
        }

        return answerList;
        

    }

   public string Encoder(string rawString, int step)
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
