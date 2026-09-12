public class Solution {
    public int[] TopKFrequent(int[] nums, int k) 
    {
        Dictionary<int, int> dict = new Dictionary<int, int>();

        foreach(var num in nums)
        {
            if(dict.ContainsKey(num))
            {
                dict[num] ++;
            }
            else
            {
                dict.Add(num,1);
            }
        }

        List<int>[] bucket = new List<int>[nums.Length + 1];
        foreach(var kvp in dict)
        {
            if(bucket[kvp.Value] == null)
            {
                bucket[kvp.Value] = new List<int>();
            }
            bucket[kvp.Value].Add(kvp.Key);        
        }

        List<int> answerList = new List<int>();

        for(int i = nums.Length; i>=0; i--)
        {
            if(bucket[i] != null)
            answerList.AddRange(bucket[i]);
            if(answerList.Count >= k)
            {
                break;
            }
        }

        return answerList.ToArray();
    }
}
