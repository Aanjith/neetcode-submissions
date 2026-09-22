public class Solution {
    public bool IsValidSudoku(char[][] board) 
    {
        Dictionary<int ,List<int>> rowDict = new Dictionary<int ,List<int>>();
        Dictionary<int ,List<int>> columnDict = new Dictionary<int ,List<int>>();
        Dictionary<(int, int) ,List<int>> boxDict = new Dictionary<(int, int) ,List<int>>();
            
        for(int i = 0; i < 9; i++)
        {
            for(int j = 0; j < 9; j++)
            {
                if (!int.TryParse(board[i][j].ToString(), out int result))
                {
                    continue;
                }

                var boxIndex = GetBoxIndex(i,j);
                if(boxDict.ContainsKey(boxIndex))//dict contains key
                {
                    if(IsElementInList(boxDict[boxIndex],result))
                    {
                        return false;
                    }
                    else
                    {
                        boxDict[boxIndex].Add(result);
                    }
                }
                else
                {
                    boxDict[boxIndex] = new List<int>{result};
                }

                if(columnDict.ContainsKey(j))//dict contains key
                {
                    if(IsElementInList(columnDict[j],result))
                    {
                        return false;
                    }
                    else
                    {
                        columnDict[j].Add(result);
                    }
                }
                else
                {
                    columnDict[j] = new List<int>{result};
                }

                if(rowDict.ContainsKey(i))//dict contains key
                {
                    if(IsElementInList(rowDict[i],result))
                    {
                        return false;
                    }
                    else
                    {
                        rowDict[i].Add(result);
                    }
                }
                else
                {
                    rowDict[i] = new List<int>{result};
                }
            }
        }

        
        

        return true;

    }

    public (int, int) GetBoxIndex(int x, int y)
    {
        int a = x/3;
        int b = y/3;
        return (a,b);
    }

    public static bool IsElementInList(List<int> list, int element)
    {
        var result = list.Contains(element)? true: false;
        return result;
    }
}
