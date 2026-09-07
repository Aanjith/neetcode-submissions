public class Solution {
    public List<List<string>> GroupAnagrams(string[] strs) 
    {
        var dupStrs = new string[strs.Length];
        for(int i = 0; i<strs.Length; i++)
        {
            dupStrs[i] = strs[i];
        } 
        var dict = new Dictionary<string, List<int>>();
        List<List<string>> list = new List<List<string>>();

        for(int i = 0; i<dupStrs.Length; i++)
        {
            char[] chars = dupStrs[i].ToCharArray();
            Array.Sort(chars);
            dupStrs[i] = new string(chars);

            if(dict.ContainsKey(dupStrs[i]))
            {
                dict[dupStrs[i]].Add(i);
            }
            else
            dict.Add(dupStrs[i],new List<int>{i});
        }

        foreach(var kvp in dict)
        {
            var sublist = new List<string>();
            foreach(var num in kvp.Value)
            {
                sublist.Add(strs[num]);
            }
            list.Add(sublist);
        }

        return list;
    }
}
