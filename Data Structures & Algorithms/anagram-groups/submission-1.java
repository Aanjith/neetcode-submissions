class Solution {
    public List<List<String>> groupAnagrams(String[] strs) 
    {
        String[] sortedArray = new String[strs.length]; 

        for(int i = 0; i<strs.length; i++)
        {
            sortedArray[i] = SortString(strs[i]);
        }

        HashMap<String, List<String>> pairs = new HashMap<>();
        for(int i = 0; i < sortedArray.length; i++)
        {
            if (!pairs.containsKey(sortedArray[i])) 
            {
                pairs.put(sortedArray[i],new ArrayList<>(List.of(strs[i])));
            }
            else
            {
                List<String> value = pairs.get(sortedArray[i]);
                value.add(strs[i]);
            }
        }

        List<List<String>> answer = new ArrayList<>();

        for (Map.Entry<String, List<String>> entry : pairs.entrySet()) 
        {
            answer.add(new ArrayList<>(entry.getValue()));
        }

        return answer;
    }

    private String SortString(String S)
    {
        String original = S;
        char[] chars = original.toCharArray();
        Arrays.sort(chars);
        String sorted = new String(chars);
        return sorted;
    }
}
