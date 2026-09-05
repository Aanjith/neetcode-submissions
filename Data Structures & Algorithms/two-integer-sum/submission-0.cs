public class Solution {
    public int[] TwoSum(int[] nums, int target) 
    {
        Dictionary<int,int> dict1 = new Dictionary<int,int>();
        

        for(int i = 0; i<nums.Length; i++ )
        {
            if(dict1.ContainsKey(target - nums[i]))
            {
                int[] array = [ dict1[target-nums[i]], i];
                return array;
            }
            else
            {
                dict1.Add(nums[i],i);
            }
        }
        return [];
    }
}
