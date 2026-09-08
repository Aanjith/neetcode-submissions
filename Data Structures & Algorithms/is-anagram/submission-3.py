class Solution:
    def isAnagram(self, s: str, t: str) -> bool:

        check_list = [0] * 26

        if len(s) != len(t):
            return False

        for i in range(len(s)):
            ch1 = ord(s[i]) - ord('a')
            ch2 = ord(t[i]) - ord('a')

            check_list[ch1] += 1
            check_list[ch2] -= 1

        
        for i in check_list:
            if i != 0:
                return False
        

        return True

        