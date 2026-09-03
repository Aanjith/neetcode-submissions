public class Solution {
    public bool hasDuplicate(int[] nums) 
    {
        if(nums.Length <= 0) return false;
        HashSet<int> hashSet = new HashSet<int>();
        foreach(var num in nums)
        {
            if(!hashSet.Add(num))
            {
                return true;
            }
        }
        return false;
    }
}