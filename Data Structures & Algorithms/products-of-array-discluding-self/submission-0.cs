public class Solution {
    public int[] ProductExceptSelf(int[] nums) 
    {
        int[] prefixSum = new int[nums.Length];
        int[] suffixSum = new int[nums.Length];
        int[] result = new int[nums.Length];

        for(int i = 0; i<nums.Length; i++)
        {
            if(i == 0)
            {
                prefixSum[i] = nums[i];    
            }
            else
            {
                prefixSum[i] = prefixSum[i-1] * nums[i];
            }
        }

        for(int i = nums.Length-1; i>=0; i--)
        {
            if(i == nums.Length-1)
            {
                suffixSum[i] = nums[i];    
            }
            else
            {
                suffixSum[i] = suffixSum[i+1] * nums[i];
            }
        }

        for(int i = nums.Length-1; i>=0; i--)
        {
            if(i == nums.Length-1 && nums.Length-1 != 0)
            {
                result[i] = prefixSum[i-1];    
            }
            else if (i == 0)
            {
                result[i] = suffixSum[i+1];
            }
            else
            {
                result[i] = prefixSum[i-1] * suffixSum[i+1];
            }
        }

        return result;
    }
}
