public class Solution {
    public bool IsAnagram(string s, string t) 
    {
        var dict1 = new Dictionary<char, int>();
        var dict2 = new Dictionary<char, int>();

        foreach (var ch in s)
        {
            if(dict1.ContainsKey(ch))
            {
                dict1[ch]++;
            }
            else
            {
                dict1.Add(ch,1);
            }
        }
        foreach (var ch in t)
        {
            if(dict2.ContainsKey(ch))
            {
                dict2[ch]++;
            }
            else
            {
                dict2.Add(ch,1);
            }
        }

        foreach(KeyValuePair<char,int> kv in dict1)
        {
            if(dict2.TryGetValue(kv.Key, out var value))
            {
                if(value!=kv.Value) return false;
            }
            else{
                return false;
            }
        }

        foreach(KeyValuePair<char,int> kv in dict2)
        {
            if(dict1.TryGetValue(kv.Key, out var value))
            {
                if(value!=kv.Value) return false;
            }
            else{
                return false;
            }
        }

        return true;
    }
}
