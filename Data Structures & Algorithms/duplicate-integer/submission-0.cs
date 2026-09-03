public class Solution {
    public bool hasDuplicate(int[] nums) 
    {
        HashSet<int> hashSet = new HashSet<int>();
        foreach(var num in nums)
        {
            if(hashSet.Contains(num))
            {
                return true;
            }
            else
            {
                hashSet.Add(num);
            }
        }
        return false;
    }
}